<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Incidents.aspx.cs" Inherits="Incidents" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
           <h2>Schedule VS Deployments</h2>
 <table >
        <tr>
            <td>
                <table>
                    <tr align="justify">
                        <td>
                            <h4>
                                Start Date</h4>
                            <asp:TextBox CssClass="textBoxes" ID="txtStartDate" runat="server" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <h4>
                                End Date</h4>
                            <asp:TextBox CssClass="textBoxes" ID="txtEndDate" runat="server" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <h4>
                                &nbsp</h4>
                            <asp:Button ID="btnFetchData" runat="server" Text="Button" CssClass="buttons" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" >
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
