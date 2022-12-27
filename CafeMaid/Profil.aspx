<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profil.aspx.cs" Inherits="CafeMaid.Profil" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <form id="form1" runat="server">
        <style>
             body {
              background: #aaa;
            }
            .form-control:focus {
              box-shadow: none;
              border-color: darkorange;
            }
            .profile-button {
              background: darkorange;
              box-shadow: none;
              border: none;
            }
            .profile-button:hover {
              background: darkorange;
            }
            .profile-button:focus {
              background: darkorange;
              box-shadow: none;
            }
            .profile-button:active {
              background: darkorange;
              box-shadow: none;
            }
            .back:hover {
              color: darkorange;
              cursor: pointer;
            }
               
                .card{
                  background:#16181a;  border-radius:14px; max-width: 300px; display:block; margin:auto;
                  padding:60px; padding-left:20px; padding-right:20px;box-shadow: 2px 10px 40px black; z-index:99;
                }
                .logo-card{max-width:50px; margin-bottom:15px; margin-top: -19px;}
                label{display:flex; font-size:10px; color:white; opacity:.4;}
                input{font-family: 'Work Sans', sans-serif;background:transparent; border:none; border-bottom:1px solid transparent; color:#dbdce0; transition: border-bottom .4s;}
                input:focus{border-bottom:1px solid #1abc9c; outline:none;}
                .cardnumber{display:block; font-size:20px; margin-bottom:8px; }
                .name{display:block; font-size:15px; max-width: 200px; float:left; margin-bottom:15px;}
                .toleft{float:left;}
                .ccv{width:50px; margin-top:-5px; font-size:15px;}
                .receipt{background: #dbdce0; border-radius:4px; padding:5%; padding-top:200px; max-width:600px; display:block; margin:auto; margin-top:-180px; z-index:-999; position:relative;}
                .col{width:50%; float:left;}
                .bought-item{background:#f5f5f5; padding:2px;}
                .bought-items{margin-top:-3px;}
                .cost{color:#3a7bd5;}
                .seller{color: #3a7bd5;}
                .description{font-size: 13px;}
                .price{font-size:12px;}
                .comprobe{text-align:center;}
                .proceed{position:absolute; transform:translate(300px, 10px); width:50px; height:50px; border-radius:50%; background:#1abc9c; border:none;color:white; transition: box-shadow .2s, transform .4s; cursor:pointer;}
                .proceed:active{outline:none; }
                .proceed:focus{outline:none;box-shadow: inset 0px 0px 5px white;}
                .sendicon{filter:invert(100%); padding-top:2px;}
                
                
        </style>


<body class ="sub_page">

    <script src="Scripts/menuScript.js"></script>
   <script>GetBankKart()</script>
   <script>GetSiparisList()</script>

  
    

<div class="container rounded bg-white mt-5" style="margin-bottom:50px; padding-bottom:300px;">
    <div class="row">
            <div class="col-md-4 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5">
                    <img class="rounded-circle mt-5" src="https://www.freepnglogos.com/uploads/coffee-logo-png/coffee-logo-logo-elements-logo-objects-3.png" width="90">
                    <span class="font-weight-bold"> <%= Session["KullaniciAdi"] %> </span>
                    <span class="text-black-50"> <%= Session["EPosta"] %> </span>
                    <span> <%= Session["TelefonNo"] %> </span>
                </div>
            </div>
            <div class="col-md-8">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <div class="d-flex flex-row align-items-center back">
                           <a href="Menu.aspx"><h6>Menü</h6><i class="fa fa-long-arrow-left mr-1 mb-1"></i></a>
                         
                        </div>

              <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                <li class="nav-item text-center">
                  <a class="nav-link active btl" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">

                        
                            <h2 style="margin-bottom:5px; text-align:center; font-size:25px;" >
                                 Kullanici Bilgileri
                            </h2>

                  </a>
                </li>
                <li class="nav-item text-center">
                  <a class="nav-link btr" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">

                      <div class="heading_container">
                            <h2 style="margin-bottom:5px; text-align:center; font-size:25px;" >
                                Kartlarım
                            </h2>
                        </div>
                  </a>
                </li>

                <li class="nav-item text-center">
                  <a class="nav-link btr" id="pills-profile-tab2" data-toggle="pill" href="#pills-profile2" role="tab" aria-controls="pills-profile" aria-selected="false">

                      <div class="heading_container">
                            <h2 style="margin-bottom:5px; text-align:center; font-size:25px;" >
                                Siparişlerim
                            </h2>
                        </div>
                  </a>
                </li>

               
              </ul>
                    <h6 class="text-right">Profil Düzenle</h6>
                    </div>

                    <div class="tab-content" id="pills-tabContent">
                        
      



                        <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                            <div class="form-group" style="height: 150px;">
                                <div class="row mt-2">
                                    <div class="col-md-6">
                                        <input id="kullaniciAdi"  type="text" class="form-control" placeholder="first name"></div>
                                    <script>document.getElementById("kullaniciAdi").setAttribute("value", '<%= Session["KullaniciAdi"] %>');</script>
                                    <div class="col-md-6">
                                        <input id="kullaniciSifre" type="password" class="form-control"  placeholder="Password"></div>
                                    <script>document.getElementById("kullaniciSifre").setAttribute("value", '<%= Session["Sifre"] %>');</script>

                                </div>
                                <div class="row mt-3">
                                    <div class="col-md-6">
                                        <input id="ePosta" type="text" class="form-control" placeholder="Email"></div>
                                    <script>document.getElementById("ePosta").setAttribute("value", '<%= Session["EPosta"] %>');</script>

                                    <div class="col-md-6">
                                        <input id="telefonNo" type="text" class="form-control"  placeholder="Phone number"></div>
                                    <script>document.getElementById("telefonNo").setAttribute("value", '<%= Session["TelefonNo"] %>');</script>

                                </div >
                                <div class="row mt-3">
                                    <div class="col-md-1">
                                        <input id="isAdmin" name="isAdmins" type="checkBox" class="form-control" ></div>
                                     <div class="col-md-5">
                                            <span class="form-control"  for="isAdmins"> Admin Yetkisi</span></div>

                                    <script>document.getElementById("isAdmin").setAttribute("checked", '<%= Session["IsAdmin"] %>');</script>

                                    <div class="col-md-6">
                                        <input type="text" class="form-control" value="USA" placeholder="Country"></div>
                                </div>
                          <div class="row mt-3">
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" placeholder="Bank Name" value="Bank of America"></div>
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" value="043958409584095" placeholder="Account Number"></div>
                                </div>
                                <div class="mt-5 text-right">
                                    <button class="btn btn-primary profile-button" type="button">Değişiklikleri Kaydet</button></div>
                            </div>
                        </div>

                            
                   <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                   <div class="form-group" style ="height: 150px;" >
                                


                    <div class="container" >
                      <div class="card" style="padding-top:0px;">
                        <button onclick="AddBankKart()" class="proceed"><svg class="sendicon" width="24" height="24" viewBox="0 0 24 24">
                      <path d="M4,11V13H16L10.5,18.5L11.92,19.92L19.84,12L11.92,4.08L10.5,5.5L16,11H4Z"></path>
                    </svg></button>
                       <img src="https://cdn-icons-png.flaticon.com/512/2695/2695971.png" class="logo-card">
                    
                          <br />

                          <input id="kartActive" style=" float:right; width:50px;height:30px;" type="checkbox" checked="" class="form-control" />
                          <label style=" float:right; "> İsActive:</label>
             
                     
                          <label>Card number:</label>

                         <input id="kartNo" name="kartNo" type="text" class="input cardnumber"  placeholder="1234 5678 9101 1121">
                     <label>Name:</label>
                     <input id="kartSahibi" name="kartSahibi" class="input name"  placeholder="Edgar Pérez">
                     <label  class="toleft">CCV:</label>
                     <input id="kartCvc" name="kartCvc"  class="input toleft ccv" placeholder="321">
                     <label  class="toleft">SKT:</label>
                     <input id="kartSKT" name="kartSKT"  class="input toleft ccv" placeholder="12/22">
                        
<%--                          <button style=" float:right; border:hidden; background-color:transparent; width:50px;height:30px;"  class="form-control">                               
                              <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
	                             viewBox="0 0 473 473" fill="red" style="enable-background:new 0 0 473 473;" xml:space="preserve">
                        
	                            <path d="M324.285,215.015V128h20V38h-98.384V0H132.669v38H34.285v90h20v305h161.523c23.578,24.635,56.766,40,93.477,40
		                            c71.368,0,129.43-58.062,129.43-129.43C438.715,277.276,388.612,222.474,324.285,215.015z M294.285,215.015
		                            c-18.052,2.093-34.982,7.911-50,16.669V128h50V215.015z M162.669,30h53.232v8h-53.232V30z M64.285,68h250v30h-250V68z M84.285,128
		                            h50v275h-50V128z M164.285,403V128h50v127.768c-21.356,23.089-34.429,53.946-34.429,87.802c0,21.411,5.231,41.622,14.475,59.43
		                            H164.285z M309.285,443c-54.826,0-99.429-44.604-99.429-99.43s44.604-99.429,99.429-99.429s99.43,44.604,99.43,99.429
		                            S364.111,443,309.285,443z"/>
	                            <polygon points="342.248,289.395 309.285,322.358 276.323,289.395 255.11,310.608 288.073,343.571 255.11,376.533 276.323,397.746 
		                            309.285,364.783 342.248,397.746 363.461,376.533 330.498,343.571 363.461,310.608 	"/>
                             
                            </svg>
                          </button>--%>

                      </div> <br />
                        <hr />



                        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                          <div id="bankCardList" class="carousel-inner">
                         


                          </div>




                          <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                          </a>
                          <a class="carousel-control-next"; href="#carouselExampleControls" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                          </a>
                        </div>

        </div>
</div>
</div>




                        <div class="tab-pane fade" id="pills-profile2" role="tabpanel" aria-labelledby="pills-profile-tab">
                   <div class="form-group" style ="height: 150px;">
                                
                       <div id="siparisList">






                       </div>

                    
 
                    



                  </div>
                  </div>  



                </div>



</div>
</div>
</div>
</div>
          
            </body>

     </form>


   </asp:Content>