

using System;
using ClientesNameEspace;
using ClientesNameEspace.DLL;





public partial class FormularioClientes : System.Web.UI.Page
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
            int contactoId = Convert.ToInt32(strId);
            EntidadCliente obj = ClienteBLL.GetContactoById(contactoId);

            NombreTextBox.Text = obj.Nombre;
            NitTextBox.Text = obj.Nit;
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
            int contactoId = Convert.ToInt32(ContactoIdHiddenField.Value);

            EntidadCliente obj = new EntidadCliente()
            {
                ContactoId = contactoId,
                Nombre = NombreTextBox.Text,
                Telefono = TelefonoTextBox.Text,
                Direccion = DireccionTextBox.Text
            };

            if (contactoId == 0)
                ContactoBLL.InsertarContacto(obj);
            else
                ContactoBLL.ActualizarContacto(obj);
        }
        catch (Exception ex)
        {
            ErrorPanel.Visible = true;
            return;
        }

        Response.Redirect("~/ListaContactos.aspx");
    }
}