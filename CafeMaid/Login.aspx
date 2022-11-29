<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="CafeMaid.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">


<html>
<body>

  

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
            <div class="heading_container">
                <h2>
                We Are Feane
              </h2>
             
                <asp:TextBox  ID="TextBox1" runat="server"></asp:TextBox>
                    
                <asp:TextBox  ID="TextBox2" runat="server"></asp:TextBox>             
            
          
              
            
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
              
            
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


    </form>


   </asp:Content>
