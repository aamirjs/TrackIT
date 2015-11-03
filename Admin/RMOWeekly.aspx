<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RMOWeekly.aspx.cs" Inherits="RMOWeekly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="background-color:white">

    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Deployed Last Week</span>
    <asp:GridView ID="gvThisWeekDeps" runat="server" AutoGenerateColumns="false" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
        <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" SortExpression="CRF No" ControlStyle-Width="450px" />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self"  ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="HistDate" HeaderText="Deployed On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />

    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Delivered to IT for Deployment</span>
    <asp:GridView ID="gvDeliveredForDep" runat="server" AutoGenerateColumns="false" 
        Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
        <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" SortExpression="CRF No" 
                ControlStyle-Width="450px" >
<ControlStyle Width="450px"></ControlStyle>
            </asp:BoundField>
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" 
                DataNavigateUrlFields="Name" 
                DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  
                NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self"  
                ControlStyle-ForeColor="#000000">
<ControlStyle ForeColor="#336699"></ControlStyle>
            </asp:HyperLinkField>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="HistDate" HeaderText="Deployed On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />


    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Pending for the CRF A Approval</span>
    <asp:GridView ID="gvPendingCRFApprovalsA" runat="server" AutoGenerateColumns="false" 
	Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
    <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" SortExpression="CRF No" />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="Date" HeaderText="Requested On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    
    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Pending for the CRF B Approval</span>
    <asp:GridView ID="gvPendingCRFApprovalsB" runat="server" AutoGenerateColumns="false" 
	Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
    <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" SortExpression="CRF No" />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="Date" HeaderText="Requested On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />


    
    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Pending RCA/Proposal Approval</span>
    <asp:GridView ID="gvPendingRCAPropApprovals" runat="server" AutoGenerateColumns="false" 
	Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
    <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
          <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" SortExpression="SNo" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" SortExpression="CRF No" />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    
    
    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Pending DBA Review</span>
    <asp:GridView ID="gvPendingDBAReview" runat="server" AutoGenerateColumns="false" 
	Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
    <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
        <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF"  />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="Requested On" HeaderText="Requested On" SortExpression="Requested On" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    
    <span style="font-family: Century Gothic; color: #EE7328; font-size: 12pt; font-weight: bold">Items Pending PDC's</span>
    <asp:GridView ID="gvItemsPendingPDC" runat="server" AutoGenerateColumns="false" 
	Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000" Width="80%">
    <HeaderStyle BackColor="#A6A6A6" Font-Names="Tahoma" ForeColor="#000" Font-Size="10pt"/>
          <Columns>
            <asp:BoundField DataField="SNo" HeaderText="Item" />
            <asp:BoundField DataField="CRF No" HeaderText="CRF" />
            <asp:HyperLinkField DataTextField="Name" HeaderText="Name" DataNavigateUrlFields="Name" DataNavigateUrlFormatString="~/Admin/UpdateItemStatus.aspx?Name={0}"  NavigateUrl="~/Admin/UpdateItemStatus.aspx" Target="_self" ControlStyle-ForeColor="#000000"/>
            <asp:BoundField DataField="Description"  HeaderText="Item Description" />
            <asp:BoundField DataField="Deployed On" HeaderText="Deployed On" />
            <asp:BoundField DataField="PDC Requested" HeaderText="PDC Requested" />
            <asp:BoundField DataField="PDC Recieved" HeaderText="PDC Received" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    
</div>    


</asp:Content>
