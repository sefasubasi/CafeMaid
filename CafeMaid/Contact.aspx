<%@ Page Title="Contact" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CafeMaid.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">


<body class="sub_page">
     <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>
     <script src="https://kit.fontawesome.com/9d1d9a82d2.js" crossorigin="anonymous"></script>

<script>


    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Contact.aspx/kategoriRapor"),
        data: JSON.stringify(),
        dataType: "json",
        success: function (data) {
            var value = [];
            var adet = [];

            console.log(data);


            for (var i in data.d) {
                var item = data.d[i];

                value.push(item.Value);
                adet.push(item.Adet);

            }




    $(document).ready(function () {
        var ctx = $("#chart-line");
        var myLineChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: value,
                datasets: [{
                    data: adet,
                    backgroundColor: ["rgba(255, 0, 0, 0.5)", "rgba(100, 255, 0, 0.5)", "rgba(200, 50, 255, 0.5)", "rgba(0, 100, 255, 0.5)"]
                }]
            },
        });
    });





            },
    error: function (req, status, error) {
        console.log(error)
    }
    });

</script>
        
<script>

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Contact.aspx/urunRapor"),
        data: JSON.stringify(),
        dataType: "json",
        success: function (data) {
            var urunAd =[];
            var urunAdet=[];

            console.log(data);


            for (var i in data.d) {
                var item = data.d[i];

                urunAd.push(item.UrunAdi);
                urunAdet.push(item.UrunAdet);

            }




            $(document).ready(function () {
                var ctxB = document.getElementById("barChart").getContext('2d');

                var myBarChart = new Chart(ctxB, {
                    type: 'bar',
                    data: {
                        labels: urunAd,
                        datasets: [{
                            label: null,
                            data: urunAdet,
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        }
                    }
                })

            });











        },
        error: function (req, status, error) {
            console.log(error)
        }
    });
</script>

    <script>





    </script>



    <script src="Scripts/menuScript.js"></script>
    <script>
        KategoriListSelection();
    </script>
  <section class="about_section layout_padding">

       <div class="tab-content" id="pills-tabContent" style="margin-left:50px; margin-right:50px; height:1250px;">
                <div class="tab-pane fade show active" id="pills-panel" role="tabpanel" aria-labelledby="pills-home-tab">
                   <div class="form-group" style ="height: 150px;">


                       <div class="row">
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-primary text-white mb-4">
                                    <div class="card-body">Kullanıcı Sayısı</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label runat="server" id="kullanici_sayi"></asp:Label>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-warning text-white mb-4">
                                    <div class="card-body">Ürün Adeti</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label runat="server" id="urun_sayi"></asp:Label>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-success text-white mb-4">
                                    <div class="card-body">Aktif Adisyon</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                        <asp:Label runat="server" id="aktif_adisyon_label"></asp:Label>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3 col-md-6">
                                <div class="card bg-danger text-white mb-4">
                                    <div class="card-body">Gün Tamamlanan Sipariş Sayısı</div>
                                    <div class="card-footer d-flex align-items-center justify-content-between">
                                       <asp:Label runat="server" id="tamamlanan_gunluk_adisyon"></asp:Label>
                                        <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                                    </div>
                                </div>
                            </div>
                        </div>


                       <div class="row">
                            <div class="col-xl-6">
                                <div class="card mb-4" style="padding-top:10px; padding-bottom:10px;">
                                    <div class="card-header" style="color:black; font-weight: bold;">
                                         En Çok Tercih Edilin Ürünler
                                    </div> 

                                   <div class="card-body">
                                       <canvas id="barChart"></canvas>
                                   </div>


                                </div>
                             </div>


                            <div class="col-xl-6">
                                <div class="card mb-4" style="padding-top:10px; padding-bottom:10px;">
                                    <div class="card-header" style="color:black; font-weight: bold;">
                                         En Çok Tercih Edilin Kategoriler
                                    </div> 
                                    <div class="card-body">
                                    <canvas id="chart-line" width="100" height="50" class="chartjs-render-monitor"></canvas>
                                  </div>
                                </div>
                             </div>


                             </div>
                            </div>
                        </div>


                   

                <div class="tab-pane fade" id="pills-veri" role="tabpanel" aria-labelledby="pills-profile-tab">
                   <div class="form-group" style ="height: 150px;">

                     <div class="row" style="position:center;">
                       <div class="card" style="width:400px;">
                          <h5 class="card-header h7" style="color:black; font-weight: bold;">Ürün ekleme</h5>
                          <div class="card-body">


                              <input style="margin-bottom:5px;" class="form-control" ID="TextBox1" name="TextBox1" placeholder="Ürün Adı"></input><br />
                              <label style="color:black;">Katagori Seçiniz :</label>
                              <select id="kategoriSelection" class="form-select">
                             
                              </select>
                              <br /><br />
                              <input style="margin-bottom:5px;" class="form-control" ID="TextBox2"  name="TextBox2" placeholder="Ürün Açıklama"></input><br />
                              <input style="margin-bottom:5px;" class="form-control" ID="TextBox3"  name="TextBox3" placeholder="Ürün Fiyatı"></input><br />
                              <input style="margin-bottom:5px;" class="form-control" ID="TextBox4"  name="TextBox4" placeholder="Ürün Resim"></input><br />

                              <Button ID="Button3" class="btn btn-warning"  style="color:white; float:right; width:150px;" OnClick="UrunEkle()" >Ekle</Button>
                          </div>
                        </div>

                        

                       <div class="card" style="width:400px; margin-left:100px;">
                          <h5 class="card-header h7" style="color:black; font-weight: bold;">Katagori ekleme</h5>
                          <div class="card-body">


                              <asp:TextBox style="margin-bottom:5px;" class="form-control" ID="TextBox5" runat="server" placeholder="Katagori Adı"></asp:TextBox><br />

                              <asp:Button ID="Button4" class="btn btn-warning"  runat="server" style="color:white; float:right; width:150px;" OnClick="Button4_Click" Text="Ekle" />
                          </div>
                        </div>
                       </div>

                    </div> 

                </div>
            </div>
  
      
        


   </section>
  

</form>
</asp:Content>




