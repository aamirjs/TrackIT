<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RaiseCRF_A.aspx.cs" Inherits="RaiseCRF_A"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h1>Raise CRF A for items</h1>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRFNo" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}" HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}" ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description" NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />            
        </Columns>
    </asp:GridView>
</asp:Content>
