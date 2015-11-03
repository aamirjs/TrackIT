<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PostDeployment.aspx.cs" Inherits="PostDeployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div style="vertical-align: top; text-align: left; background-color: #fff; padding:3px;">
    <h2>
        Deployed Items</h2>
    <hr />
    <asp:Label ID="Label1" runat="server" />
    <asp:GridView ID="gvPostDeploymentChecklist" runat="server" 
    CssClass="mGrid" AutoGenerateColumns="false" 
        OnRowDataBound="gvPostDeploymentChecklist_RowDataBound" 
    Font-Names="Tahoma" Font-Size="Smaller">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}&StatusID=19") %>'
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
            <asp:BoundField DataField="CRFA" HeaderText="CRF A" />
            <asp:BoundField DataField="CRFB" HeaderText="CRF B" />

            <asp:BoundField DataField="LLDInfo" HeaderText="LLD Info" />
            <asp:BoundField DataField="LLDRequired" HeaderText="LLD Required" />
            <asp:BoundField DataField="LLDNotRequired" HeaderText="LLD Not Required" />
            <asp:BoundField DataField="LLDComplete" HeaderText="LLD Complete" />

            <asp:BoundField DataField="Deployed" HeaderText="Deployed" />
            <asp:BoundField DataField="PDC Requested" HeaderText="PDC Requested" />
            <asp:BoundField DataField="PDC Recieved" HeaderText="PDC Received" />
            <asp:BoundField DataField="Merge Trunk" HeaderText="Merge Trunk" />
            <asp:BoundField DataField="Update DIM" HeaderText="Update DIM" />
            <asp:BoundField DataField="Move Shares" HeaderText="Move Shares" />
            <asp:BoundField DataField="Move Branch" HeaderText="Move Branch" />
            <asp:BoundField DataField="HDClosed" HeaderText="HD Closed" />
            <asp:BoundField DataField="Closed" HeaderText="Closed" />
        </Columns>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</div>	
</asp:Content>
