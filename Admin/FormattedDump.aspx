<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FormattedDump.aspx.cs" Inherits="Admin_FormattedDump" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="div1" style="">
    <div >
        <h4>Dimesions Dump for CCB</h4>
        <asp:RadioButton ID="cbCR" runat="server" Text="CR" AutoPostBack="True" OnCheckedChanged="cbCR_CheckedChanged" CssClass="textBoxes"  GroupName="G1"/>
        <asp:RadioButton ID="cbPR" runat="server" Text="PR" AutoPostBack="True" OnCheckedChanged="cbPR_CheckedChanged" CssClass="textBoxes" GroupName="G1"/>
        <asp:RadioButton ID="cbTDR" runat="server" Text="TDR" AutoPostBack="True" OnCheckedChanged="cbTDR_CheckedChanged" CssClass="textBoxes" GroupName="G1"/>
    </div>
        <asp:LinkButton ID="btnImport" runat="server" onclick="btnImport_Click1">Export</asp:LinkButton>
    
    <br />
    
    <div id="div2" style="overflow:scroll; ">
    <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="True" 
            BackColor="White" Font-Names="Segoe UI" Font-Size="Small">
    </asp:GridView>
    </div>
    </div>

</asp:Content>

