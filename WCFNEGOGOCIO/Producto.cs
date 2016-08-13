using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFNEGOGOCIO
{
    public class Producto
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
    }
}