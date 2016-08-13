using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFNEGOGOCIO
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductoService.svc or ProductoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductoService : IProductoService
    {
        string conexion = ConfigurationManager.ConnectionStrings["db_inventarioConnectionString"].ConnectionString;



        public DataTable ObtenerProductos()
        {
            DataTable dtProducto = new DataTable("Productos");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = conexion;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlCon;
                sqlcmd.CommandText = "sp_Sel_Producto_CAT";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlcmd);
                sqlDat.Fill(dtProducto);
            }
            catch (Exception ex)
            {
                dtProducto = null;

            }
            return dtProducto;
        }

        //        public List<Producto> ObtenerProductos()
        //        {
        //            SqlConnection SqlCon = new SqlConnection(Conexion.cn);
        //            SqlCon.Open();
        //            List<string> lista4 = new List<string>();
        //            List<object> lista2 = new List<object>();
        //            List<Producto> lista = new List<Producto>();


        //            Producto p = new Producto();
        //            try
        //            {
        //                SqlCommand Command = new SqlCommand("sp_Sel_Producto_CAT", SqlCon);
        //                Command.CommandType = CommandType.StoredProcedure;
        //                //Command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
        //                SqlDataReader myReader = Command.ExecuteReader();
        //                while (myReader.Read())
        //                {
        //                    //lista.Add(myReader.GetString(0));
        //                    //lista.Add(myReader.GetDecimal(1).ToString());
        //                    //lista.Add(myReader.GetDecimal(2).ToString());
        //                    //lista.Add(myReader.GetInt32(3).ToString());

        //                    p.Var_CodProd = myReader.GetInt32(0);
        //                    p.Var_NombreProd = myReader.GetString(1);
        //                    p.Var_PrecioProd = myReader.GetDecimal(2);
        //                    p.Var_PrecioProdC = myReader.GetDecimal(3);
        //                    p.Var_Cate = myReader.GetInt32(4);
        ////                    lista2.Add(new[]
        ////{ 
        ////    new {Cod_Producto= myReader.GetInt32(0),Nombre_Prod= myReader.GetString(1),Precio_Venta=myReader.GetDecimal(2),Precio_Compra= myReader.GetDecimal(3),Categoria=myReader.GetInt32(4)}
        ////});
        //                 lista2 = new List<object>(lista);

        //                    lista.Add(p);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                return null;
        //            }
        //            finally
        //            {
        //                if (SqlCon.State == ConnectionState.Open)
        //                    SqlCon.Close();
        //            }
        //            return lista;

        //        }
        
        public Producto ObtenerDatos(int Codigo)
        {
            SqlConnection SqlCon = new SqlConnection(conexion);
            SqlCon.Open();
            Producto p = new Producto();
            try
            {
                SqlCommand Command = new SqlCommand("SPBUSCARPRODUCTO", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
                SqlDataReader myReader = Command.ExecuteReader();
                while (myReader.Read())
                {
                    p.Var_NombreProd = myReader.GetString(0);
                    p.Var_PrecioProd = myReader.GetDecimal(1);
                    p.Var_PrecioProdC = myReader.GetDecimal(2);
                    p.Var_Cate = myReader.GetInt32(3);
                    // var lista = p;

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return p;

        }
          
        public string ActualizarProd(Producto varProduct)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                //Asignamos la conexion
                sqlCon.ConnectionString = conexion;
                //abrimos la conexion para la insercion
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "sp_act_Producto";
                sqlCmd.CommandType = CommandType.StoredProcedure;



                //codigo
                SqlParameter sqlParCod = new SqlParameter();
                sqlParCod.ParameterName = "@codProducto ";
                sqlParCod.SqlDbType = SqlDbType.Int;
                sqlParCod.Value = varProduct.Var_CodProd;
                sqlCmd.Parameters.Add(sqlParCod);

                SqlParameter sqlParNom = new SqlParameter();
                sqlParNom.ParameterName = "@nombreProduct";
                sqlParNom.SqlDbType = SqlDbType.VarChar;
                sqlParNom.Size = 20;
                sqlParNom.Value = varProduct.Var_NombreProd;
                sqlCmd.Parameters.Add(sqlParNom);

                SqlParameter sqlParPrec = new SqlParameter();
                sqlParPrec.ParameterName = "@precioVenta ";
                sqlParPrec.SqlDbType = SqlDbType.Decimal;
                sqlParPrec.Value = varProduct.Var_PrecioProd;
                sqlCmd.Parameters.Add(sqlParPrec);

                SqlParameter sqlParPrecC = new SqlParameter();
                sqlParPrecC.ParameterName = "@precioVenta ";
                sqlParPrecC.SqlDbType = SqlDbType.Decimal;
                sqlParPrecC.Value = varProduct.Var_PrecioProdC;
                sqlCmd.Parameters.Add(sqlParPrecC);

                SqlParameter sqlParCat = new SqlParameter();
                sqlParCat.ParameterName = "@codCategoria";
                sqlParCat.SqlDbType = SqlDbType.Int;
                sqlParCat.Precision = 12;
                sqlParCat.Scale = 2;
                sqlParCat.Value = varProduct.Var_Cate;
                sqlCmd.Parameters.Add(sqlParCat);
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

        //public string InsertarProd(Producto varProduct)
        //{
        //    string rpta = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        //Asignamos la conexion
        //        sqlCon.ConnectionString = Conexion.cn;
        //        //abrimos la conexion para la insercion
        //        sqlCon.Open();
        //        SqlCommand sqlCmd = new SqlCommand();
        //        sqlCmd.Connection = sqlCon;
        //        sqlCmd.CommandText = "sp_ins_Productos";
        //        sqlCmd.CommandType = CommandType.StoredProcedure;



        //        //codigo
        //        //SqlParameter sqlParCod = new SqlParameter();
        //        //sqlParCod.ParameterName = "@codProd";
        //        //sqlParCod.SqlDbType = SqlDbType.Int;
        //        //sqlParCod.Direction = ParameterDirection.InputOutput;
        //        //sqlParCod.Value = varProduct.var_CodProd;
        //        //sqlCmd.Parameters.Add(sqlParCod);

        //        SqlParameter sqlParNom = new SqlParameter();
        //        sqlParNom.ParameterName = "@nombreProduct";
        //        sqlParNom.SqlDbType = SqlDbType.VarChar;
        //        sqlParNom.Size = 20;
        //        sqlParNom.Value = varProduct.Var_NombreProd;
        //        sqlCmd.Parameters.Add(sqlParNom);

        //        SqlParameter sqlParPrec = new SqlParameter();
        //        sqlParPrec.ParameterName = "@precioVenta ";
        //        sqlParPrec.SqlDbType = SqlDbType.Decimal;
        //        sqlParPrec.Value = varProduct.Var_PrecioProd;
        //        sqlCmd.Parameters.Add(sqlParPrec);

        //        SqlParameter sqlParPrecC = new SqlParameter();
        //        sqlParPrecC.ParameterName = "@precioCompra ";
        //        sqlParPrecC.SqlDbType = SqlDbType.Decimal;
        //        sqlParPrecC.Value = varProduct.Var_PrecioProdC;
        //        sqlCmd.Parameters.Add(sqlParPrecC);

        //        SqlParameter sqlParCat = new SqlParameter();
        //        sqlParCat.ParameterName = "@codCategoria";
        //        sqlParCat.SqlDbType = SqlDbType.Int;
        //        sqlParCat.Precision = 12;
        //        sqlParCat.Scale = 2;
        //        sqlParCat.Value = varProduct.Var_Cate;
        //        sqlCmd.Parameters.Add(sqlParCat);
        //        rpta = sqlCmd.ExecuteNonQuery() == 1 ? "Ok" : "No se registro";


        //    }
        //    catch (Exception ex)
        //    {

        //        rpta = ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return rpta;
        //}

          [WebInvoke(Method = "POST", UriTemplate = "InsertarProd", ResponseFormat = WebMessageFormat.Json)]
        public string InsertarProd(Producto varProduct)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection(conexion);
            sqlCon.Open();
            try
            {
                SqlCommand command = new SqlCommand("sp_ins_Productos", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter Nom = new SqlParameter();
                command.Parameters.Add("@nombreProduct", SqlDbType.VarChar).Value = varProduct.Var_NombreProd;
                command.Parameters.Add("@precioVenta", SqlDbType.Decimal).Value = varProduct.Var_PrecioProd;
                command.Parameters.Add("@precioCompra", SqlDbType.Decimal).Value = varProduct.Var_PrecioProdC;
                command.Parameters.Add("@codCategoria", SqlDbType.Int).Value = varProduct.Var_Cate;
                rpta = command.ExecuteNonQuery() == 1 ? "Ok" : "No se registro";
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return rpta;
        }
    }
}
