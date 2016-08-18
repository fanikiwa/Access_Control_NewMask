<%@ Page Title="Studio Gruppen" Language="C#" ClientIDMode="Static" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="MembersGroup.aspx.cs" Inherits="Access_Control_NewMask.Content.MembersGroup" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/MembersGroup.js"></script>
    <link href="Styles/MembersGroup.css" rel="stylesheet" />
    <script type="text/javascript">
        function __promptWarning(text) {
            if (text.trim() != "") $("#__WarningPrompt > .secPromptMsg").text(text);
            $("#promptsPlaceHolder, #__WarningPrompt").show();
        }
        function __hidePromptWarning() {
            $("#promptsPlaceHolder, #__WarningPrompt").hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="ImportantDialogBox"></div>
    <asp:HiddenField ID="HiddenField1BackValue" runat="server" />
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <div class="topDvn">
        <section class="secLeftTop">
            <section class="secLeftTopL">
                <asp:Label ID="lblCustomerNr" runat="server" CssClass="lblsec2Tsd" Text="<%$ Resources:localizedText, studiogrpno %>"></asp:Label>
                <dx:ASPxComboBox ID="cboGroupNr" runat="server" ClientInstanceName="cboGroupNr" ValueField="Id" TextField="GroupNr" CssClass="ddlist2Tasad" HorizontalAlign="left" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                    EnableCallbackMode="true" SelectedIndex="0" Theme="Office2003Blue" TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" OnCallback="cboGroupNr_Callback">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboGroupNrSelectedIndexChanged(s.GetValue());}"
                        EndCallback="function(s, e) {
	cboGroupNrEndCallback();
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Width="20%" FieldName="GroupNr" />
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" Width="80%" FieldName="GroupName" />
                    </Columns>
                </dx:ASPxComboBox>
            </section>
            <section class="secLeftTopR3">
                <asp:Label ID="lblClientName" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, description1 %>"></asp:Label>
                <dx:ASPxComboBox ID="cboGroupDescrptn" runat="server" ClientInstanceName="cboGroupDescrptn" CssClass="ddlistT2" Theme="Office2003Blue" OnCallback="cboGroupDescrptn_Callback"
                    TextFormatString="{1}" DropDownWidth="480px" SelectedIndex="0" DropDownRows="20" ValueField="Id" TextField="GroupName" EnableCallbackMode="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">

                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboGroupDescrptnSelectedIndexChanged(s.GetValue());	
}"
                        EndCallback="function(s, e) {
	cboGroupDescriptionEndCallback();
}"></ClientSideEvents>
                    <Columns>
                        <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" Width="20%" FieldName="GroupNr" />
                        <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, description1 %>" Width="80%" FieldName="GroupName" />
                    </Columns>
                </dx:ASPxComboBox>
            </section>
        </section>
    </div>
    <div class="dvnBttm">
        <div class="groupareamain">
            <section class="grouptitle">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, groupNo4 %>" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtGroupNr" runat="server" CssClass="txtGrpNr"></asp:TextBox>
            </section>
            <section class="groupsubtitle">
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, groupdescriptionnew %>" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtGroupDescription" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
            </section>
            <section class="grouptitleduration">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, personresponsiblenew %>" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtPersonHead" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnSearchEmp" runat="server" Text="" CssClass="trainerdata" />
            </section>
            <section class="groupttrainer1">
                <asp:Label ID="Label4" runat="server" Text="1.  Trainer:" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtTrainerOne" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnTrainerOne" runat="server" Text="" CssClass="trainerdata" />
            </section>
            <section class="groupttrainer2">
                <asp:Label ID="Label5" runat="server" Text="2.  Trainer:" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtTrainerTwo" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnTrainerTwo" runat="server" Text="" CssClass="trainerdata" />
            </section>
            <section class="groupttrainer3">
                <asp:Label ID="Label6" runat="server" Text="3.  Trainer:" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtTrainerThree" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnTrainerThree" runat="server" Text="" CssClass="trainerdata" />
            </section>
            <section class="groupttrainer4">
                <asp:Label ID="Label7" runat="server" Text="4.  Trainer:" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtTrainerFour" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnTrainerFour" runat="server" Text="" CssClass="trainerdata" />
            </section>
            <section class="groupttrainer5">
                <asp:Label ID="Label8" runat="server" Text="5.  Trainer:" CssClass="trainerlbl"></asp:Label>
                <asp:TextBox ID="txtTrainerFive" runat="server" CssClass="txtGrpNrDescrptn"></asp:TextBox>
                <asp:Button ID="btnTrainerFive" runat="server" Text="" CssClass="trainerdata" />
            </section>
        </div>
        <div class="groupareagrid">
            <dx:ASPxGridView ID="grdGroups" runat="server" ClientInstanceName="grdGroups" KeyFieldName="Id" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                AutoGenerateColumns="False" Width="100%" SettingsPager-PageSize="18" OnCustomCallback="grdGroups_CustomCallback">
                <ClientSideEvents RowDblClick="function(s, e) {
	grdGroupsDblClick(s,e);
}"></ClientSideEvents>

                <SettingsPager PageSize="18" ShowEmptyDataRows="True" Visible="False"></SettingsPager>

                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" FieldName="Id" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="left" FieldName="GroupNr" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" VisibleIndex="1" Width="15%" Caption="<%$ Resources:localizedText, groupNo4 %>">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="left" FieldName="GroupName" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" VisibleIndex="2" Caption="<%$ Resources:localizedText, description1 %>" Width="45%">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="left" FieldName="PersonHead" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" VisibleIndex="3" Caption="<%$ Resources:localizedText, personresponsiblenew %>" Width="40%">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="true" ProcessFocusedRowChangedOnServer="false" />
            </dx:ASPxGridView>
        </div>
        <section class="btngroupareagrid">
            <asp:Button ID="btnAcceptGroup" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="ubernahme" />
            <%--<a href="AccessPlanMembers.aspx">AccessPlanMembers.aspx</a>--%>
        </section>
    </div>

    <div class="searchOne" style="display: none;">
        <section class="gridSection">
            <dx:ASPxGridView ID="grdPersonal" runat="server" ClientInstanceName="grdPersonal" KeyFieldName="ID" Theme="Office2003Blue" AutoGenerateColumns="False" Width="100%">

                <ClientSideEvents RowDblClick="function(s, e) {
	grdPersonalRowDblClick(s, e);
}"></ClientSideEvents>

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="Center" Caption="<%$ Resources:localizedText, persNo_new %>" VisibleIndex="1" FieldName="Pers_Nr" Width="20%">
                        <CellStyle HorizontalAlign="Center"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstname_new %>" VisibleIndex="2" FieldName="FirstName" Width="40%"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, LastName1 %>" VisibleIndex="3" FieldName="LastName" Width="40%"></dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPager Visible="False" PageSize="34" ShowEmptyDataRows="True"></SettingsPager>
                <SettingsBehavior AllowSort="false" AllowFocusedRow="true" />
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            </dx:ASPxGridView>
        </section>
        <section class="ApplyButtonSection">
            <asp:Button ID="btnApplyPers" runat="server" Text="<%$ Resources:localizedText, takeover %>" CssClass="ubernahme" />
        </section>
    </div>
    <div id="importantDialog" class="dialogBox">
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="bottomgroup">
        <asp:Button ID="btnNew" runat="server" Text="<%$ Resources:localizedText, newstudiogroup %>" CssClass="newbtnfooterblue" />
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:localizedText, savestudiogroup %>" CssClass="savebtnfootergreen" />
        <asp:Button ID="btnDelete" runat="server" Text="<%$ Resources:localizedText, deletestudiogroup %>" CssClass="deletebtnfooterred" />
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
