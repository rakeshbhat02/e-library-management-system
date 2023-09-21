<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="Library_Managment_System.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-md-6 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="imgs/generaluser.png" width="150" />
  
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member Login</h3>
                            </center>
                        </div>

                    </div>
                      <div class="row">
                        <div class="col">
                            <center>
                                <hr />
                            </center>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            <label>Member ID</label>
                            <div class="form-group">
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Member ID"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator1"
        runat="server"
        ControlToValidate="TextBox1"
        InitialValue=""
        ErrorMessage="Member ID is required."
        ForeColor="Red"
        Display="Dynamic"
    />
</div>

                            <label>Password</label>
                           <div class="form-group">
    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator2"
        runat="server"
        ControlToValidate="TextBox2"
        InitialValue=""
        ErrorMessage="Password is required."
        ForeColor="Red"
        Display="Dynamic"
    /></div>
                            <div>
    <div>
    <a href="ForgotPassword.aspx">Forgot Password?</a>
</div>
</div>

                            <div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                            </div>
                            <a href="userSignup.aspx">
                            <div class="form-group">
                                <input id="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign Up" />
                            </div>
                                </a>
                        </div>

                    </div>
                </div>
            </div>
            <a href="homePage.aspx"><< Go to Home</a>
            <br /><br />
        </div>
    </div>
</asp:Content>
