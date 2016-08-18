<%@ Page Title="<%$ Resources:localizedText, contractDuration %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="MemberContractDuration.aspx.cs" Inherits="Access_Control_NewMask.Content.MemberContractDuration" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/MemberContractDuration.js"></script>
    <link href="Styles/MemberContractDuration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTop">
             
                
            </section>            
        </div>
        <div class="MidContentAreaDiv">
                <div class="secholder">
                    <section class="areagrid">
                        <dx:ASPxGridView ID="grdContractDurtaion" ClientInstanceName="grdContractDurtaion" KeyFieldName="ID" OnCustomCallback="grdContractDurtaion_CustomCallback" OnBatchUpdate="grdContractDurtaion_BatchUpdate" OnCustomColumnSort="grdContractDurtaion_CustomColumnSort" runat="server" AutoGenerateColumns="False" Width="100%" Theme="Office2003Blue">
                            <ClientSideEvents EndCallback="function(s, e) {
	grdContractDurtaionEndCallBack(s,e);
}"></ClientSideEvents>

                            <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, durationno %> " VisibleIndex="1" Settings-SortMode="Custom" FieldName="DurationNr" Width="15%">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    <CellStyle HorizontalAlign="Center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, duration %>" VisibleIndex="2" Settings-SortMode="Custom" FieldName="Duration"  Width="70%">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
            
                               <%-- <dx:GridViewCommandColumn Caption="Auswahl" VisibleIndex="3" ShowSelectCheckbox="true"  Width="15%">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewCommandColumn>--%>
                               
                                  <dx:GridViewDataCheckColumn Caption="<%$ Resources:localizedText, selectionTitle %>" VisibleIndex="3" FieldName="IsSelected"  Width="15%">
                                     <PropertiesCheckEdit>
                                    <ClientSideEvents CheckedChanged="function(s, e) {
    if (s.GetChecked()) {
	    activeCheckedChanged(s, e);
    }
}"></ClientSideEvents>
                                </PropertiesCheckEdit>
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Center"></HeaderStyle>
                                    </dx:GridViewDataCheckColumn>
                                </Columns>
                           <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="true" />
                                    <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                    </SettingsPager>
                            <SettingsEditing EditFormColumnCount="25" Mode="Batch" NewItemRowPosition="Bottom">
                                        <BatchEditSettings EditMode="Cell" StartEditAction="Click" ShowConfirmOnLosingChanges="False" />
                                    </SettingsEditing>
                                    <Settings ShowStatusBar="Hidden" />
                        </dx:ASPxGridView>
                        </section>
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, createperionclicknextline %>" CssClass="lblperiod"></asp:Label>
                </div>

            </div>
         <div id="importantDialog" class="dialogBox">
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
    
    <section class="footerextra">
        
<%--     <asp:Button ID="btnnew" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="Zeitraum neu"  style="width: 95px !important;" />--%>
    <asp:Button ID="btnsave" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, saveduration %>"  style="width: 122px !important;" />
    <asp:Button ID="btnDelete" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deleteduration %>" style="width: 123px !important; padding-left:13px;" />
          <asp:Button ID="btnapply" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft editbtnfooterorange" runat="server" Text="<%$ Resources:localizedText, takeover %>"  style=" margin-left: 34%; " />
        </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
