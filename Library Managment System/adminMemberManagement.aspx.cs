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
    public partial class adminMemberManagement : System.Web.UI.Page
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
        //Go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                getMemberByID();
            }
            else
            {
                ShowMessage("Member ID does not exist");
                clearForm();
            }
            
        }
        //Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Active");
        }
        //Pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Pending");
        }
        //Deactivate button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Deactivated");
        }
        //Delete button 
        protected void Button3_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }
        void deleteMemberByID()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tb1 WHERE member_id = '" + TextBox1.Text.Trim() + "'", con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                ShowMessage("Enter Valid Member ID");
            }
            
        }
        void getMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id = '" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox3.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox5.Text = dr.GetValue(4).ToString();
                        TextBox6.Text = dr.GetValue(5).ToString();
                        TextBox9.Text = dr.GetValue(6).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                    }
                    

                }
                else
                {
                    ShowMessage("Member ID does not exist");
                    clearForm();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tb1 SET account_status = '" + status + "' where member_id = '" + TextBox1.Text.Trim() + "'", con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                ShowMessage("Member ID does not exist");
            }
            
        }
        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id = '" + TextBox1.Text.Trim() + "';", con);
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
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
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