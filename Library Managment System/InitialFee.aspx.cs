using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using System.Net;

namespace Library_Managment_System
{
    public partial class InitialFee : System.Web.UI.Page
    {
        public string orderId;
        public string orderIds;
        public string name;
        public string product;
        public string email;
        public string contact;
        public string address;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {


                    name = "Rakesh Bhat";
                    product = "Membership Fee";
                    email = "rakeshaedurkala@gmail.com";
                    contact = "7975969789";
                    address = "Mysuru";


                    Session["product"] = product;
                    Session["fee"] = "100";

                    Dictionary<string, object> input = new Dictionary<string, object>();

                    decimal amount = 100;

                    string orders = System.DateTime.Now.Ticks.ToString();
                    orderIds = orders;

                    input.Add("amount", amount * 100);
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