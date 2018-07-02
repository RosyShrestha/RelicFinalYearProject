using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for bllUsers
/// </summary>
public class bllUsers
{
	public bllUsers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CreateUserUsingSignIn(string firstname, string lastname, string email, string password, string address, double phonenumber)
    {
        //connection
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Insert into Users output INSERTED.UserID values (@Firstname,@Lastname,@Email,@Password,@Address,@PhoneNumber,@IsActive)";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.Parameters.AddWithValue("@Firstname", firstname);
        cmd.Parameters.AddWithValue("@Lastname", lastname);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Password", password);
        cmd.Parameters.AddWithValue("@Address", address);
        cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
        cmd.Parameters.AddWithValue("@IsActive", "false");
        con.Open();
        int Id = (int)cmd.ExecuteScalar();
        con.Close();
        return Id;
    }




    public DataTable SelectAllFromUsers(string email, string password)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "select * from Users where Email=@email and Password=@password";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);

        //cmd<---da--->dt
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //rows columns collection
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable SelectAllFromUsers(string email)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "select * from Users where Email=@email";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@email", email);

        //cmd<---da--->dt
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //rows columns collection
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int UpdateAfterPasswordChange(string password, string email)
    {
        //connection
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "update Users set password=@password where email=@email";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@email", email);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public int DeleteFromActivationTable(string activationCode)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "DELETE FROM ActivationTable WHERE ActivationCode = @ActivationCode";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    //public int UpdateUserTableAfterActivation(string email)
    //{
    //    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
    //    string sql = "Update Users set IsActive=True where Email=@email";
    //    //execute sql queries
    //    SqlCommand cmd = new SqlCommand(sql, con);
    //    //parameters 
    //    cmd.CommandType = CommandType.Text;
    //    con.Open();
    //    int i = cmd.ExecuteNonQuery();
    //    con.Close();
    //    return i;
    //}
    public int UpdateUserTableAfter(int userid)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Update Users set IsActive=@a where UserID=@userid";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@a", "true");

        cmd.Parameters.AddWithValue("@userid", userid);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public DataTable selectFromActivationCode(string activationcode)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Select * From ActivationTable where ActivationCode=@activationcode";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@activationcode", activationcode);
        //cmd<---da--->dt
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //rows columns collection
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int SendActivationCode(int userid, string activationcode)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Insert into ActivationTable values (@UserId,@ActivationCode) ";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.Parameters.AddWithValue("@UserId", userid);
        cmd.Parameters.AddWithValue("@ActivationCode", activationcode);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
    public DataTable SelectFromUsersTable(string Email)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "Select * from Users where Email=@email ";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@email", Email);
        //cmd<---da--->dt
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //rows columns collection
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public int ResetPassword(string password, string email)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string sql = "update Users set Password=@password where Email=@email";
        //execute sql queries
        SqlCommand cmd = new SqlCommand(sql, con);
        //parameters 
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@email", email);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        return i;
    }
}