<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBio" runat="server" Text="Attendence" />
            <asp:Button ID="Button1" runat="server" Text="Button" />
             <asp:Button ID="Button2" runat="server" Text="SMS OTP" />
            <asp:Button ID="Button4" runat="server" Text="SMS Bulk" /> <br /><br />
             <asp:Button ID="Button3" runat="server" Text="Weekday" />
            <asp:Button ID="btnWrittenSMS" runat="server" Text="SMS Written" />
             <asp:Button ID="btnWrittenEmail" runat="server" Text="Email Written" />
                <asp:Button ID="btnDept" runat="server" Text="Email Written Dept" /> <br />
             <asp:Button ID="btnInterviewSMS" runat="server" Text="SMS Interview" />
             <asp:Button ID="btnInterviewEmail" runat="server" Text="Email Interview" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
