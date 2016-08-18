<%@ Page Title="Zutrittsgruppen - Feiertagsplan" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessGroupHolidaySchedule.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessGroupHolidaySchedule" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessGroupHolidaySchedule.js"></script>
    <link href="Styles/AccessGroupHolidaySchedule.css" rel="stylesheet" />
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
     <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldConfirmDialog" runat="server" />
    <asp:HiddenField ID="hiddenFieldCalendarYear" runat="server" />
     <section class="contentdiv">
        <div class="topsectiondivNew">
            <section class="topdivNew">
                <div id="ControlSecarea" class="ControlSecarea1New">
                   
                    <div class="ControlSecarea3">
                        <section class="leftDvns">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, accessplangroupinfo %>" CssClass="Gruppen1"></asp:Label>
                            <asp:TextBox ID="txtAccessGroupNumber" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppen2"></asp:TextBox>
                            <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="Gruppen3"></asp:Label>
                            <asp:TextBox ID="txtAccessGroupName" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppen4"></asp:TextBox>
                            <asp:TextBox ID="txtAccessGroupId" Style="display:none;" runat="server"></asp:TextBox>
                        </section>
                        <section class="rightDvns">
                            <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2" ></asp:Button>
                            <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                            <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="newstandardbutton Zutrittsprofilbutton2"></asp:Button>
                            <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                            <asp:Button ID="btnHoliday" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="newstandardbutton Zutrittsprofilbutton2holiday" Enabled="false"></asp:Button>
                            <asp:ImageButton ID="btnInformation" CssClass="btnInfo" runat="server"  />
                        </section>
                    </div>
                </div>
                
            </section>
            

        </div>
         <div class="MidContentAreaDiv">
         <section class="topdivbtmnew9">
             <div class="topdivtop">
                    <section class="topdivbtmnewleft ">
                        
                    <section class="secDrpDwn1">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, holidayPlanNo2%>" CssClass="lblnr015"></asp:Label>
                        <dx:ASPxComboBox ID="ddlHolidayPlanCalendarNumber" ClientInstanceName="ddlHolidayPlanCalendarNumber" ValueField="Id" TextField="HolidayPlanCalendarNumber" EnableCallbackMode="true" OnCallback="ddlHolidayPlanCalendarNumber_Callback" runat="server" Theme="Office2003Blue" TextFormatString="{0}" DropDownRows="6" DropDownWidth="400px" CssClass="txtbox015">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
PlanNumberSelectedIndexChanged(s,e);	
}"
                                DropDown="function(s, e) {
dplPlanClicked(s,e);	
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="Nr:" Name="HolidayPlanCalendarNumber" FieldName="HolidayPlanCalendarNumber" Width="10%" />
                                <dx:ListBoxColumn Caption ="<%$ Resources:localizedText, description1 %>" Name="HolidayPlanCalendarName" FieldName="HolidayPlanCalendarName" Width="90%" />
                            </Columns>
                        </dx:ASPxComboBox>
                           
                        </section>
                        <section class="secDrpDwn2">
                            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblnr1Hldy015"></asp:Label>
                            <dx:ASPxComboBox ID="ddlHolidayPlanCalendarName" ClientInstanceName="ddlHolidayPlanCalendarName" ValueField="Id" TextField="HolidayPlanCalendarName" EnableCallbackMode="true" OnCallback="ddlHolidayPlanCalendarName_Callback" runat="server" Theme="Office2003Blue" TextFormatString="{1}" DropDownRows="6" DropDownWidth="400px" CssClass="drpDscrption015">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
PlanNameSelectedIndexChanged(s,e);	
}"
                                    DropDown="function(s, e) {
dplPlanClicked(s,e);	
}"></ClientSideEvents>
                                 <Columns>
                                <dx:ListBoxColumn Caption="Nr:" Name="HolidayPlanCalendarNumber" FieldName="HolidayPlanCalendarNumber" Width="10%" />
                                <dx:ListBoxColumn Caption ="<%$ Resources:localizedText, description1 %>" Name="HolidayPlanCalendarName" FieldName="HolidayPlanCalendarName" Width="90%" />
                            </Columns>
                            </dx:ASPxComboBox>
                        </section>
                 
                       </section>
                       <section class="topdivbtmnewright">
                        <section class="dateSelection">
                            <section class="sec3">
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, year %>" CssClass="lblYear3"></asp:Label>
                                <section class="griddatemover1">
                                    <section class="griddatemoverleft">
                                        <asp:Button ID="btnCalendarYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                    </section>
                                    <section class="griddatemovercenter">
                                        <asp:DropDownList ID="ddlCalendarYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%; display: none;" CssClass="ddlYearStyle"></asp:DropDownList>
                                        <dx:ASPxComboBox runat="server" ID="ddlCalendarYear2" ClientInstanceName="ddlCalendarYear2"  Theme="Aqua" ValueType="System.String" CssClass="ddlYearStyle2" Style="min-width: 100%;"></dx:ASPxComboBox>
                                    </section>
                                    <section class="griddatemoverright">
                                        <asp:Button ID="btnCalendarYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt2new" />
                                    </section>
                                </section>
                            </section>
                            <asp:Button ID="Search" runat="server" Text="" CssClass="searchzutarea" Style="display: none" />
                        </section>
                        <%--<section class="contentdivtop1rightnewcalender">
                     </section>--%>
                    </section>
                 </div>
               <div class="topdivbottom">
                   <section class="secLeftTxtBx">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, holidayPlanNo2%>" CssClass="lblKlndrNr"></asp:Label>
                            <asp:TextBox ID="txtHolidayPlanCalendarNumber" runat="server" CssClass="txtKlndrNr" onkeypress="return IsNumber(event)"></asp:TextBox>
                        </section>
                        <section class="secLeftTxtBx2">
                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, description1%>" CssClass="lblKlndrNr015"></asp:Label>
                            <asp:TextBox ID="txtHolidayPlanCalendarName" runat="server" CssClass="txtKlndrNr2"></asp:TextBox>
                        </section>
                    <section class="drpDwn3">
                            <asp:Label ID="Label9" runat="server" Text="Feiertagskalender Nr.:" CssClass="lblHldyClndr015"></asp:Label>
                        <dx:ASPxComboBox ID="ddlHolidayCalendarNumber" runat="server" CssClass="drpHldyClndr015" ValueField="Id" TextField="HolidayCalendarNumber"
                            DropDownRows="6" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{0}" Theme="Office2003Blue">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
HolidaySelectedChanged(s,e);
}"></ClientSideEvents>
                            <Columns>
                                    <dx:ListBoxColumn Caption="Nr:" FieldName="HolidayCalendarNumber" Name="HolidayCalendarNumber" ToolTip="<%$ Resources:localizedText, holidayCalendarNo2 %>" Width="10%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="HolidayCalendarName" Name="HolidayCalendarName" ToolTip="<%$ Resources:localizedText, description1 %>" Width="90%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
                        <section class="drpDwn4">
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, description1%>" CssClass="lblHldyClndr2new"></asp:Label>
                           
                            <dx:ASPxComboBox ID="ddlHolidayCalendarName" runat="server" CssClass="drpHldyClndr2new" ValueField="Id" TextField="HolidayCalendarName" 
                                DropDownRows="6" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{1}"
                                IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue" ValueType="System.String">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
HolidaySelectedChanged(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn Caption="Nr" FieldName="HolidayCalendarNumber" Name="HolidayCalendarNumber" ToolTip="<%$ Resources:localizedText, holidayCalendarNo2 %>" Width="10%" />
                                    <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="HolidayCalendarName" Name="HolidayCalendarName" ToolTip="<%$ Resources:localizedText, description1 %>" Width="90%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>
               </div>
                </section>
             
        <section class="contentdivbottomNew">
            <section class="contentdivbottomleft">
                <section class="contentdivbottomlefttop">
                    <dx:ASPxGridView ID="gridViewHolidayPlanCalendar" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" ClientInstanceName="gridViewHolidayPlanCalendar" EnableCallBacks="true" OnCustomCallback="gridViewHolidayPlanCalendar_CustomCallback" KeyFieldName="Id" runat="server" AutoGenerateColumns="False"
                        Theme="Office2003Blue" Width="100%" OnHtmlDataCellPrepared="gridViewHolidayPlanCalendar_OnHtmlDataCellPrepared" >
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
                        <SettingsPager PageSize="12" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </section>
                <section class="contentdivbottomleftbottom">
                    <section class="memotext">
                        <asp:Label ID="Label5" runat="server" Text="Memo Text" CssClass="memotexttop"></asp:Label>
                        <asp:TextBox ID="txtMemo" runat="server" CssClass="memotextbottom" TextMode="MultiLine"></asp:TextBox>
                    </section>
                    <section class="labal">
                        <section class="generelle">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, generalSettingsAndProfileAssignment %>"></asp:Label>
                        </section>
                        <section class="labal1">
                            <section class="labal1left">
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, holidaysNoAccess %>" CssClass="lblCheck"></asp:Label>
                                <asp:CheckBox ID="chkDenyAccess" runat="server" CssClass="checkleft" />
                            </section>
                            <section class="labal1right">
                                <asp:Label ID="Label11" runat="server" CssClass="lblAskj" Text="<%$ Resources:localizedText, holidayPermit %>"></asp:Label>
                                <asp:CheckBox ID="chkAllowAccess" runat="server" CssClass="chkBoxLeft" />
                            </section>
                        </section>
                        <section class="labal2">
                            <section class="labaltop">
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, accessProfile %>" CssClass="Accessno"></asp:Label>
                                <%-- <asp:DropDownList ID="ddlAccessProfileNumber" runat="server" DataValueField="ID" DataTextField="AccessProfileNo" CssClass="txtProfil1"></asp:DropDownList>--%>
                                 <asp:DropDownList ID="dplAccessProfileMemo" runat="server" DataValueField="ID" DataTextField="Memo" style="display:none;" />
                                <dx:ASPxComboBox ID="ddlAccessProfileNumber" runat="server" CssClass="txtProfil1" ValueField="ID" TextField="AccessDescription"
                                    DropDownRows="6" DropDownWidth="600px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{2}"
                                    IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue" ValueType="System.String">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());
}" />
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Gr. Profil Nr." FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="Gr. Profil Nr." Width="18%" />
                                        <dx:ListBoxColumn Caption="Gr. Bezeichnung" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="Gr. Bezeichnung" Width="42%" />
                                        <dx:ListBoxColumn Caption="Profil Nr." FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="Profil Nr." Width="18%" />
                                        <dx:ListBoxColumn Caption="Profil Bezeichnung" FieldName="AccessDescription" Name="AccessDescription" ToolTip="Profil Bezeichnung" Width="42%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, description %>" CssClass="Accessno1"></asp:Label>
                                <dx:ASPxComboBox ID="ddlAccessProfileName" runat="server" ValueType="System.String" CssClass="txtProfil" ValueField="ID" TextField="AccessDescription"
                                    DropDownRows="6" DropDownWidth="600px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{3}"
                                    IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());	
}" />
                                    <Columns>
                                        <dx:ListBoxColumn Caption="Gr. Profil Nr." FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="Gr. Profil Nr." Width="18%" />
                                        <dx:ListBoxColumn Caption="Gr. Bezeichnung" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="Gr. Bezeichnung" Width="42%" />
                                        <dx:ListBoxColumn Caption="Profil Nr." FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="Profil Nr." Width="18%" />
                                        <dx:ListBoxColumn Caption="Profil Bezeichnung" FieldName="AccessDescription" Name="AccessDescription" ToolTip="Profil Bezeichnung" Width="42%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, profileId %>" CssClass="Accessno2"></asp:Label>
                                <dx:ASPxComboBox ID="ddlAccessProfileIdNumber" ClientInstanceName="ddlAccessProfileIdNumber" ValueField="ID" TextField="AccessProfileID" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="ddlProfil2id1">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());	
}" />
                                </dx:ASPxComboBox>
                                
                            </section>
                            <section class="lblSec3">
                                <asp:Button ID="btnSearchAccessProfile" runat="server" Text="" CssClass="searchfltright2" Width="25px" Height="25px" BackColor="White" Style="border-radius: 5px; margin-top: 2px;" />
                                <asp:Button ID="btnSearchProfiles" ClientIDMode="Static" runat="server" Text="" CssClass="SearchProfilebtn" />
                              

                            </section>
                            <section class="labal2btm">
                                <section class="hldrOne">
                                    <asp:Button ID="btnNewAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessProfile1 %>" CssClass="mapbtns1BtnsRight2 newbtnfooterblue" OnClick="btnNewAccessProfile_Click" />
                                </section>
                                <section class="hldrTwo">
                                    <section class="bis" style="display: none">
                                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblJahr"></asp:Label>
                                    </section>
                                    <section class="center">
                                        <section class="griddatemover4" style="display: none">
                                            <section class="griddatemoverleft">
                                                <asp:Button ID="btnDateToPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                            </section>
                                            <section class="griddatemovercenter">
                                                <dx:ASPxDateEdit ID="datePickerDateFrom" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                                 <%--   <ClientSideEvents DateChanged="DateFromChanged" />--%>
                                                </dx:ASPxDateEdit>
                                            </section>
                                            <section class="griddatemoverright">
                                                <asp:Button ID="btnDateToNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                            </section>
                                        </section>
                                    </section>
                                </section>
                                <section class="hldrThree">
                                    <section class="von1" style="display: none">
                                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, from %>" CssClass="lblJahr"></asp:Label>
                                    </section>
                                    <section class="last">
                                        <section class="griddatemover3" style="display: none">
                                            <section class="griddatemoverleft">
                                                <asp:Button ID="btnDateFromPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                            </section>
                                            <section class="griddatemovercenter">
                                                <dx:ASPxDateEdit ID="datePickerDateTo" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                                  <%--  <ClientSideEvents DateChanged="DateToChaged" />--%>
                                                </dx:ASPxDateEdit>
                                            </section>
                                            <section class="griddatemoverright">
                                                <asp:Button ID="btnDateFromNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                            </section>
                                        </section>
                                    </section>
                                </section>
                                <section class="hldrFour">
                                    <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText,takeover%>" CssClass="editbtnfooterorange" style="margin-top:10px; float:right; width:87px;" />
                                </section>
                            </section>
                        </section>
                    </section>
                </section>
            </section>
            <section class="contentdivbottomright">
                <section class="contentdivbottomrightgrid ">
                    <dx:ASPxGridView ID="gridViewHoliday" SettingsBehavior-AllowSort="false" ClientInstanceName="gridViewHoliday" OnCustomCallback="gridViewHoliday_CustomCallback" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%"
                        KeyFieldName="Id" OnDataBound="gridViewHoliday_OnDataBound"  EnableCallBacks="True">
                        <ClientSideEvents SelectionChanged="gridViewHolidaySelectionChanged" Init="function(s, e) {
	getSelectedOptions(s,e);
}"
                            RowDblClick="function(s, e) { gridViewHolidayRowDbClick(s,e) }" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="32%" Caption="<%$ Resources:localizedText, holidaySpecialDay_new %>" FieldName="HolidayName" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn Width="30%" VisibleIndex="2" Caption="<%$ Resources:localizedText, dates %>" FieldName="HolidayDate">
                                <EditFormSettings Visible="False" />
                                <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                                </PropertiesDateEdit>
                                <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataCheckColumn Width="4%" Caption="<%$ Resources:localizedText, selection%>" FieldName="IsSelected" ReadOnly="true" VisibleIndex="3">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataCheckColumn>
                            <%-- <dx:GridViewCommandColumn Width="4%" Caption="Profil" ShowSelectCheckbox="True" ShowClearFilterButton="True" VisibleIndex="4" />--%>
                            <dx:GridViewDataCheckColumn Caption="Profil" FieldName="AccessProfile" VisibleIndex="4"></dx:GridViewDataCheckColumn>
                        </Columns>
                        <Styles>
                            <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                        </Styles>
                        <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowDragDrop="false"></SettingsBehavior>
                        <SettingsPager PageSize="18" ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                        <SettingsEditing Mode="Batch">
                            <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                        </SettingsEditing>
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="True" AllowInsert="False" />
                        <Settings ShowStatusBar="Hidden" />
                    </dx:ASPxGridView>
                </section>
                <section class="clearselection">
                    <asp:Button ID="btnRemoveSelected" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, clearselection%>" CssClass="btnclear deletebtnfooterred" />
                </section>
                <section class="contentdivbottomrightbutton " style="display: none;">
                    <section class="leftOne"></section>
                    <section class="rightOne">
                        <asp:Button ID="btnSelectAll" CssClass="BottomFooterBtnsLeftnewselect btnAll" runat="server" Text="<%$ Resources:localizedText, all %>" />
                        <asp:Button ID="btnDeselectAll" CssClass="BottomFooterBtnsLeftnewHldy btnSelect" runat="server" Text="<%$ Resources:localizedText, unselect%>" />
                    </section>

                </section>
            </section>

            <%-- section for Access Profiles --%>
            <section class="tblAccessProfiles" style="display: none;">
                <section class="sectionGridsd">
                    <asp:Table runat="server" ID="tableHeader" CssClass="tableRowMainnew" CellPadding="0" CellSpacing="0">
                        <asp:TableHeaderRow CssClass="tableRownew">
                            <asp:TableCell CssClass="tableCell1">
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText,activeProfile %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCellmdf">
                                <asp:Label ID="Label31" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                            </asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <dx:ASPxGridView ID="grdZuttritProfileTimeFrames" runat="server"  AutoGenerateColumns="False" UseDisabledStatePainter="false" SettingsBehavior-AllowSort="false" Theme="Office2003Blue"
                        CssClass="grid" Width="100%" ClientInstanceName="grdZuttritProfileTimeFrames" OnCustomCallback="grdZuttritProfileTimeFrames_CustomCallback"  EnableCallBacks="true" KeyFieldName="ID" ForeColor="Black">
                        <Columns>
                            <dx:GridViewDataCheckColumn VisibleIndex="4" Caption="<%$ Resources:localizedText,all %>" Width="9.5%" FieldName="ProfilAktiv">
                                <PropertiesCheckEdit EnableClientSideAPI="True">
                                </PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="MonFrom" VisibleIndex="6" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm" EnableFocusedStyle="False">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="MonTo" VisibleIndex="8" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="TueFrom" VisibleIndex="10" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="TueTo" VisibleIndex="12" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="WedFrom" VisibleIndex="14" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="WedTo" VisibleIndex="16" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="ThurFrom" VisibleIndex="18" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="ThurTo" VisibleIndex="20" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="FriFrom" VisibleIndex="22" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="FriTo" VisibleIndex="24" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="SatFrom" VisibleIndex="26" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="SatTo" VisibleIndex="28" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="SunFrom" VisibleIndex="30" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="SunTo" VisibleIndex="31" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" AllowDragDrop="false" />
                        <SettingsPager ShowEmptyDataRows="True" Visible="False">
                        </SettingsPager>
                        <SettingsEditing EditFormColumnCount="20" Mode="Batch">
                            <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                        </SettingsEditing>
                        <Settings ShowStatusBar="Hidden" />
                        <SettingsDetail ShowDetailButtons="False" />
                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="False" />
                    </dx:ASPxGridView>
                </section>
                  <section class="sectionMemo">
                    <section class="secMemoHeader">
                        <asp:Label ID="lblMemo" runat="server" Text="<%$ Resources:localizedText,memo%>" CssClass="lblMemo"></asp:Label>
                    </section>
                    <section class="secMemo">
                        <asp:TextBox ID="txtAccessProfileMemo" runat="server" CssClass="txtMemo" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                    </section>
                </section>
            </section>
        </section>
        <div id="searchAccessProfile" class="accssProfls" style="display: none;">
            <dx:ASPxGridView ID="gridViewAccessProfileSearch" ClientInstanceName="gridViewAccessProfileSearch" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue"
                Width="100%" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="12px" KeyFieldName="ID">
                <ClientSideEvents RowClick="function(s, e) { gridViewAccessProfileRowClick(s, e); }" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nr%>" VisibleIndex="0" FieldName="AccessProfileNo" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                             <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idnew%>" VisibleIndex="0" FieldName="AccessProfileID" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description1%>" VisibleIndex="1" FieldName="AccessDescription" Width="76%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                <SettingsPager PageSize="17" ShowEmptyDataRows="True"></SettingsPager>
            </dx:ASPxGridView>

        </div>
             </div>
    </section>
    <div id="importantDialog" class="dialogBox"></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    
   
   

    <asp:Button ID="btnNewHolidayPlan" CssClass=" newbtnfooterblue" runat="server" Text="Feiertagsplan neu" Style="width:117px;" OnClick="btnNewHolidayPlan_Click"  />
    <asp:Button ID="btnSaveHolidayPlan" CssClass=" savebtnfootergreen" runat="server" Text="Feiertagsplan speichern" Style="width:152px;"  />
    <asp:Button ID="btnDeleteHolidayPlan" CssClass=" deletebtnfooterred" runat="server" Text="Feiertagsplan löschen" Style="width:148px;" />



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>

