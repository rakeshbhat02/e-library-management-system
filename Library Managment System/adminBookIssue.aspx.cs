using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class adminBookIssue : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("adminLogin.aspx");
            }

            GridView1.DataBind();
            


        }
        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getBookandMemberNames();
        }
        //Issue Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            int currentStock = 0;
            bool bookExists = checkIfBookExists(out currentStock);
            bool memberExists = checkIfMemberExists(); // Check if member exists first
            
            if (bookExists && memberExists)
            {
                int booksIssuedToMember = GetNoOfBooksIssued(); // Get the number of books already issued to the member
                if (booksIssuedToMember >= 3)
                {
                    Response.Write("<script>alert('This Member already has 3 books!');</script>");
                }
                else if (currentStock > 0)
                {
                    if (checkIfAlreadyIssued())
                    {
                        Response.Write("<script>alert('This Member already has this book!');</script>");
                        clearForm();
                    }
                    else
                    {
                        issueBook();
                        Response.Write("<script>alert('Book Issued Successfully');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No stock available for this book.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
            }
        }

        //Return Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            int currentStock = 0; // Initialize currentStock

            // Check if the book exists and retrieve the current stock
            bool bookExists = checkIfBookExists(out currentStock);
            bool memberExists = checkIfMemberExists(); // Check if member exists first

            if (bookExists && memberExists)
            {
                if (checkIfAlreadyIssued())
                {
                    if (currentStock >= 0)
                    {
                        returnBook();
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('No stock available for this book.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID');</script>");
            }
        }


        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                

                SqlCommand cmd = new SqlCommand("INSERT into book_issue_tb1(member_id, member_name, book_id, book_name, issue_date, due_date) " +
                                                "values(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());

                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO transactions (member_id, book_id, transaction_type, transaction_date) " +
                                    "VALUES (@member_id, @book_id, 'Issue', GETDATE())", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tb1 set current_stock = current_stock - 1 WHERE book_id = '" + TextBox2.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();

                con.Close();

                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tb1 WHERE book_id = '"+TextBox2.Text.Trim()+ "' AND member_id = '" + TextBox1.Text.Trim() + "';", con);
                
                int result = cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO transactions (member_id, book_id, transaction_type, transaction_date) VALUES (@member_id, @book_id, 'Return', GETDATE())", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    cmd = new SqlCommand("UPDATE book_master_tb1 set current_stock = current_stock+1 WHERE book_id = '" + TextBox2.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Returned Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                    con.Close();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid Details');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getBookandMemberNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tb1 where book_id = '" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }
                
                cmd = new SqlCommand("SELECT full_name from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + "';", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID');</script>");
                }
                cmd = new SqlCommand("SELECT issue_date from book_issue_tb1 where member_id='" + TextBox1.Text.Trim() + "' AND book_id = '" + TextBox2.Text.Trim() + "';", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox5.Text = dt.Rows[0]["issue_date"].ToString();
                }
                else
                {
                    TextBox5.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                cmd = new SqlCommand("SELECT due_date from book_issue_tb1 where member_id='" + TextBox1.Text.Trim() + "' AND book_id = '" + TextBox2.Text.Trim() + "';", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox6.Text = dt.Rows[0]["due_date"].ToString();
                }
                else
                {
                    TextBox6.Text = "";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkIfBookExists(out int currentStock)
        {
            currentStock = 0; // Initialize the currentStock variable

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tb1 WHERE book_id = @BookID;", con);
                cmd.Parameters.AddWithValue("@BookID", TextBox2.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    currentStock = Convert.ToInt32(dt.Rows[0]["current_stock"]);
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('Book not found.');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        bool checkIfAlreadyIssued()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tb1 where member_id = '" + TextBox1.Text.Trim() + "' AND book_id = '" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.ForeColor = System.Drawing.Color.White;

                   
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected string CalculateFine(object dueDateObj)
        {
            if (dueDateObj != DBNull.Value)
            {
                DateTime dueDate = Convert.ToDateTime(dueDateObj);
                DateTime currentDate = DateTime.Now;

                // Calculate the number of days overdue
                int daysOverdue = (currentDate - dueDate).Days;

                // Calculate the fine (5 rupees per day overdue)
                if (daysOverdue > 0)
                {
                    int fineAmount = daysOverdue * 5;
                    
                    return fineAmount.ToString()+" Rupees";
                }
            }

            // Return empty string if there's no fine
            return "No Fine";
        }



        int GetNoOfBooksIssued()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from book_issue_tb1 where member_id = '" + TextBox1.Text.Trim() + "'", con);
                int numberOfBooksIssued = (int)cmd.ExecuteScalar();
                return numberOfBooksIssued;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return -1; // Handle the error gracefully; return -1 or another appropriate value
            }
        }



    }

}