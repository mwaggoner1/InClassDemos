<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>
<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="my" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Waiter Admin</h1>
    <br />
    <my:MessageUserControl ID="MessageUserControl" runat="server" />
    <br /><br />



    <table style="width: 70%">
        <tr>
            <td align="right" style="padding-right:30px">Select Waiter</td>
            <td style="width: 291px">
                <asp:DropDownList ID="WaiterSelect" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="WaiterDataSource" DataTextField="FullName" DataValueField="WaiterID" Height="18px" OnSelectedIndexChanged="WaiterSelect_SelectedIndexChanged" Width="175px">
                    <asp:ListItem>Select a Waiter</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="width: 291px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">ID:</td>
            <td style="width: 291px">
                <asp:Label ID="WaiterID" runat="server" Text="Label"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">First Name:</td>
            <td style="width: 291px">
                <asp:TextBox ID="FirstName" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" ErrorMessage="First Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">Last Name:</td>
            <td style="width: 291px">
                <asp:TextBox ID="LastName" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" ErrorMessage="Last Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">Phone :</td>
            <td style="width: 291px">
                <asp:TextBox ID="Phone" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Phone" ErrorMessage="Phone is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">Address:</td>
            <td style="width: 291px">
                <asp:TextBox ID="Address" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Address" ErrorMessage="Address is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">Date Hired (mm/dd/yyyy) :</td>
            <td style="width: 291px">
                <asp:TextBox ID="DateHired" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">Date Released:</td>
            <td style="height: 24px; width: 291px">
                <asp:TextBox ID="DateReleased" runat="server" Width="175px"></asp:TextBox>
            </td>
            <td style="height: 24px"></td>
        </tr>
        <tr>
            <td style="height: 22px"></td>
            <td style="height: 22px; width: 291px">
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td align="right" style="padding-right:30px">
                <asp:LinkButton ID="Insert" runat="server">Insert Waiter</asp:LinkButton></td></td>
            <td style="width: 291px">
                <asp:LinkButton ID="Update" runat="server">Update Waiter</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:ObjectDataSource ID="WaiterDataSource" runat="server" DataObjectTypeName="eRestaurantSystem.Entities.Waiter" DeleteMethod="Waiter_Delete" InsertMethod="Waiter_Add" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiters_List" TypeName="eRestaurantSystem.BLL.AdminController" UpdateMethod="Waiter_Update"></asp:ObjectDataSource>

</asp:Content>

