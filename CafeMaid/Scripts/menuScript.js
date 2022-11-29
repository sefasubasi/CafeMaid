
function UrunList() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //headers: {
        //    "__RequestVerificationToken": getTextValue("tokenInput")
        //},
        url: ("Menu.aspx/GetUrunList"),
        data: JSON.stringify({ str: "AJAX TEST => " }),
        dataType: "json",
        success: function (data) {

      
            console.log(data);
            for (var i in data.d) {
                var item = data.d[i];

                //document.getElementById("footerDiv").innerHTML += generateItem(item.id,item.adi);
                document.getElementById("kategoriId" + item.KategoriId).insertAdjacentHTML("afterend", generateItem(item.KategoriId, item.UrunAdi))

            }


        },
        error: function (req, status, error) {
            console.log(error)
        }
    });
}

function generateItem(id, isim) {

    return "<p id='str" + id + "' onclick='itemOnclick(" + id + ")'>" + isim + "</p>";


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
                document.getElementById("contentFiled").insertAdjacentHTML("afterbegin", generateKategoriItem(item.Id, item.Value))

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
    return "<p id='kategoriId"+id+"' onclick='itemOnclick(" + id + ")'>" + isim + "</p>";


}
function itemOnclick(id) {
    alert(id)
}
function itemSil(id) {
    document.getElementById("str" + id).remove()
}

