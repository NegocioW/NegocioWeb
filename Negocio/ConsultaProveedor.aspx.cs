using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
namespace Negocio
{
    public partial class ConsultaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgProvedores.DataSource =NegProveedores.ObtenerProveedores();
                dgProvedores.DataBind();

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

        protected void btn_modificarp_Click(object sender, EventArgs e)
        {
            string rpta = NegProveedores.actualizar(Convert.ToInt32(codigo.Text), nit.Text, nombre.Text, txtTelefono.Text, txtContacto.Text, txtDireccion.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se actualizo correctamente");
            }
            else
            {
                mError("Problemas al actualizar");
            }
        }

        protected void dgProvedores_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow dg;
            codigo.Enabled=false;
            dg = dgProvedores.SelectedRow;
            codigo.Text = dg.Cells[0].Text;
            nit.Text = dg.Cells[1].Text;
            nombre.Text = dg.Cells[2].Text;
            txtTelefono.Text = dg.Cells[3].Text;
            txtContacto.Text = dg.Cells[4].Text;
            txtDireccion.Text = dg.Cells[5].Text;
            
        }

        protected void dgProvedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgProvedores.EditIndex = Convert.ToInt32(e.NewEditIndex);
            HiddenField1.Value = e.NewEditIndex.ToString();
            dgProvedores.DataSource = NegProveedores.ObtenerProveedores();
            dgProvedores.DataBind();
        }

        protected void dgProvedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox t1 = new TextBox();
            TextBox t2 = new TextBox();
            TextBox t3 = new TextBox();
            TextBox t4 = new TextBox();
            TextBox t5 = new TextBox();
            TextBox t6 = new TextBox();

            t1=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[0].Controls[0];
            t2=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[1].Controls[0];
            t3=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[2].Controls[0];
            t4=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[3].Controls[0];
            t5=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[4].Controls[0];
            t6=(TextBox)dgProvedores.Rows[Convert.ToInt32(HiddenField1.Value)].Cells[5].Controls[0];

            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["Cod_Proveedor"] = t1.Text;
            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["Nit_Cedula"] = t2.Text;
            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["Nombre_RazonSocial"] = t3.Text;
            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["Telefono"] = t4.Text;
            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["NombContacto"] = t5.Text;
            NegProveedores.ObtenerProveedores().Rows[e.RowIndex]["Direccion"] = t6.Text;
            dgProvedores.EditIndex = -1;
            
             string rpta = NegProveedores.actualizar(Convert.ToInt32(t1.Text), t2.Text,t3.Text,t4.Text,t5.Text,t6.Text);
            if (rpta.Equals("Ok"))
            {

                mOK("Se actualizo correctamente");
            }
            else
            {
                mError("Problemas al actualizar");
            }
            dgProvedores.DataSource = NegProveedores.ObtenerProveedores();
            dgProvedores.DataBind();
        }
           
        

        protected void dgProvedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgProvedores.EditIndex = -1;

            dgProvedores.DataSource = NegProveedores.ObtenerProveedores();
            dgProvedores.DataBind();
        }

        

     
    }
}