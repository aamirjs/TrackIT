<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="DTSSP.aspx.cs" Inherits="Admin_DTSSP"  
MaintainScrollPositionOnPostback="true"
%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Type search string and press enter<br />

<asp:TextBox ID="txtSearch" runat="server" CssClass="textBoxes" AutoCompleteType="Search" onfocus="cleartext()"
                    AutoPostBack="True" OnTextChanged="txtNames_TextChanged" Width="800px"/>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetDatabaseObjects"
                    ServicePath="~/TrackItWebService.asmx" UseContextKey="True" TargetControlID="txtSearch"
                    MinimumPrefixLength="2" CompletionInterval="500" 
                   CompletionSetCount="5000">
                </cc1:AutoCompleteExtender>
                

<br />
    <div style="text-align: center; color: Red; width: 100%; font-weight: bolder; height: 15px;
            display: inline;">
            <%= ErrorMessage %></div>
            <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AutoGenerateColumns="false" AutoGenerateEditButton="True"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing1"
            OnRowUpdating="GridView1_RowUpdating" DataKeyNames="spid" 
            OnRowDataBound="GridView1_RowDataBound" onrowdeleted="GridView1_RowDeleted" 
            onrowdeleting="GridView1_RowDeleting" EditRowStyle-BackColor="Aquamarine">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblspID" runat="server" Text='<%# Bind("spid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" Visible="True"  ControlStyle-Width="400px" ItemStyle-Wrap="true">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' ></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' Width="400"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="description" Visible="True" ControlStyle-Width="400px" ItemStyle-Wrap="true">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" Wrap="true" Width="500" Height="100" Font-Names="Tahoma"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Updated" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblUpdated" runat="server" Text='<%# Bind("Updated") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</asp:Content>

