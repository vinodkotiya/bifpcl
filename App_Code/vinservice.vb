Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Web.Script.Serialization
Imports System.Data.SQLite
Imports System.Data

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://vinodkotiya.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class vinservice
    Inherits System.Web.Services.WebService

    <WebMethod()> _
     <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod(Description:="say hello with name")> _
   <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function sayhelloname(ByVal name As String) As String
        Return "from asp.net web service Hello " + name
    End Function
    <WebMethod(Description:="say hello with name1")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function updatefileCount(ByVal filename As String) As String
        filename = Server.UrlDecode(filename)
        Dim q = "update upload set downloads = downloads+1 , lastview=current_timestamp where filename='" + filename + "'" '"
        Try
            Dim r = dbOp.getDBsingle("update upload set downloads = downloads+1 , lastview=current_timestamp where filename='" + filename + "' ")
            Return "from asp.net web service Hello " + filename + r + q
        Catch e As Exception
            Return "Error: from asp.net web service Hello " + e.Message + q
        End Try

    End Function
    <WebMethod(Description:="say hello with name1")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function removefile(ByVal fileid As String) As String
        fileid = Server.UrlDecode(fileid)
        Dim q = "update kpa_upload set del = 1 where uid='" + fileid + "'" '"
        Try
            Dim r = dbOp.executeDB(q)
            Return "File ID deleted " + fileid + r '+ q
        Catch e As Exception
            Return "Error: from asp.net web service Hello " + e.Message + q
        End Try

    End Function
    <WebMethod(Description:="say hello with namey1")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function getDBSingleX(ByVal type As String) As String
        Dim q = "" '"
        If type = "EPC" Then
            q = "select timeline from dashboard where type = 'fin' limit 1"
        ElseIf type = "ENG" Then
            q = "select timeline from dashboard where type = 'eng' limit 1"
        End If
        Try
            Dim r = dbOp.getDBsingle(q, "dprdb")
            Return r '+ q
        Catch e As Exception
            Return "Error: from asp.net web service Hello " + e.Message + q
        End Try

    End Function
    ''<WebMethod(Description:="sendSMSJson")>
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    'Public Async Function sendSMSJson() As Threading.Tasks.Task(Of String)
    '    Try
    '        '  In web.config
    '        '<assemblies>
    '        '  <add assembly = "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
    '        '</assemblies>
    '        '  Dim myJson As String = "{'api_key':'KEY-aai41fb80abs0ljp130nqv81znmi28rn','api_secret':'1mpR6HcKMF3Cft@r','request_type': 'OTP','message_type':'TEXT','message_body':'OTP 4646','mobile':'01678582832'}"
    '        Dim serializer = New JavaScriptSerializer()
    '        'Dim json As String = serializer.Serialize(New With {Key .api_key = "KEY-aai41fb80abs0ljp130nqv81znmi28rn", Key .api_secret = "1mpR6HcKMF3Cft@r"
    '        ' })
    '        Dim json As String = serializer.Serialize(New With {Key .api_key = "KEY-aai41fb80abs0ljp130nqv81znmi28rn", Key .api_secret = "1mpR6HcKMF3Cft@r", Key .request_type = "OTP", Key .message_type = "OTP", Key .message_body = "OTP 4646 and lets see when it delivered' @r", Key .mobile = "01678582832"
    '    })
    '        Dim myJson As String = "{'api_key':KEY-aai41fb80abs0ljp130nqv81znmi28rn,'api_secret':1mpR6HcKMF3Cft@r}"

    '        Using client = New System.Net.Http.HttpClient
    '            Using response As System.Net.Http.HttpResponseMessage = Await client.PostAsync("https://portal.adnsms.com/api/v1/secure/send-sms", New StringContent(json, Encoding.UTF8, "application/json"))
    '                '  Using response As HttpResponseMessage = Await client.PostAsync("https://portal.adnsms.com/api/v1/secure/check-balance", New StringContent(json, Encoding.UTF8, "application/json"))
    '                Using content As System.Net.Http.HttpContent = response.Content
    '                    ' Get contents of page as a String.
    '                    Dim result As String = Await content.ReadAsStringAsync()
    '                    ' If data exists, print a substring.
    '                    If result IsNot Nothing Then
    '                        Return result.ToString
    '                    End If
    '                End Using
    '            End Using
    '        End Using

    '    Catch e As Exception
    '        Return "Error: from asp.net web service sendSMSJson " + e.Message
    '    End Try

    'End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function GetCurrentTime(ByVal filename As String) As String
        Return "Hello " & filename & Environment.NewLine & "The Current Time is: " ' & _
        ' DateTime.Now.ToString()
    End Function
    <WebMethod(Description:="Ogram Function")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function ogramdata() As String

        Dim mysql = "SELECT  id , pid as parentId, Name, desig as Title,  cell as Phone, 'images/icon/logo.png' as image, workarea as Work from contacts_New where dept in ('PP&M','CEG') and id!=50 order by id "
        Dim dt = dbOp.getDBTable(mysql)
        Dim dataTableRowCount As Integer

            Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))
            Dim row As Dictionary(Of String, Object)
            Try
            dataTableRowCount = dt.Rows.Count

            For Each dr As DataRow In dt.Rows
                    row = New Dictionary(Of String, Object)
                    For Each col As DataColumn In dt.Columns
                        row.Add(col.ColumnName, dr(col))
                    Next
                    rows.Add(row)
                Next
                Return serializer.Serialize(rows)
            ''          Return "[{"id":"1","name":"test1"},{"id":"2","name":"test2"},{"id":"3","name":"test3"},{"id":"4","name":"test4"},{"id":"5","name":"test5"}]"


        Catch exp As Exception
            Return "Error inside web service: " + exp.Message

        End Try
        'Close Database connection
        'and Dispose Database objects
        '' Return "from asp.net web service Hello "
    End Function

    <WebMethod(Description:="getUserControl")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetUserControlHTML(controlpath As String, doctype As String, project As String) As String
        ' Create instance of the page control
        Try
            Dim page As New Page()
            Dim headHolder = New System.Web.UI.HtmlControls.HtmlHead
            ' Create instance of the user control
            Dim userControl As UserControl = DirectCast(page.LoadControl(controlpath), UserControl)

            'Disabled ViewState- If required
            ''  userControl.EnableViewState = False

            'Acces the control via the interface
            Dim UserCtrl As ICustomParams = TryCast(userControl, ICustomParams)
            If UserCtrl IsNot Nothing Then
                UserCtrl.docType = doctype
                UserCtrl.project = project
            End If

            'Form control is mandatory on page control to process User Controls
            Dim form As New HtmlForm()

            'Add user control to the form
            form.Controls.Add(userControl)

            'Add form to the page
            page.Controls.Add(headHolder)
            page.Controls.Add(form)

            'Write the control Html to text writer
            Dim textWriter As New System.IO.StringWriter()

            'execute page on server
            HttpContext.Current.Server.Execute(page, textWriter, False)

            ' Clean up code and return html
            Dim html As String = CleanHtml(textWriter.ToString())

            Return html
        Catch e1 As Exception
            Return "Exception inside webservice: " & e1.Message
        End Try


    End Function
    <WebMethod(Description:="getUserControl")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetUserControlHTML1(controlpath As String) As String
        ' Create instance of the page control
        Try
            Dim page As New Page()
            Dim headHolder = New System.Web.UI.HtmlControls.HtmlHead
            ' Create instance of the user control
            Dim userControl As UserControl = DirectCast(page.LoadControl(controlpath), UserControl)

            'Disabled ViewState- If required
            ''  userControl.EnableViewState = False

            'Acces the control via the interface
            Dim UserCtrl As ICustomParams = TryCast(userControl, ICustomParams)


            'Form control is mandatory on page control to process User Controls
            Dim form As New HtmlForm()

            'Add user control to the form
            form.Controls.Add(userControl)

            'Add form to the page
            page.Controls.Add(headHolder)
            page.Controls.Add(form)

            'Write the control Html to text writer
            Dim textWriter As New System.IO.StringWriter()

            'execute page on server
            HttpContext.Current.Server.Execute(page, textWriter, False)

            ' Clean up code and return html
            Dim html As String = CleanHtml(textWriter.ToString())

            Return html
        Catch e1 As Exception
            Return "Exception inside webservice: " & e1.Message
        End Try


    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function checkSession() As Boolean
        If HttpContext.Current.Session("eid") Is Nothing Then
            Return False
        Else
            Return True
        End If
        ' DateTime.Now.ToString()
    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function setSession(ByVal type As String, ByVal pro As String) As Boolean
        HttpContext.Current.Session("type") = type
        HttpContext.Current.Session("pro") = pro
        Return True

    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function displaySession() As String
        Return HttpContext.Current.Session("eid") & HttpContext.Current.Session("ename")

    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function setUserSession(ByVal eid As String, ByVal name As String) As String
        Try
            If Not String.IsNullOrEmpty(eid) And Not String.IsNullOrEmpty(name) Then
                '  HttpContext.Current.Session.Clear() 
                ' System.Threading.Thread.Sleep(1000)
                HttpContext.Current.Session.Add("eid", eid)
                HttpContext.Current.Session.Add("ename", name)
                'HttpContext.Current.Session("eid") = eid
                'HttpContext.Current.Session("ename") = name
                Return "success"
            Else
                Return "Empty" & eid & name
            End If
        Catch e As Exception
            Return "Error in webservice:" + e.Message
        End Try
    End Function
    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function clearSession() As String
        Try
            HttpContext.Current.Session.Abandon()
            HttpContext.Current.Session.Clear()
            Return "success"
        Catch e As Exception
            Return "Error in webservice:" + e.Message
        End Try
    End Function

    <WebMethod(Description:="authenticateuserAjax")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function authenticateuserAjax(ByVal name As String, ByVal pwd As String) As String
        '  Return "ID is " + name + " pwd is " + pwd
        Dim mysql = "SELECT distinct name FROM users WHERE  eid ='" & name.Trim & "' and pwd='" & pwd.Trim & "' "
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vindb").ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Dim result = ""
            Try
                connection.Open()
                sqlComm = New SQLiteCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If dataTableRowCount = 1 Then
                    result = dt.Rows(0).Item(0).ToString()
                    connection.Close()
                    Return result
                Else
                    connection.Close()
                    Return "Error: Username/Password not valid."
                End If

            Catch exp As Exception

                connection.Close()
                Return "Error inside web service: " + exp.Message

            End Try
            'Close Database connection
            'and Dispose Database objects
        End Using
    End Function

    <WebMethod(Description:="getRating")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function GetRating() As String
        Dim sql As String = "SELECT ROUND(SUM(Rating) / COUNT(Rating),1) as Average , COUNT(Rating)as Total FROM suggestion"
        Dim mydt = dbOp.getDBTable(sql)
        Dim json As String = String.Empty
        For Each row In mydt.Rows
            json += "[ {"
            json += String.Format("Average: {0}, Total: {1}", row(0), row(1))
            'json += String.Format("Average: {0}, Total: {1}", "4.1", "19")
            json += "} ]"
            Exit For
        Next

        Return json

    End Function
    <WebMethod(Description:="setRating")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function setRating() As String

        Dim sql As String = "insert into suggestion "


        Return "success"

    End Function
    <WebMethod(Description:="getControlwithData")>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function getControlwithData(doctype As String, project As String) As String
        ' Create instance of the page control
        Dim gv As New GridView()
        Dim stringWriter As New System.IO.StringWriter()
        Dim htmlWriter As New HtmlTextWriter(stringWriter)
        Dim myDT = dbOp.getDBTable("select project, date_format(last_updated,'%d.%m.%y') as reviewdate,date_format(reviewdate,'%d.%m.%y') as reviewdate1,reviewby,subject,venue,filename,remarks1,remarks2, concat(project,'\\',type,'\\',filename) as url   from upload_cmg where project like '" & project & "' and type = '" & doctype & "' order by reviewdate1 desc")
        gv.Caption = dbOp.getDBsingle("select count(project)  from upload_cmg where project like '" & project & "' and type = '" & doctype & "' order by reviewdate desc") & " records found.."
        'gv.AllowPaging = True
        'gv.PageSize = 10
        'project0, 1 reviewdate, 2 reviewdate1,3reviewby,4 subject,5 venue,6 filename,7 remarks1,8 remarks2,  9 url
        For Each row In myDT.Rows
            row(9) = getfileIcon(row(9))
        Next
        ' myDT.Columns.Remove(0) 'remove 1st column
        gv.DataSource = myDT
        gv.DataBind()
        gv.HeaderRow.TableSection = TableRowSection.TableHeader
        gv.RenderControl(htmlWriter)
        Return stringWriter.ToString()
    End Function
    Private Function getfileIcon(ByVal file As String) As String
        Dim thefile As String = "\upload\" & file
        Dim img As String = "images/" & Right(thefile, 3) & ".gif"
        Dim ret = ""
        Try ' If System.IO.File.Exists(Server.MapPath("~") + thefile) Then
            Dim fs As System.IO.FileInfo = New System.IO.FileInfo(Server.MapPath("~") + thefile)
            ret = "<img src='" & img & "' width=13 height=13 border=0 onerror=" & Chr(34) & "this.src='images/file.gif';" & Chr(34) & "  />" & Math.Round((fs.Length / (1024 * 1024)), 2).ToString()   'Left(e.Row.Cells(2).Text, 2)
        Catch e1 As Exception ' Else
            ret = Math.Round((Rnd(6) * 600)).ToString & thefile & e1.Message
        End Try 'End If
        Return ret
    End Function

    Private Function CleanHtml(html As String) As String
        Return html 'Regex.Replace(html, "]*?>", "", RegexOptions.IgnoreCase)
    End Function



    <WebMethod(Description:="authenticateuser")> _
  <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function authenticateuser(ByVal name As String, ByVal pwd As String) As String
        ''  Return "ID is " + name + " pwd is " + pwd
        'Dim mysql = "SELECT distinct first_name FROM users u,groups g,group_users gu WHERE u.userid = gu.userid and g.gid = gu.gid and username='" & name.Trim & "' and password=md5('" & pwd.Trim & "') and g.name like ('%')"
        'Using connection As New MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
        '    connection.Open()
        '    Dim result As String
        '    Dim sqlComm As MySqlCommand
        '    Dim sqlReader As MySqlDataReader
        '    Dim dt As New DataTable()
        '    Dim dataTableRowCount As Integer
        '    Try
        '        sqlComm = New MySqlCommand(mysql, connection)
        '        sqlReader = sqlComm.ExecuteReader()
        '        dt.Load(sqlReader)
        '        dataTableRowCount = dt.Rows.Count
        '        sqlReader.Close()
        '        sqlComm.Dispose()
        '        If dataTableRowCount = 1 Then
        '            result = dt.Rows(0).Item(0).ToString()
        '            connection.Close()
        '            Return result
        '        Else
        '            connection.Close()
        '            Return "Error: Username/Password not valid."
        '        End If

        '    Catch exp As Exception

        '        connection.Close()
        '        Return "Error: " + exp.Message

        '    End Try
        '    'Close Database connection
        '    'and Dispose Database objects
        'End Using
    End Function
    <WebMethod()> _
    Public Function GetCompletionList(prefixText As String) As String()
        'Dim items As New List(Of String)(50)
        '''this function will return single value from table by concatenating rows with hash
        'Using connection As New MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
        '    ' connection.Close()
        '    connection.Open()

        '    Dim sqlComm As MySqlCommand
        '    Dim sqlReader As MySqlDataReader
        '    Dim dt As New DataTable()
        '    Dim j As Integer = 0
        '    Dim myquery = "SELECT distinct concat(project,' ', type) as res FROM `upload_cmg` where project like '%" & prefixText & "%' or type like '%" & prefixText & "%'" & _
        '        " order by project, type"
        '    Try
        '        sqlComm = New MySqlCommand(myquery, connection)
        '        sqlReader = sqlComm.ExecuteReader()
        '        dt.Load(sqlReader)
        '        Dim i = dt.Rows.Count

        '        sqlReader.Close()
        '        sqlComm.Dispose()
        '        If i = 0 Then
        '            connection.Close()
        '            'items = Nothing
        '            items.Add("No Records")

        '        End If

        '        While j < i

        '            items.Add(dt.Rows(j).Item(0).ToString())

        '            j = j + 1
        '        End While

        '        connection.Close()
        '        Return items.ToArray()


        '    Catch e1 As Exception
        '        'lblDebug.text = e.Message
        '        connection.Close()
        '        items.Add(e1.Message)
        '        Return items.ToArray()
        '    End Try
        '    'connection.Close()
        'End Using
    End Function
End Class