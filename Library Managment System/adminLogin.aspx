<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="Library_Managment_System.adminLogin" %>
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
                                <img src="imgs/adminuser.png" width="150" />
  
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Admin Login</h3>
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
                            
                            <div class="form-group">
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Email"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvEmail"
        runat="server"
        ControlToValidate="TextBox1"
        InitialValue=""
        ErrorMessage="Email is required."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
 
</div>

<div class="form-group">
    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvPassword"
        runat="server"
        ControlToValidate="TextBox2"
        InitialValue=""
        ErrorMessage="Password is required."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
</div>

                            <div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                            </div>
                           
                        </div>

                    </div>
                </div>
            </div>
           <b>
               <a href="homePage.aspx"><< Go to Home</a>

           </b> 
            <br /><br /><br /><br /><br /><br /><br /><br />
        </div>
    </div>  
</asp:Content>
