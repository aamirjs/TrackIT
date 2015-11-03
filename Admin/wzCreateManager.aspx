<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="wzCreateManager.aspx.cs" Inherits="Admin_wzCreateManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Item information</h3>
    <br/>
    <asp:Wizard ID="Wizard1" runat="server" Width="100%" ActiveStepIndex="0" OnFinishButtonClick="Wizard1_FinishButtonClick">
        <SideBarTemplate>
            <asp:DataList ID="SideBarList" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server"></asp:LinkButton>
                </ItemTemplate>
                <SelectedItemStyle Font-Bold="True" />
            </asp:DataList>
        </SideBarTemplate>
        <WizardSteps>
            <asp:WizardStep ID="stpCreateItem" runat="server" Title="Main Information">
                <div id="dvCreateItem" style="padding-left: 10%; padding-right: 10%">
                    <table width="60%">
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td style="width: 97px">
                                            Type
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlItemType" runat="server" CssClass="dropdownlists">
                                                <asp:ListItem Text="CR" Value="CR_" />
                                                <asp:ListItem Text="TDR" Value="TDR_" />
                                                <asp:ListItem Text="PR" Value="PR_" />
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtItemNo" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            CRF#
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCRFNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Team
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTeam" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Description
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="textBoxes" Height="107px"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Build Package
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBuild" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Related Items
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRelatedItems" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            Owned By
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOwnedBy" runat="server" CssClass="textBoxes"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 97px">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="stbDevelopers" runat="server" Title="Users">
                <h4>
                    Select Developers of this item</h4>
                <asp:CheckBoxList ID="cblUsers" runat="server" AutoPostBack="false" RepeatColumns="2"
                    RepeatLayout="Table" Height="22px" Width="200">
                </asp:CheckBoxList>
            </asp:WizardStep>
            <asp:WizardStep ID="stpTickets" runat="server" Title="Tickets">
                <asp:GridView ID="GridViewTickets" runat="server" AlternatingRowStyle-CssClass="alt"
                    AutoGenerateColumns="true" CssClass="mGrid" EmptyDataText="No tickets attached">
                    <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                </asp:GridView>
                <span class="labels">Ticket#</span>
                <asp:TextBox ID="txtTicket" runat="server" CssClass="textBoxes" />
                <br />
                <asp:Button ID="btnAddTicket" runat="server" CssClass="buttons" Text="Add Ticket" />
            </asp:WizardStep>
        </WizardSteps>
        <SideBarStyle BackColor="#FF9900" ForeColor="#FF9900" />
    </asp:Wizard>
</asp:Content>
