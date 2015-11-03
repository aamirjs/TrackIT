<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RelatedItems.aspx.cs" Inherits="RelatedItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Related Items</h2>
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" 
        PagerStyle-CssClass="pgr" AutoGenerateColumns="False" 
        AlternatingRowStyle-CssClass="alt" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="CRF No" HeaderText="CRF No"  />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True"  />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Related_Items" HeaderText="Related_Items" />
        </Columns>
<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dbSigma %>" SelectCommand="select 
			vcCRFNumber as 'CRF No', 
			vcCRPRTDR as 'Name', 
			Left (vcDescription, 100) as 'Description',  
			vcBuildPackage as 'Build',
			vcRelateditems 'Related_Items'
from tbItems (nolock) where len(vcRelateditems) &gt; 1
and vcRelateditems NOT IN ('','NA')"></asp:SqlDataSource>
</asp:Content>

