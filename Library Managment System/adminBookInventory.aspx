<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminBookInventory.aspx.cs" Inherits="Library_Managment_System.adminBookInventory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });

       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
        }

    </script>
   

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
  <asp:Panel ID="MessagePanel" runat="server" Visible="false" CssClass="alert-panel" style="position: fixed; top: 20px; left: 50%; transform: translateX(-50%); background-color: #f5f5f5; text-align: center; padding: 10px; border-radius: 5px; box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); z-index: 999;">
    <asp:Label ID="MessageLabel" runat="server" Text="" CssClass="alert-text" ForeColor="#f44336"></asp:Label>
    <asp:Button ID="CloseButton" runat="server" Text="&#10006;" OnClick="CloseButton_Click" CssClass="btn btn-sm btn-light" CausesValidation="false" />
</asp:Panel>



    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                <div class="card-body">
                     <div class="row">
                        <div class="col">
                            <center>
                                <h3>Book Details</h3>
                                
                            </center>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            
                            <center>
                                <img id="imgview" src="bookInventory/books.png" width="100" />
  
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
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                               

                            </center>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
    InitialValue="" ErrorMessage="Please select a file to upload." ForeColor="Red" Display="Dynamic" />
                        </div></div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Book ID</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                                   
                                    <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-primary" Text="Go" OnClick="LinkButton4_Click" CausesValidation="false"></asp:LinkButton>
                                     
                                </div>
                                
                                
                            </div>
                        </div>
                        <div class="col-md-8">
                            <label>Book Name</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Book Name"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
    InitialValue="" ErrorMessage="Book Name is required." ForeColor="Red" Display="Dynamic" />

                                    
                                
                                

                            </div>
                        </div>
                        

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Language</label>
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                    <asp:ListItem Text="--Select Language--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="English" Value="English"/>
                                    <asp:ListItem Text="Kannada" Value="Kannnada"/>
                                    <asp:ListItem Text="Hindi" Value="Hindi"/>
                                    <asp:ListItem Text="Bengali" Value="Bengali"/>
                                    <asp:ListItem Text="Telugu" Value="Telugu"/>
                                    <asp:ListItem Text="Marathi" Value="Marathi"/>
                                    <asp:ListItem Text="Tamil" Value="Tamil"/>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ErrorMessage="Language is required" ControlToValidate="DropDownList1"
    InitialValue="0" runat="server" ForeColor="Red" />
                               
                                
                            </div>
                            <label>Publisher Name</label>
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownList2" class="form-control" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Select a Publisher--" Value=""></asp:ListItem>
                                   
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ErrorMessage="Publisher Name is required" ControlToValidate="DropDownList2"
    InitialValue="" runat="server" ForeColor="Red" />

                                
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Author Name</label>
                            <div class="form-group">
                                
                                <asp:DropDownList ID="DropDownList3" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="--Select an Author--" Value=""></asp:ListItem>
                                </asp:DropDownList> 
                                 <asp:RequiredFieldValidator ErrorMessage="Author Name is required" ControlToValidate="DropDownList3"
    InitialValue="" runat="server" ForeColor="Red" />
                                

                            </div>
                            <label>Publish Date</label>
                            <div class="form-group">
                                
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorForDate" runat="server"
                                    ControlToValidate="TextBox3"
                                    InitialValue=""
                                    ErrorMessage="Publish Date is required"
                                    Display="Dynamic"
                                    ForeColor="Red" />


                            </div>


                        </div>
                         <div class="col-md-4">
                            <label>Genre</label>
                            <div class="form-group">
                                
                                <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                    <asp:ListItem Text="Fiction" Value="Fiction" />
                                    <asp:ListItem Text="Mystery" Value="Mystery" />
                                    <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                    <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                    <asp:ListItem Text="Romance" Value="Romance" />
                                    <asp:ListItem Text="Historical Fiction" Value="Historical Fiction" />
                                    <asp:ListItem Text="Thriller" Value="Thriller" />
                                    <asp:ListItem Text="Horror" Value="Horror" />
                                    <asp:ListItem Text="Non-Fiction" Value="Non-Fiction" />
                                    <asp:ListItem Text="Biography" Value="Biography" />
                                    <asp:ListItem Text="Self Help" Value="Self Help" />
                                    <asp:ListItem Text="Philosophy" Value="Philosophy" />
                                    <asp:ListItem Text="Technical" Value="Technical" />

                                </asp:ListBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorListBox" runat="server"
                                    ControlToValidate="ListBox1"
                                    InitialValue=""
                                    ErrorMessage="Please select at least one genre."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                    
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Edition</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Edition"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="TextBox5"
                                    InitialValue=""
                                    ErrorMessage="Edition is required"
                                    Display="Dynamic"
                                    ForeColor="Red" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Cost (per unit)</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="Cost" TextMode="Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="TextBox6"
                                    InitialValue=""
                                    ErrorMessage="Book Cost is required"
                                    Display="Dynamic"
                                    ForeColor="Red" />
                                
                                

                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>Pages</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Actual Stock</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="TextBox4"
                                    InitialValue=""
                                    ErrorMessage="Actual Stock is required"
                                    Display="Dynamic"
                                    ForeColor="Red" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <label>Current Stock</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>
                         <div class="col-md-4">
                            <label>Issued Books</label>
                            <div class="form-group">
                                
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                    
                                
                                

                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label>Book Description</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Description"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button3_Click" />
                                
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button1_Click" CausesValidation="false"/>
                            </div>
                            
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" CausesValidation="false" />
                                
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
                                <h3>Book Inventory List</h3>
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [book_master_tb1]"></asp:SqlDataSource>
                        <div class="col">
                            
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        <ControlStyle Font-Bold="True" />
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Cost -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />

                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            
                        </div>

                    </div>
                </div>
                    
            </div>
                </div>
            </div>
        </div>
            
            
            
       
</asp:Content>
