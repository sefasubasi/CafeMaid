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
function SepeteEkle(id) {



   // alert(item.Id);
    alert("ADET: " + document.getElementById("adet" + id).value);

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

            alert(data);

            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];



                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                //document.getElementById("down_menu_item").insertAdjacentHTML("afterbegin", generateKategoriItem(item.Id, item.Value))

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

