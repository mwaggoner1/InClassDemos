using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eRestaurantSystem.BLL;
using eRestaurantSystem.Entities;
using EatIn.UI;


public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // initialize the date hired to today.
        DateHired.Text = DateTime.Today.ToShortDateString();
    }




    protected void WaiterSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        int waiterId;
        if(!int.TryParse(WaiterSelect.SelectedValue, out waiterId))
        {
            MessageUserControl.ShowInfo("Please select a waiter.");
            ClearTextFields();
            return; // exit here.
        }
        // it would be better if the id could be passed to GetWaiterInfo here.
        MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo); 
        // why would i want the error message control to be responsible for running my query?
        // this should be changed so message user control is separate... in my opinion.
        
    }

    public void GetWaiterInfo()
    {
        // Standard lookup sequence
        int waiterId;
        if (!int.TryParse(WaiterSelect.SelectedValue, out waiterId))
        {
            MessageUserControl.ShowInfo("Please select a waiter.");
            ClearTextFields();
            return; // exit here.
        } // i duplicated this till i can find a way to pass the paramter to the delegate callback
        AdminController controller = new AdminController();
        Waiter waiter = controller.Waiter_GetWaiterById(waiterId);

        WaiterID.Text       = waiter.WaiterID.ToString();
        FirstName.Text      = waiter.FirstName.ToString();
        LastName.Text       = waiter.LastName.ToString();
        Phone.Text          = waiter.Phone.ToString();
        Address.Text        = waiter.Address.ToString();
        DateHired.Text      = waiter.HireDate.ToString("MM/dd/yyyy");

        if (waiter.ReleaseDate.HasValue)
        {
            DateReleased.Text = waiter.ReleaseDate.ToString();
        }
        
    
    }

    public void ClearTextFields()
    {
        WaiterID.Text       = "";
        FirstName.Text      = "";
        LastName.Text       = "";
        Phone.Text          = "";
        Address.Text        = "";
        DateHired.Text      = "";
        DateReleased.Text   = "";
    }
}