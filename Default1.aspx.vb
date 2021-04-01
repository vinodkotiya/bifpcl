Imports Common
Imports dbOp
'Imports DotNet.Highcharts
'Imports DotNet.Highcharts.Options
'Imports DotNet.Highcharts.Options.Series
'Imports DotNet.Highcharts.Attributes
'Imports DotNet.Highcharts.Helpers
'Imports DotNet.Highcharts.Enums
'Imports System.Data
'Imports System.Drawing

Partial Class _Default1
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '<########## Login MODULE
            If Request.Params("mode") = "pd@bifpcl.com" Or Request.Params("mode") = "md@bifpcl.com" Then
                Session("email") = Request.Params("mode")
            End If
            If Request.Form.Count = 1 Then
                Dim appsecret = "OdCsO1iD1OXhU6WqDHlabUyfd/viRpG5RTExYv2L1dc="
                Session("email") = Decrypt(Request.Form("email"), appsecret)
                '  divBug.InnerHtml = Session("email")
            End If
            '
            ' If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343272")

            divMobiSidmenu.InnerHtml = makemenu(True, 2)
            divSideMenu.InnerHtml = makemenu(False, 2)
            divNotification.InnerHtml = getNotification(1)
            '   divLogin.InnerHtml = showAccount("9383", "Vinod Kumar Kotiya", "vinodkotiya@ntpc.co.in")
            divLogin.InnerHtml = showAccount(Session("email"))
        End If
        executeDB("update hits set view = view+1 where page = 'home'")
        executeDB("insert into login (eid, log, logintime) values (0, 'Home Page Access : at " & Now.ToString() & " - " & Request.UserHostAddress & "', current_timestamp)", "logdb")
        '   loadChart()
    End Sub
    '    Sub loadChart()


    '        Dim plf = "<div Class='row'>"
    '        '  If Cache("gplf") Is Nothing Then
    '        Dim i = 0
    '        Dim act = 10
    '        Dim total = 2007
    '        'https://github.com/fairmat/DotNet.Highcharts/blob/master/DotNet.Highcharts/DotNet.Highcharts.Samples/Controllers/DemoController.cs

    '        Dim chart As Highcharts = New Highcharts("chart" & i.ToString).InitChart(New Chart() With {
    ' .Type = ChartTypes.Gauge,
    ' .AlignTicks = False,
    ' .PlotBackgroundColor = Nothing,
    ' .PlotBackgroundImage = Nothing,
    ' .PlotBorderWidth = 0,
    ' .PlotShadow = False,
    ' .Height = 100
    '}).SetTitle(New Title() With {
    ' .Text = "CAPEX"
    '}).SetTooltip(New Tooltip() With {
    ' .ValueSuffix = " SCH"
    '}).SetPane(New Pane() With {
    ' .StartAngle = -150,
    ' .EndAngle = 100
    '}).SetYAxis(New YAxis() {New YAxis() With {
    ' .Min = 0,
    ' .Max = 100,
    ' .LineColor = ColorTranslator.FromHtml("#339"),
    ' .TickColor = ColorTranslator.FromHtml("#339"),
    ' .MinorTickColor = ColorTranslator.FromHtml("#339"),
    ' .Offset = -25,
    ' .LineWidth = 2,
    ' .TickLength = 5,
    ' .MinorTickLength = 5,
    ' .EndOnTick = False,
    ' .Labels = New YAxisLabels() With {
    '     .Distance = -20
    '}
    '}, New YAxis() With {
    ' .Min = 0,
    ' .Max = 50,
    ' .TickPosition = TickPositions.Outside,
    ' .LineColor = ColorTranslator.FromHtml("#933"),
    ' .LineWidth = 2,
    ' .MinorTickPosition = TickPositions.Outside,
    ' .TickColor = ColorTranslator.FromHtml("#933"),
    ' .MinorTickColor = ColorTranslator.FromHtml("#933"),
    ' .TickLength = 5,
    ' .MinorTickLength = 5,
    ' .Offset = -20,
    ' .EndOnTick = False,
    ' .Labels = New YAxisLabels() With {
    '     .Distance = 12
    '}
    '}}).SetPlotOptions(New PlotOptions() With {
    ' .Gauge = New PlotOptionsGauge() With {
    '     .DataLabels = New PlotOptionsGaugeDataLabels() With {
    '         .Formatter = "function() {" & vbCr & vbLf & "                                                        var kmh = this.y," & vbCr & vbLf & vbTab & "                                                    mph = Math.round(" & act & ");" & vbCr & vbLf & vbTab & "                                                    return '<span style=color:#339>'+ kmh + ' PLF</span><br/><span style=color:#933>' + mph + ' m $</span>';" & vbCr & vbLf & "                                                    }",
    '         .BackgroundColor = New BackColorOrGradient(New Gradient() With {
    '             .LinearGradient = New Integer() {0, 0, 0, 1},
    '             .Stops = New Object(,) {{0, "#DDD"}, {1, "#FFF"}}
    '        })
    '    }
    '}
    '}).SetSeries(New Series() With {
    ' .Name = "SCH" & i.ToString,
    ' .Data = New Data(New Object() {act})
    '}).SetCredits(New Credits() With {
    '.Text = act & " ACT"})
    '        'If i Mod 4 = 0 Then plf = plf & "</div>"
    '        'If i Mod 4 = 0 Then plf = plf & "<div Class='row'>"

    '        ' plf = plf & "<div class='span3' style='width: 265px;border: dashed 1px palevioletred;  margin-top:  10px;'>" & chart.ToHtmlString() & "</div>"
    '        plf = chart.ToHtmlString()

    '        '  Next
    '        '        Cache.Insert("gplf", plf, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
    '        'End If
    '        'divPLF.InnerHtml = Cache("gplf").ToString
    '        litChart.Text = plf ' litChart.Text & Cache("gplf").ToString & "</div>"
    '        ' litChart.Text = litChart.Text & plf & "</div>"


    '    End Sub
    '    Sub loadChartGauge()


    '        Dim plf = "<div Class='row'>"
    '        '  If Cache("gplf") Is Nothing Then
    '        Dim i = 0
    '        Dim act = 10
    '        Dim total = 2007
    '        'https://github.com/fairmat/DotNet.Highcharts/blob/master/DotNet.Highcharts/DotNet.Highcharts.Samples/Controllers/DemoController.cs

    '        Dim chart As Highcharts = New Highcharts("chart" & i.ToString).InitChart(New Chart() With {
    ' .Type = ChartTypes.Gauge,
    ' .AlignTicks = False,
    ' .PlotBackgroundColor = Nothing,
    ' .PlotBackgroundImage = Nothing,
    ' .PlotBorderWidth = 0,
    ' .PlotShadow = False
    '}).SetTitle(New Title() With {
    ' .Text = "CAPEX"
    '}).SetTooltip(New Tooltip() With {
    ' .ValueSuffix = " SCH"
    '}).SetPane(New Pane() With {
    ' .StartAngle = -150,
    ' .EndAngle = 100
    '}).SetYAxis(New YAxis() {New YAxis() With {
    ' .Min = 0,
    ' .Max = 100,
    ' .LineColor = ColorTranslator.FromHtml("#339"),
    ' .TickColor = ColorTranslator.FromHtml("#339"),
    ' .MinorTickColor = ColorTranslator.FromHtml("#339"),
    ' .Offset = -25,
    ' .LineWidth = 2,
    ' .TickLength = 5,
    ' .MinorTickLength = 5,
    ' .EndOnTick = False,
    ' .Labels = New YAxisLabels() With {
    '     .Distance = -20
    '}
    '}, New YAxis() With {
    ' .Min = 0,
    ' .Max = 50,
    ' .TickPosition = TickPositions.Outside,
    ' .LineColor = ColorTranslator.FromHtml("#933"),
    ' .LineWidth = 2,
    ' .MinorTickPosition = TickPositions.Outside,
    ' .TickColor = ColorTranslator.FromHtml("#933"),
    ' .MinorTickColor = ColorTranslator.FromHtml("#933"),
    ' .TickLength = 5,
    ' .MinorTickLength = 5,
    ' .Offset = -20,
    ' .EndOnTick = False,
    ' .Labels = New YAxisLabels() With {
    '     .Distance = 12
    '}
    '}}).SetPlotOptions(New PlotOptions() With {
    ' .Gauge = New PlotOptionsGauge() With {
    '     .DataLabels = New PlotOptionsGaugeDataLabels() With {
    '         .Formatter = "function() {" & vbCr & vbLf & "                                                        var kmh = this.y," & vbCr & vbLf & vbTab & "                                                    mph = Math.round(" & act & ");" & vbCr & vbLf & vbTab & "                                                    return '<span style=color:#339>'+ kmh + ' PLF</span><br/><span style=color:#933>' + mph + ' m $</span>';" & vbCr & vbLf & "                                                    }",
    '         .BackgroundColor = New BackColorOrGradient(New Gradient() With {
    '             .LinearGradient = New Integer() {0, 0, 0, 1},
    '             .Stops = New Object(,) {{0, "#DDD"}, {1, "#FFF"}}
    '        })
    '    }
    '}
    '}).SetSeries(New Series() With {
    ' .Name = "SCH" & i.ToString,
    ' .Data = New Data(New Object() {act})
    '}).SetCredits(New Credits() With {
    '.Text = act & " ACT"})
    '        'If i Mod 4 = 0 Then plf = plf & "</div>"
    '        'If i Mod 4 = 0 Then plf = plf & "<div Class='row'>"

    '        ' plf = plf & "<div class='span3' style='width: 265px;border: dashed 1px palevioletred;  margin-top:  10px;'>" & chart.ToHtmlString() & "</div>"
    '        plf = chart.ToHtmlString()

    '        '  Next
    '        '        Cache.Insert("gplf", plf, Nothing, DateTime.Now.AddHours(1.0), TimeSpan.Zero)
    '        'End If
    '        'divPLF.InnerHtml = Cache("gplf").ToString
    '        litChart.Text = plf ' litChart.Text & Cache("gplf").ToString & "</div>"
    '        ' litChart.Text = litChart.Text & plf & "</div>"


    '    End Sub
End Class
