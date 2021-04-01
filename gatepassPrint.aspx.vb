  Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Drawing.Font
Imports System.Configuration
Imports Font = iTextSharp.text.Font
Imports QRCoder
Imports Image = System.Drawing.Image
Imports System.Data
Imports dbOp
Partial Class gatepassPrint
    Inherits System.Web.UI.Page

    Private Sub gatepassPrint_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request.Params("mode") = "cover" Then
            printCover(Request.Params("type"), HttpUtility.UrlDecode(Request.Params("agency")), Request.Params("passtype"))
        ElseIf Request.Params("mode") = "leave" Then
            printLeave()
        ElseIf Request.Params("mode") = "vehicle" Then
            printVehicle(Request.Params("id").ToString)
        ElseIf Request.Params("mode") = "application" Then
            printApplication()
        ElseIf Request.Params("mode") = "admitcard" Then
            printAdmitCard()
        ElseIf Request.Params("mode") = "admitcardall" Then
            printAdmitCardAll(Request.Params("stage").ToString, Request.Params("phase").ToString)
        ElseIf Request.Params("mode") = "attendance" Then
            printAttendance(Request.Params("stage").ToString, Request.Params("phase").ToString)
        ElseIf Request.Params("mode") = "attendance" Then
            printAttendance(Request.Params("stage").ToString, Request.Params("phase").ToString)
        ElseIf Request.Params("mode") = "rating" Then
            Dim appid = ""
            If Not Request.Params("appid") Is Nothing Then appid = Request.Params("appid").ToString
            printRatingAll(Request.Params("stage").ToString, Request.Params("phase").ToString, appid)
        ElseIf Request.Params("mode") = "rating3int" Then
            Dim appid = ""
            If Not Request.Params("appid") Is Nothing Then appid = Request.Params("appid").ToString
            printRatingAll3Int(Request.Params("phase").ToString, Request.Params("dt").ToString, Request.Params("tm").ToString, appid)
        Else
            printID()
        End If

    End Sub
    Sub printRatingAll3Int(ByVal phase As String, ByVal i_dt As String, ByVal i_time As String, Optional ByVal Printappid As String = "")
        '  stage = "written"
        ' Printappid = "2008190658025"
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."
        Dim filterAppID = ""
        If Not String.IsNullOrEmpty(Printappid) Then filterAppID = " and appid = '" & Printappid & "' "
        Dim qAll = "select distinct appid from careers_application where last_updated > '2019-04-05' and status = 'Submit' and stage = 'interview' and phase = '" & phase & "' and  venue_i_dt like '%" & i_dt & "%' and venue_i_time like '%" & i_time & "%' " & filterAppID & " and not i1a = 0 order by jobid, venue_i_dt, merit,  slot asc"  'appid in ('2404190440167','3004190241007','2204192257397','1704192141027','2104190234093','2104190220136')
        Dim myDT = getDBTable(qAll, "appsdb")
        If myDT.Rows.Count < 1 Then
            divMsg.InnerHtml = "No Records found " & qAll
            Exit Sub
        End If
        Try
            Dim doc As New Document(PageSize.A4, 40.0F, 10.0F, 30.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()

                For Each rID In myDT.Rows
                    Dim appID = rID(0)

                    Dim q = "select jobid, cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) as Age, salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',ncert as 'ncert', address || ' ' || district || ' Postal Code-' || pin as 'addressc',addressp || ' ' || districtp as 'addressp',exptype || ' Sector '  as 'workexp', org || ', ' || desig  || ', From ' || durationfrom || ' To ' || durationto as 'Detail',deptcand ,freedom , relative , draft , resume, qual1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', strftime('%d.%m.%Y',last_updated) as last_updated, aid, rollno,  ratessc, ratehsc,rategrad,ratepg,ratediploma,i1a,i1b,i1c,i1d, i1rem, i2a,i2b,i2c,i2d, i2rem , i3a,i3b,i3c,i3d, i3rem, i4a,i4b,i4c,i4d, i4rem, i5a,i5b,i5c,i5d, i5rem  from careers_application where  appid = '" & appID & "' and stage = 'interview'  limit 1"

                    Dim dt = getDBTable(q, "appsdb")
                    If dt.Rows.Count < 1 Then
                        divMsg.InnerHtml = "No Records found for requested admit ID load failed.." & appID
                        Exit Sub
                    End If
                    Dim jobid = If(IsDBNull(dt.Rows(0)("jobid")), "", dt.Rows(0)("jobid"))
                    Dim jobdetail = getDBsingle("select replace(post, X'0A', ' ') from careers_jobs where jobid = " & jobid, "appsdb")
                    Dim minQual = getDBsingle("select minQual from careers_jobs where jobid = " & jobid, "appsdb")
                    ' jobdetail = jobdetail.Replace(vbCrLf, " ")
                    Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
                    Dim name = If(IsDBNull(dt.Rows(0)("name")), "", dt.Rows(0)("name"))
                    Dim father = If(IsDBNull(dt.Rows(0)("father")), "", dt.Rows(0)("father"))
                    Dim sex = If(IsDBNull(dt.Rows(0)("sex")), "", dt.Rows(0)("sex"))
                    Dim Contact = If(IsDBNull(dt.Rows(0)("Contact")), "", dt.Rows(0)("Contact"))
                    Dim dob = If(IsDBNull(dt.Rows(0)("dob")), "", dt.Rows(0)("dob"))
                    Dim age = If(IsDBNull(dt.Rows(0)("age")), "", dt.Rows(0)("age"))
                    'Dim nid = If(IsDBNull(dt.Rows(0)("nid")), "", dt.Rows(0)("nid"))
                    'Dim ncert = If(IsDBNull(dt.Rows(0)("ncert")), "", dt.Rows(0)("ncert"))
                    Dim addressc = If(IsDBNull(dt.Rows(0)("addressc")), "", dt.Rows(0)("addressc"))
                    'Dim addressp = If(IsDBNull(dt.Rows(0)("addressp")), "", dt.Rows(0)("addressp"))
                    Dim workexp = If(IsDBNull(dt.Rows(0)("workexp")), "", dt.Rows(0)("workexp"))
                    'Dim Detail = If(IsDBNull(dt.Rows(0)("Detail")), "", dt.Rows(0)("Detail"))
                    'Dim deptcand = If(IsDBNull(dt.Rows(0)("deptcand")), "", dt.Rows(0)("deptcand"))
                    'Dim freedom = If(IsDBNull(dt.Rows(0)("freedom")), "", dt.Rows(0)("freedom"))
                    'Dim relative = If(IsDBNull(dt.Rows(0)("relative")), "", dt.Rows(0)("relative"))
                    'Dim draft = If(IsDBNull(dt.Rows(0)("draft")), "", dt.Rows(0)("draft"))
                    'Dim resume1 = If(IsDBNull(dt.Rows(0)("resume")), "", dt.Rows(0)("resume"))
                    Dim qualification1 = If(IsDBNull(dt.Rows(0)("qualification1")), "", dt.Rows(0)("qualification1"))
                    Dim qualification2 = If(IsDBNull(dt.Rows(0)("qualification2")), "", dt.Rows(0)("qualification2"))
                    Dim qualification3 = If(IsDBNull(dt.Rows(0)("qualification3")), "", dt.Rows(0)("qualification3"))
                    If qualification3.ToString.StartsWith("NA") Then qualification3 = ""
                    Dim qualification4 = If(IsDBNull(dt.Rows(0)("qualification4")), "", dt.Rows(0)("qualification4"))
                    If qualification4.ToString.StartsWith("NA") Then qualification4 = ""
                    Dim qualification5 = If(IsDBNull(dt.Rows(0)("qualification5")), "", dt.Rows(0)("qualification5"))
                    If qualification5.ToString.StartsWith("NA") Then qualification5 = ""
                    Dim last_updated = If(IsDBNull(dt.Rows(0)("last_updated")), "", dt.Rows(0)("last_updated"))
                    Dim aid = If(IsDBNull(dt.Rows(0)("aid")), "", dt.Rows(0)("aid"))
                    Dim rollno = If(IsDBNull(dt.Rows(0)("rollno")), "", dt.Rows(0)("rollno"))

                    Dim ratessc = If(IsDBNull(dt.Rows(0)("ratessc")), 0.0, Double.Parse(dt.Rows(0)("ratessc").ToString))
                    Dim ratehsc = If(IsDBNull(dt.Rows(0)("ratehsc")), 0.0, Double.Parse(dt.Rows(0)("ratehsc").ToString))
                    Dim rategrad = If(IsDBNull(dt.Rows(0)("rategrad")), 0.0, Double.Parse(dt.Rows(0)("rategrad").ToString))
                    Dim ratepg = If(IsDBNull(dt.Rows(0)("ratepg")), 0.0, Double.Parse(dt.Rows(0)("ratepg").ToString))
                    Dim ratediploma = If(IsDBNull(dt.Rows(0)("ratediploma")), 0.0, Double.Parse(dt.Rows(0)("ratediploma").ToString))
                    Dim hscOrDip = ratehsc
                    If ratehsc = 0 Then hscOrDip = Math.Round(ratediploma * 1.25, 2)
                    Dim calculationText = ""
                    Dim totalEd = 0.0
                    Try
                        If minQual = "Graduate" Then
                            calculationText = "Calculations" & vbLf & "Total = a + b + (c*1.25)"
                            totalEd = Math.Round(ratessc + hscOrDip + (1.25 * rategrad), 2)
                        Else
                            calculationText = "Calculations" & vbLf & "Total = (a+b)*0.7 + c + d"
                            totalEd = Math.Round(((ratessc + hscOrDip) * 0.7) + rategrad + ratepg, 2)
                        End If
                    Catch exm As Exception
                        calculationText = "Error in calculation " & exm.Message
                    End Try

                    Dim i1a = If(IsDBNull(dt.Rows(0)("i1a")), 0.0, Double.Parse(dt.Rows(0)("i1a").ToString))
                    Dim i1b = If(IsDBNull(dt.Rows(0)("i1b")), 0.0, Double.Parse(dt.Rows(0)("i1b").ToString))
                    Dim i1c = If(IsDBNull(dt.Rows(0)("i1c")), 0.0, Double.Parse(dt.Rows(0)("i1c").ToString))
                    Dim i1d = If(IsDBNull(dt.Rows(0)("i1d")), 0.0, Double.Parse(dt.Rows(0)("i1d").ToString))
                    Dim i1rem = If(IsDBNull(dt.Rows(0)("i1rem")), "", dt.Rows(0)("i1rem"))
                    Dim i2a = If(IsDBNull(dt.Rows(0)("i2a")), 0.0, Double.Parse(dt.Rows(0)("i2a").ToString))
                    Dim i2b = If(IsDBNull(dt.Rows(0)("i2b")), 0.0, Double.Parse(dt.Rows(0)("i2b").ToString))
                    Dim i2c = If(IsDBNull(dt.Rows(0)("i2c")), 0.0, Double.Parse(dt.Rows(0)("i2c").ToString))
                    Dim i2d = If(IsDBNull(dt.Rows(0)("i2d")), 0.0, Double.Parse(dt.Rows(0)("i2d").ToString))
                    Dim i2rem = If(IsDBNull(dt.Rows(0)("i2rem")), "", dt.Rows(0)("i2rem"))
                    Dim i3a = If(IsDBNull(dt.Rows(0)("i3a")), 0.0, Double.Parse(dt.Rows(0)("i3a").ToString))
                    Dim i3b = If(IsDBNull(dt.Rows(0)("i3b")), 0.0, Double.Parse(dt.Rows(0)("i3b").ToString))
                    Dim i3c = If(IsDBNull(dt.Rows(0)("i3c")), 0.0, Double.Parse(dt.Rows(0)("i3c").ToString))
                    Dim i3d = If(IsDBNull(dt.Rows(0)("i3d")), 0.0, Double.Parse(dt.Rows(0)("i3d").ToString))
                    Dim i3rem = If(IsDBNull(dt.Rows(0)("i3rem")), "", dt.Rows(0)("i3rem"))
                    Dim i4a = If(IsDBNull(dt.Rows(0)("i4a")), 0.0, Double.Parse(dt.Rows(0)("i4a").ToString))
                    Dim i4b = If(IsDBNull(dt.Rows(0)("i4b")), 0.0, Double.Parse(dt.Rows(0)("i4b").ToString))
                    Dim i4c = If(IsDBNull(dt.Rows(0)("i4c")), 0.0, Double.Parse(dt.Rows(0)("i4c").ToString))
                    Dim i4d = If(IsDBNull(dt.Rows(0)("i4d")), 0.0, Double.Parse(dt.Rows(0)("i4d").ToString))
                    Dim i4rem = If(IsDBNull(dt.Rows(0)("i4rem")), "", dt.Rows(0)("i4rem"))
                    Dim i5a = If(IsDBNull(dt.Rows(0)("i5a")), 0.0, Double.Parse(dt.Rows(0)("i5a").ToString))
                    Dim i5b = If(IsDBNull(dt.Rows(0)("i5b")), 0.0, Double.Parse(dt.Rows(0)("i5b").ToString))
                    Dim i5c = If(IsDBNull(dt.Rows(0)("i5c")), 0.0, Double.Parse(dt.Rows(0)("i5c").ToString))
                    Dim i5d = If(IsDBNull(dt.Rows(0)("i5d")), 0.0, Double.Parse(dt.Rows(0)("i5d").ToString))
                    Dim i5rem = If(IsDBNull(dt.Rows(0)("i5rem")), "", dt.Rows(0)("i5rem"))
                    Dim i1Total = i1a + i1b + i1c + i1d
                    Dim i2Total = i2a + i2b + i2c + i2d
                    Dim i3Total = i3a + i3b + i3c + i3d
                    Dim i4Total = i4a + i4b + i4c + i4d
                    Dim i5Total = i5a + i5b + i5c + i5d
                    Dim iterviewer = 1
                    If i1Total > 0 Then iterviewer = 1
                    If i2Total > 0 Then iterviewer = iterviewer + 1
                    If i3Total > 0 Then iterviewer = iterviewer + 1
                    If i4Total > 0 Then iterviewer = iterviewer + 1
                    If i5Total > 0 Then iterviewer = iterviewer + 1

                    Dim total = Math.Round((i1Total + i2Total + i3Total + i4Total + i5Total) / iterviewer, 2)
                    '''''###############################################
                    '''  
                    ''' 
                    Dim ref = "1. General Information" 'last_updated 'Now.ToString("dd.MM.yyyy")


                    '  doc.NewPage()
                    ''' Loop through Page 1
                    ''' 
                    Dim j = 0
                    Dim idCardPerPage = 25
                    Dim t2Horizontal = 0
                    Dim tVertical = 0
                    Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                    Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                    Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                    Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                    Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                    Dim phrase As Phrase = Nothing
                    Dim cell As PdfPCell = Nothing
                    Dim table As PdfPTable = Nothing
                    Dim color__1 As BaseColor = Nothing




                    'reference Details
                    Dim htable = New PdfPTable(2)
                    htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                    htable.TotalWidth = 460.0F
                    htable.SetWidths(New Single() {60.0F, 400.0F})

                    Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                    'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                    Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    pic.ScaleAbsolute(60.0F, 60.0F)
                    cell = New PdfPCell(pic)
                    cell.BorderColor = BaseColor.WHITE
                    htable.AddCell(cell)

                    table = New PdfPTable(6)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.2F, 0.3F, 0.4F, 0.4F, 0.4F, 0.3F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90

                    phrase = New Phrase()
                    phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                    ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
                    'cell.Colspan = 2
                    htable.AddCell(cell)
                    doc.Add(htable)
                    'Separater Line
                    color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                    DrawLine(writer, 25.0F, doc.Top - 59.0F, doc.PageSize.Width - 25.0F, doc.Top - 59.0F, color__1)
                    DrawLine(writer, 25.0F, doc.Top - 60.0F, doc.PageSize.Width - 25.0F, doc.Top - 60.0F, color__1)
                    Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                    cellBlank.Colspan = 2
                    cellBlank.PaddingBottom = 8.0F
                    ' table.AddCell(cellBlank)
                    Dim btable = New PdfPTable(3)
                    btable.HorizontalAlignment = Element.ALIGN_LEFT
                    btable.TotalWidth = 460.0F
                    btable.SetWidths(New Single() {130.0F, 190.0F, 120.0F})
                    btable.SpacingBefore = 2.0F
                    btable.WidthPercentage = 90


                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("Interview Rating Sheet", FontFactory.GetFont("Arial", 16, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.Colspan = 3
                    'cell.BorderColor = BaseColor.BLACK
                    ' cell.Rowspan = 2
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    ' cell.BorderColor = BaseColor.BLACK
                    cell.Colspan = 2
                    ' cell.HorizontalAlignment = Element.ALIGN_CENTER
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Roll Number:" & vbLf & rollno, FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE
                    cell.Rowspan = 8
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    cell = PhraseCell(New Phrase("Post Name:   ", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(jobdetail, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("  ", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Name of Candidate: ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Date of Birth: ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(dob & " (" & age & " Yrs.)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    cell = PhraseCell(New Phrase("Education Qualification:  ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 5
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification2, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification3, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification4, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification5, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    doc.Add(btable)
                    'phrase = New Phrase()
                    '' phrase.Add(New Chunk("Sub: Admit Card for the post of " & jobdetail & " of BIFPCL" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("2. Indicator for Candidate’s Academic Result & Working Experience: [Academic Result-25; Working Experience-20] " & vbLf, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, BaseColor.BLACK)))
                    'doc.Add(phrase)

                    '''
                    'cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    'cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("2. Marks Obtained In Educational Qualification:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 6
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Qualifying Degree", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 2
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("CGPA/GPA Obtained:", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Colspan = 4
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(calculationText, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 2
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("S.S.C (Out of 5)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("H.S.C (Out of 5)/Diploma (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Graduation (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("PostGraduation (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    ' End If

                    cell = PhraseCell(New Phrase(minQual, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(ratessc.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(hscOrDip.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(rategrad.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(ratepg.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(totalEd.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)

                    '###########
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(a)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(b)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(c)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(d)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sub Total Marks Obtained(Out of 15)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)

                    ''
                    ' table.AddCell(cellBlank)
                    doc.Add(table)
                    table = New PdfPTable(8)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.1F, 0.3F, 0.2F, 0.3F, 0.3F, 0.3F, 0.3F, 0.3F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90
                    cell = PhraseCell(New Phrase("3. Marks Obtained In Viva Voce:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 8
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sl.", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Item", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Max Marks", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Interviewer 1", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Interviewer 2", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Interviewer 3", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Interviewer 4", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Interviewer 5", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("A.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("General Knowledge &; Awareness", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("8", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1a, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2a, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3a, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4a, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5a, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("B.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Ability to Communicate in English", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1b, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2b, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3b, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4b, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5b, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("C.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Professional Knowledge", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1c, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2c, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3c, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4c, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5c, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("D.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Personality, Confidence & Attitude", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1d, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2d, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3d, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4d, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5d, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("E.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Remarks", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("-", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1rem, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2rem, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3rem, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4rem, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5rem, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sub Total", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("35", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i1Total, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i2Total, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i3Total, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i4Total, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(i5Total, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Signature" & vbCrLf & "." & vbCrLf & "." & vbCrLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    cell.Colspan = 2
                    table.AddCell(cell)

                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    doc.Add(table)
                    '#####
                    table = New PdfPTable(5)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.1F, 0.5F, 0.3F, 0.3F, 0.5F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90
                    cell = PhraseCell(New Phrase("4. Total Marks Obtained In Educational Qualification and Viva Voce:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 5
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sl.", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Item", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Maximum Marks", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Marks Obtained", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Comments(if any)", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("A.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Educational Qualification", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("15", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(totalEd.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("B.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Viva Voce", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("35", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(total.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)

                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Grand Total(Sub Total 2+Sub Total 3)", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("50", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase((totalEd + total).ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    doc.Add(table)
                    phrase = New Phrase()
                    'phrase.Add(New Chunk("You are requested to attend the " & str1 & " as per above schedule." & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("No TA/DA will be paid for participating in this " & str1 & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("-" & vbLf & vbLf & vbLf & vbLf & appID.ToString, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    doc.Add(phrase)

                    'phrase = New Phrase()
                    'phrase.Add(New Chunk("(Mohammad Mujtaba Tabrez)" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("DGM (HR), BIFPCL" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("E-mail: help@bifpcl.com" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))

                    'phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("For any queries, feel free to reach us at: +88028321607-Ext 112,108 or write to us at: help@bifpcl.com " & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)))


                    'doc.Add(phrase)


                    doc.NewPage()

                    ' Exit For
                Next

                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=ratingcardAll" & Printappid & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printRatingAll(ByVal stage As String, ByVal phase As String, Optional ByVal Printappid As String = "")
        '  stage = "written"
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."
        Dim filterAppID = ""
        If Not String.IsNullOrEmpty(Printappid) Then filterAppID = " and appid = '" & Printappid & "' "
        Dim qAll = "select distinct appid from careers_application where last_updated > '2019-04-05' and status = 'Submit' and  phase = '" & phase & "' and stage = '" & stage & "' " & filterAppID & " order by jobid, venue_i_dt, merit,  slot asc"  'appid in ('2404190440167','3004190241007','2204192257397','1704192141027','2104190234093','2104190220136')
        Dim myDT = getDBTable(qAll, "appsdb")
        If myDT.Rows.Count < 1 Then
            divMsg.InnerHtml = "No Records found " & qAll
            Exit Sub
        End If
        Try
            Dim doc As New Document(PageSize.A4, 40.0F, 10.0F, 30.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()

                For Each rID In myDT.Rows
                    Dim appID = rID(0)

                    Dim q = "select jobid, cast(strftime('%Y.%m%d', 'now') - strftime('%Y.%m%d', dob) as int) as Age, salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',ncert as 'ncert', address || ' ' || district || ' Postal Code-' || pin as 'addressc',addressp || ' ' || districtp as 'addressp',exptype || ' Sector '  as 'workexp', org || ', ' || desig  || ', From ' || durationfrom || ' To ' || durationto as 'Detail',deptcand ,freedom , relative , draft , resume, qual1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', strftime('%d.%m.%Y',last_updated) as last_updated, aid, rollno,  ratessc, ratehsc,rategrad,ratepg,ratediploma  from careers_application where  appid = '" & appID & "' and stage = '" & stage & "'  limit 1"

                    Dim dt = getDBTable(q, "appsdb")
                    If dt.Rows.Count < 1 Then
                        divMsg.InnerHtml = "No Records found for requested admit ID load failed.." & appID
                        Exit Sub
                    End If
                    Dim jobid = If(IsDBNull(dt.Rows(0)("jobid")), "", dt.Rows(0)("jobid"))
                    Dim jobdetail = getDBsingle("select replace(post, X'0A', ' ') from careers_jobs where jobid = " & jobid, "appsdb")
                    Dim minQual = getDBsingle("select minQual from careers_jobs where jobid = " & jobid, "appsdb")
                    ' jobdetail = jobdetail.Replace(vbCrLf, " ")
                    Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
                    Dim name = If(IsDBNull(dt.Rows(0)("name")), "", dt.Rows(0)("name"))
                    Dim father = If(IsDBNull(dt.Rows(0)("father")), "", dt.Rows(0)("father"))
                    Dim sex = If(IsDBNull(dt.Rows(0)("sex")), "", dt.Rows(0)("sex"))
                    Dim Contact = If(IsDBNull(dt.Rows(0)("Contact")), "", dt.Rows(0)("Contact"))
                    Dim dob = If(IsDBNull(dt.Rows(0)("dob")), "", dt.Rows(0)("dob"))
                    Dim age = If(IsDBNull(dt.Rows(0)("age")), "", dt.Rows(0)("age"))
                    'Dim nid = If(IsDBNull(dt.Rows(0)("nid")), "", dt.Rows(0)("nid"))
                    'Dim ncert = If(IsDBNull(dt.Rows(0)("ncert")), "", dt.Rows(0)("ncert"))
                    Dim addressc = If(IsDBNull(dt.Rows(0)("addressc")), "", dt.Rows(0)("addressc"))
                    'Dim addressp = If(IsDBNull(dt.Rows(0)("addressp")), "", dt.Rows(0)("addressp"))
                    Dim workexp = If(IsDBNull(dt.Rows(0)("workexp")), "", dt.Rows(0)("workexp"))
                    'Dim Detail = If(IsDBNull(dt.Rows(0)("Detail")), "", dt.Rows(0)("Detail"))
                    'Dim deptcand = If(IsDBNull(dt.Rows(0)("deptcand")), "", dt.Rows(0)("deptcand"))
                    'Dim freedom = If(IsDBNull(dt.Rows(0)("freedom")), "", dt.Rows(0)("freedom"))
                    'Dim relative = If(IsDBNull(dt.Rows(0)("relative")), "", dt.Rows(0)("relative"))
                    'Dim draft = If(IsDBNull(dt.Rows(0)("draft")), "", dt.Rows(0)("draft"))
                    'Dim resume1 = If(IsDBNull(dt.Rows(0)("resume")), "", dt.Rows(0)("resume"))
                    Dim qualification1 = If(IsDBNull(dt.Rows(0)("qualification1")), "", dt.Rows(0)("qualification1"))
                    Dim qualification2 = If(IsDBNull(dt.Rows(0)("qualification2")), "", dt.Rows(0)("qualification2"))
                    Dim qualification3 = If(IsDBNull(dt.Rows(0)("qualification3")), "", dt.Rows(0)("qualification3"))
                    If qualification3.ToString.StartsWith("NA") Then qualification3 = ""
                    Dim qualification4 = If(IsDBNull(dt.Rows(0)("qualification4")), "", dt.Rows(0)("qualification4"))
                    If qualification4.ToString.StartsWith("NA") Then qualification4 = ""
                    Dim qualification5 = If(IsDBNull(dt.Rows(0)("qualification5")), "", dt.Rows(0)("qualification5"))
                    If qualification5.ToString.StartsWith("NA") Then qualification5 = ""
                    Dim last_updated = If(IsDBNull(dt.Rows(0)("last_updated")), "", dt.Rows(0)("last_updated"))
                    Dim aid = If(IsDBNull(dt.Rows(0)("aid")), "", dt.Rows(0)("aid"))
                    Dim rollno = If(IsDBNull(dt.Rows(0)("rollno")), "", dt.Rows(0)("rollno"))

                    Dim ratessc = If(IsDBNull(dt.Rows(0)("ratessc")), 0.0, Double.Parse(dt.Rows(0)("ratessc").ToString))
                    Dim ratehsc = If(IsDBNull(dt.Rows(0)("ratehsc")), 0.0, Double.Parse(dt.Rows(0)("ratehsc").ToString))
                    Dim rategrad = If(IsDBNull(dt.Rows(0)("rategrad")), 0.0, Double.Parse(dt.Rows(0)("rategrad").ToString))
                    Dim ratepg = If(IsDBNull(dt.Rows(0)("ratepg")), 0.0, Double.Parse(dt.Rows(0)("ratepg").ToString))
                    Dim ratediploma = If(IsDBNull(dt.Rows(0)("ratediploma")), 0.0, Double.Parse(dt.Rows(0)("ratediploma").ToString))
                    Dim hscOrDip = ratehsc
                    If ratehsc = 0 Then hscOrDip = ratediploma * 1.25
                    Dim calculationText = ""
                    Dim totalEd = 0.0
                    Try
                        If minQual = "Graduate" Then
                            calculationText = "Calculations" & vbLf & "Total = a + b + (c*1.25)"
                            totalEd = Math.Round(ratessc + hscOrDip + (1.25 * rategrad), 2)
                        Else
                            calculationText = "Calculations" & vbLf & "Total = (a+b)*0.7 + c + d"
                            totalEd = Math.Round(((ratessc + hscOrDip) * 0.7) + rategrad + ratepg, 2)
                        End If
                    Catch exm As Exception
                        calculationText = "Error in calculation " & exm.Message
                    End Try
                    '''''###############################################
                    '''  
                    ''' 
                    Dim ref = "1. General Information" 'last_updated 'Now.ToString("dd.MM.yyyy")


                    '  doc.NewPage()
                    ''' Loop through Page 1
                    ''' 
                    Dim j = 0
                    Dim idCardPerPage = 25
                    Dim t2Horizontal = 0
                    Dim tVertical = 0
                    Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                    Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                    Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                    Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                    Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                    Dim phrase As Phrase = Nothing
                    Dim cell As PdfPCell = Nothing
                    Dim table As PdfPTable = Nothing
                    Dim color__1 As BaseColor = Nothing




                    'reference Details
                    Dim htable = New PdfPTable(2)
                    htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                    htable.TotalWidth = 460.0F
                    htable.SetWidths(New Single() {60.0F, 400.0F})

                    Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                    'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                    Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    pic.ScaleAbsolute(60.0F, 60.0F)
                    cell = New PdfPCell(pic)
                    cell.BorderColor = BaseColor.WHITE
                    htable.AddCell(cell)

                    table = New PdfPTable(6)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.2F, 0.3F, 0.4F, 0.4F, 0.4F, 0.3F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90

                    phrase = New Phrase()
                    phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                    ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
                    'cell.Colspan = 2
                    htable.AddCell(cell)
                    doc.Add(htable)
                    'Separater Line
                    color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                    DrawLine(writer, 25.0F, doc.Top - 59.0F, doc.PageSize.Width - 25.0F, doc.Top - 59.0F, color__1)
                    DrawLine(writer, 25.0F, doc.Top - 60.0F, doc.PageSize.Width - 25.0F, doc.Top - 60.0F, color__1)
                    Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                    cellBlank.Colspan = 2
                    cellBlank.PaddingBottom = 8.0F
                    ' table.AddCell(cellBlank)
                    Dim btable = New PdfPTable(3)
                    btable.HorizontalAlignment = Element.ALIGN_LEFT
                    btable.TotalWidth = 460.0F
                    btable.SetWidths(New Single() {130.0F, 190.0F, 120.0F})
                    btable.SpacingBefore = 2.0F
                    btable.WidthPercentage = 90


                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("Interview Rating Sheet", FontFactory.GetFont("Arial", 16, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    cell.Colspan = 3
                    'cell.BorderColor = BaseColor.BLACK
                    ' cell.Rowspan = 2
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    ' cell.BorderColor = BaseColor.BLACK
                    cell.Colspan = 2
                    ' cell.HorizontalAlignment = Element.ALIGN_CENTER
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Roll Number:" & vbLf & rollno, FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE
                    cell.Rowspan = 8
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    cell = PhraseCell(New Phrase("Post Name:   ", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(jobdetail, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("  ", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Name of Candidate: ", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Date of Birth: ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(dob & " (" & age & " Yrs.)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    cell = PhraseCell(New Phrase("Education Qualification:  ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 5
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification2, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification3, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification4, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification5, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    btable.AddCell(cell)


                    doc.Add(btable)
                    'phrase = New Phrase()
                    '' phrase.Add(New Chunk("Sub: Admit Card for the post of " & jobdetail & " of BIFPCL" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("2. Indicator for Candidate’s Academic Result & Working Experience: [Academic Result-25; Working Experience-20] " & vbLf, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, BaseColor.BLACK)))
                    'doc.Add(phrase)

                    '''
                    'cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    'cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("2. Marks Obtained In Educational Qualification:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 6
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Qualifying Degree", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 2
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("CGPA/GPA Obtained:", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Colspan = 4
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(calculationText, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.Rowspan = 2
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("S.S.C (Out of 5)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("H.S.C (Out of 5)/Diploma (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Graduation (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("PostGraduation (Out of 4)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    ' End If

                    cell = PhraseCell(New Phrase(minQual, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(ratessc.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(hscOrDip.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(rategrad.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(ratepg.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(totalEd.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)

                    '###########
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(a)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(b)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(c)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("(d)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sub Total Marks Obtained(Out of 15)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)

                    ''
                    ' table.AddCell(cellBlank)
                    doc.Add(table)
                    table = New PdfPTable(5)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.1F, 0.5F, 0.3F, 0.3F, 0.5F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90
                    cell = PhraseCell(New Phrase("3. Marks Obtained In Viva Voce:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 5
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sl.", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Item", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Marks Allocated", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Marks Obtained", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Remarks", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("A.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("General Knowledge & Awareness", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("8", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("B.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Ability to Communicate in English", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("C.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Professional Knowledge", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("D.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Personality, Confidence & Attitude", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("9", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sub Total", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("35", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    doc.Add(table)
                    '#####
                    table = New PdfPTable(5)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.1F, 0.5F, 0.3F, 0.3F, 0.5F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90
                    cell = PhraseCell(New Phrase("4. Total Marks Obtained In Educational Qualification and Viva Voce:", FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.Colspan = 5
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Sl.", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Item", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Maximum Marks", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Marks Obtained", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Comments(if any)", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("A.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Educational Qualification", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("15", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(totalEd.ToString, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("B.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Viva Voce", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("35", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)

                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Grand Total(Sub Total 2+Sub Total 3)", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("50", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    doc.Add(table)
                    phrase = New Phrase()
                    'phrase.Add(New Chunk("You are requested to attend the " & str1 & " as per above schedule." & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("No TA/DA will be paid for participating in this " & str1 & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("-" & vbLf & vbLf & vbLf & vbLf & appID.ToString, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    doc.Add(phrase)

                    'phrase = New Phrase()
                    'phrase.Add(New Chunk("(Mohammad Mujtaba Tabrez)" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("DGM (HR), BIFPCL" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("E-mail: help@bifpcl.com" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))

                    'phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                    'phrase.Add(New Chunk("For any queries, feel free to reach us at: +88028321607-Ext 112,108 or write to us at: help@bifpcl.com " & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)))


                    'doc.Add(phrase)


                    doc.NewPage()

                    ' Exit For
                Next

                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=ratingcardAll" & Printappid & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printAttendance(ByVal stage As String, ByVal phase As String)
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd." '"BHARAT HEAVY ELECTRICALS LIMITED"
        Dim auth = "BIFPCL"
        'Dim list = CType(Session("printCoverID"), List(Of String))
        'Dim IDcommaseparated = String.Join(",", list)
        'divMsg.InnerHtml = IDcommaseparated
        'Dim totalID = list.Count

        ''dont touch first 9 columns
        'Dim q = "select id as 'Gate Pass ID',name as 'Name',father as 'Father', nationality as 'Nationality',nid as 'NID/Passport',desig as 'Desig',cell as 'Contact',strftime('%d.%m.%Y',validity_start) as 'V. Start',strftime('%d.%m.%Y',validity_end) as 'V. End', sex , age , 'Village: ' || ifnull(village,'') || ' PO:' || ifnull(po,'') || ' PS:' || ifnull(ps,'') || 'Dist:' || ifnull(district,'') as 'Address', mainagency as 'Work Partner', subagency, strftime('%d.%m.%Y', dob) as dob,  compliance, area, bgroup,desig,cat from gatepass where id in ( " & IDcommaseparated & ") "
        Dim q = " select distinct appid , replace(c.post, X'0A', ' ') as post, rollno as 'RollNo', salute || ' ' || name as 'NAME OF APPLICANT' ,father as 'FATHERs NAME',Sex as 'GENDER', strftime('%d.%m.%Y',dob) as 'DATE OF BIRTH', idcard as 'NATIONAL ID NUMBER' ,   appid as 'Photo', appid as 'SIGNATURE OF APPLICANT', date_w,date_i   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = '" & stage & "' and c.phase = '" & phase & "'  order by rollno"
        If stage = "interview" Then
            q = " select distinct appid , replace(c.post, X'0A', ' ') as post, rollno as 'RollNo', salute || ' ' || name as 'NAME OF APPLICANT' ,father as 'FATHERs NAME',strftime('%d.%m.%Y',venue_i_dt) || ' - ' || venue_i_time as 'Interview Slot', strftime('%d.%m.%Y',dob) as 'DATE OF BIRTH', idcard as 'NATIONAL ID NUMBER' ,   appid as 'Photo', appid as 'SIGNATURE OF APPLICANT', date_w,date_i   from careers_application c, careers_jobs j where c.jobid = j.jobid and stage = '" & stage & "' and c.phase = '" & phase & "' order by c.jobid, venue_i_dt, merit,  slot asc"
        End If
        Dim dt = dbOp.getDBTable(q, "appsdb")
        Dim totalID = dt.Rows.Count
        If dt.Rows.Count < 1 Then

            divMsg.InnerHtml = "No Records found for requested ID load failed.. Print can be done for applicants having " & stage & " status for " & phase '& IDcommaseparated
            Exit Sub
        End If
        '''''###############################################
        Dim doc As New Document(PageSize.A4.Rotate, 10.0F, 10.0F, 10.0F, 10.0F)
        Using memoryStream As New MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
            doc.Open()
            '  doc.NewPage()
            ''' Loop through Page 1
            ''' 

            Dim j = 0
            Dim idCardPerPage = 25
            Dim t2Horizontal = 0
            Dim tVertical = 0
            Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
            Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
            Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
            Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
            Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


            Dim phrase As Phrase = Nothing
            Dim cell As PdfPCell = Nothing
            Dim table As PdfPTable = Nothing
            Dim color__1 As BaseColor = Nothing


            Dim htable = New PdfPTable(2)
            htable.HorizontalAlignment = Element.ALIGN_MIDDLE
            htable.TotalWidth = 460.0F
            htable.SetWidths(New Single() {60.0F, 400.0F})

            Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
            Dim imageSign = ""
            'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
            Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
            'image.ScalePercent(scale)
            pic.ScaleAbsolute(60.0F, 60.0F)
            cell = New PdfPCell(pic)
            cell.BorderColor = BaseColor.WHITE
            htable.AddCell(cell)
            phrase = New Phrase()
            phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
            ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            Dim str1 = "Room No:                      Signature of Invigilator:"
            If stage = "interview" Then str1 = "Date:                      Signature of HR Officer:"
            phrase.Add(New Chunk(str1, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            cell = PhraseCell(phrase, PdfPCell.ALIGN_JUSTIFIED_ALL)
            'cell.Colspan = 2
            htable.AddCell(cell)
            doc.Add(htable)

            table = New PdfPTable(2)
            table.HorizontalAlignment = Element.ALIGN_LEFT
            table.SetWidths(New Single() {0.3F, 1.0F})
            table.SpacingBefore = 20.0F
            table.WidthPercentage = 90
            'reference Details

            'phrase = New Phrase()
            'phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLUE)))
            '' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("2X660MW MAITREE STPP" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            'cell.Colspan = 2
            'table.AddCell(cell)
            'Separater Line
            color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
            'DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
            'DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
            Dim cellBlank = PhraseCell(New Phrase("."), PdfPCell.ALIGN_CENTER)
            cellBlank.Colspan = 2
            cellBlank.PaddingBottom = 15.0F
            'phrase = New Phrase
            'phrase.Add(New Chunk("Attendance Sheet  (" & totalID & " Nos.): " & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)))
            'doc.Add(phrase)
            Dim col_max = 8
            Dim pdfTable As New PdfPTable(col_max)
            pdfTable.DefaultCell.Padding = 3
            pdfTable.WidthPercentage = 100
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.DefaultCell.BorderWidth = 1
            j = 0
            dt.Columns.RemoveAt(0)

            Dim m = 0
            ''print column

            For Each c As DataColumn In dt.Columns
                If Not m = 0 Then
                    Dim cell1 As New PdfPCell(New Phrase(c.ToString))
                    pdfTable.AddCell(cell1)
                End If
                If m = col_max Then Exit For
                m = m + 1
            Next


            Dim k = 1
            Dim candidate = 0
            Dim reset = k
            Dim dept = ""
            Dim date_wi = ""
            Dim oldDept = dept
            Dim old_date = date_wi
            For Each dr As DataRow In dt.Rows
                candidate = candidate + 1
                'If j Mod idCardPerPage = 0 Then

                '    doc.NewPage()
                '    j = 0
                'End If

                dept = dr("post").ToString
                date_wi = dr("date_w").ToString
                If stage = "interview" Then date_wi = dr("date_i").ToString
                Dim l = 0
                If (Not oldDept = dept And Not k = 1) Then

                    doc.Add(pdfTable)
                    phrase = New Phrase
                    phrase.Add(New Chunk(oldDept & "         Date:" & old_date & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("   " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    ' DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                    ' phrase.Add(New Chunk("      Total Candidate:" & candidate & " for above post out of Total: " & totalID & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("      Total Present:" & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("      Total Absent:", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)))
                    doc.Add(phrase)
                    doc.NewPage()
                    doc.Add(htable)
                    pdfTable = New PdfPTable(col_max)
                    pdfTable.DefaultCell.Padding = 3
                    pdfTable.WidthPercentage = 100
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.DefaultCell.BorderWidth = 1
                    m = 0
                    ''print column
                    candidate = 0
                    For Each c As DataColumn In dt.Columns
                        If Not m = 0 Then
                            Dim cell1 As New PdfPCell(New Phrase(c.ToString))
                            pdfTable.AddCell(cell1)
                        End If
                        If m = col_max Then Exit For
                        m = m + 1
                    Next

                    reset = 1
                End If
                For Each c As DataColumn In dt.Columns



                    If l = 7 Then
                        imagePath = String.Format("~/upload/HR/Career/{0}.jpg", dr(c).ToString)
                        If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                            imagePath = String.Format("~/images/{0}.jpg", "user")
                        End If
                        Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                        'image.ScalePercent(scale)
                        mypic.ScaleAbsolute(70.0F, 70.0F)

                        Dim cell1 = New PdfPCell(mypic)
                        cell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                        ' Dim cell1 = PhraseCell(New Phrase(imagePath, FontFactory.GetFont("Arial", 9, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)

                        pdfTable.AddCell(cell1)
                        'ElseIf l = 5 Then
                        '    Dim cell1 = PhraseCell(New Phrase(dr(c).ToString & oldDept & dept, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)
                        '    pdfTable.AddCell(cell1)
                    ElseIf l = 8 Then
                        imageSign = String.Format("~/upload/HR/Career/s{0}.jpg", dr(c).ToString)
                        If Not System.IO.File.Exists(Server.MapPath(imageSign)) Then
                            imageSign = String.Format("~/images/{0}.png", "logo")
                        End If
                        Dim picSign As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imageSign))
                        'image.ScalePercent(scale)
                        picSign.ScaleAbsolute(90.0F, 23.0F)
                        picSign.Border = 10
                        picSign.BorderColorBottom = BaseColor.BLACK
                        picSign.BorderColorLeft = BaseColor.BLACK
                        picSign.BorderWidth = 3.0F
                        Dim cell1 = New PdfPCell(picSign)
                        cell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                        ' Dim cell1 = PhraseCell(New Phrase(imagePath, FontFactory.GetFont("Arial", 9, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)

                        pdfTable.AddCell(cell1)
                    ElseIf Not (l = 0 Or l = 7 Or l = 8) Then
                        Dim cell1 = PhraseCell(New Phrase(dr(c).ToString, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)
                        pdfTable.AddCell(cell1)
                    End If
                    If l = col_max Then Exit For
                    l = l + 1
                Next
                j = j + 1
                ' If k = 7 Then Exit For
                If reset Mod 6 = 0 Then
                    doc.Add(pdfTable)
                    phrase = New Phrase
                    phrase.Add(New Chunk(dept, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    doc.Add(phrase)
                    doc.NewPage()
                    doc.Add(htable)
                    pdfTable = New PdfPTable(col_max)
                    pdfTable.DefaultCell.Padding = 3
                    pdfTable.WidthPercentage = 100
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
                    pdfTable.DefaultCell.BorderWidth = 1
                    m = 0
                    ''print column

                    For Each c As DataColumn In dt.Columns
                        If Not m = 0 Then
                            Dim cell1 As New PdfPCell(New Phrase(c.ToString))
                            pdfTable.AddCell(cell1)
                        End If
                        If m = col_max Then Exit For
                        m = m + 1
                    Next
                End If

                reset = reset + 1
                k = k + 1
                oldDept = dept
                old_date = date_wi
            Next
            doc.Add(pdfTable)
            phrase = New Phrase
            phrase.Add(New Chunk(oldDept & "         Date:" & old_date & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("      Total Present:" & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)))
            phrase.Add(New Chunk("      Total Absent:", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK)))
            doc.Add(phrase)
            doc.Close()
            Dim bytes As Byte() = memoryStream.ToArray()
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "attachment;filename=CoverCandidate" & Now.ToString("ddMyyHHmmss") & ".pdf")
            Response.Buffer = True
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.BinaryWrite(bytes)
            Response.[End]()

        End Using
    End Sub

    Sub printAdmitCardAll(ByVal stage As String, ByVal phase As String)

        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."
        Dim qAll = "select distinct appid from careers_application where last_updated > '2019-04-05' and status = 'Submit' and  phase = '" & phase & "' and stage = '" & stage & "' order by rollno asc"  'appid in ('2404190440167','3004190241007','2204192257397','1704192141027','2104190234093','2104190220136')
        If stage = "interview" Then
            qAll = "select distinct appid from careers_application where last_updated > '2019-04-05'  and status = 'Submit' and  phase = '" & phase & "' and stage = '" & stage & "' order by jobid, merit asc "  'rollno in ('2404190440167','3004190241007','2204192257397','1704192141027','2104190234093','2104190220136')
        End If
        Dim myDT = getDBTable(qAll, "appsdb")
        If myDT.Rows.Count < 1 Then
            divMsg.InnerHtml = "No Records found "
            Exit Sub
        End If
        Try
            Dim doc As New Document(PageSize.A4, 40.0F, 10.0F, 30.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                Dim seq = 1
                For Each rID In myDT.Rows
                    Dim appID = rID(0)

                    Dim q = "select jobid, salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',ncert as 'ncert', address || ' ' || district || ' Postal Code-' || pin as 'addressc',addressp || ' ' || districtp as 'addressp',exptype || ' Sector '  as 'workexp', org || ', ' || desig  || ', From ' || durationfrom || ' To ' || durationto as 'Detail',deptcand ,freedom , relative , draft , resume, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', strftime('%d.%m.%Y',last_updated) as last_updated, aid, rollno, venue_i,  strftime('%d.%m.%Y',venue_i_dt) as venue_i_dt, venue_i_time from careers_application where appid = '" & appID & "' and stage = '" & stage & "' limit 1"

                    Dim dt = getDBTable(q, "appsdb")
                    If dt.Rows.Count < 1 Then
                        divMsg.InnerHtml = "No Records found for requested admit ID load failed.." & appID
                        Exit Sub
                    End If
                    Dim jobid = If(IsDBNull(dt.Rows(0)("jobid")), "", dt.Rows(0)("jobid"))
                    Dim jobdetail = getDBsingle("select replace(post, X'0A', ' ') from careers_jobs where jobid = " & jobid, "appsdb")
                    ' jobdetail = jobdetail.Replace(vbCrLf, " ")
                    Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
                    Dim name = If(IsDBNull(dt.Rows(0)("name")), "", dt.Rows(0)("name"))
                    Dim father = If(IsDBNull(dt.Rows(0)("father")), "", dt.Rows(0)("father"))
                    Dim sex = If(IsDBNull(dt.Rows(0)("sex")), "", dt.Rows(0)("sex"))
                    Dim Contact = If(IsDBNull(dt.Rows(0)("Contact")), "", dt.Rows(0)("Contact"))
                    Dim dob = If(IsDBNull(dt.Rows(0)("dob")), "", dt.Rows(0)("dob"))
                    'Dim nid = If(IsDBNull(dt.Rows(0)("nid")), "", dt.Rows(0)("nid"))
                    'Dim ncert = If(IsDBNull(dt.Rows(0)("ncert")), "", dt.Rows(0)("ncert"))
                    Dim addressc = If(IsDBNull(dt.Rows(0)("addressc")), "", dt.Rows(0)("addressc"))
                    'Dim addressp = If(IsDBNull(dt.Rows(0)("addressp")), "", dt.Rows(0)("addressp"))
                    'Dim workexp = If(IsDBNull(dt.Rows(0)("workexp")), "", dt.Rows(0)("workexp"))
                    'Dim Detail = If(IsDBNull(dt.Rows(0)("Detail")), "", dt.Rows(0)("Detail"))
                    'Dim deptcand = If(IsDBNull(dt.Rows(0)("deptcand")), "", dt.Rows(0)("deptcand"))
                    'Dim freedom = If(IsDBNull(dt.Rows(0)("freedom")), "", dt.Rows(0)("freedom"))
                    'Dim relative = If(IsDBNull(dt.Rows(0)("relative")), "", dt.Rows(0)("relative"))
                    'Dim draft = If(IsDBNull(dt.Rows(0)("draft")), "", dt.Rows(0)("draft"))
                    'Dim resume1 = If(IsDBNull(dt.Rows(0)("resume")), "", dt.Rows(0)("resume"))
                    'Dim qualification1 = If(IsDBNull(dt.Rows(0)("qualification1")), "", dt.Rows(0)("qualification1"))
                    'Dim qualification2 = If(IsDBNull(dt.Rows(0)("qualification2")), "", dt.Rows(0)("qualification2"))
                    'Dim qualification3 = If(IsDBNull(dt.Rows(0)("qualification3")), "", dt.Rows(0)("qualification3"))
                    'Dim qualification4 = If(IsDBNull(dt.Rows(0)("qualification4")), "", dt.Rows(0)("qualification4"))
                    'Dim qualification5 = If(IsDBNull(dt.Rows(0)("qualification5")), "", dt.Rows(0)("qualification5"))
                    Dim last_updated = If(IsDBNull(dt.Rows(0)("last_updated")), "", dt.Rows(0)("last_updated"))
                    Dim aid = If(IsDBNull(dt.Rows(0)("aid")), "", dt.Rows(0)("aid"))
                    Dim rollno = If(IsDBNull(dt.Rows(0)("rollno")), "", dt.Rows(0)("rollno"))
                    Dim venue_int = If(IsDBNull(dt.Rows(0)("venue_i")), "", dt.Rows(0)("venue_i"))
                    Dim venue_i_dt = If(IsDBNull(dt.Rows(0)("venue_i_dt")), "", dt.Rows(0)("venue_i_dt"))
                    Dim venue_i_time = If(IsDBNull(dt.Rows(0)("venue_i_time")), "", dt.Rows(0)("venue_i_time"))
                    '''''###############################################
                    '''  
                    '''
                    Dim j = 0
                    '  Dim ref = "Ref: BIFPCL/HRRECTT/" & appID & "/" & seq & "                                   Date: " & "07.01.2020" 'last_updated 'Now.ToString("dd.MM.yyyy")
                    seq = seq + 1

                    '  doc.NewPage()
                    ''' Loop through Page 1
                    ''' 

                    Dim idCardPerPage = 25
                    Dim t2Horizontal = 0
                    Dim tVertical = 0
                    Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                    Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                    Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                    Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                    Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                    Dim phrase As Phrase = Nothing
                    Dim cell As PdfPCell = Nothing
                    Dim table As PdfPTable = Nothing
                    Dim color__1 As BaseColor = Nothing




                    'reference Details
                    Dim htable = New PdfPTable(2)
                    htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                    htable.TotalWidth = 460.0F
                    htable.SetWidths(New Single() {60.0F, 400.0F})

                    Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                    'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                    Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    pic.ScaleAbsolute(60.0F, 60.0F)
                    cell = New PdfPCell(pic)
                    cell.BorderColor = BaseColor.WHITE
                    htable.AddCell(cell)

                    table = New PdfPTable(2)
                    table.HorizontalAlignment = Element.ALIGN_LEFT
                    table.SetWidths(New Single() {0.7F, 1.0F})
                    table.SpacingBefore = 5.0F
                    table.WidthPercentage = 90

                    phrase = New Phrase()
                    phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                    ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
                    'cell.Colspan = 2
                    htable.AddCell(cell)
                    doc.Add(htable)
                    'Separater Line
                    color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                    DrawLine(writer, 25.0F, doc.Top - 59.0F, doc.PageSize.Width - 25.0F, doc.Top - 59.0F, color__1)
                    DrawLine(writer, 25.0F, doc.Top - 60.0F, doc.PageSize.Width - 25.0F, doc.Top - 60.0F, color__1)
                    Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                    cellBlank.Colspan = 2
                    cellBlank.PaddingBottom = 8.0F
                    ' table.AddCell(cellBlank)
                    Dim btable = New PdfPTable(2)
                    btable.HorizontalAlignment = Element.ALIGN_LEFT
                    btable.TotalWidth = 460.0F
                    btable.SetWidths(New Single() {380.0F, 80.0F})
                    btable.SpacingBefore = 2.0F
                    btable.WidthPercentage = 90

                    q = "select vanue_w, date_w, time_w, vanue_i, date_i, time_i from careers_jobs where jobid = '" & jobid & "'  limit 1"
                    Dim mydt1 = getDBTable(q, "appsdb")
                    If mydt1.Rows.Count = 0 Then
                        Exit Sub
                    End If
                    Dim venue_w = mydt1.Rows(0)("vanue_w").ToString
                    Dim date_w = mydt1.Rows(0)("date_w").ToString
                    Dim time_w = mydt1.Rows(0)("time_w").ToString
                    Dim issuedate = mydt1.Rows(0)("date_i").ToString
                    Dim ref = "Ref: BIFPCL/HRRECTT/" & appID & "                               Date: " & issuedate 'last_updated 'Now.ToString("dd.MM.yyyy")

                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)

                    cell.Colspan = 2
                    ' cell.Rowspan = 2
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Admit Card ", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    ' cell.Colspan = 2
                    cell.HorizontalAlignment = Element.ALIGN_CENTER
                    btable.AddCell(cell)
                    imagePath = String.Format("~/upload/HR/Career/{0}.jpg", appID)
                    If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                        imagePath = String.Format("~/images/{0}.jpg", "user")
                    End If
                    Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    mypic.ScaleAbsolute(80.0F, 90.0F)

                    cell = New PdfPCell(mypic)
                    cell.Rowspan = 7
                    cell.BorderColor = BaseColor.WHITE
                    btable.AddCell(cell)


                    cell = PhraseCell(New Phrase("Roll Number:   " & rollno, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    'cell = PhraseCell(New Phrase("  ", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'btable.AddCell(cell)
                    cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)

                    cell = PhraseCell(New Phrase("Father's Name: " & father, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)

                    cell = PhraseCell(New Phrase("Email: " & email, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Contact:  " & Contact, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)
                    cell = PhraseCell(New Phrase("Address: " & addressc.Replace(vbCr, " ").Replace(vbLf, " "), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    btable.AddCell(cell)
                    Dim str1 = "VIVA-VOCE"
                    If stage = "written" Then str1 = "Written Test Examination"
                    doc.Add(btable)
                    phrase = New Phrase()
                    phrase.Add(New Chunk("Sub: Admit Card for " & str1 & " for the post of " & jobdetail & " of BIFPCL" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    phrase.Add(New Chunk("Dear Candidate " & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))

                    phrase.Add(New Chunk("You are shortlisted for " & str1 & " for the post of " & jobdetail & " of Bangladesh-India Friendship Power Company (Pvt) Limited (BIFPCL), which will be held as per the following schedule: ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    doc.Add(phrase)

                    Dim venue_i = venue_int 'mydt1.Rows(0)("vanue_i").ToString

                    Dim date_i = venue_i_dt ' mydt1.Rows(0)("date_i").ToString
                    Dim date_i_dt As DateTime
                    Try
                        Dim d = Split(date_i, ".")
                        date_i_dt = New DateTime(d(2), d(1), d(0))
                    Catch exd As Exception

                    End Try

                    Dim time_i = venue_i_time ' mydt1.Rows(0)("time_i").ToString
                    Dim eventDate = date_i & ", " & date_i_dt.ToString("ddd")
                    If stage = "written" Then
                        venue_i = venue_w
                        date_i = date_w
                        eventDate = date_i
                        time_i = time_w
                    End If
                    '''
                    'cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    'cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    'cell.BorderColor = BaseColor.BLACK
                    'table.AddCell(cell)
                    ' table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("Date & Day:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(eventDate, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)

                    ' End If
                    '  table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("Time:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(time_i, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    If stage = "written" Then

                        'table.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase("Duration of Written Examination:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        table.AddCell(cell)
                        cell = PhraseCell(New Phrase("90 Minutes", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        table.AddCell(cell)
                    End If
                    cell = PhraseCell(New Phrase("Venue:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    ' cell.Colspan = 2
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(venue_i, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    If stage = "interview" Then
                        cell = PhraseCell(New Phrase("Dress Code:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        table.AddCell(cell)
                        cell = PhraseCell(New Phrase("Formals", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        table.AddCell(cell)
                    End If
                    'cell = PhraseCell(New Phrase("Declaration:" & vbCrLf & "I hereby declare that all the statements made in this application are true, complete and correct to the best of my knowledge and belief. I understand that in the event of any information being found false at any stage or not satisfying the eligibility criteria specified for the post, my candidature/ appointment is liable to be cancelled/terminated. I declare that i will join the post, if selected within a period of 2 months from the date of issue of offer letter.", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                    'cell.BorderColor = BaseColor.BLACK
                    'cell.Colspan = 2
                    ' table.AddCell(cell)


                    ''
                    ' table.AddCell(cellBlank)
                    doc.Add(table)
                    phrase = New Phrase()
                    phrase.Add(New Chunk("You are requested to attend the " & str1 & " as per above schedule." & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("No TA/DA will be paid for participating in this " & str1 & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("As Directed-" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    doc.Add(phrase)

                    Dim imageSign = String.Format("~/images/{0}.jpg", "hrsign")
                    Dim picSign As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imageSign))
                    'image.ScalePercent(scale)
                    picSign.ScaleAbsolute(90.0F, 23.0F)
                    'cell = New PdfPCell(picSign)
                    doc.Add(picSign)

                    phrase = New Phrase()
                    phrase.Add(New Chunk("(Mohammad Mujtaba Tabrez)" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                    phrase.Add(New Chunk("AGM (HR), BIFPCL" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("E-mail: help@bifpcl.com" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk(vbLf & "Important Instructions for Candidates:" & vbCrLf, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, BaseColor.BLACK)))
                    phrase.Add(New Chunk("1.	Applicants must follow the guidelines for the prevention and control of social and institutional infections of Covid-19 published by the Ministry of Health and Family Welfare. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("2.	Applicants must wear Face mask before entering the venue hall. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("3.	The Applicant must carry this admit card to attend the " & str1 & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    If stage = "written" Then

                        phrase.Add(New Chunk("4.	Applicant must sit in the examination hall at least 30 minutes prior to the start of " & str1 & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("5.	Applicants are allowed to use only general calculator. However, mobile phones, bags, books, Scientific and programmable calculators and any other communication device is strictly prohibited. Bringing these in examination hall is a punishable offence." & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("6.	Applicant must use the same signature for application, attendance sheet and wherever needed. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("7.	Applicant is not allowed to enter or exit the examination hall after the start of the written examination. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("8.	Invigilators in the examination hall will match the photograph of the applicant in the attendance sheet with that of the admit card before taking his/her signature. Legal action will be taken against the applicant if any irregularity is detected. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("9.	Applicant will be expelled if the general instructions are not followed or if found guilty of misconduct, misbehavior or adopting unfair means. Applicant found guilty of copying, adopting any sort of unfair means or misconduct, bearing prohibited things will be barred from applying in any future examination conducted by the company and will not be allowed to apply for any other posts to be advertised by the company. Moreover, he/she may be handed over to the law enforcing agency for taking legal action against him/her. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                        phrase.Add(New Chunk("10.	Head Invigilator of examination hall is authorized to take necessary action in case any candidate is found violating above mentioned instructions. Head Invigilator is also authorized to provide a  send statement to competent authority of BIFPCL for taking necessary actions against the accused applicant. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    ElseIf stage = "interview" Then
                        phrase.Add(New Chunk("4.	Candidate must reach the venue hall at least 30 minutes prior to the start of viva voce;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("5.	Candidate must bring following documents (In Original) along with attested photocopies for verification on the day of the Viva-Voce." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    	a)	National ID/Birth Certificate & All relevant Educational & Experience Certificates (If/Any)." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    	b)	First & Last Page of Valid Passport of Bangladesh " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    	c)	Candidates passed from foreign university (ies)/Institute(s) should carry the equivalence certificate/result issued from a competent authority recognized by government of Bangladesh. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    	d)	Persons employed in Government/Semi-Government/Autonomous organization(s)/Govt. owned company (ies) and have applied through proper channel should carry a NOC Issued from their respective employer." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    	e)	Candidates who are availing Age Relaxation in respect of being sons/grand-sons and daughters/grand-daughters of freedom fighters and martyred freedom fighters should carry certificates issued to Freedom Fighters/ Martyred Freedom Fighters by the appropriate authority and also carry copy of the certificate already submitted to us which was issued from the respective Union Parishad Chairman/ Ward Commissioner of City Corporation/ Pourashava Mayor/ Counselor testifying their relationship with the Freedom Fighters/ Martyred Freedom Fighters.;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("6.	BIFPCL shall examine the photograph of the candidate in the attendance sheet with that of the admit card before taking his/her signature;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("7.	Candidate who do not possess a passport/valid passport of Bangladesh are urged to apply for the same as soon as possible. Non-availability of passport at Joining Stage may lead to cancellation of candidature. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                        '  phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                    End If
                    phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("For any queries, feel free to reach us at: +88028321607-Ext 112,108 or write to us at: help@bifpcl.com " & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)))


                    doc.Add(phrase)


                    doc.NewPage()


                Next

                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=admitcardAll.pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printAdmitCard()
        Dim appID = Session("jobAdmitID")
        Dim stage = Session("stageAdmitID")
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."


        Dim q = "select jobid, salute || ' ' || name as name ,father,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',ncert as 'ncert', replace(address, X'0D', '')  || ' ' || district || ' Postal Code-' || pin as 'addressc',replace(addressp, X'0A', ' ') || ' ' || districtp as 'addressp',exptype || ' Sector '  as 'workexp', org || ', ' || desig  || ', From ' || durationfrom || ' To ' || durationto as 'Detail',deptcand ,freedom , relative , draft , resume, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', strftime('%d.%m.%Y',last_updated) as last_updated, aid, rollno, venue_i,  strftime('%d.%m.%Y',venue_i_dt) as venue_i_dt, venue_i_time, stage from careers_application where appid = '" & appID & "' and stage = '" & stage & "'"
        Try
            Dim dt = getDBTable(q, "appsdb")
            If dt.Rows.Count < 1 Then
                divMsg.InnerHtml = "No Records found for requested admit ID load failed.." & appID & q
                Exit Sub
            End If
            If dt.Rows.Count > 1 Then
                divMsg.InnerHtml = "You have submitted the application multiple times by using back button of browser.. mail to help@bifpcl.com to get the admit card " '& appID
                Exit Sub
            End If
            Dim jobid = If(IsDBNull(dt.Rows(0)("jobid")), "", dt.Rows(0)("jobid"))
            Dim jobdetail = getDBsingle("select replace(post, X'0A', ' ') from careers_jobs where jobid = " & jobid, "appsdb")
            ' jobdetail = jobdetail.Replace(vbCrLf, " ")
            Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
            Dim name = If(IsDBNull(dt.Rows(0)("name")), "", dt.Rows(0)("name"))
            Dim father = If(IsDBNull(dt.Rows(0)("father")), "", dt.Rows(0)("father"))
            Dim sex = If(IsDBNull(dt.Rows(0)("sex")), "", dt.Rows(0)("sex"))
            Dim Contact = If(IsDBNull(dt.Rows(0)("Contact")), "", dt.Rows(0)("Contact"))
            Dim dob = If(IsDBNull(dt.Rows(0)("dob")), "", dt.Rows(0)("dob"))
            'Dim nid = If(IsDBNull(dt.Rows(0)("nid")), "", dt.Rows(0)("nid"))
            'Dim ncert = If(IsDBNull(dt.Rows(0)("ncert")), "", dt.Rows(0)("ncert"))
            Dim addressc = If(IsDBNull(dt.Rows(0)("addressc")), "", dt.Rows(0)("addressc"))
            'Dim addressp = If(IsDBNull(dt.Rows(0)("addressp")), "", dt.Rows(0)("addressp"))
            'Dim workexp = If(IsDBNull(dt.Rows(0)("workexp")), "", dt.Rows(0)("workexp"))
            'Dim Detail = If(IsDBNull(dt.Rows(0)("Detail")), "", dt.Rows(0)("Detail"))
            'Dim deptcand = If(IsDBNull(dt.Rows(0)("deptcand")), "", dt.Rows(0)("deptcand"))
            'Dim freedom = If(IsDBNull(dt.Rows(0)("freedom")), "", dt.Rows(0)("freedom"))
            'Dim relative = If(IsDBNull(dt.Rows(0)("relative")), "", dt.Rows(0)("relative"))
            'Dim draft = If(IsDBNull(dt.Rows(0)("draft")), "", dt.Rows(0)("draft"))
            'Dim resume1 = If(IsDBNull(dt.Rows(0)("resume")), "", dt.Rows(0)("resume"))
            'Dim qualification1 = If(IsDBNull(dt.Rows(0)("qualification1")), "", dt.Rows(0)("qualification1"))
            'Dim qualification2 = If(IsDBNull(dt.Rows(0)("qualification2")), "", dt.Rows(0)("qualification2"))
            'Dim qualification3 = If(IsDBNull(dt.Rows(0)("qualification3")), "", dt.Rows(0)("qualification3"))
            'Dim qualification4 = If(IsDBNull(dt.Rows(0)("qualification4")), "", dt.Rows(0)("qualification4"))
            'Dim qualification5 = If(IsDBNull(dt.Rows(0)("qualification5")), "", dt.Rows(0)("qualification5"))
            Dim last_updated = If(IsDBNull(dt.Rows(0)("last_updated")), "", dt.Rows(0)("last_updated"))
            Dim aid = If(IsDBNull(dt.Rows(0)("aid")), "", dt.Rows(0)("aid"))
            Dim rollno = If(IsDBNull(dt.Rows(0)("rollno")), "", dt.Rows(0)("rollno"))
            Dim venue_int = If(IsDBNull(dt.Rows(0)("venue_i")), "", dt.Rows(0)("venue_i"))
            Dim venue_i_dt = If(IsDBNull(dt.Rows(0)("venue_i_dt")), "", dt.Rows(0)("venue_i_dt"))
            Dim venue_i_time = If(IsDBNull(dt.Rows(0)("venue_i_time")), "", dt.Rows(0)("venue_i_time"))
            '  Dim stage = If(IsDBNull(dt.Rows(0)("stage")), "", dt.Rows(0)("stage"))
            '''''###############################################
            '''  
            ''' 

            Dim doc As New Document(PageSize.A4, 40.0F, 10.0F, 30.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                '  doc.NewPage()
                ''' Loop through Page 1
                ''' 
                Dim j = 0
                Dim idCardPerPage = 25
                Dim t2Horizontal = 0
                Dim tVertical = 0
                Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                Dim phrase As Phrase = Nothing
                Dim cell As PdfPCell = Nothing
                Dim table As PdfPTable = Nothing
                Dim color__1 As BaseColor = Nothing




                'reference Details
                Dim htable = New PdfPTable(2)
                htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                htable.TotalWidth = 460.0F
                htable.SetWidths(New Single() {60.0F, 400.0F})

                Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                pic.ScaleAbsolute(60.0F, 60.0F)
                cell = New PdfPCell(pic)
                cell.BorderColor = BaseColor.WHITE
                htable.AddCell(cell)

                table = New PdfPTable(2)
                table.HorizontalAlignment = Element.ALIGN_LEFT
                table.SetWidths(New Single() {0.7F, 1.0F})
                table.SpacingBefore = 2.0F
                table.WidthPercentage = 90

                phrase = New Phrase()
                phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
                'cell.Colspan = 2
                htable.AddCell(cell)
                doc.Add(htable)
                'Separater Line
                color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                DrawLine(writer, 25.0F, doc.Top - 59.0F, doc.PageSize.Width - 25.0F, doc.Top - 59.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 60.0F, doc.PageSize.Width - 25.0F, doc.Top - 60.0F, color__1)
                Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                cellBlank.Colspan = 2
                cellBlank.PaddingBottom = 8.0F
                ' table.AddCell(cellBlank)
                Dim btable = New PdfPTable(2)
                btable.HorizontalAlignment = Element.ALIGN_LEFT
                btable.TotalWidth = 460.0F
                btable.SetWidths(New Single() {380.0F, 80.0F})
                btable.SpacingBefore = 2.0F
                btable.WidthPercentage = 90
                q = "select vanue_w, date_w, time_w, vanue_i, date_i, time_i from careers_jobs where jobid = '" & jobid & "'  limit 1"
                Dim mydt = getDBTable(q, "appsdb")
                If mydt.Rows.Count = 0 Then
                    Exit Sub
                End If
                Dim venue_w = mydt.Rows(0)("vanue_w").ToString
                Dim date_w = mydt.Rows(0)("date_w").ToString
                Dim time_w = mydt.Rows(0)("time_w").ToString
                Dim issuedate = mydt.Rows(0)("date_i").ToString
                Dim ref = "Ref: BIFPCL/HRRECTT/" & appID & "                               Date: " & issuedate 'last_updated 'Now.ToString("dd.MM.yyyy")


                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)

                cell.Colspan = 2
                ' cell.Rowspan = 2
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Admit Card ", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                ' cell.Colspan = 2
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                btable.AddCell(cell)
                imagePath = String.Format("~/upload/HR/Career/{0}.jpg", appID)
                If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                    imagePath = String.Format("~/images/{0}.jpg", "user")
                End If
                Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                mypic.ScaleAbsolute(80.0F, 90.0F)

                cell = New PdfPCell(mypic)
                cell.Rowspan = 7
                cell.BorderColor = BaseColor.WHITE
                btable.AddCell(cell)

                cell = PhraseCell(New Phrase("Roll Number:   " & rollno, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                'cell = PhraseCell(New Phrase("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'btable.AddCell(cell)
                'cell = PhraseCell(New Phrase("  ", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'btable.AddCell(cell)
                cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)

                cell = PhraseCell(New Phrase("Father's Name: " & father, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)

                cell = PhraseCell(New Phrase("Email: " & email, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Contact:  " & Contact, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Address: " & addressc.Replace(vbCr, " ").Replace(vbLf, " "), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                Dim str1 = "VIVA-VOCE"
                If stage = "written" Then
                    str1 = "Written Test Examination"
                    'Exit Sub
                End If
                doc.Add(btable)
                phrase = New Phrase()
                phrase.Add(New Chunk("Sub: Admit Card for " & str1 & " for the post of " & jobdetail & " of BIFPCL" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Dear Candidate " & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("You are shortlisted for " & str1 & " for the post of " & jobdetail & " of Bangladesh-India Friendship Power Company (Pvt) Limited (BIFPCL), which will be held as per the following schedule: ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                doc.Add(phrase)

                Dim venue_i = venue_int 'mydt1.Rows(0)("vanue_i").ToString

                Dim date_i = venue_i_dt ' mydt1.Rows(0)("date_i").ToString
                Dim date_i_dt As DateTime
                Try
                    Dim d = Split(date_i, ".")
                    date_i_dt = New DateTime(d(2), d(1), d(0))
                Catch exd As Exception

                End Try

                Dim time_i = venue_i_time ' mydt1.Rows(0)("time_i").ToString
                Dim eventDate = date_i & ", " & date_i_dt.ToString("ddd")
                If stage = "written" Then
                    venue_i = venue_w
                    date_i = date_w
                    eventDate = date_i
                    time_i = time_w
                End If
                '''
                'cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'table.AddCell(cell)
                'cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'table.AddCell(cell)
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Date & Day:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(eventDate, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)

                ' End If
                '  table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Time:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(time_i, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                If stage = "written" Then

                    'table.AddCell(cellBlank)
                    cell = PhraseCell(New Phrase("Duration of Written Examination:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("90 Minutes", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If
                cell = PhraseCell(New Phrase("Venue:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                ' cell.Colspan = 2
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(venue_i, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                If stage = "interview" Then
                    cell = PhraseCell(New Phrase("Dress Code:", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase("Formals", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If
                'cell = PhraseCell(New Phrase("Declaration:" & vbCrLf & "I hereby declare that all the statements made in this application are true, complete and correct to the best of my knowledge and belief. I understand that in the event of any information being found false at any stage or not satisfying the eligibility criteria specified for the post, my candidature/ appointment is liable to be cancelled/terminated. I declare that i will join the post, if selected within a period of 2 months from the date of issue of offer letter.", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                'cell.BorderColor = BaseColor.BLACK
                'cell.Colspan = 2
                ' table.AddCell(cell)


                ''
                ' table.AddCell(cellBlank)
                doc.Add(table)
                phrase = New Phrase()
                phrase.Add(New Chunk("You are requested to attend the " & str1 & " as per above schedule." & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("No TA/DA will be paid for participating in this " & str1 & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)))
                phrase.Add(New Chunk("As Directed-" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                doc.Add(phrase)

                Dim imageSign = String.Format("~/images/{0}.jpg", "hrsign")
                Dim picSign As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imageSign))
                'image.ScalePercent(scale)
                picSign.ScaleAbsolute(90.0F, 23.0F)
                'cell = New PdfPCell(picSign)
                doc.Add(picSign)

                phrase = New Phrase()
                phrase.Add(New Chunk("(Mohammad Mujtaba Tabrez)" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("AGM (HR), BIFPCL" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("E-mail: help@bifpcl.com" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk(vbLf & "Important Instructions for Candidates:" & vbCrLf, FontFactory.GetFont("Arial", 10, Font.UNDERLINE, BaseColor.BLACK)))
                phrase.Add(New Chunk("1.	Applicants must follow the guidelines for the prevention and control of social and institutional infections of Covid-19 published by the Ministry of Health and Family Welfare. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("2.	Applicants must wear Face mask before entering the exanimation center. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("3.	The Applicant must carry this admit card to attend the " & str1 & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                If stage = "written" Then

                    phrase.Add(New Chunk("4.	Applicant must sit in the examination hall at least 30 minutes prior to the start of " & str1 & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("5.	Applicants are allowed to use only general calculator. However, mobile phones, bags, books, Scientific and programmable calculators and any other communication device is strictly prohibited. Bringing these in examination hall is a punishable offence." & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("6.	Applicant must use the same signature for application, attendance sheet and wherever needed. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("7.	Applicant is not allowed to enter or exit the examination hall after the start of the written examination. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("8.	Invigilators in the examination hall will match the photograph of the applicant in the attendance sheet with that of the admit card before taking his/her signature. Legal action will be taken against the applicant if any irregularity is detected. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("9.	Applicant will be expelled if the general instructions are not followed or if found guilty of misconduct, misbehavior or adopting unfair means. Applicant found guilty of copying, adopting any sort of unfair means or misconduct, bearing prohibited things will be barred from applying in any future examination conducted by the company and will not be allowed to apply for any other posts to be advertised by the company. Moreover, he/she may be handed over to the law enforcing agency for taking legal action against him/her. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                    phrase.Add(New Chunk("10.	Head Invigilator of examination hall is authorized to take necessary action in case any candidate is found violating above mentioned instructions. Head Invigilator is also authorized to provide a  send statement to competent authority of BIFPCL for taking necessary actions against the accused applicant. " & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)))
                ElseIf stage = "interview" Then
                    phrase.Add(New Chunk("4.	Candidate must reach the venue hall at least 30 minutes prior to the start of viva voce;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("5.	Candidate must bring following documents (In Original) along with attested photocopies for verification on the day of the Viva-Voce." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("    	a)	National ID/Birth Certificate & All relevant Educational & Experience Certificates (If/Any)." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("    	b)	First & Last Page of Valid Passport of Bangladesh " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("    	c)	Candidates passed from foreign university (ies)/Institute(s) should carry the equivalence certificate/result issued from a competent authority recognized by government of Bangladesh. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("    	d)	Persons employed in Government/Semi-Government/Autonomous organization(s)/Govt. owned company (ies) and have applied through proper channel should carry a NOC Issued from their respective employer." & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("    	e)	Candidates who are availing Age Relaxation in respect of being sons/grand-sons and daughters/grand-daughters of freedom fighters and martyred freedom fighters should carry certificates issued to Freedom Fighters/ Martyred Freedom Fighters by the appropriate authority and also carry copy of the certificate already submitted to us which was issued from the respective Union Parishad Chairman/ Ward Commissioner of City Corporation/ Pourashava Mayor/ Counselor testifying their relationship with the Freedom Fighters/ Martyred Freedom Fighters.;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("6.	BIFPCL shall examine the photograph of the candidate in the attendance sheet with that of the admit card before taking his/her signature;" & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    phrase.Add(New Chunk("7.	Candidate who do not possess a passport/valid passport of Bangladesh are urged to apply for the same as soon as possible. Non-availability of passport at Joining Stage may lead to cancellation of candidature. " & vbLf, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)))
                    '  phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                End If
                phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("For any queries, feel free to reach us at: +88028321607-Ext 112,108 or write to us at: help@bifpcl.com " & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLUE)))


                doc.Add(phrase)




                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=admitcard" & appID & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printApplication()
        Dim appID = Session("jobAppID")

        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."


        Dim q = "select jobid, salute || ' ' || name as name ,father,mother,post,sex, email, 'Mobile-' || cell || ' Phone-' || phone as 'Contact', strftime('%d.%m.%Y',dob) as dob, idcard as 'nid',ncert as 'ncert', address || ' ' || district || ' Postal Code-' || pin as 'addressc',addressp || ' ' || districtp as 'addressp',exptype || ' Sector '  as 'workexp', org || ', ' || desig  || ', From ' || durationfrom || ' To ' || durationto as 'Detail',deptcand ,freedom , relative , draft , resume, qual1 || ' / ' || sub1 || '/ ' || inst1 || ' / ' || uni1 || ' / ' || year1 || ' / ' || gpa1 as 'qualification1',qual2 || ' / ' || sub2 || '/ ' || inst2 || ' / ' || uni2 || ' / ' || year2 || ' / ' || gpa2 as 'qualification2',qual3 || ' / ' || sub3 || '/ ' || inst3 || ' / ' || uni3 || ' / ' || year3 || ' / ' || gpa3 as  'qualification3',qual4 || ' / ' || sub4 || '/ ' || inst4 || ' / ' || uni4 || ' / ' || year4 || ' / ' || gpa4 as  'qualification4',qual5 || ' / ' || sub5 || '/ ' || inst5 || ' / ' || uni5 || ' / ' || year5 || ' / ' || gpa5 as  'qualification5', strftime('%d.%m.%Y',last_updated) as last_updated from careers_application where appid = '" & appID & "' limit 1"
        Try
            Dim dt = getDBTable(q, "appsdb")
            If dt.Rows.Count < 1 Then
                divMsg.InnerHtml = "No Records found for requested ID load failed.." & appID
                Exit Sub
            End If
            Dim jobid = If(IsDBNull(dt.Rows(0)("jobid")), "", dt.Rows(0)("jobid"))
            Dim jobdetail = If(IsDBNull(dt.Rows(0)("post")), "", dt.Rows(0)("post")) 'getDBsingle("select post from careers_jobs where jobid = " & jobid, "appsdb")
            Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
            Dim name = If(IsDBNull(dt.Rows(0)("name")), "", dt.Rows(0)("name"))
            Dim father = If(IsDBNull(dt.Rows(0)("father")), "", dt.Rows(0)("father"))
            Dim mother = If(IsDBNull(dt.Rows(0)("mother")), "", dt.Rows(0)("mother"))
            Dim sex = If(IsDBNull(dt.Rows(0)("sex")), "", dt.Rows(0)("sex"))
            Dim Contact = If(IsDBNull(dt.Rows(0)("Contact")), "", dt.Rows(0)("Contact"))
            Dim dob = If(IsDBNull(dt.Rows(0)("dob")), "", dt.Rows(0)("dob"))
            Dim nid = If(IsDBNull(dt.Rows(0)("nid")), "", dt.Rows(0)("nid"))
            Dim ncert = If(IsDBNull(dt.Rows(0)("ncert")), "", dt.Rows(0)("ncert"))
            Dim addressc = If(IsDBNull(dt.Rows(0)("addressc")), "", dt.Rows(0)("addressc"))
            Dim addressp = If(IsDBNull(dt.Rows(0)("addressp")), "", dt.Rows(0)("addressp"))
            Dim workexp = If(IsDBNull(dt.Rows(0)("workexp")), "", dt.Rows(0)("workexp"))
            Dim Detail = If(IsDBNull(dt.Rows(0)("Detail")), "", dt.Rows(0)("Detail"))
            Dim deptcand = If(IsDBNull(dt.Rows(0)("deptcand")), "", dt.Rows(0)("deptcand"))
            Dim freedom = If(IsDBNull(dt.Rows(0)("freedom")), "", dt.Rows(0)("freedom"))
            Dim relative = If(IsDBNull(dt.Rows(0)("relative")), "", dt.Rows(0)("relative"))
            Dim draft = If(IsDBNull(dt.Rows(0)("draft")), "", dt.Rows(0)("draft"))
            Dim resume1 = If(IsDBNull(dt.Rows(0)("resume")), "", dt.Rows(0)("resume"))
            Dim qualification1 = If(IsDBNull(dt.Rows(0)("qualification1")), "", dt.Rows(0)("qualification1"))
            Dim qualification2 = If(IsDBNull(dt.Rows(0)("qualification2")), "", dt.Rows(0)("qualification2"))
            Dim qualification3 = If(IsDBNull(dt.Rows(0)("qualification3")), "", dt.Rows(0)("qualification3"))
            Dim qualification4 = If(IsDBNull(dt.Rows(0)("qualification4")), "", dt.Rows(0)("qualification4"))
            Dim qualification5 = If(IsDBNull(dt.Rows(0)("qualification5")), "", dt.Rows(0)("qualification5"))
            Dim last_updated = If(IsDBNull(dt.Rows(0)("last_updated")), "", dt.Rows(0)("last_updated"))
            '''''###############################################
            '''  
            ''' 
            Dim ref = "Ref: BIFPCL/HR/Job/Application: " & appID & "                Date: " & last_updated 'Now.ToString("dd.MM.yyyy")

            Dim doc As New Document(PageSize.A4, 40.0F, 10.0F, 30.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                '  doc.NewPage()
                ''' Loop through Page 1
                ''' 
                Dim j = 0
                Dim idCardPerPage = 25
                Dim t2Horizontal = 0
                Dim tVertical = 0
                Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                Dim phrase As Phrase = Nothing
                Dim cell As PdfPCell = Nothing
                Dim table As PdfPTable = Nothing
                Dim color__1 As BaseColor = Nothing




                'reference Details
                Dim htable = New PdfPTable(2)
                htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                htable.TotalWidth = 460.0F
                htable.SetWidths(New Single() {60.0F, 400.0F})

                Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                pic.ScaleAbsolute(60.0F, 60.0F)
                cell = New PdfPCell(pic)
                cell.BorderColor = BaseColor.WHITE
                htable.AddCell(cell)

                table = New PdfPTable(2)
                table.HorizontalAlignment = Element.ALIGN_LEFT
                table.SetWidths(New Single() {0.5F, 1.2F})
                table.SpacingBefore = 20.0F
                table.WidthPercentage = 90

                phrase = New Phrase()
                phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
                'cell.Colspan = 2
                htable.AddCell(cell)
                doc.Add(htable)
                'Separater Line
                color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                cellBlank.Colspan = 2
                cellBlank.PaddingBottom = 8.0F
                ' table.AddCell(cellBlank)
                Dim btable = New PdfPTable(2)
                btable.HorizontalAlignment = Element.ALIGN_LEFT
                btable.TotalWidth = 460.0F
                btable.SetWidths(New Single() {380.0F, 80.0F})
                btable.SpacingBefore = 20.0F
                btable.WidthPercentage = 90


                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)

                cell.Colspan = 2
                ' cell.Rowspan = 2
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Application Form ", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                ' cell.Colspan = 2
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                btable.AddCell(cell)
                imagePath = String.Format("~/upload/HR/Career/{0}.jpg", appID)
                If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                    imagePath = String.Format("~/images/{0}.jpg", "user")
                End If
                Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                mypic.ScaleAbsolute(80.0F, 90.0F)
                cell = New PdfPCell(mypic)
                cell.Rowspan = 7
                cell.BorderColor = BaseColor.WHITE
                btable.AddCell(cell)





                cell = PhraseCell(New Phrase("Unique Application ID:   " & appID, FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("  ", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)

                cell = PhraseCell(New Phrase("Email: " & email, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)
                cell = PhraseCell(New Phrase("Contact:  " & Contact, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                btable.AddCell(cell)

                doc.Add(btable)

                '''
                cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Mother's Name:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(mother, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Gender:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(sex, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Date of Birth", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(dob, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                ' End If
                '  table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("NID No:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                ' cell.Colspan = 2
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(nid, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)

                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Communication Address:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(addressc, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Permanent Address:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(addressp, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Total Work Experience:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(ncert, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Current/Last Work Exp:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(workexp, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Company:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(Detail, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)

                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Qualification 1:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(qualification1, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)

                If Not qualification2.ToString.StartsWith("NA") Then
                    cell = PhraseCell(New Phrase("Qualification 2:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification2, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If
                If Not qualification3.ToString.StartsWith("NA") Then
                    cell = PhraseCell(New Phrase("Qualification 3:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification3, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If
                If Not qualification4.ToString.StartsWith("NA") Then
                    cell = PhraseCell(New Phrase("Qualification 4:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification4, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If
                If Not qualification5.ToString.StartsWith("NA") Then
                    cell = PhraseCell(New Phrase("Qualification 5:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(qualification5, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    cell.BorderColor = BaseColor.BLACK
                    table.AddCell(cell)
                End If

                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Are you currently employed Or were employed by BIFPCL:" & deptcand, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                cell.Colspan = 2
                table.AddCell(cell)
                'cell = PhraseCell(New Phrase(, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'table.AddCell(cell)
                cell = PhraseCell(New Phrase("Are you a son/grand-son or daughter/grand-daughter of freedom fighter(s)/martyred freedom fighter(s): " & freedom, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                cell.Colspan = 2
                table.AddCell(cell)
                'cell = PhraseCell(New Phrase(freedom, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'table.AddCell(cell)
                cell = PhraseCell(New Phrase("Do You Have Any Relative In BIFPCL: " & relative, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                cell.Colspan = 2
                table.AddCell(cell)

                cell = PhraseCell(New Phrase("Online Payment Transaction ID(Txn. ID):", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(draft, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Degree Certificate:", FontFactory.GetFont("Arial", 11, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(resume1, FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Declaration:" & vbCrLf & "I hereby declare that all the statements made in this application are true, complete and correct to the best of my knowledge and belief. I understand that in the event of any information being found false at any stage or not satisfying the eligibility criteria specified for the post, my candidature/ appointment is liable to be cancelled/terminated. I declare that i will join the post, if selected within a period of 2 months from the date of issue of offer letter.", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                cell.Colspan = 2
                table.AddCell(cell)


                ''
                table.AddCell(cellBlank)
                doc.Add(table)

                Dim imageSign = String.Format("~/upload/HR/Career/s{0}.jpg", appID)
                If Not System.IO.File.Exists(Server.MapPath(imageSign)) Then
                    imageSign = String.Format("~/images/{0}.png", "logo")
                End If
                Dim picSign As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imageSign))
                'image.ScalePercent(scale)
                picSign.ScaleAbsolute(90.0F, 23.0F)
                doc.Add(picSign)

                phrase = New Phrase()
                phrase.Add(New Chunk("Signature of Candidate" & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("(" & name.ToString & ")" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Note: System Generated Application. Candidates copy. (c)2018 www.bifpcl.com " & vbLf & vbLf, FontFactory.GetFont("Arial", 8, Font.BOLDITALIC, BaseColor.BLACK)))

                doc.Add(phrase)



                ''''' Now add another page with summary sheet.
                '''
                doc.NewPage()
                doc.Add(htable)
                'Separater Line
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                phrase = New Phrase()
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                'phrase.Add(New Chunk("Candidates need to download and sign filled application form and send it by post/by courier/by hand; to the Chief Human Resources Officer, Bangladesh-India Friendship Power Company (Pvt.) Limited, Unique Heights Borak (Level-17), 117 Kazi Nazrul Islam Avenue, Eskaton Garden, Dhaka-1000 on or before the office hours of 30th April 2019 (6:00 PM)" & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                'phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Unique Application ID:   " & appID.ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Post Applied:   " & jobdetail.ToString.Replace(vbCr, "").Replace(vbLf, "") & ",Post ID " & jobid.ToString & vbCrLf & vbCrLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))

                phrase.Add(New Chunk("Checklist (Points to remember)" & vbLf, FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)))
                'phrase.Add(New Chunk("Last date of receipt of online application is: 15th August 2019 (06:00 P.M BST)" & vbLf, FontFactory.GetFont("Arial", 11, Font.BOLD, BaseColor.BLACK)))

                phrase.Add(New Chunk("Following needs to be taken care of for the next round of recruitment process:", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)))
                doc.Add(phrase)
                Dim ltable = New PdfPTable(2)
                ltable.HorizontalAlignment = Element.ALIGN_LEFT
                ltable.SetWidths(New Single() {1.3F, 0.4F})
                ltable.SpacingBefore = 20.0F
                ltable.WidthPercentage = 90
                cell = PhraseCell(New Phrase("Description", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Tick Mark", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)

                cell = PhraseCell(New Phrase("1. My signature in the application form is correct:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("2. I have mentioned correct online payment transaction ID in the application:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("3. I have note down online payment transaction ID and Unique application ID for future reference :", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("4. I have attested copy of National ID Card", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("5. I have Attested copies of all educational certificates (starting from SSC or equivalent):", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("6. I have Attested copies of all experience certificates:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("7. I have Nationality certificate in original:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("8. I have 03(three) attested copies of recent PP size photographs:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                'cell = PhraseCell(New Phrase("9. Pay Order/Bank Draft for BDT. 1000/- payable in favor of 'Bangladesh-India Friendship Power Company (Pvt.) Limited':", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'ltable.AddCell(cell)
                'cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'cell.BorderColor = BaseColor.BLACK
                'ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("9. I have Detailed & Signed CV/Resume:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)

                cell = PhraseCell(New Phrase("10. If availing age relaxation- (a) attested copies of certificates issued to Freedom Fighters/ Martyred Freedom Fighters by the appropriate authority. (b) certificate (In Original) issued from the respective Union Parishad Chairman/ Ward Commissioner of City Corporation/ Pourashava Mayor/ Counselor mentioning their relationship with the Freedom Fighters/ Martyred Freedom Fighters.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("11. If passed from foreign university(ies)/Institute(s) - attested copies of equivalence certificate/result issued from a competent authority recognized by government.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("12. I understand that Unique Application ID will be required for download of Admit Card:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("13. I understand that no printout or documents needs to be sent by post:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                doc.Add(ltable)
                phrase = New Phrase()
                ' phrase.Add(New Chunk("Signature of Candidate" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(name.ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Note: Candidate may keep this pdf for future reference/communication. No need to send by Post." & vbLf & " (c)2018 www.bifpcl.com" & vbLf & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))
                doc.Add(phrase)
                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=application" & appID & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printVehicle(ByVal appid As String)
        'Dim appID = Session("leaveAppID")

        Dim ref = "Ref: BIFPCL/HR/Vehicle/Application: " & appid & "                Date: " & Now.AddHours(6).ToString("dd.MM.yyyy")
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."


        Dim q = "select  case when reporting > current_timestamp then '' || uid else '0' end as Action, cast(uid as text) as Print, strftime('%d.%m.%Y %H:%M',reporting) as 'Reporting Time', strftime('%d.%m.%Y %H:%M',returning) as 'returning', seats ,  v.vehicle as 'Vehicle', driver as Driver, driverno as 'Driver No', aremark as 'Approver Remark', status as 'Booking Status', triptype, source as 'Reporting Address', destination, occupants as 'Passengers' , remark as reason, eid from vehiclebook b left outer join vehicle v on b.vehicle = v.vid where uid = '" & appid & "' order by reporting desc limit 1"
        Try
            Dim dt = getDBTable(q, "appsdb")
            If dt.Rows.Count < 1 Then
                divMsg.InnerHtml = "No Records found for requested ID load failed.." & appid
                Exit Sub
            End If
            Dim email = If(IsDBNull(dt.Rows(0)("eid")), "", dt.Rows(0)("eid"))
            Dim name = getDBsingle("select name || ', ' || desig from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim org = getDBsingle("select org from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim workarea = getDBsingle("select workarea from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim mobile = getDBsingle("select cell from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim dt_st_outTime = ""
            Dim dt_st_inTime = ""
            Dim duration = ""
            Dim absence = 0
            Dim lbOut = "Reporting Time:"
            Dim lbIn = "Releasing Time:"
            Dim lbAbsence = "Reporting Place:"
            Dim dt_st_out, dt_st_in As Date

            dt_st_outTime = If(IsDBNull(dt.Rows(0)("returning")), "", dt.Rows(0)("returning"))
            dt_st_inTime = If(IsDBNull(dt.Rows(0)("Reporting Time")), "", dt.Rows(0)("Reporting Time"))
            '  duration = If(IsDBNull(dt.Rows(0)("duration")), "", dt.Rows(0)("duration"))
            '   absence = duration - 1
            '  Dim txtdt_st_out = If(IsDBNull(dt.Rows(0)("dt_st_out")), "0000-00-00", dt.Rows(0)("dt_st_out"))
            '  Dim txtdt_st_in = If(IsDBNull(dt.Rows(0)("dt_st_in")), "0000-00-00", dt.Rows(0)("dt_st_in"))
            '  dt_st_out = DateTime.ParseExact(txtdt_st_out, "yyyy-M-dd", Nothing)
            ' dt_st_in = DateTime.ParseExact(txtdt_st_in, "yyyy-M-dd", Nothing)
            Dim Passengers = If(IsDBNull(dt.Rows(0)("Passengers")), "", dt.Rows(0)("Passengers"))
            Dim l1fromto = "" 'If(IsDBNull(dt.Rows(0)("l1fromto")), "", dt.Rows(0)("l1fromto"))
            Dim l1duration = "" 'If(IsDBNull(dt.Rows(0)("l1duration")), "", dt.Rows(0)("l1duration"))
            Dim l2type = "" 'If(IsDBNull(dt.Rows(0)("l2type")), "", dt.Rows(0)("l2type"))
            Dim l2fromto = "" 'If(IsDBNull(dt.Rows(0)("l2fromto")), "", dt.Rows(0)("l2fromto"))
            Dim l2duration = "" 'If(IsDBNull(dt.Rows(0)("l2duration")), "", dt.Rows(0)("l2duration"))
            Dim l3type = "" 'If(IsDBNull(dt.Rows(0)("l3type")), "", dt.Rows(0)("l3type"))
            Dim l3fromto = "" 'If(IsDBNull(dt.Rows(0)("l3fromto")), "", dt.Rows(0)("l3fromto"))
            Dim l3duration = "" 'If(IsDBNull(dt.Rows(0)("l3duration")), "", dt.Rows(0)("l3duration"))
            Dim purpose = If(IsDBNull(dt.Rows(0)("triptype")), "", dt.Rows(0)("triptype"))
            Dim address = If(IsDBNull(dt.Rows(0)("Reporting Address")), "", dt.Rows(0)("Reporting Address"))
            Dim destination = If(IsDBNull(dt.Rows(0)("destination")), "", dt.Rows(0)("destination"))
            Dim seats = If(IsDBNull(dt.Rows(0)("seats")), "", dt.Rows(0)("seats"))
            Dim remark = If(IsDBNull(dt.Rows(0)("Approver Remark")), "", dt.Rows(0)("Approver Remark"))
            Dim reason = If(IsDBNull(dt.Rows(0)("reason")), "", dt.Rows(0)("reason"))
            '''''###############################################
            Dim doc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                '  doc.NewPage()
                ''' Loop through Page 1
                ''' 
                Dim j = 0
                Dim idCardPerPage = 25
                Dim t2Horizontal = 0
                Dim tVertical = 0
                Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                Dim phrase As Phrase = Nothing
                Dim cell As PdfPCell = Nothing
                Dim table As PdfPTable = Nothing
                Dim color__1 As BaseColor = Nothing




                'reference Details
                Dim htable = New PdfPTable(2)
                htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                htable.TotalWidth = 460.0F
                htable.SetWidths(New Single() {60.0F, 400.0F})

                Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                pic.ScaleAbsolute(60.0F, 60.0F)
                cell = New PdfPCell(pic)
                cell.BorderColor = BaseColor.WHITE
                htable.AddCell(cell)

                table = New PdfPTable(2)
                table.HorizontalAlignment = Element.ALIGN_LEFT
                table.SetWidths(New Single() {0.7F, 1.0F})
                table.SpacingBefore = 20.0F
                table.WidthPercentage = 90

                phrase = New Phrase()
                phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE)
                'cell.Colspan = 2
                htable.AddCell(cell)
                doc.Add(htable)
                'Separater Line
                color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                cellBlank.Colspan = 2
                cellBlank.PaddingBottom = 15.0F
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.Colspan = 2
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_CENTER)
                cell.Colspan = 2
                cell.PaddingBottom = 30.0F
                table.AddCell(cell)
                '''
                table.AddCell(cellBlank)
                'phrase = New Phrase()
                'phrase.Add(New Chunk("To" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)))
                'phrase.Add(New Chunk("Gate Pass Approving Authority" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'phrase.Add(New Chunk("2X660MW MAITREE STPP, " & auth & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
                'cell.Colspan = 2
                'table.AddCell(cell)
                ''
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Vehicle Booking Request", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                'cell = PhraseCell(New Phrase(appType, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'table.AddCell(cell)
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Name:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' If appType.Contains("Out") Then
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(lbOut, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(dt_st_inTime, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(lbIn, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(dt_st_outTime, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(lbAbsence, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(address.ToString, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Destination:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(destination.ToString, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)

                ' End If
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("No Of Seats:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(seats.ToString, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Passenger Details:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.Colspan = 2
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(" " & Passengers, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(l1fromto & " (" & l1duration & " Days)", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Booking Type:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(purpose, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Reason:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(reason.ToString, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                'cell = PhraseCell(New Phrase("Approver Remark:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'table.AddCell(cell)
                'cell = PhraseCell(New Phrase(remark, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                'table.AddCell(cell)


                ''
                table.AddCell(cellBlank)


                doc.Add(table)

                phrase = New Phrase()
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Signature of Employee" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(name & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Parent org:" & org & ", Location: " & workarea & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Phone: " & mobile & " Email:" & Session("email").ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Approved By HOD" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("(HR Allotment)" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" SMS will be sent with vehicle and driver detail after approval." & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))

                phrase.Add(New Chunk("Note: System Generated Application. No cutting/overwriting is allowed." & vbLf & vbLf & ". Only Name mentioned in Passenger details shall be allowed in vehicle.", FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))

                doc.Add(phrase)

                doc.Add(cellBlank)



                ''''' Now add another page with summary sheet.
                '''
                ' doc.NewPage()


                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=vehicle" & appid & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Sub printLeave()
        Dim appID = Session("leaveAppID")

        Dim ref = "Ref: BIFPCL/HR/Leave/Application: " & appID & "                Date: " & Now.AddHours(6).ToString("dd.MM.yyyy")
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."


        Dim q = "select appid, apptype, email,dt_st_out,dt_st_in, Cast ((JulianDay(dt_st_in) - JulianDay(dt_st_out)) As Integer) as duration, strftime('%d.%m.%Y',dt_st_out) || ' ' || outtime as dt_st_outTime, strftime('%d.%m.%Y',dt_st_in) || ' ' || intime as dt_st_inTime, l1type,strftime('%d.%m.%Y',l1from) || ' - ' || strftime('%d.%m.%Y',l1to) as l1fromto,Cast ((JulianDay(l1to) - JulianDay(l1from)) As Integer) + 1 as l1duration, l1from, l1to ,l2type, strftime('%d.%m.%Y',l2from) || ' - ' || strftime('%d.%m.%Y',l2to) as l2fromto, Cast ((JulianDay(l2to) - JulianDay(l2from)) As Integer)+1 as l2duration, l2from,l2to,l3type,strftime('%d.%m.%Y',l3from) || ' - ' || strftime('%d.%m.%Y',l3to) as l3fromto,Cast ((JulianDay(l3to) - JulianDay(l3from)) As Integer)+1 as l3duration, l3from, l3to, strftime('%d.%m.%Y',dt_apply) as dt_apply,purpose,address, remark, last_updated,status from leaverequest where appid = '" & appID & "' limit 1"
        Try
            Dim dt = getDBTable(q, "hrdb")
            If dt.Rows.Count < 1 Then
                divMsg.InnerHtml = "No Records found for requested ID load failed.." & appID
                Exit Sub
            End If
            Dim appType As String = If(IsDBNull(dt.Rows(0)("apptype")), "", dt.Rows(0)("apptype"))
            appType = If(appType.Contains("Out"), "Out Station Application", "In Station Application")
            Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))
            Dim name = getDBsingle("select name || ', ' || desig from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim org = getDBsingle("select org from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim workarea = getDBsingle("select workarea from contacts_New where email = '" & email & "' limit 1", "hrdb")
            Dim dt_st_outTime = ""
            Dim dt_st_inTime = ""
            Dim duration = ""
            Dim absence = 0
            Dim lbOut = "Start Date of Leave:"
            Dim lbIn = "End Date of Leave:"
            Dim lbAbsence = "Total Absence:"
            Dim dt_st_out, dt_st_in As Date
            If appType.Contains("Out") Then
                lbOut = "Date of Leaving Station:"
                lbIn = "Date of Joining Station:"
                lbAbsence = "Total Absence from HQ/Site(Excluding journey date):"
            End If
            dt_st_outTime = If(IsDBNull(dt.Rows(0)("dt_st_outTime")), "", dt.Rows(0)("dt_st_outTime"))
            dt_st_inTime = If(IsDBNull(dt.Rows(0)("dt_st_inTime")), "", dt.Rows(0)("dt_st_inTime"))
            duration = If(IsDBNull(dt.Rows(0)("duration")), "", dt.Rows(0)("duration"))
            absence = duration - 1
            Dim txtdt_st_out = If(IsDBNull(dt.Rows(0)("dt_st_out")), "0000-00-00", dt.Rows(0)("dt_st_out"))
            Dim txtdt_st_in = If(IsDBNull(dt.Rows(0)("dt_st_in")), "0000-00-00", dt.Rows(0)("dt_st_in"))
            dt_st_out = DateTime.ParseExact(txtdt_st_out, "yyyy-M-dd", Nothing)
            dt_st_in = DateTime.ParseExact(txtdt_st_in, "yyyy-M-dd", Nothing)
            Dim l1type = If(IsDBNull(dt.Rows(0)("l1type")), "", dt.Rows(0)("l1type"))
            Dim l1fromto = If(IsDBNull(dt.Rows(0)("l1fromto")), "", dt.Rows(0)("l1fromto"))
            Dim l1duration = If(IsDBNull(dt.Rows(0)("l1duration")), "", dt.Rows(0)("l1duration"))
            Dim l2type = If(IsDBNull(dt.Rows(0)("l2type")), "", dt.Rows(0)("l2type"))
            Dim l2fromto = If(IsDBNull(dt.Rows(0)("l2fromto")), "", dt.Rows(0)("l2fromto"))
            Dim l2duration = If(IsDBNull(dt.Rows(0)("l2duration")), "", dt.Rows(0)("l2duration"))
            Dim l3type = If(IsDBNull(dt.Rows(0)("l3type")), "", dt.Rows(0)("l3type"))
            Dim l3fromto = If(IsDBNull(dt.Rows(0)("l3fromto")), "", dt.Rows(0)("l3fromto"))
            Dim l3duration = If(IsDBNull(dt.Rows(0)("l3duration")), "", dt.Rows(0)("l3duration"))
            Dim purpose = If(IsDBNull(dt.Rows(0)("purpose")), "", dt.Rows(0)("purpose"))
            Dim address = If(IsDBNull(dt.Rows(0)("address")), "", dt.Rows(0)("address"))
            Dim remark = If(IsDBNull(dt.Rows(0)("remark")), "", dt.Rows(0)("remark"))
            '''''###############################################
            Dim doc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                '  doc.NewPage()
                ''' Loop through Page 1
                ''' 
                Dim j = 0
                Dim idCardPerPage = 25
                Dim t2Horizontal = 0
                Dim tVertical = 0
                Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


                Dim phrase As Phrase = Nothing
                Dim cell As PdfPCell = Nothing
                Dim table As PdfPTable = Nothing
                Dim color__1 As BaseColor = Nothing




                'reference Details
                Dim htable = New PdfPTable(2)
                htable.HorizontalAlignment = Element.ALIGN_MIDDLE
                htable.TotalWidth = 460.0F
                htable.SetWidths(New Single() {60.0F, 400.0F})

                Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                'image.ScalePercent(scale)
                pic.ScaleAbsolute(60.0F, 60.0F)
                cell = New PdfPCell(pic)
                cell.BorderColor = BaseColor.WHITE
                htable.AddCell(cell)

                table = New PdfPTable(2)
                table.HorizontalAlignment = Element.ALIGN_LEFT
                table.SetWidths(New Single() {0.7F, 1.0F})
                table.SpacingBefore = 20.0F
                table.WidthPercentage = 90

                phrase = New Phrase()
                phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE)
                'cell.Colspan = 2
                htable.AddCell(cell)
                doc.Add(htable)
                'Separater Line
                color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                Dim cellBlank = PhraseCell(New Phrase(" "), PdfPCell.ALIGN_CENTER)
                cellBlank.Colspan = 2
                cellBlank.PaddingBottom = 15.0F
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.Colspan = 2
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_CENTER)
                cell.Colspan = 2
                cell.PaddingBottom = 30.0F
                table.AddCell(cell)
                '''
                table.AddCell(cellBlank)
                'phrase = New Phrase()
                'phrase.Add(New Chunk("To" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)))
                'phrase.Add(New Chunk("Gate Pass Approving Authority" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'phrase.Add(New Chunk("2X660MW MAITREE STPP, " & auth & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                'cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
                'cell.Colspan = 2
                'table.AddCell(cell)
                ''
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Leave:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(appType, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Name:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(name, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' If appType.Contains("Out") Then
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(lbOut, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(dt_st_outTime, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase(lbIn, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(dt_st_inTime, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(lbAbsence, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(absence.ToString & " Day(s)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' End If
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Leave Details:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.Colspan = 2
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("1. " & l1type, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(l1fromto & " (" & l1duration & " Days)", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                ' table.AddCell(cellBlank)
                If Not l2type = "- - -" Then
                    cell = PhraseCell(New Phrase("2. " & l2type, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(l2fromto & " (" & l2duration & " Days)", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    table.AddCell(cell)
                End If
                If Not l3type = "- - -" Then
                    cell = PhraseCell(New Phrase("3. " & l3type, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    table.AddCell(cell)
                    cell = PhraseCell(New Phrase(l3fromto & " (" & l3duration & " Days)", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                    table.AddCell(cell)
                End If
                table.AddCell(cellBlank)
                cell = PhraseCell(New Phrase("Purpose of Leave:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(purpose, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Address during leave period: ", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(address, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase("Remark:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)
                cell = PhraseCell(New Phrase(remark, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                table.AddCell(cell)


                ''
                table.AddCell(cellBlank)
                doc.Add(table)
                '''################## CALANDER ################
                '''
                Dim CalDays = absence + 6
                Dim pdfTable As New PdfPTable(CalDays)
                pdfTable.DefaultCell.Padding = 3
                pdfTable.WidthPercentage = 100
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
                pdfTable.DefaultCell.BorderWidth = 1
                j = 0
                'For Each c As DataColumn In dt.Columns
                '    Dim cell1 As New PdfPCell(New Phrase(c.ToString))
                '    pdfTable.AddCell(cell1)
                'Next
                Dim dates As New List(Of String)
                Dim wkdays As New List(Of String)
                Dim colors As New List(Of String)
                Dim gh As New List(Of String)
                Dim myday = dt_st_out.AddDays(-2)
                For i = 0 To CalDays - 1
                    dates.Add(myday.ToString("%d.%M"))
                    wkdays.Add(Left(myday.DayOfWeek.ToString, 3))
                    Dim holiday = checkHoliday(myday, org, workarea)
                    If myday.DayOfWeek = 5 Then : colors.Add("PINK")
                    ElseIf myday.DayOfWeek = 6 And workarea = "HO" Then : colors.Add("PINK")
                    ElseIf Not holiday.Contains("Error") Then
                        colors.Add("GREEN")
                        gh.Add(myday.ToString("%d.%M") & " - " & holiday)
                    Else
                        colors.Add("WHITE")
                    End If
                    myday = myday.AddDays(1)
                Next
                For Each d In dates
                    Dim cell1 As New PdfPCell(New Phrase(d.ToString, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))
                    pdfTable.AddCell(cell1)
                Next
                For Each d In dates
                    Dim cell1 As New PdfPCell(New Phrase(wkdays(dates.IndexOf(d.ToString)), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                    If colors(dates.IndexOf(d.ToString)) = "PINK" Then cell1.BackgroundColor = BaseColor.PINK
                    If colors(dates.IndexOf(d.ToString)) = "GREEN" Then cell1.BackgroundColor = BaseColor.GREEN
                    pdfTable.AddCell(cell1)
                Next
                pdfTable.AddCell(cellBlank)
                Dim ghString = ""
                For Each g In gh
                    ghString = ghString & g
                Next

                ''###########################################################
                phrase = New Phrase()
                phrase.Add(New Chunk(ghString, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLUE)))

                doc.Add(pdfTable)
                doc.Add(phrase)

                phrase = New Phrase()
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Signature of Employee" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(name & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Parent org:" & org & ", Location: " & workarea & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk("Email:" & Session("email").ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Recommended By" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Approved By" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Note: System Generated Application. No cutting/overwriting is allowed." & vbLf & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))

                doc.Add(phrase)

                doc.Add(cellBlank)



                ''''' Now add another page with summary sheet.
                '''
                ' doc.NewPage()


                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=leave" & appID & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = "Error " & ex.Message '& q
        End Try
    End Sub
    Function checkHoliday(ByVal dt As Date, ByVal org As String, ByVal location As String) As String
        If org = "BIFPCL" Then
            org = "BPDB"  ''for BIFPCL staff holiday shall be same as BPDB and location shall be %
            '     location = "%"
        End If
        If dt.Year < 2019 And org = "NTPC" Then location = "%" '' pre 2019 same holiday calander
        'Dim q = "select holiday from holiday where holidaydate = '" & dt.ToString("yyyy-MM-dd") & "' and org like '" & org & "' "
        If Cache("mydtH") Is Nothing Then
            Dim q = "select holiday,holidaydate, org, loc from holiday where 1"
            Dim mydt = getDBTable(q, "hrdb")
            Cache.Insert("mydtH", mydt, Nothing, DateTime.Now.AddHours(24.0), TimeSpan.Zero)
        End If
        Dim finaldt = Cache("mydtH")
        Dim hrow() As DataRow = finaldt.Select("holidaydate = '" & dt.ToString("yyyy-MM-dd") & "' AND  org like '" & org & "' AND loc like '" & location & "'")
        If hrow.Count > 0 Then
            Return hrow(0).Item("holiday")
        Else
            Return "Error"
        End If

    End Function
    Sub printCover(ByVal type As String, ByVal agency As String, ByVal passtype As String)
        Dim bodytop = "This has reference to above mentioned subject, we are forwarding the following card for fresh issue."
        Dim bodybottom = "In view of the above, we request you to kindly approve the gate pass of the " & agency & " employees for smooth movement of work at the Project site."
        If passtype = "Renew" Then
            bodytop = "This has reference to above mentioned subject, we are forwarding the following card for further renewal which has already been expired or going to be expired."
        End If
        If passtype = "Cancel" Then
            bodytop = "This has reference to above mentioned subject, we are forwarding the following card for cancellation."
        End If
        If passtype = "Temp" Then
            bodytop = "This has reference to above mentioned subject, we are forwarding the following card for Temporary Gate Pass (7 days Validity)."
        End If
        Dim ref = "Ref: BIFPCL: MSTPP: GATEPASS: " & Now.Year & "/" & Now.Month & "                Date: " & Now.ToString("dd.MM.yyyy")
        Dim head = "Bangladesh-India Friendship Power Company (Pvt) Ltd." '"BHARAT HEAVY ELECTRICALS LIMITED"
        Dim auth = "BIFPCL"
        If type = "Agency" Then
            ref = "Ref: " & Left(agency, 10) & " MSTPP: HRM: GATEPASS: " & Now.Year & "/" & Now.Month & "                Date: " & Now.ToString("dd.MM.yyyy")
            ' head = agency
            auth = "BHEL"
        End If
        Dim list = CType(Session("printCoverID"), List(Of String))
        Dim IDcommaseparated = String.Join(",", list)
        divMsg.InnerHtml = IDcommaseparated
        Dim totalID = list.Count

        ''dont touch first 9 columns
        Dim q = "select passtype || ' - ' || id as 'Gate Pass ID',name as 'Name',father as 'Father', nationality as 'Nationality',nid as 'NID/Passport',desig as 'Desig',cell as 'Contact',strftime('%d.%m.%Y',validity_start) as 'V. Start',strftime('%d.%m.%Y',validity_end) as 'V. End', strftime('%d.%m.%Y',pre_test_date) as pre_test_date, strftime('%d.%m.%Y',post_test_date) as post_test_date, subagency as 'Sub Agency', temp, id as photo, visa, strftime('%d.%m.%Y',visaexp) as 'Visa Exp', sex , age , 'Village: ' || ifnull(village,'') || ' PO:' || ifnull(po,'') || ' PS:' || ifnull(ps,'') || 'Dist:' || ifnull(district,'') as 'Address', mainagency as 'Work Partner', subagency, strftime('%d.%m.%Y', dob) as dob,  compliance, area, bgroup,desig,cat from gatepass where id in ( " & IDcommaseparated & ") "
        Dim dt = dbOp.getDBTable(q, "gpdb")
        If dt.Rows.Count < 1 Then
            divMsg.InnerHtml = "No Records found for requested ID load failed.." & IDcommaseparated
            Exit Sub
        End If
        '''''###############################################
        Dim doc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 10.0F)
        Using memoryStream As New MemoryStream()
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
            doc.Open()
            '  doc.NewPage()
            ''' Loop through Page 1
            ''' 
            Dim j = 0
            Dim idCardPerPage = 25
            Dim t2Horizontal = 0
            Dim tVertical = 0
            Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
            Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
            Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
            Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
            Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)


            Dim phrase As Phrase = Nothing
            Dim cell As PdfPCell = Nothing
            Dim table As PdfPTable = Nothing
            Dim color__1 As BaseColor = Nothing


            'Header Table
            'table = New PdfPTable(2)
            'table.TotalWidth = 280.0F
            'table.LockedWidth = True
            'table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
            'table.DefaultCell.BorderWidth = 0
            'table.SetWidths(New Single() {140.0F, 140.0F})

            'Company Logo
            'cell = ImageCell("~/images/northwindlogo.gif", 30.0F, PdfPCell.ALIGN_CENTER)
            'table.AddCell(cell)

            'Company Name and Address
            'phrase = New Phrase()
            'phrase.Add(New Chunk("BHARAT HEAVY ELECTRICALS LIMITED" & vbLf & vbLf, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)))
            'phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("2X660MW MAITREE STPP" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            ' cell.VerticalAlignment = PdfCell.ALIGN_TOP
            'table.AddCell(cell)
            'doc.Add(table)
            ''Separater Line
            'color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
            'DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
            'DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
            'reference Details
            Dim htable = New PdfPTable(2)
            htable.HorizontalAlignment = Element.ALIGN_MIDDLE
            htable.TotalWidth = 460.0F
            htable.SetWidths(New Single() {60.0F, 400.0F})

            Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
            'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
            Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
            'image.ScalePercent(scale)
            pic.ScaleAbsolute(60.0F, 60.0F)
            cell = New PdfPCell(pic)
            cell.BorderColor = BaseColor.WHITE
            htable.AddCell(cell)
            phrase = New Phrase()
            phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
            ' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            '  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER)
            'cell.Colspan = 2
            htable.AddCell(cell)
            doc.Add(htable)

            table = New PdfPTable(2)
            table.HorizontalAlignment = Element.ALIGN_LEFT
            table.SetWidths(New Single() {0.3F, 1.0F})
            table.SpacingBefore = 20.0F
            table.WidthPercentage = 90
            'reference Details

            'phrase = New Phrase()
            'phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLUE)))
            '' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("2X660MW MAITREE STPP" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            'cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            'cell.Colspan = 2
            'table.AddCell(cell)
            'Separater Line
            color__1 = BaseColor.BLACK  'New Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"))
            DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
            DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
            Dim cellBlank = PhraseCell(New Phrase("."), PdfPCell.ALIGN_CENTER)
            cellBlank.Colspan = 2
            cellBlank.PaddingBottom = 3.0F
            table.AddCell(cellBlank)
            cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_CENTER)
            cell.Colspan = 2
            cell.PaddingBottom = 3.0F
            table.AddCell(cell)
            '''
            table.AddCell(cellBlank)
            phrase = New Phrase()
            phrase.Add(New Chunk("To" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)))
            phrase.Add(New Chunk("Gate Pass Approving Authority" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("2X660MW MAITREE STPP, " & auth & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("RAMPAL, BAGERHAT, BANGLADESH", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            ''
            table.AddCell(cellBlank)
            cell = PhraseCell(New Phrase("Subject: " & passtype & " Gate pass for our/vendor's employee - reg ", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            cell.PaddingBottom = 30.0F
            table.AddCell(cell)
            '''
            table.AddCell(cellBlank)
            phrase = New Phrase()
            phrase.Add(New Chunk("Dear Sir" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)))
            phrase.Add(New Chunk(bodytop & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            ''
            table.AddCell(cellBlank)
            cell = PhraseCell(New Phrase("Agency: " & agency & vbCrLf & "Gate Pass ID Submitted for approval: Total " & totalID & " Nos." & vbCrLf & IDcommaseparated, FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            cell.PaddingBottom = 30.0F
            table.AddCell(cell)
            '''
             ''
            table.AddCell(cellBlank)
            cell = PhraseCell(New Phrase(bodybottom, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            cell.PaddingBottom = 30.0F
            table.AddCell(cell)
            ''
            table.AddCell(cellBlank)
            cell = PhraseCell(New Phrase("Regards,", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            cell.PaddingBottom = 30.0F
            table.AddCell(cell)
            '''
            '''
            table.AddCell(cellBlank)
            phrase = New Phrase()
            phrase.Add(New Chunk("(Signature with Seal)" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("Email:" & Session("email").ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
            phrase.Add(New Chunk("Enclosure:" & vbLf, FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.BLACK)))
            phrase.Add(New Chunk("1: System Generated " & passtype & " Summary Sheet for the Gate Pass requested.", FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.BLACK)))

            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT)
            cell.Colspan = 2
            table.AddCell(cell)
            doc.Add(table)

            ''''' Now add another page with summary sheet.
            '''
            doc.SetPageSize(PageSize.A4.Rotate())
            doc.NewPage()

            doc.Add(htable)
            'Separater Line
            DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
            DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
            phrase = New Phrase
            phrase.Add(New Chunk("Summary Sheet  (" & totalID & " Nos.): " & agency & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)))
            doc.Add(phrase)
            Dim pdfTable As New PdfPTable(14)
            pdfTable.DefaultCell.Padding = 3
            pdfTable.WidthPercentage = 100
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
            pdfTable.DefaultCell.BorderWidth = 1
            j = 0
            Dim k = 0
            ''print column
            For Each c As DataColumn In dt.Columns
                Dim cell1 As New PdfPCell(New Phrase(c.ToString))
                pdfTable.AddCell(cell1)
                If k = 13 Then Exit For
                k = k + 1
            Next


            k = 0
            For Each dr As DataRow In dt.Rows
                'If j Mod idCardPerPage = 0 Then

                '    doc.NewPage()
                '    j = 0
                'End If
                Dim l = 0
                For Each c As DataColumn In dt.Columns
                    If Not l = 13 Then
                        Dim cell1 = PhraseCell(New Phrase(dr(c).ToString, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)
                        pdfTable.AddCell(cell1)
                    ElseIf l = 13 Then
                        imagePath = String.Format("~/upload/gatepass/{0}.jpg", dr(c).ToString)
                        If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                            imagePath = String.Format("~/images/{0}.jpg", "user")
                        End If
                        Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                        'image.ScalePercent(scale)
                        mypic.ScaleAbsolute(70.0F, 70.0F)

                        Dim cell1 = New PdfPCell(mypic)
                        cell1.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                        ' Dim cell1 = PhraseCell(New Phrase(imagePath, FontFactory.GetFont("Arial", 9, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)

                        pdfTable.AddCell(cell1)
                    End If
                    If l = 13 Then Exit For
                    l = l + 1
                Next
                j = j + 1
                ' If k = 8 Then Exit For
                k = k + 1
            Next
            doc.Add(pdfTable)

            If Not (passtype = "Cancel") Then
                ''''' After approval Distribution sheet.
                '''
                doc.NewPage()
                doc.Add(htable)
                'Separater Line
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                phrase = New Phrase
                phrase.Add(New Chunk("After approval card distribution sheet(" & totalID & " Nos.): " & agency & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)))
                doc.Add(phrase)
                Dim pdfTable1 As New PdfPTable(9)
                pdfTable1.DefaultCell.Padding = 3
                pdfTable1.WidthPercentage = 100
                pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT
                pdfTable1.DefaultCell.BorderWidth = 1
                j = 0
                k = 0
                For Each c As DataColumn In dt.Columns
                    Dim text = c.ToString
                    If k = 6 Then text = "Sign of Gatepass Holder"
                    If k = 7 Then text = "Sign of Agency Rep."
                    If k = 8 Then text = "Date of issue"
                    Dim cell1 As New PdfPCell(New Phrase(text))
                    pdfTable1.AddCell(cell1)
                    If k = 8 Then Exit For
                    k = k + 1
                Next


                k = 0
                For Each dr As DataRow In dt.Rows
                    Dim l = 0
                    For Each c As DataColumn In dt.Columns
                        Dim text = dr(c).ToString
                        If l > 5 Then text = ""
                        Dim cell1 = PhraseCell(New Phrase(text, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT, True)
                        pdfTable1.AddCell(cell1)
                        If l = 8 Then Exit For
                        l = l + 1
                    Next
                    j = j + 1
                    ' If k = 8 Then Exit For
                    k = k + 1
                Next
                doc.Add(pdfTable1)
            End If
            ''''' Now add another page for undertaking.
            '''
            If passtype = "Temp" Then
                doc.SetPageSize(PageSize.A4)
                doc.NewPage()
                doc.Add(htable)
                'Separater Line
                DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                phrase = New Phrase()
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                'phrase.Add(New Chunk("Candidates need to download and sign filled application form and send it by post/by courier/by hand; to the Chief Human Resources Officer, Bangladesh-India Friendship Power Company (Pvt.) Limited, Unique Heights Borak (Level-17), 117 Kazi Nazrul Islam Avenue, Eskaton Garden, Dhaka-1000 on or before the office hours of 30th April 2019 (6:00 PM)" & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                'phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Date: " & Now.ToString("dd.MM.yyyy") & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(".                                  Undertaking   " & vbCrLf & vbCrLf, FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK)))

                phrase.Add(New Chunk("Period of validity: From ___________ To ______________" & vbLf, FontFactory.GetFont("Arial", 13, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("No of Persons:______" & vbLf & vbLf, FontFactory.GetFont("Arial", 11, Font.BOLD, BaseColor.BLACK)))

                phrase.Add(New Chunk("Following precautions will be taken for movement of manpower inside MSTPP,Rampal to prevent Covid-19 infection.", FontFactory.GetFont("Arial", 11, Font.NORMAL, BaseColor.BLACK)))
                doc.Add(phrase)
                Dim ltable = New PdfPTable(2)
                ltable.HorizontalAlignment = Element.ALIGN_LEFT
                ltable.SetWidths(New Single() {1.3F, 0.4F})
                ltable.SpacingBefore = 20.0F
                ltable.WidthPercentage = 90
                cell = PhraseCell(New Phrase("Description", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Tick Mark", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)

                cell = PhraseCell(New Phrase("1. All personnel, including staff, workers and drivers will have to undergo thermal scanning/medical checkup at the main gate.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("2. Anyone if found symptomatic will be denied entry.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("3. Nose mask is compulsory - to be used by all.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("4. Hand gloves is to be used by all while entering through main gate.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("5. Hand sanitizations is to be used by agency while entering through main gate.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("6. All safety PPE’s as required are to be used while entering through the main gate.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("7. All personnel will directly go to work place, maintain social distance and leave the site after completion of daily work.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("8. None of the personnel will go to any other area of the project site for any reason whatsoever.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("9. Mask, hand gloves and sanitizing to be followed strictly while discharging duty at site / work place.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("10. People only with valid gate pass will be allowed inside project site.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)

                cell = PhraseCell(New Phrase("11. The intermixing of persons at work place ( i.e the persons undergoing quarantine and the persons already completed quarantine ) should be avoided .", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                cell.BorderColor = BaseColor.BLACK
                ltable.AddCell(cell)
                ' cell = PhraseCell(New Phrase("12. I understand that Unique Application ID will be required for download of Admit Card:", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)
                ' cell.BorderColor = BaseColor.BLACK
                ' ltable.AddCell(cell)
                ' cell = PhraseCell(New Phrase("Yes            No ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                ' cell.BorderColor = BaseColor.BLACK
                ' ltable.AddCell(cell)

                doc.Add(ltable)
                phrase = New Phrase()
                phrase.Add(New Chunk("The above precautions shall be strictly followed by all personnel under our agency inside MSTPP site." & vbLf & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Signature" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                phrase.Add(New Chunk("Name,Designation" & vbLf & agency & vbLf & Session("email").ToString, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                doc.Add(phrase)
            End If
            ''''' Now add another page with Application letter for each ID.
            '''
            'ref = "Ref: BIFPCL/HR/GatePass: " & appID & "                Date: " & Now.ToString("dd.MM.yyyy")
            If Not (passtype = "Cancel") Then
                head = "Bangladesh-India Friendship Power Company (Pvt) Ltd."

                For Each dr As DataRow In dt.Rows
                    doc.SetPageSize(PageSize.A4)
                    doc.NewPage()

                    Try
                        table = New PdfPTable(2)
                        table.HorizontalAlignment = Element.ALIGN_LEFT
                        table.TotalWidth = 460.0F
                        table.SetWidths(New Single() {390.0F, 70.0F})
                        table.SpacingBefore = 20.0F
                        table.WidthPercentage = 90

                        'phrase = New Phrase()
                        'phrase.Add(New Chunk(head & vbLf & vbLf, FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLUE)))
                        '' phrase.Add(New Chunk("Power Sector Eastern Region" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                        'phrase.Add(New Chunk("(A Joint Venture Company of BPDB & NTPC Ltd.)" & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                        ''  phrase.Add(New Chunk("Registered Office: Unique Heights (Borak), 117 Kazi Nazrul Islam Avenue (Level-17), Eskaton Garden, Dhaka-1000.", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                        'cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE)
                        ''cell.Colspan = 2
                        'htable.AddCell(cell)
                        doc.Add(htable)
                        'Separater Line
                        DrawLine(writer, 25.0F, doc.Top - 79.0F, doc.PageSize.Width - 25.0F, doc.Top - 79.0F, color__1)
                        DrawLine(writer, 25.0F, doc.Top - 80.0F, doc.PageSize.Width - 25.0F, doc.Top - 80.0F, color__1)
                        Dim id = If(IsDBNull(dr("Gate Pass ID")), "", dr("Gate Pass ID"))
                        Dim photo = If(IsDBNull(dr("photo")), "", dr("photo"))

                        ' table.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase(ref, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.Colspan = 2
                        table.AddCell(cell)
                        cell = PhraseCell(New Phrase("Application Form For Gate Pass", FontFactory.GetFont("Arial", 14, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        ' cell.Colspan = 2
                        cell.HorizontalAlignment = Element.ALIGN_CENTER
                        table.AddCell(cell)
                        imagePath = String.Format("~/upload/gatepass/{0}.jpg", photo)
                        If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                            imagePath = String.Format("~/images/{0}.jpg", "user")
                        End If
                        Dim mypic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                        'image.ScalePercent(scale)
                        mypic.ScaleAbsolute(70.0F, 90.0F)

                        cell = New PdfPCell(mypic)
                        cell.Rowspan = 2
                        table.AddCell(cell)
                        cell = PhraseCell(New Phrase(agency, FontFactory.GetFont("Arial", 16, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        ' cell.Colspan = 2
                        cell.HorizontalAlignment = Element.ALIGN_LEFT
                        table.AddCell(cell)
                        'cell = PhraseCell(New Phrase(), PdfPCell.ALIGN_CENTER)
                        'cell.Colspan = 2
                        'cell.PaddingBottom = 30.0F
                        'table.AddCell(cell)
                        doc.Add(table)

                        ' Dim q = "select id as 'Gate Pass ID',name as 'Name',father as 'Father', strftime('%d.%m.%Y', dob) as dob, nationality as 'Nationality',nid as 'NID/Passport',desig as 'Desig',
                        'cell as 'Contact',strftime('%d.%m.%Y',validity_start) as 'V. Start',
                        'strftime('%d.%m.%Y',validity_end) as 'V. End', sex , age , 'Village: ' || ifnull(village,'') || ' PO:' || ifnull(po,'') || ' PS:' || ifnull(ps,'') || 'Dist:' || ifnull(district,'') 
                        'as 'Address', mainagency as 'Work Partner', subagency, compliance, area from gatepass where id in ( " & IDcommaseparated & ") "
                        'Dim email = If(IsDBNull(dt.Rows(0)("email")), "", dt.Rows(0)("email"))

                        Dim name = If(IsDBNull(dr("Name")), "", dr("Name"))
                        ' Dim I = If(IsDBNull(dr("I")), "", dr("I"))
                        Dim father = If(IsDBNull(dr("Father")), "", dr("Father"))
                        Dim sex = If(IsDBNull(dr("sex")), "", dr("sex"))
                        Dim Contact = If(IsDBNull(dr("Contact")), "", dr("Contact"))
                        Dim dob = If(IsDBNull(dr("dob")), "", dr("dob"))
                        Dim nid = If(IsDBNull(dr("NID/Passport")), "", dr("NID/Passport"))
                        Dim nationality = If(IsDBNull(dr("nationality")), "", dr("nationality"))
                        Dim Address = If(IsDBNull(dr("Address")), "", dr("Address"))
                        Dim mainagency = If(IsDBNull(dr("Work Partner")), "", dr("Work Partner"))
                        Dim subagency = If(IsDBNull(dr("subagency")), "", dr("subagency"))
                        Dim compliance = If(IsDBNull(dr("compliance")), "", dr("compliance"))
                        Dim area = If(IsDBNull(dr("area")), "", dr("area"))
                        Dim vstart = If(IsDBNull(dr("V. Start")), "", dr("V. Start"))
                        Dim vend = If(IsDBNull(dr("V. End")), "", dr("V. End"))
                        Dim bgroup = If(IsDBNull(dr("bgroup")), "", dr("bgroup"))
                        Dim cat = If(IsDBNull(dr("cat")), "", dr("cat"))
                        Dim desig = If(IsDBNull(dr("desig")), "", dr("desig"))
                        Dim visa = If(IsDBNull(dr("visa")), "", dr("visa"))
                        Dim visaexp = If(IsDBNull(dr("Visa Exp")), "", dr("Visa Exp"))
                        Dim pre_test_date = If(IsDBNull(dr("pre_test_date")), "", dr("pre_test_date"))
                        Dim post_test_date = If(IsDBNull(dr("post_test_date")), "", dr("post_test_date"))
                        Dim temp = If(IsDBNull(dr("temp")), "", dr("temp"))


                        Dim bTable As New PdfPTable(2)
                        bTable.DefaultCell.Padding = 3
                        bTable.WidthPercentage = 100
                        bTable.HorizontalAlignment = Element.ALIGN_LEFT
                        bTable.DefaultCell.BorderWidth = 2
                        bTable.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase("Gate Pass ID:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(id.ToString, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Name:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(name.ToString, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Father's Name:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(father, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Designation:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(desig, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Blood Group:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(bgroup, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Skill Type:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(cat, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Location of work inside plant:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(area, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        ' btable.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase("Gender:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(sex, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Date of Birth", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(dob, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        ' End If
                        '  btable.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase("Type of ID Proof (Tick):", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("National Identity Card       Birth Certificate      Driving License       Passport(with VISA)", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("ID No:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        ' cell.Colspan = 2
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(nid, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Nationality:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(nationality, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        bTable.AddCell(cellBlank)
                        cell = PhraseCell(New Phrase("Communication Address:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(Address, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Contact Number:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(Contact, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Contact Number of a relative & relation:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Name of the Main Agency:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(mainagency, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Name of the Sub Agency:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(subagency, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Validity:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(vstart & " - " & vend, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)

                        cell = PhraseCell(New Phrase("VISA:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(visa & " - " & visaexp, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Compliance/HSE Certificate:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(compliance, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Pre - Post Test Date:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(pre_test_date & " - " & post_test_date, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase("Temperature:", FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)
                        cell = PhraseCell(New Phrase(temp, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT)
                        cell.BorderColor = BaseColor.BLACK
                        bTable.AddCell(cell)

                        doc.Add(bTable)
                        phrase = New Phrase()
                        phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        phrase.Add(New Chunk("Applicant Signature with Date" & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        phrase.Add(New Chunk(" " & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        phrase.Add(New Chunk(name.ToString & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        ' phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        Dim sign = "Signature of Agency with Seal          Approved by BHEL             Approved by BIFPCL"
                        If mainagency = "BIFPCL" Then
                            sign = "Signature of Agency with Seal            Forwarded by               Approved by BIFPCL"
                        End If
                        phrase.Add(New Chunk(sign & vbLf, FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk(" " & vbLf & vbLf, FontFactory.GetFont("Arial", 12, Font.BOLDITALIC, BaseColor.BLACK)))
                        phrase.Add(New Chunk("Attachment: 1. Photocopy of National Identify Card (NID) / Birth certificate / Driving Licence / Passport & HSE Certificate" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))
                        phrase.Add(New Chunk("    2. Photo (1 Passport size & 1 stamp size)" & vbLf, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)))

                        phrase.Add(New Chunk("Note: System Generated Application. No cutting/overwriting is allowed.(c) www.bifpcl.com" & vbLf & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))

                        doc.Add(phrase)

                        doc.Add(cellBlank)
                    Catch ex As Exception
                        phrase.Add(New Chunk("Error occured in printing application form for ID " & ex.Message & vbLf & vbLf, FontFactory.GetFont("Arial", 10, Font.BOLDITALIC, BaseColor.BLACK)))

                        doc.Add(phrase)
                    End Try
                Next
            End If
            doc.Close()
            Dim bytes As Byte() = memoryStream.ToArray()
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "attachment;filename=Cover" & Now.ToString("ddMyyHHmmss") & ".pdf")
            Response.Buffer = True
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.BinaryWrite(bytes)
            Response.[End]()

        End Using
    End Sub
    Sub printID()
        Dim list = CType(Session("printID"), List(Of String))
        Dim IDcommaseparated = String.Join(",", list)
        divMsg.InnerHtml = IDcommaseparated
        Dim q = "select id,sn,name,father,sex,age,strftime('%d.%m.%Y',dob) as dob,nationality,nid,mainagency,agency,subagency,desig,status,mainagency,village,po,ps,district,cell,bgroup,area, strftime('%d.%m.%Y',validity_start) as validity_start,strftime('%d.%m.%Y',validity_end) as validity_end, strftime('%d.%m.%Y',approve2_dt) as approve2_dt, last_updated,lastupdateby, compliance  from gatepass where id in ( " & IDcommaseparated & ") "
        Dim dt = dbOp.getDBTable(q, "gpdb")
        If dt.Rows.Count < 1 Then
            divMsg.InnerHtml = "No Records found for requested ID load failed.." & IDcommaseparated
            Exit Sub
        End If
        'Dim dt As DataTable = New DataTable()
        'dt.Columns.Add("id")
        'dt.Columns.Add("agency")
        'dt.Columns.Add("validity_end")
        'dt.Columns.Add("name")
        'dt.Columns.Add("father")
        'dt.Columns.Add("age")
        'dt.Columns.Add("village")
        'dt.Columns.Add("po")
        'dt.Columns.Add("ps")
        'dt.Columns.Add("district")
        'dt.Columns.Add("status")
        'dt.Columns.Add("approve2_dt")
        'For i As Integer = 5220 To 5233 - 1
        '    Dim row As DataRow = dt.NewRow()
        '    row("id") = i.ToString()
        '    row("agency") = "Simplex Infrastructure Pvt Limited with BHEL BD" 'Now.ToString("d.M.yy")
        '    row("validity_end") = Now.ToString("d.M.yy")
        '    row("status") = "Valid"
        '    row("approve2_dt") = Now.ToString("dd.MM.yy")
        '    dt.Rows.Add(row)
        'Next

        Try
            Dim agency = ""

            '''#################################################
            Dim QRsize = 90.0F
            Dim tableWidth = 280.0F
            Dim col1Width = 130.0F
            Dim col2Width = QRsize
            Dim col3Width = 60.0F
            Dim logoWidth = col2Width
            Dim picWidth = col3Width
            Dim picHeight = 70.0F
            Dim hGap = 300
            Dim vGap = 200
            Dim idCardPerPage = 8
            '''''###############################################
            Dim doc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 10.0F)
            Using memoryStream As New MemoryStream()
                Dim pdfWriter__1 As PdfWriter = PdfWriter.GetInstance(doc, memoryStream)
                doc.Open()
                '  doc.NewPage()
                ''' Loop through Page 1
                ''' 
                Dim j = 0

                Dim t2Horizontal = 0
                Dim tVertical = 0
                Dim bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
                Dim bfHel = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, False)
                Dim myFontBig = New iTextSharp.text.Font(bfHel, 10, Font.NORMAL)
                Dim myFontSmall = New iTextSharp.text.Font(bfTimes, 8, Font.NORMAL)
                Dim myFontMedium = New iTextSharp.text.Font(bfTimes, 10, Font.NORMAL)

                '''' PRINT FRONT AREA
                '''#################
                For Each r In dt.Rows
                    If j Mod idCardPerPage = 0 Then
                        doc.NewPage()
                        ''reset for new page
                        t2Horizontal = 0
                        tVertical = 0
                        j = 0
                    End If


                    Dim QRText = ""
                    Dim info = ""
                    Dim id = ""
                    Dim validity_end = ""
                    Dim imagePath = ""
                    Dim bottomInfo = ""
                    Try
                        agency = r("agency").ToString
                        QRText = r("id").ToString & " Valid:" & r("validity_end") & " " & Left(r("name").ToString, 11)
                        info = r("name") & vbCrLf & vbCrLf & "F:" & r("father") & vbCrLf & "Age:" & r("age") & vbCrLf & r("village") & " PO:" & r("po") & vbCrLf & "PS:" & r("ps") & ", " & r("district") &
                               vbCrLf & "Blood Grp: "
                        id = r("id").ToString
                        imagePath = String.Format("~/upload/gatepass/{0}.jpg", id)
                        'bottomInfo = "Printed On:" & Now.ToString("dd.MM.yy HH:mm") & " Status:" & r("status").ToString & " since: " & r("approve2_dt")
                        bottomInfo = "Permitted to work at " & r("compliance").ToString
                        ''' check if imagepath exist or not
                        ''' 
                        If Not System.IO.File.Exists(Server.MapPath(imagePath)) Then
                            imagePath = String.Format("~/images/{0}.jpg", "user")
                        End If
                        validity_end = r("validity_end").ToString
                    Catch ex As Exception
                        info = ex.Message
                        agency = "Error"
                    End Try


                    Dim table As New PdfPTable(3)
                    table.TotalWidth = tableWidth
                    table.LockedWidth = True
                    table.SetWidths({col1Width, col2Width, col3Width})

                    table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                    table.DefaultCell.BorderWidth = 0
                    Dim cell As New PdfPCell(New Phrase("Bangladesh India Friendship Power Company (P) Ltd" & vbCrLf & "2X660 MW Maitree Super Thermal Power Project" & vbCrLf & vbCrLf & "QR Gate Pass", myFontBig))
                    cell.FixedHeight = 50.0F
                    cell.Colspan = 3
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cell.HorizontalAlignment = 1
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase(agency, myFontSmall))
                    cell.FixedHeight = 15.0F
                    table.AddCell(cell)
                    cell = New PdfPCell(New Phrase("ID:" & id, myFontMedium))
                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)
                    cell = New PdfPCell(New Phrase("Valid:" & validity_end, myFontSmall))

                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase(info, myFontMedium))
                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)

                    ''QR
                    Dim qrGenerator As New QRCodeGenerator()
                    Dim myQRData As QRCodeData = qrGenerator.CreateQrCode(QRText, QRCodeGenerator.ECCLevel.Q)
                    Dim myQRCode = New QRCode(myQRData)
                    Using bitMap As Bitmap = myQRCode.GetGraphic(20)
                        Using bitMapResized = New Bitmap(bitMap, New Size(QRsize, QRsize))
                            Dim myImage = CType(bitMapResized, Image)
                            Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(myImage, System.Drawing.Imaging.ImageFormat.Jpeg)
                            image.SetDpi(200, 200)
                            'image.Width = 70.0F
                            'image.Height = 70.0F

                            cell = New PdfPCell(image)
                            table.AddCell(cell)
                        End Using
                    End Using

                    ''logo
                    'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                    Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    pic.ScaleAbsolute(picWidth, picHeight)

                    cell = New PdfPCell(pic)
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase(bottomInfo, myFontMedium))
                    cell.BackgroundColor = BaseColor.PINK
                    cell.Colspan = 3
                    cell.FixedHeight = 15.0F
                    table.AddCell(cell)
                    If j Mod 2 = 0 Then
                        t2Horizontal = hGap
                    Else
                        t2Horizontal = 0
                    End If
                    If j Mod 2 = 0 And j > 1 Then tVertical = tVertical + vGap
                    Dim maintable As New PdfPTable(1)
                    maintable.TotalWidth = tableWidth
                    maintable.LockedWidth = True
                    maintable.AddCell(table)
                    maintable.WriteSelectedRows(0, -1, doc.Left + t2Horizontal, doc.Top - tVertical, pdfWriter__1.DirectContent)
                    j = j + 1


                Next

                j = 0
                For Each r In dt.Rows
                    If j Mod idCardPerPage = 0 Then
                        doc.NewPage()
                        ''reset for new page
                        t2Horizontal = 0
                        tVertical = 0
                        j = 0
                    End If

                    Dim QRText = ""
                    Dim info = "MSTPP Office PO: Kalekharber" & vbCrLf & "Union: Rajnagar,Thana: Rampal," & vbCrLf & "Dist: Bagerhat" & vbCrLf & vbCrLf & "Holder Sign:" & vbCrLf & " " & vbCrLf & "Company Sign:"

                    Dim id = ""
                    Dim validity_end = ""
                    Dim imagePath = String.Format("~/images/{0}.png", "logo_thumb")
                    Dim imageSign = String.Format("~/images/{0}.png", "gpsign")

                    Dim table As New PdfPTable(3)
                    table.TotalWidth = tableWidth
                    table.LockedWidth = True
                    table.SetWidths({col1Width, col2Width, col3Width})

                    table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                    table.DefaultCell.BorderWidth = 0
                    Dim cell As New PdfPCell(New Phrase("Bangladesh India Friendship Power Company (P) Ltd" & vbCrLf & "2X660 MW Maitree Super Thermal Power Project" & vbCrLf & vbCrLf & "Security Room: 01755628291, Ambulance: 01798751272", myFontBig))
                    cell.FixedHeight = 50.0F
                    cell.Colspan = 3
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER
                    cell.HorizontalAlignment = 1
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase("Address:", myFontSmall))
                    cell.FixedHeight = 15.0F
                    table.AddCell(cell)
                    cell = New PdfPCell(New Phrase("www.bifpcl.com", myFontMedium))
                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)
                    cell = New PdfPCell(New Phrase("", myFontSmall))

                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase(info, myFontMedium))
                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)


                    ''logo
                    'cell = ImageCell(String.Format("~/images/{0}.jpg", "logo"), QRsize, PdfPCell.ALIGN_CENTER)
                    Dim pic As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imagePath))
                    'image.ScalePercent(scale)
                    pic.ScaleAbsolute(logoWidth, QRsize)
                    cell = New PdfPCell(pic)
                    table.AddCell(cell)

                    cell = New PdfPCell(New Phrase("Valid Upto:" & vbCrLf & vbCrLf & "Valid Upto:" & vbCrLf & vbCrLf & "Valid Upto:", myFontMedium))
                    ' cell.FixedHeight = 10.0F
                    table.AddCell(cell)

                    Dim picSign As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(imageSign))
                    'image.ScalePercent(scale)
                    picSign.ScaleAbsolute(picWidth, 15.0F)
                    cell = New PdfPCell(picSign)
                    table.AddCell(cell)

                    Dim bottomInfo = "The card is Non Transferrable."
                    cell = New PdfPCell(New Phrase(bottomInfo, myFontSmall))
                    cell.Colspan = 2
                    cell.FixedHeight = 15.0F
                    table.AddCell(cell)
                    If j Mod 2 = 0 Then
                        t2Horizontal = hGap
                    Else
                        t2Horizontal = 0
                    End If
                    If j Mod 2 = 0 And j > 1 Then tVertical = tVertical + vGap
                    Dim maintable As New PdfPTable(1)
                    maintable.TotalWidth = tableWidth
                    maintable.LockedWidth = True
                    maintable.AddCell(table)
                    maintable.WriteSelectedRows(0, -1, doc.Left + t2Horizontal, doc.Top - tVertical, pdfWriter__1.DirectContent)
                    j = j + 1


                Next


                doc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-disposition", "attachment;filename=ID" & Left(agency, 6) & ".pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()

            End Using
        Catch ex As Exception
            divMsg.InnerHtml = ex.Message & IDcommaseparated
        End Try
    End Sub

    Private Shared Sub DrawLine(writer As PdfWriter, x1 As Single, y1 As Single, x2 As Single, y2 As Single, color As BaseColor)
        Dim contentByte As PdfContentByte = writer.DirectContent
        contentByte.SetColorStroke(color)
        contentByte.MoveTo(x1, y1)
        contentByte.LineTo(x2, y2)
        contentByte.Stroke()
    End Sub
    Private Shared Function PhraseCell(phrase As Phrase, align As Integer, Optional border As Boolean = False) As PdfPCell
        Dim cell As New PdfPCell(phrase)
        If border Then
            cell.BorderColor = BaseColor.BLACK  ' Color.AliceBlue  ' Color.White
        Else
            cell.BorderColor = BaseColor.WHITE
        End If
        cell.VerticalAlignment = PdfPCell.ALIGN_TOP
        cell.HorizontalAlignment = align
        cell.PaddingBottom = 2.0F
        cell.PaddingTop = 0.0F
        Return cell
    End Function
End Class


