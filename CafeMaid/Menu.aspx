<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CafeMaid.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<html>
<body class="sub_page">
    <script src="Scripts/menuScript.js"></script>

   

  <!-- about section -->

  <section class="about_section layout_padding">
    <div class="container  ">

      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="images/about-img.png" alt="">
          </div>
        </div>
        <div class="col-md-6">
          <div class="detail-box">
            <div id="contentFiled" class="heading_container">
              <h2>
                We Are Feane
              </h2>
                 <p onclick="KategoriList()">kategoriGetir</p>
                 <p onclick="UrunList()">urunler</p>

            </div>
            <p>
             Yeni metin güncellemesi denemesidir.
            </p>
            <a href="">
              Read More
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end about section -->




</body>

</html>
</asp:Content>
