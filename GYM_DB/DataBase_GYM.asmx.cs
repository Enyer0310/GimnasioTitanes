using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace GYM_DB
{
    /// <summary>
    /// Descripción breve de DataBase_GYM
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class DataBase_GYM : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet ListarPuestos()
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-D6BEJ18; Initial Catalog=bd_titanesGym; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PUESTO", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet IdPuesto(int ID)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-D6BEJ18; Initial Catalog=bd_titanesGym; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PUESTO WHERE id_puesto = " + ID,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]

        public DataSet IdSuplemento(string ID)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-D6BEJ18; Initial Catalog=bd_titanesGym; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SUPLEMENTO WHERE nom_suplemento = " + "'" + ID+ "'",conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            
        }

        [WebMethod]

        public DataSet IdproveedorMaquinas(string ID)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-D6BEJ18; Initial Catalog=bd_titanesGym; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PROVEEDORMAQUINAS WHERE nom_maquina = " + "'" + ID + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        [WebMethod]

        public DataSet proveedorSuplemento(int ID)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=DESKTOP-D6BEJ18; Initial Catalog=bd_titanesGym; Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PROVEEDORSUPLEMENTO WHERE id_proveedorSuplemento = " + "'" + ID + "'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
    }
}
