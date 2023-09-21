using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Managment_System
{
    public partial class adminBookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath, global_book_name, global_genres, global_edition, global_publisher, global_publish_date, global_description;
        static int global_actual_stock, global_current_stock, global_cost, global_pages;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("adminLogin.aspx");
            }
            if (!IsPostBack) { 
                fillAuthorPublisherValues();
                UpdateStockAndIssuedBooksCount(TextBox1.Text.Trim());

            }
            else
            {
                MessagePanel.Visible = false;
            }
            GridView1.DataBind();
        }
        //Go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getBookById();
        }
        //Add button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
                ShowMessage("Book ID Already Exists");

            else
                addNewBook();
        }
        //Update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        //Delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                deleteBookByID();
            }
            else
            {
                ShowMessage("Book ID does not exist");
            }
            
        }

        //user defined functions
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                DropDownList3.Items.Clear();

                ListItem authorDefaultItem = new ListItem("--Select an Author--", "");
                DropDownList3.Items.Add(authorDefaultItem);
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tb1;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                DropDownList2.Items.Clear();

                ListItem publisherDefaultItem = new ListItem("--Select a Publisher--", "");
                DropDownList2.Items.Add(publisherDefaultItem);

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tb1;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addNewBook()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) ||
            string.IsNullOrWhiteSpace(TextBox2.Text) ||
            string.IsNullOrWhiteSpace(TextBox3.Text) ||
            DropDownList1.SelectedIndex == 0 ||
            DropDownList2.SelectedIndex == 0 ||
            DropDownList3.SelectedIndex == 0 ||
            ListBox1.GetSelectedIndices().Length == 0 ||
            string.IsNullOrWhiteSpace(TextBox5.Text) ||
            string.IsNullOrWhiteSpace(TextBox6.Text) ||
            
           
            string.IsNullOrWhiteSpace(TextBox4.Text))
                {
                    ShowMessage("Please fill in all required fields.");
                }
                else
                {
                    string genres = string.Join(",", ListBox1.GetSelectedIndices().Select(i => ListBox1.Items[i].Value));

                    string filepath = "~/bookInventory/books.png"; // Default image path

                    if (FileUpload1.HasFile)
                    {
                        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        FileUpload1.SaveAs(Server.MapPath("bookInventory/" + filename));
                        filepath = "~/bookInventory/" + filename;
                    }

                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1(book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) VALUES(@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link)", con))

                        {
                            // Add your parameters here (similar to what you had before)
                            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@genre", genres);
                            cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                            cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                            cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                            cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                            cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@book_img_link", filepath);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    Response.Write("<script>alert('Book added successfully');</script>");
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getBookById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tb1 where book_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
                    ListBox1.ClearSelection();
                    string[] genres = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for(int i = 0; i < genres.Length; i++)
                    {
                        for(int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genres[i])
                                ListBox1.Items[j].Selected = true;                       
                        }
                    }
                    TextBox5.Text = dt.Rows[0]["edition"].ToString();
                    TextBox6.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox8.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();

                    global_book_name = dt.Rows[0]["book_name"].ToString();
                    global_genres = string.Join(",", genres);
                    global_publisher = dt.Rows[0]["publisher_name"].ToString();
                    global_publish_date = dt.Rows[0]["publish_date"].ToString();
                    global_edition = dt.Rows[0]["edition"].ToString();
                    global_cost = Convert.ToInt32(dt.Rows[0]["book_cost"].ToString().Trim());
                    global_pages = Convert.ToInt32(dt.Rows[0]["no_of_pages"].ToString());
                    global_description = dt.Rows[0]["book_description"].ToString();        
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    int global_issued_books = Convert.ToInt32(global_actual_stock) - Convert.ToInt32(global_current_stock);


                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    ShowMessage("Invalid Book ID");
                    clearForm();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void updateBookByID()
        {
            if (checkIfBookExists())
            {
                bool changesMade = false;
                int global_issued_books = 0;
                try
                {
                    using (SqlConnection cons = new SqlConnection(strcon))
                    {
                        if (cons.State == ConnectionState.Closed)
                            cons.Open();

                        SqlCommand issuedBooksCmd = new SqlCommand("SELECT COUNT(*) AS issued_books_count FROM book_issue_tb1 WHERE book_id = @book_id", cons);
                        issuedBooksCmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                        SqlDataReader reader = issuedBooksCmd.ExecuteReader();

                        if (reader.Read())
                        {
                            global_issued_books = Convert.ToInt32(reader["issued_books_count"]);
                        }

                        reader.Close();
                    }
                    string newBookName = TextBox2.Text.Trim();
                    string newGenres = string.Join(",", ListBox1.GetSelectedIndices().Select(i => ListBox1.Items[i].Value));
                    string newAuthor = DropDownList3.SelectedItem.Value;
                    string newPublisher = DropDownList2.SelectedItem.Value;
                    string newPublishDate = TextBox3.Text.Trim();
                    string newLanguage = DropDownList1.SelectedItem.Value;
                    string newEdition = TextBox5.Text.Trim();
                    int newCost = Convert.ToInt32(TextBox6.Text.Trim());
                    int newPages = Convert.ToInt32(TextBox9.Text.Trim());
                    string newDescription = TextBox10.Text.Trim();
                    int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox7.Text.Trim());
                    string newFilepath = "~/book_inventory/books1";
                    string newFilename = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (newBookName != global_book_name ||
                newGenres != global_genres ||
                newPublisher != global_publisher ||
                newPublishDate != global_publish_date ||
                newEdition != global_edition ||
                newCost != global_cost ||
                newPages != global_pages ||
                newDescription != global_description ||
                actual_stock != global_actual_stock ||
                current_stock != global_current_stock)
                    {
                        changesMade = true; // Set the flag if changes were detected
                    }

                    // Check if any field has changed
                    if (newBookName == global_book_name &&
                        newGenres == global_genres &&
                        newPublisher == global_publisher &&
                        newPublishDate == global_publish_date &&
                        newEdition == global_edition &&
                        newCost == global_cost &&
                    newPages == global_pages &&
                    newDescription == global_description &&
                    actual_stock == global_actual_stock &&
                    current_stock == global_current_stock &&
                    (newFilename == null || newFilename == ""))
                    {
                        ShowMessage("No changes were made to the book details.");
                        return;
                    }

                   

                    if (global_actual_stock == actual_stock)
                    {
                        
                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Issued books cannot be more than actual stock of books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox7.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    
                    
                    if (newFilename == "" || newFilename == null)
                    {
                        newFilepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + newFilename));
                        newFilepath = "~/book_inventory/" + newFilename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tb1 SET book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id = '" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString()) ;
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", newFilepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    if (changesMade)
                    {
                        Response.Write("<script>alert('Book Updated Successfully');</script>");
                    }
                    

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                ShowMessage("Book ID does not exist");
            }

        }
        void deleteBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tb1 WHERE book_id = '" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           

        }
        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tb1 where book_id = '" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            ListBox1.ClearSelection();
            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            DropDownList3.ClearSelection();
        }

      
        void ShowMessage(string message)
        {
            MessageLabel.Text = message;
            MessagePanel.Visible = true;
        }
        protected void CloseButton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
        }
        protected void UpdateStockAndIssuedBooksCount(string bookId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                // Get the actual stock count
                SqlCommand actualStockCmd = new SqlCommand("SELECT actual_stock FROM book_master_tb1 WHERE book_id = @book_id", con);
                actualStockCmd.Parameters.AddWithValue("@book_id", bookId);
                int actualStock = Convert.ToInt32(actualStockCmd.ExecuteScalar());

                // Get the issued books count
                SqlCommand issuedBooksCmd = new SqlCommand("SELECT COUNT(*) AS issued_books_count FROM book_issue_tb1 WHERE book_id = @book_id", con);
                issuedBooksCmd.Parameters.AddWithValue("@book_id", bookId);
                int issuedBooksCount = Convert.ToInt32(issuedBooksCmd.ExecuteScalar());

                // Calculate current stock as actual_stock - issued_books_count
                int currentStock = actualStock - issuedBooksCount;

                // Update the TextBoxes with the values
                TextBox7.Text = currentStock.ToString();
                TextBox8.Text = issuedBooksCount.ToString();
            }
        }




    }
}