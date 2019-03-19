<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RelatorioCopa.aspx.cs" Inherits="Web.RelatorioCopa" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="btnGerarRelatorio" runat="server" Text="Button" OnClick="btnGerarRelatorio_Click" />
    <rsweb:ReportViewer ID="rptRelatorio" runat="server"></rsweb:ReportViewer>

</asp:Content>
