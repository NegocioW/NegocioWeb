using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_datos
{
   public  class Proveedores:Conexion
    {
        private int cod_proveedor;

        public int Cod_proveedor
        {
            get { return cod_proveedor; }
            set { cod_proveedor = value; }
        }

        private string nit_cedula;
        private string nombre;
        private string telefono;
        private string contacto;
        
        private string direccion;


     
        public string Nit_cedula
        {
            get { return nit_cedula; }
            set { nit_cedula = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public DataSet ObtenerUltimo()
        {
            DataSet dtProveedorUltimo = new DataSet("proveedor");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                sqlCon.ConnectionString = Conexion.cn;

                //2. Establecer el comando
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;//La conexion que va a usar el comando
                sqlCmd.CommandText = "sp_provedormas1";//El comando a ejecutar
                sqlCmd.CommandType = CommandType.StoredProcedure;//Decirle al comando que va a ejecutar una sentencia SQL

                //3. No hay parametros

                //4. El DataAdapter que va a ejecutar el comando y es el encargado de llena el DataTable
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtProveedorUltimo);//Llenamos el Dataset
            }
            catch (Exception ex)
            {
                dtProveedorUltimo = null;
            }
            return dtProveedorUltimo;
        }
       public DataTable ObtenerProveedores()
       {
           DataTable dtProveedor= new DataTable("proveedor");
           SqlConnection sqlCon = new SqlConnection();
           try
           {
               //1. Establecer la cadena de conexion
               sqlCon.ConnectionString = Conexion.cn;

               //2. Establecer el comando
               SqlCommand sqlCmd = new SqlCommand();
               sqlCmd.Connection = sqlCon;//La conexion que va a usar el comando
               sqlCmd.CommandText = "sp_Sel_Proveedor";//El comando a ejecutar
               sqlCmd.CommandType = CommandType.StoredProcedure;//Decirle al comando que va a ejecutar una sentencia SQL

               //3. No hay parametros

               //4. El DataAdapter que va a ejecutar el comando y es el encargado de llena el DataTable
               SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
               sqlDat.Fill(dtProveedor);//Llenamos el DataTable
           }
           catch (Exception ex)
           {
               dtProveedor = null;
           }
           return dtProveedor;
       }
       public string Insertarproveedor(Proveedores varProveedor)
       {
           string rpta = "";
           SqlConnection sqlcon = new SqlConnection();
           try
           {
               sqlcon.ConnectionString = Conexion.cn;
               sqlcon.Open();
               SqlCommand sqlcmd = new SqlCommand();
               sqlcmd.Connection = sqlcon;
               sqlcmd.CommandText = "sp_ins_Proveedor";
               sqlcmd.CommandType = CommandType.StoredProcedure;

               //SqlParameter sqlParCodCli = new SqlParameter();
               //sqlParCodCli.ParameterName = "@Cod_Proveedor";
               //sqlParCodCli.SqlDbType = SqlDbType.Int;
               //sqlParCodCli.Direction = ParameterDirection.Output;
               //sqlParCodCli.Value = varproveedor.Cod_proveedor1;
               //sqlcmd.Parameters.Add(sqlParCodCli);

               SqlParameter sqlParNit = new SqlParameter();
               sqlParNit.ParameterName = "@nitcedula";
               sqlParNit.SqlDbType = SqlDbType.VarChar;
               sqlParNit.Size = 15;
               sqlParNit.Value = varProveedor.Nit_cedula;
               sqlcmd.Parameters.Add(sqlParNit);

               SqlParameter sqlParnom = new SqlParameter();
               sqlParnom.ParameterName = "@nombrerazon";
               sqlParnom.SqlDbType = SqlDbType.VarChar;
               sqlParnom.Size = 30;
               sqlParnom.Value = varProveedor.Nombre;
               sqlcmd.Parameters.Add(sqlParnom);


               SqlParameter sqlPartel = new SqlParameter();
               sqlPartel.ParameterName = "@telefono";
               sqlPartel.SqlDbType = SqlDbType.VarChar;
               sqlPartel.Size = 30;
               sqlPartel.Value = varProveedor.Telefono;
               sqlcmd.Parameters.Add(sqlPartel);

               SqlParameter sqlParcon = new SqlParameter();
               sqlParcon.ParameterName = "@nombContacto";
               sqlParcon.SqlDbType = SqlDbType.VarChar;
               sqlParcon.Size = 30;
               sqlParcon.Value = varProveedor.Contacto;
               sqlcmd.Parameters.Add(sqlParcon);

               SqlParameter sqlPardir = new SqlParameter();
               sqlPardir.ParameterName = "@direccion";
               sqlPardir.SqlDbType = SqlDbType.VarChar;
               sqlPardir.Size = 30;
               sqlPardir.Value = varProveedor.Direccion;
               sqlcmd.Parameters.Add(sqlPardir);

               rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se Insertó el proveedor de Forma Correcta";

           }
           catch (Exception ex)
           {
               rpta = ex.Message;
           }
           finally
           {
               if (sqlcon.State == ConnectionState.Open) 
                   sqlcon.Close();
           }
           return rpta;
       }



     
       public string ActualizarProveedor(Proveedores varProveedor)
       {
      
             
                string rpta = "";
                SqlConnection sqlcon = new SqlConnection();
            try
            {
                //Asignamos la conexion
                sqlcon.ConnectionString = Conexion.cn;
                //abrimos la conexion para la insercion
                sqlcon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlcon;
                sqlCmd.CommandText = "sp_act_Proveedor";
                sqlCmd.CommandType=CommandType.StoredProcedure;
                


             
                SqlParameter sqlParCod=new SqlParameter();
                sqlParCod.ParameterName="@codProveedor";
                sqlParCod.SqlDbType=SqlDbType.Int;
                sqlParCod.Value=varProveedor.Cod_proveedor;
                sqlCmd.Parameters.Add(sqlParCod);
                
                SqlParameter sqlParNit=new SqlParameter();
                sqlParNit.ParameterName = "@nitcedula";
                sqlParNit.SqlDbType=SqlDbType.VarChar;
                sqlParNit.Size=15;
                sqlParNit.Value=varProveedor.Nit_cedula;
                sqlCmd.Parameters.Add(sqlParNit);

               
                SqlParameter sqlParnom=new SqlParameter();
                sqlParnom.ParameterName="@nombrerazon";
                sqlParnom.SqlDbType=SqlDbType.VarChar;
                sqlParnom.Size=40;
                sqlParnom.Value=varProveedor.Nombre;
                sqlCmd.Parameters.Add(sqlParnom);

                
               

                SqlParameter sqlPartel=new SqlParameter();
                sqlPartel.ParameterName="@telefono";
                sqlPartel.SqlDbType=SqlDbType.VarChar;
                sqlPartel.Size=30;
                sqlPartel.Value=varProveedor.Telefono;
                sqlCmd.Parameters.Add(sqlPartel);


          
                SqlParameter sqlParcon=new SqlParameter();
                sqlParcon.ParameterName="@nombContacto";
                sqlParcon.SqlDbType=SqlDbType.VarChar;
                sqlParcon.Size=30;
                sqlParcon.Value=varProveedor.Contacto;
                sqlCmd.Parameters.Add(sqlParcon);

              

                SqlParameter sqlPardir=new SqlParameter();
                sqlPardir.ParameterName="@direccion";
                sqlPardir.SqlDbType=SqlDbType.VarChar;
                sqlPardir.Size=30;
                sqlPardir.Value=varProveedor.Direccion;
                sqlCmd.Parameters.Add(sqlPardir);

                rpta=sqlCmd.ExecuteNonQuery()==1?"Ok":"No se registro";

              

           }
           catch (Exception ex)
           {
               rpta = ex.Message;
           }
           finally
           {
               if (sqlcon.State == ConnectionState.Open)
                   sqlcon.Close();
           }
           return rpta;
       }

    }
}
