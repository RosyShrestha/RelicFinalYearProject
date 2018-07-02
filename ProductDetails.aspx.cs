using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    BLLProduct blp = new BLLProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                Session["string"] = Request.QueryString["id"];
                DataTable dt = blp.GetProductByProductId(Convert.ToInt32(Request.QueryString["id"].ToString()));
                Image1.ImageUrl = "/ProductPhotos/" + dt.Rows[0]["PImage"];
                string Productname = dt.Rows[0]["PName"].ToString();
                int ProductPrice =Convert.ToInt32( dt.Rows[0]["PPrice"].ToString());
                string Designersname = dt.Rows[0]["PArtist"].ToString();
                lblProductName.Text = Productname;
                lblPrice.Text = ProductPrice.ToString();
                lblDesignersName.Text = Designersname;
                //Session["page"] = Request.UrlReferrer.ToString();
            }
        } 
    }
    Login login = new Login();
    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (Request.QueryString["id"] != null)
            {
                int userid = (int)Session["userid"];
                int productid = Convert.ToInt32(Request.QueryString["id"].ToString());
                string productname = lblProductName.Text;
                int productprice = Convert.ToInt32(lblPrice.Text);
                string productartist = lblDesignersName.Text;
                int i = blp.InsertIntoCart(productid, userid,Convert.ToInt32(ddlQuantity.Text));
                Response.Redirect("Cart.aspx");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Login to your account');", true);
        }
    }
}
