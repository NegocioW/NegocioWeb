using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_de_negocio;
using System.Windows;


namespace Negocio
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            if (!IsPostBack)
            {

                dgCategorias.DataSource = NegCategorias.ObtenerCat();
                dgCategorias.DataBind();

          
               
            }
        }
     
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow dg;
            txtcodigo_cat.Enabled = false;
            dg = dgCategorias.SelectedRow;
            txtcodigo_cat.Text = dg.Cells[0].Text;
            txtNombreCat.Text = dg.Cells[1].Text;

        }

   

     
        private void mOK(string Men)
        {
            Response.Write("<script>window.alert('Guardado');</script>");
        }

        private void mError(string Men)
        {
            Response.Write("<script>window.alert('no se pudo');</script>");

        }

 

        protected void btn_guardarc_Click(object sender, EventArgs e)
        {

            string rpta = NegCategorias.NegInsertar(txtNombreCat.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se guardo correctamente");
            }
            else
            {
                mError("Problemas al guardar");
            }
        }

        protected void btn_modificarc_Click(object sender, EventArgs e)
        {
            string rpta = NegCategorias.NegActualizar(Convert.ToInt32(txtcodigo_cat.Text), txtNombreCat.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se actualizo correctamente");
            }
            else
            {
                mError("Problemas al actualizar");
            }
        }

        protected void dgCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgCategorias.EditIndex = Convert.ToInt32(e.NewEditIndex);
            HiddenField1.Value = e.NewEditIndex.ToString();
            dgCategorias.DataSource = NegCategorias.ObtenerCat();
            dgCategorias.DataBind();
        }

        protected void dgCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();

            t1=(TextBox)dgCategorias.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[0].Controls[0];
            t2=(TextBox)dgCategorias.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[1].Controls[0];

            //NegCategorias.ObtenerCat().Rows[e.RowIndex]["Descripcion_Categ"] = t1.Text;
            dgCategorias.EditIndex = -1;
            
             string rpta = NegCategorias.NegActualizar(Convert.ToInt32(t1.Text), t2.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se actualizo correctamente");
            }
            else
            {
                mError("Problemas al actualizar");
            }
            dgCategorias.DataSource = NegCategorias.ObtenerCat();
            dgCategorias.DataBind();
        }
           
         
        

        protected void dgCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgCategorias.EditIndex = -1;
       
            //dgCategorias.DataSource = NegCategorias.ObtenerCat();
            //dgCategorias.DataBind();
        }

        protected void BTNBUSCAR_Click(object sender, EventArgs e)
        {
            int cod = 0;
            List<string> LISTA = new List<string>();
            //LISTA = NegCategorias.obtenerCodigo(txtNombreCat.Text);
            txtcodigo_cat.Text = NegCategorias.obtenerCodigo(txtNombreCat.Text).Var_CodiCat.ToString();
               
        }

    
    }
}