using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class Compra:Conexion
    {
        public DataTable ObtenerCompras()
        {
            DataTable dtCompras = new DataTable("Compras");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandText = "sp_sel_Proveedor_x_Producto";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlcmd);
                sqlDat.Fill(dtCompras);
            }
            catch (Exception ex)
            {
                dtCompras = null;

            }
            return dtCompras;
        }




         public string InsertarComp(Compra varCompra)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                //Asignamos la conexion
                sqlCon.ConnectionString = Conexion.cn;
                //abrimos la conexion para la insercion
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_ins_Proveedor_x_Producto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParProv = new SqlParameter();
                sqlParProv.ParameterName = "@codProveedor";
                sqlParProv.SqlDbType = SqlDbType.Int;
                sqlParProv.Precision = 12;
                sqlParProv.Scale = 2;
                sqlParProv.Value = varCompra.Var_CodProv;
                sqlCmd.Parameters.Add(sqlParProv);

                SqlParameter sqlParProd = new SqlParameter();
                sqlParProd.ParameterName = "@codProducto";
                sqlParProd.SqlDbType = SqlDbType.Int;
                sqlParProd.Precision = 12;
                sqlParProd.Scale = 2;
                sqlParProd.Value = varCompra.Var_CodProd;
                sqlCmd.Parameters.Add(sqlParProd);

                SqlParameter sqlParCant = new SqlParameter();
                sqlParCant.ParameterName = "@cantidad";
                sqlParCant.SqlDbType = SqlDbType.Int;
                sqlParCant.Precision = 12;
                sqlParCant.Scale = 2;
                sqlParCant.Value = varCompra.Var_cantidad;
                sqlCmd.Parameters.Add(sqlParCant);

                SqlParameter sqlParPrecC = new SqlParameter();
                sqlParPrecC.ParameterName = "@Precio_Compra ";
                sqlParPrecC.SqlDbType = SqlDbType.Decimal;
                sqlParPrecC.Value = varCompra.Var_precioc;
                sqlCmd.Parameters.Add(sqlParPrecC);
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se registro";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return rpta;
        }
 
    //constructor vacio

    public Compra()
{

}
    private int var_CodProv;

    public int Var_CodProv
    {
        get { return var_CodProv; }
        set { var_CodProv = value; }
    }
    private int var_CodProd;

    public int Var_CodProd
    {
        get { return var_CodProd; }
        set { var_CodProd = value; }
    }

    private int var_cantidad;

public int Var_cantidad
{
  get { return var_cantidad; }
  set { var_cantidad = value; }
}



private decimal var_precioc;

public decimal Var_precioc
{
    get { return var_precioc; }
    set { var_precioc = value; }
}
        
  
  //constructor lleno
    public Compra(int Cod_Proveedor ,int Cod_Producto,int Cantidad,decimal Precio_Compra ){
        var_CodProv = Cod_Proveedor;
        var_CodProd = Cod_Producto;
        var_cantidad = Cantidad;
        var_precioc = Precio_Compra;
}
    }
}
