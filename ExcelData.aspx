<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExcelData.aspx.cs" Inherits="ExcelData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

            <h2>Definitions</h2>        
            <hr />


    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Export to Excel</asp:LinkButton>
    <asp:GridView ID="GridView1" 
	runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" RowStyle-Wrap="false"  
        AlternatingRowStyle-CssClass="alt"  
        OnPageIndexChanging="GridView2_PageIndexChanging">
        <PagerStyle CssClass="pgr"></PagerStyle>
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>
</asp:Content>
