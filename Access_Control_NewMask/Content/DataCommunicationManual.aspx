<%@ Page Title="<%$ Resources:localizedText, datacommmanual  %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="DataCommunicationManual.aspx.cs" Inherits="Access_Control_NewMask.Content.DataCommunicationManual" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/DataCommunicationManual.js"></script>
    <link href="Styles/DataCommunicationManual.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="mainContent">
        <div class="contTop">
            <div class="ControlSecarea1new2ab">
                <div class="ControlSecarea2">
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, terminalgroupNo %>" CssClass="planGruppen1" Style="min-width: 79px;"></asp:Label>
                    <%--<asp:DropDownList ID="ddlTerminalGrpNr" DataValueField="ID" DataTextField="GroupNr"
                        runat="server"  Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen2">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="ddlTerminalGrpNr" ClientInstanceName="ddlTerminalGrpNr" CssClass="planGruppen2" EnableCallbackMode="true" ValueField="ID" TextField="GroupNr" SelectedIndex="0" TextFormatString="{0}" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" IncrementalFilteringMode="Contains" Theme="Office2003Blue" ValueType="System.String" runat="server">
                        <ClientSideEvents SelectedIndexChanged="ddlTerminalGrpNr_SelectedIndexChanged" />
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, terminalgroupNo %>" FieldName="GroupNr" Name="GroupNr" ToolTip="<%$ Resources:localizedText, terminalgroupNo %>" Width="35%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="GroupDescription" Name="GroupDescription" ToolTip="<%$ Resources:localizedText, description1 %>" Width="65%" />
                        </Columns>
                    </dx:ASPxComboBox>
                    <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="planGruppen3" Style="margin-left: 4px;"></asp:Label>
                    <%--<asp:DropDownList ID="ddlTerminalDescription" runat="server" DataValueField="ID" DataTextField="GroupDescription"
                         Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" CssClass="planGruppen4">
                    </asp:DropDownList>--%>
                    <dx:ASPxComboBox ID="ddlTerminalDescription" ClientInstanceName="ddlTerminalDescription" CssClass="planGruppen4" EnableCallbackMode="true" ValueField="ID" TextField="GroupDescription" SelectedIndex="0" TextFormatString="{1}" DropDownWidth="400px" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="14px" IncrementalFilteringMode="Contains" Theme="Office2003Blue" ValueType="System.String" runat="server">
                        <ClientSideEvents SelectedIndexChanged="ddlTerminalDescription_SelectedIndexChanged" />
                        <Columns>
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, terminalgroupNo %>" FieldName="GroupNr" Name="GroupNr" ToolTip="<%$ Resources:localizedText, terminalgroupNo %>" Width="35%" />
                            <dx:ListBoxColumn Caption="<%$ Resources:localizedText, description1 %>" FieldName="GroupDescription" Name="GroupDescription" ToolTip="<%$ Resources:localizedText, description1 %>" Width="65%" />
                        </Columns>
                    </dx:ASPxComboBox>

                    <asp:Button ID="btnSearchTerminals" runat="server" Text="" CssClass="searchzutarea" />

                </div>
                <div class="ControlSecarea3">
                    <section class="leftDvns">
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, terminalgroupNo %>" CssClass="Gruppen1"></asp:Label>
                        <asp:TextBox ID="txtTerminalGrpNr" ClientIDMode="Static" runat="server" CssClass="Gruppen2"></asp:TextBox>
                        <asp:Label runat="server" Text="<%$ Resources:localizedText, description1 %>" CssClass="Gruppen3"></asp:Label>
                        <asp:TextBox ID="txtGroupDescription" ClientIDMode="Static" runat="server" CssClass="Gruppen4"></asp:TextBox>
                    </section>
                    <section class="rightDvns">
                        <section class="secLeftImg">
                            <img src="../Images/FormImages/315-arrow.png" class="imgLeft" />
                            <%--<img src="../Images/FormImages/190arrow2.png" class="imgLeft" />--%>
                        </section>
                        <section class="secMidText">
                            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, terminalsfromtermkonfig%>" CssClass="lblHeaderText"></asp:Label>
                        </section>
                        <section class="secRightImg">
                            <img src="../Images/FormImages/315RIght.png" class="imgRight" />
                            <%--<img src="../Images/FormImages/190arrow.png" class="imgRight" />--%>
                        </section>
                    </section>
                </div>
            </div>
        </div>
        <section class="MidContentAreaDiv">
            <div class="contMid">
                <section class="secGridLeft">
                    <section class="gridterminal">
                        <dx:ASPxGridView ID="grdMappedTerminals" ClientInstanceName="grdMappedTerminals" KeyFieldName="ID" EnableCallBacks="true" runat="server" Width="100%" AutoGenerateColumns="False" OnCustomButtonInitialize="grdMappedTerminals_CustomButtonInitialize" OnCustomCallback="grdMappedTerminals_CustomCallback" OnDataBound="grdMappedTerminals_DataBound" OnHtmlDataCellPrepared="grdMappedTerminals_HtmlDataCellPrepared">
                            <ClientSideEvents SelectionChanged="function(s, e) { grdMappedTerminalsRowChanged(s,e) }" />
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="1" Caption="<%$ Resources:localizedText, terminalId%>" Width="8%" FieldName="TermID">
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="2" Caption="Terminal Type" Width="17%" FieldName="TermType"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="3" Caption="<%$ Resources:localizedText, description3%>" Width="33%" FieldName="Description"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="4" Caption="<%$ Resources:localizedText, connection_new%>" Width="12%" FieldName="ConnectionType"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="5" Caption="Status" Visible="false" FieldName="IsActive"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="5" Caption="Status" Width="8%" FieldName="Status"></dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="true" ShowClearFilterButton="True" HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="6" Caption="<%$ Resources:localizedText, action_new%>" Width="8%"></dx:GridViewCommandColumn>
                                <dx:GridViewCommandColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="7" Caption="<%$ Resources:localizedText, connection_new%>" Width="12%" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="Verbindung" Text="Info">
                                            <Image ToolTip="Verbindung" Url="../Images/FormImages/yellowgrid.png" />

                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="8" FieldName="SerialNumber"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="9" FieldName="IpAddress"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="10" FieldName="Port"></dx:GridViewDataTextColumn>
                            </Columns>

                            <Styles>
                                <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>
                            </Styles>
                            <SettingsPager PageSize="26" Visible="False" ShowEmptyDataRows="True">
                            </SettingsPager>
                            <SettingsBehavior AllowFocusedRow="true" AllowSelectSingleRowOnly="False" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                        </dx:ASPxGridView>
                    </section>
                    <section class="btnDelete">
                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, terminalgroup %>" CssClass="lbldelete"></asp:Label>
                        <asp:Button ID="btnUmapTerminalInstance" ClientIDMode="Static" CssClass=" deletebtnred" runat="server" Text="<%$ Resources:localizedText, deleteButton %>" />
                    </section>
                </section>
                <section class="secRight">
                    <section class="secGridRight">
                        <dx:ASPxGridView ID="grdTerminalInstances" KeyFieldName="ID" runat="server" Styles-Cell-BackColor="White" Width="100%" AutoGenerateColumns="False" OnCustomCallback="grdTerminalInstances_CustomCallback" OnDataBound="grdTerminalInstances_DataBound" OnHtmlDataCellPrepared="grdTerminalInstances_HtmlDataCellPrepared">
                            <ClientSideEvents SelectionChanged="function(s, e) { grdTerminalInstancesRowChanged(s,e) }" CustomButtonClick="function(s, e) { }" />
                            <Columns>
                                <dx:GridViewDataTextColumn Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="1" Caption="<%$ Resources:localizedText, terminalId%>" FieldName="TermID" Width="8%">
                                    <CellStyle HorizontalAlign="Left"></CellStyle>
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="2" Caption="Terminal Type" FieldName="TermType" Width="20%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="3" Caption="<%$ Resources:localizedText, description3%>" FieldName="Description" Width="40%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="4" Caption="<%$ Resources:localizedText, connection_new%>" FieldName="ConnectionType" Width="15%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="5" Caption="Status" Visible="false" FieldName="IsActive" Width="8%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" VisibleIndex="6" Caption="Status" FieldName="Status" Width="8%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ShowSelectCheckbox="true" HeaderStyle-BackColor="White" HeaderStyle-ForeColor="Green" ShowClearFilterButton="True" VisibleIndex="7" Caption="<%$ Resources:localizedText, action_new%>" Width="5%">
                                    <HeaderStyle BackColor="White" ForeColor="Green"></HeaderStyle>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <Styles>
                                <SelectedRow BackColor="Transparent" ForeColor="Black"></SelectedRow>

                                <Cell BackColor="White"></Cell>
                            </Styles>
                            <SettingsPager PageSize="25" Visible="False" ShowEmptyDataRows="True">
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="False" AllowDragDrop="false" AllowSort="false"></SettingsBehavior>
                        </dx:ASPxGridView>
                    </section>
                    <section class="btnappl">
                        <section class="secApplyChanges">

                            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, terminalsinnewgroup %>" CssClass="lblTitle"></asp:Label>
                            <asp:Button ID="btnMapTerminals" ClientIDMode="Static" runat="server" Text="<%$ Resources:localizedText, accept %>" CssClass="editbtnfooterorange " Style="width: 94px; float: right;" />
                        </section>
                    </section>
                </section>

            </div>
            <div class="contFooter">
                <section class="contFooterLeft">
                    <section class="secleftbttm">
                        <asp:Button ID="btnSendRefferenceData" CssClass="newstandardbutton btn" style="cursor:pointer;" runat="server" Text="<%$ Resources:localizedText, sendReferenceData %>" />
                        <asp:Button ID="btnGetBookings" CssClass="newstandardbutton btn" style="cursor:pointer;" runat="server" Text="<%$ Resources:localizedText, getBookings %>" />
                        <asp:Button ID="btnSendSystemTime" CssClass="newstandardbutton btn" style="cursor:pointer;" runat="server" Text="<%$ Resources:localizedText, setSystemTime %>" />
                        <asp:Button ID="btnTestConnection" CssClass="newstandardbutton btn" style="cursor:pointer;" runat="server" Text="<%$ Resources:localizedText, testconnection %>" />
                    </section>
                </section>
                <%--<section class="contFooterRight">
               
            </section>--%>
            </div>
            <section class="searchTerminals" style="display: none;">
                <section class="searchTerminalsGrid">
                <dx:ASPxGridView ID="grdSearchTerminals" ClientInstanceName="grdSearchTerminals" runat="server" Width="100%" AutoGenerateColumns="False" Theme="Office2003Blue" KeyFieldName="ID" EnableTheming="True">

                    <Columns>
                        <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="ID"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="4%" VisibleIndex="1" Caption="<%$ Resources:localizedText, terminalgroupNo %>" FieldName="GroupNr">
                            <CellStyle HorizontalAlign="Left"></CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Width="12%" VisibleIndex="2" Caption="<%$ Resources:localizedText, description1 %>" FieldName="GroupDescription"></dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager ShowEmptyDataRows="true" PageSize="25" Visible="False"></SettingsPager>
                    <SettingsBehavior AllowSort="false" AllowFocusedRow="true" AllowDragDrop="false" />
                    <SettingsDataSecurity AllowEdit="False" AllowDelete="False" AllowInsert="False"></SettingsDataSecurity>
                </dx:ASPxGridView>
                    </section>
                <section class="searchTerminalsApplyBtn">
                     <asp:Button ID="btnApplyTermGrp" runat="server" CssClass="editbtnfooterorange" Text="<%$ Resources:localizedText, takeover %>" style="float:right; clear:both; width: 110px; height: 15px; text-align:right !important;" />
                </section>
            </section>
        </section>
    </div>
    <div id="importantDialog" class="dialogBox"></div>

    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="True" ShowImage="true" ClientIDMode="Static" Text="Tun aufgabe auf ausgewählten terminnals">
        <Image Url="../Images/FormImages/Loading.gif" />
    </dx:ASPxLoadingPanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">

    <asp:Button ID="btnNew" CssClass=" newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newgroup %>" Style="width: 90px;" OnClick="btnNew_Click" />
    <asp:Button ID="btnSave" CssClass=" savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savegroup %>" Style="width: 124px;"  OnClick="btnSave_Click"/>
    <asp:Button ID="btnDelete" ClientIDMode="Static" CssClass=" deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletegroup %>" Style="width: 115px;"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">

    <asp:Button ID="btnBack" ClientIDMode="Static" CssClass=" backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" />
    <asp:Button ID="btnActHelp" CssClass=" helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
