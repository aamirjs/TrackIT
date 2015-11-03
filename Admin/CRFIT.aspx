<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CRFIT.aspx.cs" Inherits="Admin_CRFIT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>CRF Information for IT</h2>
    <hr />
    <table style="width: 100%">
        <tr>
            <td style="width: 20%; vertical-align: top;">
                <h4>
                    Create an item</h4>
                <table width="100%">
                    <tr>
                        <td>
                            <span class="labels">CRF#</span>
                            <asp:TextBox CssClass="textBoxes" ID="txtCRF" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="labels">Department</span>
                            <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="false" CssClass="dropdownlists"
                                Width="200px" DataTextField="DepartmentName" DataValueField="DepartmentID" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="labels">Deployment Date</span>
                            <asp:TextBox CssClass="textBoxes" ID="txtDeploymentDate" runat="server" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDeploymentDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="labels">Deployment Time</span>
                            <asp:DropDownList ID="ddlHH" runat="server" CssClass="dropdownlists" Width="40px" />
                            <asp:DropDownList ID="ddlMM" runat="server" CssClass="dropdownlists" Width="40px" />
                            <asp:DropDownList ID="ddlAMPM" runat="server" CssClass="dropdownlists" Width="45px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="labels">Brief Description</span>
                            <asp:TextBox ID="txtDecription" runat="server" CssClass="textBoxes" Height="107px"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="labels">CRF Status</span>
                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="false" CssClass="dropdownlists"
                                DataTextField="CRFStatus" DataValueField="CRFStatusID" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCreate" runat="server" CssClass="buttons" OnClick="btnCreate_Click"
                                Text="Create" />
                            <asp:Button ID="btnUpdate" runat="server" CssClass="buttons" OnClick="btnUpdate_Click"
                                Text="Update" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top; text-align: left; width: 80%;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                    SelectedRowStyle-BackColor="PaleGoldenrod" EmptyDataText="There are no data records to display."
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                    Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:Label ID="lblCRFId" runat="server" Text='<%# Bind("[iCRFId]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRF#">
                            <ItemTemplate>
                                <asp:Label ID="lblCRFNo" runat="server" Text='<%# Bind("[vcCRFNo]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartmentID" runat="server" Text='<%# Bind("[iDepartmentID]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Department">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("[vcDepartment]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deployment Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDeploymentDate" runat="server" Text='<%# Bind("[sdtDeploymentDate]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Deployment Time">
                            <ItemTemplate>
                                <asp:Label ID="lblDeploymentTime" runat="server" Text='<%# Bind("[dtDeploymentTime]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("[vcDescription]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRF StatusID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCRFStatusID" runat="server" Text='<%# Bind("[iCRFStatusID]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CRF Status">
                            <ItemTemplate>
                                <asp:Label ID="lblCRFStatus" runat="server" Text='<%# Bind("[vcCRFStatus]") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="dtCreateTime" HeaderText="Created" />
                        <asp:BoundField DataField="dtUpdateTime" HeaderText="Updated" />
                    </Columns>
                </asp:GridView>
                <span style="color: Red">
                    <%= ErrorMessage %></span>
            </td>
        </tr>
    </table>
</asp:Content>
