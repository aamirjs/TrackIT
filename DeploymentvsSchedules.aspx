<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DeploymentvsSchedules.aspx.cs" Inherits="DeploymentvsSchedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Deployments VS Planned</h2>
    <hr />
    <h3>Missed Deadlines</h3>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False">
        <SelectedRowStyle BackColor="#FF9900" />
        <Columns>
            <asp:BoundField DataField="vcCRFNumber" HeaderText="CRF#" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dtScheduled" HeaderText="Scheduled" />
            <asp:BoundField DataField="dtDeployed" HeaderText="Deployed" />
            <asp:BoundField DataField="DaysDelayed" HeaderText="Delay (Days)" />
            <asp:BoundField DataField="State" HeaderText="State" />
        </Columns>
    </asp:GridView>
    <h2>Schedule VS Deployments</h2>
    <asp:GridView ID="GridView2" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False">
        <SelectedRowStyle BackColor="#FF9900" />
        <Columns>
            <asp:BoundField DataField="vcCRFNumber" HeaderText="CRF#" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dtScheduled" HeaderText="Scheduled" />
            <asp:BoundField DataField="dtDeployed" HeaderText="Deployed" />
            <asp:BoundField DataField="DaysDelayed" HeaderText="Delay (Days)" />
            <asp:BoundField DataField="State" HeaderText="State" />
        </Columns>
    </asp:GridView>
    <h2>Schedule VS Deployments</h2>
    <asp:GridView ID="GridView3" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False">
        <SelectedRowStyle BackColor="#FF9900" />
        <Columns>
            <asp:BoundField DataField="vcCRFNumber" HeaderText="CRF#" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dtScheduled" HeaderText="Scheduled" />
            <asp:BoundField DataField="dtDeployed" HeaderText="Deployed" />
            <asp:BoundField DataField="DaysDelayed" HeaderText="Delay (Days)" />
            <asp:BoundField DataField="State" HeaderText="State" />
        </Columns>
    </asp:GridView>
    <h2>Schedule VS Deployments</h2>
    <asp:GridView ID="GridView4" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False">
        <SelectedRowStyle BackColor="#FF9900" />
        <Columns>
            <asp:BoundField DataField="vcCRFNumber" HeaderText="CRF#" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dtScheduled" HeaderText="Scheduled" />
            <asp:BoundField DataField="dtDeployed" HeaderText="Deployed" />
            <asp:BoundField DataField="DaysDelayed" HeaderText="Delay (Days)" />
            <asp:BoundField DataField="State" HeaderText="State" />
        </Columns>
    </asp:GridView>
</asp:Content>
