<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dev.aspx.vb" Inherits="_dev" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NTPC SSO</title>
    <link href='favicon.ico' rel='icon' type='image/x-icon'/>
    <style>
 @import url(css/google.css);
* {
  margin: 0;
  padding: 0;
  font-family: 'Roboto', sans-serif;
}
body {
  background-color: #999;
}
.login {
  margin-left: auto; margin-right: auto;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  border-bottom-left-radius: 3px;
  border-bottom-right-radius: 3px;
  background-color: #fff;
  height: 1000px;
  width: 380px;
  margin-top: 20px;
  -webkit-box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
-moz-box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
box-shadow: 0px 0px 20px -2px rgba(0,0,0,0.75);
}
.top {
  background-color: #1976d2;
  height: 100px;
  width: 380px;
  position: absolute;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
}
.title {
  color: #fff;
  position: absolute;
  bottom: 10px;
  left: 30px;
  font-size: 20px;
  font-weight: 300;
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
}
.body {
  position: absolute;
  margin-top: 100px;
  height: 300px;
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
.google {
  width: 70px;
  padding-bottom: 10px;
  margin-left: 100px;
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
 .codebox {
        /* Below are styles for the codebox (not the code itself) */
        border:1px solid black;
        background-color:#EEEEFF;
        width:300px;
        overflow:auto;    
        padding:10px;
    }
    .codebox code {
        /* Styles in here affect the text of the codebox */
         width:550px;
        font-size:0.9em;
        /*min-height:200px;
        max-height:400px;*/
        /* You could also put all sorts of styling here, like different font, color, underline, etc. for the code. */
    }
    </style>
    <script src="jquery-3.2.1.min.js"></script>
     <script type="text/javascript">
         function myFunction() {
             alert("I am an alert box!");
         }
        function copyToClipboard(element) {
          // alert('hi');
            var code = document.getElementById(element).value;
           if (code.length == 0) { return 0; }
            var $temp = $("<input>");
            $("body").append($temp);
            $temp.val(code).select();
            document.execCommand("copy");
            $temp.remove();
            alert('Code ' + document.getElementById(element).value + ' is copied.');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <header>
One account. All of NTPC.
</header>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
   <div class="login">
     
  <div class="top">
        <div class="appname" runat="server" id="divAppname">Auth: NTPC Developer Page</div>
    <div class="title" runat="server" id="divHead">Register Your App : <asp:Label ID="lbEmail" runat="server" Text=""  /></div>
  </div>
  <div class="body">
        

      <asp:Panel ID="pnlSignUP" runat="server" Visible="True" >
          <asp:DropDownList ID="ddlApps" DataTextField="t" DataValueField ="v" AutoPostBack="true"  runat="server"></asp:DropDownList><br />
           <div class="tooltip">Your Website/App Name</div>
            <asp:TextBox ID="txtApp" runat="server" class="email" type="text" name="email"   MaxLength="50"    />
           <div class="tooltip">Your Website/App URL</div>
            <asp:TextBox ID="txtAppUrl" runat="server" class="email" type="text" name="phone" placeholder="http://10.0.236.165/ppm"   MaxLength="50"    />
           <div class="tooltip">Your Redirection URL after Login</div>
            <asp:TextBox ID="txtRedirURL" runat="server" class="email" type="text" name="phone" placeholder="http://10.0.236.165/ppm/login.aspx"   MaxLength="50"    /> <br />
          <asp:CheckBox ID="cbUsers" runat="server" Text="Allow Access to NTPC Users only" Checked="true"  />
            <asp:Button ID="btnSignUp" runat="server" Text="Register" class="next" />
           <div class="tooltip">App ID</div>
            <asp:TextBox ID="txtAppID" runat="server" class="email" type="text" name="phone"  MaxLength="20"  ReadOnly="true"   />   <button onclick="copyToClipboard('txtAppID')"><img src="images/copy.png" alt="Copy" width="32" /></button>
           <div class="tooltip">App Secret</div>
            <asp:TextBox ID="txtAppSecret" runat="server" class="email" type="text" name="phone"     />
           <button  onclick ="copyToClipboard('txtAppSecret')"><img src="images/copy.png" alt="Copy" width="32" /></button>
     <br />
             <div id="divMsg" class="error" runat="server" /> <br />
             <asp:Button ID="btnFone" runat="server" Text="Update Phone" class="next" /><br />
          Example:
          <div class="codebox">
        <code>   
            ''Call the SSO Login with your appid 
              Response.Redirect("https://cc.ntpc.co.in/sso/Default.aspx?appid=12343218")
        </code>
              </div> <br /><br />
              <div class="codebox" style="height:250px;">
        <code>   
            ''Catch the authorised login credential as follows using your app secret
            <br />
            ' If Request.Form.Count > 0 Then   <br />
             If not Request.Form("eid") is Nothing Then <br />
                Dim appsecret = "wSISKY2/p8j4P1iyqppUEhhvWfFfzqi/WlrqHbr+1rQ="   <br />
               Session("eid") = Decrypt(Request.Form("eid"), appsecret)   <br />
               Session("email") = Decrypt(Request.Form("email"), appsecret)   <br />
            End If
             <br /> <br />
            '' For decrypt function use this <br />
            Imports System.Security.Cryptography <br /> <br />
Public Shared Function Decrypt(cipherText As String, ByVal EncryptionKey As String As String <br />
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText) <br />
        Using encryptor As Aes = Aes.Create() <br />
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
    <br />
        Return cipherText <br />
    End Function <br />

        </code>
             
    </div>
      </asp:Panel>
       <asp:GridView ID="gvUsers"  Font-Size="14px" ForeColor="Black"  CssClass="table-striped" runat="server" /> 
     <a href="sso.pdf" target="_blank" >How It Works</a>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   <a href="upload/demo.txt" target="_blank" >Demo Login Page</a>

   
    <div class="notif">Register your app & get the appid and app secret for login.</div>
    <div class="logo"><img class="google" src="images/ntpc.png"></div>
  </div>
</div>
            </ContentTemplate><Triggers>
            <%--     <asp:PostBackTrigger ControlID="lbForgotOTP1" />--%>
                              </Triggers></asp:UpdatePanel>
    </form>
   
</body>
</html>
