using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class login : System.Web.UI.Page
{
    public List<CountryInfo> CountryInformation { get; set; }

    public class CountryInfo
    {
        public string userid { get; set; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Request.QueryString["errmsg"] !=null)
            {
                lblerr.InnerText = Request.QueryString["errmsg"];
            }
        }
    }

    protected void Cancel(object sender, EventArgs e)
    {
        txtUserID.Text = "";
        txtpasswd.Text = "";
        txtUserID.Focus();
    }


    private void Login1()
    {
        try
        {
            string str_pass = StringUtil.Crypt(txtpasswd.Text);
            //string str_pass1 = StringUtil.Decrypt(str_pass);

            string[] fldname = { "UserID", "Passwd" };
            string[] fldvalue = { txtUserID.Text, str_pass };
            //string[] fldvalue = { txtUserID.Text, txtpasswd.Text };


            DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_Login");


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Cookies["mycookie"].Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["id"] = ds.Tables[0].Rows[0]["ID"].ToString();
                        HttpContext.Current.Session["userid"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Response.Cookies["labid"].Value = ds.Tables[0].Rows[0]["labid"].ToString();

                        if (HttpContext.Current.Response.Cookies["labid"].Value == "3")
                        {
                            Response.Redirect("sample_results.aspx");
                        }
                        else
                        {
                            Response.Redirect("sample_recv.aspx");
                        }

                    }
                    else
                    {
                        lblerr.InnerText = "Invalid user id or password";
                    }
                }
                else
                {
                    lblerr.InnerText = "Invalid user id or password";
                }
            }
            else
            {
                lblerr.InnerText = "Invalid user id or password";
            }


        }

        catch (Exception ex)
        {
            lblerr.InnerText = ex.Message;
        }

    }

    private static string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }
        return result.ToString();
    }


    static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
    {
        HashAlgorithm algorithm = new SHA256Managed();

        byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

        for (int i = 0; i < plainText.Length; i++)
        {
            plainTextWithSaltBytes[i] = plainText[i];
        }
        for (int i = 0; i < salt.Length; i++)
        {
            plainTextWithSaltBytes[plainText.Length + i] = salt[i];
        }

        return algorithm.ComputeHash(plainTextWithSaltBytes);
    }



    public static string GeneratePassword(int length) //length of salt    
    {
        const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        var randNum = new Random();
        var chars = new char[length];
        var allowedCharCount = allowedChars.Length;
        for (var i = 0; i <= length - 1; i++)
        {
            chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }


    public static string EncodePassword(string pass, string salt) //encrypt password    
    {
        byte[] bytes = Encoding.Unicode.GetBytes(pass);
        byte[] src = Encoding.Unicode.GetBytes(salt);
        byte[] dst = new byte[src.Length + bytes.Length];
        System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

        HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        byte[] inArray = algorithm.ComputeHash(dst);

        return Convert.ToBase64String(inArray);
        //return EncodePasswordSHA512(Convert.ToBase64String(inArray));
    }

    public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
    {
        Byte[] originalBytes;
        Byte[] encodedBytes;
        MD5 md5;
        //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
        md5 = new MD5CryptoServiceProvider();
        originalBytes = ASCIIEncoding.Default.GetBytes(pass);
        encodedBytes = md5.ComputeHash(originalBytes);
        //Convert encoded bytes back to a 'readable' string    
        return BitConverter.ToString(encodedBytes);
    }


    public static string base64Encode(string sData) // Encode    
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }


    public static string base64Decode(string sData) //Decode    
    {
        try
        {
            var encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecodeByte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
            char[] decodedChar = new char[charCount];
            utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
            string result = new String(decodedChar);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Decode" + ex.Message);
        }
    }



    protected void Login(object sender, EventArgs e)
    {
        List<CountryInfo> CountryInformation = new List<CountryInfo>();

        try
        {

            string str_pass = StringUtil.Crypt(txtpasswd.Text);
            //string str_pass1 = StringUtil.Decrypt(str_pass);

            string[] fldname = { "UserID", "Passwd" };
            //string[] fldvalue = { txtUserID.Text, str_pass };
            string[] fldvalue = { txtUserID.Text, txtpasswd.Text };


            //DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_Login");
            DataSet ds = ExecuteNonQuery_Qry(fldname, fldvalue, "select * from tblLogin where userid='" + txtUserID.Text + "' and passwd='" + txtpasswd.Text + "' and userstatus = 1");


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Cookies["mycookie"].Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["id"] = ds.Tables[0].Rows[0]["ID"].ToString();
                        HttpContext.Current.Session["userid"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Response.Cookies["labid"].Value = ds.Tables[0].Rows[0]["labid"].ToString();


                        if (HttpContext.Current.Response.Cookies["labid"].Value == "3")
                        {
                            Response.Redirect("sample_results.aspx");
                        }
                        else
                        {
                            Response.Redirect("sample_recv.aspx");
                        }

                    }
                    else
                    {
                        lblerr.InnerText = "Invalid user id or password";
                    }
                }
                else
                {
                    lblerr.InnerText = "Invalid user id or password";
                }
            }
            else
            {
                lblerr.InnerText = "Invalid user id or password";
            }


        }

        catch (Exception ex)
        {
            lblerr.InnerText = ex.Message;
        }

    }



    protected void Login_SHA1(object sender, EventArgs e)
    {
        List<CountryInfo> CountryInformation = new List<CountryInfo>();

        try
        {

            var keyNew = GeneratePassword(10);
            var password = EncodePassword("abcd", keyNew);


            string str_pass = StringUtil.Crypt(txtpasswd.Text);
            //string str_pass1 = StringUtil.Decrypt(str_pass);

            string[] fldname = { "UserID", "Passwd" };
            string[] fldvalue = { txtUserID.Text, str_pass };
            //string[] fldvalue = { txtUserID.Text, txtpasswd.Text };


            DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_Login");


            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Cookies["mycookie"].Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["id"] = ds.Tables[0].Rows[0]["ID"].ToString();
                        HttpContext.Current.Session["userid"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Response.Cookies["labid"].Value = ds.Tables[0].Rows[0]["labid"].ToString();

                        Response.Redirect("sample_recv.aspx");

                    }
                    else
                    {
                        lblerr.InnerText = "Invalid user id or password";
                    }
                }
                else
                {
                    lblerr.InnerText = "Invalid user id or password";
                }
            }
            else
            {
                lblerr.InnerText = "Invalid user id or password";
            }


        }

        catch (Exception ex)
        {
            lblerr.InnerText = ex.Message;
        }

    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<CountryInfo> Login(string userid, string passwd)
    {
        List<CountryInfo> CountryInformation = new List<CountryInfo>();

        try
        {
            string[] fldname = { "UserID", "Passwd" };
            string[] fldvalue = { userid, passwd };

            DataSet ds = ExecuteNonQuery(fldname, fldvalue, "sp_Login");

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        HttpContext.Current.Response.Cookies["mycookie"].Value = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Session["id"] = ds.Tables[0].Rows[0]["ID"].ToString();
                        HttpContext.Current.Session["userid"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                        HttpContext.Current.Response.Cookies["labid"].Value = ds.Tables[0].Rows[0]["labid"].ToString();


                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            CountryInformation.Add(new CountryInfo()
                            {
                                userid = dr["UserID"].ToString()
                            });
                        }

                    }
                }
            }


        }

        catch (Exception ex)
        {

        }

        return CountryInformation;
    }


    [WebMethod]
    public static void Logout()
    {
        try
        {
            //HttpContext.Current.Session.Remove("id");
            //HttpContext.Current.Session.Remove("userid");

            HttpContext.Current.Response.Redirect("login.aspx", false);

        }

        catch (Exception ex)
        {

        }
    }


    public static DataSet ExecuteNonQuery(string[] fieldName, string[] fieldValues, string spName)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == "" || fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "DOP" || fieldName[a] == "StartDate" || fieldName[a] == "EndDate" || fieldName[a] == "AADOP")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[1] + "/" + dt[0] + "/" + dt[2]);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(fieldName[a], fieldValues[a]);
                    }
                }
            }

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

        }

        catch (Exception ex)
        {

        }

        finally
        {
            cn.MConnClose();
            cmd = null;
            cn = null;
        }

        return ds;
    }



    public static DataSet ExecuteNonQuery_Qry(string[] fieldName, string[] fieldValues, string qry)
    {
        SqlCommand cmd = null;
        CConnection cn = null;
        SqlDataAdapter da = null;
        DataSet ds = null;

        string[] dt;


        try
        {
            cn = new CConnection();

            cmd = new SqlCommand();
            cmd.Connection = cn.cn;
            cmd.CommandText = qry;
            cmd.CommandType = CommandType.Text;

            for (int a = 0; a <= fieldName.Length - 1; a++)
            {
                if (fieldValues[a] == "" || fieldValues[a] == " -" || fieldValues[a] == "  /  /" || fieldValues[a] == "  :" || fieldValues[a] == "" || fieldValues[a] == "  -   -  -      -  - -" || fieldValues[a] == "3-     -" || fieldValues[a] == "  ." || fieldValues[a] == "  -   -  -    -  - -")
                {
                    cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                }
                else
                {
                    if (fieldName[a] == "DOP" || fieldName[a] == "StartDate" || fieldName[a] == "EndDate" || fieldName[a] == "AADOP")
                    {
                        if (fieldValues[a].ToString() == "01/01/0001")
                        {
                            cmd.Parameters.AddWithValue(fieldName[a], DBNull.Value);
                        }
                        else
                        {
                            dt = fieldValues[a].Split('/');
                            cmd.Parameters.AddWithValue(fieldName[a], dt[1] + "/" + dt[0] + "/" + dt[2]);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(fieldName[a], fieldValues[a]);
                    }
                }
            }

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);

        }

        catch (Exception ex)
        {

        }

        finally
        {
            cn.MConnClose();
            cmd = null;
            cn = null;
        }

        return ds;
    }



}


public static class StringUtil
{
    private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

    public static string Crypt(this string text)
    {
        SymmetricAlgorithm algorithm = DES.Create();
        ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
        byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
        byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        return Convert.ToBase64String(outputBuffer);
    }

    public static string Decrypt(this string text)
    {
        SymmetricAlgorithm algorithm = DES.Create();
        ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
        byte[] inputbuffer = Convert.FromBase64String(text);
        byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
        return Encoding.Unicode.GetString(outputBuffer);
    }
}