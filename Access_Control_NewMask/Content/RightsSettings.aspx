<%@ Page Title="<%$ Resources:localizedText, rightsSettings %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="RightsSettings.aspx.cs" Inherits="Access_Control_NewMask.Content.RightsSettings" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/RightsSettings.css" rel="stylesheet" />
    <script src="Scripts/RightsSettings.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div id="secWrapper">
        <div class="divsionOne">
            <section class="clasOne">
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, employeeNr %>" CssClass="lblPersNr"></asp:Label>
                <dx:ASPxComboBox ID="cmbPrsNrr" runat="server" CssClass="ddlPrsNr" Theme="Office2003Blue" TextFormatString="{0}"
                    DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    <ClientSideEvents SelectedIndexChanged="function (s, e) {
    cmbPrsNrrIndexChanged();
}" />
                    <Columns>
                        <dx:ListBoxColumn FieldName="Pers_Nr" Name="Pers. Nr." Width="10%" Caption="Pers. Nr.:" ToolTip="Pers. Nr."></dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Fullname" Name="Name" Width="90%" Caption="Name:" ToolTip="Name"></dx:ListBoxColumn>
                    </Columns>
                </dx:ASPxComboBox>
                <%--<asp:DropDownList ID="ddlPrsNrr" runat="server" CssClass="ddlPrsNr"></asp:DropDownList>--%>
                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, employee2 %>" CssClass="lbStaff"></asp:Label>
                <dx:ASPxComboBox ID="cmbEmployee" runat="server" CssClass="ddlPrsNr2" Theme="Office2003Blue" TextFormatString="{1}"
                    DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    <ClientSideEvents SelectedIndexChanged="function (s, e) {
    cmbEmployeeIndexChanged();
}" />
                    <Columns>
                        <dx:ListBoxColumn FieldName="Pers_Nr" Name="Pers. Nr." Width="10%" Caption="Pers. Nr.:" ToolTip="Pers. Nr."></dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="Fullname" Name="Name" Width="90%" Caption="Name:" ToolTip="Name"></dx:ListBoxColumn>
                    </Columns>
                </dx:ASPxComboBox>
                <%--  <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="ddlPrsNr2" ></asp:DropDownList>--%>
                <asp:Button ID="btnSearchEmpNr" ClientIDMode="Static" runat="server" Text="" CssClass="btnsearch btnSearchNew" />

            </section>
            <section class="clasOne">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, rightNr %>" CssClass="lblRightNr"></asp:Label>
                <dx:ASPxComboBox ID="cmbRightNr" runat="server" ValueType="System.String" CssClass="ddlRightNr" Theme="Office2003Blue" TextFormatString="{0}"
                    DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    <ClientSideEvents SelectedIndexChanged="function (s, e) {
    cmbRightNrIndexChanged();
}" />
                    <Columns>
                        <dx:ListBoxColumn FieldName="ProfileNr" Name="Nr." Width="10%" Caption="Nr.:" ToolTip="Nr."></dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="ProfileDescription" Name="Bezeichnung" Width="90%" Caption="Bezeichnung:" ToolTip="ProfileDescription"></dx:ListBoxColumn>
                    </Columns>
                </dx:ASPxComboBox>
                <%--  <asp:DropDownList ID="ddlRightNr" ClientIDMode="Static" runat="server"  CssClass="ddlRightNr"></asp:DropDownList>--%>
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, descriptionnew %>" CssClass="lblDscptn"></asp:Label>
                <dx:ASPxComboBox ID="cmbRightDescription" runat="server" ValueType="System.String" CssClass="ddlDscptn" Theme="Office2003Blue" TextFormatString="{1}"
                    DropDownWidth="500px" DropDownRows="20" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                    <ClientSideEvents SelectedIndexChanged="function (s, e) {
    cmbRightDescriptionIndexChanged();
}" />
                    <Columns>
                        <dx:ListBoxColumn FieldName="ProfileNr" Name="Nr." Width="10%" Caption="Nr.:" ToolTip="Nr."></dx:ListBoxColumn>
                        <dx:ListBoxColumn FieldName="ProfileDescription" Name="Bezeichnung" Width="90%" Caption="Bezeichnung:" ToolTip="ProfileDescription"></dx:ListBoxColumn>
                    </Columns>
                </dx:ASPxComboBox>
                <%--   <asp:DropDownList ID="ddlRightDescription" ClientIDMode="Static"  runat="server" CssClass="ddlDscptn"></asp:DropDownList>--%>
                <asp:Button ID="btnSearchRightNr" ClientIDMode="Static" runat="server" Text="" CssClass="btnsearchRightNr btnSearchNew" />
            </section>
        </div>
        <div class="divsionTwo">
            <section class="secPassSettings">
                <section class="classTwotop">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText, newPassword %>" CssClass="lblNewPass"></asp:Label>
                    <asp:TextBox ID="txtNewPass" runat="server" CssClass="txtNewPass" TextMode="Password" Type="password"></asp:TextBox>
                </section>
                <section class="classthree">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText, repeatNewPassword %>" CssClass="lblNewPassRepeat"></asp:Label>
                    <asp:TextBox ID="txtRepeatPass" runat="server" CssClass="txtNewPassRepeat" TextMode="Password" Type="password"></asp:TextBox>
                </section>
                <section class="classfour">
                    <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText, activedirectory %>" CssClass="lblNewPassRepeat"></asp:Label>
                    <asp:CheckBox ID="chkUseAD" runat="server" CssClass="activearea" />
                </section>
                <section class="classTwo">
                    <asp:Label ID="Label8" runat="server" Text="Active Directory Benutzername:" CssClass="lblNewPassRepeat"></asp:Label>
                    <asp:TextBox ID="txtADUsername" runat="server" CssClass="txtNewPassRepeat"></asp:TextBox>
                </section>
                <section class="classTwo">
                    <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText, connectionlinks %>" CssClass="lblNewPassRepeat"></asp:Label>
                    <asp:TextBox ID="txtADPath" runat="server" CssClass="txtNewPassRepeat"></asp:TextBox>
                </section>
                <section class="classTwo">
                    <asp:Label ID="Label10" runat="server" Text="Domäne:" CssClass="lblNewPassRepeat"></asp:Label>
                    <asp:TextBox ID="txtADController" runat="server" CssClass="txtNewPassRepeat"></asp:TextBox>
                </section>
            </section>
        </div>
        <div class="divsionThree" style="display: none;">
            <section class="secCenterAlgn">
                <asp:Button ID="Button1" CssClass="BottomFooterBtnsLeft btnNew" runat="server" Text="<%$ Resources:localizedText, newButton %>" />
                <asp:Button ID="Button2" CssClass="BottomFooterBtnsLeft btnSave" runat="server" Text="<%$ Resources:localizedText, saveButton %>" />
                <asp:Button ID="Button3" CssClass="BottomFooterBtnsLeft btnLöschen" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
            </section>

        </div>
    </div>
    <div id="searchPersonal" style="display: none;" class="searchWrapper">

        <dx:ASPxGridView ID="grdVwPersonal" runat="server" Width="100%" KeyFieldName="Pers_Nr" SettingsBehavior-AllowSort="false" Theme="Office2003Blue" AutoGenerateColumns="False"
            EnableTheming="True">
            <ClientSideEvents RowDblClick="function (s, e) {
    grdVwPersonalRowDblClick(s, e);
}" />
            <Columns>
                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personnelNo2 %>" VisibleIndex="1" FieldName="Pers_Nr">
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, identification %>" VisibleIndex="2" FieldName="IdentificationNr_string">
                    <CellStyle HorizontalAlign="Left"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, lastName %>" VisibleIndex="3" FieldName="LastName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstName %>" VisibleIndex="4" FieldName="FirstName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location2 %>" VisibleIndex="5" FieldName="LocationName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, depatmentTitle %>" VisibleIndex="6" FieldName="DepartmentName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costcenter2%>" VisibleIndex="7" FieldName="CostCenterName">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn Caption="<%$ Resources:localizedText, selection%>" Visible="false" ShowSelectCheckbox="True" ShowClearFilterButton="True" VisibleIndex="8" />

            </Columns>

            <SettingsPager ShowEmptyDataRows="true" Mode="ShowAllRecords" Visible="False"></SettingsPager>
            <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        </dx:ASPxGridView>
    </div>
    <div id="rightsSearch" style="display: none;" class="rightsSearch">

        <dx:ASPxGridView ID="grdVwRightsNrSearch" runat="server" ClientInstanceName="grdVwRightsNrSearch" SettingsBehavior-AllowSort="false" Width="100%" KeyFieldName="ID" AutoGenerateColumns="False" Theme="Office2003Blue" EnableTheming="True">

            <ClientSideEvents RowDblClick="function(s, e) {
	grdVwRightsNrSearchRowDblClick(s, e)
}"></ClientSideEvents>
            <Columns>
                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn HeaderStyle-HorizontalAlign="left" Caption="<%$ Resources:localizedText, rightNo %>" FieldName="ProfileNr" Width="4%" VisibleIndex="1">
                    <CellStyle HorizontalAlign="left"></CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, descriptionnew %>" Width="18%" FieldName="ProfileDescription" VisibleIndex="2"></dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="false" AllowSort="false" />
            <SettingsPager ShowEmptyDataRows="true" PageSize="16" Visible="False"></SettingsPager>

            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        </dx:ASPxGridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <section class="secCenterAlgn">
        <asp:Button ID="btnNew" CssClass="newbtnfooterblue  " runat="server" Text="<%$ Resources:localizedText, newButton %>" Style="width: 38px;" OnClick="btnNew_Click" />
        <asp:Button ID="btnSave" CssClass=" savebtnfootergreen  " runat="server" Text="<%$ Resources:localizedText, saveButton %>" Style="width: 74px;" OnClick="btnSave_Click" />
        <asp:Button ID="btnDelete" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" Style="width: 63px;" Enabled="false" />
    </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">

    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
