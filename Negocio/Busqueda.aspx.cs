using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_de_negocio;
namespace Negocio
{
    public partial class Busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgProductos.DataSource = NegProductos.ObtenerProd();
                dgProductos.DataBind();
            }
        }

        protected void dgProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow dg;
     
            dg = dgProductos.SelectedRow;
          
        }

        protected void dgProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgProductos.EditIndex = Convert.ToInt32(e.NewEditIndex);
            HiddenField1.Value = e.NewEditIndex.ToString();
            dgProductos.DataSource = NegProductos.ObtenerProd();
            dgProductos.DataBind();
        }

  

        protected void dgProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgProductos.EditIndex = -1;

            dgProductos.DataSource = NegProductos.ObtenerProd();
            dgProductos.DataBind();
        }

        protected void dgProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            TextBox t3 = new TextBox();
            TextBox t4 = new TextBox();
            TextBox  t5 = new TextBox();

            t1 = (TextBox)dgProductos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[0].Controls[0];
            t2 = (TextBox)dgProductos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[1].Controls[0];
            t3 = (TextBox)dgProductos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[2].Controls[0];
            t4 = (TextBox)dgProductos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[3].Controls[0];
            t5 = (TextBox)dgProductos.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[4].Controls[0];

            NegProductos.ObtenerProd().Rows[e.RowIndex]["Cod_Producto"] = t1.Text;
            NegProductos.ObtenerProd().Rows[e.RowIndex]["Nombre_Prod"] = t2.Text;
            NegProductos.ObtenerProd().Rows[e.RowIndex]["Precio_Venta"] = t3.Text;
            NegProductos.ObtenerProd().Rows[e.RowIndex]["Precio_Compra"] = t4.Text;
           

            dgProductos.EditIndex = -1;
           /* string rpta = NegProductos.NegActualizar(Convert.ToInt32(t1.Text), t2.Text, Convert.ToDecimal(t3.Text),Convert.ToDecimal(t4.Text),Convert.ToInt32(.SE));
            if (rpta.Equals("Ok"))
            {

                mOK("Se modifico correctamente");
            }
            else
            {
                mError("Problemas al modificar");
            }
            
           */
        }

        private void mOK(string Men)
        {
            Response.Write("<script>window.alert('Guardado');</script>");
        }

        private void mError(string Men)
        {
            Response.Write("<script>window.alert('no se pudo');</script>");

        }
    }
}