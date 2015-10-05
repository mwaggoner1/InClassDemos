<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsByDate.aspx.cs" Inherits="SamplePages_ReservationsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Reservations By Date</h1>

    <table class="nav-justified" style="width:70%">
    <tr>
        <td align="center">Enter Reservation Date (mm/dd/yyyy)</td>
        <td>
            <asp:TextBox ID="ReservationDate" runat="server" PlaceHolder="mm/dd/yyyy"></asp:TextBox>
            <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <div class="row col-md-12">
                <asp:Repeater ID="EventReservations" runat="server" DataSourceID="EventReservationsDataSource">
                    <ItemTemplate>
                        <h3>
                            <%# Eval("Description") %>
                        </h3>
                        
                        <table class="table table-striped">
                            <thead>
                                <th>Name</th>
                                <th>Phone</th>
                                <th>Time</th>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="ReservationList" runat="server" DataSource='<%# Eval("Reservations") %>'>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("CustomerName") %>
                                            </td>
                                            <td>
                                                <%# Eval("ContactPhone") %>
                                            </td>
                                            <td>
                                                <%# Eval("ReservationDate") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </td>
    </tr>
    </table>

    <asp:ObjectDataSource ID="EventReservationsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByDate" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ReservationDate" Name="date" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

