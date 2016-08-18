<%@ Page Title="<%$ Resources:localizedText,eventCalendar%>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="HolidayCalender.aspx.cs" Inherits="Access_Control_NewMask.Content.HolidayCalender" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/HolidayCalender.js"></script>
    <link href="Styles/HolidayCalender.css" rel="stylesheet" />
        <link href="Styles/FormViewSearchcalender.css" rel="stylesheet" /> 
    <%--<link href="Styles/SaveDeleteDialog.css" rel="stylesheet" />--%>
   <%-- <link href="Styles/ImportantInfoDialogHolidayCalendar.css" rel="stylesheet" />--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
     <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldHolidayModeValue" runat="server" />
    <asp:HiddenField ID="hiddenFieldCalendarYear" runat="server" />
    <asp:HiddenField ID="hiddenFieldChangeType" runat="server" />
    <asp:HiddenField ID="hiddenFieldCalendarType" runat="server" />
    <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />
    <asp:HiddenField ID="hiddenFieldMaintainState" runat="server" />
    <asp:HiddenField ID="hiddenFieldRedirect" runat="server" />
    <asp:HiddenField ID="hiddenFieldConfirmDialog" runat="server" />
    <asp:HiddenField ID="hiddenFieldChangesSaved" runat="server" />
    <asp:HiddenField ID="_isPostBack" runat="server" />
    <asp:HiddenField ID="HolCRHiddenField" ClientIDMode="Static" runat="server" />
        <section class="contentdiv"> 
        <dx:ASPxLoadingPanel ID="CalenderLoadingPanel" ClientInstanceName="CalenderLoadingPanel" runat="server"></dx:ASPxLoadingPanel>
        <section class="contentdivtop">
            <section class="contentdivtop1">
                <section class="contentdivtop1left">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText,holidayCalendarNo2%>" CssClass="benutzernrlbl"></asp:Label>
                    <dx:ASPxComboBox ID="ddlHolidayCalendarNumber" ClientInstanceName="ddlHolidayCalendarNumber" runat="server" ValueType="System.String"  ValueField="Id"  Theme="Office2003Blue"  TextField="HolidayCalendarNumber" EnableCallbackMode="true" OnCallback="ddlHolidayCalendarNumber_Callback"  CssClass="benutzernr"  Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"  TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px" >
                        <Columns>
                            <dx:ListBoxColumn FieldName="HolidayCalendarNumber" Caption="<%$ Resources:localizedText, no2 %>" Name="ProfileDescription" ToolTip="Nr." Width="20%" />
                            <dx:ListBoxColumn FieldName="HolidayCalendarName" Caption="<%$ Resources:localizedText, description1 %>" Name="" ToolTip="Bezeichnung:" Width="80%" />
                        </Columns>
<ClientSideEvents SelectedIndexChanged="function(s, e) {
CalendarNumberSelectionChanged(s,e);	
}"
                            DropDown="function(s, e) {
isDropDownClick(s,e);	
}"></ClientSideEvents>
                    </dx:ASPxComboBox>  
                </section>
                <section class="contentdivtop1right">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="benutzernrlbl2"></asp:Label>
                     <dx:ASPxComboBox ID="ddlHolidayCalendarName" ClientInstanceName="ddlHolidayCalendarName" runat="server" ValueField="ID" TextField="HolidayCalendarName"  EnableCallbackMode="true" OnCallback="ddlHolidayCalendarName_Callback"  Theme="Office2003Blue" CssClass="benutzernr2"  Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px">
                         <Columns>
                            <dx:ListBoxColumn FieldName="HolidayCalendarNumber" Caption="<%$ Resources:localizedText, no2 %>" Name="ProfileDescription" ToolTip="Nr." Width="20%" />
                            <dx:ListBoxColumn FieldName="HolidayCalendarName" Caption="<%$ Resources:localizedText, description1 %>" Name="" ToolTip="Bezeichnung:" Width="80%" />
                        </Columns>
                         <ClientSideEvents SelectedIndexChanged="function(s, e) {
CalendarNameSelectionChanged(s,e);	
}"
                            DropDown="function(s, e) {
isDropDownClick(s,e);	
}"></ClientSideEvents>
                     </dx:ASPxComboBox> 
                </section>
                <section class="contentdivtop1rightnew1">
                     <section class="contentdivtop1rightnewcalender">
                        <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, year1 %>" CssClass="lblyear"></asp:Label>
                        <section class="sec2">
                            <section class="griddatemover">
                                <section class="griddatemoverleft">
                                    <asp:Button ID="btnCalendarYearPrevious" runat="server" Text="" 
                                         CssClass="korbtnFvNavPrevNr" />
                                </section>
                                <section class="griddatemovercenter">
                                    <dx:ASPxComboBox runat="server" ID="ddlCalendarYear2Old" ClientIDMode="Static"  ClientInstanceName="ddlCalendarYear2Old" Theme="Aqua" ValueType="System.String"  CssClass="ddlYearStyle2" Style="min-width: 100%;" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
CalendarYearSelectionChanged(s,e);
}"></ClientSideEvents>
                                    </dx:ASPxComboBox>

                                    <dx:ASPxComboBox runat="server" ID="ddlCalendarYear2" ClientIDMode="Static" ClientInstanceName="ddlCalendarYear2" Theme="Aqua" ValueType="System.String" CssClass="ddlYearStyle2New" Style="min-width: 100%;"  Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"></dx:ASPxComboBox>

                                </section>
                                <section class="btnNext">
                                    <asp:Button ID="btnCalendarYearNext" runat="server" Text=""  CssClass="korbtnFvNavNexNrt" />
                                </section>
                            </section>
                        </section>
                    </section>
                    <section class="empFormViewNavnew resize" >
                           
                        <section class="fvNavSearch" style="margin-left: 8px; width: 75px;">
                            <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                            <asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchAllEmpnew" style="background-size:contain;" />
                        </section>
                    </section>
                
                </section>
            </section>
            <section class="contentdivtop2">
                <section class="contentdivtop1leftnew">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,holidayCalendarNo2%>" CssClass="benutzernrlbl"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarNumber" runat="server" CssClass="benutzernr22" onkeypress="return IsNumber(event)"></asp:TextBox>
                </section>
                <section class="contentdivtop1rightnew">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="benutzernrlbl2"></asp:Label>
                    <asp:TextBox ID="txtHolidayCalendarName" runat="server" CssClass="benutzernr22bez"></asp:TextBox>
                </section>
                <section class="secYearAndFederalState">
                    
                    <section class="bundeland">
                        <asp:Label ID="lblRegionState" runat="server" Text="<%$ Resources:localizedText, federalstate1 %>" CssClass="lblFederalState"></asp:Label>
                        <dx:ASPxComboBox ID="ddlRegionID" runat="server" CssClass="cboFederalState" Theme="Office2003Blue" ValueType="System.String" OnSelectedIndexChanged="ddlRegionID_SelectedIndexChanged"  Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownRows="20">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlRegionIDSelectionChanged(s,e);	
}"></ClientSideEvents>
                            <Items>
                                <dx:ListEditItem Text="keine" Value="0" Selected="True" />
                                <dx:ListEditItem Text="Baden-Württemberg (BW)" Value="1" />
                                <dx:ListEditItem Text="Bayern (BY)" Value="2" />
                                <dx:ListEditItem Text="Berlin (BE)" Value="3" />
                                <dx:ListEditItem Text="Brandenburg (BB)" Value="4" />
                                <dx:ListEditItem Text="Bremen (HB)" Value="5" />
                                <dx:ListEditItem Text="Hamburg (HH)" Value="6" />
                                <dx:ListEditItem Text="Hesseh (HE)" Value="7" />
                                <dx:ListEditItem Text="Mecklenburg-Vorpommern (MV)" Value="8" />
                                <dx:ListEditItem Text="Niedersachsen (NI)" Value="9" />
                                <dx:ListEditItem Text="Nordrhein-Westfalen (NW)" Value="10" />
                                <dx:ListEditItem Text="Rheinland-Pfalz (RP)" Value="11" />
                                <dx:ListEditItem Text="Saarland (SL)" Value="12" />
                                <dx:ListEditItem Text="Sachsen (SN)" Value="13" />
                                <dx:ListEditItem Text="Sachsen-Anhalt (ST)" Value="14" />
                                <dx:ListEditItem Text="Schleswig-Holstein (SH)" Value="15" />
                                <dx:ListEditItem Text="Thüringen (TH)" Value="16" />
                            </Items>
                        </dx:ASPxComboBox>
                    </section>
                </section>
            </section>
        </section>

        <div id="importantInfoDialog" class="dialogBox">
        </div>

        <section class="contentdivbottom">
            <section class="contentdivbottomleft">
                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText,eventCalendar1 %>" CssClass="lblcaltitle"></asp:Label>
                <section id="sectionCalendar" class="contentdivbottomlefttop">                  
                    <dx:ASPxGridView ID="gridViewHolidayCalendar" ClientInstanceName="gridViewHolidayCalendar" runat="server" Theme="Office2003Blue" Width="100%"
                        EnableCallBacks="true" OnHtmlDataCellPrepared="gridViewHolidayCalendar_OnHtmlDataCellPrepared" OnCustomCallback="gridViewHolidayCalendar_OnCustomCallback" >
                        <ClientSideEvents EndCallback="function(s, e) {
gridViewHolidayCalendarEndCallBack(s,e);	
}"></ClientSideEvents>
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
                <section class="contentdivbottomleftbottom">
                    <section class="memotext">
                        <asp:Label ID="Label5" runat="server" Text="Memo Text:" CssClass="memotexttop"></asp:Label>
                        <asp:TextBox ID="txtMemo" runat="server" CssClass="memotextbottom" TextMode="MultiLine"></asp:TextBox>
                    </section>
                    <section class="labal">
                        <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText,applyHoliday%>" CssClass="lbltitlenew"></asp:Label>
                        <section class="labal1">
                            <section class="labal1left">
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText,takeHolidaysFromInternet%>"></asp:Label>
                            </section>
                            <section class="labal1right">
                                <asp:Button ID="btnInternet" runat="server" Text="Internet" CssClass="newstandardbutton btnInternet" />
                            </section>
                        </section>
                        <section class="labal2">
                            <section class="labal1left">
                                <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText,applyHoliday1 %>" CssClass="lblApply"></asp:Label>
                            </section>
                            <section class="labal1right">
                                <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText,takeover%>" CssClass="BottomFooterBtnsLeftnew applybtnfooterorange" />
                                <%--<asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText,takeover%>" CssClass="ubernahme" />--%>
                            </section>
                        </section>
                    </section>
                </section>
            </section>
            <section class="contentdivbottomright">
                <section class="contentdivbottomrightgrid ">
                    <section id="secGridButtons" class="gridButtonsControls">
                        <%--<section class="secRight"> </section>--%>
                        <asp:Button ID="btnAssigned" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, assignedholiday %>" CssClass="btnAssigned btnAll" />
                        <asp:Button ID="btnAll" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, allholidays %>" CssClass="btnRightAgnl" />
                    </section>
                    <section id="sectionHolidaysInCalendar" class="gridSectionTop">
                        <dx:ASPxGridView ID="gridViewHolidaysInCalendar" ClientInstanceName="gridViewHolidaysInCalendar" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" KeyFieldName="Id" OnDataBound="gridViewHolidaysInCalendar_OnDataBound" OnCustomCallback="gridViewHolidaysInCalendar_OnCustomCallback" EnableCallBacks="true">
                           <ClientSideEvents SelectionChanged="gridViewHolidaysInCalendarSelectionChanged" RowClick="gridViewHolidaysInCalendarRowClick" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Visible="False" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, holidaySpecialDay1 %>" FieldName="HolidayName" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$ Resources:localizedText, dateTitle %>" FieldName="HolidayDate">
                                    <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                                    </PropertiesDateEdit>
                                    <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, selectionTitle %>" ShowSelectCheckbox="True" ShowClearFilterButton="True" SelectAllCheckboxMode="AllPages" VisibleIndex="3">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <Styles>
                                <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                            </Styles>
                            <SettingsPager PageSize="16" ShowEmptyDataRows="True" Visible="False">
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="False" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                        </dx:ASPxGridView>
                    </section>
                    
                    <section id="sectionAllHolidays" class="sectionAll" style="display: none;">
                        <dx:ASPxGridView ID="gridViewHoliday" ClientInstanceName="gridViewHoliday" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%"
                            KeyFieldName="Id" OnDataBound="gridViewHoliday_OnDataBound" OnCustomCallback="gridViewHoliday_OnCustomCallback"  EnableCallBacks="true">
                            <ClientSideEvents SelectionChanged="gridViewHolidaySelectionChanged" RowClick="gridViewHolidayRowClick" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Visible="False" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, holidaySpecialDay1 %>" FieldName="HolidayName" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$ Resources:localizedText, dateTitle %>" FieldName="HolidayDate">
                                    <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                                    </PropertiesDateEdit>
                                    <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, selection%>" ShowSelectCheckbox="True" ShowClearFilterButton="True" SelectAllCheckboxMode="AllPages" VisibleIndex="3">
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <Styles>
                                <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                            </Styles>
                            <SettingsPager PageSize="12" ShowEmptyDataRows="True" Visible="False" Mode="ShowAllRecords">
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="False" AllowSort="false" AllowDragDrop="false"></SettingsBehavior>
                        </dx:ASPxGridView>
                    </section>
                    
                </section>
                <section id="sectionHolidayEdit"  class="gridSectionControls">
                        <asp:Label ID="lblHoliday" runat="server" Text="<%$ Resources:localizedText, publicholiday %>" CssClass="lblHldy"></asp:Label>
                        <asp:TextBox ID="txtHolidayName" runat="server" CssClass="txtHldy" ClientIDMode="Static"></asp:TextBox>
                        <asp:Label ID="lblDate" runat="server" Text="<%$ Resources:localizedText, date2 %>" CssClass="lblDt"></asp:Label>
                         
                        <dx:ASPxDateEdit ID="datePickerHolidayDate" ClientInstanceName="datePickerHolidayDate" Theme="Office2003Blue" runat="server" CssClass="dteEdit" DisplayFormatString="dd.MM.yyyy">
                            <ClientSideEvents DateChanged="datePickerHolidayDateChanged" />
                        </dx:ASPxDateEdit>
                    </section>
                <section class="contentdivbottomrightbutton ">
                    <asp:Button ID="btnHolidayNew" CssClass="BottomFooterBtnsLeftnewh btnNew"  runat="server" Text="<%$ Resources:localizedText, newholiday %>" />
                    <asp:Button ID="btnHolidaySave" CssClass="BottomFooterBtnsLeftnewh1 btnSave" runat="server" Text="<%$ Resources:localizedText, saveholiday %>" />
                    <asp:Button ID="btnHolidayDelete" CssClass="BottomFooterBtnsLeftnewh2 btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteholiday %>" ClientIDMode="Static" />

                </section>
            </section>
        </section>
        <section class="contentdivbottomsearch" style="display: none">
            <dx:ASPxGridView ID="gridViewHolidayCalendarSerch" runat="server" ClientInstanceName="gridViewHolidayCalendarSerch" AutoGenerateColumns="False" Theme="Office2003Blue" SettingsPager-PageSize="17" SettingsPager-ShowEmptyDataRows="True" Width="100%" KeyFieldName="Id"  EnableCallBacks="true" OnCustomCallback="gridViewHolidayCalendarSerch_CustomCallback">
                <ClientSideEvents RowDblClick="function(s, e) {
calendarSearchRowDbClick(s,e);	
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="Id" VisibleIndex="0" Visible="false" FieldName="Id"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, holidayCalendarNo %>" VisibleIndex="1" FieldName="HolidayCalendarNumber" Width="20%">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description %>" VisibleIndex="2" FieldName="HolidayCalendarName" Width="78%"></dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" ProcessFocusedRowChangedOnServer="true" AllowSort="false" AllowDragDrop="false" />
            </dx:ASPxGridView>
             <asp:Button ID="btnApplySelectedHoliday" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, accept %>" CssClass="btnApplyCalendar" Style="float:right;" />
        </section>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
      <asp:Button ID="btnCalendarNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newholidaycal %>"   Style="width: 146px;" />
    <asp:Button ID="btnCalendarSave" ClientIDMode="Static" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveholidaycal %>"  Style="width:180px;" />
    <asp:Button ID="btnCalendarDelete" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteholidaycal %>" Style="width: 170px;" />
    <asp:Button ID="btnCopyCalendar" CssClass="editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, copyholidaycal %>" Style="width: 180px;"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
     <div id="internetWrapper">
        <section class="titleText">
            <asp:Label runat="server" Text="<%$ Resources:localizedText, loadholidaysfrominternet%>"></asp:Label>
        </section>
        <section class="internetarea1">
            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, federalstate %>" CssClass="lbltoparea"></asp:Label>
            <asp:DropDownList ID="drpCountry" runat="server" CssClass="drpland" AutoPostBack="false">
                <asp:ListItem Text="keine" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Baden-Württemberg (BW)" Value="1"></asp:ListItem>
                <asp:ListItem Text="Bayern (BY)" Value="2"></asp:ListItem>
                <asp:ListItem Text="Berlin (BE)" Value="3"></asp:ListItem>
                <asp:ListItem Text="Brandenburg (BB)" Value="4"></asp:ListItem>
                <asp:ListItem Text="Bremen (HB)" Value="5"></asp:ListItem>
                <asp:ListItem Text="Hamburg (HH)" Value="6"></asp:ListItem>
                <asp:ListItem Text="Hessen (HE)" Value="7"></asp:ListItem>
                <asp:ListItem Text="Mecklenburg-Vorpommern (MV)" Value="8"></asp:ListItem>
                <asp:ListItem Text="Niedersachsen (NI)" Value="9"></asp:ListItem>
                <asp:ListItem Text="Nordrhein-Westfalen (NW)" Value="10"></asp:ListItem>
                <asp:ListItem Text="Rheinland-Pfalz (RP)" Value="11"></asp:ListItem>
                <asp:ListItem Text="Saarland (SL)" Value="12"></asp:ListItem>
                <asp:ListItem Text="Sachsen (SN)" Value="13"></asp:ListItem>
                <asp:ListItem Text="Sachsen-Anhalt (ST)" Value="14"></asp:ListItem>
                <asp:ListItem Text="Schleswig-Holstein (SH)" Value="15"></asp:ListItem>
                <asp:ListItem Text="Thüringen (TH)" Value="16"></asp:ListItem>
            </asp:DropDownList>
        </section>
        <section class="internetarea2">
            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, year%>" CssClass="lbltoparea"></asp:Label>
            <dx:ASPxComboBox runat="server" ID="ddlYear" ClientInstanceName="ddlYear" Theme="Aqua" ValueType="System.String" AutoPostBack="false" CssClass="ddlYear" />
        </section>
        <section class="internetarea3">
            <asp:Button ID="btnDownloadHolidays" runat="server" Text="<%$ Resources:localizedText, downloadholiday %>" CssClass="savebtnfootergreen btnbottom123"  />
            <asp:Button ID="btnDeleteHolidays" runat="server" Text="<%$ Resources:localizedText, delete %>" CssClass="backbtnfooterred btnbottom123" Style="width: 59px;" />
            <asp:Button ID="Button3" runat="server" Text="<%$ Resources:localizedText, decline%>" CssClass="backbtnfooterred btnbottom123"  Style="width: 66px;" />
        </section>
    </div>
</asp:Content>
