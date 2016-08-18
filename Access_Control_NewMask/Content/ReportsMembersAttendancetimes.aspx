<%@ Page Title="<%$ Resources:localizedText, attendanceTimesMembers %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsMembersAttendancetimes.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsMembersAttendancetimes" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsMembersAttendancetimes.js"></script>
    <link href="Styles/ReportsMembersAttendancetimes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div id="ControlSection1" class="TopContentAreaDiv">
            <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, AttendanceTimesOfMitliederBePrinted %>" CssClass="lbltoparea"></asp:Label>
        </div>
        <div id="MainContdiv">
            <section class="midareaholder">
                <section class="topareatitles">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbltopareafirst"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, printStartAfter %>" CssClass="lbltopareafirstright"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbltopareafirstrightB"></asp:Label>
                </section>
                <section class="areasixitems">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lbltopareafirstdateleft"></asp:Label>
                    <dx:ASPxDateEdit ID="dtpFrom" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="dtFrom">
                        <ClientSideEvents DateChanged="function(s, e) {drpPlanDateFromChanged(s, e, dtpTo);}"></ClientSideEvents>
                    </dx:ASPxDateEdit>
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirstto"></asp:Label>
                    <dx:ASPxDateEdit ID="dtpTo" HorizontalAlign="Center" runat="server" Theme="Office2003Blue" CssClass="dtFrom">
                        <ClientSideEvents DateChanged="function(s, e) {drpPlanDateToChanged(s, e);}"></ClientSideEvents>
                    </dx:ASPxDateEdit>
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lbltopareafirstdate"></asp:Label>
                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="dtFromlast">
                        <asp:TableRow CssClass="rowOne">
                            <asp:TableCell CssClass="tblCell3">
                                <asp:CheckBox ID="chkenstri" runat="server" /><label for='chkenstri'></label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:CheckBox ID="chkVarA" runat="server" CssClass="chkAccssDataarea chkAllvar" />
                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, variantA %>" CssClass="lblvariantlast"></asp:Label>

                </section>
                <section class="areasixitems">
                    <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, studiogroup1 %>" CssClass="lbltopareafirstdateleft"></asp:Label>
                    <dx:ASPxComboBox ID="cboClientName" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboClientName" runat="server" SelectedIndex="0" ValueField="ID" TextField="GroupName" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrom">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNamePersonal(s, e);}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="GroupNr" Width="20%" />
                            <dx:ListBoxColumn Caption=" Name:" FieldName="GroupName" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbltopareafirstto"></asp:Label>
                    <dx:ASPxComboBox ID="cboClientNameto" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="GroupName" ClientIDMode="Static" ClientInstanceName="cboClientNameto" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrom">
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="GroupNr" Width="20%" />
                            <dx:ListBoxColumn Caption=" Name:" FieldName="GroupName" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, studiogroup1 %>" CssClass="lbltopareafirstdate"></asp:Label>
                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlast">
                        <asp:TableRow CssClass="rowOne">
                            <asp:TableCell CssClass="tblCell3">
                                <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:CheckBox ID="chkVarB" runat="server" CssClass="chkAccssDataareaB chkAllvar" />
                    <asp:Label ID="Label12" runat="server" Text="Variante B" CssClass="lblvariantlast"></asp:Label>

                </section>
                <section class="areasixitemsright">
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label13" runat="server" Text="Mitglieds Nr. von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cobMemberNr" CallbackPageSize="10000" SelectedIndex="0" ClientInstanceName="cobMemberNr" runat="server" ValueField="ID" TextField="MemberNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{0}" CssClass="cmbFrombottom" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboMemberGroupNr(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="MemberNumber" FieldName="MemberNumber" Width="20%" />
                                <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label14" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cobMemberNrTo" CallbackPageSize="10000" SelectedIndex="0" ClientInstanceName="cobMemberNrTo" runat="server" ValueField="ID" TextField="MemberNumber" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                            TextFormatString="{0}" CssClass="cmbFromarea2" DropDownRows="20" DropDownWidth="400px" Theme="Office2003Blue">
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Name="MemberNumber" FieldName="MemberNumber" Width="20%" />
                                <dx:ListBoxColumn Caption="Mitgliedsname:" Name="FullName" FieldName="FullName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label15" runat="server" Text="Mitglieds Nr.:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chklocation" runat="server" /><label for='chklocation'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label16" runat="server" Text="Name von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cmbPersName" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" SelectedIndex="0" ValueField="ID" TextField="FirstName" ClientIDMode="Static" ClientInstanceName="cmbPersName" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cmbPersNamePersonal(s, e);}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn FieldName="MemberNumber" Caption="Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="SurName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label17" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cmbPersNameTo" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="FirstName" SelectedIndex="0" ClientIDMode="Static" ClientInstanceName="cmbPersNameTo" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2">
                            <Columns>
                                <dx:ListBoxColumn FieldName="MemberNumber" Caption="Nr." Name="ProfileDescription" ToolTip="" Width="18%" />
                                <dx:ListBoxColumn FieldName="FirstName" Caption="Name:" Name="FirstName" ToolTip="Bezeichnung:" Width="42%" />
                                <dx:ListBoxColumn FieldName="SurName" Caption="<%$ Resources:localizedText ,firstname_new%>" Name="LastName" ToolTip="Bezeichnung:" Width="42%" />
                            </Columns>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label18" runat="server" Text="Name:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkdepartment" runat="server" /><label for='chkdepartment'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label20" runat="server" Text="Ausweis Nr. lang von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLongTransponder" CallbackPageSize="10000" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" ClientInstanceName="cboLongTransponder" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboLongTransponderePersonal(s, e);}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label21" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboLongTransponderTo" CallbackPageSize="10000" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>
                        <asp:Label ID="Label22" runat="server" Text="Ausweis Nr. lang:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkcostcenter" runat="server" /><label for='chkcostcenter'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                    <section class="areasixitemslastvariant">
                        <asp:Label ID="Label23" runat="server" Text="Ausweis Nr. Kurz von:" CssClass="lbltopareafirstdateleftbottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboShortTransponder" CallbackPageSize="10000" ClientInstanceName="cboShortTransponder" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFrombottom" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {cboShortTransponderPersonal(s, e);}"></ClientSideEvents>
                        </dx:ASPxComboBox>
                        <asp:Label ID="Label24" runat="server" Text="bis:" CssClass="lbltopareafirsttobottom"></asp:Label>
                        <dx:ASPxComboBox ID="cboShortTransponderTo" CallbackPageSize="10000" SelectedIndex="0" ValueField="ID" TextField="TransponderNr" ClientIDMode="Static" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="cmbFromarea2" DropDownWidth="200px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>
                        <asp:Label ID="Label25" runat="server" Text="Ausweis Nr. Kurz:" CssClass="lbltopareafirstdatebottom"></asp:Label>
                        <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="cmbFromlastbottom">
                            <asp:TableRow CssClass="rowOne">
                                <asp:TableCell CssClass="tblCell3">
                                    <asp:CheckBox ID="chkPersonalDate" runat="server" /><label for='chkPersonalDate'></label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                    </section>
                </section>
                <section class="lastvariant">
                    <asp:CheckBox ID="chkVarC" runat="server" CssClass="chkAccssDataareaC chkAllvar" />
                    <asp:Label ID="Label19" runat="server" Text="Variante C" CssClass="lblvariantlastarea"></asp:Label>
                </section>
            </section>

        </div>

    </div>
    <section class="showReports">
        <section class="mainBodyTop" style="display: none">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl" style="width: 41%;">
                        <asp:Label ID="Label26" runat="server" Text="Studio- Gruppe von:" CssClass="lblreport"></asp:Label>
                        <%--           <asp:Label ID="Label27" runat="server" Text="Standort von:" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label63" runat="server" Text="Abteilung von:" CssClass="lblreport"></asp:Label>--%>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtClientFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <%--                        <asp:TextBox ID="txtLocFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDept" runat="server" CssClass="drpreport"></asp:TextBox>--%>
                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label64" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <%--                  <asp:Label ID="Label65" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label66" runat="server" Text="bis:" CssClass="lblBis"></asp:Label>--%>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtClientTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <%--                        <asp:TextBox ID="txtLocTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptTo" runat="server" CssClass="drpreportnew"></asp:TextBox>--%>
                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <%--                            <asp:Label ID="Label67" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width:16%"></asp:Label>
                            <asp:Label ID="Label68" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label69" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>--%>
                            <asp:Label ID="Label74" runat="server" Text="Datum" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label76" runat="server" Text="von:" CssClass="lblDtFromTitle" Style="width: 13%;"></asp:Label>

                            <asp:TextBox ID="txtDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label77" runat="server" Text="bis:" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 20%;">
                            <asp:Label ID="Label70" runat="server" Text="Druckbeginn nach:" CssClass="lblPrintMode" Style="margin-left: 19%;"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label71" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo" style="margin-top: 18px;">
                        <section class="topRight1" style="margin-top: 5px;">
                            <asp:Label ID="Label72" runat="server" Text="Gedruckt am:" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label73" runat="server" Text="Uhrzeit:" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <%--  <asp:Label ID="lbl" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%;"></asp:Label>
                            <asp:Label ID="lblTimePrintType" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                            <section class="loggedInUser">
                                <asp:Label ID="Label75" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>
                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="Hoch:" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor: default;" />
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="Quer:" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor: default;" />
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                        </section>

                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm" style="display: none">
            <dx:ASPxGridView ID="grdShowReport" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReport" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReport_CustomCallback" OnHtmlDataCellPrepared="grdShowReport_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="Datum" VisibleIndex="1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="Studio- Gruppe" VisibleIndex="2" FieldName="MemberGroup"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mitglieds Nr" VisibleIndex="3" FieldName="ID_Nr" CellStyle-HorizontalAlign="Left">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="4" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. lang von" VisibleIndex="5" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. Kurz  " VisibleIndex="6" FieldName="CardNumbershort" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="E-Uhrzeit" VisibleIndex="7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="A-Uhrzeit" VisibleIndex="8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="K-Uhrzeit" VisibleIndex="7" Width="4%" FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="G-Uhrzeit" VisibleIndex="8" Width="4%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zeit" VisibleIndex="9" Width="4%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
        <section class="mainBodybtmB" style="display: none">
            <dx:ASPxGridView ID="grdShowReportB" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReportB" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReportB_CustomCallback" OnHtmlDataCellPrepared="grdShowReportB_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio- Gruppe" VisibleIndex="1" FieldName="MemberGroup"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mitglieds Nr" VisibleIndex="2" FieldName="ID_Nr" CellStyle-HorizontalAlign="Left">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="3" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. lang von" VisibleIndex="4" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. Kurz  " VisibleIndex="5" FieldName="CardNumbershort" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="Datum" VisibleIndex="6">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="E-Uhrzeit" VisibleIndex="7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="A-Uhrzeit" VisibleIndex="8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="K-Uhrzeit" VisibleIndex="7" Width="4%" FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="G-Uhrzeit" VisibleIndex="8" Width="4%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zeit" VisibleIndex="9" Width="4%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
        <section class="mainBodybtmC" style="display: none">
            <dx:ASPxGridView ID="grdShowReportC" runat="server" ClientIDMode="Static" ClientInstanceName="grdShowReportC" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdShowReportC_CustomCallback" OnHtmlDataCellPrepared="grdShowReportC_HtmlDataCellPrepared">

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Mitglieds Nr" VisibleIndex="1" FieldName="ID_Nr" CellStyle-HorizontalAlign="Left">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Name" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. lang von" VisibleIndex="3" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Ausweis Nr. Kurz  " VisibleIndex="4" FieldName="CardNumbershort" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Studio- Gruppe" VisibleIndex="5" FieldName="MemberGroup"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="Datum" VisibleIndex="6">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <%--<dx:GridViewDataDateColumn FieldName="EntryDate" Caption="E-Uhrzeit" VisibleIndex="7">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="A-Uhrzeit" VisibleIndex="8">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="Duration" Caption="Zeit" VisibleIndex="9">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>--%>
                    <dx:GridViewDataTextColumn Caption="K-Uhrzeit" VisibleIndex="7" Width="4%" FieldName="EntryTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="G-Uhrzeit" VisibleIndex="8" Width="4%" FieldName="ExitTimeText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Zeit" VisibleIndex="9" Width="4%" FieldName="DurationText">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="OneTodayCallbackPanel" runat="server" OnCallback="OneTodayCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="AttendanceLocalASPxDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="VisitorLocalASPxDocumentViewer" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport setHover" runat="server" Text="Zutrittsprotokoll drucken" Style="display: none;" />
    <asp:Button ID="btnPrintSelection" ClientIDMode="Static" runat="server" CssClass="btnPrintReport setHover" Text="Auswahl drucken" Style="width: 106px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" ClientIDMode="Static" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
