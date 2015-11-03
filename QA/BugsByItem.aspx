<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BugsByItem.aspx.cs" Inherits="BugsByItem" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <h2>Bugs Information</h2>
        <hr />
        <div style="text-align: center; color: Red; width: 100%; font-weight: bolder; height: 15px;
            display: inline;">
            <%= ErrorMessage %></div>
        <table>
            <tr>
                <td>
                    <h4>CR/PR/TDR</h4>
                </td>
                <td>
                    <h4>QA Phase</h4>
                </td>
                <td>
                    <h4>UAT Phase</h4>
                </td>
                <td>
                    <h4>INT Phase</h4>
                </td>
                <td>
                    <h4>Post Deployment Phase</h4></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                                 <asp:DropDownList ID="ddlCRPRTDR" runat="server" AutoPostBack="True" CssClass="dropdownlists"
            OnSelectedIndexChanged="ddlCRPRTDR_SelectedIndexChanged" Width="200px" />

                </td>
                <td>
                    
                    <h5>Number of Bugs</h5>
                    <asp:TextBox ID="txtQACount" runat="server" Width="20px"></asp:TextBox>
                    <h5>Comments</h5>
                    <asp:TextBox ID="txtQAPhaseComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
                <td>
                    <h5>Number of Bugs</h5>
                    <asp:TextBox ID="txtUATCount" runat="server"  Width="20px"></asp:TextBox>
                    <h5>Comments</h5>
                    <asp:TextBox ID="txtUATPhaseComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <h5>Number of Bugs</h5>
                    <asp:TextBox ID="txtIntCount" runat="server"  Width="20px"></asp:TextBox>
                    <h5>Comments</h5>
                    <asp:TextBox ID="txtIntPhaseComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <h5>Number of Bugs</h5>
                    <asp:TextBox ID="txtPDCount" runat="server"  Width="20px"></asp:TextBox>
                    <h5>Comments</h5>
                    <asp:TextBox ID="txtPostDepPhaseComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td><br /><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="buttons" 
                        onclick="btnSave_Click"  />
                </td>
            </tr>
        </table>


        <br />
        <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" AutoGenerateEditButton="True"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing1"
            OnRowUpdating="GridView1_RowUpdating" DataKeyNames="iBugID" 
            OnRowDataBound="GridView1_RowDataBound" onrowdeleted="GridView1_RowDeleted" 
            onrowdeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                            OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BugID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lbliBugID" runat="server" Text='<%# Bind("iBugID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbliItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QA Count" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblQACount" runat="server" Text='<%# Bind("siQACount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQACount" runat="server" Text='<%# Bind("siQACount") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QA Comment" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblQAPhaseSumm" runat="server" Text='<%# Bind("vcQAPhaseSumm") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtQAPhaseSumm" runat="server" Text='<%# Bind("vcQAPhaseSumm") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="UAT Count" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblUATCount" runat="server" Text='<%# Bind("siUATCount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUATCount" runat="server" Text='<%# Bind("siUATCount") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UAT Comments" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblUATComments" runat="server" Text='<%# Bind("vcUATPhaseSumm") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUATPhaseSumm" runat="server" Text='<%# Bind("vcUATPhaseSumm") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Integration Count" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblIntCount" runat="server" Text='<%# Bind("siIntCount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIntCount" runat="server" Text='<%# Bind("siIntCount") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Integration Comments" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblIntComments" runat="server" Text='<%# Bind("vcIntPhaseSumm") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIntPhaseSumm" runat="server" Text='<%# Bind("vcIntPhaseSumm") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Post Dep Count" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblPDCount" runat="server" Text='<%# Bind("siPostDepCount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPostDepCount" runat="server" Text='<%# Bind("siPostDepCount") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Post Deployment Comment" Visible="True">
                    <ItemTemplate>
                        <asp:Label ID="lblDevComments" runat="server" Text='<%# Bind("vcPostDepPhaseSumm") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPostDepPhaseSumm" runat="server" Text='<%# Bind("vcPostDepPhaseSumm") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pgr"></PagerStyle>
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
</asp:Content>
