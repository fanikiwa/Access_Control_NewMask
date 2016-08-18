<%@ Page Title="<%$ Resources:localizedText, companychanged %>" ClientIDMode="Static" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Access_Control_NewMask.Content.Customer" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Customer.js"></script>
    <link href="Styles/Customer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
        <asp:HiddenField ID="saveChangesonNew" ClientIDMode="Static" runat="server" />
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTop">
                <section class="secLeftTopL">

                    <asp:Label ID="lblCustomerNr" runat="server" CssClass="lblsec2Tsd" Text="<%$ Resources:localizedText, companynonew %>"></asp:Label>

                    <dx:ASPxComboBox ID="cboCustomerNr" CssClass="ddlist2Tasad" ClientInstanceName="cboCustomerNr" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueField="ID" TextField="Client_Nr" HorizontalAlign="left"
                        TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboCustomerNrSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>

                </section>
                <section class="secLeftTopR3">
                    <asp:Label ID="lblClientName" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, companynew %>"></asp:Label>
                    <dx:ASPxComboBox ID="cboClientName2" CssClass="ddlistT2" SelectedIndex="0" runat="server" Theme="Office2003Blue" ValueField="ID" TextField="Name"
                        TextFormatString="{1}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientName2SelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="Client_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, companynew %>" FieldName="Name" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
            </section>
            <section class="secRightTop">
            </section>
        </div>
        <div class="MidContentAreaDiv">
            <section class="secLeftMid2">
                <section class="topsecLeftMid">
                    <section class="secTitleData">
                        <asp:Label ID="lblData" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, dataTitle %>"></asp:Label>
                    </section>
                    <section class="secTitleSelection">
                        <asp:Label ID="lblSelection" runat="server" CssClass="lblheader2" Text="<%$ Resources:localizedText, selectionTitle %>"></asp:Label>
                    </section>
                </section>
                <section class="btmsecLeftMid">
                    <section class="innersec">
                        <section class="upperbtmsecLeftMid">
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, companynonew %>"></asp:Label>
                                    <asp:TextBox ID="txtClientNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblCustomerData" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, companynew %>"></asp:Label>
                                    <asp:TextBox ID="txtClientName" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblPlz" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, zipCode3 %>"></asp:Label>
                                    <asp:TextBox ID="txtPLZ" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblOrt" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                    <asp:TextBox ID="txtOrt" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblStreet" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" runat="server" CssClass="txtsec"></asp:TextBox>

                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label4" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, no2 %>"></asp:Label>
                                    <asp:TextBox ID="txtHouseNr" runat="server" CssClass="txtsec2"></asp:TextBox>

                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblState" runat="server" CssClass="lblsecnew" Text="<%$ Resources:localizedText, state2 %>"></asp:Label>
                                    <dx:ASPxComboBox ID="cboState" CssClass="bunddlist" ClientIDMode="Static" Theme="Aqua" runat="server" ValueField="ID" TextField="StateName"
                                        SelectedIndex="0" ValueType="System.String" DropDownRows="20" DropDownWidth="300px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    </dx:ASPxComboBox>
                                    <%--<asp:DropDownList ID="ddlState" CssClass="bunddlist" runat="server" DataValueField="ID" DataTextField="StateName"></asp:DropDownList>--%>
                                </section>
                                <section class="secdivright" style="display: none">
                                    <asp:Label ID="Label1" runat="server" CssClass="lblsecrff" Text="<%$ Resources:localizedText, holidayCalendar %>"></asp:Label>
                                    <asp:DropDownList ID="ddlHolidayCalendar" ClientIDMode="Static" CssClass="bunddlistsdf" runat="server" DataValueField="ID" DataTextField="HolidayCalendarName"></asp:DropDownList>
                                    <asp:ImageButton ID="imgCalenderGrid" CssClass="btnInfo" runat="server" />
                                </section>
                            </section>
                        </section>
                        <section class="lowerbtmsecLeftMid">
                            <section class="lowerbtmsecLeftMidL">
                                <section class="topsec">
                                    <asp:Label ID="lblRespPerson" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, personincharge2 %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <section class="secdiv2">
                                        <asp:Label ID="lblName" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, name %>"></asp:Label>
                                        <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblFunct" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, function2 %>"></asp:Label>
                                        <asp:TextBox ID="txtFunct" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblTel" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, telephone %>"></asp:Label>
                                        <asp:TextBox ID="txtTel" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblMob" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, mobile2 %>"></asp:Label>
                                        <asp:TextBox ID="txtMob" ClientIDMode="Static" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblEmail" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, email2 %>"></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                </section>
                            </section>
                            <section class="lowerbtmsecLeftMidR">
                                <section class="topsec">
                                    <asp:Label ID="lblMemo" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, memoTitle %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <asp:TextBox ID="txtMemo" CssClass="txtMemo" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                </section>
                            </section>
                        </section>
                    </section>
                </section>
                <section class="secRightMid">
                    <section class="btmsecRightMid">
                        <section class="innersec2">
                            <dx:ASPxGridView ID="grdClientDetails" runat="server" ClientIDMode="Static" ClientInstanceName="grdClientDetails" EnableCallBacks="false" AutoGenerateColumns="False" KeyFieldName="ID"
                                EnableTheming="True" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" Theme="Office2003Blue" Width="100%">
                                <ClientSideEvents RowClick="function(s, e) {grdClientDetailsRowClick(s, e)}"></ClientSideEvents>

                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, companynonew %>" VisibleIndex="1" FieldName="Client_Nr">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="14%" Caption="<%$ Resources:localizedText, companynew %>" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="3" FieldName="Ort"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="4" FieldName="Plz">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="14%" Caption="<%$ Resources:localizedText, personincharge2 %>" FieldName="PersonInCharge" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, telephone %>" FieldName="Telephone" VisibleIndex="7">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowDragDrop="False" AllowSort="False" AllowFocusedRow="True" AllowGroup="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                                <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </section>
                    </section>
                </section>
            </section>
            <section class="secCalendar" style="display: none;">
                <section class="topsecRightMidNew">
                    <asp:Label ID="Label2" runat="server" Text="Kalender Nr." CssClass="lblClndrNrKldnr"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarNumber" runat="server" CssClass="txtClndrNrKldr"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="Description" CssClass="lblClndrDscKldr"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarName" runat="server" CssClass="txtClndrDscKldr"></asp:TextBox>
                </section>
                <section class="innersec2b">
                    <dx:ASPxGridView ID="gridViewHolidayCalendar" ClientInstanceName="gridViewHolidayCalendar" runat="server"
                        KeyFieldName="Id" Theme="Office2003Blue" Width="100%">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="1" VisibleIndex="1" Visible="False" FieldName="Id">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, month %>" VisibleIndex="2" FieldName="MonthName">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="1" VisibleIndex="3" FieldName="Day1Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="2" VisibleIndex="4" FieldName="Day2Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="3" VisibleIndex="5" FieldName="Day3Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="4" VisibleIndex="6" FieldName="Day4Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="5" VisibleIndex="7" FieldName="Day5Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="6" VisibleIndex="8" FieldName="Day6Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="7" VisibleIndex="9" FieldName="Day7Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="8" VisibleIndex="10" FieldName="Day8Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="9" VisibleIndex="11" FieldName="Day9Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="10" VisibleIndex="12" FieldName="Day10Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="11" VisibleIndex="13" FieldName="Day11Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="12" VisibleIndex="14" FieldName="Day12Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="13" VisibleIndex="15" FieldName="Day13Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="14" VisibleIndex="16" FieldName="Day14Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="15" VisibleIndex="17" FieldName="Day15Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="16" VisibleIndex="18" FieldName="Day16Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="17" VisibleIndex="19" FieldName="Day17Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="18" VisibleIndex="20" FieldName="Day18Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="19" VisibleIndex="21" FieldName="Day19Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="20" VisibleIndex="22" FieldName="Day20Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="21" VisibleIndex="23" FieldName="Day21Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="22" VisibleIndex="24" FieldName="Day22Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="23" VisibleIndex="25" FieldName="Day23Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="24" VisibleIndex="26" FieldName="Day24Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="25" VisibleIndex="27" FieldName="Day25Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="26" VisibleIndex="28" FieldName="Day26Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="27" VisibleIndex="29" FieldName="Day27Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="28" VisibleIndex="30" FieldName="Day28Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="29" VisibleIndex="31" FieldName="Day29Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="30" VisibleIndex="32" FieldName="Day30Holiday">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="31" VisibleIndex="33" FieldName="Day31Holiday">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPager PageSize="12" ShowEmptyDataRows="True">
                        </SettingsPager>
                        <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSort="False"></SettingsBehavior>
                        <Settings ShowStatusBar="Hidden" />
                        <SettingsDetail ShowDetailButtons="False" />
                    </dx:ASPxGridView>
                </section>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newcompanysave %>" OnClick="btnNew_Click" Style="width: 91px !important;" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savecompany %>" OnClick="btnSave_Click" Style="width: 124px !important;" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, deletecompany %>" OnClick="btnDelete_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
