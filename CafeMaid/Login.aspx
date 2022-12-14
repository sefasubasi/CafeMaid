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
  margin: 0px 0px 150px 0px;
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


        <div  id="giris" class="block text main-agileits" style="height:300px;">
       

            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                <li class="nav-item text-center">
                  <a class="nav-link active btl" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">

                        
                            <h2 style="margin-bottom:5px; text-align:center; font-size:25px;" >
                                 Kullanıcı  Giriş
                            </h2>

                  </a>
                </li>
                <li class="nav-item text-center">
                  <a class="nav-link btr" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">

                      <div class="heading_container">
                            <h2 style="margin-bottom:5px; text-align:center; font-size:25px;" >
                                 Kaydol
                            </h2>
                        </div>
                  </a>
                </li>
               
              </ul>
              <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                   <div class="form-group" style ="height: 150px;">
                     <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox1" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
                     <asp:TextBox style="margin-bottom:10px;" class="form-control" ID="TextBox2" runat="server" placeholder="Şifre"></asp:TextBox>
                     <asp:Button ID="Button1" class="btn1 btn-warning"  runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
                    </div>
                </div>
                <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                   <div class="form-group" style ="height: 150px;">
                     <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox3" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
                     <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox4" runat="server" placeholder="Şifre"></asp:TextBox>
                     <asp:TextBox style="margin-bottom:10px;" class="form-control" ID="TextBox5" runat="server" placeholder="Şifre Tekrarı"></asp:TextBox>
                     <asp:Button ID="Button4" class="btn1 btn-warning"  runat="server" OnClick="Button2_Click" Text="Kaydol" />
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