<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="CafeMaid.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">


<html>
<head>
<style>
.btn {
  padding: 5px;
  background-color: warning;
  transition: transform .2s; 
  width: 110px;
  height: 40px;
  margin: 0 auto;
}
.btn:hover {
  transform: scale(1.2);
}
#giris {
  border: none;
  padding: 16px 70px;
  text-align: center;
  font-size: 16px;
  transition: 0.3s;
  border-radius:25px;
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
        <div  id="giris" class="block text main-agileits" style="margin:auto 0 auto auto;"  >
          <div class="detail-box">
            <div class="heading_container">
                <h2 style="margin-bottom:5px; text-align:center;" >
                   Kullanıcı Giriş
                </h2>
                <div class="form-group" style ="height: 150px; margin: 5px;">
                     <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox1" runat="server" placeholder="E-Mail"></asp:TextBox>
                     <asp:TextBox style="margin-bottom:10px;" class="form-control" ID="TextBox2" runat="server" placeholder="Şifre"></asp:TextBox>
                     <asp:Button style=" color:white; margin-bottom:5px;" class="btn btn-warning" ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
                     <asp:Button style=" color:white; margin-bottom:5px;" class="btn btn-warning" ID="Button2" runat="server" OnClick="Button2_Click" Text="Kaydol" />
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