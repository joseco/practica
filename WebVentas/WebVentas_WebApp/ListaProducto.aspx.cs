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
    public partial class ListaProducto : System.Web.UI.Page
    {
        EN_Tbl_producto entidadProducto= new EN_Tbl_producto();
        CT_Tbl_producto reglaNegocioProducto = new CT_Tbl_producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                ProductoGridView.DataSource = reglaNegocioProducto.SelectAllList();
                ProductoGridView.DataBind();

            }
            catch (Exception ex)
            {

            }
        }


        protected void ProductoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int productoID = Convert.ToInt32(e.CommandArgument);
                    reglaNegocioProducto.Delete(productoID);
                    CargarLista();
                }
                catch (Exception ex)
                {

                }
            }

            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/FormularioProducto.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}