<%@ Page Title="<%$ Resources:localizedText, accessProfileTitle %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="AccessProfile.aspx.cs" Inherits="Access_Control_NewMask.Content.AccessProfile" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/AccessProfile.js"></script>
    <link href="Styles/AccessProfile.css" rel="stylesheet" />
    <link href="Styles/ImportantInfoDialogAccessProfile.css" rel="stylesheet" />
    <link href="Styles/FormViewSearchAccPro.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldDeleteMode" runat="server" />
    <asp:HiddenField ID="hiddenFieldCurrentGroup" runat="server" />
    <asp:HiddenField ID="hiddenFieldFormMode" runat="server" Value="None" ClientIDMode="Static" />
    <div id="confirmDelete" class="dialogBox"></div>
    <div id="importantInfoDialog" class="dialogBox"></div>
    <div class="divMain">
        <div class="sectionTop">
            <section class="sectionTopLeft">
                <section class="secTopleftlabels" style="margin-bottom: 8px;">
                    <section class="secDivisions">
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:localizedText,grpProfNr1 %>" CssClass="lblTopSection2"></asp:Label>
                    </section>
                    <section class="secDivisions2">
                        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:localizedText,groupDescription1 %>" CssClass="lblTopSectionc"></asp:Label>
                    </section>
                    <section class="secDivisions3">
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:localizedText,profileNoTtl1 %>" CssClass="lblTopSection3"></asp:Label>
                    </section>
                    <section class="secMidTop">
                        <asp:Label ID="Label25" runat="server" Text="<%$ Resources:localizedText,profileId1 %>" CssClass="lblZutrtt"></asp:Label>
                    </section>
                    <section class="secDivisions4New">
                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:localizedText,profileDescptn1 %>" CssClass="lblTopSections"></asp:Label>
                    </section>
                    <section class="secDivisions5">
                        <asp:Label ID="Label9" runat="server" Text="<%$ Resources:localizedText,displayTenProfiles %>" CssClass="lblTopSectionsd"></asp:Label>
                    </section>
                </section>
                <section class="secTopleftDrpdwns">
                    <asp:ObjectDataSource ID="zuttritProfileObjectDataSource" runat="server" DataObjectTypeName="KruAll.Core.Models.ZuttritProfile" DeleteMethod="DeleteZuttritProfile" InsertMethod="CreateZuttritProfile" SelectMethod="ZuttritProfiles" TypeName="Access_Control.ViewModels.ZuttritProfileViewModel" UpdateMethod="UpdateZuttritProfile"></asp:ObjectDataSource>
                    <section class="secDivisions">
                        <dx:ASPxComboBox ID="ddlGroupProfileNo1" SelectedIndex="0" ClientInstanceName="ddlGroupProfileNo1" ClientIDMode="Static" runat="server" CssClass="drpDwnSecTophg" Theme="Office2003Blue" TextField="AccessGroupNumber" ValueField="ID"
                            TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">

                            <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlGroupProfileNoSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,grpProfNr %>" FieldName="AccessGroupNumber" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,groupDescription %>" FieldName="AccessGroupName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="secDivisions2">
                        <dx:ASPxComboBox ID="ddlGroupProfileDescription1" ClientInstanceName="ddlGroupProfileDescription1" ClientIDMode="Static" runat="server" CssClass="drpDwnSecTopoipu" TextField="AccessGroupName" ValueField="ID" Theme="Office2003Blue"
                            TextFormatString="{1}" SelectedIndex="0" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlGroupProfileDescription1SelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,grpProfNr %>" FieldName="AccessGroupNumber" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,groupDescription %>" FieldName="AccessGroupName" Width="80%" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="secDivisions3">
                        <dx:ASPxComboBox ID="ddlAccessProfileNo" ClientInstanceName="ddlAccessProfileNo" ClientIDMode="Static" runat="server" CssClass="drpDwnSecTopoi" TextField="AccessProfileNo" ValueField="ID" Theme="Office2003Blue"
                            TextFormatString="{0}" SelectedIndex="0" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="ddlAccessProfileNo_Callback" EnableCallbackMode="true">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
    ddlAccessProfileNoSelectedIndexChanged(s.GetValue());
}"
                                EndCallback="function(s, e) {
	ddlAccessProfileNoEndCallback(s,e);
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileNoTtl %>" FieldName="AccessProfileNo" Width="20%" />
                                <dx:ListBoxColumn Caption="Profil ID" FieldName="AccessProfileID" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileDescptn %>" FieldName="AccessDescription" Width="60%" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="topSecmid">
                        <dx:ASPxComboBox ID="ddlAccessProfileID" ClientInstanceName="ddlAccessProfileID" ClientIDMode="Static" runat="server" CssClass="drpZutrttID" TextField="AccessProfileID" ValueField="ID" Theme="Office2003Blue"
                            TextFormatString="{1}" SelectedIndex="0" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="ddlAccessProfileID_Callback" EnableCallbackMode="true">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlAccessProfileIDSelectedIndexChanged(s.GetValue());
                                        }"
                                EndCallback="function(s, e) {
ddlAccessProfileIDEndCallBack(s,e);	
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileNoTtl %>" FieldName="AccessProfileNo" Width="20%" />
                                <dx:ListBoxColumn Caption="Profil ID" FieldName="AccessProfileID" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileDescptn %>" FieldName="AccessDescription" Width="60%" />
                            </Columns>
                        </dx:ASPxComboBox>

                    </section>
                    <section class="secDivisions4">

                        <dx:ASPxComboBox ID="ddlAccessDescription" ClientInstanceName="ddlAccessDescription" ClientIDMode="Static" runat="server" CssClass="drpDwnSecTop3" TextField="AccessDescription" ValueField="ID" Theme="Office2003Blue"
                            TextFormatString="{2}" SelectedIndex="0" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" OnCallback="ddlAccessDescription_Callback" EnableCallbackMode="true">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) {ddlAccessDescriptionSelectedIndexChanged(s.GetValue());}" EndCallback="function(s, e) {
	ddlAccessDescriptionEndCallBack(s,e);
}"></ClientSideEvents>
                            <Columns>
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileNoTtl %>" FieldName="AccessProfileNo" Width="20%" />
                                <dx:ListBoxColumn Caption="Profil ID:" FieldName="AccessProfileID" Width="20%" />
                                <dx:ListBoxColumn Caption="<%$ Resources:localizedText,profileDescptn %>" FieldName="AccessDescription" Width="60%" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </section>
                    <section class="secDivisions5bttm">
                        <asp:CheckBox ID="chkDisplayProfiles" runat="server" CssClass="chkbox" />
                    </section>
                </section>
            </section>
            <section class="sectionTopRight" style="display: none;">
                <section class="empFormViewNav">
                    <section class="fvNavSearch">
                        <asp:Label ID="lblSearchAllEmp" runat="server" Text="<%$ Resources:localizedText, search %>" />
                        <asp:Button ID="btnSearchProfiles" runat="server" Text="" CssClass="searchAllEmp" />
                    </section>
                    <section class="fvNavPrevious">
                        <span></span>
                        <asp:Button ID="fvNavPrev" runat="server" Text="" CssClass="btnFvNavPrev" />
                        <%--OnClick="fvNavPrev_Click" --%>
                    </section>
                    <section class="fvNavCurrentEmpNum">
                        <asp:Label ID="lblFvCurrentEntry" Text="<%$ Resources:localizedText, pos %>" runat="server" />
                        <asp:TextBox ID="txtFvCurrentEntry" runat="server" Width="96%" Enabled="false" />
                    </section>
                    <section class="fvNavTotalEmpNum">
                        <asp:Label ID="lblFvTotalEntries" Text="<%$ Resources:localizedText, num %>" runat="server" />
                        <asp:TextBox ID="txtFvTotalEntries" runat="server" Width="96%" Enabled="false" />
                    </section>
                    <section class="fvNavNext">
                        <span></span>
                        <asp:Button ID="fvNavNext" runat="server" Text="" CssClass="btnFvNavNext" />
                        <%--OnClick="fvNavNext_Click"--%>
                    </section>
                </section>
            </section>
        </div>

        <div class="sectionBottom">
            <section class="secBottomLeft">
                <section class="top1Left">
                    <section class="secTopleftlabels">
                        <section class="secLablesDivisions">
                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText,grpProfNr1 %>" CssClass="lblgrpPrflNo"></asp:Label>
                        </section>
                        <section class="secLablesDivisions2">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText,groupDescription1 %>" CssClass="lblgrpPrfldesc"></asp:Label>
                        </section>
                        <section class="secLablesDivisions3">
                            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText,profileNoTtl1 %>" CssClass="lblaccsPrflNo"></asp:Label>
                        </section>
                        <section class="secLablesDivisions">
                            <asp:Label ID="Label26" runat="server" Text="<%$ Resources:localizedText,profileId1 %>" CssClass="lblZtrt"></asp:Label>
                        </section>
                        <section class="secLablesDivisions42">
                            <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText,profileDescptn1 %>" CssClass="lblaccsdsc"></asp:Label>
                        </section>
                        <asp:Label ID="Label27" runat="server" Text="<%$ Resources:localizedText,foreColor %>" CssClass="lblColorOne"></asp:Label>
                        <asp:Label ID="Label28" runat="server" Text="<%$ Resources:localizedText,backColor %>" CssClass="lblColorTwo"></asp:Label>
                        <asp:Label ID="Label29" runat="server" Text="<%$ Resources:localizedText,sample %>" CssClass="lblSampleText"></asp:Label>
                    </section>
                    <section class="secToplefttextboxes">
                        <section class="secLablesDivisions">
                            <asp:TextBox ID="txtGroupProfileNo1" ReadOnly="true" runat="server" CssClass="drpDwnSecTop"></asp:TextBox>
                        </section>
                        <section class="secLablesDivisions2">
                            <asp:TextBox ID="txtGroupProfileDescription1" ReadOnly="true" runat="server" CssClass="txtSecTop1"></asp:TextBox>
                        </section>
                        <section class="secLablesDivisions3">
                            <asp:TextBox ID="txtAccessProfileNo" runat="server" CssClass="drpDwnSecTopssd"></asp:TextBox>
                            <%--CssClass="txtSecTop2"--%>
                        </section>
                        <section class="secLablesDivisions">
                            <asp:TextBox ID="txtAccessProfileID" runat="server" CssClass="txtZutrttID maxlength4"></asp:TextBox>
                            <%--CssClass="txtSecTop2"--%>
                        </section>
                        <section class="secLablesDivisions4">
                            <asp:TextBox ID="txtAccessDescription" runat="server" CssClass="txtSecTop1dsds"></asp:TextBox>
                            <%--CssClass="txtSecTop4"--%>
                        </section>
                        <dx:ASPxColorEdit ID="ASPxColorEditForeColor" runat="server" AllowUserInput="false" Theme="Office2003Blue" CssClass="colorEditOne" EnableCustomColors="true">
                            <ColorIndicatorStyle CssClass="colorIndicator"></ColorIndicatorStyle>
                            <ClientSideEvents ColorChanged="function(s, e) {
	ColorChangedHandler(s,e)
}"></ClientSideEvents>

                            <%--  <DropDownButton Text="..."></DropDownButton>--%>
                            <DropDownButton Image-Url="../Images/FormImages/paint-brush.png"></DropDownButton>
                        </dx:ASPxColorEdit>
                        <dx:ASPxColorEdit ID="ASPxColorEditBackColor" runat="server" AllowUserInput="false" Theme="Office2003Blue" CssClass="colorEditTwo" EnableCustomColors="True">
                            <ColorIndicatorStyle CssClass="colorIndicator"></ColorIndicatorStyle>
                            <ClientSideEvents ColorChanged="function(s, e) {
	ColorChangedHandler(s,e)
}"></ClientSideEvents>
                            <%--<DropDownButton Text="..."></DropDownButton>--%>
                            <DropDownButton Image-Url="../Images/FormImages/paint-brush.png"></DropDownButton>
                        </dx:ASPxColorEdit>
                        <asp:TextBox ID="txtSampleText" runat="server" Text="TEXT" Font-Size="18px" CssClass="txtColorSmple"></asp:TextBox>
                        <%--                         <section class="secLablesDivisions"></section>--%>
                    </section>
                </section>
                <section class="sectionGrid">
                    <asp:ObjectDataSource ID="grdZuttritProfileTimeFramesObjectDataSource" runat="server" DataObjectTypeName="KruAll.Core.Models.ZuttritProfilesTimeFrame" DeleteMethod="DeleteZuttritProfilesTimeFrame" InsertMethod="CreateZuttritProfilesTimeFrame" SelectMethod="ZuttritProfilesTimeFrames" TypeName="Access_Control.ViewModels.ZuttritProfilesTimeFrameViewModel" UpdateMethod="UpdateZuttritProfilesTimeFrame"></asp:ObjectDataSource>
                    <asp:Table runat="server" ID="tableHeader" CssClass="tableRowMain" CellPadding="0" CellSpacing="0">
                        <asp:TableHeaderRow CssClass="tableRow">
                            <asp:TableCell CssClass="tableCell1">
                                <asp:Label ID="Label24" runat="server" Text="<%$ Resources:localizedText,activeProfile %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label11" runat="server" Text="<%$ Resources:localizedText,mon %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:localizedText,tue %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:localizedText,wed %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label17" runat="server" Text="<%$ Resources:localizedText,thur %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label18" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label19" runat="server" Text="<%$ Resources:localizedText,fri %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label20" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label21" runat="server" Text="<%$ Resources:localizedText,sat %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label22" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="tableCell">
                                <asp:Label ID="Label23" runat="server" Text="<%$ Resources:localizedText,sun %>"></asp:Label>
                            </asp:TableCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <dx:ASPxGridView ID="grdZuttritProfileTimeFrames" runat="server" AutoGenerateColumns="False" UseDisabledStatePainter="false" SettingsBehavior-AllowSort="false" Theme="Office2003Blue" CssClass="grid" Width="100%" ClientInstanceName="grdZuttritProfileTimeFrames" KeyFieldName="ID" OnCustomJSProperties="grdZuttritProfileTimeFrames_CustomJSProperties" OnCustomCallback="grdZuttritProfileTimeFrames_CustomCallback" ForeColor="Black">
                        <ClientSideEvents EndCallback="function(s, e) {
	checkDisplayStatus();
}" />
                        <Columns>
                            <dx:GridViewDataCheckColumn VisibleIndex="4" Caption="<%$ Resources:localizedText,all %>" Width="9.5%" FieldName="ProfilAktiv">
                                <PropertiesCheckEdit EnableClientSideAPI="True">
                                    <ClientSideEvents CheckedChanged="function(s, e) {
	activateProfile(s, e);
}" />
                                </PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>

                            <%--<dx:GridViewCommandColumn Caption="<%$ Resources:localizedText,all %>" ShowSelectCheckbox="True" Width="9.5%" ShowClearFilterButton="True" VisibleIndex="4" />--%>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="MonFrom" VisibleIndex="6" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="MonTo" VisibleIndex="8" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="TueFrom" VisibleIndex="10" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="TueTo" VisibleIndex="12" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="WedFrom" VisibleIndex="14" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>

                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="WedTo" VisibleIndex="16" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="ThurFrom" VisibleIndex="18" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="ThurTo" VisibleIndex="20" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="FriFrom" VisibleIndex="22" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="FriTo" VisibleIndex="24" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,fromScm %>" FieldName="SatFrom" VisibleIndex="26" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
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
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTimeEditColumn Caption="<%$ Resources:localizedText,toScm %>" FieldName="SunTo" VisibleIndex="31" Width="6%">
                                <PropertiesTimeEdit DisplayFormatString="HH:mm">
                                    <ClientSideEvents ValueChanged="function (s, e) { timeFramesChanged(s,e) }" />
                                    <SpinButtons Enabled="False" ShowIncrementButtons="False">
                                    </SpinButtons>
                                </PropertiesTimeEdit>
                            </dx:GridViewDataTimeEditColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" Visible="False" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowDragDrop="false" AllowSort="false" />
                        <SettingsPager PageSize="15" ShowEmptyDataRows="True" Mode="ShowAllRecords" Visible="False">
                        </SettingsPager>
                        <SettingsEditing EditFormColumnCount="20" Mode="Batch">
                            <BatchEditSettings ShowConfirmOnLosingChanges="False" />
                        </SettingsEditing>
                        <Settings ShowStatusBar="Hidden" />
                        <SettingsDetail ShowDetailButtons="False" />
                        <SettingsDataSecurity AllowDelete="False" />
                    </dx:ASPxGridView>
                </section>
                <section class="sectionMemo">
                    <section class="secMemoHeader">
                        <asp:Label ID="lblMemo" runat="server" Text="<%$ Resources:localizedText,memonew %>" CssClass="lblMemo"></asp:Label>
                    </section>
                    <section class="secMemo">
                        <asp:TextBox ID="txtMemoNotes" runat="server" CssClass="txtMemo" TextMode="MultiLine"></asp:TextBox>
                    </section>
                </section>
            </section>
            <section class="secBottomRight">
                <dx:ASPxGridView ID="grdAccessProfileList" runat="server" SettingsBehavior-AllowSort="false" AutoGenerateColumns="False" Theme="Office2003Blue" Width="100%" ClientInstanceName="grdAccessProfileList" KeyFieldName="ID" OnCustomCallback="grdAccessProfileList_CustomCallback">
                    <ClientSideEvents RowDblClick="function(s, e) {
	LoadProfileTimeFrames(s, e);
}"
                        RowClick="function(s, e) {
	LoadProfileTimeFrames(s, e);
}" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText,grpProfNr1 %>" VisibleIndex="1" FieldName="GroupNo">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="12%" Caption="<%$ Resources:localizedText,groupDescription1 %>" VisibleIndex="2" FieldName="GroupDescription">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText,profileNoTtl1 %>" VisibleIndex="3" FieldName="AccessProfileNo">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="12%" Caption="<%$ Resources:localizedText,profileDescptn1 %>" VisibleIndex="4" FieldName="AccessDescription">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" Caption="Pofil ID:" VisibleIndex="5" FieldName="AccessProfileID">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="30" ShowEmptyDataRows="True">
                    </SettingsPager>
                    <SettingsBehavior AllowSelectSingleRowOnly="False" AllowSelectByRowClick="True" AllowDragDrop="false" AllowSort="True"></SettingsBehavior>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="false" AllowInsert="false" />
                </dx:ASPxGridView>
            </section>
        </div>
        <div class="secSearchProfiles" style="display: none;">
            <dx:ASPxGridView ID="grdSearchProfiles" runat="server" ClientInstanceName="grdSearchProfiles" Theme="Office2003Blue" Width="100%" ClientIDMode="Static" AutoGenerateColumns="False" KeyFieldName="ID" OnCustomCallback="grdSearchProfiles_CustomCallback">
                <%--   <ClientSideEvents RowClick="function(s, e) {
	grdSearchProfilesRowClick(s,e);
}"></ClientSideEvents>--%>
                <ClientSideEvents RowClick="function(s, e) {
	LoadProfileTimeFrames(s, e)
grdSearchProfilesRowClick(s, e)
}"></ClientSideEvents>
                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="6%" Caption="<%$ Resources:localizedText,grpProfNr %>" VisibleIndex="1" FieldName="GroupNo">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="44%" Caption="Gr.Bezeichnung" VisibleIndex="2" FieldName="GroupDescription">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="6%" Caption="<%$ Resources:localizedText,profileNo %>" VisibleIndex="3" FieldName="AccessProfileNo">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Width="44%" Caption="<%$ Resources:localizedText,profileDescription %>" VisibleIndex="4" FieldName="AccessDescription">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Profil ID" Visible="false" VisibleIndex="5" FieldName="AccessProfileID">
                        <CellStyle HorizontalAlign="Left"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <%-- AccessProfileID --%>
                </Columns>
                <SettingsPager ShowEmptyDataRows="true" PageSize="25" Visible="False"></SettingsPager>
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                <SettingsBehavior AllowFocusedRow="True" AllowSort="False" AllowDragDrop="False" AllowGroup="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnEntNew" CssClass="newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, accesspronew %>" Style="width: 117px !important;" />
    <%-- <asp:Button ID="btnEntEdit" CssClass="BottomFooterBtnsLeft btnEdit" runat="server" Text="<%$ Resources:localizedText, editing %>" />--%>
    <asp:Button ID="btnEntSave" CssClass="savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, accessprosave %>" Style="width: 150px !important;" />
    <asp:Button ID="btnCancelDel" CssClass="deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, accessprodelete %>" Style="width: 140px !important; text-align: left !important;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
