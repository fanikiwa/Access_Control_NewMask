<%@ Page Title="<%$ Resources:localizedText, vehicles %>" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="Access_Control_NewMask.Content.Vehicles" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Vehicles.css" rel="stylesheet" />
   <%--  <link href="Styles/VehiclesDialogs.css" rel="stylesheet" />--%>
    <script src="Scripts/Vehicles.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="ContentAreaDiv">
        <div class="TopContentAreaDiv">
            <section class="secLeftTop">
                <section class="secLeftTopL">
                    <asp:Label ID="lbllocationno" runat="server" CssClass="lblsecT2" Text="<%$ Resources:localizedText, manufacturer %>"></asp:Label>
                    
                    <dx:ASPxComboBox ID="cboVehicleTypes" ClientInstanceName="cboVehicleTypes" ValueField="ID" TextField="Name" runat="server" CssClass="ddlistT2" Theme="Office2003Blue" ClientIDMode="Static"
                        DropDownWidth="480px" OnCallback="cboVehicleTypes_Callback" EnableCallbackMode="true">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cboVehicleTypesSelectionChanged(s,e);
}"
                            EndCallback="function(s, e) {
cboVehicleTypesEndCallBack(s,e);	
}"></ClientSideEvents>
                    </dx:ASPxComboBox>

                </section>
                
            </section>            
        </div>
        <div class="MidContentAreaDiv">
                <div class="secholder">
                    <section class="left">
                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:localizedText, manufacturertable %>" CssClass="herslabel"></asp:Label>
                        <section class="allgridarea">
                        <dx:ASPxGridView ID="grdManufacturer" ClientInstanceName="grdManufacturer" KeyFieldName="ID" runat="server" OnCustomCallback="grdManufacturer_CustomCallback" AutoGenerateColumns="False" Width="98%">

                            <ClientSideEvents RowClick="function(s, e) {
	grdManufacturerRowClick(s,e);
}"
                                EndCallback="function(s, e) {
grdManufacturerEndCallBack(s,e);	
}"></ClientSideEvents>

                            <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, manufacturer12 %>" VisibleIndex="1" FieldName="Name">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                           <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" />
                                    <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                    </SettingsPager>
                        </dx:ASPxGridView>

                        </section>
                    </section>
                      <section class="center">
                          <section class="slabel">                         
                              <asp:Label ID="lblVehicleManu" runat="server" CssClass="labelcenter"  Text=""></asp:Label>
                          </section>
                          <section class="simage">
                              <asp:ImageButton ID="imgArrow" runat="server" ImageUrl="~/Images/FormImages/addtogrid.png" CssClass="arrowgrid"/> 
                          </section>
                      </section>
                      <section class="right">
                             <asp:Label ID="Label2" runat="server" Text="" CssClass="herslabel"></asp:Label>
                          <section class="allgridarea">
                          <dx:ASPxGridView ID="grdVehicleModel" ClientInstanceName="grdVehicleModel" KeyFieldName="ID" runat="server" OnCustomCallback="grdVehicleModel_CustomCallback" AutoGenerateColumns="False" Width="66%">
                              <ClientSideEvents RowClick="function(s, e) {
	grdVehicleModelRowClick(s,e);
}"></ClientSideEvents>

                              <Columns>
                                    <dx:GridViewDataTextColumn Caption="ID" VisibleIndex="0" FieldName="ID" Visible="false">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="<%$ Resources:localizedText, typevehicle %>" VisibleIndex="1" FieldName="Type">
                                        <HeaderStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Left"></HeaderStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                               <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" AllowSort="false" />
                                    <SettingsPager PageSize="24" ShowEmptyDataRows="True" Visible="False">
                                    </SettingsPager>
                          </dx:ASPxGridView>

                          </section>
                      </section>
                </div>
                <div class="secbelow">
                    <section class="secbelowl"> 
                        <asp:Label ID="Label3" runat="server" CssClass="lblhers" Text="<%$ Resources:localizedText, createmanufacturer %>"></asp:Label>
                        <asp:TextBox ID="txtManufacturerId" runat="server" Style="display:none" CssClass="txthers"></asp:TextBox>
                        <asp:TextBox ID="txtManufacturer" runat="server" CssClass="txthers"></asp:TextBox>
                    </section>
                    <section class="secbelowr"> 
                        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:localizedText, createvehicletype %>" CssClass="lblfah"></asp:Label>
                        <asp:TextBox ID="txtVehicleModelId" Style="display:none" runat="server" CssClass="txtfah"></asp:TextBox> 
                        <asp:TextBox ID="txtVehicleModel" runat="server" CssClass="txtfah"></asp:TextBox> 
                    </section>
                </div>
            </div>
        <div id="importantDialog" class="dialogBox"></div>
         <div id="saveAlert" class="saveAlertBox">
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
     <asp:Button ID="btnNewManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newmanufacturer %>"  style="width: 112px !important;" />
    <asp:Button ID="btnSaveManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savemanufacturer %>"   />
    <asp:Button ID="btnDeleteManufacturer" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletemanufacturer %>"  />
    <section class="footerextra">
     <asp:Button ID="btnNewModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft newbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, newvehicletype %>"  style="width: 118px !important;" />
    <asp:Button ID="btnSaveModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft savebtnfootergreen" runat="server" Text="<%$ Resources:localizedText, savevehicletype %>"  style="width: 150px !important;" />
    <asp:Button ID="btnDeleteModel" ClientIDMode="Static" CssClass="BottomFooterBtnsLeft deletebtnfooterred" runat="server" Text="<%$ Resources:localizedText, deletevehicletype %>" style="width: 150px !important; padding-left:0px;" />
        </section>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
      <asp:Button ID="btnBack" CssClass="BottomFooterBtnsRight backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, backButton %>"   OnClick="btnBack_Click" />
    <asp:Button ID="btnActHelp" CssClass="BottomFooterBtnsRight helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, helpButton %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
