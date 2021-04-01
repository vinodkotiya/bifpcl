<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tester.aspx.vb" Inherits="tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
 @import url(css/google.css);
* {
  margin: 0;
  padding: 0;
  font-family: 'Roboto', sans-serif;
}
html,
body {
  background-color: #999;
  height:500px;
   min-height: 100%;
}
.login {
  margin-left: auto; margin-right: auto;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  border-bottom-left-radius: 3px;
  border-bottom-right-radius: 3px;
  background-color: #fff;
  height: 650px;
  width: 350px;
  margin-top: 20px;
  -webkit-box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
-moz-box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
}
.top {
  background-color: #1976d2;
  height: 100px;
  width: 350px;
  position: absolute;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
}
.title {
  color: #fff;
  position: absolute;
  bottom: 10px;
  left: 30px;
  border-top:2px dashed yellow;
  font-size: 16px;
  font-weight: 300;
  margin-top:5px;
}
.appname {
  color: #fff;
  /*position: absolute;*/
  bottom: 10px;
  left: 30px;
  font-size: 26px;
  font-weight: 300;
  margin-left:10px;
  margin-top:8px;
      text-align: center;
}
.body {
  position: absolute;
  margin-top: 100px;
  /*height: 100%;*/
  width: 350px;
  padding-left: 30px;
  text-align: left;
  padding-top: 10px;
}
.tooltip {
  color: #999;
  font-size: 12px;
}
.error {
  color:#ff0000;
  font-style:italic;
  margin-top: 10px;
  font-size: 12px;
}
.email {
  border-style: solid;
  border-top-width: 0;
  border-left-width: 0;
  border-right-width: 0;
  height: 24px;
  font-size: 18px;
  border-bottom-color: #1976d2;
  width: 290px;
  padding-top: 3px;
  padding-bottom: 3px;
  transition: all 0.2s ease-in-out;
}
.email:hover {
  border-bottom-color: #1976d2;
  transition: all 0.2s ease-in-out;
}
.email:focus {
  border-bottom-color: #1976d2;
  transition: all 0.2s ease-in-out;
  outline: none;
}
.more {
  color: #1976d2;
  text-transform: uppercase;
  font-size: 16px;
  padding-top: 45px;
  display: inline-block;
}
.next {
  background-color: #1976d2;
  width: 70px;
  color: #fff;
  display: inline-block;
  padding-top: 7px;
  padding-bottom: 7px;
  text-transform: uppercase;
  text-align: center;
  margin-left: 100px;
  border-radius: 2px;
}
.logo {
  position: absolute;
  /*bottom: 5px;*/
  text-align: center;
}
.count {
 display:inline-block;
}
.google {
  width: 70px;
  padding-bottom: 10px;
  margin-left: 100px;
}
.stats {
  padding-bottom: 10px;
  margin-left: 10px;
position:relative;
top:100px;
}
a {
  text-decoration: none;
}
.notif {
  width: calc(100% - 60px);
  height: 50px;
  color: #666;
  font-size: 12px;
  margin-top: 20px;
  text-align: center;
}
header {
	position: relative;
	width: 100%;
	height: 80px;
	box-shadow: 0 2px 5px 0 rgba(0,0,0,0.26);
	background: rgb(3, 169, 245);
	font-size: 30px;
	font-weight: 300;
	color: rgb(242, 251, 253);
	text-align: center;
	line-height: 75px;
}
   /* Smartphones (portrait and landscape) ----------- */
@media only screen and (min-device-width : 320px) and (max-device-width : 480px) {
/* Styles */
}

/* Smartphones (landscape) ----------- */
@media only screen and (min-width : 321px) {
/* Styles */
}

/* Smartphones (portrait) ----------- */
@media only screen and (max-width : 320px) {
/* Styles */
}

/* iPads (portrait and landscape) ----------- */
@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) {
/* Styles */

}

/* iPads (landscape) ----------- */
@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : landscape) {
/* Styles */
}

/* iPads (portrait) ----------- */
@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : portrait) {
/* Styles */
}
/**********
iPad 3
**********/
@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : landscape) and (-webkit-min-device-pixel-ratio : 2) {
/* Styles */
}

@media only screen and (min-device-width : 768px) and (max-device-width : 1024px) and (orientation : portrait) and (-webkit-min-device-pixel-ratio : 2) {
/* Styles */
}
/* Desktops and laptops ----------- */
@media only screen  and (min-width : 1224px) {
/* Styles */
}

/* Large screens ----------- */
@media only screen  and (min-width : 1824px) {
/* Styles */
}

/* iPhone 4 ----------- */
@media only screen and (min-device-width : 320px) and (max-device-width : 480px) and (orientation : landscape) and (-webkit-min-device-pixel-ratio : 2) {
/* Styles */
}

@media only screen and (min-device-width : 320px) and (max-device-width : 480px) and (orientation : portrait) and (-webkit-min-device-pixel-ratio : 2) {
/* Styles */
}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login">
     
  <div class="top">
        <div class="appname" runat="server" id="divAppname">Auth: NTPC Developer Page</div>
    <div class="title" runat="server" id="divHead">Add Your App to Test : <asp:Label ID="lbEmail" runat="server" Text=""  /></div>
  </div>
  <div class="body">
        

      <asp:Panel ID="pnlSignUP" runat="server" Visible="True" >
       
          <div class="tooltip">Your Redirection URL after Login</div>
            <asp:TextBox ID="txtRedirURL" runat="server" class="email" type="text" name="phone" placeholder="http://10.0.236.165/ppm/login.aspx"   MaxLength="50"    /> <br />
        <%--   <div class="tooltip">App ID</div>
            <asp:TextBox ID="txtAppID" runat="server" class="email" type="text" name="phone"  MaxLength="20"  ReadOnly="true"   />   --%>
           <div class="tooltip">App Secret</div>
            <asp:TextBox ID="txtAppSecret" runat="server" class="email" type="text" name="phone"     />
           <div class="tooltip">Your Temp Password</div>
            <asp:TextBox ID="txtPwd" runat="server" class="email" type="text" name="phone"     />
            <asp:Button ID="btnSignUp" runat="server" Text="Add App" class="next" />
         
           <br /><br />
          <hr />
             <div class="tooltip">Choose App</div>
             <asp:DropDownList ID="ddlApps" DataTextField="t" DataValueField ="v" AutoPostBack="true"  runat="server"></asp:DropDownList><br />
           <div class="tooltip">Your Temp Password</div>
            <asp:TextBox ID="txtMyPwd" runat="server" class="email" type="text" name="phone"     />
            <div class="tooltip">Emp No to Test</div>
            <asp:TextBox ID="txtEmp" runat="server" class="email" type="text" name="phone"     />
            <asp:Button ID="btnLogin" runat="server" Text="Test Login" class="next" />
               <div id="divMsg" class="error" runat="server" /> <br />
        
      </asp:Panel>
     
   
   
    <div class="notif">Select your app for testing SSO for any emp ID.</div>
    <div class="logo"><img class="google" src="images/ntpc.png"></div>
  </div>
</div>
    </form>
</body>
</html>
