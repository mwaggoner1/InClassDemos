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
                <asp:DropDownList ID="SpecialEventList" Width="150px" runat="server" 
                    AppendDataBoundItems="True" DataSourceID="SpecialEventsDataSource" 
                    DataTextField="Description" DataValueField="EventCode">
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
                <asp:GridView ID="ReservationGridView" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataSourceID="ReservationsDataSource" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
                            SortExpression="CustomerName" >
                        <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationDate" HeaderText="Reservation Date" 
                            SortExpression="ReservationDate" DataFormatString="{0:MM/dd/yyyy}" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="Size" 
                            SortExpression="NumberInParty" >
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Contact Phone" 
                            SortExpression="ContactPhone" >
                        <HeaderStyle HorizontalAlign="Center" Width="125px" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status" 
                            SortExpression="ReservationStatus" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <EmptyDataTemplate>
                        No Data To Display.
                    </EmptyDataTemplate>
                   
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                   
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    
    <asp:ObjectDataSource ID="ReservationsDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="ReservationsByEventCode_List" 
        TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventCode" 
                PropertyName="SelectedValue" Type="String" DefaultValue="" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SpecialEventsDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="SpecialEvent_List" 
        TypeName="eRestaurantSystem.BLL.AdminController">
    </asp:ObjectDataSource>

</asp:Content>


