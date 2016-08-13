using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;

namespace Capa_de_negocio
{
   public class NegProductos
    {
       public static DataTable ObtenerProd()
       {
           //obtener de tipo de datatable
           return new Producto().ObtenerProductos();
       }
        //public static List<Producto> ObtenerProd()
        //{
        //    //obtener de tipo de datatable
        //    return new Producto().ObtenerProductos();
        //}
        public static string NegActualizar(int CodProd, string NomProd, decimal PrecProd,decimal PrecProdC, int codCat)
        {

            Producto prod = new Producto();

            //GUARDAR VALORES EN LAS PROPIEDADES 
            prod.Var_CodProd = CodProd;
            prod.Var_NombreProd = NomProd;
            prod.Var_PrecioProd = PrecProd;
            prod.Var_PrecioProdC = PrecProdC;
            prod.Var_Cate = codCat;
            //enviamos el objeto de tipo categoria
            return prod.ActualizarProd(prod);
        }
        public static Producto Obtenerdatos(int codigo)
        {
            return new Producto().ObtenerDatos(codigo);
        }

        public static string NegInsertar(string NomProd, decimal PrecProd, decimal PrecProdC, int codCat)
        {

            Producto prod = new Producto();

            //GUARDAR VALORES EN LAS PROPIEDADES 
            //cat.Var_CodiCat = CodCate;
            //prod.Var_CodProd = CodProd;
            prod.Var_NombreProd = NomProd;
            prod.Var_PrecioProd = PrecProd;
            prod.Var_PrecioProdC= PrecProdC;
            prod.Var_Cate = codCat;

            //enviamos el objeto de tipo categoria
            return prod.InsertarProd(prod);

        }
    }
}
