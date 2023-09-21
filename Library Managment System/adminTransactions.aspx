<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminTransactions.aspx.cs" Inherits="Library_Managment_System.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col">
                <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h3>Issue/Return List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [transactions]"></asp:SqlDataSource>
                        <div class="col">
                            <center>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="transaction_id">
                                    <Columns>
                                        <asp:BoundField DataField="transaction_id" HeaderText="transaction_id" SortExpression="transaction_id" InsertVisible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="transaction_type" HeaderText="transaction_type" SortExpression="transaction_type" />
                                        <asp:BoundField DataField="transaction_date" HeaderText="transaction_date" SortExpression="transaction_date" />
 
            
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </div>

                    </div>
                </div>
            </div>
                </div>
            </div></div>
    
</asp:Content>
