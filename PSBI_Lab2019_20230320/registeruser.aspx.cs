using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class registeruser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cmdRegister.OnClientClick = "return ValidateForm();";
            getData();
        }
    }


    private void getData()
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            SqlDataAdapter da = new SqlDataAdapter("select id, userid 'UserID', passwd 'Password', case when userstatus = 'True' then 'Active' else 'In-Active' end 'UserStatus', case when isuseroradmin = 'True' then 'Admin' else 'User' end 'UserType' from tblLogin order by id desc", cn.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dg.DataSource = ds;
            dg.DataBind();
            dg.Columns[0].Visible = false;
        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message.Replace(",", "") + "');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
        }

        finally
        {

        }
    }


    protected void cmdRegister_Click(object sender, EventArgs e)
    {
        CConnection cn = null;

        try
        {
            cn = new CConnection();

            SqlCommand cmd = new SqlCommand("insert into tblLogin(UserID, Passwd, UserStatus, IsUserOrAdmin) values('" + txtUserID.Text + "', '" + txtpasswd.Text + "'" + ddluserstatus.SelectedValue + "', 'user');", cn.cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            string message = "alert('User created successfully');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            getData();

            ClearFields();
        }

        catch (Exception ex)
        {
            string message = "alert('" + ex.Message.Replace(",", "") + "');";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }

        finally
        {
            cn = null;
        }
    }

    private void ClearFields()
    {
        txtUserID.Text = "";
        txtpasswd.Text = "";
        txtconpasswd.Text = "";
        txtUserID.Focus();
    }

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}