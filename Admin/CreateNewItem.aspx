<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreateNewItem.aspx.cs" Inherits="_CreateNewItem" Title="Create New Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <h2>New Item Information</h2>        
            <hr />

            <span style="color: Red"> <%= ErrorMessage %></span>
            <table>
                <tr>
                    <td valign="top">
                        <table>
                            <tr>
                                <td style="width:200px">
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
                                <td >
                                    CRF Number (000-000)</td>
                                <td>
                                    <asp:TextBox ID="txtCRFNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ErrorMessage="RegularExpressionValidator" ControlToValidate="txtCRFNumber" 
                                        Display="Dynamic" ValidationExpression="^\d{3}-\d{3}$">Format is 000-000</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Severity</td>
                                <td>
                                    <asp:TextBox ID="txtSeverity" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ErrorMessage="RegularExpressionValidator" ControlToValidate="txtSeverity" 
                                        Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Priority</td>
                                <td>
                                    <asp:TextBox ID="txtPriority" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                        ErrorMessage="RegularExpressionValidator" ControlToValidate="txtPriority" 
                                        Display="Dynamic" ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Estimated Effort</td>
                                <td>
                                    <asp:TextBox ID="txtEstimatedEffort" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                        ErrorMessage="RegularExpressionValidator" 
                                        ControlToValidate="txtEstimatedEffort" Display="Dynamic" 
                                        ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Charge Number</td>
                                <td>
                                    <asp:TextBox ID="txtChargeNumber" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    Customer Reference Number</td>
                                <td>
                                    <asp:TextBox ID="txtCustomerReferenceNumber" runat="server" 
                                        CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
                                    Percent Completed</td>
                                <td>
                                    <asp:TextBox ID="txtPercentComplete" runat="server" CssClass="textBoxes"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                        ErrorMessage="RegularExpressionValidator" 
                                        ControlToValidate="txtPercentComplete" Display="Dynamic" 
                                        ValidationExpression="^\d+$">Must be digits</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td >
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
                                <td >
                                    Title</td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="textBoxes" Height="107px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    Detailed Description</td>
                                <td>
                                    <asp:TextBox ID="txtDetailedDescription" runat="server" CssClass="textBoxes" Height="107px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td >
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
                                <td >
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
                                <td >
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
                                <td >
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="buttons" OnClick="btnSubmit_Click"
                                        Text="Create" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        
                    <h4>Select Developers of this item</h4>
    
                    <asp:CheckBoxList ID="cblUsers" runat="server" AutoPostBack="false"  
                    RepeatColumns="2" 
                    RepeatLayout="Table"
                    Height="22px" Width="200" >
                    </asp:CheckBoxList>
                    
                    
                    </td>
                </tr>
            </table>
        
</asp:Content>
