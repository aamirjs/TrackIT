<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewItems.aspx.cs" Inherits="ViewItems"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="gvItemByCode" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="CRF" HeaderText="CRF" />
                  <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>' 
                                Target="_self" Text='<%# Eval("Name") %>' ></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}" ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description" NavigateUrl="~/Admin/UpdateItem.aspx" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />
        </Columns>
    </asp:GridView>

</asp:Content>

