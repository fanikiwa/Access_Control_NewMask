<%@ Page Title="Besucherpläne Zutrittskalender" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="VisitorPlanVisitorCalender.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorPlanVisitorCalender" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/VisitorPlanVisitorCalender.js"></script>
    <link href="Styles/VisitorPlanVisitorCalender.css" rel="stylesheet" />
    <link href="Styles/VisitorPlanVisitorCalender2.css" rel="stylesheet" />
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
       <div id="mainholder">
           <asp:HiddenField ID="hiddenFieldAccessCalendarId" runat="server" />
        <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />
        <asp:HiddenField ID="hiddenFieldDateFrom" runat="server" />
        <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
        <asp:HiddenField ID="hiddenFieldCalendarYear" runat="server" />
        <asp:HiddenField ID="hiddenFieldSearchValue" runat="server" />
        <div class="topsectiondiv">
               <section class="leftDvnsnewab">
                            <asp:Label runat="server" Text="<%$ Resources:localizedText,  visitorPlannumber %>" CssClass="planGruppenfnew"></asp:Label>
                            <asp:TextBox ID="txtVisitorPlanNumber" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppenfnew"></asp:TextBox>
                            <asp:Label runat="server" Text=" <%$ Resources:localizedText, description1 %>" CssClass="planGruppengtext"></asp:Label>
                            <asp:TextBox ID="txtVisitorPlanName" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppengcalendernew"></asp:TextBox>
                            <asp:TextBox ID="txtVisitorPlanId" Style="display:none" ClientIDMode="Static" runat="server"></asp:TextBox>
                        </section>
                        <section class="rightDvnsnewab">
                            <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="Leserbutton1newabcd" OnClick="btnReader_Click"></asp:Button>
                            <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                            <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" Enabled="false" CssClass="Zutrittsprofilbutton2newabcd"></asp:Button>
                        </section>

        </div>

        <div id="importantInfoDialog" class="dialogBox">
        </div>
        <div id="importantInfoDialogCustom" class="dialogBoxCustom">
        </div>
        <div class="MidContentAreaDiv">
        <div id="accessGroupDiv" class="bottomsectiondiv">
            
            <section class="topdiv">
                <section class="topdivtop">
                    <section class="leftTopContentAreaDiv" style="margin-top: 1px;">
                        <section class="secdivision">
                            <asp:Label ID="lblZusch" runat="server" CssClass="lblZuch" Text="<%$ Resources:localizedText, calendarNoTtl %>"></asp:Label>
                            
                             <dx:ASPxComboBox ID="dplCalendarNr" runat="server" CssClass="ddlistZusch" TextField="Calendar_Nr" ValueField="ID" EnableCallbackMode="true" OnCallback="dplCalendarNr_Callback" CallbackPageSize="100000" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{0}" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
calendarSelectedChanged(s,e);
}"
                                    DropDown="function(s, e) {
	DropDownClick(s,e);
}"
                                    EndCallback="function(s, e) {
dplCalendarNrEndCallBack(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Calendar_Nr" Caption="Nr." Width="20%" />
                                    <dx:ListBoxColumn FieldName="Calendar_Name" Caption="Bezeichnung" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="secdivisionNew">
                            <asp:Label ID="lblBesch" runat="server" CssClass="lblBesch" Text="<%$ Resources:localizedText, descriptionAccs %>"></asp:Label>
                            <dx:ASPxComboBox ID="dplCalendarName" runat="server" CssClass="ddlistBesch" TextField="Calendar_Name" ValueField="ID" EnableCallbackMode="true" OnCallback="dplCalendarName_Callback" CallbackPageSize="100000"  Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{1}" DropDownRows="20" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
calendarSelectedChanged(s,e);
}"
                                    DropDown="function(s, e) {
DropDownClick(s,e);	
}"
                                    EndCallback="function(s, e) {
	dplCalendarNameEndCallBack(s,e);
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="Calendar_Nr" Caption="Nr." Width="20%" />
                                    <dx:ListBoxColumn FieldName="Calendar_Name" Caption="Bezeichnung" Width="80%" />
                                </Columns>
                            </dx:ASPxComboBox>
                        </section>

                    </section>
                    <section class="rightTopContentAreaDiv">
                        <section class="secSearch">
                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, search %>" CssClass="lblSearchTitle"></asp:Label>
                            <asp:Button ID="btnSearchAllCalendars" runat="server" Text="" CssClass="searchfltrighte btnsrch" BorderStyle="None" Width="24px" Height="24px" BackColor="White" Style="border-radius: 5px; margin-top: 8px;" />
                        </section>
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, year %>" CssClass="lblyear"></asp:Label>
                        <section class="griddatemover2">
                            <section class="griddatemoverleft2">
                                <asp:Button ID="btnCalendarYearPrevious" runat="server" ClientIDMode="Static" CssClass="korbtnFvNavPrevNr2" />
                                <%--<asp:Button ID="btnCalendarYearPrevious" ClientIDMode="Static" runat="server" Text="" CssClass="korbtnFvNavPrevNr2" OnClick="btnCalendarYearPrevious_Click"/>--%>
                            </section>
                            <section class="griddatemovercenter2">
                                <asp:DropDownList ID="ddlCalendarYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%; display: none;" CssClass="ddlYearStyle"></asp:DropDownList>
                                <dx:ASPxComboBox runat="server" ID="ddlCalendarYear2" ClientIDMode="Static" Theme="Office2003Blue" ValueType="System.String" AutoPostBack="true" CssClass="ddlYearStyle2" Style="min-width: 100%;"></dx:ASPxComboBox>
                            </section>
                            <section class="griddatemoverright2">
                                <asp:Button ID="btnCalendarYearNext" ClientIDMode="Static" runat="server" Text="" CssClass="korbtnFvNavNexNrt2" />
                            </section>
                        </section>
                        <%--<asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchfltright" BorderStyle="None" Width="25px" Height="25px" BackColor="White" Style="border-radius: 5px; margin-top:8px;" />--%>
                    </section>
                </section>
                <section class="topdivbtm">
                    <section class="leftTopContentAreaDiv2">
                        <section class="secdivision">
                            <asp:Label ID="lblZusch2" runat="server" CssClass="lblZuch" Text="<%$ Resources:localizedText, calendarNoTtl %>"></asp:Label>
                            <asp:TextBox ID="txtCalendarNr" runat="server" CssClass="txtZusch"></asp:TextBox>
                        </section>
                        <section class="secdivisionNew">
                            <asp:Label ID="lblBesch2" runat="server" CssClass="lblBesch" Text="<%$ Resources:localizedText, descriptionAccs %>"></asp:Label>
                            <asp:TextBox ID="txtCalendarName" runat="server" CssClass="txtBesch"></asp:TextBox>
                        </section>
                    </section>
                    <section class="rightTopContentAreaDiv2">
                    
                    </section>
                </section>
            </section>
            <section class="bottomsectiondivNew">
                                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText, accessCalendar %>"  CssClass="lblHeader2"></asp:Label>
                <section class="bottomsectiondivleft1aTop">
                    <section class="table">
                        <dx:ASPxGridView ID="grdAccessCalendar" ClientInstanceName="grdAccessCalendar" OnHtmlDataCellPrepared="grdAccessCalendar_HtmlDataCellPrepared" OnCustomCallback="grdAccessCalendar_CustomCallback" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" KeyFieldName="ID"  EnableCallBacks="true">
                           <ClientSideEvents EndCallback="function(s, e) {
grdAccessCalendarEndCallBack(s,e);	
}"></ClientSideEvents> 
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="1" VisibleIndex="1" Visible="False" FieldName="ID">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, month %>" VisibleIndex="2" FieldName="MonthName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="1" VisibleIndex="3" FieldName="Day1AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="2" VisibleIndex="4" FieldName="Day2AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="3" VisibleIndex="5" FieldName="Day3AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="4" VisibleIndex="6" FieldName="Day4AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="5" VisibleIndex="7" FieldName="Day5AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="6" VisibleIndex="8" FieldName="Day6AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="7" VisibleIndex="9" FieldName="Day7AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="8" VisibleIndex="10" FieldName="Day8AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="9" VisibleIndex="11" FieldName="Day9AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="10" VisibleIndex="12" FieldName="Day10AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="11" VisibleIndex="13" FieldName="Day11AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="12" VisibleIndex="14" FieldName="Day12AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="13" VisibleIndex="15" FieldName="Day13AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="14" VisibleIndex="16" FieldName="Day14AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="15" VisibleIndex="17" FieldName="Day15AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="16" VisibleIndex="18" FieldName="Day16AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="17" VisibleIndex="19" FieldName="Day17AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="18" VisibleIndex="20" FieldName="Day18AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="19" VisibleIndex="21" FieldName="Day19AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="20" VisibleIndex="22" FieldName="Day20AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="21" VisibleIndex="23" FieldName="Day21AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="22" VisibleIndex="24" FieldName="Day22AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="23" VisibleIndex="25" FieldName="Day23AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="24" VisibleIndex="26" FieldName="Day24AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="25" VisibleIndex="27" FieldName="Day25AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="26" VisibleIndex="28" FieldName="Day26AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="27" VisibleIndex="29" FieldName="Day27AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="28" VisibleIndex="30" FieldName="Day28AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="29" VisibleIndex="31" FieldName="Day29AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="30" VisibleIndex="32" FieldName="Day30AccessProfile">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="31" VisibleIndex="33" FieldName="Day31AccessProfile">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="12" ShowEmptyDataRows="True">
                            </SettingsPager>
                            <SettingsBehavior AllowGroup="False" AllowSort="False" AllowDragDrop="False"></SettingsBehavior>
                            <Settings ShowStatusBar="Hidden" />
                            <SettingsDetail ShowDetailButtons="False" />
                        </dx:ASPxGridView>
                    </section>
                    <%-- <section class="uppersec">
                       <asp:Label ID="lblProc" runat="server" CssClass="lblMidsecnew" Text=""></asp:Label>
                    </section>
                        <section class="lowersecnew">
                            <section class="secZuschnew">
                               
                            </section>
                        </section>--%>
                </section>
                <section class="bottomsectiondivrightbBottom">
                    <section class="bottomsectiondivrightbBottomleft">
                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, Profileselection %>" CssClass="profillbl" Style="height: 29px;"></asp:Label>
                        <section id="sectionAccessProfile" class="bottomlblleft">
                            <section class="topContHolder">
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, accessProfile %>" CssClass="lblZuchnew" Style="display: none;"></asp:Label>
                                <%-- <asp:DropDownList ID="dplAccessProfileNr" runat="server" CssClass="ddlProfil2" DataValueField="ID" DataTextField="AccessProfileNo"></asp:DropDownList>--%>
                                <dx:ASPxComboBox ID="dplAccessProfileNr" runat="server" CssClass="ddlProfil2" ValueField="ID" TextField="AccessDescription"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{2}"
                                    IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue" ValueType="System.String">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());
}" />
                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupProfileNo %>" FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="<%$ Resources:localizedText, groupProfileNo %>" Width="21%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, grpDescription %>" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="<%$ Resources:localizedText, grpDescription %>" Width="40%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileNo %>" FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="<%$ Resources:localizedText, profileNo %>" Width="21%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileDescription %>" FieldName="AccessDescription" Name="AccessDescription" ToolTip="<%$ Resources:localizedText, profileDescription %>" Width="40%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblZuchnewmid"></asp:Label>
                                <asp:DropDownList ID="dplAccessProfileMemo" runat="server" DataValueField="ID" DataTextField="Memo" Style="display: none;" />
                                <dx:ASPxComboBox ID="dplAccessProfileName" runat="server" ValueType="System.String" CssClass="ddlProfil" ValueField="ID" TextField="AccessDescription"
                                    DropDownRows="20" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{3}"
                                    IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());	
}" />
                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupProfileNo %>" FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="<%$ Resources:localizedText, groupProfileNo %>" Width="21%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, grpDescription %>" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="<%$ Resources:localizedText, grpDescription %>" Width="40%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileNo %>" FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="<%$ Resources:localizedText, profileNo %>" Width="21%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileDescription %>" FieldName="AccessDescription" Name="AccessDescription" ToolTip="<%$ Resources:localizedText, profileDescription %>" Width="40%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <asp:Label ID="Label5" runat="server" Text="Profil ID:" CssClass="lblZuchnew1"></asp:Label>
                                <dx:ASPxComboBox ID="ddlProfileId" runat="server" CssClass="ddlProfil2id" ValueField="ID" TextField="AccessProfileID" ValueType="System.String" Theme="Office2003Blue"  DropDownRows="20" DropDownWidth="350px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{2}" IncrementalFilteringMode="Contains" SelectedIndex="0" >
                                 <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());	
}" />
                                    <Columns>
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileNo %>" FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="<%$ Resources:localizedText, profileNo %>" Width="22%" />
                                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileDescription %>" FieldName="AccessDescription" Name="AccessDescription" ToolTip="<%$ Resources:localizedText, profileDescription %>" Width="50%" />
                                      <dx:ListBoxColumn Caption="Profil ID:" FieldName="AccessProfileID" Name="AccessProfileID" ToolTip="Profil ID:" Width="40%" />
                                    </Columns>
                                </dx:ASPxComboBox>
                                <section class="toplbl2">
                                    <asp:Button ID="btnSearchAccessProfile" runat="server" Text="" CssClass="searchfltright" Width="24px" Height="24px" BackColor="White" Style="border-radius: 5px; margin-top: 4px;" />
                                </section>
                                <asp:Button ID="btnSearchProfiles" ClientIDMode="Static" runat="server" Text="" CssClass="SearchProfilebtn" />

                            </section>
                            <section class="bottomlblright">
                                    <section class="profilenewarea">
                            <asp:Button ID="btnNewAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessProfile1 %>" CssClass="newstandardbutton" OnClick="btnNewAccessProfile_Click" />
                        </section>
                                <%--<asp:Button ID="btnSearchProfiles" ClientIDMode="Static" runat="server" Text="Zutrittsprofile" CssClass="SearchProfilebtn" />--%>
                            </section>
                        </section>

                    
                    </section>
                    <section class="bottomsectiondivrightbBottomright">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, Integratedprofile %>" CssClass="profillbl" Style="margin-left: 8px; height: 25px;"></asp:Label>
                        <%--<section class="toplbl">
                            <section class="toplbl1">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, selectAccessProfile %>"></asp:Label>
                        </section>
                            
                        </section>--%>
                        <section class="bottomlbl" >
                            <div class="intergrated">
                                <section class="top">
                                    <section class="top1">
                                        <section class="top1left">
                                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText,daysDateSelection %>"></asp:Label>
                                        </section>
                                        <section class="top1right">
                                            <section class="rightDivs">
                                                <section class="sec1">
                                                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText,date %>" CssClass="lblJahr"></asp:Label>
                                                </section>
                                                <section class="sec2">
                                                    <section class="griddatemover">
                                                        <section class="griddatemoverleft">
                                                            <asp:Button ID="btnTariffYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                                        </section>
                                                        <section class="griddatemovercenter">
                                                            <asp:DropDownList ID="ddlTariffYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%; display: none;" CssClass="ddlYearStyle"></asp:DropDownList>
                                                            <dx:ASPxComboBox runat="server" ID="ddlTariffYear2" Theme="Aqua" ValueType="System.String" AutoPostBack="false" CssClass="ddlYearStyle2" Style="min-width: 100%;"></dx:ASPxComboBox>
                                                        </section>
                                                        <section class="griddatemoverright">
                                                            <asp:Button ID="btnTariffYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                                        </section>
                                                    </section>
                                                </section>
                                            </section>
                                        </section>
                                    </section>
                                    <%--<dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Office2003Blue" Width="100%">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Mo" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Di" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mi" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Do" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Fr" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sa" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="So" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, dates%>" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="2" ShowEmptyDataRows="True">
                            </SettingsPager>
                        </dx:ASPxGridView>--%>
                                    <section class="top2">
                                        <asp:Panel runat="server" ID="panelWorkdays">
                                            <table class="tbl">
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,mon%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,tue%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,wed%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,thur%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,fri%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,sat%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText ,sun%>"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <%-- <asp:Label runat="server" CssClass="lblDays" Text="<%$ Resources:localizedText, dates %>"></asp:Label>--%>
                                                    </th>
                                                </tr>
                                                <tbody>
                                                    <tr>
                                                        <td id="labelMonday" class="workingDay">
                                                            <asp:CheckBox runat="server" ID="chkMonday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelTuesday" class="workingDay">
                                                            <asp:CheckBox runat="server" ID="chkTuesday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelWednesday" class="workingDay">
                                                            <asp:CheckBox runat="server" ID="chkWednesday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelThursday" class="workingDay">
                                                            <asp:CheckBox runat="server" ID="chkThursday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelFriday" class="workingDay">
                                                            <asp:CheckBox runat="server" ID="chkFriday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelSaturday" class="nonWorkingDay">
                                                            <asp:CheckBox runat="server" ID="chkSaturday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="labelSunday" class="nonWorkingDay">
                                                            <asp:CheckBox runat="server" ID="chkSunday" Checked="false" CssClass="checkBoxDays"></asp:CheckBox>
                                                        </td>
                                                        <td id="txt" class="txt">
                                                            <%-- <asp:TextBox ID="txtCalendarDate" runat="server" CssClass="txt2" ReadOnly="true" ></asp:TextBox>--%>
                                        
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </section>
                                </section>
                              

                            </div>
                            <%-- <section class="bottomlblright">
                                
                            </section>--%>
                            <div class="intergrated2" >
                                  <section id="sectionWeekButtons" class="bottom">
                                    <asp:Button ID="btnWeek" runat="server" Text="<%$ Resources:localizedText, week %>" CssClass="button btnweek" />
                                    <asp:Button ID="btnmonFri" runat="server" Text="Montag - Freitag" CssClass="button1 btnmonFri" />
                                    <asp:Button ID="btnSattoSun" runat="server" Text="Samstag - Sonntag" CssClass="button2 btnSattoSun" />
                                </section>
                                <section class="rightbottom3">
                                    <div class="intergrated3">
                                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, validprofil %>" CssClass="profillbl2"></asp:Label>
                                        <section class="rightDivs2">
                                            <section class="von1">
                                                <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText, from %>" CssClass="lblJahr"></asp:Label>
                                            </section>
                                            <section class="last">
                                                <section class="griddatemover">
                                                    <section class="griddatemoverleft">
                                                        <asp:Button ID="btnDateFromPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                                    </section>
                                                    <section class="griddatemovercenter">
                                                        <dx:ASPxDateEdit ID="datePickerDateFrom" ClientInstanceName="datePickerDateFrom" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                                        </dx:ASPxDateEdit>
                                                    </section>
                                                    <section class="griddatemoverright">
                                                        <asp:Button ID="btnDateFromNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                                    </section>
                                                </section>
                                            </section>
                                        </section>
                                        <section class="rightDivs1">
                                            <section class="bis">
                                                <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblJahr"></asp:Label>
                                            </section>
                                            <section class="center">
                                                <section class="griddatemover">
                                                    <section class="griddatemoverleft">
                                                        <asp:Button ID="btnDateToPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                                    </section>
                                                    <section class="griddatemovercenter">
                                                        <dx:ASPxDateEdit ID="datePickerDateTo" ClientInstanceName="datePickerDateTo" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                                        </dx:ASPxDateEdit>
                                                    </section>
                                                    <section class="griddatemoverright">
                                                        <asp:Button ID="btnDateToNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                                    </section>
                                                </section>
                                            </section>
                                        </section>
                                    </div>
                                    <div class="intergrated4">
                                        <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="applybtnfooterorange" style="width:88px; float:right;" />
                                    </div>
                                </section>
                            </div>
                        </section>
                    </section>
                    <section class="bottomsectiondivrightbBottomright2" style="display: none;">
                        <asp:Label ID="Label6" runat="server" Text="Memo Text" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                    </section>
                </section>
                <section class="tblAccessProfiles" style="display: none;">
                    <section class="sectionGridsd">
                        <asp:ObjectDataSource ID="grdZuttritProfileTimeFramesObjectDataSource" runat="server" DataObjectTypeName="KruAll.Core.Models.ZuttritProfilesTimeFrame" DeleteMethod="DeleteZuttritProfilesTimeFrame" InsertMethod="CreateZuttritProfilesTimeFrame" SelectMethod="ZuttritProfilesTimeFrames" TypeName="Access_Control.ViewModels.ZuttritProfilesTimeFrameViewModel" UpdateMethod="UpdateZuttritProfilesTimeFrame"></asp:ObjectDataSource>
                        <asp:Table runat="server" ID="tableHeader" CssClass="tableRowMainnew" CellPadding="0" CellSpacing="0">
                            <asp:TableHeaderRow CssClass="tableRownew">
                                <asp:TableCell CssClass="tableCell1">
                                    <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText,activeProfile %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell CssClass="tableCellmdf">
                                    <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                                </asp:TableCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <dx:ASPxGridView ID="grdZuttritProfileTimeFrames" runat="server" AutoGenerateColumns="False" UseDisabledStatePainter="false" SettingsBehavior-AllowSort="false" Theme="Office2003Blue"
                            CssClass="grid" Width="100%" ClientInstanceName="grdZuttritProfileTimeFrames" KeyFieldName="ID" EnableCallBacks="true"  OnCustomCallback="grdZuttritProfileTimeFrames_CustomCallback"   ForeColor="Black">

                            <Columns>
                                <dx:GridViewDataCheckColumn VisibleIndex="4" Caption="<%$ Resources:localizedText,all %>" Width="9.5%" FieldName="ProfilAktiv">
                                    <PropertiesCheckEdit EnableClientSideAPI="True">
                                        <ClientSideEvents CheckedChanged="function(s, e) {
	activateProfile(s, e);
}" />
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
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowDragDrop="false" AllowSort="false" />
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
            <div class="secCalendarSelection">
                <section class="headerClass">
                    <asp:Label ID="Label30" runat="server" Text="<%$ Resources:localizedText, calendarSelection %>" CssClass="lblHeader"></asp:Label>
                </section>
                <section class="midGridClass">
                    <dx:ASPxGridView ID="grdHolidayCalndr" ClientInstanceName="grdHolidayCalndr"  EnableCallBacks="true" OnCustomCallback="grdHolidayCalndr_CustomCallback" runat="server" Width="100%" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False">
                        <ClientSideEvents RowClick="function(s, e) {
	if (ASPxClientUtils.touchUI) {
		grdHolidayCalndrSingleClick(s,e)
	}
}"
                            RowDblClick="function(s, e) {
	grdHolidayCalndrSingleClick(s,e)
}" />
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, calendarNr %>" VisibleIndex="1" FieldName="Calendar_Nr">
                                <CellStyle HorizontalAlign="Left"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="12%" Caption="<%$ Resources:localizedText, descrption %>" VisibleIndex="2" FieldName="Calendar_Name"></dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPager PageSize="19" ShowEmptyDataRows="true" Visible="False"></SettingsPager>
                        <SettingsBehavior AllowFocusedRow="true" AllowSort="false" AllowDragDrop="false" />
                        <SettingsDataSecurity AllowInsert="False" AllowEdit="False" AllowDelete="False"></SettingsDataSecurity>
                    </dx:ASPxGridView>
                </section>
                <section class="secFooter">
                    <asp:Button ID="btnApplySelectedCalender" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, applycalender %>" CssClass="applybtnfooterorange" Style="text-align: right !important; float: right; margin-top: 0;" />
                </section>
            </div>

        </div>
        <div id="searchAccessProfile" class="accssProfls" style="display: none">
           
             <dx:ASPxGridView ID="gridViewAccessProfileSearch" ClientInstanceName="gridViewAccessProfileSearch" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue"
                Width="100%" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="12px" KeyFieldName="ID">
                <ClientSideEvents
                    RowClick="function(s, e) {
                    if (ASPxClientUtils.touchUI) {
		                     gridViewAccessProfileRowClick(s, e); }}"
                    RowDblClick="function(s, e) {
	gridViewAccessProfileRowClick(s,e);
}" />
                <Columns>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nr%>" VisibleIndex="0" FieldName="AccessProfileNo" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idnew%>" VisibleIndex="1" FieldName="AccessProfileID" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description1%>" VisibleIndex="2" FieldName="AccessDescription" Width="76%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                <SettingsPager PageSize="13" ShowEmptyDataRows="True"></SettingsPager>
            </dx:ASPxGridView>
        </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
     <asp:Button ID="btnNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, accesscalendernew %>" Style="width: 134px !important;"  />
    <asp:Button ID="btnEdit" CssClass="editbtnfooterorange " runat="server" Text="<%$ Resources:localizedText, editing %>" Style="display: none" />
    <asp:Button ID="btnSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, accesscalendersave %>" Style="width: 164px !important;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, accesscalenderdelete %>" Style="width: 154px !important;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" PostBackUrl="~/Content/VisitorPlan.aspx"  />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
