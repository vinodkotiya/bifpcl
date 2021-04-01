Imports System.IO
Imports Ionic.Zip
Imports System.Collections.Generic
Imports dbOp

Partial Class dailybackup
    Inherits System.Web.UI.Page

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        backupjob()
    End Sub
    Sub backupjob()
        ' If getDBsingle("select (strftime('%s','now')- strftime('%s',last_updated)) / 3600 from backup where backupday = 'sendbackup'") > 24 Then
        Dim zipName As String
            Dim path = Server.MapPath("~/App_Data/")
            Using zip As New ZipFile()
                zip.AlternateEncodingUsage = ZipOption.AsNecessary
                zip.Password = "ntpc1234scope6789delhi"
                ' zip.AddDirectoryByName("Files")
                Dim filesToZip As New System.Collections.Generic.List(Of String)()

            filesToZip.Add(path & "bifpc.db")
            filesToZip.Add(path & "hr.db")
            filesToZip.Add(path & "dpr.db")
            filesToZip.Add(path & "sso.db")
            filesToZip.Add(path & "apps.db")
            filesToZip.Add(path & "gp.db")

            For Each filepath As String In filesToZip
                    zip.AddFile(filepath, "Files")

                Next
            'Response.Clear()
            'Response.BufferOutput = False
            zipName = [String].Format("Backup_{0}.zip", "bifpc") 'DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")
            'Response.ContentType = "application/zip"
            'Response.AddHeader("content-disposition", "attachment; filename=" + zipName)
            ' zip.Save(Response.OutputStream)
            zip.Save(path & zipName)
                '  Response.[End]()
                divmsg.InnerHtml = "Zip File created " & zipName


            End Using
        '' now mail backup 
        '' check
        Dim mailto = "admin@bifpcl.com"
        Dim mailcc = "itbifpcl@gmail.com"
        Dim msg = "Dear Team " & vbCrLf & vbCrLf &
                "<br/><br/>Please find attached system generated database backup" & vbCrLf &
                "<br/><br/> zip file is password protected <br/> <br/> "



        ' Dim ret = SendEmail("CCHR-NOREPLY@ntpc.co.in", mailto, mailcc, "", "Daily Backup " & Now.ToString("dd.MM.yyyy"), msg, path & zipName, "", "", "")
        Dim ret = SendEmail("admin@bifpcl.com", mailto, mailcc, "", "BIFPCL Daily Data backup  " & DateTime.UtcNow.AddHours(6).ToString("dd.MM.yyyy HH:mm"), msg, path & zipName, "", "admin@bifpcl.com", "Imtheone@6")

        ' executeDB("update backup set last_updated= current_timestamp where backupday = 'sendbackup'")
        divmsg.InnerHtml = divmsg.InnerHtml & "  File emailed " & ret

        'Else
        '    divmsg.InnerHtml = "Backup already taken and mailed for today."
        'End If
    End Sub

    Private Sub dailybackup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Button1.Enabled = False
        ' Button2.Enabled = False
        If Session("email") Is Nothing Then
            'Response.Redirect("sso/Default.aspx?appid=12343272")
            divmsg.InnerHtml = "Please login to take backup <a href=sso/Default.aspx?appid=12343272> Login </a>"
            Exit Sub
        End If
        If Not (checkAuthorization(Session("email"), "dailybackup.aspx")) Then
            divmsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation."
            Exit Sub
        End If
        Button1.Enabled = True
        Button2.Enabled = True
        ' backupjob()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim msg = ""
        Dim ret = getDBsingle("PRAGMA INTEGRITY_CHECK")
        msg = msg & "BIFPCL DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "hrdb")
        msg = msg & "<br/>HR DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "dprdb")
        msg = msg & "<br/>DPR DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "appsdb")
        msg = msg & "<br/>Apps DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "gpdb")
        msg = msg & "<br/>Gate Pass DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "ssodb")
        msg = msg & "<br/>SSO DB " & ret
        ret = getDBsingle("PRAGMA INTEGRITY_CHECK", "logdb")
        msg = msg & "<br/>Log DB " & ret & "<br/>pragma integrity_check"
        divmsg.InnerHtml = msg
    End Sub
End Class
