<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="terms.aspx.cs" Inherits="Library_Managment_System.terms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* Style the headings */
        h1 {
            color: #337ab7; /* Blue color for the main heading */
        }

        h2 {
            color: #5bc0de;/* Light blue color for subheadings */
            
            margin: 25px;
        }

        /* Style the list items */
        ul {
            list-style-type: disc; /* Use bullets for list items */
            color: #333; /* Dark gray text color for list items */
            margin-left: 20px; /* Indent the list items */
        }

        /* Style links within the content */
        a {
            color: #d9534f; /* Red color for links */
            text-decoration: underline; /* Add underlines to links */
        }
    </style>

   <center>
       <h1>Terms and Conditions</h1>
   </center> 

    <h2>Membership:</h2><br />
    <ul>
        <li>Users must have a valid library card or membership to borrow materials.</li>
        <li>Users must provide accurate and up-to-date contact information when applying for membership.</li>
        <li>Membership may be subject to age restrictions or residency requirements.</li>
        <li>Students can borrow any number of books but cannot possess more than 5 books at a time (borrowing limit).</li>
        <li>7 days is the borrowing period.</li>
        <li>A fine of <span style="color: #d9534f;">5 rupees per day</span> will be charged after the due date.</li>
        <li>Members may be deactivated if they do not return a book after the due date.</li>
        <li>Membership will be permanently deleted if a book is not returned even a week after the due date.</li>
        <li>Borrowers are responsible for the safekeeping of borrowed materials.</li>
        <li>Libraries may charge for lost or damaged items, and replacement costs may apply.</li>
    </ul><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>


