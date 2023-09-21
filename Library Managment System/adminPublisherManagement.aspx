<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPublisherManagement.aspx.cs" Inherits="Library_Managment_System.adminPublisherManagement" %>

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
    <div class="container">
        <div class="row">
            <div class="col-md-5">
            <div class="card">
                <div class="card-body">
                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Publisher Details</h3>
                                
                            </center>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            
                            <center>
                                <img src="imgs/publisher.png" width="100" />
  
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
                        <div class="col-md-4">
                            <label>Publisher Id</label>
                            <div class="form-group">
    <div class="input-group">
        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
      
        <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click" causesValidation="false"/>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [publisher_master_tb1]"></asp:SqlDataSource>
          <asp:RequiredFieldValidator
            ID="rfvTextBox1"
            runat="server"
            ControlToValidate="TextBox1"
            InitialValue=""
            ErrorMessage="ID is required."
            ForeColor="Red"
            Display="Dynamic"
            EnableClientScript="true"
        />
    </div>
</div>

                        </div>
                        <div class="col-md-8">
                            <label>Publisher Name</label>
                            <div class="form-group">
    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Publisher Name"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvTextBox2"
        runat="server"
        ControlToValidate="TextBox2"
        InitialValue=""
        ErrorMessage="Publisher Name is required."
        ForeColor="Red"
        Display="Dynamic"
        EnableClientScript="true"
    />
</div>

                        </div>

                    </div>
              
                    
                    
                    
                    <div class="row">
                        <div class="col-4">
                            
                            <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                             
                             
                                
                            
                            </div>
                        <div class="col-4">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                        </div>
                        <div class="col-4">
                            <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
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
                                <h3>Publisher List</h3>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </div>

                    </div>
                </div>
            </div>
                </div>
        </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <br />
    </div>
</asp:Content>
