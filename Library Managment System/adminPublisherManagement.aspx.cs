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
    public partial class adminPublisherManagement : System.Web.UI.Page
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
        
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                ShowMessage("Publisher with this ID already exists. You cannot add another publisher with the same ID");
            }
            else
            {
                addNewPublisher();
            }
        }
        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                updatePublisher();
                
            }
            else
            {
                ShowMessage("Publisher with this ID does not exist");
            }
        }
        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfPublisherExists())
            {
                deletePublisher();

            }
            else
            {
                ShowMessage("Publisher with this ID does not exist");
            }
        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }
        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("INSERT into publisher_master_tb1(publisher_id,publisher_name) values (@publisher_id,@publisher_name)", con);
                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher added successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Retrieve the current publisher name from the database for comparison
                SqlCommand getPublisherNameCmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tb1 WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                string currentPublisherName = getPublisherNameCmd.ExecuteScalar() as string;

                // Check if the new publisher name is different from the current publisher name
                if (currentPublisherName != TextBox2.Text.Trim())
                {
                    // The publisher name has changed, so proceed with the update
                    SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tb1 SET publisher_name=@publisher_name WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Publisher Updated Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                else
                {
                    // The publisher name has not changed, display a message or take appropriate action
                    ShowMessage("No changes made to the publisher name.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tb1 WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher Deleted successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    TextBox2.Text = dt.Rows[0][1].ToString();
                else
                    ShowMessage("Invalid Publisher ID");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id = '" + TextBox1.Text.Trim() + "';", con);
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