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
    public partial class FormularioCliente : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string strId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(strId))
                return;
            try
            {
                int clienteId = Convert.ToInt32(strId);
                Cliente obj = ClienteBLL.GetCLienteById(clienteId);

                NombreTextBox.Text = obj.Nombre;
                NitTextBox.Text = obj.Nit;
                
                ClienteIdHiddenField.Value = strId;
            }
            catch (Exception ex)
            {

            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorPanel.Visible = false;
                int clienteId = Convert.ToInt32(ClienteIdHiddenField.Value);

                Cliente obj = new Cliente()
                {
                    ClienteId = clienteId,
                    Nombre = NombreTextBox.Text,
                    Nit = NitTextBox.Text
                };

                if (clienteId == 0)
                    ClienteBLL.InsertarCliente(obj);
                else
                    ClienteBLL.ActualizarCliente(obj);
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                return;
            }

            Response.Redirect("~/ListaClientes.aspx");
        }






    }
}