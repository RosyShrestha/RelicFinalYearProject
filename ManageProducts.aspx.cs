using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageProducts : System.Web.UI.Page
{
    Bllcategory blc = new Bllcategory();
    BLLProduct blp = new BLLProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Image2.Visible = false;
            LoadCategory();
            LoadGrid();

        }
    }
    private void LoadGrid()
    {
        DataTable dt = blp.GetAllProduct();
        GridView1.DataSource = dt;
        GridView1.DataBind();
        txtproductname.Text = "";
        txtartist.Text = " ";
        txtprice.Text = " ";
        Image2.Visible = false;
    }
    private void LoadCategory()
    {
        DataTable dt = blc.GetAllCategory();
        ddlcategory.DataSource = dt;
        ddlcategory.DataTextField = "CName";
        ddlcategory.DataValueField = "CID";
        ddlcategory.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        int i = blp.CreateProduct(Convert.ToInt32(ddlcategory.SelectedValue.ToString()), txtproductname.Text, txtartist.Text, Convert.ToInt32(txtprice.Text), FileUpload1.FileName);
        if (i > 0)
        {
           
            FileUpload1.SaveAs(Server.MapPath("~/ProductPhotos/" + FileUpload1.FileName));
            lblmessage.Text = "product created";
            LoadGrid();
        }
    
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        {
            if (e.CommandName == "EDIT")
            {
                int i = Convert.ToInt32(e.CommandArgument.ToString());
                DataTable dt = blp.GetProductByProductId(i);
                ddlcategory.SelectedValue = dt.Rows[0]["CID"].ToString();
                txtproductname.Text = dt.Rows[0]["PName"].ToString();
                txtartist.Text = dt.Rows[0]["PArtist"].ToString();
                txtprice.Text = dt.Rows[0]["PPrice"].ToString();
                Image2.Visible = true;
                Image2.ImageUrl = "~/ProductPhotos/" + dt.Rows[0]["PImage"].ToString();
                HiddenField1.Value = dt.Rows[0]["PImage"].ToString();
                HiddenField2.Value = i.ToString();
            }
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        
        string filename = "";
        if (FileUpload1.HasFile)
        {
            filename = FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/ProductPhotos/" + FileUpload1.FileName));
            File.Delete(Server.MapPath("~/ProductPhotos/" + HiddenField1.Value));
            lblmessage.Text = "Product Updated";
        }
        else
        {
            filename = HiddenField1.Value;
        }
        int i = blp.UpdateProduct(Convert.ToInt32(ddlcategory.SelectedValue.ToString()), txtproductname.Text, txtartist.Text, Convert.ToInt32(txtprice.Text), filename, Convert.ToInt32(HiddenField2.Value));
        if (i > 0)
        {
            //FileUpload1.SaveAs(Server.MapPath("~/ProductPhotos/" + filename));

            LoadGrid();
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        int i = blp.DeleteProduct(Convert.ToInt32(ddlcategory.SelectedValue.ToString()), txtproductname.Text, txtartist.Text, Convert.ToInt32(txtprice.Text), FileUpload1.FileName, Convert.ToInt32(HiddenField2.Value));
        if (i > 0)
        {
            lblmessage.Text = "Product Deleted";
            LoadGrid();

        }
    }
}