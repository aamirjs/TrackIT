<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyTasks.aspx.cs" Inherits="MyTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:dbSigma %>" 
            SelectCommand="SELECT [TaskID], [Description], [DueDate] FROM [MyTasks]">
        </asp:SqlDataSource>
        <asp:GridView ID="gvTasks" runat="server" CssClass="mGrid" 
            PagerStyle-CssClass="pgr" AutoGenerateColumns="False" 
            AlternatingRowStyle-CssClass="alt">
<PagerStyle CssClass="pgr"></PagerStyle>

<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>

</asp:Content>