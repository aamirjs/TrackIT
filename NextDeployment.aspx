<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NextDeployment.aspx.cs" Inherits="NextDeployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Scheduled Deployments</h2>
    <hr />
    <asp:GridView ID="gvScheduledDeployment" runat="server" CssClass="mGrid" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="AReq" HeaderText="A Req" />
            <asp:BoundField DataField="CRFA" HeaderText="A Done" />
            <asp:BoundField DataField="QA" HeaderText="QA" />
            <asp:BoundField DataField="BReq" HeaderText="B Req" />
            <asp:BoundField DataField="CRFB" HeaderText="B Done" />
            <asp:BoundField DataField="Merge" HeaderText="Merge" />
            <asp:BoundField DataField="Integration" HeaderText="Integration" />
            <asp:BoundField DataField="SchDepDate" HeaderText="SchDepDate" />
        </Columns>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>
