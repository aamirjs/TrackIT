<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Remarks.aspx.cs" Inherits="Remarks"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" AllowSorting="True"
        DataSourceID="SqlDataSource1" >
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="CRF" HeaderText="CRF" SortExpression="CRF" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
            <asp:BoundField DataField="RemarkDate" HeaderText="RemarkDate" SortExpression="RemarkDate" />
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <HeaderStyle ForeColor="White" />
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbSigma %>"
        SelectCommand="
                        SELECT 
                        R.iItemID ID,	
                        vcCRFNumber 'CRF',	
                        vcCRPRTDR Name,	
                        left(vcDescription, 70) Description,	
                        vcRemark Remark,	
                        Convert(varchar, sdtRemarkDate, 102) RemarkDate 
                        from tbItemRemarks R
                        JOIN tbItems I on R.iItemID = I.iItemID
                        order by RemarkDate  desc" 
                        SelectCommandType="Text"></asp:SqlDataSource>
</asp:Content>
