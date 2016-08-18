<%@ Page Title="<%$ Resources:localizedText, alarmdooropen %>" Language="C#" MasterPageFile="~/MasterPages/Primary.Master" AutoEventWireup="true" CodeBehind="Alarmfunction.aspx.cs" Inherits="Access_Control_NewMask.Content.Alarmfunction" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/Alarmfunction.js"></script>
    <link href="Styles/Alarmfunction.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="mainareaplace1">
        <div class="topareaplace1" style="display:none;">
            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:localizedText, alarmdooropen %>"  CssClass="topbtn1 btnHovers" Style="color:#009bd8 !important;"/>
       
            <asp:Button ID="Button2" runat="server" Text="<%$ Resources:localizedText, messages %>" CssClass="topbtn btnHovers" Style="color:#009bd8 !important;" />
            
        </div> 
        <div class="gridareaplace1" style="display:none;">
             <dx:ASPxGridView ID="ASPxGridView2" runat="server" Width="100%"  
                        Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="12px" >
                                  <Columns>
                            <dx:GridViewDataTextColumn VisibleIndex="0" Visible="false" FieldName="ID"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, location1 %>" VisibleIndex="1" Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="left" /> 
                            </dx:GridViewDataTextColumn> 
                            <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, building2 %>" VisibleIndex="2" Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="left" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, floor2 %>" VisibleIndex="3" Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="left" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
    <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, room2 %>" VisibleIndex="4" Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="left" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                          <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, doororreader %>" VisibleIndex="5" Width="12%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="left" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, info2 %>" VisibleIndex="6" Width="10%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="Center" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, date %>" VisibleIndex="7" Width="9%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="Center" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, time1 %>" VisibleIndex="8" Width="9%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="Center" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, alarm %>" VisibleIndex="9" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="Center" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, end %>" VisibleIndex="10" Width="5%" HeaderStyle-BackColor="#ffffff" HeaderStyle-ForeColor="#000000" HeaderStyle-Font-Bold="true">
                                <HeaderStyle HorizontalAlign="Center" /> 
                              <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataTextColumn>
                                      </Columns>
                                        <SettingsPager ShowEmptyDataRows="true" Visible="False" PageSize="26"></SettingsPager>
                            </dx:ASPxGridView>
 
        </div>
        <div class="Wrapperdivinfo">
                <section class="infoimgarea">
                </section>
                <section class="lblsoftware">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, alarmdoorfunction %>"></asp:Label>
                </section>
                <section class="btnareabottom" style="display:none;">
                    <asp:Button ID="btnBacktop" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  />
                </section>
            </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
      <asp:Button ID="Button3" runat="server" Text="<%$ Resources:localizedText, saveendalarm %>" CssClass="savebtnfootergreen" Style="width:159px; display:none;" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"  />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" style="display:none;" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
