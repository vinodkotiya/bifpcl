<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dailybackup.aspx.vb" Inherits="dailybackup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Designed By Vinod Kotiya to Mail the Backups</title>
          <meta http-equiv="refresh" content="1800">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="zip db file" />
         <asp:Button ID="Button2" runat="server" Text="Check DB integrity" />
        <div id="divmsg" runat="server" />

    </div>
    </form>
</body>
</html>
