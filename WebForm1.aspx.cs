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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }
        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();

            SqlDataAdapter sdr = new SqlDataAdapter("select * from stdtbl", con);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text == "register")
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                con.Open();
                String sql = "INSERT INTO [stdtbl] ([name], [password], [city], [gender], [hobby]) VALUES (@name, @password, @city, @gender, @hobby)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("name", TextBox1.Text);
                cmd.Parameters.AddWithValue("password", TextBox2.Text);
                String ct = DropDownList1.Text;
                cmd.Parameters.AddWithValue("city", ct);
                String gnd = "";
                for (int i = 0; i < RadioButtonList1.Items.Count; i++)
                {
                    if (RadioButtonList1.Items[i].Selected == true)
                    {
                        gnd = RadioButtonList1.Items[i].Text;
                    }
                }
                cmd.Parameters.AddWithValue("gender", gnd);

                String hby = "";
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        hby += CheckBoxList1.Items[i].Text;
                    }
                }
                cmd.Parameters.AddWithValue("hobby", hby);
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    Response.Write("record inserted");
                }

                else
                {
                    Response.Write("not inserted");
                }
                show();
            }
            else if (Button1.Text == "update")
            {
                
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                con.Open();
                String sql = "UPDATE [stdtbl] SET [name] = @name, [password] = @password, [city] = @city, [gender] = @gender, [hobby] = @hobby WHERE [Id] = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("name", TextBox1.Text);
                cmd.Parameters.AddWithValue("password", TextBox2.Text);
                String ct = DropDownList1.Text;
                cmd.Parameters.AddWithValue("city", ct);
                String gnd = "";
                for (int i = 0; i < RadioButtonList1.Items.Count; i++)
                {
                    if (RadioButtonList1.Items[i].Selected == true)
                    {
                        gnd = RadioButtonList1.Items[i].Text;
                    }
                }
                cmd.Parameters.AddWithValue("gender", gnd);

                String hby = "";
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {
                        hby += CheckBoxList1.Items[i].Text;
                    }
                }
                cmd.Parameters.AddWithValue("hobby", hby);
                cmd.Parameters.AddWithValue("id", ViewState["id"]);
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    Response.Write("record inserted");
                }

                else
                {
                    Response.Write("not inserted");
                }
                show();
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Text = "update";
            Button bt = (Button)sender;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();

            SqlDataAdapter sdr = new SqlDataAdapter("select * from stdtbl where id="+bt.CommandArgument, con);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();



            ViewState["id"] = bt.CommandArgument;
            con.Close();


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("DELETE FROM [stdtbl] WHERE [Id] = "+bt.CommandArgument, con);
            cmd.ExecuteNonQuery();
            show();

            
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
    }
}
