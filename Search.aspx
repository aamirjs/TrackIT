<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <h2>Search Items</h2>        
            <hr />
    <span style="color: Red">
        <%= ErrorMessage %></span>
        <table style="width:100%">
        <tr>
            <td>
                <asp:TextBox ID="txtNames" runat="server" CssClass="textBoxes" AutoCompleteType="Search" onfocus="cleartext()"
                    AutoPostBack="True" OnTextChanged="txtNames_TextChanged" Width="800px"/>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetCompletionList"
                    ServicePath="TrackItWebService.asmx" UseContextKey="True" TargetControlID="txtNames"
                    MinimumPrefixLength="2" CompletionInterval="500" 
                   CompletionSetCount="100">
                </cc1:AutoCompleteExtender>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" DataKeyNames="iItemID">
                    <Columns>
                        <asp:BoundField DataField="iItemID" HeaderText="iItemID" />
                        <asp:BoundField DataField="CRF No" HeaderText="CRF No" />
                        <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItemStatus.aspx?Name={0}"
                            HeaderText="Name" DataTextField="Name" NavigateUrl="~/Admin/UpdateItemStatus.aspx"
                            Target="_self" />
                        <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                            ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                            NavigateUrl="~/Admin/UpdateItem.aspx" Target="_top" />
                        <asp:BoundField DataField="Build" HeaderText="Build" />
                        <asp:BoundField DataField="Now" HeaderText="Now" />
                        <asp:BoundField DataField="HistState" HeaderText="HistState" />
                        <asp:BoundField DataField="StatusDate" HeaderText="StatusDate" />
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
    </table>
<script type="text/javascript">
    $(document).ready(function(event) {

    $("#txtNames").focus(function() { $(this).select(); });

    });

</script>

</asp:Content>
