<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Library_Managment_System.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1>Reset Password</h1><br />
        <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <asp:Label ID="Label4" runat="server" Text="New Password"></asp:Label><br />
<asp:TextBox ID="password" runat="server" Placeholder="Enter your Password" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvPassword" runat="server"
    ControlToValidate="password"
    InitialValue=""
    ErrorMessage="Password is required"
    Display="Dynamic"
    ForeColor="Red">
</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="password"
    ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$"
    ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one number."
    Display="Dynamic" ForeColor="Red" /><br /><br />

<asp:Label ID="Label1" runat="server" Text="Confirm Password"></asp:Label><br />
<asp:TextBox ID="confirm_password" runat="server" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server"
    ControlToValidate="confirm_password"
    InitialValue=""
    ErrorMessage="Confirm Password is required"
    Display="Dynamic"
    ForeColor="Red">
</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="confirm_password"
    ControlToCompare="password" Operator="Equal"
    ErrorMessage="Passwords do not match" Display="Dynamic" ForeColor="Red" /><br />

        
           
        
        <asp:Button ID="resetBtn" runat="server" Text="Submit" OnClick="resetBtn_Click" />
                </asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Link is expired."></asp:Label><br />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
