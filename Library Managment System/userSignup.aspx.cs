using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class userSignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                MessagePanel.Visible = false;
               
            }
            if (Session["paymentSuccessful"] != null && (bool)Session["paymentSuccessful"])
            {
                LinkButton1.Visible = false;
                Label1.Visible = true;

                // Reset the session variable to prevent multiple updates
                //Session["paymentSuccessful"] = false;
            }
        }
        //Sign Up button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIdExists()) {
                Response.Write("<script>alert('Member ID already exists, Try another ID.');</script>");
            
            }
            else if(!Label1.Visible)
            {
                Response.Write("<script>alert('Please pay the membership fee before signing up.');</script>");
            }
            else
            {
                signupNewMember();
            }
            
        }
        bool checkIdExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tb1 where member_id = '"+TextBox8.Text.Trim()+"';", con);

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
        void signupNewMember()
        {
            try
            {
                // Retrieve user input
                string full_name = TextBox1.Text.Trim();
                string dob = TextBox2.Text.Trim();
                string contact_no = TextBox3.Text.Trim();
                string email = TextBox4.Text.Trim();
                string state = DropDownList1.SelectedItem.Value;
                string city = TextBox6.Text.Trim();
                string pincode = TextBox7.Text.Trim();
                string full_address = TextBox5.Text.Trim();
                string member_id = TextBox8.Text.Trim();
                string password = TextBox9.Text.Trim();

                // Perform field validations
                if (string.IsNullOrWhiteSpace(full_name) ||
                    string.IsNullOrWhiteSpace(dob) ||
                    string.IsNullOrWhiteSpace(contact_no) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(state) ||
                    string.IsNullOrWhiteSpace(city) ||
                    string.IsNullOrWhiteSpace(pincode) ||
                    string.IsNullOrWhiteSpace(full_address) ||
                    
                    
                    !IsValidDateOfBirth(dob) ||
                     
                    !IsValidEmail(email) || 
                    !IsValidPhoneNumber(contact_no) || 
                    !IsValidPincode(pincode)) 
                {
                    ShowMessage("Please fill out all fields correctly.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    ShowMessage("Please enter a password");
                }
                if (!IsPasswordValid(password))
                {
                    ShowMessage("Please enter a valid password");
                    return;
                }
                if (string.IsNullOrWhiteSpace(member_id))
                {
                    ShowMessage("Please enter an ID");
                    return;
                }

                // If all validations pass, proceed with database insert

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tb1(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values" +
                    "(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status);", con);
                cmd.Parameters.AddWithValue("@full_name", full_name);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@contact_no", contact_no);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@pincode", pincode);
                cmd.Parameters.AddWithValue("@full_address", full_address);
                cmd.Parameters.AddWithValue("@member_id", member_id);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");











                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to login.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool IsPasswordValid(string password)
        {
            

            //Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.
            if (password.Length < 8 || !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)"))
            {
                return false;
            }

            return true;
        }

        bool IsValidEmail(string email)
        {
            
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool IsValidPhoneNumber(string phoneNumber)
        {
            
           return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        bool IsValidPincode(string pincode)
        {
         
            return Regex.IsMatch(pincode, @"^\d{6}$");
        }
        bool IsValidDateOfBirth(string dob)
        {
            //Check if the date can be parsed and if the person is at least 18 years old
            if (DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                // Calculate age based on the DOB
                int age = DateTime.Today.Year - dateOfBirth.Year;
                

                // Check if the person is at least 18 years old
                if (age >= 18)
                {
                    return true;
                }
            }

            return false;
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
            

            
            Response.Redirect($"InitialFee.aspx");
        }


    }
}