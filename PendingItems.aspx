<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PendingItems.aspx.cs" Inherits="PendingItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Dashboard</h2>
    <hr />
    <h4>
        Conflicts</h4>
    <asp:GridView ID="gvConflicts" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                        Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("vcRemark") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Description") %>' Width="300px"
                        NavigateUrl='<%# Eval("Name", "Admin/UpdateItem.aspx?Name={0}") %>' ControlStyle-ForeColor="Green"
                        Target="_top" ToolTip='<%# Eval("vcRemark") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Items Pending for the RCA/Proposal Approval
    </h4>
    <asp:GridView ID="gvPendingRCAPropApprovals" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRFNo" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
            <asp:BoundField DataField="Current State" HeaderText="Now" SortExpression="Current State" />
            <asp:BoundField DataField="Hist Status" HeaderText="Was" SortExpression="Hist Status" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Items Pending CRF A approval</h4>
    <asp:GridView ID="gvPendingApprovalA" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt" ForeColor="Red">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Items Pending DBA Review</h4>
    <a href="#" id="hlPendingDBAReview">[+]</a><br />
    <div id="divPendingDBAReview" class="slidingDiv">
        <asp:GridView ID="gvPendingDBAReview" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
                <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                    HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                    Target="_self" />
                <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                    ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                    NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
                <asp:BoundField DataField="Build" HeaderText="Build" />
                <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
                <asp:BoundField DataField="Current State" HeaderText="Now" SortExpression="Current State" />
                <asp:BoundField DataField="Hist Status" HeaderText="Was" SortExpression="Hist Status" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <h4>
        Items Pending CRF B approval</h4>
    <asp:GridView ID="gvPendingApprovalB" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt" ForeColor="Red">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Now" HeaderText="Now" SortExpression="Now" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Prepare for Integration Test & Deployment</h4>
    <asp:GridView ID="gvPrepareForDeployment" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRFNo" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Delivered to IT for Deployment</h4>
    <asp:GridView ID="gvPendingDeployment" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRFNo" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        This week Deployments</h4>
    <asp:GridView ID="gvThisWeekDeps" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRFNo" SortExpression="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Was" HeaderText="Was" />
            <asp:BoundField DataField="HistDate" HeaderText="HistDate" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="LastDate" HeaderText="LastDate" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Previous Week Deployments</h4>
    <asp:GridView ID="gvPrevWeekDeps" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AutoGenerateColumns="false" AlternatingRowStyle-CssClass="alt">
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                Target="_self" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
            <asp:BoundField DataField="Build" HeaderText="Build" />
            <asp:BoundField DataField="Was" HeaderText="Was" />
            <asp:BoundField DataField="HistDate" HeaderText="HistDate" />
            <asp:BoundField DataField="Now" HeaderText="Now" />
            <asp:BoundField DataField="LastDate" HeaderText="LastDate" />
        </Columns>
    </asp:GridView>
    <br />
    <h4>
        Items Pending PDC</h4>
    <a href="#" id="hlPendingPDC">[+]</a><br />
    <div id="divPendingPDC" class="slidingDiv">
        <asp:GridView ID="gvItemsPendingPDC" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="SNo" HeaderText="SNo" SortExpression="SNo" />
                <asp:BoundField DataField="CRF No" HeaderText="CRF No" SortExpression="CRF No" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                            Target="_self" Text='<%# Eval("Name") %>' ToolTip='<%# Eval("vcRemark") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Description") %>' Width="300px"
                            NavigateUrl='<%# Eval("Name", "Admin/UpdateItem.aspx?Name={0}") %>' ControlStyle-ForeColor="Green"
                            Target="_top" ToolTip='<%# Eval("vcRemark") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Build" HeaderText="Build" />
                <asp:BoundField DataField="Deployed" HeaderText="Deployed" />
                <asp:BoundField DataField="PDC Requested" HeaderText="PDC Req" />
                <asp:BoundField DataField="PDC Recieved" HeaderText="PDC Recd" />
                <asp:BoundField DataField="vcRemark" HeaderText="Remarks" />
            </Columns>
        </asp:GridView>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            try {
                $('#hlPendingCRFApproal').click(function() {
                    $("#PendingCRFApproval").toggle(1000);
                });

                $('#hlPendingDBAReview').click(function() {
                    $("#divPendingDBAReview").toggle(1000);
                });

                $("#hlPendingPDC").click(function() {
                    $("#divPendingPDC").toggle(1000);
                });

            }
            catch (err) {
                $(".labels").text(err);
            }
        });
    </script>

</asp:Content>
