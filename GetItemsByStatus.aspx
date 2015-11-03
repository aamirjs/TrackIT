<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GetItemsByStatus.aspx.cs" Inherits="GetItemsByStatus"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h2>Search By Status</h2>
            <hr />

<div style="vertical-align:top;">
<span class="labels">Select Item:</span>    
<asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true"     Width="200px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="dropdownlists"/>
</div>    
<br />
<div style="vertical-align:top;" >
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt">
    </asp:GridView>
</div>
</asp:Content>
