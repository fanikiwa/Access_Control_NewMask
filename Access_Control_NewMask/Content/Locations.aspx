<%@ Page Title="<%$ Resources:localizedText, location2 %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="Access_Control_NewMask.Content.Locations" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Locations.css" rel="stylesheet" />
    <script src="Scripts/Locations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="saveChangesonNew" ClientIDMode="Static" runat="server" />
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTop">
                <section class="secLeftTopL">
                    <asp:Label ID="lbllocationno" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, locationNo %>"></asp:Label>
                    <dx:ASPxComboBox ID="cbolocno" runat="server" ClientInstanceName="cbolocno" CssClass="ddlistT2" Theme="Office2003Blue" TextField="Location_Nr" ValueField="ID" ClientIDMode="Static" EnableCallbackMode="true"
                        TextFormatString="{0}" DropDownWidth="480px" SelectedIndex="0" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cbolocnSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
                <section class="secLeftTopR3">
                    <asp:Label ID="lbllocation" runat="server" CssClass="lblsec2Tsd" Text="<%$ Resources:localizedText, location1 %>"></asp:Label>
                    <dx:ASPxComboBox ID="cbolocation" runat="server" CssClass="ddlist2Tasad" ClientInstanceName="cbolocation" Theme="Office2003Blue" TextField="Name" ValueField="ID" ClientIDMode="Static"
                        TextFormatString="{1}" DropDownWidth="480px" SelectedIndex="0" EnableCallbackMode="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cbolocationSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr.:" FieldName="Location_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, location1 %>" FieldName="Name" Width="80%" />
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
                                    <asp:Label ID="lbllocno" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, locationNo %>"></asp:Label>
                                    <asp:TextBox ID="txtlocno1" runat="server" CssClass="txtsec"></asp:TextBox>

                                </section>
                                <section class="secdivright">

                                    <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, location1 %>"></asp:Label>
                                    <asp:TextBox ID="txtloc" runat="server" CssClass="txtsec2"></asp:TextBox>

                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblPLZ" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, plz %>"></asp:Label>
                                    <asp:TextBox ID="txtPLZ" runat="server" CssClass="txtsec"></asp:TextBox>

                                </section>
                                <section class="secdivright">

                                    <asp:Label ID="lblOrt" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, place2 %>"></asp:Label>
                                    <asp:TextBox ID="txtOrt" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblStreet" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" runat="server" CssClass="txtsec2" style="width:50%;"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblhseNumber" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, housenr %>"></asp:Label>
                                    <asp:TextBox ID="txthseNumber" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblState" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, state2 %>"></asp:Label>
                                    <dx:ASPxComboBox ID="cboState" runat="server" SelectedIndex="0" CssClass="bunddlist" Theme="Office2003Blue" ValueType="System.String" ValueField="ID" TextField="StateName" ClientIDMode="Static" DropDownRows="20" DropDownWidth="300px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label1" runat="server" CssClass="lblsecrff" Text="<%$ Resources:localizedText, holidayCalendar %>"></asp:Label>
                                    <dx:ASPxComboBox ID="ddlHolidayCalendar" ClientInstanceName="ddlHolidayCalendar" runat="server" SelectedIndex="0" CssClass="bunddlistsdf" Theme="Office2003Blue" ValueType="System.String" ValueField="ID" TextField="HolidayCalendarName" DropDownRows="20" DropDownWidth="300px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>

                                    <asp:ImageButton ID="imgCalenderGrid" CssClass="btnInfo" runat="server" ClientIDMode="Static" />


                                </section>
                            </section>
                        </section>
                        <section class="lowerbtmsecLeftMid">
                            <section class="lowerbtmsecLeftMidL">
                                <section class="topsec">
                                    <asp:Label ID="lblRespPerson" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, responsiblePerson %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <section class="secdiv2">
                                        <asp:Label ID="lblName" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, name %>"></asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="txtsec3"></asp:TextBox>
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
                            <dx:ASPxGridView ID="grdLocation" runat="server" ClientInstanceName="grdLocation" AutoGenerateColumns="False"
                                Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" EnableCallBacks="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                <ClientSideEvents
                                    RowClick="function(s, e) {
	grdLocRowClick(s, e)
}" />
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, locationNo %>" VisibleIndex="1" FieldName="Location_Nr">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="15%" Caption="<%$ Resources:localizedText, location1 %>" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="3" FieldName="Place"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="4" FieldName="ZipCode">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="21%" Caption="<%$ Resources:localizedText, holidayCalenderTitle2 %>" FieldName="HolidayCalendar.HolidayCalendarName" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, responsiblePerson %>" FieldName="LocationHeadName" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, telephone %>" FieldName="LocationHeadPhone" VisibleIndex="7">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Function" FieldName="LocationHeadFunction" VisibleIndex="8" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Mobile" FieldName="LocationHeadMobile" VisibleIndex="9" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Email" FieldName="LocationHeadEmail" VisibleIndex="10" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Memo" FieldName="InfoText" VisibleIndex="11" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="state" FieldName="State" VisibleIndex="12" Visible="false"></dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" AllowDragDrop="false" />
                                <SettingsPager Visible="False" ShowEmptyDataRows="True" PageSize="21">
                                </SettingsPager>
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            </dx:ASPxGridView>
                        </section>
                    </section>
                </section>
            </section>
            <section class="secCalendar" style="display: none;">
                <section class="topsecRightMidNew">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, calendarNo %>" CssClass="lblClndrNrKldnr"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarNumber" runat="server" CssClass="txtClndrNrKldr"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblClndrDscKldr"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarName" runat="server" CssClass="txtClndrDscKldr"></asp:TextBox>
                </section>
                <section class="innersec2b">
                    <dx:ASPxGridView ID="gridViewHolidayCalendar" ClientInstanceName="gridViewHolidayCalendar" runat="server"
                        KeyFieldName="Id" OnHtmlDataCellPrepared="gridViewHolidayCalendar_HtmlDataCellPrepared" Theme="Office2003Blue" Width="100%" OnCustomCallback="gridViewHolidayCalendar_CustomCallback" AutoGenerateColumns="False">
                        <ClientSideEvents EndCallback="function(s, e) {
	gridViewHolidayCalendarEndCallback(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="1" VisibleIndex="1" Visible="False" FieldName="Id">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, month %>" VisibleIndex="2" FieldName="MonthName" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="1" VisibleIndex="3" FieldName="Day1Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="2" VisibleIndex="4" FieldName="Day2Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="3" VisibleIndex="5" FieldName="Day3Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="4" VisibleIndex="6" FieldName="Day4Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="5" VisibleIndex="7" FieldName="Day5Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="6" VisibleIndex="8" FieldName="Day6Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="7" VisibleIndex="9" FieldName="Day7Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="8" VisibleIndex="10" FieldName="Day8Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="9" VisibleIndex="11" FieldName="Day9Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="10" VisibleIndex="12" FieldName="Day10Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="11" VisibleIndex="13" FieldName="Day11Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="12" VisibleIndex="14" FieldName="Day12Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="13" VisibleIndex="15" FieldName="Day13Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="14" VisibleIndex="16" FieldName="Day14Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="15" VisibleIndex="17" FieldName="Day15Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="16" VisibleIndex="18" FieldName="Day16Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="17" VisibleIndex="19" FieldName="Day17Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="18" VisibleIndex="20" FieldName="Day18Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="19" VisibleIndex="21" FieldName="Day19Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="20" VisibleIndex="22" FieldName="Day20Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="21" VisibleIndex="23" FieldName="Day21Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="22" VisibleIndex="24" FieldName="Day22Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="23" VisibleIndex="25" FieldName="Day23Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="24" VisibleIndex="26" FieldName="Day24Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="25" VisibleIndex="27" FieldName="Day25Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="26" VisibleIndex="28" FieldName="Day26Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="27" VisibleIndex="29" FieldName="Day27Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="28" VisibleIndex="30" FieldName="Day28Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="29" VisibleIndex="31" FieldName="Day29Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="30" VisibleIndex="32" FieldName="Day30Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="31" VisibleIndex="33" FieldName="Day31Holiday" CellStyle-Paddings-PaddingTop="12px" CellStyle-Paddings-PaddingBottom="12px">
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
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newlocations %>" OnClick="btnNew_Click" Style="width: 89px !important;" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savelocations %>" OnClick="btnSave_Click" Style="width: 123px !important;" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletelocations %>" OnClick="btnDelete_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
