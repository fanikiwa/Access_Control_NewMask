<%@ Page Title="Zutrittsplan Mitgliederauswahl" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessPlanMembers.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlanMembers" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessPlanMembers.js"></script>
    <link href="Styles/AccessPlanMembers.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">

    <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldInitialPersonalsCount" runat="server" />
    <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />

    <div class="accPlnMainContent">

        <div id="ControlSecarea" class="controlSec">

            <div class="ControlSecarea2" style="display: none;">

                <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanGroupNo %>" CssClass="planGruppen1"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessGroupNumber" ClientInstanceName="ddlAccessGroupNumber" ClientIDMode="Static" runat="server" ValueField="Id" TextField="AccessGroupNumber" ValueType="System.String" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen2" TextFormatString="{0}" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                    <Columns>
                        <dx:ListBoxColumn FieldName="AccessGroupNumber" Name="AccessGroupNumber" Caption="AccessGroupNumber" ToolTip="AccessGroupNumber" Width="20%" />
                        <dx:ListBoxColumn FieldName="AccessGroupName" Name="AccessGroupName" Caption="AccessGroupName" ToolTip="AccessGroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="planGruppen3"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessGroupName" ClientInstanceName="ddlAccessGroupName" ClientIDMode="Static" runat="server" ValueField="Id" TextField="AccessGroupName" ValueType="System.String" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen4" TextFormatString="{1}" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                    <Columns>
                        <dx:ListBoxColumn FieldName="AccessGroupNumber" Name="AccessGroupNumber" Caption="AccessGroupNumber" ToolTip="AccessGroupNumber" Width="20%" />
                        <dx:ListBoxColumn FieldName="AccessGroupName" Name="AccessGroupName" Caption="AccessGroupName" ToolTip="AccessGroupName" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label runat="server" Text="<%$ Resources:localizedText, accessPlanNo %>" CssClass="planGruppen5"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessProfileNumber" ClientInstanceName="ddlAccessProfileNumber" ClientIDMode="Static" runat="server" ValueField="Id" TextField="AccessPlanNr" ValueType="System.String" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen6" TextFormatString="{0}" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                    <Columns>
                        <dx:ListBoxColumn FieldName="AccessPlanNr" Name="AccessPlanNr" Caption="AccessPlanNr" ToolTip="AccessPlanNr" Width="20%" />
                        <dx:ListBoxColumn FieldName="AccessPlanDescription" Name="AccessPlanDescription" Caption="AccessPlanDescription" ToolTip="AccessPlanDescription" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>

                <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen7"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessProfileName" ClientInstanceName="ddlAccessProfileName" ClientIDMode="Static" runat="server" ValueField="Id" TextField="AccessPlanDescription" ValueType="System.String" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen8" TextFormatString="{1}" EnableCallbackMode="true" Theme="Office2003Blue" DropDownRows="20" DropDownWidth="400px">
                    <Columns>
                        <dx:ListBoxColumn FieldName="AccessPlanNr" Name="AccessPlanNr" Caption="AccessPlanNr" ToolTip="AccessPlanNr" Width="20%" />
                        <dx:ListBoxColumn FieldName="AccessPlanDescription" Name="AccessPlanDescription" Caption="AccessPlanDescription" ToolTip="AccessPlanDescription" Width="80%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Button ID="Search" runat="server" Text="" CssClass="searchzutarea" />
            </div>
            <div class="ControlSecarea3New">
                <section class="leftDvns">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessplangroupinfo %>" CssClass="Gruppen1"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupNumber" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppen2"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, groupName %>" CssClass="Gruppen3"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppen4"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, planNo_new %>" CssClass="planGruppenf"></asp:Label>
                    <asp:TextBox ID="txtAccessProfileNumber" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppenf"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppeng"></asp:Label>
                    <asp:TextBox ID="txtAccessProfileName" ClientIDMode="Static" Enabled="false" runat="server" CssClass="Gruppeng"></asp:TextBox>
                </section>
                <section class="rightDvns">
                    <asp:Button ID="btnPersonnel" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, people %>" CssClass="newstandardbutton Personenbutton2" PostBackUrl="~/Content/AccessPlanPersonal.aspx"></asp:Button>
                    <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                    <asp:Button ID="btnMembers" runat="server" Text="Mitglieder" CssClass="newstandardbutton memberbutton2" Enabled="false"></asp:Button>
                    <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                    <asp:Button ID="btnReader" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2" PostBackUrl="~/Content/AccessPlanReader.aspx"></asp:Button>
                    <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                    <asp:Button ID="btnAccessProfile" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" PostBackUrl="~/Content/AccessPlanAccessCalender.aspx" CssClass="newstandardbutton Zutrittsprofilbutton2"></asp:Button>
                    <img src="../Images/FormImages/arrowpoint.png" class="arrowpoint" />
                    <asp:Button ID="Button1" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" PostBackUrl="~/Content/AccessPlanHolidaySchedule.aspx" CssClass="newstandardbutton Zutrittsprofilbutton2leser"></asp:Button>
                    <asp:ImageButton ID="btnInformation" CssClass="btnInfo" runat="server" />
                </section>

            </div>
        </div>

        <div class="MidContentAreaDiv">

            <div id="divFilterEmployees" class="midSection">

                <section class="secMidLeft">

                    <section class="midDivns">

                        <section class="sec1">

                            <asp:Label ID="Label6" runat="server" Text="Studio Gruppe:" CssClass="lblMidSec"></asp:Label>

                            <dx:ASPxComboBox ID="ddlbMemberGroupFrom" ClientInstanceName="ddlbMemberGroupFrom" ValueField="Id" TextField="GroupNr" runat="server" Theme="Office2003Blue" CssClass="drpMidSec5" TextFormatString="{1}" DropDownRows="20" DropDownStyle="DropDownList" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlMemberGroupFromSelectionChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="GroupNr" Caption="Gruppen Nr." Name="ID" Width="15%" />
                                    <dx:ListBoxColumn FieldName="GroupName" Caption="Gruppen Bezeichnung" Name="GroupName" Width="50%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>

                        <section class="sec2">

                            <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblMidSecbis"></asp:Label>

                            <dx:ASPxComboBox ID="ddlMemberGroupTo" ClientInstanceName="ddlMemberGroupTo" ValueField="Id" TextField="GroupNr" runat="server" Theme="Office2003Blue" CssClass="drpMidSec" TextFormatString="{1}" DropDownRows="20" DropDownStyle="DropDownList" DropDownWidth="400px">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlMemberGroupToSelectionChanged(s,e);	
}"></ClientSideEvents>
                                <Columns>
                                    <dx:ListBoxColumn FieldName="GroupNr" Caption="Gruppen Nr." Name="ID" Width="15%" />
                                    <dx:ListBoxColumn FieldName="GroupName" Caption="Gruppen Bezeichnung" Name="GroupName" Width="50%" />
                                </Columns>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="sec3">

                            <section class="midSecRght1">

                                <asp:Label ID="Label8" runat="server" Text="Mitglieds Nr. von:" CssClass="lblMidSec3" Style="line-height: 14px;"></asp:Label>

                                <dx:ASPxComboBox ID="ddlMemberFrom" ClientInstanceName="ddlMemberFrom" ValueField="ID" TextField="MemberNumber" runat="server" Theme="Office2003Blue" CssClass="drpMidSec3" DropDownStyle="DropDownList" DropDownRows="20" DropDownWidth="400px" TextFormatString="{0}">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlMemberFromSelectionChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="MemberNumber" Caption="Mitglieds Nr." Name="Number" Width="20%" />
                                        <dx:ListBoxColumn FieldName="FirstName" Caption="Name" Name="FirstName" Width="30%" />
                                        <dx:ListBoxColumn FieldName="SurName" Caption="Vorname" Name="SurName" Width="30%" />
                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>

                            <section class="midSecRght2">

                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblMidSec2"></asp:Label>

                                <dx:ASPxComboBox ID="ddlMemberTo" ClientInstanceName="ddlMemberTo" ValueField="ID" TextField="MemberNumber" runat="server" Theme="Office2003Blue" CssClass="drpMidSec2" DropDownStyle="DropDownList" DropDownRows="20" DropDownWidth="400px" TextFormatString="{0}">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlMemberToSelectionChanged(s,e);	
}"></ClientSideEvents>
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="MemberNumber" Caption="Mitglieds Nr." Name="Number" Width="20%" />
                                        <dx:ListBoxColumn FieldName="FirstName" Caption="Name" Name="FirstName" Width="30%" />
                                        <dx:ListBoxColumn FieldName="SurName" Caption="Vorname" Name="SurName" Width="30%" />

                                    </Columns>
                                </dx:ASPxComboBox>

                            </section>

                        </section>

                    </section>

                    <section class="midDivns" style="display: none;">
                        <section class="sec1">
                            <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, departmentFrom %>" CssClass="lblMidSec"></asp:Label>
                            <dx:ASPxComboBox ID="ddlDepartmentFrom" ClientInstanceName="ddlDepartmentFrom" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" CssClass="drpMidSec5">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlDepartmentFromSelectionChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="sec2">
                            <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblMidSecbis"></asp:Label>
                            <dx:ASPxComboBox ID="ddlDepartmentTo" ClientInstanceName="ddlDepartmentTo" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" CssClass="drpMidSec">
                                <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlDepartmentToSelectionChanged(s,e);	
}"></ClientSideEvents>
                            </dx:ASPxComboBox>

                        </section>
                        <section class="sec3">
                            <section class="midSecRght1">
                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText, costCenterFrom %>" CssClass="lblMidSec3"></asp:Label>
                                <dx:ASPxComboBox ID="ddlCostCentreFrom" ClientInstanceName="ddlCostCentreFrom" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" CssClass="drpMidSec3">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlCostCentreFromSelectionChanged(s,e);	
}"></ClientSideEvents>
                                </dx:ASPxComboBox>

                            </section>
                            <section class="midSecRght2">
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText, to %>" CssClass="lblMidSec2"></asp:Label>
                                <dx:ASPxComboBox ID="ddlCostCentreTo" ClientInstanceName="ddlCostCentreTo" ValueField="ID" TextField="Name" runat="server" Theme="Office2003Blue" CssClass="drpMidSec2">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
ddlCostCentreToSelectionChanged(s,e);	
}"></ClientSideEvents>
                                </dx:ASPxComboBox>

                            </section>
                        </section>
                    </section>
                    <section class="midDivns" style="display: none;">
                        <section class="sec1">
                            <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText, containerNumber2 %>" CssClass="lblMidSec"></asp:Label>
                            <dx:ASPxComboBox ID="ASPxComboBox9" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpContainerNo"></dx:ASPxComboBox>
                        </section>
                        <section class="sec2">
                            <asp:Label ID="Label13" runat="server" Text="Container ID:" CssClass="lblMidSecbis"></asp:Label>
                            <dx:ASPxComboBox ID="ASPxComboBox10" runat="server" ValueType="System.String" Theme="Office2003Blue" CssClass="drpMidSec"></dx:ASPxComboBox>
                        </section>
                        <section class="sec3">
                            <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText, containerDescription %>" CssClass="lblMidSec4"></asp:Label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="txtMidSec"></asp:TextBox>
                        </section>
                    </section>
                </section>
                <section class="secMidRightnew">
                    <asp:Button ID="btnFilterEmployees" CssClass="btnMidSecRight" runat="server" Text="" />
                </section>
                <section class="divsRght" style="display: none;">
                    <asp:Button ID="btnDeselectAll" runat="server" Text="<%$ Resources:localizedText, unselect%>" CssClass="btnFtrMid btnSelect" />
                    <asp:Button ID="btnSelectAll" runat="server" Text="<%$ Resources:localizedText, all%>" CssClass="btnFtrMid btnAll" />
                </section>
            </div>

            <div id="importantDialog" class="dialogBox">
            </div>

            <div class="gridSectionNew">

                <dx:ASPxGridView ID="gridViewEmployee" ClientInstanceName="gridViewEmployee" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Aqua" Width="100%" KeyFieldName="ID" SettingsBehavior-AllowSort="false"
                    OnDataBound="gridViewEmployee_OnDataBound" OnCustomCallback="gridViewEmployee_OnCustomCallback">
                    <ClientSideEvents SelectionChanged="gridViewEmployeeSelectionChanged" Init="function(s, e) {
gridViewEmployeeInit(s,e);	
}" />

                    <Columns>

                        <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0" FieldName="ID">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, membernumber %>" VisibleIndex="1" FieldName="MemberNumber" Width="15%">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, LastName1 %>" VisibleIndex="2" FieldName="SurName">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstname_new %>" VisibleIndex="3" FieldName="FirstName">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, contractnumber%>" VisibleIndex="4" FieldName="AgreementNr">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, place2%>" VisibleIndex="5" FieldName="Place">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, zipCode2%>" VisibleIndex="6" FieldName="PostalCode">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, street%>" VisibleIndex="7" FieldName="Street">
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, housenumber%>" ShowSelectCheckbox="True" ShowClearFilterButton="True" SelectAllCheckboxMode="Page" VisibleIndex="8" />

                        <dx:GridViewDataTextColumn Caption="" VisibleIndex="9" FieldName="IsSelected" Visible="false">
                        </dx:GridViewDataTextColumn>

                    </Columns>

                    <Styles>
                        <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                    </Styles>

                    <SettingsPager PageSize="26" Visible="False" ShowEmptyDataRows="True">
                    </SettingsPager>

                    <SettingsBehavior AllowSelectSingleRowOnly="False" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>

                </dx:ASPxGridView>

            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="divsLft">
        <%-- <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>"  />
        <asp:Button ID="btnEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>"   />--%>
        <%-- <asp:Button ClientIDMode="Static" ID="btnSave" CssClass="BottomFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>"  />  --%>
        <asp:Button ID="btnSave" ClientIDMode="Static" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveButton %>" Style="width: 70px;" />
        <%--    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>"   />--%>
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
