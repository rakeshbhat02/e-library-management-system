<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMemberManagement.aspx.cs" Inherits="Library_Managment_System.adminMemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
     <center>
         <asp:Panel ID="MessagePanel" runat="server" Visible="false" CssClass="alert-panel">
    <asp:Label ID="MessageLabel" runat="server" Text="" CssClass="alert-text" ForeColor="#f44336"></asp:Label>
    <asp:Button ID="CloseButton" runat="server" Text="&#10006;" OnClick="CloseButton_Click" CssClass="btn btn-sm btn-light" />
</asp:Panel>
     </center>
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member Details</h3>
                                
                            </center>
                        </div>

                    </div>
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
                                <hr />
                            </center>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label>Member ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary" Text="Go" OnClick="LinkButton4_Click"></asp:LinkButton>
                                    <asp:RequiredFieldValidator
                                        ID="rfvMemberID"
                                        runat="server"
                                        ControlToValidate="TextBox1"
                                        InitialValue=""
                                        ErrorMessage="Member ID is required."
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        EnableClientScript="true" />
                                </div>
                                
                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Full Name</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Account Status</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control mr-1" runat="server" placeholder="Status" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-success mr-1" OnClick="LinkButton1_Click"><i class="fa-regular fa-circle-check"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-warning mr-1" OnClick="LinkButton2_Click"><i class="fa-regular fa-circle-pause"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-danger mr-1" OnClick="LinkButton3_Click"><i class="fa-regular fa-circle-xmark"></i></asp:LinkButton>
                                   

                                </div>
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <label>DOB</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"  ReadOnly="True" placeholder="DOB"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Contact Number</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" ReadOnly="True" placeholder="Contact No."></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>
                         <div class="col-md-5">
                            <label>Email ID</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" ReadOnly="True" placeholder="Email"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>State</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"  ReadOnly="True" placeholder="State"></asp:TextBox>
                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>City</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" ReadOnly="True" placeholder="City"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>Pincode</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" ReadOnly="True" placeholder="Pincode"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label>Full Postal Address</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Full Address" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    
                        <div class="row">
                            <div class="col-8 mx-auto">
                                
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClientClick="return confirmDelete();" OnClick="Button3_Click"/>
                                <script type="text/javascript">
                                    function confirmDelete() {
                                        var memberId = document.getElementById('<%= TextBox1.ClientID %>').value;
                                        if (memberId === "") {
                                            // Member ID field is empty, do not show the confirmation dialog
                                            return true;
                                        }

                                        // Show the confirmation dialog for other cases
                                        return confirm('Are you sure you want to permanently remove this user?');
                                    }
                                </script>
                            </div>
                            
                        </div>
                        

                    </div>
                
            </div>
                <b>
                    <a href="homePage.aspx"><< Go to Home</a>
                </b>
                <br /><br />
            
        </div>
            <div class="col-md-7">
                <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Member List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [member_master_tb1]"></asp:SqlDataSource>
                        <div class="col">
                            <center>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email ID" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </div>

                    </div>
                </div>
            </div>
                </div>
        </div>
            
    </div>
</asp:Content>
