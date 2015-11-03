<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DataScripts.aspx.cs" Inherits="DataScripts" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <table >
            <tr>
                <td style="vertical-align: top;">
                    <table border="0" >
                        <tr>
                            <td >
                                Dimension#</td>
                            <td >
                                <asp:DropDownList ID="ddlDimensionNumber" runat="server" 
                                DataTextField="iItemID" DataValueField="vcCRPRTDR"
                                />
                            </td>
                            <td >
                                Description</td>
                            <td >
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            </td>
                            <td >
                                Updated On</td>
                            <td >
                                <asp:TextBox ID="txtUpdateDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                    TargetControlID="txtUpdateDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td >
                                <asp:Button ID="btnCreate" runat="server" Text="Create" 
                                    onclick="btnCreate_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                Script Name</td>
                            <td >
                                <asp:TextBox ID="txtScriptName" runat="server"></asp:TextBox>
                            </td>
                            <td >
                                Parameters</td>
                            <td >
                                <asp:TextBox ID="txtParameters" runat="server"></asp:TextBox>
                            </td>
                            <td >
                                Database</td>
                            <td >
<%--                                <asp:DropDownList ID="ddlDatabase" runat="server"
                                DataTextField="vcDatabase" DataValueField="iDatabaseID" ></asp:DropDownList>
--%>                            </td>
                            <td >
                                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                Module Name</td>
                            <td >
                                <asp:TextBox ID="txtModuleName" runat="server"></asp:TextBox>
                            </td>
                            <td >
                                Created On</td>
                            <td >
                                <asp:TextBox ID="txtCreateDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    TargetControlID="txtCreateDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td >
                                Last Updated By</td>
                            <td >
                                
                            </td>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                            <td >
                                Backend</td>
                            <td >
                                
                                <asp:CheckBox ID="cbIsBackEnd" runat="server" Checked="True" />
                                
                            </td>
                            <td >
                               <span style="color: Red">
       </span></td>
                        </tr>
                        
                        </table>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                        EmptyDataText="There are no data records to display."
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" 
                        AutoGenerateEditButton="True" onrowediting="GridView1_RowEditing"
                         
                        onrowdatabound="GridView1_RowDataBound"
                        DataKeyNames="iDataScriptID" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        onrowdeleting="GridView1_RowDeleting" onrowupdating="GridView1_RowUpdating"
                        >
                        <EmptyDataRowStyle BackColor="#FF9933" />
                        <Columns>

                            <asp:TemplateField HeaderText="Script ID" InsertVisible="False" SortExpression="iDataScriptID">
                                <ItemTemplate>
                                    <asp:Label ID="DataScriptID" runat="server" Text='<%# Bind("iDataScriptID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblDataScriptID" runat="server" Text='<%# Eval("iDataScriptID") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Dimension #" SortExpression="vcDimensionNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcDimensionNumber" runat="server" Text='<%# Bind("vcDimensionNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                        <asp:DropDownList ID="ddlDimensionNumbers" runat="server"
                                        DataTextField="CRPRTDR"
                                        DataValueField="iItemID"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="File Name" SortExpression="vcFileName">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcFileName" runat="server" Text='<%# Bind("vcFileName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtvcFileName" runat="server" Text='<%# Bind("vcFileName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Module Name" SortExpression="vcModuleName">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcModuleName" runat="server" Text='<%# Bind("vcModuleName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtvcModuleName" runat="server" Text='<%# Bind("vcModuleName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description" SortExpression="vcDescription">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcDescription" runat="server" Text='<%# Bind("vcDescription") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtvcDescription" runat="server" Text='<%# Bind("vcDescription") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Parametres" SortExpression="vcParametres">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcParametres" runat="server" Text='<%# Bind("vcParametres") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtvcParametres" runat="server" Text='<%# Bind("vcParametres") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Created" SortExpression="dtCreateDate">
                                <ItemTemplate>
                                    <asp:Label ID="lbldtCreateDate" runat="server" Text='<%# Bind("dtCreateDate") %>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtdtCreateDate" runat="server" Text='<%# Bind("dtCreateDate") %>'></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    TargetControlID="txtdtCreateDate">
                                </cc1:CalendarExtender>
                                </EditItemTemplate>--%>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Updated" SortExpression="dtUpdateDate">
                                <ItemTemplate>
                                    <asp:Label ID="lbldtUpdateDate" runat="server" Text='<%# Bind("dtUpdateDate") %>'></asp:Label>
                                </ItemTemplate>
                                <%--<EditItemTemplate>
                                    <asp:TextBox ID="txtdtUpdateDate" runat="server" Text='<%# Bind("dtUpdateDate") %>'></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                    TargetControlID="txtdtUpdateDate"></cc1:CalendarExtender>
                                </EditItemTemplate>--%>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Database" SortExpression="vcDatabase">
                                <ItemTemplate>
                                    <asp:Label ID="lblvcDatabase" runat="server" Text='<%# Bind("vcDatabase") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                        <asp:DropDownList ID="ddlDatabase" runat="server"
                                        DataTextField="vcDatabase" DataValueField="iDatabaseID" >
                                        </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
<%--                            <asp:TemplateField HeaderText="Database ID" SortExpression="iDatabaseID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbliDatabaseID" runat="server" Text='<%# Bind("iDatabaseID") %>'></asp:Label>
                                </ItemTemplate>                                
                            </asp:TemplateField>
 --%>                           
                            <asp:TemplateField HeaderText="User ID" InsertVisible="False" SortExpression="vcWindowsLogin"
                                Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lbliUserID" runat="server" Text='<%# Bind("vcWindowsLogin") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlUserID" runat="server"
                                        DataTextField="WindowsLogin" DataValueField="iUserID" >
                                        </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Updated By" >
                                <ItemTemplate>
                                    <asp:Label ID="lblvcUserName" runat="server" Text='<%# Bind("vcUserName") %>'></asp:Label>
                                </ItemTemplate>
<%--                                <EditItemTemplate>
                                        <asp:DropDownList ID="ddlLastUpdateBy" runat="server"
                                        DataTextField="WindowsLogin"
                                        DataValueField="UserID"></asp:DropDownList>
                                </EditItemTemplate>
--%>                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Back End" SortExpression="bIsBackEnd">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbbIsBackEnd" runat="server" Checked='<%# Bind("bIsBackEnd") %>' Enabled="false" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="cbIsBackEnd" runat="server" Checked='<%# Bind("bIsBackEnd") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            
 <%--                           <asp:TemplateField HeaderText="Data Script Status ID" SortExpression="iDataScriptStatusID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbliDataScriptStatusID" runat="server" Text='<%# Bind("iDataScriptStatusID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDataScriptStatusID" runat="server" Text='<%# Bind("iDataScriptStatusID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
--%>  
                            <asp:TemplateField HeaderText="Status" SortExpression="vcStatusDescription">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusDescription" runat="server" Text='<%# Bind("vcStatusDescription") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                     <asp:DropDownList ID="ddlDataScriptStatus" runat="server"
                                        DataTextField="vcDescription"
                                        DataValueField="iDataScriptStatusID"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                        <SelectedRowStyle BackColor="#FFFF99" />
                        <EditRowStyle BackColor="#CCCC00" />
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <span style="color: Red"><%= ErrorMessage %></span>
            

</asp:Content>
