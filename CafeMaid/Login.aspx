<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="CafeMaid.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">


<html>
<head>
<style type="text/css" class="cssStyles">


.btn1{
  padding: 5px;
  background-color: warning;
  transition: transform .2s; 
  width: 110px;
  height: 40px;
  margin: 0 auto;
  color:white; 
  margin-bottom:5px;


   display: inline-block;
  font-weight: 400;
  text-align: center;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;

  border: 1px solid transparent;

  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.25rem;



}

.btn1:hover {
      color: white;
  text-decoration: none;
  transform: scale(1.2);
}
#giris {
  border: none;
  padding: 16px 70px;
  text-align: center;
  font-size: 16px;
  transition: 0.3s;
  border-radius:25px;
  margin: 0px 0px 150px 5px;
}
#giris:hover {
  background-color: #8D8D8D33;
 
}
</style>

         


</head>
<body class ="sub_page">
  
  

  
  <section class="about_section layout_padding">
    <div class="container">

      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="images/about-img.png" alt="">
          </div>
        </div>
        <div  id="giris" class="block text main-agileits">
          <div class="detail-box">
            <div class="heading_container">
                <h2 style="margin-bottom:5px; text-align:center;" >
                   Kullanıcı Giriş
                </h2>
                <div class="form-group" style ="height: 150px;">
                     <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox1" runat="server" placeholder="E-Mail"></asp:TextBox>
                     <asp:TextBox style="margin-bottom:10px;" class="form-control" ID="TextBox2" runat="server" placeholder="Şifre"></asp:TextBox>
                     <asp:Button ID="Button1" class="btn1 btn-warning"  runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
                     <asp:Button ID="Button2" class="btn1 btn-warning"  runat="server" OnClick="Button2_Click" Text="Kaydol" />
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>




</body>

</html>

    </form>


   </asp:Content>