using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
namespace Capa_de_negocio
{
    public class NegCompras
    {

        public static DataTable ObtenerComp()
        {

            return new Compra().ObtenerCompras();


    }
        public static string NegInsertar(int CodProv,int CodProd,int Cant,decimal PrecioC)
        {
            Compra Comp=new Compra();
           

            //GUARDAR VALORES EN LAS PROPIEDADES 
            //cat.Var_CodiCat = CodCate;
            Comp.Var_CodProv=CodProv ;
            Comp.Var_CodProd = CodProd;
            Comp.Var_cantidad = Cant;
            Comp.Var_precioc = PrecioC;
            //enviamos el objeto de tipo categoria
            return Comp.InsertarComp(Comp);

        }
    }
}