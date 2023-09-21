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
    public partial class ResetPassword : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string forgot_otp = Request.QueryString["forgot_otp"].ToString();
            string email = Request.QueryString["email"].ToString();

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
                con.Open();
            string checkActivation = "select member_id from member_master_tb1 where email='" + email + "' and forgot_otp='" + forgot_otp + "'";
            SqlCommand checkCMD = new SqlCommand(checkActivation, con);
            SqlDataReader read = checkCMD.ExecuteReader();
            if (read.Read())
            {
                PlaceHolder1.Visible = true;
                PlaceHolder2.Visible = false;
                con.Close();
            }
            else
            {
                PlaceHolder1.Visible = false;
                PlaceHolder2.Visible = true;
                con.Close();
            }
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            
            string email = Request.QueryString["email"].ToString();

            if (password.Text.ToString() == confirm_password.Text.ToString())
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            string updateAcc = "UPDATE member_master_tb1 SET forgot_otp = 0, password = @NewPassword WHERE email = @Email";

                            using (SqlCommand cmdUpdate = new SqlCommand(updateAcc, con, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@NewPassword", password.Text.ToString());
                                cmdUpdate.Parameters.AddWithValue("@Email", email);

                                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit(); // Commit the transaction if successful
                                    lblErrorMsg.Text = "Password reset successful.";
                                    lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    transaction.Rollback(); // Rollback the transaction if no rows were affected
                                    lblErrorMsg.Text = "Password reset failed. Email not found or no changes made.";
                                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback the transaction in case of an exception
                            lblErrorMsg.Text = "An error occurred: " + ex.Message;
                            lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }

            }
            else
            {
                lblErrorMsg.Text = "Password Mismatch: The new password and confirm password fields do not match. Please ensure that both passwords are identical and try again.";

            }
            
        }
    }
}