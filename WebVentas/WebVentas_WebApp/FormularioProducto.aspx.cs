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
    public partial class FormularioProducto : System.Web.UI.Page
    {
        EN_Tbl_producto entidadProducto = new EN_Tbl_producto();
        CT_Tbl_producto reglaNegocioProducto = new CT_Tbl_producto();
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
                entidadProducto = reglaNegocioProducto.Select(contactoId);


                NombreTextBox.Text = entidadProducto.Nombre;
                PrecioTextBox.Text = (entidadProducto.Precio).ToString();
                ProductoIdHiddenField.Value = strId;
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
                int clienteid = Convert.ToInt32(ProductoIdHiddenField.Value);



                entidadProducto.Producto_id = clienteid;
                entidadProducto.Nombre = NombreTextBox.Text;
                entidadProducto.Precio = Int32.Parse(PrecioTextBox.Text); ;



                if (clienteid == 0)
                    reglaNegocioProducto.Insert(entidadProducto);
                else
                    reglaNegocioProducto.Update(entidadProducto);
            }
            catch (Exception ex)
            {
                ErrorPanel.Visible = true;
                return;
            }

            Response.Redirect("~/ListaProducto.aspx");
        }

    }
}