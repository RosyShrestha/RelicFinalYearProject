using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"]!=null)
        {
            HyperLink1.Visible = false;
            btnLogout.Visible = true;

        }
        else
        {
            HyperLink1.Visible = true;
            btnLogout.Visible = false;
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        HyperLink1.Visible = true;
        btnLogout.Visible=false;
    }
}
