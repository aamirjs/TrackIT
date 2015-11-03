<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FillChecklist.aspx.cs" Inherits="FillChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <h2>Fill Checklist</h2>        
            <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <span style="color: Red">
                    <%= ErrorMessage %></span>
                <table>
                    <tr>
                        <td style="vertical-align: top;">
                            <div style="">
                                <asp:DropDownList ID="ddlCRPRTDR" runat="server" AutoPostBack="True" CssClass="dropdownlists"
                                    OnSelectedIndexChanged="ddlCRPRTDR_SelectedIndexChanged" />
                                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" CssClass="dropdownlists"
                                    OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    <asp:ListItem Text=" DEV" Value="DEV" />
                                    <asp:ListItem Text=" QA" Value="QA" />
                                    <asp:ListItem Text=" RMO" Value="RMO" />
                                </asp:DropDownList>
                                <asp:Button ID="btnFreeze" runat="server" Text="Freeze" OnClick="btnFreeze_Click" CssClass="buttons" />
                                <asp:Button ID="btnUnFreeze" runat="server" Text="UnFreeze" OnClick="btnUnFreeze_Click" CssClass="buttons" />
                                <asp:Image ID="ImgLocked" runat="server" ImageUrl="~/images/unlocked.png" Height="30" Width="30" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" colspan="2">
                            <asp:GridView ID="GridView1" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                runat="server" AutoGenerateColumns="False" DataKeyNames="iItemID,iSequence" OnRowDataBound="GridView1_RowDataBound"
                                OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Entry" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEntryID" runat="server" Text='<%# Bind("iEntryID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sequence" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSequenceID" runat="server" Text='<%# Bind("iSequence") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="vcOwner" HeaderText="Owner" />
                                    <asp:TemplateField HeaderText="Description" ControlStyle-Width="300px" ItemStyle-Wrap="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("vcDescription") %>'
                                                Width="55px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comments">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("vcComment") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Button" Text="Yes" CommandName="Yes" ControlStyle-CssClass="gridbuttons" />
                                    <asp:ButtonField ButtonType="Button" Text="No" CommandName="No" ControlStyle-CssClass="gridbuttons" />
                                    <asp:ButtonField ButtonType="Button" Text="Na" CommandName="Na" ControlStyle-CssClass="gridbuttons" />
                                    <asp:TemplateField HeaderText="Updated On">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUpdated" runat="server" Text='<%# Bind("dtUpdTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Selection">
                                        <ItemTemplate>
                                            <asp:Image ID="ImgResponse" runat="server" ImageUrl="~/images/not_ok_icon.png" Height="30" Width="30" />
                                            <%--<asp:Image ID="ImgLocked" runat="server" ImageUrl="~/images/unlocked.png" Height="30" Width="30" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="vcResponse" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResponse" runat="server" Text='<%# Bind("vcResponse") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Locked" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocked" runat="server" Text='<%# Bind("bLocked") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="btnFreeze" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlCRPRTDR" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
