using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_full_name, global_dob, global_contact_no, global_email, global_state, global_city, global_pincode, global_address;
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!IsPostBack)
                {
                    GridView1.DataBind();
                   
                }
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();
                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                        
                    }
                }
                
                CalculateAndDisplayTotalFine();
                if (Session["paymentSuccessful"] != null && (bool)Session["paymentSuccessful"])
                {
                    UpdateStatusToPaid();

                    // Reset the session variable to prevent multiple updates
                    Session["paymentSuccessful"] = false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
            
            
            
        }
        private void UpdateStatusToPaid()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                // Find the status column in your GridView (you may need to adjust the column index)
                Label statusLabel = row.Cells[7].FindControl("StatusLabel") as Label;
                Label fineLabel = row.Cells[6].FindControl("FineLabel") as Label;
                // Update the status to "Paid"
                if (fineLabel != null && fineLabel.Text != "No Fine")
                {
                    if (statusLabel != null)
                    {
                        statusLabel.Text = "Paid";
                        statusLabel.ForeColor = System.Drawing.Color.White;
                        statusLabel.BackColor = System.Drawing.Color.Green;
                    }
                }
                    
            }
            TotalFineValueLabel.Text = "0.00 Rupees";
            LinkButton1.Visible = false;
            ShowMessage("Please take a screenshot.");
        }
        //Update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }
        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tb1 where member_id = '" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["dob"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["full_address"].ToString();
                TextBox8.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();
                
                global_full_name = dt.Rows[0]["full_name"].ToString();
                global_dob = dt.Rows[0]["dob"].ToString();
                global_contact_no = dt.Rows[0]["contact_no"].ToString();
                global_email = dt.Rows[0]["email"].ToString();
                global_state = dt.Rows[0]["state"].ToString().Trim();
                global_city = dt.Rows[0]["city"].ToString();
                global_pincode = dt.Rows[0]["pincode"].ToString();
                global_address = dt.Rows[0]["full_address"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "Active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "Deactivated")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Calculate the total fine (replace this with your logic)
            decimal totalFine = CalculateTotalFine();

            // Redirect to PayNow.aspx with the totalFine as a query parameter
            Response.Redirect($"PayNow.aspx?totalFine={totalFine}");
        }

        void updateUserPersonalDetails()
        {
            bool changesMade = false;
            
            

            // Check if TextBox10 contains a new password value
            

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string newFullName = TextBox1.Text.Trim();

                string newDob = TextBox2.Text.Trim();
                string newContact = TextBox3.Text.Trim();
                string newEmail = TextBox4.Text.Trim();
                string newState = DropDownList1.SelectedItem.Value;
                string newCity = TextBox6.Text.Trim();
                string newPincode = TextBox7.Text.Trim();
                string newAddress = TextBox5.Text.Trim();
                string password = GetPasswordFromDatabase();
                if (newFullName != global_full_name ||
                     newDob != global_dob ||
                     newContact != global_contact_no ||
                     newEmail != global_email ||
                     newState != global_state ||
                     newCity != global_city ||
                     newPincode != global_pincode ||
                     newAddress != global_address ||
                      !string.IsNullOrWhiteSpace(TextBox10.Text.Trim())
                     )
                {
                    changesMade = true;
                }
                if (newFullName == global_full_name &&
                    newDob == global_dob &&
                    newContact == global_contact_no &&
                    newEmail == global_email &&
                    newState == global_state &&
                    newCity == global_city &&
                    newPincode == global_pincode &&
                    newAddress == global_address &&
                    string.IsNullOrWhiteSpace(TextBox10.Text.Trim())
                    )
                {
                    ShowMessage("No changes were made to your personal details.");
                    return;
                }
                // Retrieve the current password from the database

                if (!string.IsNullOrWhiteSpace(TextBox10.Text))
                {
                    password = TextBox10.Text.Trim(); // Update with the new password if provided
                }




                SqlCommand cmd = new SqlCommand("update member_master_tb1 set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (changesMade)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private string GetPasswordFromDatabase()
        {
            string member_id = Session["username"].ToString().Trim();
            string password = ""; // Initialize with an empty string

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Assuming you have a table called 'user_credentials' with columns 'username' and 'password'
                SqlCommand cmd = new SqlCommand("SELECT password FROM member_master_tb1 WHERE member_id = @member_id", con);
                cmd.Parameters.AddWithValue("@member_id", member_id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    password = reader["password"].ToString(); // Retrieve the password from the database
                }

                con.Close();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database access
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            return password;
        }

        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.ForeColor = System.Drawing.Color.White;
                    }
                    Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                    Label fineLabel = (Label)e.Row.FindControl("FineLabel");

                    // Check the text of the fine label
                    if (fineLabel != null && fineLabel.Text == "No Fine")
                    {
                        // Set the status label text to "-"
                        statusLabel.Text = "-";
                    }

                }
            
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        
        private decimal CalculateTotalFine()
        {
            decimal totalFine = 0;

            foreach (GridViewRow row in GridView1.Rows)
            {
                string dueDateStr = row.Cells[5].Text;
                string fineStr = CalculateFine(dueDateStr);

                if (fineStr.Equals("No Fine", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                else
                {
                    string numericFineStr = fineStr.Replace(" Rupees", "").Trim();

                    if (decimal.TryParse(numericFineStr, out decimal fine))
                    {
                        totalFine += fine;
                    }
                }
            }

            return totalFine;
        }

        private void UpdateTotalFineLabel(decimal totalFine)
        {
            string formattedTotalFine = totalFine.ToString("0.00") + " Rupees";
            TotalFineValueLabel.Text = formattedTotalFine;

            // Display or hide the LinkButton based on the totalFine value
            LinkButton1.Visible = totalFine > 0;
        }

       

        protected void CalculateAndDisplayTotalFine()
        {
            decimal totalFine = CalculateTotalFine();
            UpdateTotalFineLabel(totalFine);
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

                    return fineAmount.ToString() + " Rupees";
                }
            }

            // Return empty string if there's no fine
            return "No Fine";
        }
        
        void ShowMessage(string message)
        {
            MessageLabel.Text = message;
            MessagePanel.Visible = true;
        }
        protected void CloseButton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
        }
        


    }
}