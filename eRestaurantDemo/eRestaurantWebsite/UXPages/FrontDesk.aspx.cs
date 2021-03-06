﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using eRestaurantSystem.BLL;
using eRestaurantSystem.Entities;
using eRestaurantSystem.Entities.DTOs;
using eRestaurantSystem.Entities.POCOs;

public partial class UXPages_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        AdminController sysmgr = new AdminController();
        DateTime info = sysmgr.GetLastBillDateTime();
        SearchDate.Text = info.ToString("yyy-MM-dd");
        SearchTime.Text = info.ToString("hh:mm:ss");
    }
}