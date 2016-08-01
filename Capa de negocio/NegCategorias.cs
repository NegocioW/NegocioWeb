using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
namespace Capa_de_negocio
{
    public class NegCategorias
    {
        //public static DataTable ObtenerCat()
        //{
        //    //obtener de tipo de datatable
        //    return new Categoria().ObtenerCategorias();
        //}

        public static List<Categoria> ObtenerCat()
        {

            return new Categoria().ObtenerCategorias();
        }

        public static Categoria obtenerCodigo(string nombre)
        {
              Categoria cat = new Categoria();

            cat.Var_NombreCat=nombre;
            return new Categoria().obtenerCodigo(nombre);
        }

        //Metodo para actualizar
        public static string NegActualizar(int CodCate, string NomCate)
        {

            Categoria cat = new Categoria();

            //GUARDAR VALORES EN LAS PROPIEDADES 
            cat.Var_CodiCat = CodCate;
            cat.Var_NombreCat = NomCate;

            //enviamos el objeto de tipo categoria
            return cat.ActualizarCat(cat);
        }
        
            public static string NegInsertar( string NomCate)
        {

            Categoria cat = new Categoria();

            //GUARDAR VALORES EN LAS PROPIEDADES 
            //cat.Var_CodiCat = CodCate;
            cat.Var_NombreCat = NomCate;

            //enviamos el objeto de tipo categoria
            return cat.InsertarCat(cat);
        
        }
       
    }
}

