<%@ Page Title="<%$ Resources:localizedText, depatmentTitle %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Department_New.aspx.cs" Inherits="Access_Control_NewMask.Content.Department_New" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Department_New.js"></script>
    <link href="Styles/Department_New.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="saveChangesonNew" ClientIDMode="Static" runat="server" />
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTopse">
                <section class="secLeftTopL2">
                    <asp:Label ID="Label2" runat="server" CssClass="lblsecTlft" Text="<%$ Resources:localizedText, departmentnr1 %>"></asp:Label>
                    <dx:ASPxComboBox ID="cboDeptNr" runat="server" ClientInstanceName="cboDeptNr" CssClass="ddlistTlft" Theme="Office2003Blue" HorizontalAlign="left"
                        EnableCallbackMode="true" SelectedIndex="0" ValueField="ID" TextField="Department_Nr" TextFormatString="{0}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDeptNrSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
                <section class="secLeftTopR2">
                    <asp:Label ID="Label1" runat="server" CssClass="lblsec2Tsdfnew" Text="<%$ Resources:localizedText, departments1 %>"></asp:Label>
                    <dx:ASPxComboBox ID="cboDeptName" runat="server" ClientInstanceName="cboDeptName" CssClass="ddlist2Twenew" Theme="Office2003Blue"
                        EnableCallbackMode="true" SelectedIndex="0" ValueField="ID" TextField="Name" TextFormatString="{1}" DropDownRows="20" DropDownWidth="480px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {cboDeptNameSelectedIndexChanged(s.GetValue());}"></ClientSideEvents>
                        <Columns>
                            <dx:ListBoxColumn Caption="Nr.:" FieldName="Department_Nr" Width="20%" />
                            <dx:ListBoxColumn Caption="Name:" FieldName="Name" Width="80%" />
                        </Columns>
                    </dx:ASPxComboBox>
                </section>
            </section>
            <section class="secRightTopwe">
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
                                    <asp:Label ID="lbllocno" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, departmentnr1 %>"></asp:Label>
                                    <asp:TextBox ID="txtdeptNo" runat="server" CssClass="txtsec" Text=""></asp:TextBox>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblloc" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, department %>"></asp:Label>
                                    <asp:TextBox ID="txtdeptName" runat="server" CssClass="txtsec2" Text=""></asp:TextBox>

                                    <%-- <asp:Label ID="lbllocno" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, departmentnr %>"></asp:Label>
                                    <asp:TextBox ID="txtdeptNo" runat="server" CssClass="txtsec2" Text=""></asp:TextBox>--%>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">

                                    <asp:Label ID="lblPLZ" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, plz %>"></asp:Label>
                                    <asp:TextBox ID="txtPLZ" runat="server" CssClass="txtsec"></asp:TextBox>

                                    <%--<asp:Label ID="lblOrt" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, place %>"></asp:Label>
                                    <asp:TextBox ID="txtOrt" ClientIDMode="Static" runat="server" CssClass="txtsec"></asp:TextBox>--%>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblOrt" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, placeTitle %>"></asp:Label>
                                    <asp:TextBox ID="txtOrt" ClientIDMode="Static" runat="server" CssClass="txtsec2"></asp:TextBox>

                                    <%--<asp:Label ID="lblPLZ" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, plz %>"></asp:Label>
                                    <asp:TextBox ID="txtPLZ" runat="server" CssClass="txtsec2"></asp:TextBox>--%>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblStreet" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, street2 %>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" ClientIDMode="Static" runat="server" CssClass="txtsec2"></asp:TextBox>

                                    <%--<asp:Label ID="lblStreet" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, road %>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" ClientIDMode="Static" runat="server" CssClass="txtsec"></asp:TextBox>--%>
                                </section>
                                <section class="secdivright">
                                    <asp:Label ID="lblhseNumber" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, housenr %>"></asp:Label>
                                    <asp:TextBox ID="txthseNumber" runat="server" CssClass="txtsec"></asp:TextBox>


                                    <%--<asp:Label ID="lblhseNumber" runat="server" CssClass="lblsec2" Text="<%$ Resources:localizedText, housenr %>"></asp:Label>
                                    <asp:TextBox ID="txthseNumber" runat="server" CssClass="txtsec2"></asp:TextBox>--%>
                                </section>
                            </section>
                            <section class="secdiv">
                                <section class="secdivleft">
                                    <asp:Label ID="lblLocale" runat="server" CssClass="lblsec" Text="<%$ Resources:localizedText, locale %>" Style="display: none"></asp:Label>
                                    <asp:DropDownList ID="ddlLocale" ClientIDMode="Static" DataValueField="ID" DataTextField="Name" CssClass="bunddlist" runat="server" Style="display: none"></asp:DropDownList>
                                </section>
                                <section class="secdivright">
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
                                        <asp:Label ID="lblFunct" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, function %>"></asp:Label>
                                        <asp:TextBox ID="txtFunct" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblTel" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, telephone %>"></asp:Label>
                                        <asp:TextBox ID="txtTel" ClientIDMode="Static" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblMob" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, handy %>"></asp:Label>
                                        <asp:TextBox ID="txtMob" ClientIDMode="Static" runat="server" CssClass="txtPhone"></asp:TextBox>
                                    </section>
                                    <section class="secdiv2">
                                        <asp:Label ID="lblEmail" runat="server" CssClass="lblsec3" Text="<%$ Resources:localizedText, email1 %>"></asp:Label>
                                        <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="txtsec3"></asp:TextBox>
                                    </section>
                                </section>
                            </section>
                            <section class="lowerbtmsecLeftMidR">
                                <section class="topsec">
                                    <asp:Label ID="lblMemo" runat="server" CssClass="lblheader" Text="<%$ Resources:localizedText, memoTitle %>"></asp:Label>
                                </section>
                                <section class="btmsec">
                                    <asp:TextBox ID="txtMemo" ClientIDMode="Static" CssClass="txtMemo" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                </section>
                            </section>
                        </section>
                    </section>
                </section>
                <section class="secRightMid">
                    <section class="btmsecRightMid">
                        <section class="innersec2">
                            <dx:ASPxGridView ID="grdDepartments" ClientIDMode="Static" SettingsBehavior-AllowSort="false" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue" EnablePagingGestures="False" KeyFieldName="ID" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif"
                                Font-Size="14px" ClientInstanceName="grdDepartments" EnableCallBacks="False">
                                <ClientSideEvents RowClick="function(s, e) {grdDepartmentsRowClick(s, e)}"></ClientSideEvents>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" Visible="false" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="4%" Caption="<%$ resources:localizedtext, departmentnr1 %>" VisibleIndex="1" FieldName="Department_Nr">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="12%" Caption="<%$ resources:localizedtext, departments %>" VisibleIndex="2" FieldName="Name"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="12%" Caption="<%$ resources:localizedtext, place2 %>" VisibleIndex="3" FieldName="Place"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="12%" Caption="<%$ resources:localizedtext, zipCode2 %>" VisibleIndex="4" FieldName="ZipCode">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="12%" Caption="<%$ resources:localizedtext, responsiblePerson %>" VisibleIndex="5" FieldName="LocationHeadName"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="12%" Caption="<%$ resources:localizedtext, telephone %>" VisibleIndex="6" FieldName="LocationHeadPhone">
                                        <CellStyle HorizontalAlign="left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                                <SettingsPager Visible="False" PageSize="22" ShowEmptyDataRows="True"></SettingsPager>
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            </dx:ASPxGridView>
                        </section>
                    </section>
                </section>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    <asp:Button ID="btnNew" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, deptnew %>" Style="width: 109px;" OnClick="btnNew_Click" />
    <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, deptsave %>" Style="width: 124px;" OnClick="btnSave_Click" />
    <asp:Button ID="btnDelete" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deptdelete %>" Style="width: 133px;" OnClick="btnDelete_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
    <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
