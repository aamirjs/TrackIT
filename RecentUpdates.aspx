<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecentUpdates.aspx.cs" Inherits="RecentUpdates"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Recent Updates</h2>
        <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
            AllowSorting="True" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="SNo" HeaderText="SNo" ReadOnly="True" SortExpression="SNo" />
                <asp:BoundField DataField="CRF" HeaderText="CRF" SortExpression="CRF" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                            Target="_self" Text='<%# Eval("Name") %>' ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" SortExpression="Description" />
                <asp:BoundField DataField="Build" HeaderText="Build" SortExpression="Build" />
                <asp:BoundField DataField="Now" HeaderText="Now" SortExpression="Now" />
                <asp:BoundField DataField="StatusDate" HeaderText="StatusDate" />
                <asp:BoundField DataField="Updated" HeaderText="Updated" ReadOnly="True" SortExpression="Updated" />
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
            <HeaderStyle ForeColor="White" />
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:dbSigma %>" 
            SelectCommand="uspGetRecentUpdates" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
</asp:Content>

