
using System;
using System.Collections.Generic;
// importacion librerias de datos
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class Conexion
    {
        public static string cn = @"Data Source=PC-ZAGO\SQLEXPRESS;Initial Catalog=db_inventario;Integrated Security=True";

        public static string cadena()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=PC-ZAGO\SQLEXPRESS;Initial Catalog=db_inventario;Integrated Security=True";
            Con.Open();

            return Con.Database;
           
        }
    }
}
