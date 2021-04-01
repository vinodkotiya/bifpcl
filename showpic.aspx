<%@ Page Language="VB" %>
<html>
<body>
    <form id="form1" runat="server">
   
    <img style="width:120px; height:150px;" onerror="this.src='https://www.bifpcl.com/upload/employee/pics/user.png';" src="https://www.bifpcl.com/upload/employee/pics/<% Response.Write(Request.Params("eid"))%>.jpg"  />
   

    </form>
</body>
</html>