<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StageSummary.aspx.cs" Inherits="StageSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Stage Summary</h2>
            <hr />
        <table>
        <tr>
            <td style="vertical-align:top;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
                CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                >
                    <Columns>
                        <asp:TemplateField Visible="false" HeaderText="iStage" SortExpression="iStage">
                            <ItemTemplate>
                                <asp:Label  ID="lblStageID" runat="server" Text='<%# Bind("iStage") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="vcStage" SortExpression="vcStage">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("iStage", "StageSummary.aspx?Stage={0}") %>'
                                    Text='<%# Eval("vcStage") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbSigma %>"
                    SelectCommand="uspGetStageSumm" SelectCommandType="StoredProcedure" >
                </asp:SqlDataSource>
            </td>
            <td  style="vertical-align:top;">
                <asp:GridView ID="gvItemByStage" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                    AutoGenerateColumns="false"  DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="CRF" HeaderText="CRF" />
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Name", "Admin/UpdateItemStatus.aspx?Name={0}") %>'
                                    Target="_self" Text='<%# Eval("Name") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="Name" DataNavigateUrlFormatString="Admin/UpdateItem.aspx?Name={0}"
                            ControlStyle-ForeColor="Green" HeaderText="Description" DataTextField="Description"
                            NavigateUrl="~/Admin/UpdateItem.aspx" />
                        <%--<asp:BoundField DataField="Now" HeaderText="Now" />--%>
                        <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Stage" HeaderText="Stage" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbSigma %>"
                    SelectCommand="uspItemsByStage" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="iStage" QueryStringField="Stage" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
