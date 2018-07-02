using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    BLLProduct blp = new BLLProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {

                int userid = (int)Session["userid"];
                DataTable dt = blp.getallproductbyuserid(userid);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
    }
    decimal totalamount = 0M;

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label price = (Label)e.Row.FindControl("lblPrice");
            Label quantity = (Label)e.Row.FindControl("lblQuantity");
            Label total = (Label)e.Row.FindControl("lblTotal");
            total.Text = (Convert.ToDecimal(price.Text) * Convert.ToDecimal(quantity.Text)).ToString();

            totalamount += Convert.ToDecimal(total.Text);
            lblSubTotal.Text = totalamount.ToString();
            lblTotal.Text = totalamount.ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lblTotalamount = (Label)e.Row.FindControl("lblTotalamount");
            lblTotalamount.Text = totalamount.ToString();
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow row in GridView1.Rows)
        {
            CheckBox chkDeleteBox = (CheckBox)row.FindControl("chkDelete");
            HiddenField hdproductid = (HiddenField)row.FindControl("hdProductid");
            if (chkDeleteBox!=null)
            {
                if (chkDeleteBox.Checked)
                {
                    int i = blp.Deletefromcart(Convert.ToInt32(hdproductid.Value));
                    if (i>0)
                    {
                        if (Session["userid"] != null)
                         {

                int userid = (int)Session["userid"];
                DataTable dt = blp.getallproductbyuserid(userid);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
                    }
                }
            }
        }
    }
}