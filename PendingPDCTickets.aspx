<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PendingPDCTickets.aspx.cs" Inherits="PendingPDCTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <h4>Pending PDC Items</h4>
    <div id="divPendingPDC" class="slidingDiv">
        <asp:GridView ID="gvItemsPendingPDC" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
                <asp:BoundField DataField="CRF No" HeaderText="CRF No" SortExpression="CRF No" />
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
                <asp:BoundField DataField="PDC Requested" HeaderText="PDC Req" />
                <asp:BoundField DataField="PDC Recieved" HeaderText="PDC Recd" />
                <asp:BoundField DataField="vcRemark" HeaderText="Remarks" />
                <asp:BoundField DataField="Tickets" HeaderText="Tickets" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

