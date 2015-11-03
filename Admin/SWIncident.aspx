<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SWIncident.aspx.cs" Inherits="SWIncident" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <h2>Software Incidents per Item</h2>
        <hr />

        <table id="swincidents"  class="swincidents" >
            <tr>
                <td >
                    CR/PR/TDR
                </td>
                <td >
                    <asp:DropDownList ID="ddlCRPRTDR" runat="server" AutoPostBack="True" CssClass="dropdownlists" 
                    OnSelectedIndexChanged="ddlCRPRTDR_SelectedIndexChanged" />
                </td>
                <td >
                    Incident Number</td>
                <td >
                    <asp:TextBox ID="txtincidentNumber" runat="server" CssClass="textBoxes" ></asp:TextBox>             </td>
                <td>
                    Has Incident</td>
                <td >
                    <asp:RadioButton ID="rbHasIncidentYes" runat="server" Text="Yes" GroupName="HasIncident" CssClass="buttons"/>
                    <asp:RadioButton ID="rbHasIncidentNo" runat="server" Text="No" GroupName="HasIncident" CssClass="buttons"/>
                </td>
            </tr>
            <tr>
                <td >
                    Incident Description</td>
                <td  >
                    <asp:TextBox ID="txtIncidentDescription" runat="server" TextMode="MultiLine" CssClass="textBoxes"/>
                </td>
                <td  >
                    Incident Date</td>
                <td  >
                    <asp:TextBox ID="txtincidentDate" runat="server" CssClass="textBoxes" />
                </td>
                <td >
                    Hot fixed<br />
                </td>
                <td >
                    <asp:RadioButton ID="rbHotFixedYes" runat="server" Text="Yes" GroupName="HotFixed" CssClass="buttons"/>
                    <asp:RadioButton ID="rbHotFixedNo" runat="server" Text="No" GroupName="HotFixed" CssClass="buttons"/>
                    <br />
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td >
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtincidentDate" />
                </td>
                <td >
                    Rolled back</td>
                <td >
                    <asp:RadioButton ID="rbRolledBackYes" runat="server" Text="Yes" GroupName="RolledBack" CssClass="buttons"/>
                    <asp:RadioButton ID="rbRolledBackNo" runat="server" Text="No" GroupName="RolledBack" CssClass="buttons"/>
                </td>
            </tr>
            </table>
                    <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="buttons" onclick="btnCreate_Click"  />
                    <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="buttons" OnClick="btnSave_Click"  />
           <div style="text-align: center; color: Red; width: 100%; font-weight: bolder; height: 15px;
            display: inline;">
            <%= ErrorMessage %></div>
        <br />

    <br />
    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
        DataKeyNames="iIncidentID" OnRowDataBound="GridView1_RowDataBound"
        OnRowDeleting="GridView1_RowDeleting" AutoGenerateSelectButton="True" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="iIncidentID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lbliIncidentID" runat="server" Text='<%# Bind("iIncidentID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Incident Number">
                <ItemTemplate>
                    <asp:Label ID="lblIncidentNumber" runat="server" Text='<%# Bind("vcIncidentNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Incident Date">
                <ItemTemplate>
                    <asp:Label ID="lblIncidentDate" runat="server" Text='<%# Bind("sdtIncidentDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="iItemID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lbliItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CRPRTDR" Visible="True">
                <ItemTemplate>
                    <asp:Label ID="lblCRPRTDR" runat="server" Text='<%# Bind("vcCRPRTDR") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Incident Details" Visible="True">
                <ItemTemplate>
                    <asp:Label ID="lblvcDescription" runat="server" Text='<%# Bind("vcDescription") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtvcDescription" runat="server" Text='<%# Bind("vcDescription") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Has Incident">
                <ItemTemplate>
                    <asp:Label ID="lblbHasIncident" runat="server" Text='<%# Bind("bHasIncident") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rolled Back">
                <ItemTemplate>
                    <asp:Label ID="lblRolledback" runat="server" Text='<%# Bind("bRolledBack") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hot fixed">
                <ItemTemplate>
                    <asp:Label ID="lblHotfixed" runat="server" Text='<%# Bind("bHotfixed") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Updated" Visible="True">
                <ItemTemplate>
                    <asp:Label ID="lbldtUpdateDate" runat="server" Text='<%# Bind("dtUpdateDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pgr"></PagerStyle>
        <SelectedRowStyle BackColor="#FF9933" BorderStyle="Solid" />
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
    </asp:GridView>

</asp:Content>
