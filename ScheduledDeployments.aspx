<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduledDeployments.aspx.cs" Inherits="ScheduledDeployments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Scheduled Deployment Dates</h2>
    <hr />
    <table>
        <tr>
            <td>
                <div style="overflow: scroll; height: 500px;">
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        DataKeyNames="sdtScheduledDeploymentDate">
                        <SelectedRowStyle BackColor="#FF9900" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td style="vertical-align: top">
                <asp:GridView ID="GridView2" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="hyperlink1" runat="server" NavigateUrl='<%# Eval("vccrprtdr", "admin/updateitemstatus.aspx?name={0}") %>'
                                    Target="_top" Text='<%# Eval("vccrprtdr") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="vcDescription" HeaderText="Description" ReadOnly="True"
                            SortExpression="Description" />
                        <asp:BoundField DataField="sdtScheduledDeploymentDate" HeaderText="Scheduled Date" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
