<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TreeViewTest.aspx.cs" Inherits="TreeViewTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4><%= ErrorMessage %></h4>
    <table>
        <tr>
            <td style="vertical-align:top; width: 10%;">
                <asp:TreeView ID="treeView1" runat="server" OnSelectedNodeChanged="treeView1_SelectedNodeChanged">
                </asp:TreeView>
            </td>
            <td style="vertical-align:top; padding-left: 5px; width: 90%;">
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt" >
                    <Columns>
                        <asp:BoundField DataField="SNo" HeaderText="SNo" />
                        <asp:BoundField DataField="CRF" HeaderText="CRF" />
                        <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}" HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" />
                        <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}" ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description" NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
