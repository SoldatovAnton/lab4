using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            GridView1.DataSource = client.GetCustomers();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text);
            ServiceReference1.Service1Client order = new ServiceReference1.Service1Client();
            GridView2.DataSource = order.GetOrders(id);
            GridView2.DataBind();

        }
    }
}
