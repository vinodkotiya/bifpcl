Imports Microsoft.VisualBasic
Imports System.Data.SQLite
Imports System.Data
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net.Mail
Imports System.Net

Public Class dbOp
    Public invalid As Boolean
    Public Shared Function getDBsingle(ByVal mysql As String, Optional ByVal myConn As String = "vindb") As String
        ''this function will return single value from table according to myQuery
        'Create Connection String
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim result As String
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
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
                    Return "Error:Too many Records Found"
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return "Error" + e.Message
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function recentUploads(ByVal myQuery As String, ByVal type As String) As String
        ''this function will return single value from table according to myQuery
        Dim more = "<li class='vinHidden'><a href=" & Chr(34) & "#" & Chr(34) & " style='text-decoration: none; z-index:2000;' onclick=" & Chr(34) & "javascript:vinModal('" & type & "','%');return false;" & Chr(34) & "> +More..</a></li>"
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vindb").ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            connection.Open()
            Dim result As String = "<ul>"

            Dim dt As New DataTable()
            Dim j As Integer = 0
            Dim proj As String
            Try
                sqlComm = New SQLiteCommand(myQuery, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                Dim i = dt.Rows.Count

                sqlReader.Close()
                sqlComm.Dispose()
                If i = 0 Then
                    connection.Close()
                    'Return "Too many Records Found"

                End If

                While j < i

                    'type  project  subject  filename

                    proj = Uri.EscapeDataString(dt.Rows(j).Item(1).ToString())
                    If dt.Rows(j).Item(0).ToString() = "Review" Then  'for vendor
                        proj = "Vendor/" & proj
                    End If

                    result = result & "<li class='vinHidden'><a href=/larr/upload/" & proj & "/" & dt.Rows(j).Item(0).ToString() & "/" & Uri.EscapeDataString(dt.Rows(j).Item(3).ToString()) & " onclick=fileCount('" & Uri.EscapeDataString(dt.Rows(j).Item(3).ToString()) & "') target=_blank style='text-decoration: none;color: #000;'><img src=images/" & Right(dt.Rows(j).Item(3).ToString(), 3) & ".gif border=0 align=middle height=13px onerror=" & Chr(34) & "this.src='images/file.gif';" & Chr(34) & "/> " & dt.Rows(j).Item(2).ToString.Replace("CMG", "PPM") & " </a></li>"

                    j = j + 1
                End While

                connection.Close()
                Return result & more & "</ul>"


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                result = e.Message
                Return result
            End Try
            'connection.Close()
        End Using
    End Function
    Public Shared Function executeDB(ByVal mysql As String, Optional ByVal myConn As String = "vindb") As String

        'Create Connection String
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader

            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SQLiteCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()
                'Add Insert Statement
                sqlComm.Dispose()

                connection.Close()
                executeDB = "ok"


            Catch exp As Exception
                'lbldebug.Text = exp.Message
                connection.Close()
                executeDB = "Error:" + exp.Message

            End Try
            'Close Database connection
            'and Dispose Database objects
        End Using

    End Function
    Public Shared Function getDBTable(ByVal myQuery As String, Optional ByVal myConn As String = "vindb") As DataTable
        ''this function will return DataTable from table according to myQuery
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            ' connection.Close()
            connection.Open()

            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                sqlComm = New SQLiteCommand(myQuery, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)

                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If Not dt Is Nothing Then

                    connection.Close()
                    Return dt
                Else
                    connection.Close()
                    Return dt.NewRow("Too many Records Found")
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                dt.Columns.Add("Error")
                Dim tmprow = dt.NewRow
                connection.Close()
                tmprow(0) = "Error: " & e.Message & myQuery
                dt.Rows.Add(tmprow)
                ' Return dt.NewRow("Error in getdatatable")
                Return dt
            End Try
            connection.Close()
        End Using
    End Function
    Public Shared Function getDBSinglecommaSepearated(ByVal myQuery As String, Optional ByVal myConn As String = "vindb") As String
        ''this function will return single value from table by concatenating rows with hash
        Using connection As New SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings(myConn).ConnectionString)
            ' connection.Close()
            connection.Open()
            Dim result As String = ""
            Dim sqlComm As SQLiteCommand
            Dim sqlReader As SQLiteDataReader
            Dim dt As New DataTable()
            Dim j As Integer = 0

            Try
                sqlComm = New SQLiteCommand(myQuery, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                Dim i = dt.Rows.Count

                sqlReader.Close()
                sqlComm.Dispose()
                If i = 0 Then
                    connection.Close()
                    Return "NA"

                End If

                While j < i

                    result = result & " '" & dt.Rows(j).Item(0).ToString() & "',"

                    j = j + 1
                End While

                connection.Close()
                Return result & "''"


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                result = e.Message
                Return result
            End Try
            'connection.Close()
        End Using
    End Function
    Public Shared Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "VINODKOTIYA2016"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
    Public Shared Function getOrGenerateEid(ByVal email As String) As String
        Dim q = "select eid from nonntpc where email = '" & email & "' limit 1"
        Dim empno = dbOp.getDBsingle(q)
        If empno.Contains("Error") Then
            '' generate emp no for this user.
            q = "insert into nonntpc (email, eid) values ('" & email & "', -1)"
            Dim ret = dbOp.executeDB(q)
            If ret.Contains("Error") Then
                Return ret
            Else
                Return -1
            End If
        Else
            Return empno
        End If
    End Function
    Public Shared Function isAuthorised(ByVal eid As String, Optional ByVal app As String = "E8WS") As Integer
        '' 1 for pace officer, 2 for GM , 3 for WS,4 ntpc emp,  5 restriction
        If Not app = "PF" Then
            Dim q = "select distinct eid from kpa_hr where eid = " & eid & " "
            Dim ret = getDBsingle(q)
            If Not ret.Contains("Error") Then Return 1
            q = "select distinct eid from (select distinct eid from kpa_forms union all select distinct ro as eid from kpa_forms  union all select distinct r1  as eid from kpa_forms  union all select distinct r2 as eid  from kpa_forms  union all select distinct r3 from kpa_forms   ) where eid = " & eid & " "
            ret = getDBsingle(q)
            If Not ret.Contains("Error") Then Return 2
            q = "select distinct eid from (select distinct ro as eid from kpa_forms  union all select distinct r1  as eid from kpa_forms  union all select distinct r3  as eid from kpa_forms   ) where eid = " & eid & " "
            ret = getDBsingle(q, "wsdb")
            If Not ret.Contains("Error") Then Return 3
            q = "select distinct empno from employee where empno = " & eid & "  "
            ret = getDBsingle(q)
            If Not ret.Contains("Error") Then Return 4

            Return 5
        Else
            Dim q = "select distinct eid from kpa_hr where eid = " & eid & " "
            Dim ret = getDBsingle(q)
            If Not ret.Contains("Error") Then Return 1
            q = "select distinct eid from (select distinct eid from kpa_feedback union all select distinct ro as eid from kpa_feedback  union all select distinct r1  as eid from kpa_feedback  union all  select distinct r3 from kpa_feedback   ) where eid = " & eid & " "
            ret = getDBsingle(q)
            If Not ret.Contains("Error") Then Return 8
            Return 5
        End If
    End Function
    Public Shared Function dualTab(ByVal eid As String) As Boolean
        Dim q = "select distinct eid from (select distinct eid from kpa_forms union all select distinct ro from kpa_forms  union all select distinct r1 from kpa_forms  union all select distinct r2 from kpa_forms  union all select distinct r3 from kpa_forms   ) where eid = " & eid & " "
        Dim ret = getDBsingle(q)
        If Not ret.Contains("Error") Then
            q = "select distinct eid from (select distinct ro as eid  from kpa_forms  union all select distinct r1 as eid  from kpa_forms  union all select distinct r3  as eid from kpa_forms   ) where eid = " & eid & " "
            ret = getDBsingle(q, "wsdb")
            If Not ret.Contains("Error") Then Return True
        End If
        Return False
    End Function
    Public Shared Function DecryptApp(cipherText As String, Optional ByVal EncryptionKey As String = "VINODKOTIYA2016") As String
        'If System.Web.HttpRuntime.Cache("marks" & cipherText) Is Nothing Then

        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
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
        '  System.Web.HttpRuntime.Cache.Insert("marks" & cipherText, cipherText, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)

        'End If
        '''PHP Equivqlent
        '        $decryptedBytes = NULL;
        '$saltBytes = array(1,2,3,4,5,6,7,8);
        '$saltBytesstring = "";
        'For ($i= 0;$i<count($saltBytes);$i++){ echo $i;
        '    $saltBytesstring=$saltBytesstring.chr($saltBytes[$i]);
        '}

        '$AESKeyLength = 265/8;
        '$AESIVLength = 128/8;

        '$key = hash_pbkdf2("sha1", $passwordBytesstring, $saltBytesstring, 1000, $AESKeyLength + $AESIVLength, true); 

        '$aeskey = (  substr($key,0,$AESKeyLength) );
        '$aesiv =  (  substr($key,$AESKeyLength,$AESIVLength) );

        '$decrypted = mcrypt_decrypt
        '      (
        '          MCRYPT_RIJNDAEL_128,
        '          $aeskey,
        '          $bytesToBeDecryptedbinstring,
        '          MCRYPT_MODE_CBC,
        '          $aesiv
        '       );
        '$arr = str_split($decrypted);
        'For ($i= 0;$i<count($arr);$i++){
        '    $arr[$i] = ord($arr[$i]);
        '}
        '$decryptedBytes = $arr;
        Return cipherText
    End Function
    Public Shared Function Decrypt(cipherText As String) As String
        Dim m = Left(cipherText, 2)
        If System.Web.HttpRuntime.Cache("marks" & m) Is Nothing Then
            Dim EncryptionKey As String = "VINODKOTIYA2016"
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Using encryptor As Aes = Aes.Create()
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
            System.Web.HttpRuntime.Cache.Insert("marks" & m, cipherText, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)

        End If
        Return System.Web.HttpRuntime.Cache("marks" & m)
    End Function
    Public Shared Function cookieEncrypt(raw As String) As String
        Using csp = New AesCryptoServiceProvider()
            Dim e As ICryptoTransform = GetCryptoTransform(csp, True)
            Dim inputBuffer As Byte() = Encoding.UTF8.GetBytes(raw)
            Dim output As Byte() = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length)

            Dim encrypted As String = Convert.ToBase64String(output)

            Return encrypted
        End Using
    End Function

    Public Shared Function cookieDecrypt(encrypted As String) As String
        Try
            Using csp = New AesCryptoServiceProvider()
                Dim d = GetCryptoTransform(csp, False)
                Dim output As Byte() = Convert.FromBase64String(encrypted)
                Dim decryptedOutput As Byte() = d.TransformFinalBlock(output, 0, output.Length)

                Dim decypted As String = Encoding.UTF8.GetString(decryptedOutput)
                Return decypted
            End Using
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Private Shared Function GetCryptoTransform(csp As AesCryptoServiceProvider, encrypting As Boolean) As ICryptoTransform
        csp.Mode = CipherMode.CBC
        csp.Padding = PaddingMode.PKCS7
        Dim passWord = "EPSSO@TGRE545815SKJ"
        Dim salt = "thisisthes@ltforpropertyreturn@pplication"

        'a random Init. Vector. just for testing
        Dim iv As [String] = "e675f725e675f725"

        Dim spec = New Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(passWord), Encoding.UTF8.GetBytes(salt), 65536)
        Dim key As Byte() = spec.GetBytes(16)


        csp.IV = Encoding.UTF8.GetBytes(iv)
        csp.Key = key
        If encrypting Then
            Return csp.CreateEncryptor()
        End If
        Return csp.CreateDecryptor()
    End Function
    ''' if you change anything here then find and replace everywhere.
    Public Shared Function getFormStatusP(formstatus As String) As String
        Dim ret = formstatus
        If formstatus = "final_emp_edit" Then : ret = "<span style='background-color: #ffc107;'>With Employee </span>"
        ElseIf formstatus = "final_ro_edit" Then : ret = "<span style='background-color: #4cd4e3;'>With BUH </span>"
        ElseIf formstatus = "final_r1_edit" Then : ret = "<span style='background-color: #bde6c6;'>With RED </span>"
        ElseIf formstatus = "final_r3_edit" Then : ret = "<span style='background-color: lime;'>With HR </span>"
        ElseIf formstatus = "final_completed" Then : ret = "<span style='background-color: lime;'>Completed </span>"
        End If
        Return ret
    End Function
    Public Shared Function getFormStatus(formstatus As String) As String
        Dim ret = formstatus
        If formstatus = "plan_emp_edit" Then : ret = "<span style='background-color: yellow;'>Planning - With Employee </span>"
        ElseIf formstatus = "plan_ro_edit" Then : ret = "<span style='background-color: yellow;'>Planning - With RO </span>"
        ElseIf formstatus = "plan_completed" Then : ret = "<span style='background-color: lime;'>Planning - Accepted </span>"
        ElseIf formstatus = "final_emp_edit" Then : ret = "<span style='background-color: yellow;'>Final - With Employee </span>"
        ElseIf formstatus = "final_ro_edit" Then : ret = "<span style='background-color: yellow;'>Final - With Reporting Authority </span>"
        ElseIf formstatus = "final_r1_edit" Then : ret = "<span style='background-color: yellow;'>Final - With Reviewing Authority </span>"
        ElseIf formstatus = "final_r2_edit" Then : ret = "<span style='background-color: yellow;'>Final - With Concerned Director </span>"
        ElseIf formstatus = "final_r3_edit" Then : ret = "<span style='background-color: yellow;'>Final - With Accepting Authority </span>"
        ElseIf formstatus = "final_completed" Then : ret = "<span style='background-color: lime;'>Final - Completed </span>"
        End If
        Return ret
    End Function
    ''' if you change anything here then find and replace everywhere.
    Public Shared Function getFormStatusRaw(formstatus As String) As String
        Dim ret = formstatus
        If formstatus = "plan_emp_edit" Then : ret = "Planning - With Employee"
        ElseIf formstatus = "plan_ro_edit" Then : ret = "Planning - With RO"
        ElseIf formstatus = "plan_completed" Then : ret = "Planning - Accepted"
        ElseIf formstatus = "final_emp_edit" Then : ret = "Final - With Employee"
        ElseIf formstatus = "final_ro_edit" Then : ret = "Final - With Reporting Authority"
        ElseIf formstatus = "final_r1_edit" Then : ret = "Final - With Reviewing Authority"
        ElseIf formstatus = "final_r2_edit" Then : ret = "Final - With Concerned Director"
        ElseIf formstatus = "final_r3_edit" Then : ret = "Final - With Accepting Authority"
        ElseIf formstatus = "final_completed" Then : ret = "Final - Completed"
        End If
        Return ret
    End Function
    Public Shared Function formLastUpdate(ByVal formid As String, ByVal updateby As String, Optional ByVal mydb As String = "vindb") As Boolean

        Dim q = "update kpa_forms set last_updated = current_timestamp, last_updateby = '" & updateby & "' where formid = " & formid
        Dim ret = executeDB(q, mydb)
        Return True
    End Function
    Public Shared Function takeBackup() As String
        ''Backup
        Dim thefile As String = "\App_Data\hrap.db"
        Dim fs As System.IO.FileInfo = New System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath("~") + thefile)
        Dim dbsize = Math.Round((fs.Length / (1024)), 2)
        Dim str = "Storage Status: " & dbsize.ToString() & " kb of 140 TB (" & Math.Round(Decimal.Divide(dbsize, 150323855359), 10).ToString & "% of database max limit)"

        Dim copystatus = ""
        Try
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day1'") > 24 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapday1.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day1'")
                copystatus += "<br/>Day1 backup taken"
            Else
                copystatus += "<br/>Skip Copy, 1 Day old backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day1'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day2'") > 48 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapday2.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day2'")
                copystatus += "<br/>Day2 backup taken"
            Else
                copystatus += "<br/>Skip Copy, 2 Day old backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day2'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day7'") > 150 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapday7.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day7'")
                copystatus += "<br/>Weekly backup taken"
            Else
                copystatus += "<br/>Skip Copy, weekly backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day7'")
            End If
            If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'day30'") > 600 Then
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + thefile, System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapday30.db", True)
                File.Copy(System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapws.db", System.Web.HttpContext.Current.Server.MapPath("~") + "\App_Data\hrapdayws30.db", True)
                executeDB("update backup set last_updated= current_timestamp where backupday = 'day30'")
                copystatus += "<br/>Monthly backup taken"
            Else
                copystatus += "<br/>Skip Copy, Monthly backup already taken on " & getDBsingle("select last_updated from backup where backupday = 'day30'")
            End If
        Catch ex As Exception
            copystatus += "Unable to copy " & ex.Message
        End Try
        Return str & "<br/>" & copystatus
    End Function

    Public Shared Function geteidfromSupportID(ByVal searchid As String) As String
        Dim lastupdateMin = getDBsingle("select (strftime('%s','now')- strftime('%s',max(logintime))) / 60 from login where loginid = " & searchid & " limit 1")
        Dim eid = "NA"
        If lastupdateMin > 0 And lastupdateMin < 60 Then
            eid = getDBsingle("select eid from login where loginid = " & searchid & " limit 1")
        End If
        Return eid
    End Function
    Public Shared Function getRegionfromProject(ByVal searchid As String) As String
        If System.Web.HttpRuntime.Cache("proj" & searchid) Is Nothing Then
            Dim region = getDBsingle("select hr from kpa_project where project = '" & searchid & "' limit 1")
            If region.Contains("Error") Then region = "CC - SCOPE"
            System.Web.HttpRuntime.Cache.Insert("proj" & searchid, region, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
        End If
        Return System.Web.HttpRuntime.Cache("proj" & searchid)
    End Function
    Public Shared Function getAuthorityfromEid(ByVal searchid As String, ByVal formyear As String) As String

        If System.Web.HttpRuntime.Cache("auth" & searchid) Is Nothing Then
            Dim q = "select cluster from cluster where year = " & formyear & " and shid = " & searchid & " limit 1"
            Dim region = getDBsingle(q)
            If region.Contains("Error") Then region = getnamefromEid(searchid)
            System.Web.HttpRuntime.Cache.Insert("auth" & searchid, region, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
        End If
        Return System.Web.HttpRuntime.Cache("auth" & searchid)
    End Function
    Public Shared Function getnamefromEid(ByVal searchid As String) As String

        Try
            Dim fromcache = ""
            If System.Web.HttpRuntime.Cache("bnameDT") Is Nothing Then

                Dim q = "  select   distinct cast(empno as int) as eid,  name from empmast  union select   distinct cast(eid as int), ename as name from kpa_sap_workflow where not ename ='' union select   distinct cast(ro as int) as eid, roname as name from kpa_sap_workflow where  not  roname =''  union select   distinct cast(r1 as int) as eid, r1name as name from kpa_sap_workflow  where not r1name ='' union select   distinct cast(r2 as int) as eid, r2name as name from kpa_sap_workflow where  not r2name =''  union select   distinct cast(r3 as int) as eid, r3name as name from kpa_sap_workflow where  not r3name =''  "

                Dim mydt = getDBTable(q)

                q = " select   distinct cast(eid as int) as eid, ename as name from kpa_sap_workflow union select   distinct cast(ro as int) as eid, roname as name from kpa_sap_workflow union select   distinct cast(r1 as int) as eid, r1name as name from kpa_sap_workflow union select   distinct cast(r3 as int) as eid, r3name as name from kpa_sap_workflow"
                Dim mydt1 = getDBTable(q, "wsdb")
                'For Each r In mydt1.Rows
                '    mydt.Rows.Add(r)
                'Next
                'mydt.AcceptChanges()
                mydt.Merge(mydt1, False, System.Data.MissingSchemaAction.Add)
                System.Web.HttpRuntime.Cache.Insert("bnameDT", mydt, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                fromcache = "'"
            End If
            Dim CachedDT = CType(System.Web.HttpRuntime.Cache("bnameDT"), System.Data.DataTable)
            'Dim myview = CachedDT.DefaultView
            ''  Dim myview = mydt.DefaultView
            'myview.Sort = "eid"
            ' Dim indx = myview.Find(txtEid.Text)
            Dim foundRows() As System.Data.DataRow
            foundRows = CachedDT.Select("eid = " & searchid.TrimStart("0") & "")
            If foundRows.Count > 0 Then
                Return fromcache & foundRows(0)(1)
            Else
                '   Return "Name not in workflow"
                If System.Web.HttpRuntime.Cache("ename" & searchid) Is Nothing Then
                    '"select ename from kpa_sap_workflow where eid = " & searchid & " and ename is not null union all select distinct roname as ename from kpa_sap_workflow where ro =  " & searchid & " and roname is not null union all select distinct r1name as ename from kpa_sap_workflow where r1 =  " & searchid & " and r1name is not null union all select distinct r2name as ename from kpa_sap_workflow where r2 =  " & searchid & " and r2name is not null  union all select distinct r3name as ename from kpa_sap_workflow where r3 =  " & searchid & " and r3name is not null order by ename limit 1"
                    fromcache = "*"
                    Dim name = getDBsingle("select firstname from employee where empno = '" & searchid.ToString.PadLeft(6, "0") & "' limit 1")
                    If name.Contains("Error") Then
                        name = getDBsingle("select ename from kpa_sap_workflow where eid = " & searchid & " and ename is not null union all select distinct roname as ename from kpa_sap_workflow where ro =  " & searchid & " and roname is not null union all select distinct r1name as ename from kpa_sap_workflow where r1 =  " & searchid & " and r1name is not null union all select distinct r2name as ename from kpa_sap_workflow where r2 =  " & searchid & " and r2name is not null  union all select distinct r3name as ename from kpa_sap_workflow where r3 =  " & searchid & " and r3name is not null order by ename limit 1")
                        If name.Contains("Error") Then
                            ''search in workmen db
                            name = getDBsingle("select ename from kpa_sap_workflow where eid = " & searchid & " and ename is not null union all select distinct roname as ename from kpa_sap_workflow where ro =  " & searchid & " and roname is not null union all select distinct r1name as ename from kpa_sap_workflow where r1 =  " & searchid & " and r1name is not null union all select distinct r2name as ename from kpa_sap_workflow where r2 =  " & searchid & " and r2name is not null  union all select distinct r3name as ename from kpa_sap_workflow where r3 =  " & searchid & " and r3name is not null order by ename limit 1", "wsdb")
                            If name.Contains("Error") Then
                                name = "Name not in workflow"
                            End If
                        End If
                    End If

                    System.Web.HttpRuntime.Cache.Insert("ename" & searchid, name, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
                End If
                Return fromcache & System.Web.HttpRuntime.Cache("ename" & searchid)
            End If



        Catch ex As Exception
            Return "Error Name not in workflow" ' & ex.Message
        End Try



    End Function
    Public Shared Function getphonefromEid(ByVal searchid As String) As String

        Try
            If System.Web.HttpRuntime.Cache("pnameDT") Is Nothing Then

                Dim q = " select   distinct cast(empno as int) as eid, cellphone  from employee   "

                Dim mydt = getDBTable(q)

                System.Web.HttpRuntime.Cache.Insert("pnameDT", mydt, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
            End If
            Dim CachedDT = CType(System.Web.HttpRuntime.Cache("pnameDT"), System.Data.DataTable)
            Dim foundRows() As System.Data.DataRow
            foundRows = CachedDT.Select("eid = " & searchid.TrimStart("0") & "")
            If foundRows.Count > 0 Then
                Return foundRows(0)(1)
            Else
                Return "NA"

            End If

        Catch ex As Exception
            Return "Error phone not in workflow" ' & ex.Message
        End Try



    End Function
    Public Shared Function getEmailfromEid(ByVal searchid As String) As String

        Try
            If System.Web.HttpRuntime.Cache("enameDT") Is Nothing Then

                Dim q = " select   distinct cast(empno as int) as eid, email  from employee   "

                Dim mydt = getDBTable(q)

                System.Web.HttpRuntime.Cache.Insert("enameDT", mydt, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)
            End If
            Dim CachedDT = CType(System.Web.HttpRuntime.Cache("enameDT"), System.Data.DataTable)
            Dim foundRows() As System.Data.DataRow
            foundRows = CachedDT.Select("eid = " & searchid.TrimStart("0") & "")
            If foundRows.Count > 0 Then
                Return foundRows(0)(1)
            Else
                Return "NA"

            End If

        Catch ex As Exception
            Return "Error email not in workflow" ' & ex.Message
        End Try



    End Function

    Public Shared Function getCC(ByVal pageload As String) As String
        Return "<p>HTML5 | Cache Enabled | AJAX | Page creation Time:" & pageload.ToString & " ms | Design & Developed By: <b>CC-IT</b> </p>"
    End Function
    Public Shared Function getRating(ByVal rating As String) As String
        Try
            Dim r = Double.Parse(rating)
            If r >= 1 And r <= 1.3 Then : Return "1"
            ElseIf r >= 1.31 And r <= 1.5 Then : Return "2"
            ElseIf r >= 1.51 And r <= 2.5 Then : Return "3"
            ElseIf r >= 2.51 And r <= 3.5 Then : Return "4"
            ElseIf r >= 3.51 And r <= 5 Then : Return "5"
            End If

        Catch ex As Exception
            Return "0"
        End Try

    End Function
    Public Shared Function getRatingName(ByVal rating As String) As String
        Try
            Dim r = Double.Parse(rating)
            If r >= 1 And r <= 1.3 Then : Return "T1 (Outstanding)"
            ElseIf r >= 1.31 And r <= 1.5 Then : Return "T2 (Outstanding)"
            ElseIf r >= 1.51 And r <= 2.5 Then : Return "M1 (Very Good)"
            ElseIf r >= 2.51 And r <= 3.5 Then : Return "M2 (Good)"
            ElseIf r >= 3.51 And r <= 5 Then : Return "Bottom (Average)"
            Else : Return "NA"
            End If
        Catch ex As Exception
            Return "NA"
        End Try

    End Function
    Public Shared Function getRatingNameShort(ByVal rating As String) As String
        Try
            Dim r = Double.Parse(rating)
            If r >= 1 And r <= 1.3 Then : Return "T1"
            ElseIf r >= 1.31 And r <= 1.5 Then : Return "T2"
            ElseIf r >= 1.51 And r <= 2.5 Then : Return "M1"
            ElseIf r >= 2.51 And r <= 3.5 Then : Return "M2"
            ElseIf r >= 3.51 And r <= 5 Then : Return "Bottom"
            Else : Return "NA"
            End If
        Catch ex As Exception
            Return "NA"
        End Try

    End Function
    Public Shared Function getRatingNameWS(ByVal value As String) As String
        Try
            If value = "1" Then : Return "Outstanding"
            ElseIf value = "2" Then : Return "Very Good"
            ElseIf value = "3" Then : Return "Good"
            ElseIf value = "4" Then : Return "Satisfactory"
            ElseIf value = "5" Then : Return "Unsatisfactory"
            Else : Return "NA"
            End If
        Catch ex As Exception
            Return "NA"
        End Try

    End Function
    Public Shared Function getT1T2Status(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        ''Check if feature is enabled or not
        Dim f = getDBsingle("Select feature from feature where show = 1 And feature = 'T1T2Status'")
        If f.Contains("Error") Then
            Return "<<- This chart shows status of all the forms of your subordinates."
        End If

        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = " and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 1 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 1 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 1 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 1  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T1Total = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 2 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 2 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 2  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T2Total = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where     trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where   r1level > 2 and not r1level is null and  trim(r1level) <> ''  and r1 <> r2 and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level > 2 and  trim(r3level) <> '' and not r3level is null and r3 = " & eid & " and formid in (  " & formids & ")  )"
        '   q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and  trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level > 2 and not r1level is null and  trim(r1level) <> '' and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level > 2 and  trim(r3level) <> '' and not r3level is null  and r3 = " & eid & "  )"
        'Return q
        Dim M1Total = Int32.Parse(getDBsingle(q))
        Dim T1max = Math.Ceiling(totalforms * 15 / 100)
        Dim T2max = Math.Ceiling(totalforms * 15 / 100)
        Dim M1max = Math.Round(totalforms * 70 / 100)

        Dim T1perc = IIf(T1max = 0, 0, Math.Round(T1Total / T1max * 100))
        Dim T2perc = IIf(T2max = 0, 0, Math.Round(T2Total / T2max * 100))
        Dim M1perc = IIf(M1max = 0, 0, Math.Round(M1Total / M1max * 100))
        Return " <span>Top1 (15%) <br/>Permissible " & T1max & "</span><span class='pull-right'><small>Actual " & T1Total & " (" & T1perc & "%)</small></span>" &
"  <div class='progress mini'>  <div class='progress-bar progress-bar-info' style='width:" & T1perc & "%;'></div> </div>" &
               " <span>Top2 (15%) <br/>Permissible " & T2max & "</span><span class='pull-right'><small>" & "Actual " & T2Total & " (" & T2perc & "%)</small></span>" &
"   <div class='progress mini'> <div class='progress-bar progress-bar-success' style='width:" & T2perc & "%;'></div>" &
               " </div> <span>Very Good (70%) <br/>Permissible " & M1max & "</span><span class='pull-right'><small>" & "Actual " & M1Total & " (" & M1perc & "%)</small></span>" &
"  <div class='progress mini'><div class='progress-bar progress-bar-warning' style='width:" & M1perc & "%;'></div></div>" &
"<span>Total: " & totalforms & " | Assessment Completed: " & T1Total + T2Total + M1Total & " | Balance: " & totalforms - (T1Total + T2Total + M1Total) & "</span>"


    End Function
    Public Shared Function getT1T2StatusW(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        ''Check if feature is enabled or not
        Dim f = getDBsingle("select feature from feature where show = 1 and feature = 'wT1T2Status'")
        If f.Contains("Error") Then
            Return "<<- This chart shows status of all the forms of your subordinates."
        End If

        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = "" ' " and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q, "wsdb"))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 1 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 1 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 1 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 1  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T1Total = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 2 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 2 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 2  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T2Total = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where     trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where   r1level > 2 and not r1level is null and  trim(r1level) <> ''  and r1 <> r2 and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level > 2 and  trim(r3level) <> '' and not r3level is null and r3 = " & eid & " and formid in (  " & formids & ")  )"
        '   q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and  trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level > 2 and not r1level is null and  trim(r1level) <> '' and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level > 2 and  trim(r3level) <> '' and not r3level is null  and r3 = " & eid & "  )"
        'Return q
        Dim M1Total = Int32.Parse(getDBsingle(q))
        Dim T1max = Math.Ceiling(totalforms * 15 / 100)
        Dim T2max = Math.Ceiling(totalforms * 15 / 100)
        Dim M1max = Math.Round(totalforms * 70 / 100)

        Dim T1perc = IIf(T1max = 0, 0, Math.Round(T1Total / T1max * 100))
        Dim T2perc = IIf(T2max = 0, 0, Math.Round(T2Total / T2max * 100))
        Dim M1perc = IIf(M1max = 0, 0, Math.Round(M1Total / M1max * 100))
        Return " <span>Top1 (15%) <br/>Permissible " & T1max & "</span><span class='pull-right'><small>Actual " & T1Total & " (" & T1perc & "%)</small></span>" &
"  <div class='progress mini'>  <div class='progress-bar progress-bar-info' style='width:" & T1perc & "%;'></div> </div>" &
               " <span>Top2 (15%) <br/>Permissible " & T2max & "</span><span class='pull-right'><small>" & "Actual " & T2Total & " (" & T2perc & "%)</small></span>" &
"   <div class='progress mini'> <div class='progress-bar progress-bar-success' style='width:" & T2perc & "%;'></div>" &
               " </div> <span>Very Good (70%) <br/>Permissible " & M1max & "</span><span class='pull-right'><small>" & "Actual " & M1Total & " (" & M1perc & "%)</small></span>" &
"  <div class='progress mini'><div class='progress-bar progress-bar-warning' style='width:" & M1perc & "%;'></div></div>" &
"<span>Total: " & totalforms & " | Assessment Completed: " & T1Total + T2Total + M1Total & " | Balance: " & totalforms - (T1Total + T2Total + M1Total) & "</span>"


    End Function
    Public Shared Function getT1T2StatusTable(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        ''Check if feature is enabled or not
        'Dim f = getDBsingle("select feature from feature where show = 1 and feature = 'T1T2Status'")
        'If f.Contains("Error") Then
        '    Return "<<- This chart shows status of all the forms of your subordinates."
        'End If

        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = " and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 1 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 1 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 1 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 1  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T1Total = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 2 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 2 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 2  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T2Total = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where     trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where   r1level > 2 and not r1level is null and  trim(r1level) <> ''  and r1 <> r2 and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level > 2 and  trim(r3level) <> '' and not r3level is null and r3 = " & eid & " and formid in (  " & formids & ")  )"
        '   q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and  trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level > 2 and not r1level is null and  trim(r1level) <> '' and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level > 2 and  trim(r3level) <> '' and not r3level is null  and r3 = " & eid & "  )"
        'Return q
        Dim M1Total = Int32.Parse(getDBsingle(q))
        Dim T1max = Math.Ceiling(totalforms * 15 / 100)
        Dim T2max = Math.Ceiling(totalforms * 15 / 100)
        Dim M1max = Math.Round(totalforms * 70 / 100)

        Dim T1perc = IIf(T1max = 0, 0, Math.Round(T1Total / T1max * 100))
        Dim T2perc = IIf(T2max = 0, 0, Math.Round(T2Total / T2max * 100))
        Dim M1perc = IIf(M1max = 0, 0, Math.Round(M1Total / M1max * 100))
        Dim table = "<table class='mytable' style=' border-collapse: collapse; border-width:2px; width: 100%;'><tbody><th rowspan='3'>Normalization Summary</th><th>Group Size</th><th colspan='2'>Top1 (15%)</th><th colspan='2'>Top2 (15%)</th><th colspan='2'>Very Good (70%)</th>" &
        "<tr><td>-</td><td>Perm.</td><td>Act</td><td>Perm.</td><td>Act</td><td>Perm.</td><td>Act</td></tr>" &
        "<tr><td>" & totalforms & "</td><td>" & T1max & "</td><td>" & T1Total & " (" & T1perc & "%)</td><td>" & T2max & "</td><td> " & T2Total & " (" & T2perc & "%)</td><td>" & M1max & "</td><td>" & M1Total & " (" & M1perc & "%)</td></tr>" &
        "<tr ><td colspan='8'>No of Forms not recieved  | Assessment Completed: " & T1Total + T2Total + M1Total & " | Balance: " & totalforms - (T1Total + T2Total + M1Total) & "</td></tr>" &
        "</tbody></table>"
        Return table


    End Function
    Public Shared Function getT1T2StatusTableW(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        'Check if feature is enabled or not
        Dim f = getDBsingle("select feature from feature where show = 1 and feature = 'wT1T2Status'")
        If f.Contains("Error") Then
            Return "<<- This chart shows status of all the forms of your subordinates."
        End If

        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = "" '" and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q, "wsdb"))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 1 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 1 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 1 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 1  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T1Total = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where   rolevel = 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where    r1level = 2 and r1 <> r2  and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level = 2 and r2 <> r3  and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level = 2  and r3 = " & eid & " and formid in (  " & formids & ")  )"
        Dim T2Total = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(rolevel) as l from kpa_forms where     trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & " and formid in (  " & formids & ")  union select count(r1level) as l from kpa_forms where   r1level > 2 and not r1level is null and  trim(r1level) <> ''  and r1 <> r2 and r1 = " & eid & " and formid in (  " & formids & ") union select count(r2level) as l from kpa_forms where    r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & " and formid in (  " & formids & ")  union   select count(r3level) as l from kpa_forms where    r3level > 2 and  trim(r3level) <> '' and not r3level is null and r3 = " & eid & " and formid in (  " & formids & ")  )"
        '   q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and  trim(rolevel) <> '' and not rolevel is null and rolevel > 2 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level > 2 and not r1level is null and  trim(r1level) <> '' and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level > 2 and  trim(r2level) <> '' and  not r2level is null  and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level > 2 and  trim(r3level) <> '' and not r3level is null  and r3 = " & eid & "  )"
        'Return q
        Dim M1Total = Int32.Parse(getDBsingle(q, "wsdb"))
        Dim T1max = Math.Ceiling(totalforms * 15 / 100)
        Dim T2max = Math.Ceiling(totalforms * 15 / 100)
        Dim M1max = Math.Round(totalforms * 70 / 100)

        Dim T1perc = IIf(T1max = 0, 0, Math.Round(T1Total / T1max * 100))
        Dim T2perc = IIf(T2max = 0, 0, Math.Round(T2Total / T2max * 100))
        Dim M1perc = IIf(M1max = 0, 0, Math.Round(M1Total / M1max * 100))
        Dim table = "<table class='mytable' style=' border-collapse: collapse; border-width:2px; width: 100%;'><tbody><th rowspan='3'>Normalization Summary</th><th>Group Size</th><th colspan='2'>Top1 (15%)</th><th colspan='2'>Top2 (15%)</th><th colspan='2'>Very Good (70%)</th>" &
        "<tr><td>-</td><td>Perm.</td><td>Act</td><td>Perm.</td><td>Act</td><td>Perm.</td><td>Act</td></tr>" &
        "<tr><td>" & totalforms & "</td><td>" & T1max & "</td><td>" & T1Total & " (" & T1perc & "%)</td><td>" & T2max & "</td><td> " & T2Total & " (" & T2perc & "%)</td><td>" & M1max & "</td><td>" & M1Total & " (" & M1perc & "%)</td></tr>" &
        "<tr ><td colspan='8'>No of Forms not recieved  | Assessment Completed: " & T1Total + T2Total + M1Total & " | Balance: " & totalforms - (T1Total + T2Total + M1Total) & "</td></tr>" &
        "</tbody></table>"
        Return table


    End Function
    Public Shared Function getPieChart(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = " and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%emp%' and formid in (  " & formids & ")    )"
        Dim withEmp = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%ro%' and formid in (  " & formids & ")    )"
        Dim withRO = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r1%' and formid in (  " & formids & ")    )"
        Dim withR1 = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r2%' and formid in (  " & formids & ")    )"
        Dim withR2 = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r3%' and formid in (  " & formids & ")    )"
        Dim withR3 = Int32.Parse(getDBsingle(q))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%completed%' and formid in (  " & formids & ")    )"
        Dim completed = Int32.Parse(getDBsingle(q))

        Return " <div class='doughnutSummary'>Total <br/> <div class='count'>" & totalforms & "</div></div> " & "<div class='pieID pie'></div> " &
    "<ul class='pieID legend'>" &
        "<li><em>With Emp</em><span>" & withEmp & "</span></li>" &
         "<li><em>With RO</em><span>" & withRO & "</span></li>" &
          "<li><em>With R1</em><span>" & withR1 & "</span></li>" &
           "<li><em>With Dir</em><span>" & withR2 & "</span></li>" &
            "<li><em>With CMD</em><span>" & withR3 & "</span></li>" &
              "<li><em>Completed</em><span>" & completed & "</span></li>" &
    "</ul>"

    End Function
    Public Shared Function getPieChartW(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal shid As String = "%", Optional ByVal hr As String = "%") As String
        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim clusterFilter = "" '" and r2 like '" & shid & "' "
        Dim regionFilter = " and hr like '" & hr & "' "
        If hr = "Others" Then regionFilter = " and hr not in (select distinct hr from kpa_project where 1) "

        Dim formids = "select max(formid) as l from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "  and formyear= " & formyear & "  and ro = " & eid & " group by eid union select max(formid) as l  from kpa_forms where  del = 0  " & clusterFilter & regionFilter & "  and formyear=  " & formyear & " and  ro <> r1 and r1 =  " & eid & " group by eid   union select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r1 <> r2 and r2 =  " & eid & " group by eid union   select max(formid) as l  from kpa_forms where  del = 0 " & clusterFilter & regionFilter & "   and formyear=  " & formyear & " and  r2 <> r3  and  r3 = " & eid & " group by eid"
        'select count(formid) as l from kpa_forms where  del = 0 and  ro <> r1 and ro = " & eid & "  union select count(formid) as l from kpa_forms where  del = 0 and  r1 <> r2 and r1 =  " & eid & "    union select count(formid) as l from kpa_forms where  del = 0 and  r2 <> r3 and r2 =  " & eid & "   union   select count(formid) as l from kpa_forms where  del = 0 and  r3 =  " & eid & "  
        Dim q = "select count(l) from (" & formids & ")"
        Dim totalforms = Int32.Parse(getDBsingle(q, "wsdb"))
        '    q = "select sum(l) from (select count(rolevel) as l from kpa_forms where  del = 0 and rolevel = 1 and ro <> r1 and ro = " & eid & "  union select count(r1level) as l from kpa_forms where  del = 0 and  r1level = 1 and r1 <> r2 and r1 = " & eid & "  union select count(r2level) as l from kpa_forms where  del = 0 and  r2level = 1 and r2 <> r3 and r2 = " & eid & "  union   select count(r3level) as l from kpa_forms where  del = 0 and   r3level = 1 and r3 = " & eid & "  )"
        'q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%emp%' and formid in (  " & formids & ")    )"
        'Dim withEmp = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%ro%' and formid in (  " & formids & ")    )"
        Dim withRO = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r1%' and formid in (  " & formids & ")    )"
        Dim withR1 = Int32.Parse(getDBsingle(q, "wsdb"))
        'q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r2%' and formid in (  " & formids & ")    )"
        'Dim withR2 = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%r3%' and formid in (  " & formids & ")    )"
        Dim withR3 = Int32.Parse(getDBsingle(q, "wsdb"))
        q = "select sum(l) from (select count(formid) as l from kpa_forms where   formstatus like '%completed%' and formid in (  " & formids & ")    )"
        Dim completed = Int32.Parse(getDBsingle(q, "wsdb"))

        Return " <div class='doughnutSummary'>Total <br/> <div class='count'>" & totalforms & "</div></div> " & "<div class='pieID pie'></div> " &
    "<ul class='pieID legend'>" &
         "<li><em>With RO</em><span>" & withRO & "</span></li>" &
          "<li><em>With R1</em><span>" & withR1 & "</span></li>" &
            "<li><em>With HOD</em><span>" & withR3 & "</span></li>" &
              "<li><em>Completed</em><span>" & completed & "</span></li>" &
    "</ul>"

    End Function
    Public Shared Function getHindiName(ByVal eid As String) As String
        Dim hindiname = getDBsingle("select fhindi || ' ' || lhindi from emphindi where eid = " & eid, "wsdb")
        If hindiname.Contains("Error") Then Return ""
        If System.Text.RegularExpressions.Regex.IsMatch(hindiname, "\d") Then Return ""
        If String.IsNullOrEmpty(hindiname) Then Return ""
        Return hindiname
    End Function
    Public Shared Function getPieChartPACE(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal excludeseperated As Boolean = False, Optional mydb As String = "vindb") As String
        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim xcludeseperated = ""
        If excludeseperated Then xcludeseperated = " and seperated is null "

        Dim regionlist = "select hr from kpa_hr where eid = " & eid
        Dim region = getDBsingle("select hr from kpa_project where project in (select hr from kpa_hr where eid = " & eid & " and not (admin = 1 or admin = 2) limit 1)", mydb)
        If Not region.Contains("Error") Then
            regionlist = "'" & region & "'"
        End If


        Dim q = "Select count(formid) from kpa_forms where del = 0 and formyear = " & formyear & " And hr in (" & regionlist & " ) " & xcludeseperated
        Dim totalforms = Int32.Parse(getDBsingle(q, mydb))
        '    q = "Select sum(l) from (Select count(rolevel) As l from kpa_forms where  del = 0 And rolevel = 1 And ro <> r1 And ro = " & eid & "  union Select count(r1level) As l from kpa_forms where  del = 0 And  r1level = 1 And r1 <> r2 And r1 = " & eid & "  union Select count(r2level) As l from kpa_forms where  del = 0 And  r2level = 1 And r2 <> r3 And r2 = " & eid & "  union   Select count(r3level) As l from kpa_forms where  del = 0 And   r3level = 1 And r3 = " & eid & "  )"
        q = "Select count(formid) from kpa_forms where   del= 0 and formyear = " & formyear & " And   formstatus Like 'plan_emp_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withEmpPlan = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where   del= 0 and formyear = " & formyear & " and   formstatus like 'plan_ro_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withROPlan = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and   formstatus like 'plan_completed' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim plancompl = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and   formstatus like 'final_emp_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withEmp = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and  formstatus like 'final_ro_edit' and hr in  (" & regionlist & " ) " & xcludeseperated
        Dim withRO = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and   formstatus like 'final_r1_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withR1 = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where   del= 0 and formyear = " & formyear & " and   formstatus like 'final_r2_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withR2 = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where   del= 0 and formyear = " & formyear & " and formstatus like 'final_r3_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withR3 = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and formstatus like 'final_completed' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim completed = Int32.Parse(getDBsingle(q, mydb))

        Return " <div class='doughnutSummary'>Total <br/> <div class='count'>" & totalforms & "</div></div> " & "<div class='pieID pie'></div> " &
    "<ul class='pieID legend' >" &
        "<li style='width:200px'><em>Planning - With Employee</em><span>" & withEmpPlan & "</span></li>" &
         "<li style='width:200px'><em>Planning - With RO</em><span>" & withROPlan & "</span></li>" &
          "<li style='width:200px'><em>Planning - Accepted</em><span>" & plancompl & "</span></li>" &
           "<li style='width:180px'><em>Final - With Employee</em><span>" & withEmp & "</span></li>" &
            "<li style='width:200px'><em>Final - With Reporting Authority</em><span>" & withRO & "</span></li>" &
              "<li style='width:200px'><em>Final - With Reviewing Authority</em><span>" & withR1 & "</span></li>" &
                "<li style='width:200px'><em>Final - With Concerned Director</em><span>" & withR2 & "</span></li>" &
                  "<li style='width:210px'><em>Final - With Accepting Authority</em><span>" & withR3 & "</span></li>" &
                    "<li style='width:200px'><em>Final - Completed</em><span>" & completed & "</span></li>" &
    "</ul>"

    End Function
    Public Shared Function getPieChartPACEWS(ByVal eid As String, Optional ByVal formyear As String = "2016", Optional ByVal excludeseperated As Boolean = False, Optional mydb As String = "vindb") As String
        '' Get how many T1 and T2 given in current year
        'select max(formid),eid, 'RO' as r from kpa_forms where  del = 0 and formyear= 2016 and  ro <> r1 and ro = 40314 group by eid union select max(formid), eid , 'R1' as r from kpa_forms where  del = 0 and formyear= 2016 and  r1 <> r2 and r1 =  40314 group by eid   union select max(formid), eid, 'R2' as r from kpa_forms where  del = 0 and formyear= 2016 and  r2 <> r3 and r2 =  40314 group by eid union   select max(formid), eid , 'R3' as r from kpa_forms where  del = 0 and formyear= 2016  and  r3 = 40314 group by eid
        ''' Get the latestform ids where eid is RO or R1 or R2 or R3 ### if having multiple forms and old forms completed then it will not be considered in calculation untill merging and replicating forms is done
        Dim xcludeseperated = ""
        If excludeseperated Then xcludeseperated = " and seperated is null "

        Dim regionlist = getDBSinglecommaSepearated("select hr from kpa_hr where eid = " & eid)
        Dim region = getDBsingle("select hr from kpa_project where project in (select hr from kpa_hr where eid = " & eid & " and not (admin = 1 or admin = 2) limit 1)")
        If Not region.Contains("Error") Then
            regionlist = "'" & region & "'"
        End If


        Dim q = "Select count(formid) from kpa_forms where del = 0 and formyear = " & formyear & " And hr in (" & regionlist & " ) " & xcludeseperated
        Dim totalforms = Int32.Parse(getDBsingle(q, mydb))
        '    q = "Select sum(l) from (Select count(rolevel) As l from kpa_forms where  del = 0 And rolevel = 1 And ro <> r1 And ro = " & eid & "  union Select count(r1level) As l from kpa_forms where  del = 0 And  r1level = 1 And r1 <> r2 And r1 = " & eid & "  union Select count(r2level) As l from kpa_forms where  del = 0 And  r2level = 1 And r2 <> r3 And r2 = " & eid & "  union   Select count(r3level) As l from kpa_forms where  del = 0 And   r3level = 1 And r3 = " & eid & "  )"
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and   formstatus like 'final_ro_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withRO = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and   formstatus like 'final_r1_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withR1 = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where   del= 0 and formyear = " & formyear & " and   formstatus like 'final_r3_edit' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim withR3 = Int32.Parse(getDBsingle(q, mydb))
        q = "select count(formid) from kpa_forms where  del= 0 and  formyear = " & formyear & " and formstatus like 'final_completed' and hr in (" & regionlist & " ) " & xcludeseperated
        Dim completed = Int32.Parse(getDBsingle(q, mydb))

        Return " <div class='doughnutSummary'>Total <br/> <div class='count'>" & totalforms & "</div></div> " & "<div class='pieID pie'></div> " &
    "<ul class='pieID legend' >" &
            "<li style='width:200px'><em>Final - With Reporting Authority</em><span>" & withRO & "</span></li>" &
              "<li style='width:200px'><em>Final - With Reviewing Authority</em><span>" & withR1 & "</span></li>" &
                  "<li style='width:210px'><em>Final - With Accepting Authority</em><span>" & withR3 & "</span></li>" &
                    "<li style='width:200px'><em>Final - Completed</em><span>" & completed & "</span></li>" &
    "</ul>"

    End Function
    Public Shared Function getAllLinkedFormIDWithStatus(ByVal formid As String, Optional ByVal mydb As String = "vindb") As DataTable
        Return getDBTable("select formid, formstatus from kpa_forms where del = 0 and formyear = (select formyear from kpa_forms where formid = " & formid & ") and eid = (select eid from kpa_forms where formid = " & formid & ") ", mydb)

    End Function
    Public Shared Function ConvertDataTableToHTML(dt As DataTable, Optional ByVal start As Integer = 1) As String
        Dim html As String = "" '"<table>"
        ''add header row
        'html += "<tr>"
        'For i As Integer = 0 To dt.Columns.Count - 1
        '    html += "<td>" + dt.Columns(i).ColumnName + "</td>"
        'Next
        'html += "</tr>"
        'add rows
        For Each r In dt.Rows
            r(0) = start
            start = start + 1
        Next

        For i As Integer = 0 To dt.Rows.Count - 1
            html += "<tr>"
            For j As Integer = 0 To dt.Columns.Count - 1
                'html += "<td  class='tg-small'>" + dt.Rows(i)(j).ToString() + "</td>"
                html += "<td  style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;'>" + dt.Rows(i)(j).ToString() + "</td>"
            Next
            html += "</tr>"
        Next
        html += "" '</table>
        Return html
    End Function
    Public Shared Function removeDuplicate(ByVal s As String) As String
        Dim sp() As String = s.Split(" ")
        Dim al As New ArrayList()
        For Each sx As String In sp
            If (Not al.Contains(sx)) Then
                al.Add(sx)
            End If
        Next
        Dim dupRemoved() As String = al.ToArray(GetType(String))
        Return String.Join(" ", dupRemoved)
    End Function
    Public Shared Function CleanHtml(ByVal html As String) As String
        '' Cleans all manner of evils from the rich text editors in IE, Firefox, Word, and Excel
        '' Only returns acceptable HTML, and converts line breaks to <br />
        '' Acceptable HTML includes HTML-encoded entities.
        html = html.Replace("&" & "nbsp;", " ").Trim() ' concat here due to SO formatting
        '' Does this have HTML tags?
        If html.IndexOf("<") >= 0 Then
            '' Make all tags lowercase
            html = Regex.Replace(html, "<[^>]+>", AddressOf LowerTag)
            '' Filter out anything except allowed tags
            '' Problem: this strips attributes, including href from a
            '' 
            Dim AcceptableTags As String = "i|b|u|sup|sub|ol|ul|li|br|h2|h3|h4|h5|span|div|p|a|img|blockquote"
            Dim WhiteListPattern As String = "</?(?(?=" & AcceptableTags & ")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:([""']?).*?\1?)?)*\s*/?>"
            html = Regex.Replace(html, WhiteListPattern, "", RegexOptions.Compiled)
            '' Make all BR/br tags look the same, and trim them of whitespace before/after
            html = Regex.Replace(html, "\s*<br[^>]*>\s*", "<br />", RegexOptions.Compiled)
        End If
        '' No CRs
        html = html.Replace(ControlChars.Cr, "")
        '' Convert remaining LFs to line breaks
        html = html.Replace(ControlChars.Lf, "<br />")
        '' Trim BRs at the end of any string, and spaces on either side
        Return Regex.Replace(html, "(<br />)+$", "", RegexOptions.Compiled).Trim()
    End Function

    Public Shared Function LowerTag(m As Match) As String
        Return m.ToString().ToLower()
    End Function
    Public Shared Function GetDateInDDMMYY(ByVal dt As String) As String
        '1/30/2015 
        Try
            If Not dt.Contains("/") Then
                Return dt
            End If
            Dim str(3) As String
            str = dt.Split("/")
            Dim tempdt As String = String.Empty
            'For i As Integer = 2 To 0 Step -1
            tempdt = str(1).PadLeft(2, "0") + "." + str(0).PadLeft(2, "0") + "." + str(2)
            'Next
            tempdt = tempdt.Substring(0, 10)
            Return tempdt
        Catch ex As Exception
            Return dt
        End Try

    End Function
    Public Shared Function SendEmail(ByVal mailfrom As String, ByVal mailto As String, ByVal cc As String, ByVal bcc As String, ByVal subject As String, ByVal message As String, Optional ByVal attach1 As String = "", Optional ByVal attach2 As String = "", Optional ByVal userid As String = "", Optional ByVal pwd As String = "") As String
        Try
            'If Not mailto.Contains("ntpc.co.in") Then
            '    Return " Fail Non NTPC mail"
            'End If
            'create the mail message
            pwd = "Bifpccc23"
            Dim mail As New MailMessage()

            'set the addresses
            mail.IsBodyHtml = True
            mail.From = New MailAddress(mailfrom)
            mail.To.Add(mailto)
            mail.CC.Add(cc)
            'mail.Bcc.Add(bcc)
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<br/>" & message & "<br/>", Nothing, "text/html")
            'create the LinkedResource (embedded image)
            'Dim path As String = HttpContext.Current.Server.MapPath("~/DPR/")
            'Dim fileNameWitPath As String = path + Now.ToString("dd.MM.yy") + ".png"
            'If System.IO.File.Exists(fileNameWitPath) Then
            '    Dim logo As New LinkedResource(fileNameWitPath)
            '    logo.ContentId = "nw"
            '    'add the LinkedResource to the appropriate view
            '    htmlView.LinkedResources.Add(logo)
            'End If
            'set the content
            mail.Subject = subject
            ' mail.Body = message
            mail.AlternateViews.Add(htmlView)

            'add an attachment from the filesystem
            If Not String.IsNullOrEmpty(attach1) Then mail.Attachments.Add(New Attachment(attach1))

            'to add additional attachments, simply call .Add(...) again
            '  mail.Attachments.Add(New Attachment(attach2))
            ' mail.Attachments.Add(New Attachment("c:\temp\example3.txt"))

            'send the message
            '        Dim mailClient As SmtpClient = New SmtpClient("in.mailjet.com", "587") With {
            '    .Credentials = New NetworkCredential(userid, pwd),
            '    .EnableSsl = True
            '}
            Dim mailClient As SmtpClient = New SmtpClient("smtp.gmail.com", "587") With {
        .Credentials = New NetworkCredential(userid, pwd),
        .EnableSsl = True
    }
            ' Dim mailClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient("in.mailjet.com", "587")

            'This object stores the authentication values
            '  Dim basicCredential As System.Net.NetworkCredential = New System.Net.NetworkCredential(userid, pwd)
            'SMTP gateway IPs 10.1.10.72 or 10.1.10.73 for mail flow out side ntpc or 10.1.8.119
            'If mailto.Contains("ntpc.co.in") Or mailto.Contains("NTPC.CO.IN") Then
            '    mailClient.Host = "10.1.10.73"
            'Else
            '    mailClient.Host = "10.1.10.73"
            'End If

            'mailClient.UseDefaultCredentials = False
            'mailClient.Credentials = basicCredential
            mailClient.Send(mail)
            Return "ok"
        Catch exp As Exception

            Return "Error: " & exp.Message
        End Try

    End Function
    Public Shared Function getReportStatus(ByVal formyear As String, ByVal mode As String, Optional ByVal excludeseperated As Boolean = False) As DataTable
        Dim xcludeseperated = ""
        If excludeseperated Then xcludeseperated = " and seperated is null "
        If mode = "planning" Then

            Dim rodt = getDBTable("select hr as Region, count(ro) as 'Planning with RO' from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and formstatus  like 'plan_ro_edit' and hr in (select distinct hr from kpa_project where 1) group by hr")
            Dim mydt = getDBTable("select h as Region, ifnull(s,0) || ' / ' || ifnull(t,0) as 'Planning Done Emp/Total' , (ifnull(s,0) * 100 / cast(ifnull(t,1) as decimal)) || '%' as Progress from (select count(formid) as t, hr as h from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and hr in (select distinct hr from kpa_project where 1) group by hr)  d LEFT OUTER JOIN (select count(formid) as s, hr from kpa_forms where del= 0 and   formyear = " & formyear & xcludeseperated & " and (formstatus like '%final%' or formstatus like 'plan_ro_edit' or formstatus like 'plan_completed') and hr in (select distinct hr from kpa_project where 1) group by hr) e on d.h = e.hr")
            rodt.PrimaryKey = New System.Data.DataColumn() {rodt.Columns(0)}
            mydt.PrimaryKey = New System.Data.DataColumn() {mydt.Columns(0)}
            mydt.Merge(rodt)
            Return mydt
        ElseIf mode = "final" Then

            Dim rodt = getDBTable("select hr as Region, count(ro) as 'Final with RO/R1' from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and (formstatus  like 'final_ro_edit' or formstatus  like 'final_r1_edit'  ) and hr in (select distinct hr from kpa_project where 1) group by hr")
            Dim mydt = getDBTable("select h as Region, ifnull(s,0) || ' / ' || ifnull(t,0) as 'Done/Total' , (ifnull(s,0) * 100 / cast(ifnull(t,1) as decimal)) || '%' as Progress from (select count(formid) as t, hr as h from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and hr in (select distinct hr from kpa_project where 1) group by hr)  d LEFT OUTER JOIN (select count(formid) as s, hr from kpa_forms where del= 0 and   formyear = " & formyear & xcludeseperated & " and (formstatus like 'final_ro_edit' or formstatus  like 'final_r1_edit'  or formstatus  like 'final_r2_edit'  or formstatus  like 'final_r3_edit' or formstatus like 'final_completed') and hr in (select distinct hr from kpa_project where 1) group by hr) e on d.h = e.hr")
            rodt.PrimaryKey = New System.Data.DataColumn() {rodt.Columns(0)}
            mydt.PrimaryKey = New System.Data.DataColumn() {mydt.Columns(0)}
            mydt.Merge(rodt)
            Return mydt
        ElseIf mode = "WS" Then
            Dim regions = getDBSinglecommaSepearated("select distinct hr from kpa_project where 1")
            Dim rodt = getDBTable("select hr as Region, count(ro) as 'Final with R1/HOD' from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and (formstatus  like 'final_r3_edit' or formstatus  like 'final_r1_edit'  ) and hr in (" & regions & ") group by hr", "wsdb")
            Dim mydt = getDBTable("select h as Region, ifnull(s,0) || ' / ' || ifnull(t,0) as 'Done/Total' , (ifnull(s,0) * 100 / cast(ifnull(t,1) as decimal)) || '%' as Progress from (select count(formid) as t, hr as h from kpa_forms where  del= 0 and  formyear = " & formyear & xcludeseperated & " and hr in (" & regions & ") group by hr)  d LEFT OUTER JOIN (select count(formid) as s, hr from kpa_forms where del= 0 and    formyear = " & formyear & xcludeseperated & " and ( formstatus  like 'final_r1_edit'  or  formstatus  like 'final_r3_edit' or formstatus like 'final_completed') and hr in (" & regions & ") group by hr) e on d.h = e.hr", "wsdb")
            rodt.PrimaryKey = New System.Data.DataColumn() {rodt.Columns(0)}
            mydt.PrimaryKey = New System.Data.DataColumn() {mydt.Columns(0)}
            mydt.Merge(rodt)
            Return mydt
        End If

    End Function
    Public Shared Function JustSendSMS(ByVal mobileNumbersseperatedbycomma As String, ByVal msg As String) As String

        'Multiple mobiles numbers separated by comma
        Dim mobileNumber As String = mobileNumbersseperatedbycomma
        'Your message to send, Add URL encoding here.
        Dim message As String = HttpUtility.UrlEncode(msg)

        'Prepare you post parameters
        Dim sbPostData As New StringBuilder()
        sbPostData.AppendFormat("locid={0}", "001000")
        sbPostData.AppendFormat("&msg={0}", message)
        sbPostData.AppendFormat("&num={0}", mobileNumber)


        Try
            'Call Send SMS API
            'Dim sendSMSUri As String = "https://control.msg91.com/api/sendhttp.php"
            'http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender?locid=001000&msg=SMS_MSG&num=9650990024
            Dim sendSMSUri As String = "http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender"
            'Create HTTPWebrequest
            Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            Dim httpWReq As HttpWebRequest = DirectCast(WebRequest.Create(sendSMSUri), HttpWebRequest)
            'httpWReq.Headers.Clear()
            'httpWReq.AllowAutoRedirect = True
            'httpWReq.Timeout = 1000 * 2
            'httpWReq.PreAuthenticate = True
            httpWReq.Credentials = CredentialCache.DefaultCredentials
            'httpWReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)"
            'httpWReq.Timeout = 150000
            '  httpWReq.Proxy = proxyObject
            'Prepare and Add URL Encoded data
            Dim encoding As New UTF8Encoding()
            Dim data As Byte() = encoding.GetBytes(sbPostData.ToString())
            'Specify post method
            httpWReq.Method = "POST"
            httpWReq.ContentType = "application/x-www-form-urlencoded"
            httpWReq.ContentLength = data.Length
            Using stream As Stream = httpWReq.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
            'Get the response
            Dim response As HttpWebResponse = DirectCast(httpWReq.GetResponse(), HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim responseString As String = reader.ReadToEnd()

            'Close the response
            reader.Close()
            response.Close()
            'Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender"), HttpWebRequest)
            ''Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            ''request.Proxy = proxyObject
            'request.Method = "POST"
            'request.ContentType = "application/x-www-form-urlencoded"
            'Dim postData As String = "locid=001000&msg=" && "&num=9650990024"
            'Dim bytes As Byte() = Encoding.UTF8.GetBytes(postData)
            'request.ContentLength = bytes.Length

            'Dim requestStream As Stream = request.GetRequestStream()
            'requestStream.Write(bytes, 0, bytes.Length)
            ''End Using
            'Dim response As WebResponse = request.GetResponse()
            'Dim stream As Stream = response.GetResponseStream()
            'Dim reader As New StreamReader(stream)

            'Dim result = reader.ReadToEnd()
            ''  reader.Close()

            'stream.Dispose()
            'reader.Dispose()
            Return "Success"
        Catch ex As Exception
            Return "Error:" & ex.Message.ToString()
        End Try
    End Function
    Public Shared Function JustSendSMSBIFPCL(ByVal mobileNumbersseperatedbycomma As String, ByVal msg As String, Optional ByVal request_type As String = "GENERAL_CAMPAIGN") As String

        'Multiple mobiles numbers separated by comma
        Dim mobileNumber As String = mobileNumbersseperatedbycomma
        'Your message to send, Add URL encoding here.
        Dim message As String = HttpUtility.UrlEncode(msg)

        'Prepare you post parameters
        Dim sbPostData As New StringBuilder()
       'sbPostData.AppendFormat("&to={0}", mobileNumber)
        'sbPostData.AppendFormat("&text={0}", msg)


        Try
            'Call Send SMS API
            'Dim sendSMSUri As String = "https://control.msg91.com/api/sendhttp.php"
            'https://api.infobip.com/sms/1/text/query?username=myUsername&password=myPassword&to=41793026727&text=Message text
            'http://esms.zubairitexpert.com/smsapi?api_key=C20020335b87c8ab5abe68.34733659&type=text&contacts=01678582832&senderid=BIFPCL&msg=Hi it is a test messgae to check the otp 9874 that's it
            ' Dim sendSMSUri As String = "http://esms.zubairitexpert.com/smsapi?api_key=C20020335b87c8ab5abe68.34733659&type=text&senderid=BIFPCL&contacts=" & mobileNumber & "&msg=" & msg
            'Create HTTPWebrequest
            ' Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            Dim sendSMSUri As String = "https://www.bifpcl.com/sms.aspx?mobile=" & mobileNumber & "&message_body=" & HttpUtility.UrlEncode(msg) & "&request_type=" & request_type

            Dim httpWReq As HttpWebRequest = DirectCast(WebRequest.Create(sendSMSUri), HttpWebRequest)
            'httpWReq.Headers.Clear()
            'httpWReq.AllowAutoRedirect = True
            'httpWReq.Timeout = 1000 * 2
            'httpWReq.PreAuthenticate = True
            httpWReq.Credentials = CredentialCache.DefaultCredentials
            'httpWReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)"
            'httpWReq.Timeout = 150000
            '  httpWReq.Proxy = proxyObject
            'Prepare and Add URL Encoded data
            Dim encoding As New UTF8Encoding()
            Dim data As Byte() = encoding.GetBytes(sbPostData.ToString())
            'Specify post method
            httpWReq.Method = "POST"
            httpWReq.ContentType = "application/x-www-form-urlencoded"
            httpWReq.ContentLength = data.Length
            Using stream As Stream = httpWReq.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
            'Get the response
            Dim response As HttpWebResponse = DirectCast(httpWReq.GetResponse(), HttpWebResponse)
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim responseString As String = reader.ReadToEnd()

            'Close the response
            reader.Close()
            response.Close()
            'Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://ers.ntpc.co.in:8080/ntpcd/URL2_Sender"), HttpWebRequest)
            ''Dim proxyObject As WebProxy = New WebProxy("http://10.0.236.36:8080")
            ''request.Proxy = proxyObject
            'request.Method = "POST"
            'request.ContentType = "application/x-www-form-urlencoded"
            'Dim postData As String = "locid=001000&msg=" && "&num=9650990024"
            'Dim bytes As Byte() = Encoding.UTF8.GetBytes(postData)
            'request.ContentLength = bytes.Length

            'Dim requestStream As Stream = request.GetRequestStream()
            'requestStream.Write(bytes, 0, bytes.Length)
            ''End Using
            'Dim response As WebResponse = request.GetResponse()
            'Dim stream As Stream = response.GetResponseStream()
            'Dim reader As New StreamReader(stream)

            'Dim result = reader.ReadToEnd()
            ''  reader.Close()

            'stream.Dispose()
            'reader.Dispose()
            Dim i = responseString.IndexOf("api_response_message")
            Dim result = i.ToString
            If i <> -1 Then
                i += 20
                result = responseString.Substring(i, 15)

            End If
            'Label1.Text = result & i '& words(i + 1)
            Return result '"Success"
        Catch ex As Exception
            Return "Error:" & ex.Message.ToString()
        End Try
    End Function
    Public Shared Function getPrintPagesFeedback(ByVal pagenumber As String, ByVal formid As String, ByVal showmarks As String) As String
        Dim lock = "uu6BOAp3FqdtLu+sVWFRAg=="

        Dim q = ""
        Dim q2 = ""
        Dim pageCSS = "<page style='background: white;  display: block;  margin: 0 auto;  margin-bottom: 1cm; margin-top: 1cm;  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);    border-width: 6px; border-style: double; border-color: darkblue; width: 25cm; height: 37cm; '>"

        Try
            ''RELOAD VALUES
            q = "select formyear, formid, formstatus,  eid, ro,r1,r3, hr, a1,a2, strftime('%d/%m/%Y', b1), b2, b3,  c1, c2,strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, desig, project, strftime('%d.%m.%Y',gradedt) as gradedt,   strftime('%d.%m.%Y',date(gradedt, '+364 day')) as gradeend  from kpa_feedback  where  del = 0 and  formid =" & formid
            Dim a1, a2, c1, c2, grade, desig, desig_dt, end_dt, dept, hr, formyear, formstatus, eid, ro, r1, r3, emp_dt, ro_dt, r1_dt, r3_dt, b1, b2, b3, project As String
            Dim mydt = getDBTable(q)
            Dim r = mydt.Rows(0) 'get 1st row
            '  dob = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(0).ToString), "", r(0)))
            Dim yr = IIf(String.IsNullOrEmpty(r(0).ToString), "", r(0))
            formyear = Int32.Parse(yr).ToString & "-" & Right((Int32.Parse(yr) + 1).ToString, 2)
            formid = IIf(String.IsNullOrEmpty(r(1).ToString), "", r(1))
            formstatus = IIf(String.IsNullOrEmpty(r(2).ToString), "", r(2))
            eid = IIf(String.IsNullOrEmpty(r(3).ToString), "", r(3))
            ro = IIf(String.IsNullOrEmpty(r(4).ToString), "", r(4))
            r1 = IIf(String.IsNullOrEmpty(r(5).ToString), "", r(5))
            r3 = IIf(String.IsNullOrEmpty(r(6).ToString), "", r(6))
            hr = IIf(String.IsNullOrEmpty(r(7).ToString), "", r(7))
            a1 = IIf(String.IsNullOrEmpty(r(8).ToString), "", r(8))
            a2 = IIf(String.IsNullOrEmpty(r(9).ToString), "", r(9))
            b1 = IIf(String.IsNullOrEmpty(r(10).ToString), "", r(10))
            b2 = IIf(Convert.IsDBNull(r(11)), "", IIf(System.DBNull.Value Is r(11), "", Decrypt(r(11).ToString)))
            b3 = IIf(String.IsNullOrEmpty(r(12).ToString), "", r(12))
            c1 = IIf(Convert.IsDBNull(r(13)), "", IIf(System.DBNull.Value Is r(13), "", Decrypt(r(13).ToString)))
            c2 = IIf(String.IsNullOrEmpty(r(14).ToString), "", r(14))
            emp_dt = IIf(String.IsNullOrEmpty(r(15).ToString), "", r(15))
            ro_dt = IIf(String.IsNullOrEmpty(r(16).ToString), "", r(16))
            r1_dt = IIf(String.IsNullOrEmpty(r(17).ToString), "", r(17))
            r3_dt = IIf(String.IsNullOrEmpty(r(18).ToString), "", r(18))
            desig = IIf(String.IsNullOrEmpty(r(19).ToString), "", r(19))
            project = IIf(String.IsNullOrEmpty(r(20).ToString), "", r(20))
            grade = "E8"
            desig_dt = IIf(String.IsNullOrEmpty(r(21).ToString), "", r(21))
            end_dt = IIf(String.IsNullOrEmpty(r(22).ToString), "", r(22))

            If showmarks = "EMP" Then
                b2 = "X"
                b3 = "X"
                c1 = "X"
                c2 = "X"
            End If
            If showmarks = "RO" Then
                c1 = "X"
                c2 = "X"
            End If
            Dim topdiv = "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><h1></h1><img src='images/ntpc.png' style='margin-left:40px; margin-bottom:40px; width:100px; height:63px;' /> <div class='note'><span class='large_numbering'>" & pagenumber & "</span><u>Page</u> <br/> Form #" & formid & " <br/> Emp No: " & eid.PadLeft(6, "0") & " <br/><span style='font-size:9px'>" & desig_dt & " - " & end_dt & "</span></div>"
            Dim signDiv = "<div style='display:block;float:left; font-style: italic;    color: #777;'>This is system generated document. No signature Required. Printed on:" & Now & "</div>"


            If pagenumber = "1" Then
                'Return pageCSS
                Return pageCSS &
                "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>NTPC Limited</span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>(A Govt. of India Enterprise)</span> </p>" &
                "<br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US'>Performance Feedback </span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >OF</span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >General Manager</span> </p>" &
              "<br/><br/>" &
               "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >For the period from   " & desig_dt & " - " & end_dt & " </span> </p>" &
               "<br/><br/>" &
               "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section I - Basic information </p>" &
     "<table class='tableBIO' style=' margin-left: 36.0pt;'>" &
                  " <tr><td style='width460px;'><table><tr><td style='text-align:center; border:none; font-size:24px;'><b>Appraisal Year:</b></td><td style='text-align:center; border:none;  font-size:24px;'>" & formyear & "</td></tr> </table></td><td rowspan=3 style='border:none;'><img src=images/pics/" & eid.ToString.PadLeft(6, "0") & ".jpg border=4px align=middle height=120px width=100px onerror=" & Chr(34) & "this.src='images/user.jpg';" & Chr(34) & "/> </div></td></tr> " &
                   "<tr><td><table><tr><td style='text-align:center;  border:none;'><b>Period:</b></td><td style='text-align:center; border:none;'></td></tr> </table></td></tr> " &
                   "<br/><br/><br/><tr><td colspan='3' style='border:none;'><br/></td></tr> " &
                   "<tr><td><b> 1. Employee No:</b></td><td colspan='2'>" & eid.PadLeft(6, "0") & "<br/></td></tr> " &
                   "<tr><td><b> 2. Name</b></td><td colspan='3'>" & getnamefromEid(eid) & "<br/>" & getHindiName(eid) & "</td></tr> " &
                   "<tr><td><b> 3. (a)Name/Grade of the Post held:</b></td><td colspan='3'>" & grade & " / " & desig & "<br/></td></tr> " &
                   "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(b) Place of Posting:</b></td><td colspan='3'>" & project & "<br/></td></tr> " &
                   "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(c) Region</b></td><td colspan='3'>" & hr & "<br/></td></tr> " &
                   "<tr><td colspan='4' style='border:none;'><br/></td></tr> " &
                    "<tr><td><b>6. Reporting Structure</b></td><td><b>Emp No</b></td><td><b>Emp Name</b></td></tr> " &
                   "<tr><td>        &nbsp;&nbsp;&nbsp;&nbsp;<b>(a) Business Unit Head </b></td><td style='width:70px;'>" & ro & "</td><td>" & getnamefromEid(ro) & "<br/>" & getHindiName(ro) & "</td></tr> " &
                   "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(b) Regional Executive Director :</b></td><td>" & r1 & "</td><td>" & getnamefromEid(r1) & "<br/>" & getHindiName(r1) & "</td></tr> " &
                   "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(c) Accepting Authority(HR) :</b></td><td>" & r3 & "<td>" & getnamefromEid(r3) & "<br/>" & getHindiName(r3) & " " &
                  "   <tr>  <td colspan='4' style='border:none;'>      <b> GUIDELINES FOR USE " &
                " <tr>  <td colspan='4' style='border:none;'>           <br /> &nbsp;&nbsp;&nbsp;&nbsp;<b>1.	Responsibility for Assessment: Assessment for each employee will be done by the Business Unit Head and is to be reviewed by the Regional Executive Director<br /></b> <br /></td></tr> " &
                " <tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;2.	Where the employee has worked with more than one reporting person for more than 3 months, he will be assessed by all the reporting officers, in separate forms.<br /></b> <br /></td></tr> " &
               "<tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;3.	This is a system generated report.<br /></b> <br /></td></tr>" &
                            "   <tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;4.	For Correction in Data contact concerned PACE Officer.<br /></b> <br /></td></tr>" &
                                 "<tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbspConfidential: For Internal Use Only .<br /></b> <br /></td>                                     </tr>" &
                      "</table>" &
            "</table></div>" &
            "</page>"
            End If
            If pagenumber = "2" Then Return pageCSS & topdiv &
               "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & "<br/><br/>" & " <h3>OVERALL ASSESSMENT by Employee</h3>:" &
               "<p>1.	Please enumerate the major tasks assigned and completed; any exceptional contribution from the date of assuming the charge of GM. e.g. successful completion of an extraordinarily challenging task or major systemic improvement; innovative and creative measures; Safety practice adopted, efforts towards development of subordinates etc. (resulting in significant benefits to the Company and/or reduction in time and costs,)? If so, please give a brief description (Maximum 250 words):</p> <p class='blue-rectangle'> " & a1.Replace("<div>", "").Replace("</div>", "<br/>") & " </p> " &
                "<p>2.	What are the constraints/Roadblocks that hindered your performance (Maximum 150 words)? <p><p class='blue-rectangle'> " & a2 & " </p>" &
                 "<br/><div class='drop-shadow lifted'><p>: <br/>  " & getnamefromEid(eid) & " ,  <br/> <br/> Date:- " & emp_dt & "</p> </div><br/><br/>" & signDiv &
              "</div></page>"
            If pagenumber = "3" Then Return pageCSS & topdiv &
               "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & "<br/><br/>" & " <h3>OVERALL ASSESSMENT by Business Unit Head</h3>:" &
               "<p>1. Performance discussion held on-: </p><p class='blue-rectangle'> " & b1 & "</p>" &
                "<p> 2.	Rating Scale-: (1 to 5) One being the least and Five being the Best) </p><p class='blue-rectangle'> " & b2 & "</p>" &
                  "<p>3.	Observation of BUH on Performance and Achievements (Maximum 250 words)</p><p class='blue-rectangle'> " & b3 & "</p>" &
                "<br/><div class='drop-shadow lifted'><p>Business Unit Head: <br/>  " & getnamefromEid(ro) & " ,  <br/> <br/> Date:- " & ro_dt & "</p> </div><br/><br/>" & signDiv &
              "</div></page>"
            If pagenumber = "4" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & "<br/><br/>" & " <h3>OVERALL ASSESSMENT by Regional Executive Director</h3>:" &
                "<p> 1.	Rating Scale-: (1 to 5) One being the least and Five being the Best) </p><p class='blue-rectangle'> " & c1 & "</p>" &
                  "<p>2.	Observation of RED on Performance and Achievements (Maximum 250 words)</p><p class='blue-rectangle'> " & c2 & "</p>" &
              "<br/><div class='drop-shadow lifted'><p>Regional Executive Director: <br/>  " & getnamefromEid(r1) & " ,  <br/> <br/> Date:- " & r1_dt & "</p> </div><br/><br/>" & signDiv &
                 "<br/><div class='drop-shadow lifted'><p>Acceptance by HR: <br/>  " & getnamefromEid(r3) & " ,  <br/> <br/> Date:- " & r3_dt & "</p> </div><br/><br/>" & signDiv &
               "</div></page>"
        Catch ex As Exception

            Return ex.Message
        End Try
    End Function
    Public Shared Function getPrintPagesWorkmen(ByVal pagenumber As String, ByVal formid As String, ByVal showmarks As String) As String
        Dim lock = "uu6BOAp3FqdtLu+sVWFRAg=="

        Dim q = ""
        Dim q2 = ""
        Try
            ''RELOAD VALUES
            q = "select c1, c2, c3, c4, c5, c6 ,c7, c8, c9 ,c10, c11, c12, c13, c14, c15, c16 ,c17, c18, ro1,ro2,ro3,ro3a,ro3b,ro3c from kpa_desc where formid =" & formid

            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, total_ro , total_r1,total_r2, total_r3,  cat, r3c from kpa_forms  where  formid= " & formid
            ' Return q2
            Dim pageCSS = "<page style='background: white;  display: block;  margin: 0 auto;  margin-bottom: 1cm; margin-top: 1cm;  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);    border-width: 6px; border-style: double; border-color: darkblue; width: 25cm; height: 37cm; '>"
            Dim pageCSSLandscape = "<page style='background: white;  display: block;  margin: 0 auto;  margin-bottom: 1cm; margin-top: 1cm;  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);    border-width: 6px; border-style: double; border-color: darkblue; width: 37cm; height: 25cm; '>"

            If pagenumber = "0" Then Return pageCSS & "<img src='images/frontcover.jpg' width=100% height=100% /></page>"
            Dim a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, ro1, ro2, ro3, ro3a, ro3b, ro3c, r3c, dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr, formyear, period, eid, ro, r1, r2, r3, emp_dt, ro_dt, r1_dt, r2_dt, r3_dt As String
            Dim mydt = getDBTable(q2, "wsdb")
            Dim r = mydt.Rows(0) 'get 1st row
            dob = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(0).ToString), "", r(0)))
            qual = IIf(String.IsNullOrEmpty(r(1).ToString), "", r(1))
            qual = removeDuplicate(qual)
            grade = IIf(String.IsNullOrEmpty(r(2).ToString), "", r(2))
            desig = IIf(String.IsNullOrEmpty(r(3).ToString), "", r(3))
            dept = IIf(String.IsNullOrEmpty(r(6).ToString), "", r(6))
            hr = IIf(String.IsNullOrEmpty(r(7).ToString), "", r(7))
            desig_dt = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(4).ToString), "", r(4)))
            ntpc_dt = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(5).ToString), "", r(5)))
            Dim yr = IIf(String.IsNullOrEmpty(r(8).ToString), "", r(8))
            formyear = Int32.Parse(yr).ToString & "-" & Right((Int32.Parse(yr) + 1).ToString, 2)
            period = IIf(String.IsNullOrEmpty(r(9).ToString), "", r(9))
            eid = IIf(String.IsNullOrEmpty(r(10).ToString), "", r(10))
            ro = IIf(String.IsNullOrEmpty(r(11).ToString), "", r(11))
            r1 = IIf(String.IsNullOrEmpty(r(12).ToString), "", r(12))
            r2 = IIf(String.IsNullOrEmpty(r(13).ToString), "", r(13))
            r3 = IIf(String.IsNullOrEmpty(r(14).ToString), "", r(14))
            emp_dt = IIf(String.IsNullOrEmpty(r(15).ToString), "", r(15))
            ro_dt = IIf(String.IsNullOrEmpty(r(16).ToString), "", r(16))
            r1_dt = IIf(String.IsNullOrEmpty(r(17).ToString), "", r(17))
            r2_dt = IIf(String.IsNullOrEmpty(r(18).ToString), "", r(18))
            r3_dt = IIf(String.IsNullOrEmpty(r(19).ToString), "", r(19))
            '   kpa_emp, kpa_emp_actual, kpa_ro, kpa_ro_actual, comp_ro, total_ro, kpa_r1, comp_r1, total_r1, total_r2, total_r3, r3a, r3b, r3c
            Dim total_ro = IIf(Convert.IsDBNull(r("total_ro")), "", IIf(System.DBNull.Value Is r("total_ro"), "", Decrypt(r("total_ro").ToString)))
            Dim total_r1 = IIf(Convert.IsDBNull(r("total_r1")), "", IIf(System.DBNull.Value Is r("total_r1"), "", Decrypt(r("total_r1").ToString)))
            Dim total_r2 = IIf(Convert.IsDBNull(r("total_r2")), "", IIf(System.DBNull.Value Is r("total_r2"), "", Decrypt(r("total_r2").ToString)))
            Dim total_r3 = IIf(Convert.IsDBNull(r("total_r3")), "", IIf(System.DBNull.Value Is r("total_r3"), "", Decrypt(r("total_r3").ToString)))
            Dim cat = IIf(Convert.IsDBNull(r("cat")), "", r("cat"))
            r3c = IIf(Convert.IsDBNull(r("r3c")), "", IIf(System.DBNull.Value Is r("r3c"), "", Decrypt(r("r3c").ToString)))
            ' Dim cat = "" ' IIf(Convert.IsDBNull(r("cat")), "", r("cat"))
            If showmarks = "RO" Then
                total_r1 = "X"
                total_r2 = "X"
                total_r3 = "X"
                r3c = "X"
            End If
            If showmarks = "R1" Then
                total_r2 = "X"
                total_r3 = "X"
                r3c = "X"
            End If

            If pagenumber = "1" Then
                'Return pageCSS
                Return pageCSS &
                "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>NTPC Limited</span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>(A Govt. of India Enterprise)</span> </p>" &
                "<br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US'>ASSESSMENT REPORT </span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >OF</span> </p>" &
                "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >WORKMEN / SUPERVISOR </span> </p>" &
              "<br/><br/>" &
               "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section I - Basic information </p>" &
     "<table class='tableBIO' style=' margin-left: 36.0pt;'>" &
                  " <tr><td style='width460px;'><table><tr><td style='text-align:center; border:none; font-size:24px;'><b>Appraisal Year:</b></td><td style='text-align:center; border:none;  font-size:24px;'>" & formyear & "</td></tr> </table></td><td rowspan=3 style='border:none;'><img src=images/pics/" & eid.ToString.PadLeft(6, "0") & ".jpg border=4px align=middle height=120px width=100px onerror=" & Chr(34) & "this.src='images/user.jpg';" & Chr(34) & "/> </div></td></tr> " &
                   "<tr><td><table><tr><td style='text-align:center;  border:none;'><b>Period:</b></td><td style='text-align:center; border:none;'>" & period & "</td></tr> </table></td></tr> " &
                   "<br/><br/><br/><tr><td colspan='3' style='border:none;'><br/></td></tr> " &
                   "<tr><td><b> 1. Employee No:</b></td><td colspan='2'>" & eid.PadLeft(6, "0") & "<br/></td></tr> " &
                   "<tr><td><b> 2. Name</b></td><td colspan='3'>" & getnamefromEid(eid) & "<br/>" & getHindiName(eid) & "</td></tr> " &
                   "<tr><td><b> 3. Date of Birth:</b></td><td colspan='3'>" & dob & "<br/></tr> " &
                   "<tr><td><b> 4. Brief Academic & Professional Qualifications </b></td><td colspan='3'>" & qual & "<br/></td></tr> " &
                   "<tr><td><b> 5. (a)Name/Grade of the Post held:</b></td><td colspan='3'>" & grade & " / " & desig & "<br/></td></tr> " &
                   "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(b) Deptt</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td colspan='3'>" & dept & "<br/></td></tr> " &
                   "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(c) Place of Posting:</b></td><td colspan='3'>" & hr & "<br/></td></tr> " &
                   "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(d) Date of Continuous Appointment in this Post</b></td><td colspan='3'>" & desig_dt & "<br/></td></tr> " &
                 "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(e) Date of continuous Appointment in the same enterprise</b></td><td colspan='3'>" & ntpc_dt & "<br/></td></tr> " &
                   "<tr><td colspan='4' style='border:none;'><br/></td></tr> " &
                    "<tr><td><b>6. Reporting Structure</b></td><td><b>Emp No</b></td><td><b>Emp Name</b></td></tr> " &
                   "<tr><td>        &nbsp;&nbsp;&nbsp;&nbsp;<b>(a) Reporting Authority </b></td><td style='width:70px;'>" & ro & "</td><td>" & getnamefromEid(ro) & "<br/>" & getHindiName(ro) & "</td></tr> " &
                   "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(b) Reviewing Authority :</b></td><td>" & r1 & "</td><td>" & getnamefromEid(r1) & "<br/>" & getHindiName(r1) & "</td></tr> " &
                   "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(c) Accepting Authority :</b></td><td>" & r3 & "<td>" & getnamefromEid(r3) & "<br/>" & getHindiName(r3) & " " &
                  "   <tr>  <td colspan='4' style='border:none;'>      <b> GUIDELINES FOR USE " &
                " <tr>  <td colspan='4' style='border:none;'>           <br /> &nbsp;&nbsp;&nbsp;&nbsp;<b>1.	Responsibility for Assessment: Assessment for each employee will be done by the Reporting Person (to whom the employee reports) – the minimum level for which should not be less than an Executive and is to be reviewed by the Reviewing Officer (to whom the reporting person reports).  The report will further be reviewed by the Sectional Head in case he is not the Reviewing Officer, and counter signed by the HOD who may enter remarks if any.<br /></b> <br /></td></tr> " &
                " <tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;2.	Where the employee has worked with more than one reporting person for more than 3 months, he will be assessed by all the reporting officers, in separate forms.<br /></b> <br /></td></tr> " &
               "<tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;3.	The reporting officer should evaluate the attributes as corroborated by periodic records maintained and have sufficient evidence reflected during the entire period and not on isolated or recent incidents.<br /></b> <br /></td></tr>" &
                            "   <tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbsp;4.	Each attribute should be assessed independently, uninfluenced by the rating of other attributes.  Against attributes that are not applicable kindly write 'NA'.<br /></b> <br /></td></tr>" &
                                 "<tr>  <td colspan='4' style='border:none;'>   <b>  &nbsp;&nbsp;&nbsp;&nbspIt may be pointed out that the appraiser has the freedom not to evaluate an attribute for which he does not have sufficient data or which he does not consider relevant for the position of the appraise. .<br /></b> <br /></td>                                     </tr>" &
                      "</table>" &
            "</table></div>" &
            "</page>"
            End If
            Dim topdiv = "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><h1></h1><img src='images/ntpc.png' style='margin-left:40px; margin-bottom:40px; width:100px; height:63px;' /> <div class='note'><span class='large_numbering'>" & pagenumber & "</span><u>Page</u> <br/> Form #" & formid & " <br/> Emp No: " & eid.PadLeft(6, "0") & " <br/><span style='font-size:9px'>" & period & "</span></div>"

            mydt = getDBTable(q, "wsdb")
            If Not mydt.Rows.Count = 0 Then
                c1 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(0).ToString), "", getRatingNameWS(mydt.Rows(0)(0)))
                c2 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(1).ToString), "", getRatingNameWS(mydt.Rows(0)(1)))
                c3 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(2).ToString), "", getRatingNameWS(mydt.Rows(0)(2)))
                c4 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(3).ToString), "", getRatingNameWS(mydt.Rows(0)(3)))
                c5 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(4).ToString), "", getRatingNameWS(mydt.Rows(0)(4)))
                c6 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(5).ToString), "", getRatingNameWS(mydt.Rows(0)(5)))
                c7 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(6).ToString), "", getRatingNameWS(mydt.Rows(0)(6)))
                c8 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(7).ToString), "", getRatingNameWS(mydt.Rows(0)(7)))
                c9 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(8).ToString), "", getRatingNameWS(mydt.Rows(0)(8)))
                c10 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(9).ToString), "", getRatingNameWS(mydt.Rows(0)(9)))
                c11 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(10).ToString), "", getRatingNameWS(mydt.Rows(0)(10)))
                c12 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(11).ToString), "", getRatingNameWS(mydt.Rows(0)(11)))
                c13 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(12).ToString), "", getRatingNameWS(mydt.Rows(0)(12)))
                c14 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(13).ToString), "", getRatingNameWS(mydt.Rows(0)(13)))
                c15 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(14).ToString), "", getRatingNameWS(mydt.Rows(0)(14)))
                c16 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(15).ToString), "", getRatingNameWS(mydt.Rows(0)(15)))
                c17 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(16).ToString), "", getRatingNameWS(mydt.Rows(0)(16)))
                c18 = IIf(String.IsNullOrEmpty(mydt.Rows(0)(17).ToString), "", getRatingNameWS(mydt.Rows(0)(17)))
                ro1 = mydt.Rows(0)(18).ToString
                ro2 = mydt.Rows(0)(19).ToString
                ro3 = mydt.Rows(0)(20).ToString
                ro3a = mydt.Rows(0)(21).ToString
                ro3b = mydt.Rows(0)(22).ToString
                ro3c = mydt.Rows(0)(23).ToString


            End If

            mydt = getDBTable("select id, attrib, a1, a2 ,a3 ,a4 ,a5 from kpa_attrib where type = '" & cat & "' order by id asc", "wsdb")
            For Each r In mydt.Rows

                If r(0) = 1 Then a1 = "<h3>" & r(0) & " " & r(1) & ": " & c1 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 2 Then a2 = "<h3>" & r(0) & " " & r(1) & ": " & c2 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 3 Then a3 = "<h3>" & r(0) & " " & r(1) & ": " & c3 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 4 Then a4 = "<h3>" & r(0) & " " & r(1) & ": " & c4 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 5 Then a5 = "<h3>" & r(0) & " " & r(1) & ": " & c5 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 6 Then a6 = "<h3>" & r(0) & " " & r(1) & ": " & c6 & "</h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 7 Then a7 = "<h3>" & r(0) & " " & r(1) & ": " & c7 & " </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 8 Then a8 = "<h3>" & r(0) & " " & r(1) & ":  " & c8 & " </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 9 Then a9 = "<h3>" & r(0) & " " & r(1) & ": " & c9 & " </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 10 Then a10 = "<h3>" & r(0) & " " & r(1) & ": " & c10 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 11 Then a11 = "<h3>" & r(0) & " " & r(1) & ": " & c11 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 12 Then a12 = "<h3>" & r(0) & " " & r(1) & ": " & c12 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 13 Then a13 = "<h3>" & r(0) & " " & r(1) & ": " & c13 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 14 Then a14 = "<h3>" & r(0) & " " & r(1) & ": " & c14 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 15 Then a15 = "<h3>" & r(0) & " " & r(1) & ": " & c15 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 16 Then a16 = "<h3>" & r(0) & " " & r(1) & ": " & c16 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 17 Then a17 = "<h3>" & r(0) & " " & r(1) & ": " & c17 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
                If r(0) = 18 Then a18 = "<h3>" & r(0) & " " & r(1) & ": " & c18 & "  </h3>         <p class='blue-rectangle'><b>Outstanding</b> - " & r(2) & "      <br /> <b>Very Good</b>  - " & r(3) & "  <br /> <b>Good</b> - " & r(4) & "    <br /> <b>Satisfactory</b> - " & r(5) & "        <br /> <b>Unsatisfactory</b> - " & r(6) & "</p><br /> "
            Next
            Dim signDiv = "<div style='display:block;float:left; font-style: italic;    color: #777;'>This is system generated document. No signature Required. Printed on:" & Now & "</div>"

            If pagenumber = "2" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2.     RATING SCALE : Attributes  " & a1 & "<br/>" & a2 & "<br/>" & a3 & "<br/>" & a4 & "<br/>" & a5 &
               "</div></page>"
            If pagenumber = "3" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & a6 & "<br/>" & a7 & "<br/>" & a8 & "<br/>" & a9 & "<br/>" & a10 &
               "</div></page>"
            If pagenumber = "4" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >" & a11 & "<br/>" & a12 & "<br/>" & a13 & "<br/>" & a14 & "<br/>" & a15 &
               "</div></page>"
            If pagenumber = "5" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & a16 & "<br/>" & a17 & "<br/>" & a18 & "<br/><br/>" & "<h3>Overall Rating by Reporting Officer</h3>: " & getRatingNameWS(total_ro) &
               "</div></page>"
            If ro3 = "0" Then ro3a = "NA"
            If pagenumber = "6" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & "<br/><br/>" & " <h3>OVERALL ASSESSMENT by Reporting Officer</h3>: <p class='blue-rectangle'> " & getRatingNameWS(total_ro) & "</p>" &
                "<h3>Details of Rcommendations & awards and special remarks, if any.</h3><p class='blue-rectangle'> " & ro1 & "</p>" &
                 "<h3> Training & Career Development (To be filled by the Reporting Officer):</h3><br/>i)	Keeping in view his/her (a) Present assignment, (b) capabilities and (c) future development needs, do you feel that the employee should be given a rotational assignment within or outside the section/department or an additional skill? <br/>If yes, give details of the rotational assignment/additional skill,a.	With reference to his present assignment b.	With reference to his future development needs:<p class='blue-rectangle'> " & ro3a & "</p>" &
                   "<br/>ii)	Please mention the identified training and capability building needs of the Supervisor:<p class='blue-rectangle'> " & ro3b & "</p>" &
                     "<br/>iii) Approximate month when these recommendations should take effect:<p class='blue-rectangle'> " & ro3c & "</p>" &
                "<br/><div class='drop-shadow lifted'><p>Reporting Officer: <br/>  " & getnamefromEid(ro) & " ,  <br/> <br/> Date:- " & ro_dt & "</p> </div><br/><br/>" & signDiv &
               "</div></page>"
            If pagenumber = "7" Then Return pageCSS & topdiv &
                "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' > " & "<br/><br/>" & " <h3>OVERALL ASSESSMENT by Reviewing Officer:</h3> <p class='blue-rectangle'> " & getRatingNameWS(total_r1) & "</p>" &
                "<br/><div class='drop-shadow lifted'><p>Reviewing Officer: <br/>  " & getnamefromEid(r1) & " ,  <br/> <br/> Date:- " & r1_dt & "</p> </div>" &
                 "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>" & " <h3>OVERALL ASSESSMENT by Head of Department:</h3> <p class='blue-rectangle'> " & getRatingNameWS(total_r3) & "</p>" &
                   "<br/><br/><br/>Comments of the HOD:<p class='blue-rectangle'> " & r3c & "</p>" &
                "<br/><div class='drop-shadow lifted'><p>Head of Department: <br/>  " & getnamefromEid(r3) & " ,  <br/> <br/> Date:- " & r3_dt & "</p> </div><br/><br/>" & signDiv &
               "</div></page>"
        Catch ex As Exception

            Return ex.Message
        End Try
    End Function
    Public Shared Function getPrintPages(ByVal pagenumber As String, ByVal formid As String, ByVal showmarks As String) As String
        Dim lock = "uu6BOAp3FqdtLu+sVWFRAg=="

        Dim q = ""
        Dim q2 = ""
        Dim kpaQRO = "select kindex, desc,measure,  wtg, act_ach,  act_ro, total_ro" ''dont show to emp only

        If showmarks = "R3" Then
            q = "select b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1,a2,a3,a4,a5, d1,d2,d3,d4,d5,d6, c1, c2, c3, c4, c5, c6 ,c7, c8, c9 ,c10, c_act_ro, c_total_ro, ro1, ro2, ro3, ro4, ro5, ro8, ro8d, ro9, r1a, r1b, r1c, r1d, r2a from kpa_desc  where  formid=" & formid
            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, kpa_emp,kpa_emp_actual, kpa_ro,kpa_ro_actual, comp_ro,total_ro ,kpa_r1, comp_r1, total_r1,total_r2, total_r3, r3a , r3b, r3c from kpa_forms  where  formid=" & formid
        ElseIf showmarks = "R2" Then
            q = "select b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1,a2,a3,a4,a5, d1,d2,d3,d4,d5,d6, c1, c2, c3, c4, c5, c6 ,c7, c8, c9 ,c10, c_act_ro, c_total_ro, ro1, ro2, ro3, ro4, ro5, ro8, ro8d, ro9, r1a, r1b, r1c, r1d, r2a from kpa_desc  where  formid=" & formid
            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, kpa_emp,kpa_emp_actual,  kpa_ro,  kpa_ro_actual,  comp_ro,  total_ro , kpa_r1,   comp_r1,   total_r1,  total_r2,  '" & lock & "' as total_r3, '" & lock & "' as r3a ,  '" & lock & "' as r3b,  '" & lock & "' as r3c from kpa_forms  where  formid=" & formid
        ElseIf showmarks = "R1" Then
            q = "select b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1,a2,a3,a4,a5, d1,d2,d3,d4,d5,d6, c1, c2, c3, c4, c5, c6 ,c7, c8, c9 ,c10, c_act_ro, c_total_ro, ro1, ro2, ro3, ro4, ro5, ro8, ro8d, ro9, r1a, r1b, r1c, r1d, 'X' as r2a from kpa_desc  where  formid=" & formid
            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, kpa_emp,kpa_emp_actual,  kpa_ro,  kpa_ro_actual, comp_ro,  total_ro , kpa_r1,   comp_r1,   total_r1, '" & lock & "' as total_r2,  '" & lock & "' as total_r3,  '" & lock & "' as r3a ,  '" & lock & "' as r3b,  '" & lock & "' as r3c from kpa_forms  where  formid=" & formid
        ElseIf showmarks = "RO" Then
            q = "select b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1,a2,a3,a4,a5, d1,d2,d3,d4,d5,d6, c1, c2, c3, c4, c5, c6 ,c7, c8, c9 ,c10, c_act_ro, c_total_ro, ro1, ro2, ro3, ro4, ro5, ro8, ro8d, ro9, 'X' as r1a, 'X' as r1b, 'X' as r1c, 'X' as r1d, 'X' as r2a from kpa_desc  where  formid=" & formid
            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, kpa_emp,kpa_emp_actual,  kpa_ro,  kpa_ro_actual, comp_ro,  total_ro , '" & lock & "' as kpa_r1,  '" & lock & "' as comp_r1,  '" & lock & "' as total_r1, '" & lock & "' as total_r2,  '" & lock & "' as total_r3, '" & lock & "' as r3a ,  '" & lock & "' as r3b,  '" & lock & "' as r3c from kpa_forms  where  formid=" & formid
        Else
            q = "select b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1,a2,a3,a4,a5, d1,d2,d3,d4,d5,d6, 'X' as c1, 'X' as c2, 'X' as c3, 'X' as c4, 'X' as c5, 'X' as c6 ,'X' as c7, 'X' as c8, 'X' as c9 ,'X' as c10, 'X' as c_act_ro, 'X' as c_total_ro, 'X' as ro1, 'X' as ro2, 'X' as ro3, 'X' as ro4, 'X' as ro5, 'X' as ro8, 'X' as ro8d, 'X' as ro9, 'X' as r1a, 'X' as r1b, 'X' as r1c, 'X' as r1d, 'X' as r2a from kpa_desc  where  formid=" & formid
            q2 = "select dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr || ' / ' || project, formyear, strftime('%d.%m.%Y',st_dt) || ' to ' || strftime('%d.%m.%Y',end_dt) , eid, ro, r1, r2, r3, strftime('%d.%m.%Y',emp_dt) as emp_dt, strftime('%d.%m.%Y',ro_dt) as ro_dt, strftime('%d.%m.%Y',r1_dt) as r1_dt, strftime('%d.%m.%Y',r2_dt) as r2_dt, strftime('%d.%m.%Y',r3_dt) as r3_dt, kpa_emp,kpa_emp_actual, '" & lock & "' as kpa_ro, '" & lock & "' as kpa_ro_actual,  '" & lock & "' as comp_ro, '" & lock & "' as total_ro , '" & lock & "' as kpa_r1,  '" & lock & "' as comp_r1,  '" & lock & "' as total_r1, '" & lock & "' as total_r2,  '" & lock & "' as total_r3,  '" & lock & "' as r3a ,  '" & lock & "' as r3b,  '" & lock & "' as r3c from kpa_forms  where  formid=" & formid
            kpaQRO = "select kindex, desc,measure,  wtg, act_ach, '' as act_ro,'' as total_ro" ''dont show ro marks
        End If

        Dim mydt = getDBTable(q)

        Dim b5a, b5b, b5c, b5d, b5e, b5f, b8, b9a, b9b, a1, a2, a3, a4, a5, d1, d2, d3, d4, d5, d6, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c_act_ro, c_total_ro, ro1, ro2, ro3, ro4, ro5, ro8, ro8d, ro9, r1a, r1b, r1c, r1d, r2a, dob, qual, grade, desig, desig_dt, ntpc_dt, dept, hr, formyear, period, eid, ro, r1, r2, r3, emp_dt, ro_dt, r1_dt, r2_dt, r3_dt As String
        Dim r = mydt.Rows(0) 'get 1st row
        b5a = IIf(String.IsNullOrEmpty(r(0).ToString), "", r(0))
        b5b = IIf(String.IsNullOrEmpty(r(1).ToString), "", r(1))
        b5c = IIf(String.IsNullOrEmpty(r(2).ToString), "", r(2))
        b5d = IIf(String.IsNullOrEmpty(r(3).ToString), "", r(3))
        b5e = IIf(String.IsNullOrEmpty(r(4).ToString), "", r(4))
        b5f = IIf(String.IsNullOrEmpty(r(5).ToString), "", r(5))
        b8 = IIf(String.IsNullOrEmpty(r(6).ToString), "", r(6))
        b9a = IIf(String.IsNullOrEmpty(r(7).ToString), "", r(7))
        b9b = IIf(String.IsNullOrEmpty(r(8).ToString), "", r(8))

        a1 = IIf(String.IsNullOrEmpty(r(9).ToString), "", r(9))
        a2 = IIf(String.IsNullOrEmpty(r(10).ToString), "", r(10))
        a3 = IIf(String.IsNullOrEmpty(r(11).ToString), "", r(11))
        a4 = IIf(String.IsNullOrEmpty(r(12).ToString), "", r(12))
        a5 = IIf(String.IsNullOrEmpty(r(13).ToString), "", r(13))

        d1 = IIf(String.IsNullOrEmpty(r(14).ToString), "", r(14))
        d2 = IIf(String.IsNullOrEmpty(r(15).ToString), "", r(15))
        d3 = IIf(String.IsNullOrEmpty(r(16).ToString), "", r(16))
        d4 = IIf(String.IsNullOrEmpty(r(17).ToString), "", r(17))
        d5 = IIf(String.IsNullOrEmpty(r(18).ToString), "", r(18))
        d6 = IIf(String.IsNullOrEmpty(r(19).ToString), "", r(19))

        c1 = IIf(String.IsNullOrEmpty(r(20).ToString), "", r(20))
        c2 = IIf(String.IsNullOrEmpty(r(21).ToString), "", r(21))
        c3 = IIf(String.IsNullOrEmpty(r(22).ToString), "", r(22))
        c4 = IIf(String.IsNullOrEmpty(r(23).ToString), "", r(23))
        c5 = IIf(String.IsNullOrEmpty(r(24).ToString), "", r(24))
        c6 = IIf(String.IsNullOrEmpty(r(25).ToString), "", r(25))
        c7 = IIf(String.IsNullOrEmpty(r(26).ToString), "", r(26))
        c8 = IIf(String.IsNullOrEmpty(r(27).ToString), "", r(27))
        c9 = IIf(String.IsNullOrEmpty(r(28).ToString), "", r(28))
        c10 = IIf(String.IsNullOrEmpty(r(29).ToString), "", r(29))
        c_act_ro = IIf(String.IsNullOrEmpty(r(30).ToString), "", r(30))
        c_total_ro = IIf(String.IsNullOrEmpty(r(31).ToString), "", r(31))

        ro1 = IIf(String.IsNullOrEmpty(r(32).ToString), "", r(32))
        ro2 = IIf(String.IsNullOrEmpty(r(33).ToString), "", r(33))
        ro3 = IIf(String.IsNullOrEmpty(r(34).ToString), "", r(34))
        ro4 = IIf(String.IsNullOrEmpty(r(35).ToString), "", r(35))
        ro5 = IIf(String.IsNullOrEmpty(r(36).ToString), "", r(36))
        ro8 = IIf(String.IsNullOrEmpty(r(37).ToString), "", r(37))
        ro8d = IIf(String.IsNullOrEmpty(r(38).ToString), "", r(38))
        ro9 = IIf(String.IsNullOrEmpty(r(39).ToString), "", r(39))

        r1a = IIf(String.IsNullOrEmpty(r(40).ToString), "Yes", r(40))
        r1b = IIf(String.IsNullOrEmpty(r(41).ToString), "Yes", r(41))
        r1c = IIf(String.IsNullOrEmpty(r(42).ToString), "No Comments", r(42))
        r1d = IIf(String.IsNullOrEmpty(r(43).ToString), "No Comments", r(43))
        r2a = IIf(String.IsNullOrEmpty(r(44).ToString), "No Comments", r(44))
        '''Create print preview
        Dim pageCSS = "<page style='background: white;  display: block;  margin: 0 auto;  margin-bottom: 1cm; margin-top: 1cm;  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);    border-width: 6px; border-style: double; border-color: darkblue; width: 25cm; height: 37cm; '>"
        Dim pageCSSLandscape = "<page style='background: white;  display: block;  margin: 0 auto;  margin-bottom: 1cm; margin-top: 1cm;  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);    border-width: 6px; border-style: double; border-color: darkblue; width: 37cm; height: 25cm; '>"

        If pagenumber = "0" Then Return pageCSS & "<img src='images/frontcover.jpg' width=100% height=100% /></page>"

        mydt = getDBTable(q2)
        r = mydt.Rows(0) 'get 1st row
        dob = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(0).ToString), "", r(0)))
        qual = IIf(String.IsNullOrEmpty(r(1).ToString), "", r(1))
        qual = removeDuplicate(qual)
        grade = IIf(String.IsNullOrEmpty(r(2).ToString), "", r(2))
        desig = IIf(String.IsNullOrEmpty(r(3).ToString), "", r(3))
        dept = IIf(String.IsNullOrEmpty(r(6).ToString), "", r(6))
        hr = IIf(String.IsNullOrEmpty(r(7).ToString), "", r(7))
        desig_dt = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(4).ToString), "", r(4)))
        ntpc_dt = GetDateInDDMMYY(IIf(String.IsNullOrEmpty(r(5).ToString), "", r(5)))
        Dim yr = IIf(String.IsNullOrEmpty(r(8).ToString), "", r(8))
        formyear = Int32.Parse(yr).ToString & "-" & Right((Int32.Parse(yr) + 1).ToString, 2)
        period = IIf(String.IsNullOrEmpty(r(9).ToString), "", r(9))
        eid = IIf(String.IsNullOrEmpty(r(10).ToString), "", r(10))
        ro = IIf(String.IsNullOrEmpty(r(11).ToString), "", r(11))
        r1 = IIf(String.IsNullOrEmpty(r(12).ToString), "", r(12))
        r2 = IIf(String.IsNullOrEmpty(r(13).ToString), "", r(13))
        r3 = IIf(String.IsNullOrEmpty(r(14).ToString), "", r(14))
        q = "select cluster from cluster where shid = " & r2 & "  limit 1"
        Dim dirdesig = getDBsingle(q)
        If dirdesig.Contains("Error") Then dirdesig = "Concerned Director" '& q
        emp_dt = IIf(String.IsNullOrEmpty(r(15).ToString), "", r(15))
        ro_dt = IIf(String.IsNullOrEmpty(r(16).ToString), "", r(16))
        r1_dt = IIf(String.IsNullOrEmpty(r(17).ToString), "", r(17))
        r2_dt = IIf(String.IsNullOrEmpty(r(18).ToString), "", r(18))
        r3_dt = IIf(String.IsNullOrEmpty(r(19).ToString), "", r(19))
        'kpa_emp,kpa_emp_actual, kpa_ro,kpa_ro_actual, comp_ro,total_ro ,kpa_r1, comp_r1, total_r1,total_r2, total_r3, r3a , r3b, r3c
        Dim empKPATotal = Decrypt(IIf(String.IsNullOrEmpty(r("kpa_emp").ToString), "", r("kpa_emp")))
        Dim roKPATotal = Decrypt(IIf(String.IsNullOrEmpty(r("kpa_ro").ToString), "", r("kpa_ro")))
        Dim comp_ro = Decrypt(IIf(String.IsNullOrEmpty(r("comp_ro").ToString), "", r("comp_ro")))
        Dim total_ro = Decrypt(IIf(String.IsNullOrEmpty(r("total_ro").ToString), "", r("total_ro")))
        Dim total_r1 = Decrypt(IIf(String.IsNullOrEmpty(r("total_r1").ToString), "", r("total_r1")))
        Dim kpa_r1 = Decrypt(IIf(String.IsNullOrEmpty(r("comp_r1").ToString), "", r("kpa_r1")))
        Dim comp_r1 = Decrypt(IIf(String.IsNullOrEmpty(r("comp_r1").ToString), "", r("comp_r1")))
        Dim total_r2 = Decrypt(IIf(String.IsNullOrEmpty(r("total_r2").ToString), "", r("total_r2")))
        Dim total_r3 = Decrypt(IIf(String.IsNullOrEmpty(r("total_r3").ToString), "", r("total_r3")))
        Dim r3a = IIf(String.IsNullOrEmpty(r("r3a").ToString), "", r("r3a"))
        Dim r3b = IIf(String.IsNullOrEmpty(r("r3b").ToString), "", r("r3b"))
        Dim r3c = IIf(String.IsNullOrEmpty(r("r3c").ToString), "", r("r3c"))
        r3a = Decrypt(r3a)
        r3b = Decrypt(r3b)
        r3c = Decrypt(r3c)


        Dim empKPA = "<div class='drop-shadow lifted'><p>KPA Emp Total of Govt & Internal = " & empKPATotal & " </div> "
        Dim roKPA = "<div class='drop-shadow lifted'><p>KPA Emp Total of Govt & Internal = " & empKPATotal & " <br/>KPA RO Total of Govt & Internal = " & roKPATotal & " </div> "

        Dim kpaPerPage = 16
        Dim totalKPA = Convert.ToInt32(getDBsingle("select count(kindex)  from kpa  where   formid=" & formid & " "))
        Dim topdiv = "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><h1></h1><img src='images/ntpc.png' style='margin-left:40px; margin-bottom:40px; width:100px; height:63px;' /> <div class='note'><span class='large_numbering'>" & pagenumber & "</span><u>Page</u> <br/> Form #" & formid & " <br/> Emp No: " & eid.PadLeft(6, "0") & " <br/><span style='font-size:9px'>" & period & "</span></div>"
        Dim signDiv = "<div style='display:block;float:left; font-style: italic;    color: #777;'>This is system generated document. No signature Required. Printed on:" & Now & "</div>"

        If pagenumber = "1" Then

            Return pageCSS &
            "<div style='margin-left: 36.0pt;margin-right: 36.0pt; color: #000;	font-family: 'Open Sans';	font-size: 16px;	font-weight: 500;	line-height: 28px;	margin-bottom: 28px;'><br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>NTPC Limited</span> </p>" &
            "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' style='font-size:18.0pt'>(A Govt. of India Enterprise)</span> </p>" &
            "<br/><br/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US'>PERFORMANCE APPRAISAL REPORT</span> </p>" &
            "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >OF</span> </p>" &
            "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >EXECUTIVE DIRECTORS (E9)/ GENERAL MANAGERS (E8)</span> </p>" &
          "<br/><br/>" &
           "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 13.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >For the period from   " & period & "</span> </p>" &
           "<br/><br/>" &
           "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section I - Basic information </p>" &
 "<table class='tableBIO' style=' margin-left: 36.0pt;'>" &
              " <tr><td style='width460px;'><table><tr><td style='text-align:center; border:none; font-size:24px;'><b>Appraisal Year:</b></td><td style='text-align:center; border:none;  font-size:24px;'>" & formyear & "</td></tr> </table></td><td rowspan=3 style='border:none;'><img src=images/pics/" & eid.ToString.PadLeft(6, "0") & ".jpg border=4px align=middle height=120px width=100px onerror=" & Chr(34) & "this.src='images/user.jpg';" & Chr(34) & "/> </div></td></tr> " &
               "<tr><td><table><tr><td style='text-align:center;  border:none;'><b>Period:</b></td><td style='text-align:center; border:none;'>" & period & "</td></tr> </table></td></tr> " &
               "<br/><br/><br/><tr><td colspan='3' style='border:none;'><br/></td></tr> " &
               "<tr><td><b> 1. Employee No:</b></td><td colspan='2'>" & eid.PadLeft(6, "0") & "<br/></td></tr> " &
               "<tr><td><b> 2. Name</b></td><td colspan='3'>" & getnamefromEid(eid) & "<br/>" & getHindiName(eid) & "</td></tr> " &
               "<tr><td><b> 3. Date of Birth:</b></td><td colspan='3'>" & dob & "<br/></tr> " &
               "<tr><td><b> 4. Brief Academic & Professional Qualifications </b></td><td colspan='3'>" & qual & "<br/></td></tr> " &
               "<tr><td><b> 5. (a)Name/Grade of the Post held:</b></td><td colspan='3'>" & grade & " / " & desig & "<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(b) Deptt</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td colspan='3'>" & dept & "<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(c) Place of Posting:</b></td><td colspan='3'>" & hr & "<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(d) Date of Continuous Appointment in this Post</b></td><td colspan='3'>" & desig_dt & "<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(e) Present Pay and Scale of Pay:</b></td><td colspan='3'>" & b5e & "<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(f) Date of continuous Appointment in the same enterprise</b></td><td colspan='3'>" & ntpc_dt & "<br/></td></tr> " &
               "<tr><td><b> 6.&nbsp;(a) Date of First Public Enterprise Appointment:</b></td><td colspan='3'>NA<br/></td></tr> " &
               "<tr><td><b>  &nbsp;&nbsp;&nbsp;&nbsp;(b) Scale of Pay of the Post on First Appointment</b></td><td colspan='3'>NA<br/></td></tr> " &
               "<tr><td colspan='4' style='border:none;'><br/></td></tr> " &
                "<tr><td><b>7. Reporting Structure</b></td><td><b>Emp No</b></td><td><b>Emp Name</b></td></tr> " &
               "<tr><td>        &nbsp;&nbsp;&nbsp;&nbsp;<b>(a) Reporting Authority </b></td><td style='width:70px;'>" & ro & "</td><td>" & getnamefromEid(ro) & "<br/>" & getHindiName(ro) & "</td></tr> " &
               "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(b) Reviewing Authority :</b></td><td>" & r1 & "</td><td>" & getnamefromEid(r1) & "<br/>" & getHindiName(r1) & "</td></tr> " &
               "<tr><td>     &nbsp;&nbsp;&nbsp;&nbsp;<b>(c) Concerned Director</b>-For functional GM's like O&M, HR, Proj., Fin.,TS, IT, etc. :</td><td>-</td><td>" & dirdesig & "</td></tr> " &
               "<tr><td>    &nbsp;&nbsp;&nbsp;&nbsp;<b>(d) Accepting Authority :</b></td><td>-<td>CMD " &
               "            <tr><td colspan='4' style='border:none;'><br/></td></tr><tr></tr> " &
                "           <tr><td colspan='4' style='border:none;'><b> 8.Period Of absence On leave, etc. during the year:</b><table class='normalTable'><tr><td>SN</td><td>Details of Leave/Period/Remarks </td></tr><tr><td>1</td><td><b>" & b8 & "</b></td></tr></table></td></tr> " &
                 "</table>" &
        "</table></div>" &
        "</page>"
        End If

        If pagenumber = "2" Then Return pageCSS &
            topdiv &
             "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >9. Qualification acquired and Training programmes attended during the year: </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (a)  Details of Qualification acquired during the year: <div class='blue-rectangle'><table class='normalTable'><tr><td>SN</td><td>Details of Qualification/Institute/Subjects/Marks </td></tr><tr><td>1</td><td><b>" & b9a & "</b></td></tr></table></div></p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (b)  Details of Training programme attended during the year:<div class='blue-rectangle'><table class='normalTable'><tr><td>SN</td><td>Details of Training/Institute/Subject/Period </td></tr><tr><td>1</td><td><b>" & b9b & "</b></td></tr></table></div></p>" &
          "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >10. Awards/Honours received during the year: <p class='blue-rectangle'><b>" & a1 & "</b></p> </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >11. Number of officers for whom PAR was not written by the officer reported upon as Reporting/Reviewing Authority for the previous year (To be filled by Nodal Officer): <p class='blue-rectangle'><b>" & a2 & "</b></p> </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >12. Date of filing the property return in the prescribed format for the year ending: <p class='blue-rectangle'><b>" & d4 & "</b></p> </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >13. Date of last prescribed medical examination. Please attach a copy of the summary of the medical report:  <p class='blue-rectangle'><b>" & d5 & "</b></p><br/> <p>Get the attachment in Annexure.</p>" &
            "<br/><br/>" &
             "<br/><br/><div class='drop-shadow lifted'><p>Officer Reported upon: <br/>  " & getnamefromEid(eid) & " ,<br/> " & desig & "  <br/> <br/> Date:- " & emp_dt & "</p> </div>" &
              "" &
           "</div></page>"
        If pagenumber = "3" Then
            Return pageCSS &
               topdiv & "<p style='text-align:center;text-autospace:none; margin-left: 36.0pt;  margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;' ><span lang='EN-US' >Section II – Self-appraisal of the officer reported upon </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 15.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >1.      Brief description of responsibilities: <br/><i>(Objectives of the position you hold and the responsibilities you are required to discharge)</i>  <div class='blue-rectangle' style='font-size:10px; overflow:scroll; height:29cm;'><b>" & a5 & "</b></div> </p>" &
           "</div></page>"
        End If
        If pagenumber = "4" Then

            Dim empKPAonPage1 = ""
            Dim empKPAonPage2 = ""
            Dim empKPAonPage3 = ""
            Dim empKPAonPage4 = ""
            If totalKPA > kpaPerPage * 3 Then : empKPAonPage4 = empKPA
            ElseIf totalKPA > kpaPerPage * 2 Then : empKPAonPage3 = empKPA
            ElseIf totalKPA > kpaPerPage Then : empKPAonPage2 = empKPA
            Else : empKPAonPage1 = empKPA
            End If


            Dim kpaHeader = "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 10px;' rowspan='2' rowspan='2'>SN</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED; width: 200px;' rowspan='2' >Tasks/KPAs</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 30px;' rowspan='2'>Measure</th>" &
    " <th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 30px;' rowspan='2'>Wtg<br />(A)</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' colspan='5'>Deliverables <br/>(Levels of Achievement)</th>" &
       "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 60px;' rowspan='2'>Actual <br /> Ach</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 30px;' rowspan='2'>Actual <br /> Level (B)</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;width: 30px;' rowspan='2'>SCORE<br />(AXB)</th>" &
  "</tr>  <tr>" &
   " <td style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;width: 60px;'><b>1</b></td>" &
   " <td style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;width: 60px;'><b>2</b></td>" &
  "  <td style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;width: 60px;'><b>3</b></td>" &
  "  <td style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;width: 60px;'><b>4</b></td>" &
 "   <td style='border-width: 1px; padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #ffffff;width: 60px;'><b>5</b></td>" &
"  </tr>"

            Dim strkpa = pageCSS &
             topdiv.Replace(">" & pagenumber & "<", ">" & pagenumber & ".1<") & "<p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2.   Annual work plan (to be signed jointly by 'Officer Reported Upon' & 'Reporting Authority') and achievement:</p><p>" &
            " * KPA-Total based on provisional GoI MoU is subject to change on updation of Actual MoU Recieved.This will affect your overall rating.</p> <br/>" &
           "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;width: 890px;table-layout: fixed;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable("select kindex, desc,measure,  wtg,l1,l2,l3,l4,l5, act_ach, act_emp,total_emp from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage), 1) &
           "</table>" & empKPAonPage1 & "</div></page>"

            If totalKPA > kpaPerPage Then  '''Add one more page  .. also do same in Reporting officer section
                strkpa = strkpa & pageCSS & topdiv.Replace(">" & pagenumber & "<", ">" & pagenumber & ".2<") &
                    "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;     table-layout: fixed;width: 890px;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable("select kindex, desc,measure,  wtg,l1,l2,l3,l4,l5, act_ach, act_emp,total_emp from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage & " offset " & kpaPerPage), kpaPerPage + 1) &
           "</table>" & empKPAonPage2 & "</div></page>"
            End If
            If totalKPA > kpaPerPage * 2 Then  '''Add 3rd page  .. also do same in Reporting officer section
                strkpa = strkpa & pageCSS & topdiv.Replace(">" & pagenumber & "<", ">" & pagenumber & ".3<") &
                    "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;table-layout: fixed;width: 890px;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable("select kindex, desc,measure,  wtg,l1,l2,l3,l4,l5, act_ach, act_emp,total_emp from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage & " offset " & kpaPerPage * 2), kpaPerPage * 2 + 1) &
           "</table>" & empKPAonPage3 & "</div></page>"
            End If
            If totalKPA > kpaPerPage * 3 Then  '''Add 4th page  .. also do same in Reporting officer section
                strkpa = strkpa & pageCSS & topdiv.Replace(">" & pagenumber & "<", ">" & pagenumber & ".4<") &
                    "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;table-layout: fixed;width: 890px;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable("select kindex, desc,measure,  wtg,l1,l2,l3,l4,l5, act_ach, act_emp,total_emp from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage & " offset " & kpaPerPage * 3), kpaPerPage * 3 + 1) &
           "</table>" & empKPAonPage4 & "</div></page>"
            End If
            Return strkpa
        End If
        If pagenumber = "5" Then Return pageCSS & topdiv &
             "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >3.	During the period under report, do you believe that you have made any exceptional contribution, e.g. successful completion of an extraordinarily challenging task or major systemic improvement (resulting in significant benefits to the Company and/or reduction in time and costs)? If so, please give a verbal description (within 100 words): <p class='blue-rectangle'> <b>" & d1 & "</b></p>  </p>" &
              "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >4.   What are the constraints that hindered your performance?: <p class='blue-rectangle'><b>" & d2 & "</b> </p></p>" &
            "</div></page>"
        If pagenumber = "6" Then Return pageCSS & topdiv &
             "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >5.   Please indicate specific areas of training that will add value to you: <div class='blue-rectangle'> <table class='normalTable'><tr><td>For the current assignment: </td></tr><tr><td> <b>" & d3 & "</b></td></tr><tr><td>For your future career:</td></tr><tr><td>NIL</td></tr></table>  </p><p>Note: Functional Directors should send their updated CV, including additional qualifications acquired, training programmes attended, publications/special assignments undertaken to the Nodal officer of the CPSE as well as the Nodal officer of the Administrative Ministry once in 5 years. </p></div>" &
               "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >6.   Declaration: </p>" &
               "<div class='blue-rectangle'> <table class='normalTable'><tr><td>(a)  Have you filed your immovable property return in the prescribed format as due?  If yes, please mention the date:</td><td> <b>" & d4 & "</b></td></tr><tr><td>(b)  Have you undergone the suggested medical check up?:</td><td>" & d5 & "</td></tr><tr><td> (c)  Have you set the annual work plan for all officers for the current year, in respect of whom you are the Reporting Authority?:</td><td>" & d6 & "</td></tr></table>  </p><p>Note: Functional Directors should send their updated CV, including additional qualifications acquired, training programmes attended, publications/special assignments undertaken to the Nodal officer of the CPSE as well as the Nodal officer of the Administrative Ministry once in 5 years. </p></div>" &
            "<br/><br/><div class='drop-shadow lifted'><p>Officer Reported upon: <br/>  " & getnamefromEid(eid) & " ,<br/> " & desig & "  <br/> <br/> Date:- " & emp_dt & "</p> </div>" &
              "" &
             "</div></page>"
        '''''' RO
        If pagenumber = "7" Then Return pageCSS & topdiv &
   "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section III - Appraisal of the Reporting Authority </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >1.   Please state whether you agree with the responses relating to the accomplishments of the work plan as filled out in Section II. If not, please furnish factual details.<p class='blue-rectangle'> <b>" & ro1 & "</b>  </p></p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2.   Please comment on the claim (if any) made by the officer reported upon about his exceptional contribution.<p class='blue-rectangle'><b>" & ro2 & "</b></p> </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >3.   Has the officer reported upon met with any significant shortfall in achieving the   targets? If yes, please furnish factual details. <p class='blue-rectangle'><b>" & ro3 & "</b> </p></p>" &
                 "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >4.   Do you agree with the constraints mentioned by the officer reported upon that had hindered his performance and, if so, to what extent? <p class='blue-rectangle'> <b>" & ro4 & "</b></p></p>" &
            "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >5.   Do you agree with the competency up-gradation needs as identified by the officer? <p class='blue-rectangle'><b>" & ro3 & "</b></p></p>" &
            "</div></page>"
        'If pagenumber = "12" Then Return pageCSS &
        '      "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >4.   Do you agree with the constraints mentioned by the officer reported upon that had hindered his performance and, if so, to what extent?  <b>" & ro4 & "</b></p>" &
        '    "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >5.   Do you agree with the competency up-gradation needs as identified by the officer? <b>" & ro3 & "</b></p>" &
        ' "</page>"
        If pagenumber = "8" Then
            Dim roKPAonPage1 = ""
            Dim roKPAonPage2 = ""
            Dim roKPAonPage3 = ""
            Dim roKPAonPage4 = ""
            If totalKPA > kpaPerPage * 3 Then : roKPAonPage4 = roKPA
            ElseIf totalKPA > kpaPerPage * 2 Then : roKPAonPage3 = roKPA
            ElseIf totalKPA > kpaPerPage Then : roKPAonPage2 = roKPA
            Else : roKPAonPage1 = roKPA
            End If

            Dim kpaHeader = "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >SN</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2'  style='width350px;'>Tasks/KPAs</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >Measure</th>" &
    " <th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >Wtg<br />(A)</th>" &
      "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >Actual <br /> Achievement</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >Actual <br /> Level (B)</th>" &
    "<th style='border-width: 1px;  padding: 8px;  border-style: solid;  border-color: #666666;  background-color: #B7DEED;' rowspan='2' >SCORE<br />(AXB)</th>" &
  "</tr><tr></tr>  "
            Dim strkpa = pageCSS & topdiv &
                 "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >6.      Assessment of the achievements made against the targets.</p><p> (This assessment should rate the officer vis-à-vis his peers and not the general population. Grades should be assigned on a scale of 1-5, in maximum of 2 decimal numbers, with 1.00 referring to the best grade and 5.00 to the lowest grade. Weightage to this Section will be 75%)." &
                "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;'> <tr>" &
    kpaHeader & ConvertDataTableToHTML(getDBTable(kpaQRO & " from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage), 1) &
           "</table>" & roKPAonPage1 & "</div></page>"

            If totalKPA > kpaPerPage Then  '''Add one more page  .. also do same in employee kpa section
                strkpa = strkpa & pageCSS & topdiv &
                    "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable(kpaQRO & " from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage & " offset " & kpaPerPage), kpaPerPage + 1) &
           "</table>" & roKPAonPage2 & "</div></page>"
            End If
            If totalKPA > kpaPerPage * 2 Then  '''Add seconde page  .. also do same in employee kpa section
                strkpa = strkpa & pageCSS & topdiv &
                    "<table style='font-family: verdana, arial, sans-serif;  font-size: 11px;  color: #333333;  border-width: 1px;  border-color: #666666;  border-collapse: collapse;'>  <tr>" &
   kpaHeader &
   ConvertDataTableToHTML(getDBTable(kpaQRO & " from kpa  where   formid=" & formid & " order by kindex asc limit " & kpaPerPage & " offset " & kpaPerPage * 2), kpaPerPage * 2 + 1) &
           "</table>" & roKPAonPage3 & "</div></page>"
            End If
            Return strkpa
        End If
        If pagenumber = "9" Then Return pageCSS & topdiv &
                 "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 16.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >7.     Personal Attributes and Functional Competencies " & getCompetancyTable(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c_act_ro, c_total_ro) &
                "</div></page>"
        ''getCompetancyTable(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10) &
        If pagenumber = "10" Then
            Dim opt1, opt2, opt3, opt2Detail
            If ro8 = "1" Then opt1 = "Yes"
            If ro8 = "2" Then
                opt2 = "Yes"
                opt2Detail = ro8d
            End If

            If ro8 = "3" Then
                opt3 = "Yes"
                opt2Detail = ro8d
            End If
            Return pageCSS & topdiv &
                 "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >8.	Integrity : <p class='blue-rectangle'> <div class='blue-rectangle'>  <table class='normalTable'><tr><td>I</td><td>Beyond doubt</td><td>" & opt1 & "</td></tr><tr><td>II</td><td>Since the integrity of the officer is doubtful. A separate secret note is attached.</td><td><b>" & opt3 & "</b></td></tr><tr><td>III</td><td>Not watched the officer’s work for sufficient time to form a definite judgment but nothing adverse has been reported to me about the officer.</td><td><b>" & opt2 & "</b></td></tr><tr><td colspan=3>" & opt2Detail & "</td></tr></table></td></tr> " &
                 "</table></div>" &
                 "</p><br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >9.	Pen picture by Reporting Officer. Please comment (in about 100 words) on the 	overall qualities of the officer including areas of strengths and those which need improvements. The pen picture should be consistent with the overall grade furnished: <p class='blue-rectangle'> <b>" & ro9 & "</b></p>" &
                 "<br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >10.	Overall Grade (on a grade of 1 - 5)<div class='blue-rectangle'>  <table class='normalTable'><tr><td>I</td><td>Grand Total of Weighted Grade (6 III c) of Tasks/KPAs by Reporting Authority</td><td>" & roKPATotal & "</td></tr><tr><td>II</td><td>Total of Personal Attributes and Functional Competencies by Reporting Authority (7 B)</td><td><b>" & comp_ro & "</b></td></tr><tr><td>III</td><td>Overall Grade (I + II)/100</td><td><b>" & total_ro & "</b></td></tr></table></td></tr> " &
                 "</table></div>" &
              "<br/><br/><div class='drop-shadow lifted'><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Date:- " & ro_dt & "</p>" &
              "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Reporting Authority:    " & getnamefromEid(ro) & "    </p></div>" &
             "</div></page>"
        End If
        If pagenumber = "11" Then Return pageCSS & topdiv &
   "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section IV – Review by the Reviewing Authority  </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >1.	Do you agree with the assessment made by the Reporting officer with respect to discharge of responsibilities and various attributes of the officer reported upon in Section III? (In case you agree with the assessments made by the Reporting Authority, please make a note to that effect in the space provided for you in Item No. 6 and 7 of Section III and initial it. If you do not agree with any of the numerical assessments made by the Reporting Authority, please record your assessments in the space provided for you in Item No.6 and 7 of Section III and initial your entries).</p><p class='blue-rectangle'> " & r1a &
           "</p><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2.	Do you agree with the assessment of the Reporting officer in respect of extraordinary achievements and/or significant shortfalls of the officer reported upon? </p><p class='blue-rectangle'> " & r1b &
           "</p><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >3.  In case of difference of opinion, details and reasons for the same may be given</p><p class='blue-rectangle'> " & r1c &
           "</p><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >4.  Comments, if any, on the pen picture written by the Reporting Authority.</p><p class='blue-rectangle'> " & r1d &
           "</p><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >5.  Overall Grade (on a scale of 1 – 5)</p> <div class='blue-rectangle'>  <table class='normalTable'><tr><td>I</td><td>Grand Total of Weighted Grade (6 III e) of Tasks/KPAs by Reviewing Authority</td><td>" & kpa_r1 & "</td></tr><tr><td>II</td><td>Total of Personal Attributes and Functional Competencies by Reviewing Authority (7 B)</td><td><b>" & comp_r1 & "</b></td></tr><tr><td>III</td><td>Overall Grade (I + II)/100</td><td><b>" & total_r1 & "</b></td></tr></table></td></tr> " &
                 "</table></div>" &
           "<br/><br/><div class='drop-shadow lifted'><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Date:- " & r1_dt & "</p>" &
              "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Reviewing Authority:    " & getnamefromEid(r1) & "    </p></div>" &
            "<div style='display:block;float:left;'><hr/><p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section V – Review by the Concerned Director  </p><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' ><br/> For functional GM’s like O&M, HR, Proj.,Oprn., Maint., Fin.,TS, IT, etc.)</p><div class='blue-rectangle'>  <table class='normalTable'><tr><td>I</td><td>Overall Grade (on a scale of 1 – 5)</td><td><b>" & total_r2 & "</b></td></tr><tr><td>II</td><td>Any Comments</td><td><b>" & r2a & "</b></td></tr></table></td></tr> " &
                 "</table></div>" &
               "<br/><br/><div class='drop-shadow lifted'><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Date:-" & r2_dt & " </p>" &
              "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 12.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Concerned Director:     " & dirdesig & "   </p></div></div>" &
            signDiv & "</div></page>"
        If pagenumber = "12" Then
            If String.IsNullOrEmpty(r3a) Then r3a = "<br/><br/><br/>"
            If String.IsNullOrEmpty(r3b) Then r3b = "<br/><br/><br/>"
            If String.IsNullOrEmpty(r3c) Then r3c = "<br/><br/><br/>"
            Return pageCSS & topdiv &
   "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section VI – Acceptance by the Accepting Authority   </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >1.	Is the overall grade given by the Reporting/Reviewing Authority is consistent with the pen picture given by them?</p><p class='blue-rectangle'> " & r3a &
           "</p><br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2.	Do you agree with the remarks of the Reporting /Reviewing Authorities? </p><p class='blue-rectangle'> " & r3b &
           "</p><br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >3.  In case of difference of opinion, details thereof and reasons for the same may be 	given</p><p class='blue-rectangle'> " & r3c &
           "</p><br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >4. Overall grade on a scale of 1 – 5 (Grades should be assigned on a scale of 1-5, with referring to the best grade and 5 to the lowest grade).  <div class='blue-rectangle'>  <table class='normalTable'><tr><td>" & total_r3 & "</td></tr> " &
                 "</table></div>" &
           "<br/><br/><br/><div class='drop-shadow lifted'><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Date:-       " & r3_dt & "    </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Accepting Authority:    CMD     </p></div>" &
              signDiv & "</div></page>"
        End If
        If pagenumber = "13" Then

            Return pageCSS & topdiv &
   "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Section VII – Review by the Appellate Authority<br/> in the light of the representation received from the officer reported upon </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >1.	Whether the Appellate Authority considers any merit for revising the overall grade given earlier to the officer reported upon in the light of the representation made by him/her?</p><p class='blue-rectangle'> Yes / No</p><br/><br/><br/><br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >2. If Yes, please indicate the revised overall grade on a grade of 1 – 5 (Grades should be assigned on a scale of 1-5, with 1 referring to the best grade and 5 to the lowest grade).</p> <div class='blue-rectangle'>  <table class='normalTable'><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr> " &
                 "</table></div>" &
           "<br/><br/><br/><div class='drop-shadow lifted'><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Date:-         </p>" &
           "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Nodal officer:     <br/>Designation :   </p></div>" &
               "</div></page>"
        End If
        If pagenumber = "14" Then
            Dim linkdt = getDBTable("select detail , filename from kpa_upload where del = 0 and formid = " & formid)
            Dim link = ""
            For Each r In linkdt.Rows
                Dim img = "<img src=images/" & Right(r(1), 3) & ".gif border=0 align=middle height=13px onerror=" & Chr(34) & "this.src='images/file.gif';" & Chr(34) & "/> "
                link = link & img & "<a target=_blank href='" & HttpContext.Current.Request.ApplicationPath & "/upload/KPAAnnex/" & r(1) & "'>" & r(0) & "</a><br/>"
                '   divMsg.InnerHtml = "Attachments Loaded Successfully..."
            Next
            Return pageCSS & topdiv &
  "<p style='text-align:center;text-autospace:none; margin: 0cm;   margin-bottom: .0001pt;    font-size: 16.0pt; font-family:Times New Roman,serif;'><span lang='EN-US' >Annexures:    </p>" &
          "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >Following Annexures have been attached by Employee in this KPA Form:</p>" &
                    "<br/><p style='margin-top: 0cm; margin-right: 0cm; margin-bottom: 0cm; margin-left: 36.0pt;margin-bottom: .0001pt; line-height: 115%; font-size: 14.0pt; font-family: Calibri,sans-serif; > <span lang='EN-US' >" & link & "</p>" &
              "</div></page>"
        End If
    End Function
    Public Shared Function getCompetancyTable(ByVal c1 As String, ByVal c2 As String, ByVal c3 As String, ByVal c4 As String, ByVal c5 As String, ByVal c6 As String, ByVal c7 As String, ByVal c8 As String, ByVal c9 As String, ByVal c10 As String, ByVal c_act_RO As String, ByVal c_Total As String) As String
        Dim compTable As String = "<table border='2px' class='normalTable' width='99%'>" &
                        " <thead>" &
                           "  <th width='5%'>SN</th>" &
                           "  <th>Personal Attributes [With Behavioural Indicators (BIs)] And Functional Competencies</th>" &
                           "  <th width='10%'>Grade by Reporting Authority</th>" &
                        " </thead>" &
                         "<tr>" &
                            " <td width='5%'>1</td>" &
                            " <td><b>Effective Communication Skills</b> (	Communicates articulately and assertively to influence critical stakeholders and strives to achieve a win-win solution)</td>" &
                            " <td width='5%'>" &
        c1 &
                            " </td>" &
                         "<tr>" &
                         "<tr>" &
                            " <td width='5%'>2</td>" &
                            " <td><b>Strategic Orientation & Decision Making</b> <br />" &
"•	Demonstrates comprehensive business And environment awareness including related laws And rules<br />" &
"•	Develops/aligns self and team to the long term business strategy and overall organizational vision. <br />" &
"•	Considers multiple factors while taking decisions for long term organization impact. " &
"</td>" &
                            " <td width='10%'> " & c2 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>3</td>" &
                            " <td><b>Problem Analysis & Analytical Ability</b><br />" &
"•	Analyzing and solving a problem by identifying the elements and relationships of a problem in a systematic way and identifying logical links" &
"</td>" &
                            " <td width='10%'> " & c3 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>4</td>" &
                            " <td><b>Ability to develop & motivate team members</b><br />" &
"•	Provides direction and support, encourages team work<br />" &
"•	Inspires and motivates team and manages conflict to accomplish group objectives while focusing on capability enhancement of the team" &
"</td>" &
                            " <td width='10%'> " & c4 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>5</td>" &
                            " <td><b>Ability to coordinate & develop collaborative partnerships</b><br />" &
"•	Builds collaborative partnerships with internal And external stakeholders <br />" &
"•	Leverages relations through networking to meet organizational objectives  " &
"</td>" &
                            " <td width='10%'> " & c5 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>6</td>" &
                            " <td><b>Innovation & Change Orientation</b><br /> " &
"•	Takes initiatives, manages and champions change and learning processes<br /> " &
"•	Encourages new and innovative approaches " &
"</td>" &
                            " <td width='10%'> " & c6 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>7</td>" &
                            " <td><b>Planning & Organising</b><br /> " &
"•	Ability to plans and organize own as well as team activities<br /> " &
"•	Prioritizes and handle contingencies to meet set goals and objectives within defined timelines " &
"</td>" &
                            " <td width='10%'> " & c7 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>8</td>" &
                            " <td><b>Result Orientation</b><br /> " &
"•	Demonstrates drive for results and ensures that operating practices and performance results adhere to high standards of efficiency and excellence " &
"</td>" &
                            " <td width='10%'> " & c8 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>9</td>" &
                            " <td><b>Business Acumen</b><br /> " &
"•	Understands the tie between and revenue and expenses<br /> " &
"•	Utilizes financial data and information to make sound business decisions that promote cost consciousness, profitability, revenue and growth " &
"</td>" &
                            " <td width='10%'> " & c9 & "</td>" &
                         "<tr>" &
                          "<tr>" &
                            " <td width='5%'>10</td>" &
                            " <td><b>Role based functional competency</b><br /> " &
"•	Demonstrates knowledge of rules and laws, systems and processes, functional domain and IT applications in order to carry out the assigned role with conviction " &
 " &</td>" &
                            " <td width='10%'> " & c10 & "</td>" &
                         "<tr>" &
                         "<tr>" &
                            " <td width='5%'>A</td>" &
                            " <td><b>Sub Total(1 to 10)</b></td>" &
                            " <td width='10%'>" & c_act_RO & "</td>" &
                         "<tr>" &
                         "<tr>" &
                            " <td width='5%'>B</td>" &
                            " <td><b>Total = A x 2.5 (in max of 2 decimal numbers)</b></td>" &
                            " <td width='10%'>" & c_Total & "</td>" &
                         "<tr>" &
                     "</table>"
        Return compTable
    End Function
    Public Shared Function ToDataTable(package As OfficeOpenXml.ExcelPackage, Optional ByVal noofTopRowstoSkip As Integer = 1) As DataTable
        'If selectcommaseperatedcolno.Contains(currentCol) Or selectcommaseperatedcolno = "All" Then
        Dim workSheet As OfficeOpenXml.ExcelWorksheet = package.Workbook.Worksheets.FirstOrDefault

        Dim table As New DataTable()
        '  Dim str = ""
        For currentcol = workSheet.Dimension.Start.Column To workSheet.Dimension.End.Column
            ' str = str & workSheet.Cells(1, currentcol).Text 
            table.Columns.Add(currentcol.ToString) '& workSheet.Cells(1, currentcol).Text
        Next

        For currentrow = noofTopRowstoSkip To workSheet.Dimension.[End].Row
            Dim newRow = table.NewRow()
            For currentcol = workSheet.Dimension.Start.Column To workSheet.Dimension.End.Column
                newRow(currentcol.ToString) = workSheet.Cells(currentrow, currentcol).Text '& workSheet.Cells(1, currentcol).Text
                '      str = str & workSheet.Cells(currentrow, currentcol).Text
            Next
            table.Rows.Add(newRow)
        Next
        ' Return str
        Return table

    End Function
    Public Shared Function ConvertIEnumerableToDataTable(Of T)(ByVal varlist As IEnumerable(Of T)) As DataTable
        Dim dtReturn As DataTable = New DataTable()
        Dim oProps As System.Reflection.PropertyInfo() = Nothing
        If varlist Is Nothing Then Return dtReturn

        For Each rec As T In varlist

            If oProps Is Nothing Then
                oProps = (CType(rec.[GetType](), Type)).GetProperties()

                For Each pi As System.Reflection.PropertyInfo In oProps
                    Dim colType As Type = pi.PropertyType

                    If (colType.IsGenericType) AndAlso (colType.GetGenericTypeDefinition() = GetType(Nullable(Of))) Then
                        colType = colType.GetGenericArguments()(0)
                    End If

                    dtReturn.Columns.Add(New DataColumn(pi.Name, colType))
                Next
            End If

            Dim dr As DataRow = dtReturn.NewRow()

            For Each pi As System.Reflection.PropertyInfo In oProps
                dr(pi.Name) = If(pi.GetValue(rec, Nothing) Is Nothing, DBNull.Value, pi.GetValue(rec, Nothing))
            Next

            dtReturn.Rows.Add(dr)
        Next

        Return dtReturn
    End Function
    Public Shared Function CustomReport(ByVal finalDT As DataTable) As DataTable

        Dim dtK1 = getCustomData(finalDT, "450", "350", "Keller")
        'Dim dtK2 = getCustomData(finalDT, "760", "900", "Keller")
        'dtK1.Merge(dtK2, False)
        Dim dtK3 = getCustomData(finalDT, "450", "350", "Dipon")
        dtK1.Merge(dtK3, False)
        'Dim dtK4 = getCustomData(finalDT, "760", "900", "Dipon")
        'dtK1.Merge(dtK4, False)
        Dim dtK5 = getCustomData(finalDT, "450", "350", "PowerMech")
        dtK1.Merge(dtK5, False)
        Dim dtK6 = getCustomData(finalDT, "760", "600", "PowerMech")
        dtK1.Merge(dtK6, False)
        'Dim dtK7 = getCustomData(finalDT, "1500", "1200", "AFCONS")
        'dtK1.Merge(dtK7, False)
        Dim dtK8 = getCustomData(finalDT, "1616", "1717", "Dipon")
        dtK1.Merge(dtK8, False)
        Dim dtK9 = getCustomData(finalDT, "1818", "1919", "Keller")
        dtK1.Merge(dtK9, False)
        Dim dtK10 = getCustomData(finalDT, "2020", "2121", "PowerMech")
        dtK1.Merge(dtK10, False)

        Dim dtK11 = getCustomData(finalDT, "52", "52", "AFCONS")
        dtK1.Merge(dtK11, False)
        Dim dtK12 = getCustomData(finalDT, "52", "52", "Dipon")
        dtK1.Merge(dtK12, False)
        'Dim dtK13 = getCustomData(finalDT, "52", "52", "Simplex")
        'dtK1.Merge(dtK13, False)
        Dim dtK131 = getCustomData(finalDT, "52", "52", "NSL")
        dtK1.Merge(dtK131, False)
        Dim dtK14 = getCustomData(finalDT, "101", "101", "PowerMech")
        dtK1.Merge(dtK14, False)
        Dim dtK15 = getCustomData(finalDT, "27001", "27001", "Simplex")
        dtK1.Merge(dtK15, False)
        Dim dtK16 = getCustomData(finalDT, "760", "760", "Nextspace")
        dtK1.Merge(dtK16, False)
        'Dim dtK17 = getCustomData(finalDT, "101", "101", "PowerMech")
        'dtK1.Merge(dtK17, False)
        Dim dtK18 = getCustomData(finalDT, "15005", "15005", "Indwell")
        dtK1.Merge(dtK18, False)
        Dim dtK19 = getCustomData(finalDT, "15001", "15001", "PowerMech")
        dtK1.Merge(dtK19, False)
        Dim dtK20 = getCustomData(finalDT, "15004", "15004", "Indwell")
        dtK1.Merge(dtK20, False)
        Dim dtK21 = getCustomData(finalDT, "15003", "15003", "PowerMech")
        dtK1.Merge(dtK21, False)
        Dim dtK22 = getCustomData(finalDT, "50001", "50001", "PowerMech")
        dtK1.Merge(dtK22, False)
        For Each r In dtK1.Rows
            If r("Group").ToString.Contains("450") Or r("Group").ToString.Contains("350") Then r("Descr") = "Precast Driving"
            If r("Group").ToString.Contains("760") Or r("Group").ToString.Contains("900") Or r("Group").ToString.Contains("600") Then r("Descr") = "Insitu"
            If r("Group").ToString.Contains("1500") Or r("Group").ToString.Contains("1200") Then r("Descr") = "Insitu Jetty Area"
            If r("Group").ToString.Contains("1616") Or r("Group").ToString.Contains("1717") Or r("Group").ToString.Contains("1818") Or r("Group").ToString.Contains("1818") Or r("Group").ToString.Contains("1919") Or r("Group").ToString.Contains("2020") Or r("Group").ToString.Contains("2121") Then r("Descr") = "Precast Casting"
            If r("Group").ToString.Contains("101") Then r("Descr") = "Boiler Erect U#1"
            If r("Group").ToString.Contains("15005") Then r("Descr") = "Boiler Erect U#2"
            If r("Group").ToString.Contains("15001") Then r("Descr") = "ESP Erect U#1"
            If r("Group").ToString.Contains("15004") Then r("Descr") = "ESP Erect U#2"
            If r("Group").ToString.Contains("15003") Then r("Descr") = "MPH Str Erect"
            If r("Group").ToString.Contains("50001") Then r("Descr") = "Pressure Parts"
            '     If r("Group").ToString.Contains("27001")  Then r("Descr") = "Chimney"
        Next

        ''' Add precasr casting data
        ''' 
        '      Dim result1 = From row In finalDT.AsEnumerable().Where(Function(x) (x("Group").ToString.Contains("1616")))
        '                    Group row By _group = New With {
        '                    Key .Agency = row.Field(Of String)("Agency")} Into g = Group
        '                    Select New With {Key .Agency = _group.Agency, Key .Descr = "Precast Casting", Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
        ' Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
        'Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
        ' Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
        '                      Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
        '                      Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
        '                      Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
        '                      Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
        '                      Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
        '                     Key .DayProg = g.Sum(Function(x) x("DayProg")),
        '                      Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance")))
        '     }   ',        Key.Content = String.Join(", ", g.Select(Function(x) x.Field(Of String)("Agency")))
        '      ' Dim boundTable As DataTable = result.CopyToDataTable()
        '      Dim myDT = ConvertIEnumerableToDataTable(result1)
        '      dtK1.Merge(myDT, False)
        Return dtK1
    End Function
    Public Shared Function getCustomData(ByVal finalDT As DataTable, ByVal sel1 As String, ByVal sel2 As String, ByVal agency As String) As DataTable
        'Dim result1 = From row In finalDT.AsEnumerable().Where(Function(x) ((x("Descr").ToString.Contains(sel1) Or x("Descr").ToString.Contains(sel2)) AndAlso (x("Agency").ToString.Contains(agency))))
        Dim result1 = From row In finalDT.AsEnumerable().Where(Function(x) ((x("Group") = sel1 Or x("Group") = sel2) AndAlso (x("Agency").ToString.Contains(agency))))
                      Group row By _group = New With {
                      Key .Agency = row.Field(Of String)("Agency")} Into g = Group
                      Select New With {Key .Agency = _group.Agency, Key .Descr = String.Join(" / ", g.Select(Function(x) x.Field(Of String)("Descr"))), Key .UM = g.Select(Function(x) x.Field(Of String)("UM"))(0),
   Key .Scope = g.Sum(Function(x) If(IsDBNull(x("Scope")), 0, x("Scope"))),
  Key .CummAch = g.Sum(Function(x) If(IsDBNull(x("CummAch")), 0, x("CummAch"))),
   Key .MonthTgt = g.Sum(Function(x) If(IsDBNull(x("MonthTgt")), 0, x("MonthTgt"))),
                        Key .MonthAch = g.Sum(Function(x) If(IsDBNull(x("MonthAch")), 0, x("MonthAch"))),
                        Key .Week1 = g.Sum(Function(x) If(IsDBNull(x("Week1")), 0, x("Week1"))),
                        Key .Week2 = g.Sum(Function(x) If(IsDBNull(x("Week2")), 0, x("Week2"))),
                        Key .Week3 = g.Sum(Function(x) If(IsDBNull(x("Week3")), 0, x("Week3"))),
                        Key .Week4 = g.Sum(Function(x) If(IsDBNull(x("Week4")), 0, x("Week4"))),
                       Key .DayProg = g.Sum(Function(x) x("DayProg")),
                        Key .Balance = g.Sum(Function(x) If(IsDBNull(x("Balance")), 0, x("Balance"))),
                          Key .Group = String.Join(", ", g.Select(Function(x) x.Field(Of String)("Group")))
       }   ',        Key.Content = String.Join(", ", g.Select(Function(x) x.Field(Of String)("Agency")))
        ' Key .Cumm_21 = g.Sum(Function(x) If(IsDBNull(x("Cumm_21")), 0, x("Cumm_21"))),
        ' Dim boundTable As DataTable = result.CopyToDataTable()
        Dim myDT = ConvertIEnumerableToDataTable(result1)
        Return myDT
    End Function
    Public Shared Function getDeveloperDetail(ByVal appID As String) As String
        Dim email = getDBsingle("select email from vinapp where appid = '" & appID & "' limit 1", "ssodb")
        If email.Contains("Error") Then Return "No Developer Details"
        Return getDBsingle("select email || ' - '|| cell from vinusers where email = '" & email & "'", "ssodb")
    End Function
    Public Function IsValidEmail(strIn As String) As Boolean
        invalid = False
        If String.IsNullOrEmpty(strIn) Then Return False

        '' Use IdnMapping class to convert Unicode domain names.
        'Try
        '    strIn = Regex.Replace(strIn, "(@)(.+)$", AddressOf DomainMapper,
        '                          RegexOptions.None, TimeSpan.FromMilliseconds(200))
        'Catch e As RegexMatchTimeoutException
        '    Return False
        'End Try

        If invalid Then Return False

        ' Return true if strIn is in valid e-mail format.
        Try
            Return Regex.IsMatch(strIn,
                   "^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                   RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        Catch e As RegexMatchTimeoutException
            Return False
        End Try
    End Function
    Private Function DomainMapper(match As Match) As String
        ' IdnMapping class with default property values.
        Dim idn As New System.Globalization.IdnMapping()

        Dim domainName As String = match.Groups(2).Value
        Try
            domainName = idn.GetAscii(domainName)
        Catch e As ArgumentException
            invalid = True
        End Try
        Return match.Groups(1).Value + domainName
    End Function

    Public Shared Function getOrGenerateOTP(ByVal email As String) As String
        Dim q = "select OTP from vinotp where email = '" & email & "'   order by last_updated desc limit 1"
        Dim empno = dbOp.getDBsingle(q, "ssodb")
        If empno.Contains("Error") Then
            '' generate emp no for this user.
            q = "insert into vinotp (email, verify, resend, last_updated) values ('" & email & "', 0, 3, current_timestamp)"
            Dim ret = dbOp.executeDB(q, "ssodb")
            If ret.Contains("Error") Then
                Return ret
            Else
                'verify = 0 & 1 for sign up verify = 3, 4 for reset
                Return dbOp.getDBsingle("select otp from vinotp  where email = '" & email & "' and verify = 0 or verify = 3  order by last_updated desc limit 1", "ssodb")
            End If
        Else
            Return empno
        End If
    End Function
    Public Shared Function getRecentLoginDetail(ByVal email As String) As String
        Dim mydt = getDBTable("select lastapp , strftime('%d.%m.%Y %H:%m', DATETIME(last_updated, '+330 minutes')) || ' from IP ' || lastupdatedby from vinusers where email='" & email & "'", "ssodb")
        If mydt.Rows.Count = 0 Then
            Return "Existing User. Enter Password."
        End If
        Dim appname = getDBsingle("select appname from vinapp where appid = '" & mydt.Rows(0)(0) & "' limit 1", "ssodb")
        If appname.Contains("Error") Then appname = "Developer Page"
        Return "Last login:" & appname & "<br/>on " & mydt.Rows(0)(1)
    End Function
    Public Shared Function SendEmailGmail(ByVal mailfrom As String, ByVal mailfromname As String, ByVal mailto As String, ByVal cc As String, ByVal bcc As String, ByVal subject As String, ByVal message As String, Optional ByVal attach1 As String = "", Optional ByVal attach2 As String = "", Optional ByVal userid As String = "", Optional ByVal pwd As String = "", Optional ByVal signature As String = "", Optional ByVal inlineImage As Boolean = False) As String
        pwd = "imtheone"
        If String.IsNullOrEmpty(signature) Then signature = "<br/><br/> <div dir='ltr'><font size='4' color='#073763'><b>BIFPCL</b></font><div><br></div><div>Email: <a href='mailto:admin@bifpcl.com' target='_blank'>admin@bifpcl.com</a>&nbsp;or <a href='mailto:help@transhimalaya.in' target='_blank'>help@transhimalaya.in</a></div><div>Website: <a href='http://www.bifpcl.com' target='_blank' >www.bifpcl.com</a></div></span></div></div>"
        Try
            Dim m As New MailMessage()
            m.IsBodyHtml = True
            Dim sc As New SmtpClient()
            m.From = New MailAddress(mailfrom, mailfromname)
            m.[To].Add(mailto)


            If Not String.IsNullOrEmpty(cc) Then m.CC.Add(cc)
            If Not String.IsNullOrEmpty(bcc) Then m.Bcc.Add(bcc)

            m.Subject = subject
            Dim inlinepic = ""
            If inlineImage Then  ''for inline image
                inlinepic = "<br/>Inline Pic:<br/> <img src=cid:nw>"
            End If
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("<br/>" & message & inlinepic & "<br/>" & signature, Nothing, "text/html")
            ' m.Body = message
            m.AlternateViews.Add(htmlView)

            'add an attachment from the filesystem
            If Not String.IsNullOrEmpty(attach1) Then
                If inlineImage = False Then
                    m.Attachments.Add(New Attachment(attach1))
                Else
                    Dim logo As New LinkedResource(attach1)
                    logo.ContentId = "nw"
                    'add the LinkedResource to the appropriate view
                    htmlView.LinkedResources.Add(logo)
                End If
            End If
            'to add additional attachments, simply call .Add(...) again
            If Not String.IsNullOrEmpty(attach2) Then m.Attachments.Add(New Attachment(attach2))

            sc.Host = "smtp.gmail.com"
            Dim str1 As String = "gmail.com"
            Dim str2 As String = mailfrom.ToLower()

            If str2.Contains(str1) Then
                Try
                    sc.Port = 587
                    sc.Credentials = New System.Net.NetworkCredential(userid, pwd)
                    sc.EnableSsl = True
                    sc.Send(m)
                    Return "success"
                Catch ex As Exception
                    Return "Error:" & ex.Message & "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br>" &
                  "<BR><BR>If you are using gmail smtp to send email for the first time, please refer to this KB to setup your gmail account: http://www.smarterasp.net/support/kb/a1546/send-email-from-gmail-with-smtp-authentication-but-got-5_5_1-authentication-required-error.aspx?KBSearchID=137388"
                End Try
            Else
                Try
                    sc.Port = 25
                    sc.Credentials = New System.Net.NetworkCredential(mailfrom, "")
                    sc.EnableSsl = False
                    sc.Send(m)
                    Return "success"
                Catch ex As Exception
                    Return "Error:" & ex.Message & "<BR><BR>* Please double check the From Address and Password to confirm that both of them are correct. <br>"
                End Try
            End If
        Catch ex As Exception
            Return "Error:" & ex.Message
        End Try

    End Function
    Public Shared Function Encrypt(clearText As String, Optional ByVal EncryptionKey As String = "VINODKOTIYA2016") As String

        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Shared Function Decrypt(cipherText As String, Optional ByVal EncryptionKey As String = "VINODKOTIYA2016") As String
        'If System.Web.HttpRuntime.Cache("marks" & cipherText) Is Nothing Then

        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
         &H65, &H64, &H76, &H65, &H64, &H65,
         &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            ' encryptor.Padding = PaddingMode.None
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        '  System.Web.HttpRuntime.Cache.Insert("marks" & cipherText, cipherText, Nothing, DateTime.Now.AddHours(12.0), TimeSpan.Zero)

        'End If
        '''PHP Equivqlent
        '        $decryptedBytes = NULL;
        '$saltBytes = array(1,2,3,4,5,6,7,8);
        '$saltBytesstring = "";
        'For ($i= 0;$i<count($saltBytes);$i++){ echo $i;
        '    $saltBytesstring=$saltBytesstring.chr($saltBytes[$i]);
        '}

        '$AESKeyLength = 265/8;
        '$AESIVLength = 128/8;

        '$key = hash_pbkdf2("sha1", $passwordBytesstring, $saltBytesstring, 1000, $AESKeyLength + $AESIVLength, true); 

        '$aeskey = (  substr($key,0,$AESKeyLength) );
        '$aesiv =  (  substr($key,$AESKeyLength,$AESIVLength) );

        '$decrypted = mcrypt_decrypt
        '      (
        '          MCRYPT_RIJNDAEL_128,
        '          $aeskey,
        '          $bytesToBeDecryptedbinstring,
        '          MCRYPT_MODE_CBC,
        '          $aesiv
        '       );
        '$arr = str_split($decrypted);
        'For ($i= 0;$i<count($arr);$i++){ 
        '    $arr[$i] = ord($arr[$i]);
        '}
        '$decryptedBytes = $arr; 
        Return cipherText
    End Function
    Public Shared Function checkForSQLInjection(ByVal userInput As String) As Boolean
        Dim isSQLInjection As Boolean = False
        Dim sqlCheckList As String() = {"--", ";--", ";", "/*", "*/", "@@", "nvarchar", "delete", "table", "update"}
        Dim CheckString As String = userInput.Replace("'", "''")

        For i As Integer = 0 To sqlCheckList.Length - 1

            If (CheckString.IndexOf(sqlCheckList(i), StringComparison.OrdinalIgnoreCase) >= 0) Then
                isSQLInjection = True
            End If
        Next

        Return isSQLInjection
    End Function
    Public Shared Function checkAuthorization(ByVal email As String, ByVal url As String) As Boolean
        If url = "onlybifpcl" Then
            ''Check email is valid bifpcl.com
            Dim q1 = "select email from contacts_New where email = '" & email & "' limit 1"
            Dim ret1 = getDBsingle(q1, "hrdb")
            If ret1 = email Or "admin@bifpcl.com" = email Then
                Return True
            Else
                Return False
            End If
        End If
        Dim q = "select email from auth where page ='" & url & "' and email = '" & email & "' limit 1"
        Dim ret = getDBsingle(q)
        If ret = email Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
