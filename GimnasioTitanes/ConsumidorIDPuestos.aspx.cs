using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GimnasioTitanes
{
    public partial class ConsumidorIDPuestos : System.Web.UI.Page
    {
        GYM_BD.DataBase_GYMSoapClient WS = new GYM_BD.DataBase_GYMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            DataSet ds = WS.IdPuesto(x);
            GridView1.Visible= true;
            GridView1.DataSource= ds.Tables[0];
            GridView1.DataBind();
        }

        protected void btn_suple_Click(object sender, EventArgs e)
        {
            string x = txtSuple.Text;
            DataSet ds = WS.IdSuplemento(x);
            GridView2.Visible = true;
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
        }

        protected void btn_maqui_Click(object sender, EventArgs e)
        {
            string x = txt_maqui.Text;
            DataSet ds = WS.IdproveedorMaquinas(x);
            GridView3.Visible = true;
            GridView3.DataSource = ds.Tables[0];
            GridView3.DataBind();
        }

        protected void btn_provee_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txt_provee.Text);
            DataSet ds = WS.proveedorSuplemento(x);
            GridView4.Visible = true;
            GridView4.DataSource = ds.Tables[0];
            GridView4.DataBind();
        }
    }
}