using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CS_Activation : System.Web.UI.Page
{
    bllUsers blu = new bllUsers();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
            DataTable dt = blu.selectFromActivationCode(activationCode);

            int i = blu.DeleteFromActivationTable(activationCode);

            if (i == 1)
            {
                ltMessage.Text = "Account Activated";
                int x = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                int update = blu.UpdateUserTableAfter(x);
            }

        }
    }
}