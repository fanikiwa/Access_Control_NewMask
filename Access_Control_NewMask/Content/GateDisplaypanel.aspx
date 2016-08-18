<%@ Page Title="<%$ Resources:localizedText, gatemonitordisplaypanel %>" Language="C#" MasterPageFile="~/MasterPages/Gate.Master" AutoEventWireup="true" CodeBehind="GateDisplaypanel.aspx.cs" Inherits="Access_Control_NewMask.Content.GateDisplaypanel" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/GateDisplaypanel.js"></script>
    <link href="Styles/GateDisplaypanel.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="mainareaplace1">
        <div class="topareaplace1">
            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:localizedText, people %>"  CssClass="topbtn" Style="color:forestgreen !important;"/>
            <asp:CheckBox ID="chkPersonnel" runat="server"  CssClass="chkActivation"/>
            <asp:Button ID="Button2" runat="server" Text="<%$ Resources:localizedText, member %>" CssClass="topbtn" Style="color:orangered !important;" />
            <asp:CheckBox ID="chkMember" runat="server"  CssClass="chkActivation"/>
            <asp:Button ID="Button3" runat="server" Text="<%$ Resources:localizedText, visitor %>" CssClass="topbtn" Style="color:darkorange !important;"/>
            <asp:CheckBox ID="chkVisitor" runat="server"  CssClass="chkActivation"/>
            <asp:Button ID="Button4" runat="server" Text="<%$ Resources:localizedText, all %>" CssClass="topbtn" Style="color:darkblue !important; width:39px;" />
            <asp:CheckBox ID="chkShowAll" runat="server"  CssClass="chkActivation"/>
             <asp:Label ID="Label2" runat="server" Text="<%$ Resources:localizedText, present2 %>" CssClass="lblabwes"></asp:Label>
            
            <asp:ImageButton ID="ImageButton1" runat="server"  CssClass="btngreenarea"/>
         <asp:CheckBox ID="chkPresent" runat="server"  CssClass="chkActivation"/>
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, absent2 %>" CssClass=" lblabsew"></asp:Label>
            <asp:ImageButton ID="ImageButton2" runat="server" CssClass="btnredarea"/>
           
                <asp:CheckBox ID="chkAbsent" runat="server"  CssClass="chkActivation"/>
            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:localizedText, showfirstandlastbooking %>" CssClass="lblbooking"> </asp:Label>
        </div>
        <div class="gridareaplace1">
            <dx:ASPxGridView ID="grdBookings" ClientInstanceName="grdBookings" EnableCallBacks="true" OnCustomCallback="grdBookings_CustomCallback" OnCustomButtonInitialize="grdBookings_CustomButtonInitialize" KeyFieldName="IDNr" runat="server"  AutoGenerateColumns="False"  Width="100%"  >
              
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" Visible="False" VisibleIndex="0" FieldName="IDNr" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black" ></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="6%" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="1" FieldName="Name1" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, IdNo_new %>" VisibleIndex="2" FieldName="ID_Nr1" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, come %>" VisibleIndex="3" FieldName="TimeIn1" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, go %>" VisibleIndex="4" FieldName="TimeOut1" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                    <dx:GridViewDataTextColumn FieldName="CardStatus1" VisibleIndex="5" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn Width="2%" Caption="<%$ Resources:localizedText, status2 %>" VisibleIndex="6" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                                        <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Status1" Text="<%$ Resources:localizedText, status2 %>">
                                    <Image ToolTip="<%$ Resources:localizedText, status2 %>" Url="../Images/FormImages/btn_reddisplay.png" />
                                    
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Width="1%" Caption=" " FieldName="" VisibleIndex="7" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Width="6%" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="8" FieldName="Name2" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, IdNo_new %>" VisibleIndex="9" FieldName="ID_Nr2" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, come %>" VisibleIndex="10" FieldName="TimeIn2" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, go %>" VisibleIndex="11" FieldName="TimeOut2" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                     <dx:GridViewDataTextColumn FieldName="CardStatus2" VisibleIndex="12" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn Width="2%" Caption="<%$ Resources:localizedText, status2 %>"  VisibleIndex="13" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                                        <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Status2" Text="Status">
                                    <Image ToolTip="<%$ Resources:localizedText, status2 %>" Url="../Images/FormImages/btn_reddisplay.png" />
                                    
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Width="1%" Caption=" " FieldName="" VisibleIndex="14" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn Width="6%" Caption="<%$ Resources:localizedText, name %>" VisibleIndex="15" FieldName="Name3" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="Left"></CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Width="3%" Caption="<%$ Resources:localizedText, IdNo_new %>" VisibleIndex="16" FieldName="ID_Nr3" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, come %>" VisibleIndex="17" FieldName="TimeIn3" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                    <dx:GridViewDataTimeEditColumn Width="3%" Caption="<%$ Resources:localizedText, go %>" VisibleIndex="18" FieldName="TimeOut3" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                        <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTimeEditColumn>
                                     <dx:GridViewDataTextColumn FieldName="CardStatus3" VisibleIndex="19" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn Width="2%" Caption="<%$ Resources:localizedText, status2 %>"  VisibleIndex="20" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black" ShowNewButton="false" ShowEditButton="false" ButtonType="Image">
                                        <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="Status3" Text="Status">
                                    <Image ToolTip="<%$ Resources:localizedText, status2 %>" Url="../Images/FormImages/btn_reddisplay.png" />
                                    
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Width="1%" Caption=" " FieldName="" VisibleIndex="21" HeaderStyle-BackColor="darksalmon" HeaderStyle-ForeColor="black">
                                             <CellStyle HorizontalAlign="center"></CellStyle>
                                    </dx:GridViewDataTextColumn>

                                    
                                </Columns>
                                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="False" AllowDragDrop="false" />
                                <SettingsPager Visible="False" ShowEmptyDataRows="True" PageSize="26">
                                </SettingsPager>
                                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            </dx:ASPxGridView>
 
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterLeft" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterRight" runat="server">
        <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>" OnClick="btnBack_Click" />
    <asp:Button ID="btnHelp" ClientIDMode="Static" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
