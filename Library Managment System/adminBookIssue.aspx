<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookIssue.aspx.cs" Inherits="Library_Managment_System.adminBookIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Book Issuing</h3>
                                
                            </center>
                        </div>

                    </div>
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
                                <hr />
                            </center>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Member ID</label>
<div class="form-group">
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvTextBox1"
        runat="server"
        ControlToValidate="TextBox1"
        InitialValue=""
        ErrorMessage="Member ID is required."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
        ValidationGroup="ValidationGroup1" 
    />
</div>

                        </div>
                        <div class="col-md-6">
                           <label>Book ID</label>
<div class="form-group">
    <div class="input-group">
        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Book ID"></asp:TextBox>
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" CausesValidation="true" ValidationGroup="ValidationGroup1" />
    </div>
     <asp:RequiredFieldValidator
            ID="rfvBookID"
            runat="server"
            ControlToValidate="TextBox2"
            InitialValue=""
            ErrorMessage="Book ID is required."
            ForeColor="Red"
            Display="Dynamic"
            EnableClientScript="true"
            ValidationGroup="ValidationGroup1" 
        />
</div>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>Member Name</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                 <asp:RequiredFieldValidator
        ID="RequiredFieldValidator1"
        runat="server"
        ControlToValidate="TextBox3"
        InitialValue=""
        ErrorMessage="Click Go."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label>Book Name</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                     <asp:RequiredFieldValidator
        ID="RequiredFieldValidator2"
        runat="server"
        ControlToValidate="TextBox4"
        InitialValue=""
        ErrorMessage="Click Go."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                      <div class="col-md-6">
    <label>Issue Date</label>
    <div class="form-group">
        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorForTextBox5" runat="server" ControlToValidate="TextBox5"
            InitialValue="" ErrorMessage="Click Go." ForeColor="Red" Display="Dynamic" />
    </div>
</div>

                        <div class="col-md-6">
                            <label>Due Date</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator
        ID="rfvDueDate"
        runat="server"
        ControlToValidate="TextBox6"
        InitialValue=""
        ErrorMessage="Due Date is required."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
                                
                                

                            </div>
                        </div>

                    </div>
                    
                    
                    
                    <div class="row">
                        <div class="col-6">
                            
                            <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Issue" OnClick="Button2_Click" />
                             
                             
                                
                            
                            </div>
                        <div class="col-6">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-primary" runat="server" Text="Return" OnClick="Button3_Click" />
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
                                <h3>Issued Book List</h3>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
<asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                                         
                                        <asp:TemplateField HeaderText="fine" SortExpression="fine">
            <ItemTemplate>
                <%# CalculateFine(Eval("due_date")) %>
            </ItemTemplate>
        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </div>

                    </div>
                </div>
            </div>
                </div>
        </div>
          <br /><br />  <br /><br />
    </div>
</asp:Content>
