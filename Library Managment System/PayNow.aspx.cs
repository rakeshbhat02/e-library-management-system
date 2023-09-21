using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class PayNow : System.Web.UI.Page
    {
        public string orderId;
        public string orderIds;
        public string name;
        public string product;
        public string email;
        public string contact;
        public string address;
        public decimal totalFine;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("homePage.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["totalFine"] != null)
                    {
                        if (decimal.TryParse(Request.QueryString["totalFine"], out decimal totalFineValue))
                        {
                            // Use the totalFineValue as needed in your page
                            totalFine = totalFineValue;
                        }
                    }

                    name = "Rakesh Bhat";
                    product = "Fine";
                    email = "rakeshaedurkala@gmail.com";
                    contact = "7975969789";
                    address = "Mysuru";

                    
                    Session["product"] = product;
                    Session["fine"] = totalFine.ToString("0.00");
                    Dictionary<string, object> input = new Dictionary<string, object>();

                    decimal amount = totalFine;
                    
                    string orders = System.DateTime.Now.Ticks.ToString();
                    orderIds = orders;
                    
                    input.Add("amount", amount*100);
                    input.Add("currency", "INR");
                    input.Add("receipt", orders);
                    input.Add("payment_capture", 1);

                    string key = "rzp_test_cvwiiVvHjyJrmr";
                    string secret = "J4d2RxfQ97udLpP5JSNuvwSH";

                 
                    RazorpayClient client = new RazorpayClient(key, secret);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    Razorpay.Api.Order order = client.Order.Create(input);
                    orderId = order["id"].ToString();


                }
                catch (Exception ex)
                {

                }
            }
        }
       
    }
}