<%@ Page Title="<%$ Resources:localizedText, visitorsLists %>" Language="C#" MasterPageFile="~/MasterPages/Reports.Master" AutoEventWireup="true" CodeBehind="ReportsVisitorList.aspx.cs" Inherits="Access_Control_NewMask.Content.ReportsVisitorList" %>

<%@ Register Assembly="DevExpress.XtraReports.v15.2.Web, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/ReportsVisitorList.js"></script>
    <link href="Styles/ReportsVisitorList.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
        <div class="TopContentAreaDiv">
            <section class="sectop">
                <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText, dateTitle %>" CssClass="lblDateNamenew"></asp:Label>
                <asp:Label ID="lblDate" runat="server" Text="" CssClass="lblDateDisplaynew"></asp:Label>
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="toplabel">
            </section>
            <section class="contentarea">
                <section class="top1">
                    <section class="top1left">
                        <section class="lblleft">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, printSelection_New %>" CssClass="lbaus"></asp:Label>
                        </section>

                        <section class="topsec1left2">
                            <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobCompanyFrom" ClientInstanceName="cobCompanyFrom" ValueField="ID" TextField="CompanyName" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e ){cobCompanyFromIndexChanged(s, e);}"></ClientSideEvents>

                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="CompanyNr" Name="CompanyNr" />
                                     <dx:ListBoxColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" FieldName="CompanyName" Name="CompanyName" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobCompanyTo" ClientInstanceName="cobCompanyTo" ValueField="ID" TextField="CompanyName" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="CompanyNr" Name="CompanyNr" />
                                     <dx:ListBoxColumn Caption="<%$ Resources:localizedText, CompanyTitle %>" FieldName="CompanyName" Name="CompanyName" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobNameFrom" SelectedIndex="0" ClientInstanceName="cobNameFrom" ValueField="ID" TextField="Name" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s,e){cobNameFromIndexChanged(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="VisitorID" Name="VisitorID" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Name="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobNameTo" ClientInstanceName="cobNameTo" ValueField="ID" TextField="Name" TextFormatString="{1}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="VisitorID" Name="VisitorID" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Name="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="topsec1left2">
                            <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText, visitorsIdFrom %>" CssClass="lbldatefrom"></asp:Label>
                            <dx:ASPxComboBox ID="cobVisitorIdFrom" SelectedIndex="0" ClientInstanceName="cobVisitorIdFrom" ValueField="ID" TextField="VisitorID" TextFormatString="{0}" runat="server" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e){cobVisitorIdFromIndexChanged(s, e);}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="VisitorID" Name="VisitorID" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Name="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                            <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lbldateto"></asp:Label>
                            <dx:ASPxComboBox ID="cobVisitorIdTo" ClientInstanceName="cobVisitorIdTo" ValueField="ID" TextField="VisitorID" TextFormatString="{0}" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpcombo"
                                DropDownWidth="480px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="VisitorID" Name="VisitorID" />
                                    <dx:ListBoxColumn Caption="Name:" FieldName="Name" Name="Name" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                    </section>
                    <section class="top1right">
                        <section class="lblright">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, selectionOfReports_new %>" CssClass="lbsel"></asp:Label>
                        </section>

                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label20" runat="server" Text="1" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerstonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText, companyFromTitle %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkcompany" runat="server" /><label for='chkcompany'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label23" runat="server" Text="2" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersionalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkVisitorName" runat="server" /><label for='chkVisitorName'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label26" runat="server" Text="3" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPeronalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, visitorsId_NewP %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkVisitorID" runat="server" /><label for='chkVisitorID'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>


                    </section>
                </section>
                <section class="belowsec">

                    <section class="belowsecholder">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks" CssClass="tblCell1">
                                        <asp:Label ID="Label11" runat="server" Text="4" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText, zipCode2 %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhjbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkPostalCode" runat="server" /><label for='chkPostalCode'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjjecltschks" CssClass="tblCell1">
                                        <asp:Label ID="Label25" runat="server" Text="5" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, place2 %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldfbll" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkLocation" runat="server" /><label for='chkLocation'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjecschks" CssClass="tblCell1">
                                        <asp:Label ID="Label31" runat="server" Text="6" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label32" runat="server" Text="<%$ Resources:localizedText, streetAndNumber %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdrl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkStreetNumber" runat="server" /><label for='chkStreetNumber'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label33" runat="server" Text="7" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label34" runat="server" Text="<%$ Resources:localizedText, telephone %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkTelephone" runat="server" /><label for='chkTelephone'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctsschks" CssClass="tblCell1">
                                        <asp:Label ID="Label35" runat="server" Text="8" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerdrslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label36" runat="server" Text="<%$ Resources:localizedText, mobile %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldarbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkMobileNr" runat="server" /><label for='chkMobileNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctscehks" CssClass="tblCell1">
                                        <asp:Label ID="Label37" runat="server" Text="9" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrsflchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText, email1 %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbdl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkEmail" runat="server" /><label for='chkEmail'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObctschks" CssClass="tblCell1">
                                        <asp:Label ID="Label29" runat="server" Text="10" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerslchecks" CssClass="tblCell2">
                                        <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, indicator %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkVehicleRegNr" runat="server" /><label for='chkVehicleRegNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjectschks" CssClass="tblCell1">
                                        <asp:Label ID="lblObjects" runat="server" Text="11" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersonttalchecks" CssClass="tblCell2">
                                        <asp:Label ID="lblPersonal" runat="server" Text="<%$ Resources:localizedText, vehicleType %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbl" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkVehicleType" runat="server" /><label for='chkVehicleType'></label>

                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                    </section>




                    <section class="belowsecholderlast">
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjecuttschks1" CssClass="tblCell1">
                                        <asp:Label ID="Label1" runat="server" Text="12" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersjtonalchecks1" CssClass="tblCell2">
                                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, shorttermid %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lhjbl1" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkCardNumber" runat="server" /><label for='chkCardNumber'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblObjjecltschks1" CssClass="tblCell1">
                                        <asp:Label ID="Label3" runat="server" Text="13" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPersiodnalchecks1" CssClass="tblCell2">
                                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, accessAuthorizationFromTo %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldfbll1" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkAccessFromTo" runat="server" /><label for='chkAccessFromTo'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblOrrbjecschks1" CssClass="tblCell1">
                                        <asp:Label ID="Label5" runat="server" Text="14" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPerornalchecks1" CssClass="tblCell2">
                                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, accessPlanNr %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lbdrl1" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkAccessPlanNr" runat="server" /><label for='chkAccessPlanNr'></label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </section>
                        <section class="topsec1right2b">
                            <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="mainTableClassbelow">
                                <asp:TableRow CssClass="rowOne">
                                    <asp:TableCell ID="lblrObctschks1" CssClass="tblCell1">
                                        <asp:Label ID="Label9" runat="server" Text="14" CssClass="lblno"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="lblPrerrslchecks1" CssClass="tblCell2">
                                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, accessPlanDescription_newP %>" CssClass="lblobjectareatitle"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ldrbl1" CssClass="tblCell3">
                                        <asp:CheckBox ID="chkAccessPlanName" runat="server" /><label for='chkAccessPlanName'></label>
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
                        <asp:Label ID="Label70" runat="server" Text="<%$ Resources:localizedText, visitorsCompanyFrom %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label71" runat="server" Text="<%$ Resources:localizedText, nameFrom_P %>" CssClass="lblreport"></asp:Label>
                        <asp:Label ID="Label72" runat="server" Text="<%$ Resources:localizedText, visitorsIdFrom %>" CssClass="lblreport"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp">

                        <asp:TextBox ID="txtCompanyFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtNameFrom" runat="server" CssClass="drpreport"></asp:TextBox>

                        <asp:TextBox ID="txtDept" runat="server" CssClass="drpreport"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left2">
                    <section class="mainBodyTop1leftlbl2">
                        <asp:Label ID="Label73" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label74" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                        <asp:Label ID="Label75" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblBis"></asp:Label>
                    </section>
                    <section class="mainBodyTop1leftdrp4New">

                        <asp:TextBox ID="txtCompanyTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtNameTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                        <asp:TextBox ID="txtDeptTo" runat="server" CssClass="drpreportnew"></asp:TextBox>

                    </section>
                </section>
                <section class="mainBodyTop1left3">
                    <section class="selectionOne">
                        <section class="topRight1">
                            <%-- <asp:Label ID="Label76" runat="server" Text="Kostenstelle" CssClass="lblDateTitle" Style="width: 16%;display:none;"></asp:Label>
                            <asp:Label ID="Label77" runat="server" Text="von:" CssClass="lblDtFromTitle"></asp:Label>

                            <asp:TextBox ID="txtCostCenterFrom" runat="server" Style="text-align: center; display:none;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label78" runat="server" Text="bis:" CssClass="lblDateToTitle" Style="display:none"></asp:Label>

                            <asp:TextBox ID="txtCostCenterTo" runat="server" Style="text-align: center; display:none" CssClass="txtDispDateTo" ></asp:TextBox>--%>
                            <asp:Label ID="Label81" runat="server" Text="<%$ Resources:localizedText, visitorsId %>" CssClass="lblDateTitle"></asp:Label>
                            <asp:Label ID="Label82" runat="server" Text="<%$ Resources:localizedText, fromTitle %>" CssClass="lblDtFromTitle" Style="width:8%;"></asp:Label>

                            <asp:TextBox ID="txtVisitorIDFrom" runat="server" Style="text-align: center;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label83" runat="server" Text="<%$ Resources:localizedText, to_new %>" CssClass="lblDateToTitle"></asp:Label>

                            <asp:TextBox ID="txtVisitorIDTo" runat="server" Style="text-align: center;" CssClass="txtDispDateTo"></asp:TextBox>

                        </section>
                        <section class="topRight2" style="width: 30%;">
                            <asp:Label ID="Label79" runat="server" Text="<%$ Resources:localizedText, printingStart %>" CssClass="lblPrintMode" Style="display: none; margin-left: 12%;"></asp:Label>
                            <asp:Label ID="lblReportType" runat="server" Text="<%$ Resources:localizedText, variantA %>" Style="display: none" CssClass="lblTimeHrsMode"></asp:Label>
                        </section>
                        <section class="topRight3" style="display: none">
                            <asp:Label ID="Label80" runat="server" Text="Objekt" CssClass="lblPrintModeobj"></asp:Label>
                        </section>
                    </section>
                    <section class="selectionTwo">
                        <section class="topRight1" style="margin-top: 10px;">
                            <asp:Label ID="Label85" runat="server" Text="<%$ Resources:localizedText, printedOn %>" Style="margin-top: 3px;" CssClass="lblPrintDate"></asp:Label>

                            <asp:TextBox ID="txtPrintDate" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateFrom"></asp:TextBox>

                            <asp:Label ID="Label86" runat="server" Text="<%$ Resources:localizedText, time_newP %>" Style="margin-top: 3px;" CssClass="lblHrsToTitle"></asp:Label>

                            <asp:TextBox ID="txtPrintTime" runat="server" Style="text-align: center; margin-top: 0px;" CssClass="txtDispDateTo"></asp:TextBox>
                        </section>
                        <section class="topRight2">
                            <asp:Label ID="lblprintType" runat="server" Text="<%$ Resources:localizedText, createdBy %>" CssClass="lblPrintMode" Style="width: 25%;"></asp:Label>
                            <asp:Label ID="lblPersName" runat="server" Text="" CssClass="lblTimeHrsMode"></asp:Label>

                        </section>
                        <section class="topRight3perpekind">
                            <section class="secholdingarea1_new">
                                <asp:Label ID="Label99" runat="server" Text="<%$ Resources:localizedText, potrait %>" CssClass="txtportrait"></asp:Label>
                                <asp:ImageButton ID="imgPotrait" runat="server" CssClass="btnorientation1" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkPortrait" runat="server" CssClass="chk1controllast" />

                            </section>
                            <section class="secholdingarea1b_new">
                                <asp:Label ID="Label100" runat="server" Text="<%$ Resources:localizedText, landScape %>" CssClass="txtlandscape_new"></asp:Label>
                                <asp:ImageButton ID="imgLand" runat="server" CssClass="btnorientation2" Style="cursor:default;"/>
                                <asp:CheckBox ID="chkLandScape" runat="server" CssClass="chk1controllast" />

                            </section>
                        </section>
                    </section>
                    <section class="selectionThree">
                        <section class="topRight1" style="margin-top: 5px;">
                        </section>
                        <section class="topRight2">
                        </section>
                        <section class="topRight3">
                        </section>

                    </section>
                </section>
            </section>
        </section>
        <section class="mainBodybtm">
            <dx:ASPxGridView ID="grdVisitorList" runat="server" ClientIDMode="Static" ClientInstanceName="grdVisitorList" OnCustomCallback="grdVisitorList_CustomCallback" Theme="Office2003Blue" SettingsPager-AlwaysShowPager="false" Settings-ShowFooter="false" SettingsBehavior-AllowSort="true" SettingsBehavior-AllowDragDrop="true" AutoGenerateColumns="False" SettingsPager-PageSize="13" KeyFieldName="ID" SettingsPager-ShowEmptyDataRows="True" Width="100%">
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="VisitorCompany" Caption="<%$ Resources:localizedText, visitorsCompanyTitle %>" VisibleIndex="1">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="VisitorName" Caption="Name:" VisibleIndex="2">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="VisitorID" Caption="<%$ Resources:localizedText, visitorsId_NewP %>" VisibleIndex="3">
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="PostalCode" Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="4">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, placeTitle %>" VisibleIndex="5" FieldName="Location"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, streetAndNumber %>" VisibleIndex="6" FieldName="Street_Number">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, telephone %>" VisibleIndex="7" FieldName="Telephone"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, mobile2 %>" VisibleIndex="8" FieldName="MobileNumber">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, email2 %>" VisibleIndex="9" FieldName="Email"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, indicator %>" VisibleIndex="10" FieldName="VehicleRegNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, vehicleType %>" VisibleIndex="11" FieldName="VehicleType" CellStyle-HorizontalAlign="Left"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, shortTermCardNo %>" VisibleIndex="12" FieldName="CardNumber"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="AccessFromTo" Caption="<%$ Resources:localizedText, accessAuthorizationFromTo %>" VisibleIndex="13">
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy" EditFormatString="dd.MM.yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanNr %>" VisibleIndex="14" FieldName="AccessPlanNr"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, accessPlanDescription_newP %>" VisibleIndex="15" FieldName="AccessPlanName"></dx:GridViewDataTextColumn>


                </Columns>
                <SettingsPager AlwaysShowPager="false" PageSize="32"></SettingsPager>
            </dx:ASPxGridView>
        </section>
    </section>
    <div class="showReportsDocViewer" style="display: none;">
        <dx:ASPxCallbackPanel ID="ReportsVisitorListPanel" runat="server" OnCallback="ReportsVisitorListPanel_Callback">
            <PanelCollection>

                <dx:PanelContent runat="server">
                    <dx:ASPxWebDocumentViewer ID="ReportVisitorListASPxDocumentViewer" Style="width: 100%; height: 1100px;" ClientIDMode="Static" ClientInstanceName="ReportVisitorListASPxDocumentViewer" runat="server" Theme="Office2003Blue">
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
    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
