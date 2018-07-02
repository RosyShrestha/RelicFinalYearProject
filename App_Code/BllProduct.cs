using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for BLLProduct
/// </summary>
public class BLLProduct
{
    public BLLProduct()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int CreateProduct(int CategoryId, string ProductName, string Artist, double Price, string Image)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_InserProduct";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@cid", CategoryId);
        cmd.Parameters.AddWithValue("@a", ProductName);
        cmd.Parameters.AddWithValue("@b", Artist);
        cmd.Parameters.AddWithValue("@c", Price);
        cmd.Parameters.AddWithValue("@d", Image);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public DataTable GetAllProduct()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_selectall";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetProductByProductId(int ProductId)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_getproductbyproductid";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@e", ProductId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int UpdateProduct(int categoryid, string ProductName, string Artist, double Price, string Image, int productid)
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_Productupdate";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@a", ProductName);
        cmd.Parameters.AddWithValue("@b", Artist);
        cmd.Parameters.AddWithValue("@c", Price);
        cmd.Parameters.AddWithValue("@d", Image);
        cmd.Parameters.AddWithValue("@f", productid);
        cmd.Parameters.AddWithValue("@cid", categoryid);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int DeleteProduct(int CategoryId, string ProductName, string Artist, double Price, string Image, int productid)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_deleteproduct";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@f", productid);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public DataTable GetTshirtsByCategoryid()
    {
        //connection garcha
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);//double slash dinuparcha 
        string sql = "Select * from tblproduct where CID=1";
        SqlCommand cmd = new SqlCommand(sql, con);

        //cmd.Parameters.AddWithValue("@caid", cid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetMugsByCategoryid()
    {
        //connection garcha
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);//double slash dinuparcha 
        string sql = "Select * from tblproduct where CID=2";
        SqlCommand cmd = new SqlCommand(sql, con);

        //cmd.Parameters.AddWithValue("@caid", cid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable GetHoodieByCategoryid()
    {
        //connection garcha
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);//double slash dinuparcha 
        string sql = "Select * from tblproduct where CID=3";
        SqlCommand cmd = new SqlCommand(sql, con);

        //cmd.Parameters.AddWithValue("@caid", cid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int InsertIntoCart(int productid,int userid,int quantity)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "INSERT into CartTable values (@productid,@userid,@quantity)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@productid", productid);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@quantity", quantity);
        con.Open();
        int Id = cmd.ExecuteNonQuery();
        con.Close();
        return Id;
    }
    public DataTable getallproductbyuserid(int userid)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "select PName,PPrice,Quantity,PImage,CartID from tblproduct inner join cartTable on PId=ProductID and userid=@userid";
        SqlCommand cmd = new SqlCommand(sql, con);

        //cmd.Parameters.AddWithValue("@caid", cid);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@userid", userid);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int Deletefromcart(int cartid)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Delete from CartTable where CartID=@a";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@a", cartid);
        con.Open();
        int Id = cmd.ExecuteNonQuery();
        con.Close();
        return Id;
    }
    
    
}