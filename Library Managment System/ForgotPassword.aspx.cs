using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Library_Managment_System
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("select member_id from member_master_tb1 where email = '" + txtEmail.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    con.Close();
                    Random random = new Random();
                    int myRandom = random.Next(10000000, 99999999);
                    string forgot_otp = myRandom.ToString();
                    
                    con.Open();
                    
                    SqlCommand cmdUpdate = new SqlCommand("update member_master_tb1 set forgot_otp = '"+forgot_otp+"' where email = '" + txtEmail.Text.Trim() + "'", con);
                    int a = cmdUpdate.ExecuteNonQuery();
                    con.Close();
                    

                    MailMessage mail = new MailMessage();
                    mail.To.Add(txtEmail.Text.ToString());
                    mail.From = new MailAddress("rakeshaedurkala@gmail.com");
                    mail.Subject = "Password Reset Link";
                    
                    string emailBody = "";

                    emailBody += "<h1>Hello User,</h1>";
                    emailBody += "Click on Below link to reset your password.<br/>";
                    emailBody += "<p><a href='" + "https://localhost:44362/ResetPassword.aspx?forgot_otp=" + forgot_otp + "&email=" + txtEmail.Text.ToString() + "'>click here to reset password</a></p>";
                    emailBody += "Thankyou...";

                    mail.Body = emailBody;
                    mail.IsBodyHtml = true;
                    
                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587; //25 465
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new System.Net.NetworkCredential("rakeshaedurkala@gmail.com", "qmkfcsnkuvqytxir");
                    smtp.Send(mail);
                    
                    lblMessage.Visible = true;

                    lblMessage.Text = "Password reset link sent successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;




                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Your Email is not associated with us.";
                    con.Close();
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}