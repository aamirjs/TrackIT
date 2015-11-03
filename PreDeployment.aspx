<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PreDeployment.aspx.cs" Inherits="PreDeployment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Pre Deployment Checklist</h2>
    <asp:GridView ID="gvPreDeployment" runat="server" CssClass="mGrid" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="SNo"	 HeaderText="SNo"/>
            <asp:BoundField DataField="CRF No" HeaderText="CRF"/>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("vcRemarks") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}" ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description" NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" /> --%>
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="RCA_Proposal_Approved" HeaderText="RCA/Prop App"/>
            <asp:BoundField DataField="CRF_A_Requested" HeaderText="CRF A Requested"/>
            <asp:BoundField DataField="CRF_A_Approved" HeaderText="CRF A Approved"/>
            <asp:BoundField DataField="DBA_Reviewed" HeaderText="DBA Reviewed"/>
            <asp:BoundField DataField="QA_Completed" HeaderText="QA Completed"/>
            <asp:BoundField DataField="UAT_Completed" HeaderText="UAT Completed"/>
            <asp:BoundField DataField="CRF_B_Requested" HeaderText="CRF B Requested"/>
            <asp:BoundField DataField="CRF_B_Approved" HeaderText="CRF B Approved"/>
            <asp:BoundField DataField="Merge_To_Release" HeaderText="Merge To Release"/>
            <asp:BoundField DataField="Integration_Testing" HeaderText="Integration Testing"/>
            <asp:BoundField DataField="Deployed" HeaderText="Deployed"/>
        </Columns>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>

