<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="Library_Managment_System.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(document).ready(function () {
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });
</script>

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
    <style>
        .red-link {
    color: red;
}

    </style>


       
  <asp:Panel ID="MessagePanel" runat="server" Visible="false" CssClass="alert-panel" style="position: fixed; top: 20px; left: 50%; transform: translateX(-50%); background-color: #f5f5f5; text-align: center; padding: 10px; border-radius: 5px; box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); z-index: 999;">
    <asp:Label ID="MessageLabel" runat="server" Text="" CssClass="alert-text" ForeColor="#f44336"></asp:Label>
    <asp:Button ID="CloseButton" runat="server" Text="&#10006;" OnClick="CloseButton_Click" CssClass="btn btn-sm btn-light" CausesValidation="false" />
</asp:Panel>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 mx-auto">
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
                                <h3>Your Profile</h3>
                                <span>Account Status -</span>
                                <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Your Status"></asp:Label>
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
                        <div class="col-md-6">
                            <label>Full Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Date of Birth</label>
                            <div class="form-group">
                               <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Date" onblur="validateDOBClientSide(this.value);"></asp:TextBox>


               <asp:Label ID="ValidationMessageLabel" runat="server" ForeColor="Red" Text=""></asp:Label>



                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Contact Number</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3"
            ValidationExpression="^[0-9]{10}$" ErrorMessage="Please Enter 10 Digits." ForeColor="Red" Display="Dynamic" />                           
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
    <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ControlToValidate="TextBox4"
        ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
        ErrorMessage="Please enter a valid email address."
        Display="Dynamic" ForeColor="Red" />
</div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Select" Value="select"/>
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
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox6" placeholder="City" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>Pincode</label>
                            <div class="form-group">
    <asp:TextBox ID="TextBox7" placeholder="Pincode" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
    <asp:RegularExpressionValidator ID="PincodeValidator" runat="server" ControlToValidate="TextBox7"
        ValidationExpression="^\d{6}$"
        ErrorMessage="Please enter a 6-digit PIN code."
        Display="Dynamic" ForeColor="Red" />
</div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <label>Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Type your full address here" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                        <div class="col-md-4">
                            <label>Member ID</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Old Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" TextMode="Password" placeholder="Old Password" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>New Password</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server" placeholder="New Password"></asp:TextBox>
                            </div>
                        </div>


                    </div>
                    <div class="row">
                        <div class="col-8 mx-auto">
                            
                            
                            <div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClick="Button1_Click" />
                            </div>
                            
                        </div>

                    </div>
                </div>
            </div>
            
        </div>
            <div class="col-md-7">
                <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <img src="imgs/books.png" width="100" />
  
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Your Issued Books</h3>
                                
                                <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your book info"></asp:Label>
                                
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [book_issue_tb1]"></asp:SqlDataSource>
    <div class="col">
        <center>
            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                    <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                    <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                    <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                    <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                    <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />

                    <asp:TemplateField HeaderText="fine" SortExpression="fine">
                        <ItemTemplate>
                            <asp:Label ID="FineLabel" runat="server" Text='<%# CalculateFine(Eval("due_date")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="status" SortExpression="status">
                        <ItemTemplate>
                            <asp:Label ID="StatusLabel" runat="server" Text='Not Paid'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="TotalFineLabel" runat="server" Text="Total Fine:"></asp:Label>
            <asp:Label ID="TotalFineValueLabel" runat="server" Text="0.00 Rupees"></asp:Label>

            <br />
            <br />
            
               <center>
 
                   <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="red-link">Click here to pay the fine</asp:LinkButton>
                   

</center>

            
            



       
    </div>
</div>

                 
                </div>
            </div>
                </div>
        </div>
            
    </div>
</asp:Content>
