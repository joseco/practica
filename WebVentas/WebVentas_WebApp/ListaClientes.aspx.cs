using Controladores;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebVentas
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        EN_Tbl_cliente entidadCliente = new EN_Tbl_cliente();
        CT_Tbl_cliente reglaNegocioCliente = new CT_Tbl_cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarLista();
        }

        private void CargarLista()
        {
            try
            {
                ClientesGridView.DataSource = reglaNegocioCliente.SelectAllList();
                ClientesGridView.DataBind();
            
            }
            catch (Exception ex)
            {

            }
        }


        protected void ClientesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int contactoId = Convert.ToInt32(e.CommandArgument);
                    reglaNegocioCliente.Delete(contactoId);
                    CargarLista();
                }
                catch (Exception ex)
                {

                }
            }

            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/FormularioCliente.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}