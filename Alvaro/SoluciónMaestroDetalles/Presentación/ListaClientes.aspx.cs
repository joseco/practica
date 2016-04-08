using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using System.Data;

namespace CapaPresentación
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarLista();
        }
        private void CargarLista()
        {
            try
            {
                List<Cliente> cliente = ClienteBLL.GetCliente();

                ClientesGridView.DataSource = cliente;
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
                    int clienteId = Convert.ToInt32(e.CommandArgument);
                    ClienteBLL.EliminarCliente(clienteId);
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