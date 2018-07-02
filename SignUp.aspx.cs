using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sign_Up : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    bllUsers blu = new bllUsers();

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string encryptedtext = blu.Encrypt(txtPassword.Text);
        int userId = blu.CreateUserUsingSignIn(txtFirstName.Text, txtLastName.Text, txtEmail.Text, encryptedtext, txtAddress.Text, Convert.ToDouble(txtPhoneNumber.Text));

        string activationcode = Guid.NewGuid().ToString();
        int i = blu.SendActivationCode(userId, activationcode);
        SendActivationEmail(activationcode);
        string message = string.Empty;

        message = "Registration successful. Activation email has been sent.";


        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtRetypePassword.Text = "";
        txtAddress.Text = "";
        txtPhoneNumber.Text = "";
        txtFirstName.Focus();
        Response.Redirect("Login.aspx");

    }

    private void SendActivationEmail(string activationcode)
    {
        using (MailMessage mm = new MailMessage("reliceco@gmail.com", txtEmail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " + txtFirstName.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("SignUp.aspx", "CS_Activation.aspx?ActivationCode=" + activationcode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("reliceco@gmail.com", "relic1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    //    string activationCode = Guid.NewGuid().ToString();
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("INSERT INTO ActivationTable VALUES(@UserId, @ActivationCode)"))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.CommandType = CommandType.Text;
    //                cmd.Parameters.AddWithValue("@UserId", userId);
    //                cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
    //                cmd.Connection = con;
    //                con.Open();
    //                cmd.ExecuteNonQuery();
    //                con.Close();
    //            }
    //        }
    //    }

}
