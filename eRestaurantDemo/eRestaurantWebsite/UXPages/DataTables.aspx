<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DataTables.aspx.cs" Inherits="UXPages_DataTables" %>
<%@ Register Src="~/Fancy/FancyDataTable.ascx" TagPrefix="uc1" TagName="FancyDataTable" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Data Tables Stuffs</h1>
    <br /><br />


    <uc1:FancyDataTable runat="server" ID="FancyDataTable" />

    <br />
</asp:Content>

