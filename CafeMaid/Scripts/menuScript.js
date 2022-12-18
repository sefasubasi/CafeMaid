function UrunListAll() {  
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //headers: {
                //    "__RequestVerificationToken": getTextValue("tokenInput")
                //},
                url: ("Menu.aspx/GetUrunListAll"),
                data: JSON.stringify({ str: "AJAX TEST => " }),
                dataType: "json",
                success: function (data) {


                    console.log(data);

                    //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                    document.getElementById("Menu-Content").innerHTML = "";

                    document.getElementById("Menu-Content").insertAdjacentHTML("afterbegin", generateItem(data))



                },
                error: function (req, status, error) {
                    console.log(error)
                }
            });


}




function UrunList(id) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetUrunList"),
        data: JSON.stringify({ kategoriId: id }),
        dataType: "json",
        success: function (data) {

      
            console.log(data);
          
            //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
            document.getElementById("Menu-Content").innerHTML = "";

            document.getElementById("Menu-Content").insertAdjacentHTML("afterbegin", generateItem(data))



        },
        error: function (req, status, error) {
            console.log(error)
        }
    });
}


function generateItem(data) {
    var text = "";
    text += "<div id='row' class='row' >"
    for (var i in data.d) {
        var item = data.d[i];
        var syc = 0;


  
        var adet = 1;

        text += "<div class='flip-card' style='margin-right: 5px; margin-left: 5px;'>" +
            "<div class='flip-card-inner'>" +
            "<div class='flip-card-front'>" +
            "<img src='" + item.UrunImage + "'  style='width:300px;height:300px;'>" +
            "</div>" +
            "<div class='flip-card-back'>" +
            "<h1>" + item.UrunAdi + "</h1>" +
            "<p>" + item.UrunAciklama + "</p>" +
            "<input  type='text' value='1' hint='Adet Giriniz.' id='adet" + item.Id + "'></input>" +
            "</br>" +
            "<button class='btn btn-warning' onClick='SepeteEkle(" + item.Id + ")'>Satın Al</button>" +
                "</div>" +
                "</div>" +
                "</div>";
          //  document.getElementById("row" + syc / 5).insertAdjacentHTML("afterbegin", text1);
        syc++;

    }
   
    text += "</div>";

    return text;
    //return "<p id='str" + id + "' onclick='itemOnclick(" + id + ")'>" + isim + "</p>";

}



function UrunArama() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetArananUrun"),
        data: JSON.stringify({ aranan: document.getElementById("aramaText").value }),
        dataType: "json",
        success: function (data) {


            console.log(data);

            //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
            document.getElementById("Menu-Content").innerHTML = "";

            document.getElementById("Menu-Content").insertAdjacentHTML("afterbegin", generateItem(data))


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });

}

function UpdateSepetAdet(id,data) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/UpdateSepetAdet"),
        data: JSON.stringify({urunId:id, adet: data }),
        dataType: "json",
        success: function (data) {


            console.log(data);

            SepeteListesi();
            SepetOdemeListesi();


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });

}

function SepeteEkle(id) {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/SepeteUrunEkle"),
        data: JSON.stringify({ id: id, adet: document.getElementById("adet" + id).value }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            if (data.d) {
                SepeteListesi();

               // alert("Siparisiniz Alındı.");


            }
           


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });



}


function SepeteListesi() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetSepetListesi"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {

            console.log(data);


            document.getElementById("sepetListMenu").innerHTML = "<li class='divider'></li>" +
                "<li><a class='text-center' href='Odeme.aspx'>Ödeme Yap</a></li>";




            for (var i in data.d) {
                var item = data.d[i];
                

                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("sepetListMenu").insertAdjacentHTML("afterbegin", generateSepetItem(item))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });



}

function SepetOdemeListesi() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetSepetListesi"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {

            console.log(data);
            $('#TotalTutar').val(0);
            $('#TotalTutar1').val(0);
            document.getElementById("OdemeSepetListe").innerHTML = "<div class='d-flex flex-row align-items-center'><i class='fa fa-long-arrow-left'></i><a href='Menu.aspx'>Geri</a></div>" +
                "<hr>";

       

            for (var i in data.d) {
                var item = data.d[i];
            

                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("OdemeSepetListe").insertAdjacentHTML("beforeend", generateOdemeSepetItem(item))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });



}
function generateOdemeSepetItem(data) {
    var tt = parseInt($("#TotalTutar").val());
    $('#TotalTutar').val(tt + (data.UrunFiyat * data.UrunAdet));
    $('#TotalTutar1').val(tt + (data.UrunFiyat * data.UrunAdet));

    var text =
        "<div class='d-flex justify-content-between align-items-center mt-3 p-2 items rounded'>" +
        "<div class='d-flex flex-row'><img class='rounded' src='" + data.UrunImage + "' width='40'>" +
        "<div class='ml-2'><span class='font-weight-bold d-block'>" + data.UrunAdi + "</span><span class='spec'>" + data.UrunAciklama + "</span></div>" +
        "</div>" +
        "<div class='d-flex flex-row align-items-center'><span class='d-block'>" + data.UrunAdet + "</span><span class='d-block ml-5 font-weight-bold'>₺" + data.UrunFiyat * data.UrunAdet + "</span></div>" +
        "<span class='item-right'>" +

        "<div class='input-group'>" +

        "<button OnClick='btnDecClick(" + data.Id + ")' type='button' class='quantity-left-minus btn btn-danger btn-number' data-type='minus' data-field=''>-</button>" +
        "<input type='text' id='quantity" + data.Id + "' name='quantity" + data.Id + "' class='form-control input-number' value='" + data.UrunAdet + "' min='1' max='100' style='width: 40px; text-align: center; font-size: 10px; margin-left: 2px; margin-right: 2px;'>" +
        "<button OnClick='btnIncClick(" + data.Id + ")' type='button' class='quantity-right-plus btn btn-success btn-number' data-type='plus' data-field=''>+</button>" +
        "</div>" +

        "</span>" +
        "</div>";
    
    return text;

}
function generateSepetItem(data) {
    var text = "<li>" +
        "<span class='item'>" +
        "<span class='item-left'>" +
        "<img style='height: 30px; weight: 30px;' src='"+data.UrunImage+"' alt='' />" +
            "<span class='item-info'>" +
            "<span>"+data.UrunAdi+"</span>" +
        "<span>"+data.UrunFiyat+" ₺</span>" +
        "</span>" +
        "</span>" +
        "<span class='item-right'>" +

        "<div class='input-group'>" +

        "<button OnClick='btnDecClick(" + data.Id + ")' type='button' class='quantity-left-minus btn btn-danger btn-number' data-type='minus' data-field=''>-</button>" +
        "<input type='text' id='quantity" + data.Id + "' name='quantity" + data.Id + "' class='form-control input-number' value='" + data.UrunAdet + "' min='1' max='100' style='width: 40px; text-align: center; font-size: 10px; margin-left: 2px; margin-right: 2px;'>" +
        "<button OnClick='btnIncClick(" + data.Id + ")' type='button' class='quantity-right-plus btn btn-success btn-number' data-type='plus' data-field=''>+</button>" +
        "</div>" +

        "</span>" +



        "</li>";
    return text;

}


function btnIncClick(Id) {

    var quantity = parseInt($("#quantity"+Id).val());

    // If is not undefined
    quantity = quantity + 1;
    $('#quantity' + Id).val(quantity);

    UpdateSepetAdet(Id, quantity);


}
function btnDecClick(Id) {

    var quantity = parseInt($("#quantity" + Id).val());

    // If is not undefined
    quantity = quantity - 1;
    if (quantity>0) {
        $('#quantity' + Id).val(quantity);

    }

    UpdateSepetAdet(Id, quantity);

}



function OdemeYap() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Odeme.aspx/OdemeYap"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {

            console.log(data);
            $('#TotalTutar').val(0);
            $('#TotalTutar1').val(0);
            document.getElementById("OdemeSepetListe").innerHTML = "<div class='d-flex flex-row align-items-center'><i class='fa fa-long-arrow-left'></i><a href='Menu.aspx'>Geri</a></div>" +
                "<hr>";



            if (data.d) {                
                window.location = "Menu.aspx";
            }

             


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });



}



function KategoriList() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetKategoriList"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {

            
            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];

               
                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("down_menu_item").insertAdjacentHTML("afterbegin", generateKategoriItem(item.Id, item.Value))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });
}


function generateKategoriItem(id, isim) {

   /* var temp = "<li class='nav-item active'> <a class='nav-link' href='#index'>" + id + " </a>";
    temp += "<div class='dropdown-content'>";

    for (var i in isim) {
        temp += " <a href='#'>" + isim[i] + "</a>";


    }

    temp += " </div>";



    return temp;*/
   
    // return "<p id='kategoriId"+id+"' onclick='itemOnclick(" + id + ")'>" + isim + "</p>";
    return "<a class='dropdown-item' onClick='itemOnclick(" + id + ")'>" + isim + "</a>";

}
function itemOnclick(id) {
    //location.replace("/Menu.aspx");

    UrunList(id);
}
function itemSil(id) {
    document.getElementById("str" + id).remove()
}

