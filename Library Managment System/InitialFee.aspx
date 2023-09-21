<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InitialFee.aspx.cs" Inherits="Library_Managment_System.InitialFee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <form action="InitialFeeReturn.aspx" method="post" name="razorpayForm">
            <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
            <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
            <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
        </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <center> <button class="gem-button gem-button-size-tiny gem-button-style-outline gem-button-text-weight-normal gem-button-border-2 gem-button-empty" id="rzp-button1" style="    width: 108px;">Pay Now</button></center>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script>
            var orderId = "<%=orderId%>"
            
            var options = {
                "name": "<%=product%>",
                "description": "<%=product%>",
                "order_id": orderId,
                "prefill": {
                    "name": "<%=name%>",
            "email": "<%=email%>",
            "contact": "<%=contact%>",
        },
        "notes": {
            "address": "<%=address%>",
                    "merchant_order_id": "<%=orderIds%>",
                },
                "theme": {
                    "color": "#F37254"
                }
            }
   
            options.theme.image_padding = false;
            options.handler = function (response) {
                document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
                document.getElementById('razorpay_order_id').value = orderId;
                document.getElementById('razorpay_signature').value = response.razorpay_signature;
                document.razorpayForm.submit();
            };
            options.modal = {
                ondismiss: function () {
                    console.log("This code runs when the popup is closed");
                },
        
                escape: true,
           
                backdropclose: false
            };
            var rzp = new Razorpay(options);
            document.getElementById('rzp-button1').onclick = function (e) {
                rzp.open();
                e.preventDefault();
            }
        </script>

</asp:Content>
