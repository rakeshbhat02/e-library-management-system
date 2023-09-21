using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null || string.IsNullOrEmpty(Session["role"].ToString()))
                {
                    LinkButton1.Visible = true;//user login link button
                    LinkButton2.Visible = true;//user signup link button
                    LinkButton3.Visible = false;//logout link button
                    LinkButton7.Visible = false;//hello user link button
                    LinkButton5.Visible = false;
                    LinkButton6.Visible = true;//admin login link button
                    LinkButton11.Visible = false;//admin login link button
                    LinkButton12.Visible = false;//admin login link button
                    LinkButton8.Visible = false;//admin login link button
                    LinkButton9.Visible = false;//admin login link button
                    LinkButton10.Visible = false;//admin login link button
                    LinkButton13.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;//user login link button
                    LinkButton2.Visible = false;//user signup link button
                    LinkButton3.Visible = true;//logout link button
                    LinkButton7.Visible = true;//hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton5.Visible = false;
                    LinkButton6.Visible = true;//admin login link button
                    LinkButton11.Visible = false;//admin login link button
                    LinkButton12.Visible = false;//admin login link button
                    LinkButton8.Visible = false;//admin login link button
                    LinkButton9.Visible = false;//admin login link button
                    LinkButton10.Visible = false;//admin login link button
                    LinkButton13.Visible = true;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;//user login link button
                    LinkButton2.Visible = false;//user signup link button
                    LinkButton3.Visible = true;//logout link button
                    LinkButton7.Visible = true;//hello user link button
                    LinkButton7.Text = "Hello Admin";
                    LinkButton5.Visible = true;
                    LinkButton6.Visible = false;//admin login link button
                    LinkButton11.Visible = true;//admin login link button
                    LinkButton12.Visible = true;//admin login link button
                    LinkButton8.Visible = true;//admin login link button
                    LinkButton9.Visible = true;//admin login link button
                    LinkButton10.Visible = true;//admin login link button
                    LinkButton13.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'");
            }

        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBooks.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignup.aspx");
        }
        //logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true;//user login link button
            LinkButton2.Visible = true;//user signup link button
            LinkButton3.Visible = false;//logout link button
            LinkButton7.Visible = false;//hello user link button
            LinkButton5.Visible = false;
            LinkButton6.Visible = true;//admin login link button
            LinkButton11.Visible = false;//admin login link button
            LinkButton12.Visible = false;//admin login link button
            LinkButton8.Visible = false;//admin login link button
            LinkButton9.Visible = false;//admin login link button
            LinkButton10.Visible = false;//admin login link button
            LinkButton13.Visible = false;
            Response.Redirect("homePage.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAuthorManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminPublisherManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookInventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminBookIssue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

       



        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminTransactions.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }
    }
}