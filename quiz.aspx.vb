Imports dbOp
Imports Common
Imports System.Data
Imports System.IO

Partial Class _quiz
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '<########## Login MODULE

            '
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")

            '  divMobiSidmenu.InnerHtml = makemenu(True, 2)
            ' divSideMenu.InnerHtml = makemenu(False, 2)
            'divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            'divLogin.InnerHtml = showAccount(Session("email"))
            Dim mydt = getDBTable("select q,a,b,c,d,ans from quiz2")
            WriteJason(mydt, Server.MapPath("./pages/quiz/activity.json"))
            '          {
            '"quizlist": [
            '  {
            '    "q": "About What percentage of the total net electricity generated in Bangladesh each day is represented by coal?",
            '    "a": "15 percent",
            '    "b": "40 percent",
            '    "c": "11 percent",
            '    "d": "3 percent",
            '    "ans": "D"
            '  }
            '  ]}

            GridView1.DataSource = getDBTable("select q,a,b,c,d,ans from quiz")
            GridView1.DataBind()

        End If
        executeDB("update hits set view = view+1 where page = 'home'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Home Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    Function WriteJason(ByVal dt As DataTable, ByVal path As String) As Boolean
        Try
            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As List(Of Dictionary(Of String, String)) = New List(Of Dictionary(Of String, String))()
            Dim row As Dictionary(Of String, String) = Nothing

            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, String)()

                For Each col As DataColumn In dt.Columns
                    row.Add(col.ColumnName.Trim().ToString(), Convert.ToString(dr(col)))
                Next

                rows.Add(row)
            Next

            Dim jsonstring As String = serializer.Serialize(rows)

            Using file = New StreamWriter(path, False)
                file.Write(jsonstring)
                file.Close()
                file.Dispose()
            End Using

            Return True
        Catch
            Return False
        End Try
    End Function
End Class
