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
            else {
                alert("Sepete eklemeden önce giriş yapmalısınız! ");
                window.location = "Login.aspx";
            }
           


        },
        error: function (req, status, error) {
            alert("Sepete eklemeden önce giriş yapmalısınız! ");
                window.location = "Login.aspx";
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

        "<div class='d-flex flex-row align-items-center '><div class='row' style=' padding:5px; border-width:3px; border-style:groove;'><span class='d-block'>" + data.UrunAdet + "</span><span class='d-block ml-2 '> X </span><span class='d-block ml-2 font-weight-bold'>" + data.UrunFiyat + "₺</span></div><span class='d-block ml-5 font-weight-bold'>₺" + data.UrunFiyat * data.UrunAdet + "</span></div>" +
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



function OdemeYap(kartId) {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Odeme.aspx/OdemeYap"),
        data: JSON.stringify({ kartId: kartId }),
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
function AddBankKart() {
   
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/AddBankKart"),
        data: JSON.stringify({ kartSahibi: $("#kartSahibi").val(), kartNo: $("#kartNo").val(), kartCvc: $("#kartCvc").val(), kartSKT: $("#kartSKT").val() }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            if ( data.d) {

                alert("Kayıt Başarılı");
            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });

}


function BankKartSil(kartId) {
    alert(kartId + "  silinsinmi ");
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/BankKartSil"),
        data: JSON.stringify({ kartId: kartId }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            if (data.d) {

                alert("Silme Başarılı");
            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });

}


function GetSiparisList() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetSiparisList"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];


                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("siparisList").insertAdjacentHTML("afterbegin", genereteSiparisItem(item))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });

}


function genereteSiparisItem(item) {
    var text = "<p>" + item.SiparisNo + "</p>";
    text += "<hr>";


    return text;
}


function GetActiveKart() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetBankKartList"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];

                if (item.IsActive) {
                    document.getElementById("OdemeButton").setAttribute("onclick", "OdemeYap(" + item.Id + ")");
                    document.getElementById("cName").setAttribute("value", item.KartSahibi);
                    document.getElementById("cNo").setAttribute("value", item.KartNo);
                    document.getElementById("cSKT").setAttribute("value", item.KartSKT);
                    document.getElementById("cCvc").setAttribute("value", item.KartCvc);

                }
             

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });



}


function GetBankKart() {

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetBankKartList"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {


            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];


                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("bankCardList").insertAdjacentHTML("afterbegin", generateBankKartItem(item))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });
  


}

function generateBankKartItem(item) {
    var text = "";
    var checkStatus = "";
    if (item.IsActive) {
        text = "<div class='carousel-item active'>";
        checkStatus = "checked";
    }
    else {
        text = "<div class='carousel-item'>";
    }
    text += "<div class='card' style='padding-top:0px;'>" +
        "<img src='https://cdn-icons-png.flaticon.com/512/2695/2695971.png' class='logo-card'>" +
        "<br />" +
        "<input style=' float:right; width:50px;height:30px;' type='checkbox' class='form-control' checked='" + checkStatus + "' />" +
        "<label style=' float:right; '> İsActive:</label>"+
        "<label>Card number:</label>" +
        "<input type='text' class='input cardnumber' placeholder='1234 5678 9101 1121' value='" + item.KartNo + "'>" +
        "<label>Name:</label>" +
        "<input class='input name' placeholder='Kart üzerindeki İsim' value='"+item.KartSahibi+"'>" +
        "<label class='toleft'>CCV:</label>" +
        "<input class='input toleft ccv' placeholder='321' value='" + item.KartCvc + "'>" +
        "<label class='toleft'>SKT:</label>" +
        "<input class='input toleft ccv' placeholder='321' value='" + item.KartSKT + "'>" +



        " <button onclick='BankKartSil(" + item.Id + ")' style=' float:right; border:hidden; background-color:transparent; width:50px;height:30px;'  class='form-control'>" +
        " <svg version='1.1' id='Layer_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' " +
        " viewBox='0 0 473 473' fill='red' style='enable-background:new 0 0 473 473;' xml:space='preserve'>" +
        " <path d='M324.285,215.015V128h20V38h-98.384V0H132.669v38H34.285v90h20v305h161.523c23.578,24.635,56.766,40,93.477,40" +
        " c71.368,0,129.43-58.062,129.43-129.43C438.715,277.276,388.612,222.474,324.285,215.015z M294.285,215.015" +
        " c-18.052,2.093-34.982,7.911-50,16.669V128h50V215.015z M162.669,30h53.232v8h-53.232V30z M64.285,68h250v30h-250V68z M84.285,128" +
        " h50v275h-50V128z M164.285,403V128h50v127.768c-21.356,23.089-34.429,53.946-34.429,87.802c0,21.411,5.231,41.622,14.475,59.43" +
        " H164.285z M309.285,443c-54.826,0-99.429-44.604-99.429-99.43s44.604-99.429,99.429-99.429s99.43,44.604,99.43,99.429" +
        " S364.111,443,309.285,443z'/>" +
        " <polygon points='342.248,289.395 309.285,322.358 276.323,289.395 255.11,310.608 288.073,343.571 255.11,376.533 276.323,397.746 " +
        " 309.285,364.783 342.248,397.746 363.461,376.533 330.498,343.571 363.461,310.608 	'/>" +
        " </svg>" +
        " </button>" +





        "</div>" +
        "</div>";

 
 
     return text;



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
    sessionStorage["urunId"] = id;



    window.location.pathname != "/Menu.aspx" ? window.location = "Menu.aspx":null;

    UrunList(id);
}
function itemSil(id) {
    document.getElementById("str" + id).remove()
}



