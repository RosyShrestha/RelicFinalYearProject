﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hoodie : System.Web.UI.Page
{
    BLLProduct blp = new BLLProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = blp.GetHoodieByCategoryid();
            DataList1.DataSource = dt;
            DataList1.DataBind();

        }
    }
}