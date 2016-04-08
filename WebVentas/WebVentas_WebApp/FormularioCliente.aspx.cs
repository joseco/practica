using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Controladores;
namespace WebVentas
{
    public partial class FormularioCliente : System.Web.UI.Page
    {
        EN_Tbl_cliente entidadCliente = new EN_Tbl_cliente();
        CT_Tbl_cliente reglaNegocioCliente = new CT_Tbl_cliente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;


            string strId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(strId))
                return;
            try
            {
                int contactoId = Convert.ToInt32(strId);
                entidadCliente = reglaNegocioCliente.Select(contactoId);


                NombreTextBox.Text = entidadCliente.Nombre;
                NitTextBox.Text = entidadCliente.Nit;
                ContactoIdHiddenField.Value = strId;
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
                int clienteid = Convert.ToInt32(ContactoIdHiddenField.Value);



                entidadCliente.Cliente_id = clienteid;
                entidadCliente.Nombre = NombreTextBox.Text;
                entidadCliente.Nit = NitTextBox.Text;



                if (clienteid == 0)
                    reglaNegocioCliente.Insert(entidadCliente);
                else
                    reglaNegocioCliente.Update(entidadCliente);
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