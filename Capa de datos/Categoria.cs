using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
    public class Categoria : Conexion
    {
        //metodo todas las categorias
        //public DataTable ObtenerCategorias()
        //{
        //    DataTable dtCategoria = new DataTable("Categorias");
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = Conexion.cn;
        //        SqlCommand sqlcmd = new SqlCommand();
        //        sqlcmd.Connection = sqlCon;
        //        sqlcmd.CommandText = "sp_sel_categorias_ALL";
        //        sqlcmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter sqlDat = new SqlDataAdapter(sqlcmd);
        //        sqlDat.Fill(dtCategoria);
        //    }
        //    catch (Exception ex)
        //    {
        //        dtCategoria = null;

        //    }
        //    return dtCategoria;
        //}

        public  List<Categoria> ObtenerCategorias()
        {
            List<Categoria> _lista = new List<Categoria>();
            try
            {
                //    


                SqlConnection conexion = new SqlConnection(Conexion.cn);
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_sel_categorias_ALL", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader _reader = cmd.ExecuteReader();
                while (_reader.Read())
                {
                    Categoria pCiudad = new Categoria();

                    pCiudad.Var_CodiCat = _reader.GetInt32(0);
                    pCiudad.Var_NombreCat = _reader.GetString(1);
                    
                    _lista.Add(pCiudad);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                _lista = null;
            }
            return _lista;
        }

        public Categoria obtenerCodigo(string Nombre)
        {
           // List<string> list = new List<string>();
            SqlConnection SqlCon = new SqlConnection(Conexion.cn);
            Categoria cate = new Categoria();
            SqlCon.Open();
            try
            {

                SqlCommand Command = new SqlCommand("SP_OBTENERNOMBRECATEGORIA", SqlCon);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@CATEGORIANAME", SqlDbType.VarChar).Value = Nombre;
                SqlDataReader Reader = Command.ExecuteReader();
                while(Reader.Read())
                {
                   
                    string hola = Reader.GetInt32(0).ToString();
                    cate.Var_CodiCat=Reader.GetInt32(0);
                    cate.var_NombreCat=Reader.GetString(1);
                    //list.Add(cod.ToString());
                    //list.Add(descr);

                }
            }
            catch (Exception ex)
            {
                
                
            }
            return cate;
        }

        public string ActualizarCat(Categoria varCateg)
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
                sqlCmd.CommandText = "sp_act_Categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;



                //codigo
                SqlParameter sqlParCod = new SqlParameter();
                sqlParCod.ParameterName = "@codCate";
                sqlParCod.SqlDbType = SqlDbType.Int;
                sqlParCod.Value = varCateg.Var_CodiCat;
                sqlCmd.Parameters.Add(sqlParCod);

                SqlParameter sqlParNom = new SqlParameter();
                sqlParNom.ParameterName = "@DescCate";
                sqlParNom.SqlDbType = SqlDbType.VarChar;
                sqlParNom.Size = 20;
                sqlParNom.Value = varCateg.Var_NombreCat;
                sqlCmd.Parameters.Add(sqlParNom);
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

        public string InsertarCat(Categoria varCateg)
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
                sqlCmd.CommandText = "sp_ins_Categoria";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                /*
                //codigo
                SqlParameter sqlParCod = new SqlParameter();
                sqlParCod.ParameterName = "@codCate";
                sqlParCod.SqlDbType = SqlDbType.Int;
                sqlParCod.Direction = ParameterDirection.InputOutput;
                sqlParCod.Value = varCateg.Var_CodiCat;
                sqlCmd.Parameters.Add(sqlParCod);
              */
                SqlParameter sqlParNom = new SqlParameter();
                sqlParNom.ParameterName = "@DescCate";
                sqlParNom.SqlDbType = SqlDbType.VarChar;
                sqlParNom.Value = varCateg.Var_NombreCat;
                sqlCmd.Parameters.Add(sqlParNom);
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

        public Categoria()
        {

        }
        private int var_CodiCat;

        public int Var_CodiCat
        {
            get { return var_CodiCat; }
            set { var_CodiCat = value; }
        }
        private string var_NombreCat;

        public string Var_NombreCat
        {
            get { return var_NombreCat; }
            set { var_NombreCat = value; }
        }



        //constructor lleno
        public Categoria(int Cod_Categoria, string Descripcion_Categ)
        {
            Var_CodiCat = Cod_Categoria;
            Var_NombreCat = Descripcion_Categ;
        }
    }

}
