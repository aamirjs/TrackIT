<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FullDump.aspx.cs" Inherits="FullDump"  EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <h2>Dimensions Dump</h2>
            <hr />
    <asp:Label ID="Label1" runat="server" />
    <%--<asp:GridView ID="gvAllItems" runat="server" CssClass="mGrid" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
               <asp:TemplateField HeaderText="Name" >
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("Remarks") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}" 
			ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description" ControlStyle-Width="300px" 
			NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" ItemStyle-Wrap="true" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Updated" HeaderText="Updated"/>
            <asp:BoundField DataField="Now" HeaderText="Now"/>
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="10px" ItemStyle-Wrap="true" />
        </Columns>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    --%>
    <asp:GridView ID="gvAllItems" runat="server" CssClass="mGrid" AutoGenerateColumns="true">
    </asp:GridView>
    
</asp:Content>
