<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>
        Special Events Admin
    </h1>
    <hr />
    <table>
        <tr>
            <td style="width:200px; padding-right:24px;" align="right">Select an Event</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" Width="150px" runat="server" DataSourceID="SpecialEventsDataSource" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="True">
                    <asp:ListItem Value="">Select Event</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservation" runat="server">Fetch Reservation</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="SpecialEventsGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SpecialEventsDataSource">
                    <Columns>
                        <asp:BoundField DataField="EventCode" HeaderText="EventCode" SortExpression="EventCode" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:CheckBoxField DataField="Active" HeaderText="Active" SortExpression="Active" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    
    <asp:ObjectDataSource ID="SpecialEventsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>

</asp:Content>


