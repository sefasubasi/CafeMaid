<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CafeMaid.Menu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



<html>
    <head>
        <meta name="viewport" content="width=device-width, initial-scale=1">
<style>
body {
  font-family: Arial, Helvetica, sans-serif;
}

.flip-card {
  background-color: transparent;
  width: 300px;
  height: 300px;
  perspective: 1000px;
}

.flip-card-inner {
  position: relative;
  width: 100%;
  height: 100%;
  text-align: center;
  transition: transform 0.6s;
  transform-style: preserve-3d;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
}

.flip-card:hover .flip-card-inner {
  transform: rotateY(180deg);
}

.flip-card-front, .flip-card-back {
  position: absolute;
  width: 100%;
  height: 100%;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
}

.flip-card-front {
  background-color: #bbb;
  color: black;
}

.flip-card-back {
  background-color: #2980b9;
  color: white;
  transform: rotateY(180deg);
}
</style>
</head>

<body class="sub_page">
    <script src="Scripts/menuScript.js"></script>
        

  <section class="about_section layout_padding">
        <div class="row" >
           
         <div class="flip-card" style="margin-right:5px; margin-left:5px;">
          <div class="flip-card-inner">
            <div class="flip-card-front">
              <img src="https://www.tarifdefteri.org/wp-content/uploads/2022/06/Ipek-Gibi-Kremasiyla-Enfes-Pratik-Tatli-Tarifi.jpg.webp" alt="Avatar" style="width:300px;height:300px;">
            </div>
            <div class="flip-card-back">
              <h1>John Doe</h1> 
              <p>Architect & Engineer</p> 
                <button  class="btn btn-warning">Satın Al</button>
            </div>
          </div>
        </div>
            
         <div class="flip-card" style="margin-right:5px; margin-left:5px;">
          <div class="flip-card-inner">
            <div class="flip-card-front">
              <img src="https://www.tarifdefteri.org/wp-content/uploads/2022/06/Ipek-Gibi-Kremasiyla-Enfes-Pratik-Tatli-Tarifi.jpg.webp" alt="Avatar" style="width:300px;height:300px;">
            </div>
            <div class="flip-card-back">
              <h1>John Doe</h1> 
              <p>Architect & Engineer</p> 
                <button  class="btn btn-warning">Satın Al</button>
            </div>
          </div>
        </div>

            <div class="flip-card" style="margin-right:5px; margin-left:5px;">
          <div class="flip-card-inner">
            <div class="flip-card-front">
              <img src="https://www.tarifdefteri.org/wp-content/uploads/2022/06/Ipek-Gibi-Kremasiyla-Enfes-Pratik-Tatli-Tarifi.jpg.webp" alt="Avatar" style="width:300px;height:300px;">
            </div>
            <div class="flip-card-back">
              <h1>John Doe</h1> 
              <p>Architect & Engineer</p> 
                <button  class="btn btn-warning">Satın Al</button>
            </div>
          </div>
        </div>
            
         <div class="flip-card" style="margin-right:5px; margin-left:5px;">
          <div class="flip-card-inner">
            <div class="flip-card-front">
              <img src="https://www.tarifdefteri.org/wp-content/uploads/2022/06/Ipek-Gibi-Kremasiyla-Enfes-Pratik-Tatli-Tarifi.jpg.webp" alt="Avatar" style="width:300px;height:300px;">
            </div>
            <div class="flip-card-back">
              <h1>Mangolia</h1> 
              <p>Çilekli lezzet bombası.</p> 
                <h2>30TL</h2> 
                <button  class="btn btn-warning">Satın Al</button>
            </div>
          </div>
        </div>
        </div>

        </div>
   </section>
  




</body>

</html>
</asp:Content>
