Imports System.Net.Http
Imports System.Web.Script.Serialization
Imports System.Net
Partial Class sms
    Inherits System.Web.UI.Page

    Private Sub sms_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim msg = HttpUtility.UrlDecode(Request.Params("message_body"))
            SendSMS(Request.Params("mobile"), msg, Request.Params("request_type"))
        End If
    End Sub
    Async Sub SendSMS(ByVal mobile As String, ByVal message_body As String, Optional request_type As String = "GENERAL_CAMPAIGN")
        '  In web.config
        '<assemblies>
        '  <add assembly = "System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" />
        '</assemblies>
        '  Dim myJson As String = "{'api_key':'KEY-aai41fb80abs0ljp130nqv81znmi28rn','api_secret':'1mpR6HcKMF3Cft@r','request_type': 'OTP','message_type':'TEXT','message_body':'OTP 4646','mobile':'01678582832'}"
        Dim serializer = New JavaScriptSerializer()
        'Dim json As String = serializer.Serialize(New With {Key .api_key = "KEY-aai41fb80abs0ljp130nqv81znmi28rn", Key .api_secret = "1mpR6HcKMF3Cft@r"
        ' })
        Dim myJson As String
        If request_type = "OTP" Then
            Dim json As String = serializer.Serialize(New With {Key .api_key = "KEY-bryoxd3oxg65i52weg9l0phljixic6w7",
                                                  Key .api_secret = "en8MxcoDturzTYrXdd",
                                                  Key .request_type = request_type,
                                                  Key .message_type = "UNICODE",
                                                  Key .message_body = message_body,
                                                  Key .mobile = mobile
    })
            myJson = json
        ElseIf request_type = "GENERAL_CAMPAIGN" Then
            Dim json As String = serializer.Serialize(New With {Key .api_key = "KEY-bryoxd3oxg65i52weg9l0phljixic6w7",
                                                 Key .api_secret = "en8MxcoDturzTYrXdd",
                                                 Key .request_type = request_type,
                                                 Key .message_type = "UNICODE",
                                                 Key .message_body = message_body,
                                                 Key .mobile = mobile,
                                                 Key .campaign_title = "BIFPCL11"
   })
            myJson = json
        End If


        Using client = New HttpClient()
            Using response As HttpResponseMessage = Await client.PostAsync("https://portal.adnsms.com/api/v1/secure/send-sms", New StringContent(myJson, Encoding.UTF8, "application/json"))
                '  Using response As HttpResponseMessage = Await client.PostAsync("https://portal.addnsms.com/api/v1/secure/check-balance", New StringContent(json, Encoding.UTF8, "application/json"))
                Using content As HttpContent = response.Content
                    ' Get contents of page as a String.
                    Dim result As String = Await content.ReadAsStringAsync()
                    ' If data exists, print a substring.
                    If result IsNot Nothing Then
                        Label1.Text = result.ToString & myJson
                    End If
                End Using
            End Using
        End Using
    End Sub
End Class
