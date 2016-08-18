<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Access_Control_NewMask.Content.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Logout.css" rel="stylesheet" />
    <script src="Scripts/Logout.js"></script>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Contentbottomarea" runat="server">
    <div class="Wrapper">
        <%--<asp:Label runat="server" CssClass="companyname" Text="Personaleinsatzplanung von Krutec SoftCon GmbH " />--%>
        <section class="labelSection">
            <asp:Label ID="Label2" runat="server" CssClass="lblTitle" Text="<%$ Resources:localizedText, doyouwanttologoutofaccesscontrol %>"></asp:Label>
        </section>
        <section class="buttonSection">
            <section class="jaButtonSection">
                <asp:Button ID="btnyes" CssClass="buttonStylenew btnJa" runat="server" Text="<%$ Resources:localizedText, yes %>" OnClick="btnyes_Click"></asp:Button>
            </section>
            <section class="neinButtonSection">
                <asp:Button ID="btnno" CssClass="buttonStylenew btnNein" runat="server" Text="<%$ Resources:localizedText, no %>" OnClick="btnno_Click"></asp:Button>
            </section>
        </section>
    </div>
</asp:Content>
