using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace GimnasioTitanes
{
    public partial class ConsumidorPuestos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GYM_BD.DataBase_GYMSoapClient WS = new GYM_BD.DataBase_GYMSoapClient();
            DataSet ds = WS.ListarPuestos();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}