<%@ Page Title="<%$ Resources:localizedText, accessPlans %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="AccessPlan.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessPlan" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessPlan.js"></script>
    <link href="Styles/AccessPlan.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <asp:HiddenField ID="hiddenFieldFormMode" runat="server" />
        <asp:HiddenField ID="hiddenFieldDetectChanges" runat="server" />
        <asp:HiddenField ID="hiddenFieldConfirmDialog" runat="server" />
        <asp:HiddenField ID="hiddenFieldIncreament" runat="server" />
        <div id="ControlSecarea" class="ControlSecarea1new2ab">
            <div class="ControlSecarea2">
                <asp:Label runat="server" Text="<%$ Resources:localizedText, accessplangroupinfo %>" CssClass="planGruppen1"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessGroupNumber" ClientInstanceName="ddlAccessGroupNumber" ValueField="Id" TextField="AccessGroupNumber" runat="server" TextFormatString="{0}" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" CssClass="planGruppen2">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
groupNumberSelectedIndexChanged(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr" Name="AccessGroupNumber" FieldName="AccessGroupNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptioninfo %>" Name="AccessGroupName" FieldName="AccessGroupName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, descriptioninfo %>" CssClass="planGruppen3" Style="margin-left: 4px;"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessGroupName" ClientInstanceName="ddlAccessGroupName" ValueField="Id" TextField="AccessGroupName" runat="server" TextFormatString="{1}" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" CssClass="planGruppen4">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
groupNameSelectedIndexChanged(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="AccessGroupNumber" FieldName="AccessGroupNumber" Width="10%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptioninfo %>" Name="AccessGroupName" FieldName="AccessGroupName" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, planNo_new %>" CssClass="planGruppen5" Style="min-width: 97px; text-align: right;"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessProfileNumber" ClientInstanceName="ddlAccessProfileNumber" ValueField="ID" EnableCallbackMode="true" OnCallback="ddlAccessProfileNumber_Callback" TextField="AccessPlanNr" runat="server" TextFormatString="{0}" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" CssClass="planGruppen6">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
profileNumberSelectedIndexChanged(s,e);	
}"
                        DropDown="function(s, e) {
dplAccessProfileClick(s,e);	
}"
                        EndCallback="function(s, e) {
profileNumberEndCallBack(s,e)	;
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanNr" FieldName="AccessPlanNr" Width="10%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptioninfo %>" Name="AccessPlanDescription" FieldName="AccessPlanDescription" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Label runat="server" Text="<%$ Resources:localizedText, descriptioninfo %>" CssClass="planGruppen7"></asp:Label>
                <dx:ASPxComboBox ID="ddlAccessProfileName" ClientInstanceName="ddlAccessProfileName" ValueField="ID" TextField="AccessPlanDescription" EnableCallbackMode="true" OnCallback="ddlAccessProfileName_Callback" runat="server" TextFormatString="{1}" Theme="Office2003Blue" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" DropDownWidth="300px" DropDownRows="20" CssClass="planGruppen8">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
profileNameSelectedIndexChanged(s,e);	
}"
                        DropDown="function(s, e) {
dplAccessProfileClick(s,e);	
}"
                        EndCallback="function(s, e) {
profileNameEndCallBack(s,e);	
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="Nr:" Name="AccessPlanNr" FieldName="AccessPlanNr" Width="10%" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, descriptioninfo %>" Name="AccessPlanDescription" FieldName="AccessPlanDescription" Width="90%" />
                    </Columns>
                </dx:ASPxComboBox>
                <asp:Button ID="btnSearch" runat="server" Text="" CssClass="searchzutarea" />

            </div>
            <div class="ControlSecarea3">
                <section class="leftDvns">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, accessplangroupinfo %>" CssClass="Gruppen1"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupNumber" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppen2" Style="margin-left: 0; width: 7.5%;"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, descriptioninfo %>" CssClass="Gruppen3" Style="margin-left: 8px;"></asp:Label>
                    <asp:TextBox ID="txtAccessGroupName" Enabled="false" ClientIDMode="Static" runat="server" CssClass="Gruppen4"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, planNo_new %>" CssClass="planGruppenf" Style="text-align: center; margin-left: 0; min-width: 103px;"></asp:Label>
                    <asp:TextBox ID="txtAccessProfileNumber" ClientIDMode="Static" runat="server" CssClass="Gruppenf"></asp:TextBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, descriptioninfo %>" CssClass="planGruppeng"></asp:Label>
                    <asp:TextBox ID="txtAccessProfileName" ClientIDMode="Static" runat="server" CssClass="Gruppeng"></asp:TextBox>
                    <span class="settings"></span>
                </section>
                <section class="rightDvns">
                    <asp:Button ID="btnPersonnel" runat="server" Text="<%$ Resources:localizedText, people %>" CssClass="newstandardbutton Personenbutton2"></asp:Button>
                    <span class="arrowpoint"></span>
                    <asp:Button ID="btnMembers" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="newstandardbutton memberbutton2"></asp:Button>
                    <span class="arrowpoint"></span>
                    <%--   <img src="../Images/FormImages/arrowpoint.png" Class="arrowpoint" />--%>
                    <asp:Button ID="btnReader" runat="server" Text="<%$ Resources:localizedText, reader %>" CssClass="newstandardbutton Leserbutton2"></asp:Button>
                    <span class="arrowpoint"></span>
                    <%--   <img src="../Images/FormImages/arrowpoint.png" Class="arrowpoint"/>--%>
                    <asp:Button ID="btnAccessProfile" runat="server" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="newstandardbutton Zutrittsprofilbutton2"></asp:Button>
                    <span class="arrowpoint"></span>
                    <%--       <img src="../Images/FormImages/arrowpoint.png" Class="arrowpoint"/>--%>
                    <asp:Button ID="btnHoliday" runat="server" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="newstandardbutton Zutrittsprofilbutton2holiday"></asp:Button>
                </section>
            </div>
        </div>
        <div class="MidContentAreaDiv">




            <div id="importantInfoDialog" class="dialogBox">
            </div>

            <div id="wrapperaccess1" class="wrapperaccess1newab">

                <section class="Wrapperaccessmain">
                    <section class="sectop">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, settingsaccessnew %>"></asp:Label>
                    </section>
                    <section class="secbottom">
                        <section class="personenarea">
                            <section class="zutplanebuttonarea">
                                <asp:Button runat="server" ID="btnPersonen" Text="<%$ Resources:localizedText, people %>" CssClass="Personenbutton"></asp:Button>
                            </section>
                            <section>

                                <asp:ImageButton runat="server" ID="imageBtnPersonen" class="Personenbackarea"></asp:ImageButton>

                            </section>
                        </section>
                        <section class="personenarea">
                            <section class="zutplanebuttonarea">
                                <asp:Button runat="server" ID="btnMember" Text="<%$ Resources:localizedText, member %>" CssClass="membersbtn"></asp:Button>
                            </section>
                            <section>

                                <asp:ImageButton runat="server" ID="btnImagemembers" class="membersareabtn"></asp:ImageButton>

                            </section>
                        </section>
                        <section class="leserarea">
                            <section class="zutplanebuttonarea">
                                <asp:Button runat="server" ID="btnReaderHeader" Text="<%$ Resources:localizedText, reader %>" CssClass="Leserbutton"></asp:Button>
                            </section>
                            <section>

                                <asp:ImageButton runat="server" ID="imageBtnReader" ClientIDMode="Static" class="Leserbackarea"></asp:ImageButton>

                            </section>
                        </section>
                        <section class="zutrittsprofilarea">
                            <section class="zutplanebuttonarea">
                                <asp:Button runat="server" ID="btnAccessCalederHeader" Text="<%$ Resources:localizedText, accessCalendar%>" CssClass="Zutrittsprofilbutton"></asp:Button>
                            </section>
                            <section>

                                <asp:ImageButton runat="server" ClientIDMode="Static" ID="imageBtnAccessCalender" class="Zutrittsprofilbackarea"></asp:ImageButton>

                            </section>

                        </section>
                        <section class="zutrittsprofilareanew">
                            <section class="zutplanebuttonarea">
                                <asp:Button runat="server" ID="btnHolidayCalenderHeader" Text="<%$ Resources:localizedText, holidaySchedule%>" CssClass="Zutrittsprofilbuttonholiday"></asp:Button>
                            </section>
                            <section>
                                <asp:ImageButton runat="server" ID="imageBtnHolidayCalender" class="Zutrittsprofilbackareanew"></asp:ImageButton>

                            </section>
                        </section>
                    </section>
                </section>

            </div>
            <section class="ControlGrid" style="display: none">

                <dx:ASPxGridView ID="grdAccessProfileList" runat="server" ClientInstanceName="grdAccessProfileList" Width="100%" Theme="Office2003Blue" AutoGenerateColumns="False" EnableTheming="True" EnableCallBacks="true" OnCustomCallback="grdAccessProfileList_CustomCallback" SettingsBehavior-AllowFocusedRow="True" SettingsBehavior-AllowSelectByRowClick="true" SettingsBehavior-AllowSelectSingleRowOnly="true" SettingsBehavior-ProcessFocusedRowChangedOnServer="true" KeyFieldName="id" SettingsBehavior-AllowSort="false" SettingsBehavior-AllowDragDrop="false">

                    <ClientSideEvents RowDblClick="function(s, e) {
grdProfilesRowDbClick(s,e);	
}"></ClientSideEvents>

                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="id">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, groupNo %>" VisibleIndex="1" FieldName="AccessGroupNumber" Width="3%"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, grpDescription %>" VisibleIndex="2" FieldName="AccessGroupName"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, profileDescptn %>" VisibleIndex="3" FieldName="AccessPlanNr" Width="3%"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, profileNo %>" VisibleIndex="4" FieldName="AccessPlanDescription"></dx:GridViewDataTextColumn>
                    </Columns>

                    <SettingsPager PageSize="20" ShowEmptyDataRows="True">
                    </SettingsPager>

                </dx:ASPxGridView>
            </section>
        </div>
        <div id="importantDialog" class="dialogBox">
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnEntNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, accessplannew %>" Style="width: 103px;" />
    <%--    <asp:Button ID="btnEntEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" OnClick="btnEntEdit_Click"  />--%>
    <asp:Button ID="btnEntSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, accessplansave %>" Style="width: 140px;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, accessplandelete %>" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
