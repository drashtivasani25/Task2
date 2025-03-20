using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace T5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BooksConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [book] ([Title], [Author], [Price]) VALUES (@Title, @Author, @Price)", con);
            cmd.Parameters.AddWithValue("Title", TextBox1.Text);
            cmd.Parameters.AddWithValue("Author", TextBox2.Text);
            cmd.Parameters.AddWithValue("Price", TextBox3.Text);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();

            if (r == 1)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Label1.Text = "Data inserted";
            }

            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Title], [Author], [Price] FROM [book]", con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            ds.WriteXml(Server.MapPath("data.xml"));
            Label1.Text = "Data have written in xml file";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            XmlTextReader xmlreader = new XmlTextReader(Server.MapPath("data.xml"));
            DataSet ds = new DataSet();
            ds.ReadXml(xmlreader);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Label1.Text = "Data read in xml file";
        }
    }
}