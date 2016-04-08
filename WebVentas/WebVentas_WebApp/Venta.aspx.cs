using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladores;
using Entidades;
namespace WebVentas
{
    public partial class Venta : System.Web.UI.Page
    {
        CT_Tbl_detalleVenta ReglaNegociodetalleVenta = new CT_Tbl_detalleVenta();
        EN_Tbl_detalleVenta EntidadDetalleVenta = new EN_Tbl_detalleVenta();
        CT_Tbl_venta ReglaNegocioVenta = new CT_Tbl_venta();
        EN_Tbl_venta EntidadVenta = new EN_Tbl_venta();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            
            DateTime thisDay = DateTime.Today;
            String fecha = thisDay.ToString("d");
            int Ventaid= Convert.ToInt32(txtcodigoVenta.Text);
            int Clienteid = Convert.ToInt32(DropDownListCliente.SelectedValue);
            int productoid = Convert.ToInt32(DropDownListProducto.SelectedValue);
            int precio = Convert.ToInt32(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCANTIDAD.Text);
            JlaberSubtotal.Text = Convert.ToString((cantidad*precio));
            int subtotal =  Convert.ToInt32(JlaberSubtotal.Text);

            EntidadDetalleVenta.Venta_id = Ventaid;
            EntidadDetalleVenta.Producto_id = productoid;
            EntidadDetalleVenta.Precio = precio;
            EntidadDetalleVenta.Cantidad = cantidad;
            EntidadDetalleVenta.Subtotal = subtotal;
            EntidadVenta.Venta_id = Ventaid;
            EntidadVenta.Fecha = fecha;
            EntidadVenta.Cliente_id = Clienteid;
            EntidadVenta.Total = subtotal;
            ReglaNegocioVenta.Insert(EntidadVenta);
            ReglaNegociodetalleVenta.Insert(EntidadDetalleVenta);
            

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}