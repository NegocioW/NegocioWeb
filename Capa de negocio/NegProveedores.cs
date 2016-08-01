using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
namespace CapaNegocio
{
   public class NegProveedores
    {
       public static DataSet ObtenerUltimo()
       {
           return new Proveedores().ObtenerUltimo();
       }
        public static DataTable ObtenerProveedores()
        {
            return new Proveedores().ObtenerProveedores();
        }
        public static string Insertar(string Nit, string Nombre, string Telefono, string contacto, string Direccion)
        {
            Proveedores pro = new Proveedores();
            
            pro.Nit_cedula = Nit;
            pro.Nombre = Nombre;
            pro.Telefono = Telefono;
            pro.Contacto = contacto;
            pro.Direccion = Direccion;
            return pro.Insertarproveedor(pro);
        }
        public static string actualizar(int codigo, string Nit, string Nombre, string Telefono, string contacto, string Direccion)
        {
            Proveedores pro = new Proveedores();
            
            pro.Cod_proveedor = codigo;
            pro.Nit_cedula = Nit;
            pro.Nombre = Nombre;
            pro.Telefono = Telefono;
            pro.Contacto = contacto;
            pro.Direccion = Direccion;
            return pro.ActualizarProveedor(pro);

           
        }

      
      
    }
}
