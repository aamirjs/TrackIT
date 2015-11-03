<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Progress.aspx.cs" Inherits="Progress" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Progress</h2>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt" >
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="SOL_ARCHITECT" HeaderText="SOL_ARCHITECT" />
            <asp:BoundField DataField="WORKSHOP" HeaderText="WORKSHOP" />
            <asp:BoundField DataField="RCAPROP" HeaderText="RCAPROP" />
            <asp:BoundField DataField="CRFA" HeaderText="CRFA" />
            <asp:BoundField DataField="DBA" HeaderText="DBA" />
            <asp:BoundField DataField="CODEREV" HeaderText="CODEREV" />
            <asp:BoundField DataField="UserGuide" HeaderText="UserGuide" />
            <asp:BoundField DataField="UAT" HeaderText="UAT" />
            <asp:BoundField DataField="CRFB" HeaderText="CRFB" />
            <asp:BoundField DataField="INTEG" HeaderText="INTEG" />
            <asp:BoundField DataField="Deployed" HeaderText="Deployed" />
            <asp:BoundField DataField="PDC" HeaderText="PDC" />
            <asp:BoundField DataField="HDClosed" HeaderText="HDClosed" />
            <asp:BoundField DataField="Closed" HeaderText="Closed" />
        </Columns>
    </asp:GridView>
</asp:Content>
