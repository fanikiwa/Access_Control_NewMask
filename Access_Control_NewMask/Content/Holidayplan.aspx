<%@ Page Title="<%$ Resources:localizedText, holidaySchedule %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Holidayplan.aspx.cs" Inherits="Access_Control_NewMask.Content.Holidayplan" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Holidayplan.js"></script>
    <link href="Styles/Holidayplan.css" rel="stylesheet" />
    <link href="Styles/FormViewSearch.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldConfirmDialog" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <section class="contentdiv">
        <section class="contentdivtop">
            <section class="contentdivtop1">
                <section class="contentdivtop1left">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, holidayScheduleNo %>" CssClass="benutzernrlbltop"></asp:Label>
                    <dx:ASPxComboBox ID="ddlHolidayPlanCalendarNumber" runat="server" AutoPostBack="false" ClientInstanceName="ddlHolidayPlanCalendarNumber" ValueField="Id" TextFormatString="{0}" TextField="HolidayPlanCalendarNumber" CssClass="benutzernr" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        DropDownWidth="300" DropDownRows="20" OnCallback="ddlHolidayPlanCalendarNumber_Callback" EnableCallbackMode="true">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {PlanNumberSelectedIndexChanged(s, e);}" DropDown="function(s, e) {
	dplPlanClicked(s,e);
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="HolidayPlanCalendarNumber" FieldName="HolidayPlanCalendarNumber" Width="10%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="HolidayPlanCalendarName" FieldName="HolidayPlanCalendarName" Width="90%" />
                            <%--<dx:ListBoxColumn Caption="Calender ID" Name="HolidayPlanCalendarName" FieldName="HolidayCalenderId" Visible="false" />--%>
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
                <section class="contentdivtop1right">
                    <asp:Label ID="Label2" runat="server" Text=" <%$ Resources:localizedText, description1 %>" CssClass="benutzernrlbl2top"></asp:Label>
                    <dx:ASPxComboBox ID="ddlHolidayPlanCalendarName" runat="server" ClientInstanceName="ddlHolidayPlanCalendarName" ValueField="Id" TextFormatString="{1}" TextField="HolidayPlanCalendarName" CssClass="benutzernr2" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        DropDownWidth="300px" DropDownRows="20" OnCallback="ddlHolidayPlanCalendarName_Callback" EnableCallbackMode="true">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	PlanNameSelectedIndexChanged(s, e);
}"
                            DropDown="function(s, e) {
dplPlanClicked(s,e);	
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr:" Name="HolidayPlanCalendarNumber" FieldName="HolidayPlanCalendarNumber" Width="10%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Name="HolidayPlanCalendarName" FieldName="HolidayPlanCalendarName" Width="90%" />
                            <%--<dx:ListBoxColumn Caption="Calender ID" Name="HolidayPlanCalendarName" FieldName="HolidayCalenderId" Visible="false" />--%>
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
                <section class="contentdivtop1rightnew1">
                    <section class="contentdivtop1rightnewcalender">
                        <%--<section class="sec2">
                            <section class="griddatemover">
                                <section class="griddatemoverleft">
                             <asp:Button ID="btnCalendarYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr"/> 
                                </section>
                                <section class="griddatemovercenter">
                                    <asp:DropDownList ID="ddlCalendarYear" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%; display:none; " CssClass="ddlYearStyle"></asp:DropDownList>
                                    <dx:ASPxComboBox runat="server" ID="ddlCalendarYear2" Theme="Aqua" ValueType="System.String" AutoPostBack="true" CssClass="ddlYearStyle2" Style="min-width: 100%;"> </dx:ASPxComboBox>
                                </section>
                                <section class="griddatemoverright">
                                     <asp:Button ID="btnCalendarYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt"/> 
                                </section>
                            </section>
                        </section>--%>
                    </section>
                    <section class="empFormViewNavnew">
                        <section class="fvNavSearch2">
                            <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                            <asp:Button ID="btnSearchAllEmp" runat="server" Text="" CssClass="searchAllEmpnew" />
                        </section>
                    </section>

                </section>


                                <section class="secYear">
                    <section class="sec2">
                        <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, year1 %>" CssClass="lblYear3"></asp:Label>
                        <section class="griddatemover">
                            <section class="griddatemoverleft">
                                <asp:Button ID="btnCalendarYearPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                            </section>
                            <section class="griddatemovercenter">
                                <asp:DropDownList ID="ddlCalendarYear" runat="server" Theme="Office2003Blue" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%; display: none;" CssClass="ddlYearStyle"></asp:DropDownList>
                                <dx:ASPxComboBox runat="server" HorizontalAlign="Center" ClientIDMode="Static" ID="ddlCalendarYear2" OnSelectedIndexChanged="ddlCalendarYear2_SelectedIndexChanged" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" ValueType="System.String" CssClass="ddlYearStyle2" Style="min-width: 100%;"></dx:ASPxComboBox>
                            </section>
                            <section class="griddatemoverright">
                                <asp:Button ID="btnCalendarYearNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                            </section>
                        </section>
                    </section>
                </section>





            </section>
            <section class="contentdivtop2">
                <section class="contentdivtop1leftnew">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, holidayScheduleNo %>" CssClass="benutzernrlbl"></asp:Label>
                    <asp:TextBox ID="txtHolidayPlanCalendarNumber" runat="server" CssClass="benutzernr22" onkeypress="return IsNumber(event)"></asp:TextBox>
                </section>
                <section class="contentdivtop1rightnew">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="benutzernrlbl2"></asp:Label>
                    <asp:TextBox ID="txtHolidayPlanCalendarName" runat="server" CssClass="benutzernr22bez"></asp:TextBox>
                </section>
                <section class="contentdivtop1rightnew3">
                    <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, holidayCalendarNo2 %>" CssClass="lblHeader"></asp:Label>
                    <%-- <asp:DropDownList ID="ddlHolidayCalendarNumber" runat="server" DataValueField="Id" DataTextField="HolidayCalendarNumber" CssClass="benutzernr22beztextno" AutoPostBack="true" OnSelectedIndexChanged="ddlHolidayCalendarNumber_SelectedIndexChanged"></asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="ddlHolidayCalendarNumber" runat="server" ClientInstanceName="ddlHolidayCalendarNumber" CssClass="benutzernrlbl2new" ValueField="Id" TextField="HolidayCalendarNumber" DropDownRows="6" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{0}" Theme="Office2003Blue" OnCallback="ddlHolidayCalendarNumber_Callback">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
HolidaySelectedChanged(s,e);	
}"
                            EndCallback="function(s, e) {
ddlHolidayCalendarNumberEndCallBack(s, e);	
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, holidayCalendarNo2 %>" FieldName="HolidayCalendarNumber" Name="HolidayCalendarNumber" ToolTip="<%$ Resources:localizedText, holidayCalendarNo2 %>" Width="35%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="HolidayCalendarName" Name="HolidayCalendarName" ToolTip="<%$ Resources:localizedText, description1 %>" Width="65%" />

                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="lblFNr"></asp:Label>
                    <%-- <asp:DropDownList ID="ddlHolidayCalendarName" runat="server" DataValueField="Id" DataTextField="HolidayCalendarName" CssClass="benutzernr22beztext" AutoPostBack="true" OnSelectedIndexChanged="ddlHolidayCalendarName_SelectedIndexChanged"></asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="ddlHolidayCalendarName" runat="server" ClientInstanceName="ddlHolidayCalendarName" CssClass="benutzernrnew" ValueField="Id" TextField="HolidayCalendarName" AutoPostBack="false"
                        DropDownRows="6" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" SelectedIndex="0" Font-Size="14px" TextFormatString="{1}" Theme="Office2003Blue" OnCallback="ddlHolidayCalendarName_Callback">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
HolidaySelectedChanged(s,e);	
}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, holidayCalendarNo2 %>" FieldName="HolidayCalendarNumber" Name="HolidayCalendarNumber" ToolTip="<%$ Resources:localizedText, holidayCalendarNo2 %>" Width="35%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="HolidayCalendarName" Name="HolidayCalendarName" ToolTip="<%$ Resources:localizedText, description1 %>" Width="65%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>

                <%--<section class="contentdivtop1rightnewcalender">
                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, year %>" CssClass="lblyear"></asp:Label>
                  <section class="sec2">
                            <section class="griddatemover">
                                <section class="griddatemoverleft">
                             <asp:Button ID="Button7" runat="server" Text="" CssClass="korbtnFvNavPrevNr"/> 
                                </section>
                                <section class="griddatemovercenter">
                                    <asp:DropDownList ID="DropDownList3" runat="server" Theme="Aqua" ValueType="System.String" AutoPostBack="True" Style="min-width: 100%;" CssClass="ddlYearStyle"></asp:DropDownList>
                                </section>
                                <section class="griddatemoverright">
                                     <asp:Button ID="Button8" runat="server" Text="" CssClass="korbtnFvNavNexNrt"/> 
                                </section>
                            </section>
                        </section>
              </section>--%>
            </section>
        </section>
        <section class="contentdivbottom">
            <section class="contentdivbottomleft">
                <section class="contentdivbottomlefttop">
                    <dx:ASPxGridView ID="gridViewHolidayPlanCalendar" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false" ClientInstanceName="gridViewHolidayPlanCalendar" KeyFieldName="Id" runat="server" AutoGenerateColumns="False"
                        Theme="Office2003Blue" Width="100%" OnHtmlDataCellPrepared="gridViewHolidayPlanCalendar_HtmlDataCellPrepared" OnCustomCallback="gridViewHolidayPlanCalendar_CustomCallback" EnableCallBacks="true">
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
                        <asp:Label ID="Label5" runat="server" Text="Memo Text:" CssClass="memotexttop"></asp:Label>
                        <asp:TextBox ID="txtMemo" runat="server" CssClass="memotextbottom" TextMode="MultiLine"></asp:TextBox>
                    </section>
                    <section class="labal">
                        <section class="generelle">
                            <asp:Label ID="Label10" runat="server" CssClass="lblTitleHeader" Text="<%$ Resources:localizedText, generalSettingsAndProfileAssignmentTitle %>"></asp:Label>
                        </section>
                        <section class="labal1">
                            <section class="labal1left">
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, holidaysNoAccess %>" CssClass="lblAccssPermsn"></asp:Label>
                                <asp:CheckBox ID="chkDenyAccess" ClientIDMode="Static" runat="server" CssClass="chkAccssPermsn" />
                            </section>
                            <section class="labal1right">
                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, holidayAllowAccess %>" CssClass="lblAccssPermsn2"></asp:Label>
                                <asp:CheckBox ID="chkAllowAccess" ClientIDMode="Static" runat="server" CssClass="chkAccssPermsn2" />
                            </section>
                        </section>
                        <section class="labal2">
                            <section class="labaltop">
                                <section class="lblSec1">
                                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, accessProfileNo %>" CssClass="Accessno"></asp:Label>
                                    <%-- <asp:DropDownList ID="ddlAccessProfileNumber" runat="server" DataValueField="ID" DataTextField="AccessProfileNo" CssClass="txtProfil1"></asp:DropDownList>--%>
                                    <asp:DropDownList ID="dplAccessProfileMemo" runat="server" DataValueField="ID" DataTextField="Memo" Style="display: none;" />
                                    <dx:ASPxComboBox ID="ddlAccessProfileNumber" runat="server" CssClass="txtProfil1" ValueField="ID" TextField="AccessDescription"
                                        DropDownRows="6" DropDownWidth="600px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{2}"
                                        IncrementalFilteringMode="Contains" SelectedIndex="0" Theme="Office2003Blue" ValueType="System.String">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	SetProfileSelectedDxDrp(s.GetValue());
}" />
                                        <Columns>
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupProfileNo %>" FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="<%$ Resources:localizedText, groupProfileNo %>" Width="18%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, grpDescription %>" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="<%$ Resources:localizedText, grpDescription %>" Width="42%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileNoTtl %>" FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="<%$ Resources:localizedText, profileNoTtl %>" Width="18%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileDescription %>" FieldName="AccessDescription" Name="AccessDescription" ToolTip="<%$ Resources:localizedText, profileDescription %>" Width="42%" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </section>
                                <section class="lblSec2">
                                    <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="Accessno1"></asp:Label>
                                    <%-- <asp:DropDownList ID="ddlAccessProfileName" runat="server" DataValueField="ID" DataTextField="AccessDescription" CssClass="txtProfil"></asp:DropDownList>--%>
                                    <dx:ASPxComboBox ID="ddlAccessProfileName" runat="server" CssClass="txtProfil" ValueField="ID" TextField="AccessDescription"
                                        DropDownRows="6" DropDownWidth="600px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" TextFormatString="{3}" Theme="Office2003Blue">

                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
SetProfileSelectedDxDrp(s.GetValue());	
}"></ClientSideEvents>
                                        <Columns>
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, groupProfileNo %>" FieldName="AccessGroup.AccessGroupNumber" Name="AccessGroupNumber" ToolTip="<%$ Resources:localizedText, groupProfileNo %>" Width="18%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, grpDescription %>" FieldName="AccessGroup.AccessGroupName" Name="AccessGroupName" ToolTip="<%$ Resources:localizedText, grpDescription %>" Width="42%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileNoTtl %>" FieldName="AccessProfileNo" Name="AccessProfileNo" ToolTip="<%$ Resources:localizedText, profileNoTtl %>" Width="18%" />
                                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, profileDescription %>" FieldName="AccessDescription" Name="AccessDescription" ToolTip="<%$ Resources:localizedText, profileDescription %>" Width="42%" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                </section>
                                <section class="lblSec4">
                                    <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText, profileIdTitle %>" CssClass="Accessno2"></asp:Label>
                                    <dx:ASPxComboBox ID="ddlAccessProfileIdNumber" runat="server" SelectedIndex="0" ValueField="ID" TextField="AccessProfileID" CssClass="ddlProfil2id" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
SetProfileSelectedDxDrp(s.GetValue());	
}"></ClientSideEvents>
                                    </dx:ASPxComboBox>
                                </section>
                                <section class="lblSec3">
                                    <asp:Button ID="btnSearchAccessProfile" runat="server" Text="" CssClass="searchfltright2" Width="25px" Height="25px" BackColor="White" Style="border-radius: 5px; background-size: contain;" />
                                    <asp:Button ID="btnSearchProfiles" ClientIDMode="Static" runat="server" Text="" CssClass="SearchProfilebtn" />

                                </section>
                            </section>
                            <section class="labal2btm">
                                <section class="hldrOne">
                                    <asp:Button ID="btnNewAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessProfile1 %>" CssClass="mapbtns1BtnsRight2 btnNew1" OnClick="btnNewAccessProfile_Click" />
                                </section>
                                <section class="hldrTwo">
                                    <section class="bis" style="display: none">
                                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblJahr"></asp:Label>
                                    </section>
                                    <section class="center">
                                        <section class="griddatemover2" style="display: none">
                                            <section class="griddatemoverleft">
                                                <asp:Button ID="btnDateToPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                            </section>
                                            <section class="griddatemovercenter">
                                                <dx:ASPxDateEdit ID="datePickerDateFrom" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
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
                                        <section class="bottomlblright">
                                            <%--                                            <asp:Button ID="btnSearchProfiles" ClientIDMode="Static" runat="server" Text="Zutrittsprofile" CssClass="SearchProfilebtn" />--%>
                                        </section>
                                        <section class="griddatemover3" style="display: none">
                                            <section class="griddatemoverleft">
                                                <asp:Button ID="btnDateFromPrevious" runat="server" Text="" CssClass="korbtnFvNavPrevNr" />
                                            </section>
                                            <section class="griddatemovercenter">
                                                <dx:ASPxDateEdit ID="datePickerDateTo" Theme="Office2003Blue" runat="server" CssClass="ddlYearStyle2">
                                                </dx:ASPxDateEdit>
                                            </section>
                                            <section class="griddatemoverright">
                                                <asp:Button ID="btnDateFromNext" runat="server" Text="" CssClass="korbtnFvNavNexNrt" />
                                            </section>
                                        </section>
                                    </section>
                                </section>
                                <section class="hldrFour">
                                    <asp:Button ID="btnApply" runat="server" Text="<%$ Resources:localizedText,takeover%>" CssClass="ubernahmen" />
                                </section>
                                <%-- <section class="labal1left"> 
                    </section>--%>
                                <%-- <section class="labal1rightnew"> 
                     </section>--%>
                            </section>

                        </section>
                    </section>
                </section>
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
                        <dx:ASPxGridView ID="grdZuttritProfileTimeFrames" runat="server" AutoGenerateColumns="False" UseDisabledStatePainter="false" SettingsBehavior-AllowSort="false" Theme="Office2003Blue"
                            CssClass="grid" Width="100%" ClientInstanceName="grdZuttritProfileTimeFrames" EnableCallBacks="true" KeyFieldName="ID" ForeColor="Black" OnCustomCallback="grdZuttritProfileTimeFrames_CustomCallback">
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
            <section class="contentdivbottomright">
                <section class="contentdivbottomrightgrid ">
                    <dx:ASPxGridView ID="gridViewHoliday" ClientInstanceName="gridViewHoliday" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%"
                        KeyFieldName="Id" EnableCallBacks="true" OnCustomCallback="gridViewHoliday_CustomCallback">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Id" FieldName="Id" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, holidaySpecialDayTitle %>" FieldName="HolidayName" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn ShowInCustomizationForm="True" VisibleIndex="2" Caption="<%$ Resources:localizedText, dateTitle %>" FieldName="HolidayDate">
                                <EditFormSettings Visible="False" />
                                <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                                </PropertiesDateEdit>
                                <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                            </dx:GridViewDataDateColumn>
                            <%--  <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, selection%>" ShowSelectCheckbox="True"  ShowClearFilterButton="True" VisibleIndex="3" />--%>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, selectionTitle%>" FieldName="IsSelected" ReadOnly="true" VisibleIndex="3">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, profileTitle %>" FieldName="AccessProfile" VisibleIndex="4"></dx:GridViewDataCheckColumn>
                        </Columns>
                        <Styles>
                            <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                        </Styles>
                        <SettingsBehavior AllowSelectSingleRowOnly="False" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
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
                    <asp:Button ID="btnRemoveSelected" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, clearselection%>" CssClass="deletebtnfooterred" />
                </section>
                <section class="contentdivbottomrightbutton " style="display: none;">
                    <section class="leftButtons"></section>
                    <section class="rightButtons">
                        <%-- <asp:Button ID="btnSelectAll" CssClass="BottomFooterBtnsLeftnew1 btnAll" runat="server" Text="<%$ Resources:localizedText, all %>" />        
                    <asp:Button ID="btnDeselectAll" CssClass="BottomFooterBtnsLeftnewselect btnSelect" runat="server" Text="<%$ Resources:localizedText, unselect%>" />--%>
                    </section>

                </section>
            </section>
        </section>
        <div id="searchAccessProfile" class="searchAccessProfileCss" style="display: none">
            <dx:ASPxGridView ID="gridViewAccessProfileSearch" ClientInstanceName="gridViewAccessProfileSearch" runat="server" AutoGenerateColumns="False" Theme="Office2003Blue"
                Width="100%" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="12px" EnableCallBacks="false" KeyFieldName="ID">

                <ClientSideEvents RowDblClick="function(s, e) {
gridViewAccessProfileSearchRowClick(s, e);	
}"></ClientSideEvents>

                <Columns>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, nr%>" VisibleIndex="0" FieldName="AccessProfileNo" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, idnew%>" VisibleIndex="1" FieldName="AccessProfileID" Width="12%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, description1%>" VisibleIndex="2" FieldName="AccessDescription" Width="76%">
                        <Settings AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" AllowDragDrop="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                <SettingsPager PageSize="16" ShowEmptyDataRows="True" Visible="False"></SettingsPager>
                <SettingsDataSecurity AllowInsert="False" AllowEdit="False" AllowDelete="False"></SettingsDataSecurity>
            </dx:ASPxGridView>
        </div>
    </section>
    <div id="importantDialog" class="dialogBox"></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNewHolidayPlan" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, holidayplannew %>" Style="width: 116px;" OnClick="btnNewHolidayPlan_Click" />
    <%--    <asp:Button ID="btnEditHolidayPlan" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" OnClick="btnEditHolidayPlan_Click"/>--%>
    <asp:Button ID="btnSaveHolidayPlan" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, holidayplansave %>" Style="width: 153px;" OnClick="btnSaveHolidayPlan_Click" />
    <asp:Button ID="btnDeleteHolidayPlan" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, holidayplandelete %>" Style="width: 144px;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
