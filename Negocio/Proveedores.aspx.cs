using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
namespace Negocio
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void mOK(string Men)
        {
            Response.Write("<script>window.alert('Guardado');</script>");
        }

        private void mError(string Men)
        {
            Response.Write("<script>window.alert('no se pudo');</script>");

        }

        protected void btn_guardarp_Click(object sender, EventArgs e)
        {
            string rpta = NegProveedores.Insertar(nit.Text, nombre.Text,txtTelefono.Text,txtContacto.Text,txtDireccion.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se guardo correctamente");
            }
            else
            {
                mError("Problemas al guardar");
            }
        }

      

       
    }
}