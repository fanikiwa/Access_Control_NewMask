<%@ Page Title="<%$ Resources:localizedText, attendanceListMembers %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsMembersAttendaceList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsMembersAttendaceList" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/ReportsMembersAttendaceList.css" rel="stylesheet" />
    <script src="Scripts/ReportsMembersAttendaceList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="HiddenField1BackValue" runat="server" />

    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="sectop">
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, quickPrint %>" CssClass="lblqckdruk"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, allPresent %>" CssClass="lblalleanswe"></asp:Label>
                <asp:CheckBox ID="chkPresentOnly" runat="server" CssClass="chkanwse chkSwitch" />
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, allAbsence %>" CssClass="lblalleabswe"></asp:Label>
                <asp:CheckBox ID="chkAbsencesOnly" runat="server" CssClass="chkabwse chkSwitch" />
                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, allBookingsMade %>" CssClass="lblalleget"></asp:Label>
                <asp:CheckBox ID="chkAllBookings" runat="server" CssClass="chkallget chkSwitch" />
                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, dateTitle %>" CssClass="lbldatum"></asp:Label>
                <dx:ASPxDateEdit ID="dtPrintDateMain" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedisT"></dx:ASPxDateEdit>
                <asp:Button ID="btnQuickPrint" runat="server" Text="<%$ Resources:localizedText, quickPrint %>" CssClass="btnquickdruk" />
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="toplabel">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, filteredPrint %>" CssClass="labeltop"></asp:Label>
            </section>
            <section class="contentarea">
                <section class="top1">
                    <section class="top1left">
                        <section class="lblleft">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbaus"></asp:Label>
                        </section>
                        <section class="topsec1left">
                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, dateFrom_newP %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxDateEdit ID="dtPrintDateFrom" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxDateEdit ID="dtPrintDateTo" runat="server" HorizontalAlign="Center" Theme="Office2003Blue" CssClass="datedis"></dx:ASPxDateEdit>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, studioGroupFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <%--<dx:ASPxComboBox ID="ASPxComboBox2" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>
                            <dx:ASPxComboBox ID="cboStudioGroupFrom" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ClientIDMode="Static" ClientInstanceName="cboStudioGroupFrom" runat="server" SelectedIndex="0" ValueField="ID" TextField="GroupName" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {cboStudioGroupSelectionChanged(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="GroupNr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" Name:" FieldName="GroupName" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <%--<dx:ASPxComboBox ID="ASPxComboBox3" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"></dx:ASPxComboBox>--%>
                            <dx:ASPxComboBox ID="cboStudioGroupTo" CallbackPageSize="10000" TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueField="ID" TextField="GroupName" ClientIDMode="Static" ClientInstanceName="cboStudioGroupTo" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueType="System.String" CssClass="drpcombo">
                                <Columns>
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="GroupNr" Width="20%" />
                                    <dx:ListBoxColumn Caption=" Name:" FieldName="GroupName" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                    </section>
                    <section class="top1right">
                        <section class="lblright">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbsel"></asp:Label>
                        </section>
                        <section class="topsec1right">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClass">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell1">
                                        <asp:Label ID="lblObjects" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                        <asp:Label ID="lblPersonal" runat="server" Text="<%$ Resources:localizedText, date %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberDate" runat="server" /><label for='chkMemberDate'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label20" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, studiogroup1 %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkStudioGroup" runat="server" /><label for='chkStudioGroup'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>

                    </section>
                </section>
                <section class="belowsec">
                    <section class="lblleft">
                        <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText, otherSelections %>" CssClass="lbaus"></asp:Label>
                    </section>
                    <section class="belowsecholder">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label11" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, membername %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberName" runat="server" /><label for='chkMemberName'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label25" runat="server" Text="7" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, memberIdNo %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberId" runat="server" /><label for='chkMemberId'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjeecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label40" runat="server" Text="8" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalfchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label41" runat="server" Text="<%$ Resources:localizedText, contractNo %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdsrl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberContractNr" runat="server" /><label for='chkMemberContractNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label31" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, cardNo %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMemberCardNr" runat="server" /><label for='chkMemberCardNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label33" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, expiresDate %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkExpiryDate" runat="server" /><label for='chkExpiryDate'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctsschks" CssClass="tblCell1">
                                        <asp:Label ID="Label35" runat="server" Text="11" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, EntryDate %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkEntry" runat="server" /><label for='chkEntry'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctscehks" CssClass="tblCell1">
                                        <asp:Label ID="Label37" runat="server" Text="12" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrsflchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, exitDate_P %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkExit" runat="server" /><label for='chkExit'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                    </section>
                </section>
            </section>
        </div>
    </div>

    <section class="showReports" style="display: none">
        <section class="mainBodyTop">
            <section class="mainBodyTop1 ">
                <section class="mainBodyTop1left">
                    <section class="mainBodyTop1leftlbl">
                        <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, locationFrom_new %>" Style="display: none" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText, buildingFrom %>" CssClass="lblreport" Style="display: none"></asp:Label>
                        <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, studioGroupFrom %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="TextBox1" runat="server" CssClass="drpreport" Style="display: none"></asp:TextBox>

                        <asp:TextBox ID="TextBox2" runat="server" CssClass="drpreport" Style="display: none"></asp:TextBox>

                        <asp:TextBox ID="txtMemberGroupFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis" Style="display: none"></asp:Label>
                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis" Style="display: none"></asp:Label>
                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="TextBox4" runat="server" CssClass="drpreportnew" Style="display: none"></asp:TextBox>

                        <asp:TextBox ID="TextBox5" runat="server" CssClass="drpreportnew" Style="display: none"></asp:TextBox>

                        <asp:TextBox ID="txtMemberGroupTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, date_new %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintDateFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label43" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintDateTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2 topRight2areanew">
                           <%-- <asp:Label ID="Label44" runat="server" Text="Selektion der Auswertungen:" CssClass="lblPrintMode" Style="margin-left: 19%;"></asp:Label>
                            <asp:Label ID="Label45" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>--%>
                             
                              <section class="loggedInUser2">
                                <asp:Label ID="Label54" runat="server" Text="<%$ Resources:localizedText, createdBy %>" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="lblUser" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>


                        </section>
                        <section class="topRight3">
                            <asp:Label ID="printType" runat="server" Text="" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1">
                            <asp:Label ID="Label47" runat="server" Text="<%$ Resources:localizedText, time %>" CssClass="lblDateTitle" Style="display: none"></asp:Label>
                            <asp:Label ID="Label48" runat="server" Text="<%$ Resources:localizedText, fromnew %>" CssClass="lblDtFromTitle" Style="display: none"></asp:Label>

                            <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center; display: none;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label49" runat="server" Text="bis:" Style="display: none" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center; display: none;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="Label50" runat="server" Text="Ausgwählter Zeitbereich:" CssClass="lblPrintMode" Style="width: 56%; display: none;"></asp:Label>
                            <asp:Label ID="Label51" runat="server" Text="" CssClass="lblTimeHrsMode" Style="display: none"></asp:Label>
                        </section>
                        <section class="topRight3">
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1">
                            <asp:Label ID="Label52" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label53" runat="server" Text="<%$ Resources:localizedText, timeTitle %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2">
                          <%--  <section class="loggedInUser">
                                <asp:Label ID="Label54" runat="server" Text="Erstellt von:" Style="font-weight: 600;" CssClass="lblCreatedBy"></asp:Label>
                                <asp:Label ID="Label55" runat="server" Text="" CssClass="lblPersNameText"></asp:Label>
                            </section>--%>
                        </section>
                             <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast"/>

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdDisplayMemberAttendance" runat="server" ClientIDMode="Static" ClientInstanceName="grdDisplayMemberAttendance" Theme="Office2003Blue" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%" OnCustomCallback="grdDisplayMemberAttendance_CustomCallback">
                <SettingsBehavior AllowSort="false" AllowFocusedRow="True" AllowDragDrop="False" AllowGroup="False" AutoExpandAllGroups="True" />
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BookingDate" Caption="<%$ Resources:localizedText, date_new %>" VisibleIndex="1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, studioGruppe %>" Visible="false" VisibleIndex="2" FieldName="MemberGroup"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, membername %>" VisibleIndex="3" FieldName="Name"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, memberIdNo %>" Visible="false" VisibleIndex="4" FieldName="ID_Nr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, contractNo %>" VisibleIndex="5" FieldName="AgreementNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, cardNo %>" Visible="false" VisibleIndex="6" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="<%$ Resources:localizedText, expiryDate_new %>" Visible="false" VisibleIndex="7" FieldName="ExpiryDate">
                          <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="EntryDate" Caption="<%$ Resources:localizedText, joining %>" Visible="false" VisibleIndex="8">
                                     <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="ExitDate" Caption="<%$ Resources:localizedText, withdrawal %>" Visible="false" VisibleIndex="9">
                                     <HeaderStyle HorizontalAlign="Center" />
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                        <PropertiesDateEdit DisplayFormatString="HH:mm" EditFormatString="HH:mm"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="MemberAttendanceCallbackPanel" runat="server" OnCallback="MemberAttendanceCallbackPanel_Callback">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="ASPxDocumentViewerMemberAttendanceReport" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="ASPxDocumentViewerMemberAttendanceReport" runat="server" Theme="Office2003Blue">
                    </dx:ASPxWebDocumentViewer>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnPrintAttendance" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, printSelection_title %>" Style="width: 170px;" />

    <asp:Button ID="btnPrintReport" CssClass="btnPrintReport" runat="server" Text="<%$ Resources:localizedText, printAttendance %>" Style="display: none" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
