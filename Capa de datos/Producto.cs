using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
namespace Capa_de_datos
{
    public class Producto : Conexion
    {

        private int var_CodProd;

        public int Var_CodProd
        {
            get { return var_CodProd; }
            set { var_CodProd = value; }
        }


        private string var_NombreProd;

        public string Var_NombreProd
        {
            get { return var_NombreProd; }
            set { var_NombreProd = value; }
        }

        private decimal var_PrecioProd;

        public decimal Var_PrecioProd
        {
            get { return var_PrecioProd; }
            set { var_PrecioProd = value; }
        }

        private decimal var_PrecioProdC;

        public decimal Var_PrecioProdC
        {
            get { return var_PrecioProdC; }
            set { var_PrecioProdC = value; }
        }
        private int var_Cate;

        public int Var_Cate
        {
            get { return var_Cate; }
            set { var_Cate = value; }
        }

        public DataTable ObtenerProductos()
        {
            DataTable dtProducto = new DataTable("Productos");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.cn;
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
            //SqlConnection SqlCon = new SqlConnection(Conexion.cn);
            //SqlCon.Open();
            //Producto p= new Producto();
            //try
            //{  
            //    SqlCommand Command = new SqlCommand("SPBUSCARPRODUCTO", SqlCon);
            //    Command.CommandType = CommandType.StoredProcedure;
            //    Command.Parameters.Add("@Codigo", SqlDbType.Int).Value = Codigo;
            //    SqlDataReader myReader = Command.ExecuteReader();
            //    while (myReader.Read())
            //    {
            //        p.Var_NombreProd = myReader.GetString(0);
            //        p.Var_PrecioProd = myReader.GetDecimal(1);
            //        p.Var_PrecioProdC = myReader.GetDecimal(2);
            //        p.Var_Cate = myReader.GetInt32(3);
            //       // var lista = p;

            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    if (SqlCon.State == ConnectionState.Open)
            //        SqlCon.Close();
            //}
            //return p;
            return new Producto { Var_NombreProd = "nada", Var_PrecioProd = 1000, Var_PrecioProdC = 200, Var_Cate = 1 };

        }

        public string ActualizarProd(Producto varProduct)
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


        public string InsertarProd(Producto varProduct)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection(Conexion.cn);
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



        //constructor vacio


        public Producto()
        {

        }
        //constructor lleno
        public Producto(int Cod_Producto, string Nombre_Prod, decimal Precio_Venta, decimal Precio_Compra, int Cod_Categoria)
        {
            Var_CodProd = Cod_Producto;
            Var_NombreProd = Nombre_Prod;
            var_PrecioProd = Precio_Venta;
            var_PrecioProdC = Precio_Compra;
            var_Cate = Cod_Categoria;
        }


    }
}
