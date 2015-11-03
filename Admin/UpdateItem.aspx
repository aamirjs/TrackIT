<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UpdateItem.aspx.cs" Inherits="UpdateItem" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Edit Information</h2>
    <hr />
    <table style="width: 100%">
        <tr>
            <td style="vertical-align: top;">
                <div style="padding-left: 1%; width: 400px;">
                    <h4>
                        Update an item</h4>
                    <table>
                        <tr>
                            <td style="">
                                Item ID
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemID" runat="server" CssClass="readonlytextBoxes" ReadOnly="true" >-1</asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="">
                                CRPRTDR
                            </td>
                            <td>
                                <asp:TextBox ID="txtCRPRTDR" runat="server" CssClass="readonlytextBoxes" ReadOnly="true" >0</asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Type
                            </td>
                            <td>
                                <asp:TextBox ID="txtItemType" runat="server" CssClass="readonlytextBoxes" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CRF Number (000-000)
                            </td>
                            <td>
                                <asp:TextBox ID="txtCRFNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtCRFNumber" Display="Dynamic" ValidationExpression="^\d{3}-\d{3}$">Format is 000-000</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Severity
                            </td>
                            <td>
                                <asp:TextBox ID="txtSeverity" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtSeverity" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>
                        <tr>
                            <td>
                                Priority
                            </td>
                            <td>
                                <asp:TextBox ID="txtPriority" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtPriority" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>
                        <tr>
                            <td>
                                Estimated Effort (Hours)
                            </td>
                            <td>
                                <asp:TextBox ID="txtEstimatedEffortHrs" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtEstimatedEffortHrs" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>
                        <tr>
                            <td>
                                Actual Effort (Hours)
                            </td>
                            <td>
                                <asp:TextBox ID="txtActualEffortHrs" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtActualEffortHrs" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>                        <tr>
                            <td>
                                Charge Number
                            </td>
                            <td>
                                <asp:TextBox ID="txtChargeNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer Reference Number
                            </td>
                            <td>
                                <asp:TextBox ID="txtCustomerReferenceNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cross Generic Relation
                            </td>
                            <td>
                                <asp:TextBox ID="txtCrossGenericRelation" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Deployment Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeploymentDate" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                Dependent Relation
                            </td>
                            <td>
                                <asp:TextBox ID="txtDependentRelation" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Percent Completed
                            </td>
                            <td>
                                <asp:TextBox ID="txtPercentComplete" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtPercentComplete" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rank
                            </td>
                            <td>
                                <asp:TextBox ID="txtRank" runat="server" CssClass="textBoxes"></asp:TextBox>
                            </td>
                            <td>
<%--                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="RegularExpressionValidator"
                                    ControlToValidate="txtPercentComplete" Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
--%>                            </td>
                        </tr>
                        <tr>
                            <td>
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
                            <td>
                                Title
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
                            <td>
                                Detailed Description
                            </td>
                            <td>
                                <asp:TextBox ID="txtDetailedDescription" runat="server" CssClass="textBoxes" Height="107px"
                                    TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                            <td>
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
                            <td>
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
                            <td>
                                Created On
                            </td>
                            <td>
                                <asp:TextBox ID="txtCreateDate" runat="server" CssClass="readonlytextBoxes" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="buttons" OnClick="btnUpdate_Click"
                                Text="Update" />
                            <asp:Button ID="btnBack" runat="server" CssClass="buttons" OnClick="btnBack_Click"
                                Text="Back" />
                            </td>
                            <td>
                            </td>
                        <td>
                        </td>
                    </table>
                </div>
            </td>
            <td style="vertical-align: top; width: 500px;">
                <div style="padding-left: 1%; vertical-align: top; height: 43px; width: 371px;">
                    <h4>
                        Select Developers of this item</h4>
                    <asp:CheckBoxList ID="cblUsers" runat="server" AutoPostBack="false" RepeatColumns="2"
                        RepeatLayout="Table" Height="16px" Width="476px">
                    </asp:CheckBoxList>
                </div>
            </td>
        </tr>
    </table>
    <span style="color: Red">
        <%= ErrorMessage %></span>
</asp:Content>
