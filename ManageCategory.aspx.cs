using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageCategory : System.Web.UI.Page
{
    Bllcategory blc=new Bllcategory();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadCategory();
            loadGrid();
        }
    }
    public void loadCategory()
    {
        DataTable dt = blc.GetAllCategory();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
      public void loadGrid()
    {
        DataTable dt = blc.GetAllCategory();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
         int i = blc.AddCategory(txtcategoryname.Text);
        if(i>0)
        {
            lblmessage.Text = "category added";
            loadCategory();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
{
    int i = blc.UpdateCategory(txtcategoryname.Text, Convert.ToInt32(HiddenField1.Value));
        if(i>0)
        {
            lblmessage.Text = "category updated";
            loadCategory();
        }
}
protected void btnDelete_Click(object sender, EventArgs e)
{
    int i = blc.DeleteCategory(txtcategoryname.Text, Convert.ToInt32(HiddenField1.Value));
        if(i>0)
        {
            lblmessage.Text = "category deleted";
            loadCategory();
        }
}
protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    GridView1.PageIndex = e.NewPageIndex;
    loadGrid();
}
protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if(e.CommandName=="EDIT")
    {
        int i = Convert.ToInt32(e.CommandArgument.ToString());
        DataTable dt = blc.GetCategoryByCategoryId(i);
        txtcategoryname.Text = dt.Rows[0]["CName"].ToString();
        HiddenField1.Value = i.ToString();
    }
}
protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
{

}
}

    
