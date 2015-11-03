<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="IncidentManagement.aspx.cs" Inherits="Admin_IncidentManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Incident Information</h2>
    <hr />

    <table border="1" style="border-style: solid; border-color: #000080; width: 100%;">
        <tr>
            <td style="vertical-align: top; width: 70%">
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    OnRowDeleting="GridView1_RowDeleting"
                    AlternatingRowStyle-CssClass="alt" DataKeyNames="ID" AllowPaging="true" HeaderStyle-CssClass="grd_head"
                    OnSorting="GridView1_Sorting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="50">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:TemplateField HeaderText="ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbliIncidentID" runat="server" Text='<%# Bind("ID") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                    Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle BackColor="#66CCFF" Font-Italic="True" />
                    <HeaderStyle CssClass="grd_head"></HeaderStyle>
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
                <br />
                <asp:Button ID="btnNew" runat="server" Text="Add" CssClass="buttons" OnClick="btnNew_Click" />
            </td>
        </tr>
    </table>
    <span style="color: Red">
        <%= ErrorMessage %></span>
</asp:Content>
