<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Reminders.aspx.cs" Inherits="Reminders" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Reminders</h2>
    <hr />
    <table>
        <tr>
            <td style="vertical-align: top; padding-top: 2px;">
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px; padding-right: 2px;">
                            Item
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCRPRTDR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCRPRTDR_SelectedIndexChanged"
                                CssClass="dropdownlists" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px">
                            Date
                        </td>
                        <td>
                            <asp:TextBox ID="txtReminderDate" runat="server" CssClass="textBoxes" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtReminderDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px">
                            About
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemindFor" runat="server" MaxLength="50" TextMode="MultiLine"
                                CssClass="textBoxes" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px">
                            Recur
                        </td>
                        <td>
                            <asp:CheckBox ID="cbRecur" runat="server" Text="" CssClass="buttons" />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left; padding-left: 5px">
                        </td>
                        <td>
                            <asp:Button ID="btnAddReminder" runat="server" CssClass="buttons" Text="Save" OnClick="btnAddReminder_Click" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top">
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="true">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <div style="text-align: center; color: Red; width: 100%; font-weight: bolder;">
        <%= ErrorMessage %>
    </div>
</asp:Content>
