<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BIFPCL SSO</title>
<meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
    <script src="jquery-3.2.1.min.js"></script>
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
  height: 450px;
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
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <header>
One account. All of BIFPCL.
</header>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
   <div class="login">
     
  <div class="top">
        <div class="appname" runat="server" id="divAppname"></div>
    <div class="title" runat="server" id="divHead">Sign In / Sign Up for New User</div>
  </div>
  <div class="body">
        <asp:Panel ID="pnlSignIn" runat="server" Visible="False" >
    <div class="tooltip">Enter Your Email</div>
      <asp:TextBox ID="txtEmail" runat="server" class="email" type="text" name="email" placeholder="Email" Text ="" />
             <a href="#"><div class="more"></div></a>
      <asp:Button ID="btnEmail" runat="server" Text="Next" class="next" />
            </asp:Panel>

      <asp:Panel ID="pnlSignUP" runat="server" Visible="false" >
           <div class="tooltip">Your email</div>
            <asp:TextBox ID="txtNewEmail" runat="server" class="email" type="text" name="email" placeholder="              @xyz.com"   MaxLength="40"    />
           <div class="tooltip">Your Phone +88-</div>
            <asp:TextBox ID="txtNewPhone" runat="server" class="email" type="text" name="phone" placeholder="11 digit mobile" TextMode="Phone"   MaxLength="11"    />
           <div class="tooltip">Password</div>
            <asp:TextBox ID="txtNewPwd" runat="server" class="email" type="text" name="phone" TextMode="Password"  MaxLength="20"    />
           <div class="tooltip">Retype Password</div>
            <asp:TextBox ID="txtNewPwdRe" runat="server" class="email" type="text" name="phone" TextMode="Password"   MaxLength="20"   />
           <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" class="next" />
      </asp:Panel>
     
     <asp:Panel ID="pnlOTP" runat="server" Visible="False" >
   
         <div class="tooltip">Your email <a href="Default.aspx" >Not you?</a></div>
            <div id="lbOTPMail" runat="server" class="email"    /> <br />
          <div class="tooltip">Enter OTP sent on email/phone</div> 
      <asp:TextBox ID="txtOTP" runat="server" class="email" type="text" name="email" TextMode="Number"   MaxLength="6"  />
                <asp:Button ID="btnOTP" runat="server" Text="Verify" class="next" />
         <br />
         <asp:LinkButton ID="btnResendOTP" runat="server">Resend OTP</asp:LinkButton>
            </asp:Panel>

       <asp:Panel ID="pnlPassword" runat="server" Visible="False" >
   
         <div class="tooltip">Your email <a href="Default.aspx" >Not you?</a></div>
            <div id="divPwdEmail" runat="server" class="email"    /> <br />
          <div class="tooltip">Enter Password</div> 
      <asp:TextBox ID="txtPassword" runat="server" class="email" TextMode="Password"  name="email"    MaxLength="30"  />
            <asp:Button ID="btnsignIn" runat="server" Text="Log In" class="next" />
         <br />  <asp:LinkButton ID="lbForgotPwd"  runat="server">Forgot Password</asp:LinkButton>
           
            </asp:Panel>

       <asp:Panel ID="pnlForgot" runat="server" Visible="false" >
           <div class="tooltip">Your email  <a href="Default.aspx" >Not you?</a></div>
          <div id="divForgotEmail" runat="server" class="email"    /> <br />
          <div class="tooltip">Enter OTP sent on email/phone</div> 
      <asp:TextBox ID="txtForgotOTP" runat="server" class="email" type="text" name="email" TextMode="Number"   MaxLength="6"  />
           <div class="tooltip">Password</div>
            <asp:TextBox ID="txtfPwd" runat="server" class="email" type="text" name="phone" TextMode="Password"  MaxLength="20"    />
           <div class="tooltip">Retype Password</div>
            <asp:TextBox ID="txtfRePwd" runat="server" class="email" type="text" name="phone" TextMode="Password"   MaxLength="20"   />
              <br />      <asp:LinkButton ID="lbForgotOTP1" runat="server">Resend OTP</asp:LinkButton>

           <asp:Button ID="btnReset" runat="server" Text="Reset" class="next" />
             <br />

      </asp:Panel>

      <div id="divMsg" class="error" runat="server" />
    <div class="notif">You will be redirected to app after successfull login.</div>
    <div class="logo"><img class="google" src="../images/icon/logo.png"></div>
  <div class="stats">  <asp:Label ID="lbRegUser" runat="Server" CssClass="tooltip" Text="Registered User:" />  <div class="count" id="divRegUser" runat="server" />
     <asp:Label ID="lbRegApp" runat="Server"  CssClass="tooltip"  Text="Registered App:" /> <div class="count" id="divRegApp" runat="server" /> </div>
  </div>
       
</div>
            </ContentTemplate><Triggers>
                 <asp:PostBackTrigger ControlID="lbForgotOTP1" />
                              </Triggers></asp:UpdatePanel>
    </form>
    <script>
        $(document).ready(function () {
          
            $('.count').each(function () {
                $(this).prop('Counter', 0).animate({
                    Counter: $(this).text()
                }, {
                    duration: 4000,
                    easing: 'swing',
                    step: function (now) {
                        $(this).text(Math.ceil(now));
                    }
                });
            });


        });

    </script>
</body>
</html>
