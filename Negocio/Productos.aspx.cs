using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using Capa_de_negocio;
namespace Negocio
{
    
    public partial class Productos : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cmbcategoria.DataSource = NegCategorias.ObtenerCat();
                cmbcategoria.DataTextField = "Var_NombreCat";
                cmbcategoria.DataValueField = "Var_CodiCat";
                    cmbcategoria.DataBind();
            }
             
            
        }
        //para mostrar mensajes
   
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
            string rpta = NegProductos.NegInsertar(nombre.Text, Convert.ToDecimal(precio.Text), Convert.ToDecimal(txtprecioC.Text), Convert.ToInt32(cmbcategoria.SelectedValue));
              if (rpta.Equals("Ok"))
            {

                mOK("Se guardo correctamente");
            }
            else
            {
                mError("Problemas al guardar");
            }
        
        }

        protected void btn_modificarp_Click(object sender, EventArgs e)
        {
            string rpta = NegProductos.NegActualizar(Convert.ToInt32(codigo), nombre.Text, Convert.ToDecimal(precio), Convert.ToDecimal(txtprecioC.Text), Convert.ToInt32(cmbcategoria.SelectedValue));
            if (rpta.Equals("Ok"))
            {

                mOK("Se modifico correctamente");
            }
            else
            {
                mError("Problemas al modificar");
            }
        }

 

        
    }
}