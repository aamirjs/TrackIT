<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucManageIncident.ascx.cs"
    Inherits="Admin_wucManageIncident" %>
<link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
<div style="padding-left: 2px;padding-bottom: 2px; background-color: #9fbe9e">
<div style="">
    <table>
        <tr>
            <td>
                Has Incidents
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbHasIncidentYes" runat="server" Text="Yes" GroupName="HasIncident"  />
                <asp:RadioButton ID="rbHasIncidentNo" runat="server" Text="No" GroupName="HasIncident" 
                    />
            </td>
        </tr>
    </table>
</div>
<div id="dvIncidentDetails" runat="server">
    <table width="100%">
        <tr>
            <td>
                Incident Description
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="textBoxes" Width="100%" />
            </td>
        </tr>
        <tr>
            <td>
                Incident Type
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="rblItemType" runat="server">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                Was it rolled back
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbRolledBackYes" runat="server" Text="Yes" />
                <asp:RadioButton ID="rbRolledBackNo" runat="server" Text="No" />
            </td>
        </tr>
        <tr>
            <td>
                Was it hot fixed.
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton ID="rbHotFixedYes" runat="server" Text="Yes" />
                <asp:RadioButton ID="rbHotFixedNo" runat="server" Text="No" />
                
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSaveIncidentInfo" runat="server" Text="Confirm" onclick="btnSaveIncidentInfo_Click"  CssClass="buttons"
         />
         
    <span style="color: #988848"><%= ItemID %></span>
             
         
    <span style="color: Red">
        <%= ErrorMessage %></span>
</div>
</div>
