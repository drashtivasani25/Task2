using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace T4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomersConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["CustName"] = TextBox1.Text;
           // print();
        }
        //public void print()
        //{
        //    SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [CustName], [Email], [Address], [City] FROM [customer]", con);
        //    DataTable dt = new DataTable();
        //    adpt.Fill(dt);
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [customer] ([CustName], [Email], [Address], [City]) VALUES (@CustName, @Email, @Address, @City)", con);
            cmd.Parameters.AddWithValue("CustName", TextBox1.Text);
            cmd.Parameters.AddWithValue("Email", TextBox2.Text);
            cmd.Parameters.AddWithValue("Address", TextBox3.Text);
            cmd.Parameters.AddWithValue("City", TextBox4.Text);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();

            //if (r == 1)
            //{
            //    TextBox1.Text = "";
            //    TextBox2.Text = "";
            //    TextBox3.Text = "";
            //    TextBox4.Text = "";
            //    Label1.Text = "Data inserted";
            //   // print();
            //}

            HttpCookie cookie = new HttpCookie("nm");
            cookie["CustName"] = TextBox1.Text;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(cookie);
            Response.Redirect("WebForm2.aspx");

        }
    }
}