<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userSignup.aspx.cs" Inherits="Library_Managment_System.userSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .initial-fee-label {
    color: #FF0000; /* Red color for emphasis */
    font-weight: bold; /* Make it bold for emphasis */
}
        .paid {
    color: #008000; /* Red color for emphasis */
    font-weight: bold; /* Make it bold for emphasis */
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
       function validateDOBClientSide(value) {
           // Parse the entered date
           var enteredDate = new Date(value);

           // Check if the entered date is a valid date
           if (isNaN(enteredDate.getTime())) {
               // Invalid date format
               document.getElementById('<%= ValidationMessageLabel.ClientID %>').textContent = 'Invalid date format';
            return;
        }

        // Calculate age based on the entered DOB
        var today = new Date();
        var age = today.getFullYear() - enteredDate.getFullYear();

        // Check if the age is above 18
        if (age < 18) {
            // Age is below 18
            document.getElementById('<%= ValidationMessageLabel.ClientID %>').textContent = 'Age must be above 18 years';
        } else {
            // Age is valid
            document.getElementById('<%= ValidationMessageLabel.ClientID %>').textContent = '';
           }
       }
    </script>
    <asp:Panel ID="MessagePanel" runat="server" Visible="false" CssClass="alert-panel" style="position: fixed; top: 20px; left: 50%; transform: translateX(-50%); background-color: #f5f5f5; text-align: center; padding: 10px; border-radius: 5px; box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); z-index: 999;">
    <asp:Label ID="MessageLabel" runat="server" Text="" CssClass="alert-text" ForeColor="#f44336"></asp:Label>
    <asp:Button ID="CloseButton" runat="server" Text="&#10006;" OnClick="CloseButton_Click" CssClass="btn btn-sm btn-light" CausesValidation="false" />
</asp:Panel>
    <div class="container">
        <div class="col-md-8 mx-auto">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="imgs/generaluser.png" width="100" />
  
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member Registration</h3>
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
                            <center>
                          <asp:Label ID="InitialFeeLabel" runat="server" Text="Mandatory Initial Fee: ₹100" CssClass="initial-fee-label"></asp:Label>
                          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false">Click here to pay...</asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text="Paid" CssClass="paid" Visible="false"></asp:Label>

                      </center> 
                        </div>
                       

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
    InitialValue="" ErrorMessage="Please Enter Your Full Name." ForeColor="Red" Display="Dynamic" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Date" onblur="validateDOBClientSide(this.value);"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
        InitialValue="" ErrorMessage="Please Enter Your DOB" ForeColor="Red" Display="Dynamic" />

               <asp:Label ID="ValidationMessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>
    
    
</div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
    <label>Contact Number</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
            InitialValue="" ErrorMessage="Please Enter Your Contact Number" ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3"
            ValidationExpression="^[0-9]{10}$" ErrorMessage="Please Enter 10 Digits." ForeColor="Red" Display="Dynamic" />
    </div>
</div>

                        <div class="col-md-6">
    <label>Email</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ControlToValidate="TextBox4"
            InitialValue="" ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="TextBox4"
            ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
            ErrorMessage="Please Enter a Valid Email Address."
            ForeColor="Red" Display="Dynamic" />
    </div>
</div>


                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Select" Value=""/>
                                    <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh"/>
                                    <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                    <asp:ListItem Text="Assam" Value="Assam" />
                                    <asp:ListItem Text="Bihar" Value="Bihar" />
                                    <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                                    <asp:ListItem Text="Goa" Value="Goa" />
                                    <asp:ListItem Text="Gujarat" Value="Gujarat" />
                                    <asp:ListItem Text="Haryana" Value="Haryana" />
                                    <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                    <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                    <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                    <asp:ListItem Text="Kerala" Value="Kerala" />
                                    <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                    <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                    <asp:ListItem Text="Manipur" Value="Manipur" />
                                    <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                                    <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                    <asp:ListItem Text="Nagaland" Value="Nagaland" />
                                    <asp:ListItem Text="Odisha" Value="Odisha" />
                                    <asp:ListItem Text="Punjab" Value="Punjab" />
                                    <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                    <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                    <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                    <asp:ListItem Text="Telangana" Value="Telangana" />
                                    <asp:ListItem Text="Tripura" Value="Tripura" />
                                    <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                    <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                    <asp:ListItem Text="West Bengal" Value="West Bengal" />

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="StateValidator" runat="server" ControlToValidate="DropDownList1"
            InitialValue="" ErrorMessage="Please select a state" ForeColor="Red" Display="Dynamic" />
                            </div>
                        </div>
                        <div class="col-md-4">
    <label>City</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox6" placeholder="City" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="CityValidator" runat="server" ControlToValidate="TextBox6"
            InitialValue="" ErrorMessage="Please enter your city" ForeColor="Red" Display="Dynamic" />
    </div>
</div>

                        <div class="col-md-4">
    <label>Pincode</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox7" placeholder="Pincode" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="PincodeRequiredValidator" runat="server" ControlToValidate="TextBox7"
            InitialValue="" ErrorMessage="Please enter a pincode" ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="PincodeRegexValidator" runat="server" ControlToValidate="TextBox7"
            ValidationExpression="^\d{6}$" ErrorMessage="Pincode must be exactly 6 digits" ForeColor="Red" Display="Dynamic" />
    </div>
</div>


                    </div>
                    <div class="row">
                        <div class="col-md-12">
    <label>Address</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Type your full address here" TextMode="MultiLine" Rows="2"></asp:TextBox>
        <asp:RequiredFieldValidator ID="AddressRequiredValidator" runat="server" ControlToValidate="TextBox5"
            InitialValue="" ErrorMessage="Please enter your full address" ForeColor="Red" Display="Dynamic" />
    </div>
</div>

                        

                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                        <span class="badge badge-pill badge-info">Login Credentials</span>
                    </center>

                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6">
                            <label>Member ID</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="User ID"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            
                            
                            <div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                            </div>
                            
                        </div>

                    </div>
                </div>
            </div>
            <b>
                <a href="homePage.aspx"><< Go to Home</a>
            </b>
            <br /><br />
        </div>
    </div>
</asp:Content>
