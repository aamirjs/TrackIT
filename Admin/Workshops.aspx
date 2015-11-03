<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Workshops.aspx.cs" Inherits="Admin_Workshops" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Workshop Information</h2>
    <hr />
    <table>
        <tr>
            <td style="vertical-align: top;">
                <div runat="server" style="" id="PopupPanel">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Workshop ID
                                <br />
                            </td>
                            <td>
                                <asp:Label ID="lblWorkshopID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Requested By
                                <br />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRequesters" runat="server" DataValueField="UserID" DataTextField="FirstName"
                                    CssClass="dropdownlists" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CR/PR/TDR
                                <br />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCRPRTDR" runat="server" CssClass="dropdownlists" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Session Date
                                <br />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSessionDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSessionDate" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Workshop Status
                                <br />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlWorkshopStatuses" runat="server" DataValueField="siWorkshopStatusID"
                                    DataTextField="vcDescription" CssClass="dropdownlists">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align:right;">
                                <asp:Button ID="btnCreateWorkshop" runat="server" Text="Create" OnClick="btnCreateWorkshop_Click"
                                    CssClass="buttons" />
                                <asp:Button ID="btnUpdateWorkshop" runat="server" Text="Update" OnClick="btnUpdateWorkshop_Click"
                                    CssClass="buttons" />
                                <asp:Button ID="btnCancelWorkshop" runat="server" Text="Cancel" OnClick="btnCancelWorkshop_Click"
                                    CssClass="buttons" />
                </div>
                                    
                <span style="color: Red">
                    <%= ErrorMessage %></span>
            </td>
            <td>
                List of Workshops
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="iWorkshopID" EmptyDataText="There are no data records to display."
                    CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="IWorkshopID" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="VcCRPRTDR" HeaderText="Item Name" />
                        <asp:BoundField DataField="IRequesterID" HeaderText="RequesterID" Visible="false" />
                        <asp:BoundField DataField="VcFirstName" HeaderText="Requester" />
                        <asp:BoundField DataField="VcItemDescription" HeaderText="Description" />
                        <asp:BoundField DataField="IITemID" HeaderText="IITemID" Visible="false" />
                        <asp:BoundField DataField="SdtDate" HeaderText="SessionDate" />
                        <asp:BoundField DataField="SiWorkshopStatusID" HeaderText="SiWorkshopStatusID" Visible="false" />
                        <asp:BoundField DataField="VcWorkshopStatus" HeaderText="Status" />
                    </Columns>
                    <PagerStyle CssClass="pgr"></PagerStyle>
                    <SelectedRowStyle BackColor="#33CCFF" />
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <%--   <asp:Button id="b1" Text="AAA" runat="server" CssClass="modalBackground" />    
    <cc1:PopupControlExtender ID="PopupControlExtender1" 
    runat="server"
    TargetControlID="b1"
    PopupControlID="PopupPanel"
    >
    </cc1:PopupControlExtender>--%>
</asp:Content>
