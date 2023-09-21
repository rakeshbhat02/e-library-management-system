<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="aboutUs.aspx.cs" Inherits="Library_Managment_System.aboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>About Us</h1>
    </center>
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
        <!-- Add more indicators if needed -->
    </ol>

    <!-- Slides -->
    <div class="carousel-inner">
        <div class="carousel-item active">
            <img src="imgs/carousel.jpg" alt="Image 1" class="centered-and-enlarged-image">
        </div>
        <div class="carousel-item">
            <img src="imgs/racks.jpg" alt="Image 2" class="centered-and-enlarged-image">
        </div>
        <div class="carousel-item">
            <img src="imgs/cubicle.jpg" alt="Image 3" class="centered-and-enlarged-image">
        </div>
        <!-- Add more slides with images -->
    </div>

    <!-- Left and right controls -->
    <a class="carousel-control-prev" href="#myCarousel" data-slide="prev">
        <span class="carousel-control-prev-icon"></span>
    </a>
    <a class="carousel-control-next" href="#myCarousel" data-slide="next">
        <span class="carousel-control-next-icon"></span>
    </a>
</div>
<br /><br />
    <center>
        <b>
            Welcome to our E-library management system. We are dedicated to providing you with the best library services...
        </b><br /><br />
        <h6>
            The Faculty is housed in a purpose-built room in MBA block, which is open Monday to Saturday from 8.30 am – 5.00 pm. 
            The Enquiries Office is usually open from 8.30 am – 5.00 pm Monday to Friday and until 1.00 pm on Saturdays.
            There are two sections - Reading section and Reference section. The reading section is mainly used by our students to study books during exams
            and the reference section contains a number of racks of books related to different engineering branches. We also purchase a variety of newspapers
            for students and faculties to read.
        </h6><br /><br /><br /><br />
    </center>
     <style>
         .centered-and-enlarged-image {
             display: block;
             margin: 0 auto;
             max-width: 100%; /* Make the image responsive */
             width: 500px; /* Set a fixed width for uniform size */
             height: auto;
         }
    </style>
</asp:Content>
