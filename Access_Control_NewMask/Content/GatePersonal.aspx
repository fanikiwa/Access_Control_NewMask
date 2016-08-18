<%@ Page Title="<%$ Resources:localizedText ,personnelcheck%>" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GatePersonal.aspx.cs" Inherits="Access_Control_NewMask.Content.GatePersonal" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GatePersonal.js?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>"></script>
    <link href="Styles/GatePersonal.css?v=<%= Access_Control_NewMask.Controllers.Version.JSVersion %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:HiddenField ID="hiddenFieldSaveChanges" runat="server" />
    <div class="MainArea">
        <div class="midarea1">
            <div class="midcontentarea">
                <div class="persinfoarea">
                    <section class="secTwoAndThreHolder">
                        <section class="topmidmenunew">
                            <asp:Button ID="btnPersonal" runat="server" Text="<%$ Resources:localizedText ,personal%>" CssClass="btnpersonalnew2" />
                            <asp:Button ID="btnPersonalSearch" runat="server" Text="<%$ Resources:localizedText ,personnelsearch%>" CssClass="btnpersonalsearch" />
                            <asp:Button ID="btnDocument" runat="server" Text="<%$ Resources:localizedText ,document%>" CssClass="btnpersonaldoc" OnClick="btnDocument_Click" />
                        </section>
                        <section class="classTwo">
                            <section class="secTwoLeft">
                                <section class="persContOne">
                                    <asp:Label ID="Label6" runat="server" CssClass="lblLeftPersContHeader" Text="<%$ Resources:localizedText ,personneldata1%>"></asp:Label>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label3" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,companynonew%>"></asp:Label>
                                    <asp:TextBox ID="txtVisitorCompanyNr" CssClass="txttopclient" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label2" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,company2%>"></asp:Label>
                                    <asp:TextBox ID="txtVisitorCompanyName" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label27" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,IdNo_new%>"></asp:Label>
                                    <asp:TextBox ID="txtIdNr"  CssClass="txttopclient" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label4" runat="server" CssClass="lblLeftPersCont" Text="Card Nr."></asp:Label>
                                    <asp:TextBox ID="txtCardNumber" ClientIDMode="Static"  CssClass="txttopclient" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label8" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,name%>"></asp:Label>
                                    <asp:TextBox ID="txtLastName" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label23" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,firstname_new%>"></asp:Label>
                                    <asp:TextBox ID="txtFirstName"  CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne" style="display: none;">
                                    <asp:Label ID="Label24" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,company%>"></asp:Label>
                                    <asp:TextBox ID="txtCompany" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label25" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,street%>"></asp:Label>
                                    <asp:TextBox ID="txtStreet" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label26" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,place2%>"></asp:Label>
                                    <asp:TextBox ID="txtPlace" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>
                                <section class="spaceCreator"></section>
                                <section class="persContOne">
                                    <asp:Label ID="Label29" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,personnelType1%>"></asp:Label>
                                    <asp:TextBox ID="txtPersonType" runat="server" CssClass="txtLeftPersCont"></asp:TextBox>
                                </section>
                                <section class="persContOne" style="display: none;">
                                    <asp:Label ID="Label32" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,typevehicle%>"></asp:Label>
                                    <asp:TextBox ID="txtCarType" runat="server" CssClass="txtLeftPersCont"></asp:TextBox>
                                </section>
                                <section class="persContOne" style="display: none;">
                                    <asp:Label ID="Label28" runat="server" CssClass="lblLeftPersCont" Text="<%$ Resources:localizedText ,indicator%>"></asp:Label>
                                    <asp:TextBox ID="txtCarReg" CssClass="txtLeftPersCont" runat="server"></asp:TextBox>
                                </section>

                                <section class="persContOne">
                                    <asp:Label ID="Label35" runat="server" CssClass="lblLeftPersContHeader" Text="<%$ Resources:localizedText ,accessauthorization%>"></asp:Label>
                                </section>

                                <section class="persContOne">
                                    <asp:Label ID="Label37" runat="server" Text="<%$ Resources:localizedText ,accessPermissionFrom%>" CssClass="lblLeftPersCont"></asp:Label>
                                    <asp:TextBox ID="txtAccessEntry" runat="server" TextMode="Date" CssClass="txttopclient"></asp:TextBox>
                                    <asp:Label ID="Label38" runat="server" Text="<%$ Resources:localizedText ,to%>" CssClass="lblfrom" Style="text-align: center;"></asp:Label>
                                    <asp:TextBox ID="txtAccessExit" runat="server" CssClass="txttopclient"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label39" runat="server" Text="<%$ Resources:localizedText ,accessplannumber%>" CssClass="lblLeftPersCont"></asp:Label>
                                    <asp:TextBox ID="txtAccessPlanNr" runat="server" CssClass="txttopclient"></asp:TextBox>
                                </section>
                                <section class="persContOne">
                                    <asp:Label ID="Label40" runat="server" Text="<%$ Resources:localizedText ,acessplandesc%>" CssClass="lblLeftPersCont"></asp:Label>
                                    <asp:TextBox ID="txtAccessPlanDescription" runat="server" CssClass="txtLeftPersCont"></asp:TextBox>
                                </section>

                            </section>

                        </section>
                        <section class="classThree">
                            <section class="secThreeRight">
                                <section class="secHeader" style="float: left; width: 100%; margin-bottom: 17px;">
                                    <asp:Label ID="Label36" runat="server" CssClass="lblLeftPersContHeader" Text="<%$ Resources:localizedText ,passportPhoto%>"></asp:Label>
                                </section>
                                <section style="float: left; width: 100%;">
                                    <fieldset id="PhotoFieldset" style="width: 80%; margin-left: 0; margin-right: auto; border: 1px solid black;">
                                        <%--    <legend>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="PhotoholderCls"></asp:Label>
                                            </legend>--%>
                                        <div id="Photoholder" class="PhotoholderCls">
                                            <img id="img" runat="server" />
                                        </div>
                                    </fieldset>

                                </section>
                                <section style="float: left; width: 100%; margin-top: 10px;">
                                    <section class="txtwitchtigbttm">
                                        <asp:Label ID="Label42" runat="server" Text="<%$ Resources:localizedText ,memo%>" CssClass="lblmemo" />
                                        <asp:TextBox ID="txtMemo" runat="server" CssClass="txtpersonallarge" TextMode="MultiLine" font-family="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif !important" Font-Size="14px"></asp:TextBox>
                                    </section>

                                </section>

                            </section>
                        </section>
                    </section>

                    <div class="wrapperSec" style="display: none;">
                        <section class="headerInfo">
                            <asp:Label ID="Label1" runat="server" Text="Info" CssClass="lblInfomatioinHeader"></asp:Label>
                        </section>
                        <section class="secOneAll">
                            <section class="secRight" id="secRight">
                                <section class="tblRightTop" id="tblRightTop">
                                    <section style="display: none">
                                        <dx:ASPxComboBox ID="cboPersNr" HorizontalAlign="left" runat="server" ClientInstanceName="cboPersNr" ClientIDMode="Static" ValueField="Pers_Nr" TextField="Pers_Nr" EnableCallbackMode="true" AutoPostBack="false"
                                            TextFormatString="{0}" DropDownRows="20" DropDownWidth="100px" SelectedIndex="0" Theme="Office2003Blue" CallbackPageSize="10000" OnCallback="cboPersNr_Callback">

                                            <Columns>
                                                <dx:ListBoxColumn FieldName="Pers_Nr" Caption="ID Nr.:" Name="ProfileDescription" ToolTip="" Width="18%" />
                                            </Columns>
                                        </dx:ASPxComboBox>
                                    </section>
                                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="tblBottmLft1">
                                        <asp:TableHeaderRow CssClass="tblBttmRowHeader2">
                                            <asp:TableCell ColumnSpan="2" CssClass="tblBttmCellHeader2">
                                                <asp:Label ID="Label9" runat="server" Text="<%$ Resources:LocalizedText, peoplePresent %>" CssClass="lblTitleHead"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell2">
                                                <asp:Label ID="Label18" runat="server" Text="<%$ Resources:LocalizedText, people %>" CssClass="lblHeaderLarge"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell2">
                                                <asp:Label ID="Label19" runat="server" Text="<%$ Resources:LocalizedText, visitor %>" CssClass="lblHeaderLarge"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell2">
                                                <asp:Label ID="lblTotalPersonnel" runat="server" Text="" CssClass="lblData2"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell2">
                                                <asp:Label ID="lblTotalVisitors" runat="server" Text="" CssClass="lblData2"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </section>
                                <section class="tblRightBttm" id="tblRightBttm">
                                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="tblBottmLft3">
                                        <asp:TableHeaderRow CssClass="tblBttmRowHeader" Style="min-height: 30px;">
                                            <asp:TableCell ColumnSpan="2" CssClass="tblBttmCellHeader">
                                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:LocalizedText, readersAction %>" CssClass="lblTitleHead"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell3">
                                                <asp:Label ID="Label20" runat="server" Text="<%$ Resources:LocalizedText, openings %>" CssClass="lblHeaderLarge"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell3">
                                                <asp:Label ID="Label21" runat="server" Text="<%$ Resources:LocalizedText, abuse %>" CssClass="lblHeaderLarge"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell3">
                                                <asp:Label ID="Label30" runat="server" Text="" CssClass="lblData3"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell3">
                                                <asp:Label ID="Label31" runat="server" Text="" CssClass="lblData3"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </section>
                                <section class="secLeftRenamed" id="secLeft">
                                    <asp:Table runat="server" CellPadding="0" CellSpacing="0" CssClass="tblBottmLft">
                                        <asp:TableHeaderRow CssClass="tblBttmRowHeader" Style="min-height: 30px;">
                                            <asp:TableCell ColumnSpan="2" CssClass="tblBttmCellHeader">
                                                <asp:Label ID="Label11" runat="server" Text="Objekt Information" CssClass="lblTitleHead"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:LocalizedText, object %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label22" runat="server" Text="<%$ Resources:LocalizedText, numberTitle %>" CssClass="lblLeft2"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label13" runat="server" Text="<%$ Resources:LocalizedText, building %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="lblTotalBuildings" runat="server" Text="" CssClass="lblData"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:LocalizedText, levels %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="lblTotalFloors" runat="server" Text="" CssClass="lblData"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label15" runat="server" Text="<%$ Resources:LocalizedText, rooms %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="lblTotalRooms" runat="server" Text="" CssClass="lblData"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:LocalizedText, doors %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="lblTotalDoors" runat="server" Text="" CssClass="lblData"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow CssClass="tblBttmRow">
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="Label17" runat="server" Text="<%$ Resources:LocalizedText, reader %>" CssClass="lblLeft"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="tblBttmCell">
                                                <asp:Label ID="lblTotalReaders" runat="server" Text="" CssClass="lblData"></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </section>
                            </section>
                        </section>

                    </div>
                </div>
            </div>

        </div>

        <div class="searchPersonal" style="display: none;">
            <dx:ASPxGridView ID="grdSearchPersonal" runat="server" Width="100%" ClientInstanceName="grdSearchPersonal" Theme="Office2003Blue" KeyFieldName="Pers_Nr" AutoGenerateColumns="False" EnableTheming="True">
                <ClientSideEvents RowDblClick="function(s, e) {
	 BindSelectedPers(s.GetRowKey(e.visibleIndex));
}"></ClientSideEvents>

                <Columns>
                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Pers_Nr" Visible="False" VisibleIndex="8" FieldName="Pers_Nr" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, personnelNo2 %>" VisibleIndex="1" FieldName="Pers_Nr" Width="10%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, identification %>" VisibleIndex="2" FieldName="Card_Nr" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, lastName %>" VisibleIndex="3" FieldName="LastName" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, firstName %>" VisibleIndex="4" FieldName="FirstName" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location2 %>" VisibleIndex="5" FieldName="LocationName" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, depatmentTitle %>" VisibleIndex="6" FieldName="DepartmentName" Width="15%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, costcenter2%>" VisibleIndex="7" FieldName="CostCenterName" Width="15%">
                    </dx:GridViewDataTextColumn>

                </Columns>
                <SettingsBehavior AllowFocusedRow="true" AllowDragDrop="False" AllowGroup="False" AllowSort="False" />
                <SettingsPager PageSize="30" ShowEmptyDataRows="True" Visible="False">
                </SettingsPager>
                <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            </dx:ASPxGridView>

        </div>
        <section class="backareafooter">
             <asp:Button ID="btnApplyPers" runat="server" Text="<%$ Resources:localizedText, takeover%>" CssClass="ubernahme" style="margin-top:10px !important; display:none;" />
            <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
