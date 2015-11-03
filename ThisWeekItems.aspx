<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ThisWeekItems.aspx.cs" Inherits="ThisWeekItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>This Week</h2>
            <hr />
    <asp:GridView ID="gvThisWeekItems" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="False" EmptyDataText="None" AllowSorting="True" OnSorting="gvThisWeekItems_Sorting">
        <Columns>
            <asp:BoundField DataField="iItemID" HeaderText="iItemID" SortExpression="iItemID" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" SortExpression="CRF No" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("vcRemark") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="Name" SortExpression="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_self">
                <ControlStyle ForeColor="Green"></ControlStyle>
            </asp:HyperLinkField>
            <asp:BoundField DataField="Build" HeaderText="Build" SortExpression="Build" />
            <asp:BoundField DataField="MainState" HeaderText="MainState" SortExpression="MainState" />
            <asp:BoundField DataField="HistState" HeaderText="HistState" SortExpression="HistState" />
            <asp:BoundField DataField="dtUpdTime" HeaderText="dtUpdTime" SortExpression="dtUpdTime" />
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    <br />
</asp:Content>
