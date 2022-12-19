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


    <script>


     
    </script>

<div class="container rounded bg-white mt-5" style="margin-bottom:50px; padding-bottom:300px;">
    <div class="row">
            <div class="col-md-4 border-right">
                <div class="d-flex flex-column align-items-center text-center p-3 py-5"><img class="rounded-circle mt-5" src="https://www.freepnglogos.com/uploads/coffee-logo-png/coffee-logo-logo-elements-logo-objects-3.png" width="90"><span class="font-weight-bold">John Doe</span><span class="text-black-50">john_doe12@bbb.com</span><span>United States</span></div>
            </div>
            <div class="col-md-8">
                <div class="p-3 py-5">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <div class="d-flex flex-row align-items-center back"><i class="fa fa-long-arrow-left mr-1 mb-1"></i>
                            <h6>Menü</h6>
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
                                        <input type="text" class="form-control" placeholder="first name" value="John"></div>
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" value="Doe" placeholder="Doe"></div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" placeholder="Email" value="john_doe12@bbb.com"></div>
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" value="+19685969668" placeholder="Phone number"></div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-md-6">
                                        <input type="text" class="form-control" placeholder="address" value="D-113, right avenue block, CA,USA"></div>
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
                                    <button class="btn btn-primary profile-button" type="button">Save Profile</button></div>
                            </div>
                        </div>
                   

                            
                   <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                   <div class="form-group" style ="height: 150px;" >
                                


                    <div class="container" >
                      <div class="card" style="padding-top:0px;">
                        <button class="proceed"><svg class="sendicon" width="24" height="24" viewBox="0 0 24 24">
                      <path d="M4,11V13H16L10.5,18.5L11.92,19.92L19.84,12L11.92,4.08L10.5,5.5L16,11H4Z"></path>
                    </svg></button>
                       <img src="https://cdn-icons-png.flaticon.com/512/2695/2695971.png" class="logo-card">
                     <label>Card number:</label>
                     <input id="user" type="text" class="input cardnumber"  placeholder="1234 5678 9101 1121">
                     <label>Name:</label>
                     <input class="input name"  placeholder="Edgar Pérez">
                     <label class="toleft">CCV:</label>
                     <input class="input toleft ccv" placeholder="321">



                      </div> <br />



                        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                          <div class="carousel-inner">
                            <div class="carousel-item active">
                              


                                <div class="card" style="padding-top:0px;">
                                 <img src="https://cdn-icons-png.flaticon.com/512/2695/2695971.png" class="logo-card">
                                 <label>Card number:</label>
                                 <input id="user" type="text" class="input cardnumber"  placeholder="1234 5678 9101 1121">
                                 <label>Name:</label>
                                 <input class="input name"  placeholder="Edgar Pérez">
                                 <label class="toleft">CCV:</label>
                                 <input class="input toleft ccv" placeholder="321">
                                  </div>


                            </div>
                            <div class="carousel-item">
                              <div class="card" style="padding-top:0px;">
                         <img src="https://cdn-icons-png.flaticon.com/512/2695/2695971.png" class="logo-card">
                         <label>Card number:</label>
                         <input id="user" type="text" class="input cardnumber"  placeholder="1234 5678 9101 1121">
                         <label>Name:</label>
                         <input class="input name"  placeholder="Edgar Pérez">
                         <label class="toleft">CCV:</label>
                         <input class="input toleft ccv" placeholder="321">
                      </div>
                            </div>
                            <div class="carousel-item">
                               <div class="card" style="padding-top:0px;">
                         <img src="https://cdn-icons-png.flaticon.com/512/2695/2695971.png" class="logo-card">
                         <label>Card number:</label>
                         <input id="user" type="text" class="input cardnumber"  placeholder="1234 5678 9101 1121">
                         <label>Name:</label>
                         <input class="input name"  placeholder="Edgar Pérez">
                         <label class="toleft">CCV:</label>
                         <input class="input toleft ccv" placeholder="321">
                      </div>
                            </div>
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