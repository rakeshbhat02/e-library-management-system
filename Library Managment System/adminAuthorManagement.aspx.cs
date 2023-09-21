using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class adminAuthorManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("adminLogin.aspx");
            }
            if (IsPostBack)
            {
                MessagePanel.Visible = false;
            }
            GridView1.DataBind();
        }
        //Add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                ShowMessage(" Author with this ID already exists. You cannot add another author with same ID");
            }
            else
            {
                addNewAuthor();
            }

        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
                

            }
            else
            {
                ShowMessage("Author with this ID does not exist");
            }

        }
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();


            }
            else
            {
                ShowMessage("Author with this ID does not exist");
            }
        }
        //Go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }
        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT into author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);
                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Retrieve the current author name from the database for comparison
                SqlCommand getAuthorNameCmd = new SqlCommand("SELECT author_name FROM author_master_tb1 WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                string currentAuthorName = getAuthorNameCmd.ExecuteScalar() as string;

                // Check if the new author name is different from the current author name
                if (currentAuthorName != TextBox2.Text.Trim())
                {
                    // The author name has changed, so proceed with the update
                    SqlCommand cmd = new SqlCommand("UPDATE author_master_tb1 SET author_name=@author_name WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Author Updated Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                else
                {
                    // The author name has not changed, display a message or take appropriate action
                    ShowMessage("No changes made to the author name.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from author_master_tb1 WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where author_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();  
                }
                else
                {
                    ShowMessage("Invalid Author ID");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               
            }
        }
        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where author_id = '" + TextBox1.Text.Trim() + "';",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;  
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
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