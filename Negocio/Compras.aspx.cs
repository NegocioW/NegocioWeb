using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_de_negocio;
using System.Windows;
using CapaNegocio;

namespace Negocio
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {

                dgProductos.DataSource = NegProductos.ObtenerProd();
                dgProductos.DataBind();
                dgProvedores.DataSource = NegProveedores.ObtenerProveedores();
                dgProvedores.DataBind();
                ultimoid.DataSource = NegProveedores.ObtenerUltimo();
                ultimoid.DataValueField = "Cod_Proveedor";
                ultimoid.DataTextField = "Cod_Proveedor";
                ultimoid.DataBind();


                dgCompra.DataSource = NegCompras.ObtenerComp();
                dgCompra.DataBind();
            }
             
        }


      
            private void mOK(string Men)
        {
            Response.Write("<script>window.alert('Guardado');</script>");
        }

        private void mError(string Men)
        {
            Response.Write("<script>window.alert('no se pudo');</script>");

        }
        public string codprove ;
        public string codprod;
        protected void dgProvedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow dg;
            dg = dgProvedores.SelectedRow;
             codprove = dg.Cells[0].Text;
            txtProveedor.Text = dg.Cells[2].Text;
        }

        protected void dgProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow dg;
            dg = dgProductos.SelectedRow;
            codprod = dg.Cells[0].Text; 
            txtProducto.Text = dg.Cells[1].Text;
            txtPrecio.Text = dg.Cells[3].Text;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            
                decimal preciocompra = int.Parse(txtCantidad.Text) * decimal.Parse(txtPrecio.Text);
                txtTotal.Text = preciocompra.ToString();
                GridViewRow dg;
                dg = dgProvedores.SelectedRow;
                GridViewRow dgp;
                dgp = dgProductos.SelectedRow;
                codprod = dgp.Cells[0].Text;
                codprove = dg.Cells[0].Text;
                string rpta = NegCompras.NegInsertar(Convert.ToInt32(codprove), Convert.ToInt32(codprod), Convert.ToInt32(txtCantidad.Text), Convert.ToDecimal(txtTotal.Text));
                if (rpta.Equals("Ok"))
                {

                    mOK("Se guardo correctamente");
                }
                else
                {
                    mError("Problemas al guardar");
                }
            
        }

        protected void btn_guardarp_Click(object sender, EventArgs e)
        {
            //string rpta = NegProductos.NegInsertar(nombre.Text, Convert.ToDecimal(preciov.Text), Convert.ToDecimal(txtprecioC.Text), Convert.ToInt32(cmbcategoria.SelectedIndex));
            //if (rpta.Equals("Ok"))
            //{

            //    mOKp("Se guardo correctamente");
            //}
            //else
            //{
            //    mErrorp("Problemas al guardar");
            //}
        }

        private void mOKp(string Men)
        {
            Response.Write("<scrypt>window.alert('Guardado');</scrypt>");
        }

        private void mErrorp(string Men)
        {
            Response.Write("<scrypt>window.alert('no se pudo');</scrypt>");

        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {

            dgCompra.DataSource = NegCompras.ObtenerComp();
            dgCompra.DataBind();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (int.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text)).ToString();
        }




           
        
    }
}