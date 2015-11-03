<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ManageIncident.aspx.cs" Inherits="Admin_ManageIncident" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <h2>Edit IT Incidents</h2>        
            <hr />
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: top; ">
                <asp:Panel ID="pnlCreate" runat="server">
                    Incident Management Form<br />
                    <br />
                    <table style="width: 100%;">
                        <tr>
                            <td style="vertical-align: top; width: 20%;">
                                ID
                            </td>
                            <td>
                                <asp:Label ID="lblIncidentID" runat="server" Width="149px" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 20%;">
                                Incident Number
                            </td>
                            <td>
                                <asp:TextBox ID="txtIncidentNumber" runat="server" Width="149px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; width: 20%;">
                                Type
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlincidentTypes" runat="server" DataTextField="vcIncidentType"
                                    DataValueField="vcIncidentType" Width="240px" AutoPostBack="True" OnSelectedIndexChanged="ddlincidentTypes_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Location
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlincidentLocations" runat="server" DataTextField="vcLocation"
                                    DataValueField="vcLocation" Width="240px" AutoPostBack="True" OnSelectedIndexChanged="ddlincidentLocations_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Incident
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIncident" runat="server" DataTextField="vcIncident" DataValueField="vcIncident"
                                    Width="240px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Impact
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlImpact" runat="server" Width="240px">
                                    <asp:ListItem Text="Minor" Value="Minor"></asp:ListItem>
                                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                    <asp:ListItem Text="Major" Value="Major"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Incident Date
                            </td>
                            <td style="height: 21px">
                                <asp:TextBox ID="txtIncidentDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIncidentDate">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Incident Time
                            </td>
                            <td style="height: 21px">
                                <asp:TextBox ID="txtincidentTime" runat="server"></asp:TextBox>(Format: hh:mm)
                                
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtincidentTime" Display="Dynamic" 
                                    ErrorMessage="Time format: HH:MM" SetFocusOnError="True" 
                                    ValidationExpression="^(20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2})$"></asp:RegularExpressionValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Description
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Height="119px" TextMode="MultiLine"
                                    Width="246px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                Approved File
                            </td>
                            <td>
                                <asp:Panel id="pnlFileUpload" runat="server">
                                <table >
                                <tr><td><asp:FileUpload ID="FileUpload1" runat="server" /></td></tr>
                                <tr><td><asp:FileUpload ID="FileUpload2" runat="server" /></td></tr>
                                <tr><td><asp:FileUpload ID="FileUpload3" runat="server" /></td></tr>
                                <tr><td><asp:FileUpload ID="FileUpload4" runat="server" /></td></tr>
                                <tr><td><asp:FileUpload ID="FileUpload5" runat="server" /></td></tr>
                                </table>
                                
                                <br />
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                    CssClass="buttons" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttons" 
                                    onclick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
            </td>
            <td style="vertical-align: top; width: 50%; padding-left: 3px;">
            <asp:Panel ID="pnlStatus" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td style="vertical-align: top; ">
                                Change Status of Incident
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIncidentStatus" runat="server" DataTextField="vcIncidentStatus"
                                    DataValueField="iIncidentStatusID" Width="236px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Save" OnClick="btnUpdateStatus_Click"
                                    CssClass="buttons" />
                                <asp:Button ID="btnCancelStatus" runat="server" Text="Cancel" CssClass="buttons"
                                    OnClick="btnCancelStatus_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="true"
                    CssClass="mGrid" 
                    PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" 
                    HeaderStyle-CssClass="grd_head">
                </asp:GridView><br />
            </td>
        </tr>
    </table>
    <span style="color: Red">
        <%= ErrorMessage %></span>
</asp:Content>
