using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Bllcategory
/// </summary>
public class Bllcategory
{
	public Bllcategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   

    public DataTable GetAllCategory()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_SelectCategory";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
     public int AddCategory(string CategoryName)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_CategoryCRUD";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@status", "Create");
        cmd.Parameters.AddWithValue("@a", CategoryName);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
     public int UpdateCategory(string CategoryName, int CategoryId)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_CategoryCRUD";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@status", "Update");
        //cmd.Parameters.AddWithValue("@e", CategoryId);
        cmd.Parameters.AddWithValue("@a", CategoryName);
        cmd.Parameters.AddWithValue("@e", CategoryId);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public int DeleteCategory(string CategoryName, int CategoryId)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_CategoryCRUD";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@status", "Delete");
        cmd.Parameters.AddWithValue("@a", CategoryName);
        cmd.Parameters.AddWithValue("@e", CategoryId);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public DataTable GetCategoryByCategoryId(int CategoryId)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "sp_getcategorybycategoryid";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@e", CategoryId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}

