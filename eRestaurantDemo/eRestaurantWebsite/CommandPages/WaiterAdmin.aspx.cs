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
        if (!IsPostBack)
        {
            RefreshWaiterList(0);
            DateHired.Text = DateTime.Today.ToShortDateString();
        }
    }

    protected void RefreshWaiterList(int selectedValue)
    {
        // force a requery of the dropdown list
        WaiterSelect.DataBind();
        WaiterSelect.Items.Insert(0, "Select a waiter");
        WaiterSelect.SelectedValue = selectedValue.ToString();
        
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

    protected void GetWaiterInfo()
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
            DateTime rDate = DateTime.Parse(waiter.ReleaseDate.ToString());
            DateReleased.Text = rDate.ToString("MM/dd/yyyy");
        }
        
    
    }

    protected void ClearTextFields()
    {
        WaiterID.Text       = "";
        FirstName.Text      = "";
        LastName.Text       = "";
        Phone.Text          = "";
        Address.Text        = "";
        DateHired.Text      = "";
        DateReleased.Text   = "";
    }

    protected void WaiterInsert_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Phone = Phone.Text;
                item.Address = Address.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);

                item.ReleaseDate = null;

                AdminController sysmgr = new AdminController();
                WaiterID.Text = sysmgr.Waiter_Add(item).ToString();
                RefreshWaiterList(int.Parse(WaiterID.Text));

            }
        );

            
    }
    protected void WaiterUpdate_Click(object sender, EventArgs e)
    {   
        int waiterId;
        if (! int.TryParse(WaiterID.Text, out waiterId))
        {
            MessageUserControl.ShowInfo("Please Select a Waiter First.");
            return;
        }

        MessageUserControl.TryRun(() =>
            {
                Waiter item = new Waiter();
                item.WaiterID = waiterId;
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Phone = Phone.Text;
                item.Address = Address.Text;
                item.HireDate = DateTime.Parse(DateHired.Text);

                if (string.IsNullOrEmpty(DateReleased.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(DateReleased.Text);
                }

                AdminController sysmgr = new AdminController();
                sysmgr.Waiter_Update(item);
                RefreshWaiterList(item.WaiterID);

            }
        );

    }
}