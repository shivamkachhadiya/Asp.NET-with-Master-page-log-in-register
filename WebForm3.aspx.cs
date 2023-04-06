using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["val"];
            Label1.Text = dt.Rows[0][1] + "-" + dt.Rows[0][2] + "-" + dt.Rows[0][3]+"-"+ dt.Rows[0][4]+"-"+ dt.Rows[0][5];
        }
    }
}
