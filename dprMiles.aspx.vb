Imports dbOp
Imports Common
Imports System.Data
Partial Class dprMiles
    Inherits System.Web.UI.Page

    Private Sub dprMiles_Init(sender As Object, e As EventArgs) Handles Me.Init
        ''''#######Authentication Module ##################
        If Session("email") Is Nothing Then Response.Redirect("sso/Default.aspx?appid=12343266")
        '########## Login MODULE >>>>>>>>
        ''''''''Pass url or onlybifpcl for all bifplc executives
        If Not (checkAuthorization(Session("email"), "onlybifpcl") Or checkAuthorization(Session("email"), "dprm.aspx")) Then
            divMsg.InnerHtml = "Your email " & Session("email") & " don't have Authorisation to Access Milestone.<br/> May please contact TS Dept and provide your email id for authorisation."
            Exit Sub
        End If
        Dim unit = "1"
        If Not Request.Params("unit") Is Nothing Then
            unit = Request.Params("unit")
        End If
        ''''''##########################################
        divMobiSidmenu.InnerHtml = makemenu(True, 2)
        divSideMenu.InnerHtml = makemenu(False, 2, True)
        divNotification.InnerHtml = getNotification(1)
        divNotificationMobile.InnerHtml = getNotification(1, True)
        divLogin.InnerHtml = showAccount(Session("email"), True)
        divLoginMobile.InnerHtml = showAccount(Session("email"), True)
        Dim zeroDate = New DateTime(2017, 4, 24)
        Dim M As Integer = Math.Abs((Now.Year - zeroDate.Year))
        Dim curr_months As Integer = ((M * 12) + Math.Abs((Now.Month - zeroDate.Month)))

        Dim myDT = getDBTable("SELECT milestone, round(CAST ((julianday(l2date) - julianday('" & zeroDate.ToString("yyyy-MM-dd") & "'))/(365/12) AS Decimal),1) as l2Month, round(CAST ((julianday(act_ant) - julianday('2017-04-24'))/(365/12) AS Decimal),1) as antMonth , achieved  from Milestones where unit = 1 order by l2date", "dprdb")
        Dim milestones As String = String.Join(",", myDT.AsEnumerable().[Select](Function(x) "'" + x.Field(Of String)("milestone").ToString() + "'").ToArray())
        Dim l2Month As String = String.Join(",", myDT.AsEnumerable().[Select](Function(x) x.Field(Of Double)("l2Month").ToString()).ToArray())
        Dim antMonth As String = String.Join(",", myDT.AsEnumerable().[Select](Function(x) x.Field(Of Double)("antMonth") + 0.5.ToString()).ToArray())
        Dim actMonth As String = String.Join(",", myDT.AsEnumerable().[Select](Function(x) If(x("achieved") = "0", "null", x("antMonth"))))

        divMsg.InnerHtml = "Critical Issues" ' actMonth
        gvMiles.DataSource = getDBTable("SELECT milestone as Milestone, unit as Unit  , strftime('%d.%m.%Y',l2date) as 'L2 Date',  strftime('%d.%m.%Y',act_ant) as 'Act/Ant Date', achieved as 'Achieved',  strftime('%d.%m.%Y',external) as 'External Date' from Milestones  where unit=" & unit, "dprdb")
        gvMiles.DataBind()
        Dim scriptStr = " $(document).ready(function(){  var myChart =Highcharts.chart('container', { " & vbCrLf &
"    title: { " & vbCrLf &
"          text: 'BIFPCL Maitree STPP (2X660 MW)' " & vbCrLf &
"      }, " & vbCrLf &
"      subtitle: { " & vbCrLf &
"          text: 'Zero Date: " & zeroDate.ToString("dd.MM.y") & " <b>Unit#1</b>'" & vbCrLf &
"      }, " & vbCrLf &
"      yAxis: { " & vbCrLf &
"        gridLineWidth: 0, " & vbCrLf &
"          title: { " & vbCrLf &
"              text: 'Month' " & vbCrLf &
"          }, " & vbCrLf &
"          plotLines: [{ " & vbCrLf &
"              color: 'red', " & vbCrLf &
"              width: 2, " & vbCrLf &
"                dashStyle: 'longdashdot', " & vbCrLf &
 "             value: " & curr_months & ", " & vbCrLf &
 "             label: { " & vbCrLf &
 "                 align: 'right', " & vbCrLf &
"                  text: 'Cur Month 16', " & vbCrLf &
"                  style: { " & vbCrLf &
"                      color: 'blue', " & vbCrLf &
"                      fontWeight: 'bold' " & vbCrLf &
 "                 } " & vbCrLf &
 "             } " & vbCrLf &
"          }] " & vbCrLf &
"      }, " & vbCrLf &
"      xAxis: { " & vbCrLf &
"          categories: [" & milestones & "], " & vbCrLf &
 "       gridLineWidth: 1, " & vbCrLf &
"      labels: { " & vbCrLf &
"      style: { " & vbCrLf &
"                  color: 'Black' " & vbCrLf &
"              }, " & vbCrLf &
 "         useHTML: true, " & vbCrLf &
 "         formatter: function() {  " & vbCrLf &
 "             if(this.value == 'Boiler Erection Start') " & vbCrLf &
 "                return this.value + '<img src=images/tick.png  style=" & Chr(34) & "width: 30px; z-index:1000; vertical-align: middle" & Chr(34) & " />'; " & vbCrLf &
"             else  " & vbCrLf &
"                 return this.value +'<img src=images/flipboard.png style=" & Chr(34) & "width: 30px; vertical-align: middle" & Chr(34) & " />'; " & vbCrLf &
"          } " & vbCrLf &
"      }, " & vbCrLf &
"  }, " & vbCrLf &
"      legend: { " & vbCrLf &
 "         layout: 'vertical', " & vbCrLf &
 "         align: 'right', " & vbCrLf &
 "         verticalAlign: 'middle' " & vbCrLf &
 "     }, " & vbCrLf &
 "     series: [{ " & vbCrLf &
 "         name: 'Scheduled', " & vbCrLf &
 "         data: [" & l2Month & "] " & vbCrLf &
 "     },  " & vbCrLf &
 "       { " & vbCrLf &
 "         name: 'Actual', " & vbCrLf &
 "           data: [" & actMonth & "], " & vbCrLf &
 "          color: 'green' " & vbCrLf &
 "     }, { " & vbCrLf &
 "         name: 'Anticipated', " & vbCrLf &
 "           data: [" & antMonth & "], " & vbCrLf &
 "          color: 'orange' " & vbCrLf &
  "        }], " & vbCrLf &
 "   responsive: { " & vbCrLf &
 "         rules: [{ " & vbCrLf &
 "             condition: { " & vbCrLf &
 "                 maxWidth: 1000 " & vbCrLf &
 "             }, " & vbCrLf &
 "             chartOptions: { " & vbCrLf &
  "                legend: { " & vbCrLf &
  "                    layout: 'horizontal', " & vbCrLf &
 "                     align: 'center', " & vbCrLf &
  "                    verticalAlign: 'bottom' " & vbCrLf &
 "                 } " & vbCrLf &
 "             } " & vbCrLf &
 "        }] " & vbCrLf &
  "    } " & vbCrLf &
 "    }); " & vbCrLf &
  "    }); "
        ClientScript.RegisterStartupScript(Me.GetType(), "CounterScript", scriptStr, True)

    End Sub
    Sub script()
        Dim scriptStr = " $(document).ready(function(){  var myChart =Highcharts.chart('container', { " & vbCrLf &
"    title: { " & vbCrLf &
"          text: 'BIFPCL Maitree STPP (2X660 MW)' " & vbCrLf &
"      }, " & vbCrLf &
"      subtitle: { " & vbCrLf &
"          text: 'Zero Date: 24.04.2017' " & vbCrLf &
"      }, " & vbCrLf &
"      yAxis: { " & vbCrLf &
"        gridLineWidth: 0, " & vbCrLf &
"          title: { " & vbCrLf &
"              text: 'Month' " & vbCrLf &
"          }, " & vbCrLf &
"          plotLines: [{ " & vbCrLf &
"              color: 'red', " & vbCrLf &
"              width: 2, " & vbCrLf &
"                dashStyle: 'longdashdot', " & vbCrLf &
 "             value: 16, " & vbCrLf &
 "             label: { " & vbCrLf &
 "                 align: 'right', " & vbCrLf &
"                  text: 'Cur Month 16', " & vbCrLf &
"                  style: { " & vbCrLf &
"                      color: 'blue', " & vbCrLf &
"                      fontWeight: 'bold' " & vbCrLf &
 "                 } " & vbCrLf &
 "             } " & vbCrLf &
"          }] " & vbCrLf &
"      }, " & vbCrLf &
"      xAxis: { " & vbCrLf &
"          categories: ['Boiler Erection Start', 'Boiler Ceiling Girder Erection', 'Condenser Erection Start', 'Turbine Erection  Start', 'Boiler Hydro Test', 'TG Box Up', " & vbCrLf &
"              'Boiler light up & Chemical cleaning', 'TG Oil Flushing', 'TG Barring', 'Steam Blowing', 'Synchronization',  'Reliability Test Run','PAC'], " & vbCrLf &
 "       gridLineWidth: 1, " & vbCrLf &
"      labels: { " & vbCrLf &
"      style: { " & vbCrLf &
"                  color: 'Black' " & vbCrLf &
"              }, " & vbCrLf &
 "         useHTML: true, " & vbCrLf &
 "         formatter: function() {  " & vbCrLf &
 "             if(this.value == 'Boiler Erection Start') " & vbCrLf &
 "                return this.value + '<img src=images/tick.png  style=" & Chr(34) & "width: 30px; vertical-align: middle" & Chr(34) & " />'; " & vbCrLf &
"             else  " & vbCrLf &
"                 return this.value +'<img src=images/flipboard.png style=" & Chr(34) & "width: 30px; vertical-align: middle" & Chr(34) & " />'; " & vbCrLf &
"          } " & vbCrLf &
"      }, " & vbCrLf &
"  }, " & vbCrLf &
"      legend: { " & vbCrLf &
 "         layout: 'vertical', " & vbCrLf &
 "         align: 'right', " & vbCrLf &
 "         verticalAlign: 'middle' " & vbCrLf &
 "     }, " & vbCrLf &
 "     series: [{ " & vbCrLf &
 "         name: 'Scheduled', " & vbCrLf &
 "         data: [14, 19, 20, 24, 27, 35, 36, 37,38,39,41,45,46] " & vbCrLf &
 "     },  " & vbCrLf &
 "       { " & vbCrLf &
 "         name: 'Actual', " & vbCrLf &
 "           data: [14.5, null, null, null, null, null, null, null, null, null, null, null, null], " & vbCrLf &
 "          color: 'green' " & vbCrLf &
 "     }, { " & vbCrLf &
 "         name: 'Anticipated', " & vbCrLf &
 "           data: [15, 19.3, 20.5, 24, 27, 35, 36, 37, 38, 39, 41, 45, 46], " & vbCrLf &
 "          color: 'orange' " & vbCrLf &
  "        }], " & vbCrLf &
 "   responsive: { " & vbCrLf &
 "         rules: [{ " & vbCrLf &
 "             condition: { " & vbCrLf &
 "                 maxWidth: 1000 " & vbCrLf &
 "             }, " & vbCrLf &
 "             chartOptions: { " & vbCrLf &
  "                legend: { " & vbCrLf &
  "                    layout: 'horizontal', " & vbCrLf &
 "                     align: 'center', " & vbCrLf &
  "                    verticalAlign: 'bottom' " & vbCrLf &
 "                 } " & vbCrLf &
 "             } " & vbCrLf &
 "        }] " & vbCrLf &
  "    } " & vbCrLf &
 "    }); " & vbCrLf &
  "    }); "
        ' ClientScript.RegisterStartupScript(Me.GetType(), "CounterScript", scriptStr, True)

    End Sub

    Private Sub rblUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblUnit.SelectedIndexChanged
        Response.Redirect("dprMiles.aspx?unit=" & rblUnit.SelectedValue)
    End Sub
End Class
