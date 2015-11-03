<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemDetail.aspx.cs" Inherits="ItemDetail"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Item History</h2>
   <asp:GridView ID="gvItemHistory" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt">
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>

