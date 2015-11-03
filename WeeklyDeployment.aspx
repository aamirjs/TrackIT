<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="WeeklyDeployment.aspx.cs" Inherits="WeeklyDeployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Deployed Items</h2>
    <hr />
     <div style="text-align: center; color: Red; width: 100%; font-weight: bolder; height: 15px;
                display: inline; width: 18%;">
                <%= ErrorMessage %>
    </div>
    
    <asp:Panel ID="Panel1" runat="server" />
    
            
<%--    <asp:GridView ID="gvWeeklyDeployment" runat="server" CssClass="mGrid" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("vcRemark") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Description") %>' Width="300px"
                        NavigateUrl='<%# Eval("Name", "Admin/UpdateItem.aspx?Name={0}") %>' ControlStyle-ForeColor="Green"
                        Target="_top" ToolTip='<%# Eval("vcRemark") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Deployed" HeaderText="Deployed" />
            <asp:BoundField DataField="TheWeek" HeaderText="Week" />
        </Columns>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>--%>
</asp:Content>
