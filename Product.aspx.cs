using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    BLLProduct blp = new BLLProduct();
    bllUsers blu = new bllUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataTable dt = blp.GetAllProduct();
            dlAllProduct.DataSource = dt;
            dlAllProduct.DataBind();
        }
    }
    protected void btnTShirt_Click(object sender, EventArgs e)
    {
        //  if(!IsPostBack)
        //{
        //    DataTable dt = blp.GetTshirtsByCategoryid();
        //    DataList2.DataSource = dt;
        //    DataList2.DataBind();
        //}
    }
    //protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    //{
    //    if (e.CommandName =="AddToCart")
    //    {
    //        int userid =Convert.ToInt32( Session["userid"]);
    //        int productid = Convert.ToInt32( e.CommandArgument.ToString());
    //        string productname = dlAllProduct.FindControl("lblProductName").ToString();
    //        int productprice =Convert.ToInt32( dlAllProduct.FindControl("lblPrice"));
    //        string ProductArtist = dlAllProduct.FindControl("lblArtistName").ToString();
    //        int i = blp.InsertIntoCart(productid, userid, productname, productprice, ProductArtist);
    //        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Added to cart');", true);
    //    }
    //}
}
