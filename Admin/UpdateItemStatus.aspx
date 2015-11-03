<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UpdateItemStatus.aspx.cs" Inherits="UpdateItemStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblDocRef" runat="server"></asp:Label></h2>
            <div>
                <asp:CheckBox ID="cbCR" runat="server" Text="CR" AutoPostBack="True" OnCheckedChanged="cbCR_CheckedChanged"
                    CssClass="textBoxes" />
                <asp:CheckBox ID="cbPR" runat="server" Text="PR" AutoPostBack="True" OnCheckedChanged="cbPR_CheckedChanged"
                    CssClass="textBoxes" />
                <asp:CheckBox ID="cbTDR" runat="server" Text="TDR" AutoPostBack="True" OnCheckedChanged="cbTDR_CheckedChanged"
                    CssClass="textBoxes" />
                &nbsp
                <asp:Button ID="btnPrevious" runat="server" CssClass="buttons" OnClick="btnPrevious_Click"
                    Text="Previous" />
                <asp:Button ID="btnNext" runat="server" CssClass="buttons" OnClick="btnNext_Click"
                    Text="Next" />
                <asp:Button ID="btnRequestCRFB" runat="server" CssClass="buttons" OnClick="btnRequestCRFB_Click"
                    Text="Send CRF B" />
                <asp:Button ID="btnGeneratePDC" runat="server" CssClass="buttons" OnClick="btnGeneratePDC_Click"
                    Text="Send PDC" />
            </div>
            <div style="text-align: left; color: Red; height: 20px; display: inline;">
                <%= ErrorMessage %>
            </div>
            <div>
                <table border="0" style="padding-left: 5px; padding-right: 5px;">
                    <tr>
                        <td id="coloumn1" style="vertical-align: top; text-align: left; padding-left: 0px;
                            width: 10%">
                            <table id="updatecontrols">
                                <tr>
                                    <td>
                                        Item
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCRPRTDR" runat="server" AutoPostBack="True" CssClass="dropdownlists"
                                            OnSelectedIndexChanged="ddlCRPRTDR_SelectedIndexChanged" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Status
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdownlists" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Action Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="textBoxes" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Comments
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComments" runat="server" CssClass="textBoxes" Wrap="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="buttons" OnClick="btnUpdate_Click"
                                            Text="Update" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top; text-align: left;">
                                        Add Ticket
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTicket" runat="server" CssClass="textBoxes" Wrap="true" BackColor="Bisque" />
                                        <br />
                                        <asp:Button ID="btnAddTicket" runat="server" CssClass="buttons" OnClick="btnAddTicket_Click"
                                            Text="Add Ticket" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h5>
                                            Details</h5>
                                    </td>
                                    <td>
                                        <a href="UpdateItem.aspx?Name=<%= ItemName %>">Edit Details </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Build
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblBuild" runat="server" CssClass="textBoxes" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Developer
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblDeveloper" runat="server" CssClass="textBoxes" Enabled="false"
                                            Wrap="true" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Related Items
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblRelatedItems" runat="server" CssClass="textBoxes" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Deployment Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtScheduledDeploymentDate" runat="server" CssClass="textBoxes"
                                            BackColor="#7a9a9a" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtScheduledDeploymentDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Delay Reason
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDelayReasons" runat="server" CssClass="dropdownlists" />
                                        <asp:TextBox ID="txtDelayComment" runat="server" CssClass="textBoxes" Wrap="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUpdateDeploymentDelay" runat="server" CssClass="buttons" OnClick="btnUpdateDeploymentDelay_Click"
                                            Text="Update" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Remarks
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textBoxes" TextMode="MultiLine"
                                            Wrap="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddComment" runat="server" CssClass="buttons" OnClick="btnAddComment_Click"
                                            Text="Add Remarks" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        PDC Remarks
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPDCRemark" runat="server" CssClass="textBoxes" TextMode="MultiLine"
                                            Wrap="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAddPDCRemark" runat="server" CssClass="buttons" OnClick="btnAddPDCRemark_Click"
                                            Text="Add PDC Remarks" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <a class="hyperlinks1" href="file://<%= SharesPath %>/Build <%= Build %>/<%=ItemName %>">
                                            Link to Branch Folder</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <a class="hyperlinks1" href="file://<%= SharesPath %>/Build <%= Build %>/_Deployed/<%= ItemName %>">
                                            Link to Deployed Path</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td id="coloumn2" style="vertical-align: top; text-align: left; padding-left: 0px;
                            width: 20%;">
                            <div style="vertical-align: top;">
                                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting"
                                    RowStyle-HorizontalAlign="Left" OnRowDataBound="GridView1_RowDataBound" Width="500px">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                    OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                                    Text="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbliItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hist ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbliItemHistID" runat="server" Text='<%# Bind("iItemHistID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" Visible="false" />
                                        <asp:TemplateField HeaderText="SID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusID" runat="server" Text='<%# Bind("StatusID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="Status Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusDate" runat="server" Text='<%# Bind("[Status Date]") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments" ControlStyle-Width="100px" ItemStyle-Wrap="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblComents" runat="server" Text='<%# Bind("Comments") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <h4>
                                    Item History</h4>
                                <asp:GridView ID="GridView2" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False"
                                    CssClass="mGrid" OnRowDeleting="GridView1_RowDeleting" PagerStyle-CssClass="pgr"
                                    RowStyle-HorizontalAlign="Left">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbliItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hist ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbliItemHistID" runat="server" Text='<%# Bind("iItemHistID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <%--                                <asp:TemplateField HeaderText="Status ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusID" runat="server" Text='<%# Bind("StatusID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    --%>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="Status Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusDate" runat="server" Text='<%# Bind("[Status Date]") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments">
                                            <ItemTemplate>
                                                <asp:Label ID="lblComents" runat="server" Text='<%# Bind("Comments") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Updated" HeaderText="Updated" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                        <td id="coloumn3" style="vertical-align: top; text-align: left; padding-left: 0px;
                            overflow: visible; width: 30%;">
                            <asp:GridView ID="GridViewTickets" runat="server" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="true" CssClass="mGrid" EmptyDataText="No tickets attached">
                            </asp:GridView>
                            <h4>
                                Deployment Delays</h4>
                            <asp:GridView ID="gvDepDelays" runat="server" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="false" CssClass="mGrid" EmptyDataText="No deployment schedule available"
                                OnRowDeleting="gvDepDelays_RowDeleting" PagerStyle-CssClass="pgr">
                                <PagerStyle CssClass="pgr" />
                                <HeaderStyle ForeColor="Red" />
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                                Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HistID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHistID" runat="server" Text='<%# Bind("HistID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ItemID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sdtScheduledDeploymentDate" HeaderText="Scheduled" />
                                    <asp:BoundField DataField="vcDelayComments" HeaderText="Reason of Delay" />
                                </Columns>
                            </asp:GridView>
                            <h4>
                                Bug Lists</h4>
                            <asp:GridView ID="GridViewBugs" runat="server" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="true" CssClass="mGrid" EmptyDataText="No Bugs logged">
                            </asp:GridView>
                            <h4>
                                PDC Remarks</h4>
                            <asp:GridView ID="gvPDCRemarks" runat="server" AlternatingRowStyle-CssClass="alt"
                                AutoGenerateColumns="false" CssClass="mGrid" EmptyDataText="No PDC Remarks logged"
                                OnRowDeleting="gvPDCRemarks_RowDeleting">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeletePDCRemark" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                                Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PDCRemarkID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPDCRemarkID" runat="server" Text='<%# Bind("iPDCRemarkID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="iItemID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("iItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="dtUpdTime" HeaderText="Date" Visible="true" />
                                    <asp:BoundField DataField="vcRemark" HeaderText="Remark" Visible="true" />
                                </Columns>
                            </asp:GridView>
                            <h4>
                                General Remarks</h4>
                            <asp:GridView ID="gvRemarks" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
                                CssClass="mGrid" OnRowDeleting="gvRemarks_RowDeleting" EmptyDataText="No general remarks logged">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDeleteRemark" runat="server" CausesValidation="False" CommandName="Delete"
                                                OnClientClick="return confirm('Are you sure you want to delete this entry?');"
                                                Text="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemRemarksID" runat="server" Text='<%# Bind("iItemRemarksID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="iItemID" HeaderText="iItemID" Visible="false" />
                                    <asp:BoundField DataField="sdtRemarkDate" HeaderText="Date" Visible="true" />
                                    <asp:BoundField DataField="vcRemark" HeaderText="Remark" Visible="true" />
                                </Columns>
                            </asp:GridView>
                            <br />
                            <a class="hyperlinks1" href="file://<%= SharesPath %>/Build <%= Build %>/<%=ItemName %>">
                                Link to Branch Folder</a>
                            <br />
                            <a class="hyperlinks1" href="file://<%= SharesPath %>/Build <%= Build %>/_Deployed/<%= ItemName %>">
                                Link to Deployed Path</a>
                            <br />
                            <a class="hyperlinks1" href='..\QA\BugsByItem.aspx?ItemID=<%= ItemID %>'>Click to view
                                bugs</a>
                            <br />
                            <div style="text-align: left; color: Red; font-weight: bolder; display: block;">
                                <%= Result %>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAddComment" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvDepDelays" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="gvRemarks" EventName="RowDeleting" />
            <asp:AsyncPostBackTrigger ControlID="btnAddPDCRemark" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Label ID="lblItemID" runat="server" Visible='false' />
    <asp:Label ID="lblItemName" runat="server" Visible='false' />
    <asp:Label ID="lblDescription" runat="server" Visible='false' />
    <asp:Label ID="lblCRF" runat="server" Visible='false' />
</asp:Content>
