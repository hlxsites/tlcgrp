﻿
Partial Public Class requestacall
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)
        '' txtFName.Focus()
        Dim name As String = Request.QueryString("name")
        Dim mobile As String = Request.QueryString("mobile")
        Dim Email As String = Request.QueryString("Email")
        If Not IsPostBack Then

            txtLName.Text = name
            txtMobile.Text = mobile

        End If
        
        'txtEmail.Focus()
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
       
        If Page.IsValid Then
            Dim name As String = txtFName.Text

            'If txtMobile.Text.Trim.Length < 10 Then
            '    lblError.Text = "Please enter a valid Mobile Number."
            '    lblError.ForeColor = Drawing.Color.Red
            '    Return
            'End If

            'If chkAccept.Checked = False Then
            '    lblError.Text = "Please accept Terms & Conditions."
            '    lblError.ForeColor = Drawing.Color.Red
            '    Page.ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "alert('Please accept Terms & Conditions.');", True)
            '    Return
            'End If
            If chkLeadership.Checked = True Then
                SendSpecificEmail(txtFName.Text.Trim.Trim(), txtLName.Text.Trim(), txtEmailID1.Text.Trim())
                btnSubmit.Enabled = False
                Response.Redirect("ThankuRegDaySession.aspx?FName=" & Convert.ToString(Me.txtFName.Text) & "&LName=" & Convert.ToString(Me.txtLName.Text))

            Else
                ''If chkEveningEvent.Checked = True  Then
                If txtEventName.Text <> "" And txtEventMobile.Text <> "" And txtEventEmail.Text <> "" And txtEventReEmail.Text <> "" Then

                    ''changes by brijesh 07102017
                    '' If chkEveningEvent2.Checked = True Then
                    If txtEventName2.Text <> "" And txtEventMobile2.Text <> "" And txtEventEmail2.Text <> "" And txtEventReEmail2.Text <> "" Then
                        SendToBothEmail(txtFName.Text.Trim.Trim(), txtLName.Text.Trim(), txtEmailID1.Text.Trim())

                        Response.Redirect("Thankuguest2Reg.aspx?FName=" & Convert.ToString(Me.txtFName.Text) & "&LName=" & Convert.ToString(Me.txtLName.Text))


                    Else

                        'SendToBothEmail(txtFName.Text.Trim.Trim(), txtLName.Text.Trim(), txtEmailID1.Text.Trim())
                        'Response.Redirect("ThankYouEvenEvent.aspx?FName=" & Convert.ToString(Me.txtFName.Text) & "&LName=" & Convert.ToString(Me.txtLName.Text))
                        SendToBothEmail(txtFName.Text.Trim.Trim(), txtLName.Text.Trim(), txtEmailID1.Text.Trim())

                        Response.Redirect("ThankuReg.aspx?FName=" & Convert.ToString(Me.txtFName.Text) & "&LName=" & Convert.ToString(Me.txtLName.Text))
                    End If
                    ''end

                Else

                    SendToBothEmail(txtFName.Text.Trim.Trim(), txtLName.Text.Trim(), txtEmailID1.Text.Trim())

                    Response.Redirect("ThankYouEvenEvent.aspx?FName=" & Convert.ToString(Me.txtFName.Text) & "&LName=" & Convert.ToString(Me.txtLName.Text))
                End If

            End If

        End If
        btnSubmit.Enabled = False
    End Sub

    Shared Function OnlyLetters(letter As String) As Boolean
        Dim expression As String = "^[a-zA-Z .'’]*$"

        Dim match As Match = Regex.Match(letter, expression, RegexOptions.IgnoreCase)
        If match.Success Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub SendToBothEmail(ByVal sClientName As String, ByVal LName As String, ByVal sClientEmail As String)
        Try
            '-----------------User Email-------------------------------------------
            Dim Message As New Net.Mail.MailMessage()
            Dim mailID As String = sClientEmail
            Dim FromEmail As New Net.Mail.MailAddress("ghc@tlcgroup.com", "Global Hospitality Conclave")
            Message.From = FromEmail
            Message.To.Add(New Net.Mail.MailAddress(mailID))
            Message.IsBodyHtml = True
            Message.Subject = "Thank You"

            Dim str As String = String.Empty
            'If chkEveningEvent.Checked = True Then
            If txtEventName.Text <> "" And txtEventMobile.Text <> "" And txtEventEmail.Text <> "" And txtEventReEmail.Text <> "" Then

                str = "<!DOCTYPE>"
                str &= "<html>"
                str &= "<head>"
                str &= "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>"
                str &= "<meta content='MSHTML 6.00.2800.1106' name='GENERATOR'>"
                str &= "<style>body{font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;'}</style></head> "
                str &= "<body> "
                str &= "<div align='center'>	"
                str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                str &= "<tr>	"
                str &= "<td align='center'> "
                str &= "<img src='http://tlc.in/tlc/ghctlc/images/logo.jpg' border='0' alt=''>"
                str &= "</td>	  "
                str &= "</tr>	"
                str &= "<tr>	"
                str &= "<td align='center' style='padding: 10px 0px 0px 0px;'>  "
                'str &= "<img src=" + strLogoPath + " alt='' style='float: left'>	"
                str &= "</td> "
                str &= "</tr>"
                str &= "<tr> "
                str &= "<td colspan='' align='center'> "
                str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                str &= "<tr>	"
                str &= "<td colspan='3'>	"
                str &= "<center>	"
                str &= "<table cellspacing='0' cellpadding='8' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                str &= "<tr> "
                str &= "<td align='left'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'><b>Dear " & StrConv(sClientName.Trim, VbStrConv.ProperCase) & " " & StrConv(LName.Trim, VbStrConv.ProperCase) & ",</b>"

                str &= "</font></td>	"
                str &= "</tr>	"


                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Thank you for completing the registration form for Global Hospitality Conclave 2019."


                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"

                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Your registration fee is Rs. 9500, which needs to be paid directly to The Leela Ambience Gurugram Hotel & Residences. You may make this payment through the online link, cheque or via an RTGS transfer."
                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>The hotel will send you the <b>online payment link</b> within 2 days of this email. We request you to make the payment through the link within 3 days of receiving it to complete your registration."
                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><b>Cheque</b> should be made favouring Ambience Hotel & Resorts Private Limited and sent to Mr. Pranav Joshi, Head - Catering & MICE Sales, The Leela Ambience Gurugram Hotel & Residences, Ambience Island, National Highway – 8, Gurgaon 122002 with your name, mobile number and GHC 2019 written at the back of the cheque."
                str &= "</font> "
                str &= "</td> "
                str &= "</tr>"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'><b>RTGS</b> transfer may be done on the details below: "
                str &= "</font> "
                str &= "</td>"
                str &= "</tr>	"
                str &= "</table>"
                str &= "<br>"
                str &= "<table cellspacing='8' cellpadding='0' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Account Holder</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>Ambience Hotel & Resorts Private Limited"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Name of the Bank</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>Yes Bank"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Bank Account Number</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>001666200000614"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>IFSC Code of The Branch</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>YESB0000016"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>SWIFT Code</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>YESBINBB"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>MICR Code of Branch</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>110532006"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "</table>"
                str &= "</center></td> "
                str &= "</tr>"
                str &= "<br/>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Please do send an e-mail to Mr. Joshi with your details and the RTGS confirmation as a follow up to the RTGS transfer."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br />For any details with respect to the registration fee, you may connect with Mr. Joshi at +91 9717596110 or pranav.joshi@theleela.com. You may also contact any member of the Organizing Committee of GHC 2019 for support."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br />We thank you for your interest and look forward to welcoming you to GHC 2019."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"

                str &= "<tr>"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br /><b>Organizing Committee<br />GHC 2019</b>"
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "</table>"
                str &= "</td>	"
                str &= "</tr>	"
                str &= "</table> "
                str &= "</td>	"
                str &= "</tr>	"

                str &= "</table> "
                str &= "</div> "
                str &= "</body> "
                str &= "</html>  "
            Else

                str = "<!DOCTYPE>"
                str &= "<html>"
                str &= "<head>"
                str &= "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>"
                str &= "<meta content='MSHTML 6.00.2800.1106' name='GENERATOR'>"
                str &= "<style>body{font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;'}</style></head> "
                str &= "<body> "
                str &= "<div align='center'>	"
                str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                str &= "<tr>	"
                str &= "<td align='center'> "
                str &= "<img src='http://tlc.in/tlc/ghctlc/images/logo.jpg' border='0' alt=''>"
                str &= "</td>	  "
                str &= "</tr>	"
                str &= "<tr>	"
                str &= "<td align='center' style='padding: 10px 0px 0px 0px;'>  "
                'str &= "<img src=" + strLogoPath + " alt='' style='float: left'>	"
                str &= "</td>													 "
                str &= "</tr>"
                str &= "<tr> "
                str &= "<td colspan='' align='center'> "
                str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                str &= "<tr>	"
                str &= "<td colspan='3'>	"
                str &= "<center>	"
                str &= "<table cellspacing='0' cellpadding='8' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                str &= "<tr> "
                str &= "<td align='left'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'><b>Dear " & StrConv(sClientName.Trim, VbStrConv.ProperCase) & " " & StrConv(LName.Trim, VbStrConv.ProperCase) & ",</b>"

                str &= "</font></td>	"
                str &= "</tr>	"

                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Thank you for completing the registration form for Global Hospitality Conclave 2019."


                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"

                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Your registration fee is Rs. 6500, which needs to be paid directly to The Leela Ambience Gurugram Hotel & Residences. You may make this payment through the online link, cheque or via an RTGS transfer."
                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>The hotel will send you the <b>online payment link</b> within 2 days of this email. We request you to make the payment through the link within 3 days of receiving it to complete your registration."
                str &= "</font>"
                str &= "</td>	"
                str &= "</tr>	"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><b>Cheque</b> should be made favouring Ambience Hotel & Resorts Private Limited and sent to Mr. Pranav Joshi, Head - Catering & MICE Sales, The Leela Ambience Gurugram Hotel & Residences, Ambience Island, National Highway – 8, Gurgaon 122002 with your name, mobile number and GHC 2019 written at the back of the cheque."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'><b>RTGS</b> transfer may be done on the details below: "
                str &= "</font> "
                str &= "</td>"
                str &= "</tr>	"
                str &= "</table>"
                str &= "<br>"
                str &= "<table cellspacing='8' cellpadding='0' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Account Holder</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>Ambience Hotel & Resorts Private Limited"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Name of the Bank</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>Yes Bank"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>"
                str &= "<tr>"
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>Bank Account Number</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>001666200000614"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>IFSC Code of The Branch</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>YESB0000016"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>SWIFT Code</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>YESBINBB"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "<tr> "
                str &= "<td style='text-align: justify'>	"
                str &= "<font face='Arial, Helvetica, sans-serif'>MICR Code of Branch</font>"
                str &= "</td>"
                str &= "<td style='text-align: justify'>"
                str &= "<font face='Arial, Helvetica, sans-serif'>110532006"
                str &= "</font>"
                str &= "</td>"
                str &= "</tr>	"
                str &= "</table>"
                str &= "</center></td> "
                str &= "</tr>"
                str &= "<br/>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'>Please do send an e-mail to Mr. Joshi with your details and the RTGS confirmation as a follow up to the RTGS transfer."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br />For any details with respect to the registration fee, you may connect with Mr. Joshi at +91 9717596110 or pranav.joshi@theleela.com. You may also contact any member of the Organizing Committee of GHC 2019 for support."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br />We thank you for your interest and look forward to welcoming you to GHC 2019."
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "<tr>	"
                str &= "<td style='text-align: justify'> "
                str &= "<font face='Arial, Helvetica, sans-serif'><br /><b>Organizing Committee<br />GHC 2019</b>"
                str &= "</font> "
                str &= "</td>	 "
                str &= "</tr>"
                str &= "</table>"
                str &= "</td>	"
                str &= "</tr>	"

                str &= "</table> "
                str &= "</td>	"
                str &= "</tr>	"
                str &= "</table> "
                str &= "</div> "
                str &= "</body> "
                str &= "</html>  "
            End If

            ''changes by brijesh 07102017
            If chkEveningEvent.Checked = True Then

                'If chkEveningEvent2.Checked = True Then
                If txtEventName2.Text <> "" And txtEventMobile2.Text <> "" And txtEventEmail2.Text <> "" And txtEventReEmail2.Text <> "" Then
                    str = "<!DOCTYPE>"
                    str &= "<html>"
                    str &= "<head>"
                    str &= "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>"
                    str &= "<meta content='MSHTML 6.00.2800.1106' name='GENERATOR'>"
                    str &= "<style>body{font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;'}</style></head> "
                    str &= "<body> "
                    str &= "<div align='center'>	"
                    str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                    str &= "<tr>	"
                    str &= "<td align='center'> "
                    str &= "<img src='http://tlc.in/tlc/ghctlc/images/logo.jpg' border='0' alt=''>"
                    str &= "</td>	  "
                    str &= "</tr>	"
                    str &= "<tr>	"
                    str &= "<td align='center' style='padding: 10px 0px 0px 0px;'>  "
                    'str &= "<img src=" + strLogoPath + " alt='' style='float: left'>	"
                    str &= "</td>													 "
                    str &= "</tr>"
                    str &= "<tr> "
                    str &= "<td colspan='' align='center'> "
                    str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                    str &= "<tr>	"
                    str &= "<td colspan='3'>	"
                    str &= "<center>	"
                    str &= "<table cellspacing='0' cellpadding='8' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                    str &= "<tr> "
                    str &= "<td align='left'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>Dear " & StrConv(sClientName.Trim, VbStrConv.ProperCase) & " " & StrConv(LName.Trim, VbStrConv.ProperCase) & ",</b>"

                    str &= "</font></td>	"
                    str &= "</tr>	"

                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Thank you for completing the registration form for Global Hospitality Conclave 2019."


                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"

                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Your registration fee is Rs. 13500, which needs to be paid directly to The Leela Ambience Gurugram Hotel & Residences. You may make this payment through the online link, cheque or via an RTGS transfer."
                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>The hotel will send you the <b>online payment link</b> within 2 days of this email. We request you to make the payment through the link within 3 days of receiving it to complete your registration."
                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>Cheque</b> should be made favouring Ambience Hotel & Resorts Private Limited and sent to Mr. Pranav Joshi, Head - Catering & MICE Sales, The Leela Ambience Gurugram Hotel & Residences, Ambience Island, National Highway – 8, Gurgaon 122002 with your name, mobile number and GHC 2019 written at the back of the cheque."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>RTGS</b> transfer may be done on the details below: "
                    str &= "</font> "
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "</table>"
                    str &= "<br>"
                    str &= "<table cellspacing='8' cellpadding='0' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Account Holder</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Ambience Hotel & Resorts Private Limited"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Name of the Bank</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Yes Bank"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Bank Account Number</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>001666200000614"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>IFSC Code of The Branch</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>YESB0000016"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>SWIFT Code</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>YESBINBB"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>MICR Code of Branch</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>110532006"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "</table>"
                    str &= "</center></td> "
                    str &= "</tr>"
                    str &= "<br/>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Please do send an e-mail to Mr. Joshi with your details and the RTGS confirmation as a follow up to the RTGS transfer."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br />For any details with respect to the registration fee, you may connect with Mr. Joshi at +91 9717596110 or pranav.joshi@theleela.com. You may also contact any member of the Organizing Committee of GHC 2019 for support."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br />We thank you for your interest and look forward to welcoming you to GHC 2019."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"

                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br /><b>Organizing Committee<br />GHC 2019</b>"
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "</table>"
                    str &= "</td>	"
                    str &= "</tr>	"

                    str &= "</table> "
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "</table> "
                    str &= "</div> "
                    str &= "</body> "
                    str &= "</html>  "
                Else

                    str = "<!DOCTYPE>"
                    str &= "<html>"
                    str &= "<head>"
                    str &= "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'>"
                    str &= "<meta content='MSHTML 6.00.2800.1106' name='GENERATOR'>"
                    str &= "<style>body{font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;'}</style></head> "
                    str &= "<body> "
                    str &= "<div align='center'>	"
                    str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                    str &= "<tr>	"
                    str &= "<td align='center'> "
                    str &= "<img src='http://tlc.in/tlc/ghctlc/images/logo.jpg' border='0' alt=''>"
                    str &= "</td>	  "
                    str &= "</tr>	"
                    str &= "<tr>	"
                    str &= "<td align='center' style='padding: 10px 0px 0px 0px;'>  "
                    'str &= "<img src=" + strLogoPath + " alt='' style='float: left'>	"
                    str &= "</td>													 "
                    str &= "</tr>"
                    str &= "<tr> "
                    str &= "<td colspan='' align='center'> "
                    str &= "<table cellspacing='0' cellpadding='0' width='650' border='0' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''> "
                    str &= "<tr>	"
                    str &= "<td colspan='3'>	"
                    str &= "<center>	"
                    str &= "<table cellspacing='0' cellpadding='8' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                    str &= "<tr> "
                    str &= "<td align='left'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>Dear " & StrConv(sClientName.Trim, VbStrConv.ProperCase) & " " & StrConv(LName.Trim, VbStrConv.ProperCase) & ",</b>"

                    str &= "</font></td>	"
                    str &= "</tr>	"

                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Thank you for completing the registration form for Global Hospitality Conclave 2019."


                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"

                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Your registration fee is Rs. 10000, which needs to be paid directly to The Leela Ambience Gurugram Hotel & Residences. You may make this payment through the online link, cheque or via an RTGS transfer."
                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>The hotel will send you the <b>online payment link</b> within 2 days of this email. We request you to make the payment through the link within 3 days of receiving it to complete your registration."
                    str &= "</font>"
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>Cheque</b> should be made favouring Ambience Hotel & Resorts Private Limited and sent to Mr. Pranav Joshi, Head - Catering & MICE Sales, The Leela Ambience Gurugram Hotel & Residences, Ambience Island, National Highway – 8, Gurgaon 122002 with your name, mobile number and GHC 2019 written at the back of the cheque."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'><b>RTGS</b> transfer may be done on the details below: "
                    str &= "</font> "
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "</table>"
                    str &= "<br>"
                    str &= "<table cellspacing='8' cellpadding='0' border='0' width='650' style='font-family:Arial, Helvetica, sans-serif;  style='font-family:Arial, Helvetica, sans-serif; font-size:14px !important;''>"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Account Holder</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Ambience Hotel & Resorts Private Limited"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Name of the Bank</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Yes Bank"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>Bank Account Number</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>001666200000614"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>IFSC Code of The Branch</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>YESB0000016"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>SWIFT Code</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>YESBINBB"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "<tr> "
                    str &= "<td style='text-align: justify'>	"
                    str &= "<font face='Arial, Helvetica, sans-serif'>MICR Code of Branch</font>"
                    str &= "</td>"
                    str &= "<td style='text-align: justify'>"
                    str &= "<font face='Arial, Helvetica, sans-serif'>110532006"
                    str &= "</font>"
                    str &= "</td>"
                    str &= "</tr>	"
                    str &= "</table>"
                    str &= "</center></td> "
                    str &= "</tr>"
                    str &= "<br/>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'>Please do send an e-mail to Mr. Joshi with your details and the RTGS confirmation as a follow up to the RTGS transfer."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br />For any details with respect to the registration fee, you may connect with Mr. Joshi at +91 9717596110 or pranav.joshi@theleela.com. You may also contact any member of the Organizing Committee of GHC 2019 for support."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br />We thank you for your interest and look forward to welcoming you to GHC 2019."
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "<tr>	"
                    str &= "<td style='text-align: justify'> "
                    str &= "<font face='Arial, Helvetica, sans-serif'><br /><b>Organizing Committee<br />GHC 2019</b>"
                    str &= "</font> "
                    str &= "</td>	 "
                    str &= "</tr>"
                    str &= "</table>"
                    str &= "</td>	"
                    str &= "</tr>	"

                    str &= "</table> "
                    str &= "</td>	"
                    str &= "</tr>	"
                    str &= "</table> "
                    str &= "</div> "
                    str &= "</body> "
                    str &= "</html>  "
                End If
            End If
            ''end


            Message.Body = str

            '----------------------------------------------------------------------            

            '-----------------TLC Email-------------------------------------------

            Dim TLCMessage As New Net.Mail.MailMessage()
            Dim TLCmailID As String = "ghc@tlcgroup.com" ' tlc Email id 
            'Dim TLCmailID As String = "brijesh.gupta@tlcgroup.com" ' tlc Email id 
            Dim TLCFromEmail As New Net.Mail.MailAddress("ghc@tlcgroup.com", "Global Hospitality Conclave 2019.")

            TLCMessage.From = TLCFromEmail
            TLCMessage.To.Add(New Net.Mail.MailAddress(TLCmailID))

            TLCMessage.CC.Add(New Net.Mail.MailAddress("drops@tlcgroup.com"))

            TLCMessage.CC.Add(New Net.Mail.MailAddress("kamini.sharma@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("sunita.handoo@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("saurabh.dey@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("manisha.malhotra@hotelmemberships.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("vijay.bisht@tlcgroup.com"))
            
			'TLCMessage.CC.Add(New Net.Mail.MailAddress("sudhir@tlcgroup.com"))

            'TLCMessage.CC.Add(New Net.Mail.MailAddress("shailendra@tlcgroup.com"))

            'TLCMessage.CC.Add(New Net.Mail.MailAddress("sonal.sharma@tlcgroup.com"))

            TLCMessage.IsBodyHtml = True
            TLCMessage.Subject = "Global Hospitality Conclave 2019 - Registration"
            Dim TLCstr As String = String.Empty

            TLCstr = "  <head>"
            TLCstr &= "<title>Thank You</title>"
            TLCstr &= "<style type=text/css'>"
            TLCstr &= ".auto-style1 {"
            TLCstr &= "width: 246px;"
            TLCstr &= "}"
            TLCstr &= "</style>"
            TLCstr &= "</head>"
            TLCstr &= "<body>"
            TLCstr &= "<table border='1' width='500px'>"
            TLCstr &= "<tr style='text-align:center; line-height:26px;'><td colspan='2'><strong>Following Profile is interested for Registration.</strong></td> </tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Name"
            TLCstr &= "</td>"
            TLCstr &= " <td class='auto-style1'>" & txtFName.Text.Trim() & " " & txtLName.Text.Trim()
            TLCstr &= "</td>"
            TLCstr &= "</tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Email</td>"
            TLCstr &= "<td class='auto-style1'>" & txtEmailID1.Text & "</td>"
            TLCstr &= "</tr>"
            'TLCstr &= "<tr>"
            'TLCstr &= "<td>Telephone Number</td>"
            'TLCstr &= " <td class='auto-style1'>" & txtStdCode.Text & "-" & txtDayTimeTelePhone.Text & "</td>"
            'TLCstr &= "</tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Mobile</td>"
            TLCstr &= "<td class='auto-style1'>" & txtMobile.Text & "</td>"
            TLCstr &= "</tr>"

            TLCstr &= "<tr>"
            TLCstr &= "<td>Batch</td>"
            TLCstr &= "<td class='auto-style1'>" & txtBatch.Text & "</td>"
            TLCstr &= "</tr>"
            If (chkMangTrainee.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Management Trainee</td>"
                TLCstr &= "</tr>"
            End If
            If (chkHouseKeep.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>House Keeping Trainee</td>"
                TLCstr &= "</tr>"
            End If
            If (chkKitchen.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Kitchen</td>"
                TLCstr &= "</tr>"
            End If
            If (chkKitStewarding.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Kitchen and Stewarding</td>"
                TLCstr &= "</tr>"
            End If
            If (chkLeadership.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Leadership Role at The Oberoi Group for 5 years or more</td>"
                TLCstr &= "</tr>"
            End If
            TLCstr &= "<tr>"
            TLCstr &= "<td>Remarks</td>"
            TLCstr &= "<td class='auto-style1'>" & txtRemarks.Text & "</td>"
            TLCstr &= "</tr>"
            If (chkEveningEvent.Checked = True) Then

                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>Registration for evening event</td>"
                TLCstr &= "</tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Name</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventName.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Mobile</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventMobile.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Email</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventEmail.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>ReEmail</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventReEmail.Text.Trim() + "</td></tr>"
                'TLCstr &= "<table border='1' width='500px'><tr><td>Name<td><td class='auto-style1'>" + txtEventName.Text.Trim() + "<td></tr>"
                'TLCstr &= "<tr><td>Mobile<td><td class='auto-style1'>" + txtEventMobile.Text.Trim() + "</td></tr>"
                'TLCstr &= "<tr><td>Email<td><td class='auto-style1'>" + txtEventEmail.Text.Trim() + "</td></tr>"
                'TLCstr &= "<tr><td>Re-Email<td><td class='auto-style1'>" + txtEventReEmail.Text.Trim() + "</td></tr>"
                'TLCstr &= "</table></td>"
                'TLCstr &= "</tr>"

            End If
            ''changes by brijesh 07102017
            If (chkEveningEvent.Checked = True) Then

                If (chkEveningEvent2.Checked = True) Then

                    TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                    TLCstr &= "<td>&nbsp;</td>"
                    TLCstr &= "<td style='text-align:left' class='auto-style1'>Registration for evening event</td>"
                    TLCstr &= "</tr>"
                    TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                    TLCstr &= "<td>Name</td>"
                    TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventName2.Text.Trim() + "</td></tr>"
                    TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                    TLCstr &= "<td>Mobile</td>"
                    TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventMobile2.Text.Trim() + "</td></tr>"
                    TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                    TLCstr &= "<td>Email</td>"
                    TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventEmail2.Text.Trim() + "</td></tr>"
                    TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                    TLCstr &= "<td>ReEmail</td>"
                    TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventReEmail2.Text.Trim() + "</td></tr>"
                    'TLCstr &= "<table border='1' width='500px'><tr><td>Name<td><td class='auto-style1'>" + txtEventName.Text.Trim() + "<td></tr>"
                    'TLCstr &= "<tr><td>Mobile<td><td class='auto-style1'>" + txtEventMobile.Text.Trim() + "</td></tr>"
                    'TLCstr &= "<tr><td>Email<td><td class='auto-style1'>" + txtEventEmail.Text.Trim() + "</td></tr>"
                    'TLCstr &= "<tr><td>Re-Email<td><td class='auto-style1'>" + txtEventReEmail.Text.Trim() + "</td></tr>"
                    'TLCstr &= "</table></td>"
                    'TLCstr &= "</tr>"

                End If
            End If
            ''end
            'If (chkDaySession.Checked) Then
            '    TLCstr &= "<tr>"
            '    TLCstr &= "<td>&nbsp;</td>"
            '    TLCstr &= "<td class='auto-style1'>Day Session at The Leela Ambience Gurugram Hotel  & Residences on 6th January, 2019</td>"
            '    TLCstr &= "</tr>"
            'End If
            'If (chkCocktailLeela.Checked) Then
            '    TLCstr &= "<tr>"
            '    TLCstr &= "<td>&nbsp;</td>"
            '    TLCstr &= "<td class='auto-style1'>Cocktails & Dinner at The Leela Ambience Gurugram Hotel  & Residences on 6th January, 2019</td>"
            '    TLCstr &= "</tr>"
            'End If
            TLCstr &= "<tr>"
            TLCstr &= "<td>Internet details</td>"
            TLCstr &= "<td class='auto-style1'>" & Request.ServerVariables("REMOTE_ADDR") & " - " & DateTime.Now.Date.ToString("dd MMM yyyy") & " & " & DateTime.Now.TimeOfDay.Hours.ToString() & ":" & DateTime.Now.TimeOfDay.Minutes.ToString() & "</td>"
            TLCstr &= "</tr>"
            TLCstr &= "<tr>"



            TLCstr &= "<td>&nbsp; &nbsp;</td>"
            TLCstr &= "<td class='auto-style1'>&nbsp; &nbsp;</td>"
            TLCstr &= " </tr>"
            TLCstr &= "</table>"
            TLCstr &= "<br />"
            TLCstr &= "Global Hospitality Conclave 2019<br /><br />"
            TLCstr &= "Note: This e-mail is automatically generated by our system on above profile contact request. "
            TLCstr &= "</body>"
            TLCstr &= "</html>"
            TLCMessage.Body = TLCstr

            Dim SmtpTLCClient As New Net.Mail.SmtpClient()
            SmtpTLCClient.EnableSsl = False
            SmtpTLCClient.UseDefaultCredentials = False
            SmtpTLCClient.Credentials = New Net.NetworkCredential("mail@tlc.in", "tlcgroup")
            SmtpTLCClient.Host = "smtpauth.tlc.in"
            SmtpTLCClient.Port = 587
            SmtpTLCClient.Send(Message)
            SmtpTLCClient.Send(TLCMessage)
            SmtpTLCClient = Nothing

        Catch ex As Exception
            Response.Write("Check SMTP server. Please Contact with Admin")
        End Try
    End Sub

    Sub SendSpecificEmail(ByVal FName As String, ByVal LName As String, ByVal sClientEmail As String)
        Try
            '-----------------User Email-------------------------------------------
            Dim Message As New Net.Mail.MailMessage()
            Dim mailID As String = sClientEmail
            Dim FromEmail As New Net.Mail.MailAddress("ghc@tlcgroup.com", "Global Hospitality Conclave 2019")
            Message.From = FromEmail
            Message.To.Add(New Net.Mail.MailAddress(mailID))
            Message.IsBodyHtml = True
            Message.Subject = "Thank You"

            Dim str As String = String.Empty
            str = "<html>"
            str &= "<head>"
            str &= "</head>"
            str &= "<body>"

            str &= "<div align='center'>"
            str &= "<center>"
            str &= "<table cellspacing='8' cellpadding='0' border='0' width='650'>"
            str &= "<tr>"
            str &= "<td style='text-align: justify' align='center'> "
            str &= "<center><img src='http://tlc.in/tlc/ghctlc/images/logo.jpg' align='center' style='max-width:100%;'></center>"
            str &= "</font> "
            str &= "</td>	 "
            str &= "</tr>"
            str &= "<tr>"
            str &= "<td style='text-align: justify'> "
            str &= "<font face='Arial, Helvetica, sans-serif'>Dear  " & StrConv(FName.Trim() & " " & LName.Trim(), VbStrConv.ProperCase) & ","
            str &= "</font> "
            str &= "</td>	 "
            str &= "</tr>"
            str &= "<tr>"
            str &= "<td style='text-align: justify'> "
            str &= "<font face='Arial, Helvetica, sans-serif'>Thank you for your interest in the Global Hospitality Conclave 2019."
            str &= "</font> "
            str &= "</td>	 "
            str &= "</tr>"
            str &= "<tr>"
            str &= "<td style='text-align: justify'> "
            str &= "<font face='Arial, Helvetica, sans-serif'>We will get back to you with more details within three working days."
            str &= "</font> "
            str &= "</td>	 "
            str &= "</tr>"
            str &= "<tr>"
            str &= "<td style='text-align: justify'> "
            str &= "<font face='Arial, Helvetica, sans-serif'>Thank You,"
            str &= "</font> "
            str &= "</td>	"
            str &= "</tr>"
            str &= "<tr>"
            str &= "<td style='text-align: justify'> "
            str &= "<font face='Arial, Helvetica, sans-serif'><b>Organizing Committee <br />GHC 2019</b>"
            str &= "</font> "
            str &= "</td>	"
            str &= "</tr>"
            str &= "</table> "
            str &= "</center>"
            str &= "</div>"


            str &= "</body>"
            str &= "</html>"

            Message.Body = str

            '----------------------------------------------------------------------            

            '-----------------TLC Email-------------------------------------------

            Dim TLCMessage As New Net.Mail.MailMessage()
            Dim TLCmailID As String = "ghc@tlcgroup.com" ' tlc Email id 
            'Dim TLCmailID As String = "brijesh.gupta@tlcgroup.com" ' tlc Email id 
            Dim TLCFromEmail As New Net.Mail.MailAddress("ghc@tlcgroup.com", "Global Hospitality Conclave 2019.")

            TLCMessage.From = TLCFromEmail
            TLCMessage.To.Add(New Net.Mail.MailAddress(TLCmailID))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("drops@tlcgroup.com"))
            'TLCMessage.CC.Add(New Net.Mail.MailAddress("sudhir@tlcgroup.com"))
            'TLCMessage.CC.Add(New Net.Mail.MailAddress("sharoni.sharma@theleela.com"))

            TLCMessage.CC.Add(New Net.Mail.MailAddress("kamini.sharma@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("sunita.handoo@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("vijay.bisht@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("saurabh.dey@tlcgroup.com"))
            TLCMessage.CC.Add(New Net.Mail.MailAddress("manisha.malhotra@hotelmemberships.com"))


            'TLCMessage.CC.Add(New Net.Mail.MailAddress("shailendra@tlcgroup.com"))
            'TLCMessage.CC.Add(New Net.Mail.MailAddress("sonal.sharma@tlcgroup.com"))

            TLCMessage.IsBodyHtml = True
            TLCMessage.Subject = "Global Hospitality Conclave 2019 - Registration"
            Dim TLCstr As String = String.Empty

            TLCstr = "  <head>"
            TLCstr &= "<title>Thank You</title>"
            TLCstr &= "<style type=text/css'>"
            TLCstr &= ".auto-style1 {"
            TLCstr &= "width: 246px;"
            TLCstr &= "}"
            TLCstr &= "</style>"
            TLCstr &= "</head>"
            TLCstr &= "<body>"
            TLCstr &= "<table border='1' width='500px'>"
            TLCstr &= "<tr style='text-align:center; line-height:26px;'><td colspan='2'><strong>Following Profile is interested for Registration.</td> </tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Name"
            TLCstr &= "</td>"
            TLCstr &= " <td class='auto-style1'>" & txtFName.Text.Trim() & " " & txtLName.Text.Trim()
            TLCstr &= "</td>"
            TLCstr &= "</tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Email</td>"
            TLCstr &= "<td class='auto-style1'>" & txtEmailID1.Text & "</td>"
            TLCstr &= "</tr>"
            'TLCstr &= "<tr>"
            'TLCstr &= "<td>Telephone Number</td>"
            'TLCstr &= " <td class='auto-style1'>" & txtStdCode.Text & "-" & txtDayTimeTelePhone.Text & "</td>"
            'TLCstr &= "</tr>"
            TLCstr &= "<tr>"
            TLCstr &= "<td>Mobile</td>"
            TLCstr &= "<td class='auto-style1'>" & txtMobile.Text & "</td>"
            TLCstr &= "</tr>"

            TLCstr &= "<tr>"
            TLCstr &= "<td>Batch</td>"
            TLCstr &= "<td class='auto-style1'>" & txtBatch.Text & "</td>"
            TLCstr &= "</tr>"
            If (chkMangTrainee.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Management Trainee</td>"
                TLCstr &= "</tr>"
            End If
            If (chkHouseKeep.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>House Keeping Trainee</td>"
                TLCstr &= "</tr>"
            End If
            If (chkKitchen.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Kitchen</td>"
                TLCstr &= "</tr>"
            End If
            If (chkKitStewarding.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Kitchen and Stewarding</td>"
                TLCstr &= "</tr>"
            End If
            If (chkLeadership.Checked) Then
                TLCstr &= "<tr>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td class='auto-style1'>Leadership Role at The Oberoi Group for 5 years or more</td>"
                TLCstr &= "</tr>"
            End If
            TLCstr &= "<tr>"
            TLCstr &= "<td>Remarks</td>"
            TLCstr &= "<td class='auto-style1'>" & txtRemarks.Text & "</td>"
            TLCstr &= "</tr>"

            If (chkEveningEvent.Checked = True) Then

                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>&nbsp;</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>Registration for evening event</td>"
                TLCstr &= "</tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Name</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventName.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Mobile</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventMobile.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>Email</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventEmail.Text.Trim() + "</td></tr>"
                TLCstr &= "<tr  style='text-align:left; line-height:26px;'>"
                TLCstr &= "<td>ReEmail</td>"
                TLCstr &= "<td style='text-align:left' class='auto-style1'>" + txtEventReEmail.Text.Trim() + "</td></tr>"

            End If

            'If (chkDaySession.Checked) Then
            '    TLCstr &= "<tr>"
            '    TLCstr &= "<td>&nbsp;</td>"
            '    TLCstr &= "<td class='auto-style1'>Day Session at The Leela Ambience Gurugram Hotel  & Residences on 6th January, 2019</td>"
            '    TLCstr &= "</tr>"
            'End If
            'If (chkCocktailLeela.Checked) Then
            '    TLCstr &= "<tr>"
            '    TLCstr &= "<td>&nbsp;</td>"
            '    TLCstr &= "<td class='auto-style1'>Cocktails & Dinner at The Leela Ambience Gurugram Hotel  & Residences on 6th January, 2019</td>"
            '    TLCstr &= "</tr>"
            'End If

            TLCstr &= "<tr>"
            TLCstr &= "<td>Internet details</td>"
            TLCstr &= "<td class='auto-style1'>" & Request.ServerVariables("REMOTE_ADDR") & " - " & DateTime.Now.Date.ToString("dd MMM yyyy") & " & " & DateTime.Now.TimeOfDay.Hours.ToString() & ":" & DateTime.Now.TimeOfDay.Minutes.ToString() & "</td>"
            TLCstr &= "</tr>"
            TLCstr &= "<tr>"



            TLCstr &= "<td>&nbsp; &nbsp;</td>"
            TLCstr &= "<td class='auto-style1'>&nbsp; &nbsp;</td>"
            TLCstr &= " </tr>"
            TLCstr &= "</table>"
            TLCstr &= "<br />"
            TLCstr &= "Global Hospitality Conclave 2019<br /><br />"
            TLCstr &= "Note: This e-mail is automatically generated by our system on above profile contact request. "
            TLCstr &= "</body>"
            TLCstr &= "</html>"
            TLCMessage.Body = TLCstr

            Dim SmtpTLCClient As New Net.Mail.SmtpClient()
            SmtpTLCClient.EnableSsl = False
            SmtpTLCClient.UseDefaultCredentials = False
            SmtpTLCClient.Credentials = New Net.NetworkCredential("mail@tlc.in", "tlcgroup")
            SmtpTLCClient.Host = "smtpauth.tlc.in"
            SmtpTLCClient.Port = 587
            SmtpTLCClient.Send(Message)
            SmtpTLCClient.Send(TLCMessage)
            SmtpTLCClient = Nothing

        Catch ex As Exception
            Response.Write("Check SMTP server. Please Contact with Admin")
        End Try
    End Sub

    'Protected Sub chkEveningEvent_CheckedChanged(sender As Object, e As EventArgs) Handles chkEveningEvent.CheckedChanged
    '    If chkEveningEvent.Checked = True Then
    '        chkEveningEvent.Checked = True
    '    Else

    '        chkEveningEvent.Checked = False
    '        txtEventName.Text = Nothing
    '        txtEventMobile.Text = Nothing
    '        txtEventEmail.Text = Nothing
    '        txtEventReEmail.Text = Nothing
    '    End If
    'End Sub
End Class