<%@ Page Title="<%$ Resources:localizedText, visitorCompany %>" Language="C#" ClientIDMode="Static" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="VisitorCompany.aspx.cs" Inherits="Access_Control_NewMask.Content.VisitorCompany" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/VisitorCompany.css" rel="stylesheet" />
    <script src="Scripts/VisitorCompany.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="saveChangesonNew" ClientIDMode="Static" runat="server" />
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTop">
                <section class="secLeftTopL">
                    <asp:Label ID="lblCustomerNr" runat="server" CssClass="lblsec2Tsd" Text="<%$ Resources:localizedText, visitorcompanyno1 %>"></asp:Label>
                    <dx:ASPxComboBox ID="cboCustomerNr" runat="server" ClientInstanceName="cboCustomerNr" CssClass="ddlist2Tasad" HorizontalAlign="left" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px"
                        EnableCallbackMode="true" Theme="Office2003Blue" ValueField="ID" SelectedIndex="0" TextField="CompanyNr" TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" OnCallback="cboCustomerNr_Callback">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboCustomerNrSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                            <dx:ListBoxColumn Caption=" <%$ Resources:localizedText, company %>" FieldName="CompanyName" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
                <section class="secLeftTopR3">
                    <asp:Label ID="lblClientName" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, visitCompany %>"></asp:Label>
                    <dx:ASPxComboBox ID="cboClientName" runat="server" ClientInstanceName="cboClientName" CssClass="ddlistT2" Theme="Office2003Blue" ValueField="ID" TextField="CompanyName" OnCallback="cboClientName_Callback"
                        TextFormatString="{1}" DropDownWidth="480px" DropDownRows="20" SelectedIndex="0" EnableCallbackMode="true" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboClientNameSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, no2 %>" FieldName="CompanyNr" Width="20%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, company %>" FieldName="CompanyName" Width="80%" />
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
                                    <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, visitorcompanyno1 %>"></asp:Label>
                                    <asp:TextBox ID="txtClientNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblCustomerData" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, visitCompany %>"></asp:Label>
                                    <asp:TextBox ID="txtClientName" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblPlz" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, zipCode2 %>"></asp:Label>
                                    <asp:TextBox ID="txtPLZ" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblOrt" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                    <asp:TextBox ID="txtOrt" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblStreet" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" runat="server" CssClass="txtsec"></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="Label4" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, housenum %>"></asp:Label>
                                    <asp:TextBox ID="txtHouseNr" runat="server" CssClass="txtsec2"></asp:TextBox>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblState" runat="server" CssClass="lblsecnew" Text="<%$ Resources:localizedText, state2 %>"></asp:Label>
                                    <dx:ASPxComboBox ID="cboState" CssClass="bunddlist" Theme="Aqua" runat="server" ValueField="ID" TextField="StateName"
                                        SelectedIndex="0" ValueType="System.String" DropDownRows="20" DropDownWidth="300px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                                    </dx:ASPxComboBox>
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
                                        <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
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
                                    <asp:Label ID="lblMemo" runat="server" CssClass="lblheader" Text="Memo:"></asp:Label>
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
                        <dx:ASPxGridView ID="grdVisitorCompany" ClientInstanceName="grdVisitorCompany" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"
                            EnableTheming="True" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px" Theme="Office2003Blue" Width="100%" OnCustomCallback="grdVisitorCompany_CustomCallback">
                            <ClientSideEvents RowClick="function(s, e) {
 grdVisitorCompanyRowClick(s, e)	
}"></ClientSideEvents>

                            <Columns>
                                <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, visitorcompanyno1 %>" VisibleIndex="1" FieldName="CompanyNr">
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="14%" Caption="<%$ Resources:localizedText, visitCompany %>" VisibleIndex="2" FieldName="CompanyName"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="14%" Caption="<%$ Resources:localizedText, place2 %>" VisibleIndex="3" FieldName="Place"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="4%" Caption="<%$ Resources:localizedText, zipCode2 %>" VisibleIndex="4" FieldName="ZipCode">
                                    <CellStyle HorizontalAlign="left"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="14%" Caption="<%$ Resources:localizedText, responsiblePerson %>" FieldName="Name" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Width="10%" Caption="<%$ Resources:localizedText, telephone %>" FieldName="Telephone" VisibleIndex="7">
                                    <CellStyle HorizontalAlign="left"></CellStyle>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" AllowFocusedRow="True" AllowGroup="False" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                            <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                            </SettingsPager>
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                        </dx:ASPxGridView>
                    </section>
                </section>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, viscompanynew %>" OnClick="btnNew_Click" Style="width: 121px;" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, viscompanysave %>" OnClick="btnSave_Click" Style="width: 157px;" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, viscompanydelete %>" OnClick="btnDelete_Click" Style="width: 161px;" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
