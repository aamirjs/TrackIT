<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlUpdateDeploymentDate.ascx.cs"
    Inherits="AdminWebControls_WebUserControlUpdateDeploymentDate" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="width: 100%; background-color: #9a97ee">
    <table width="100%">
        <tr>
            <td>
                Scheduled Deployment Date
                <br />
                <asp:TextBox CssClass="textBoxes" ID="txtDate" runat="server" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Delay Reason<br />
                <asp:TextBox ID="txtDelayComment" runat="server" CssClass="textBoxes" ForeColor="Red" Visible="true" TextMode="MultiLine" width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpdate" runat="server" CssClass="buttons" OnClick="btnUpdate_Click" Text="Update" />
                <asp:TextBox ID="txtItemID" runat="server" ForeColor="Red" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                History</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="true" 
                    EmptyDataText="No data available"
                    >
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <HeaderStyle ForeColor="Red" />
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <span style="color: Red">
        <%= ErrorMessage %></span>
</div>
