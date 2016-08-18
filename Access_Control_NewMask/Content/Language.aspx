<%@ Page Title="<%$ Resources:localizedText, language %>" ClientIDMode="Static" Language="C#" MasterPageFile="~/MasterPages/Secondary.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="Access_Control_NewMask.Content.Language" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Language.css" rel="stylesheet" />
    <script src="Scripts/Language.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ModuleNavBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <div class="Wrapper">
        <asp:Label ID="Label1" runat="server" Text="Sprachumstellung" CssClass="titlelang" Style="display:none;"></asp:Label>
        <section class="secSprache">
            <section class="secListSpache">
                <asp:CheckBoxList ID="ListSprache" runat="server" TextAlign="Left" Font-Names="Segoe UI,Tahoma,Arial,Geneva,Verdana,sans-serif" Font-Size="16px" RepeatLayout="Table" CssClass="ListSpache">
                    <asp:ListItem Value="de-DE" Text="<%$ Resources:localizedText, german %>" class="secOption" />
                    <asp:ListItem Value="en-GB" Text="<%$ Resources:localizedText, english %>" class="secOption" />
                </asp:CheckBoxList>
            </section>
            <section class="secFooterSprache">
              
             
            </section>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterLeft" runat="server">
        <asp:Button ID="btnSave" CssClass="BottomFooterBtnsLeft_100 btnSave" runat="server" Text="<%$ Resources:localizedText, saveSetting %> " OnClick="btnSave_Click"  />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterRight" runat="server">
     <asp:Button ID="btnBack" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, back %> " OnClick="btnBack_Click" />
     <asp:Button ID="btnBackFooter" CssClass="backbtnfooterred" runat="server" Text="<%$ Resources:localizedText, back %>" Style="display:none;" />
    <asp:Button ID="btnActHelp" CssClass="helpbtnfooterblue" runat="server" Text="<%$ Resources:localizedText, help %>" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
</asp:Content>
