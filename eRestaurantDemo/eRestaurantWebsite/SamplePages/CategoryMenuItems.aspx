<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CategoryMenuItems.aspx.cs" Inherits="SamplePages_CategoryMenuItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Menu Items By Category</h1>

    <table class="nav-justified" style="width:70%">
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <div class="row col-md-12">
                <asp:Repeater ID="Catorgies" runat="server" DataSourceID="CategoryMenuItemsDataSource" >
                    <ItemTemplate>
                        <h3>
                            <img width="80" height="80" style="margin-right:30px" src='<%# "../Images/" +Eval("Description")+ "-1.png"  %>' />
                            <%# Eval("Description") %>
                        </h3>
                        <table class="table table-striped">
                            <thead>
                                <th style="width:375px">Name</th>
                                <th>Price</th>
                                <th>Calories</th>
                                <th>Comment</th>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="MenuItems" runat="server" DataSource='<%# Eval("MenuItems") %>'>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width:375px">
                                                <%# Eval("Description") %>
                                            </td>
                                            <td>
                                                <%# ((decimal)Eval("Price")).ToString("C") %>
                                            </td>
                                            <td>
                                                <%# (int)(Eval("Calories")) %>
                                            </td>
                                            <td>
                                                <%# Eval("Comment") %>
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

    <asp:ObjectDataSource ID="CategoryMenuItemsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CategoryMenuItems_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>

</asp:Content>

