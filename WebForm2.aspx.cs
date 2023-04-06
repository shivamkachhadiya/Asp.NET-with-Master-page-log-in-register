using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            String sql = "select * from stdtbl where name='"+TextBox1.Text+"' and password='"+TextBox2.Text+"'";
            SqlDataAdapter sdr = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["val"] = dt;
                Response.Redirect("WebForm3.aspx");
            }
            else
            {
                Response.Write("not log in");
            }

        }
    }
}
