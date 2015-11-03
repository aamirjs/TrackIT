<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ServersNApps.aspx.cs" Inherits="ServersNApps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Applications on Servers</h2>
    <hr />
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="True">
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    </div>
</asp:Content>
