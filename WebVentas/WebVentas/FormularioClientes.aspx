<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioClientes.aspx.cs" Inherits="FormularioClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Clientes | Sistemas Ventass</title>
    <%-- ------ CSS ------ --%>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <link href="css/prettyPhoto.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
    <link rel="shortcut icon" href="images/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <header id="header">
  
    <div class="container">
    <div class="row">
   
    
    </div>
    </div>
    </div>
      </div><%--container--%>
        </div><%--/top-bar--%>
      <nav class="navbar navbar-inverse" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    &nbsp;</div>
				
                <div class="collapse navbar-collapse navbar-right">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="Default.aspx">Inicio</a></li>
                       <li><a href="Productos.aspx">Productos</a></li>
                        <li><a href="Clientes.aspx">Clientes</a></li>                        
                        <li><a href="Ventas.aspx">Venta</a></li>  
                          <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Listas <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu">
                                <li><a href="listaproductos.aspx">Lista de productos</a></li>
                                <li><a href="listaclientes.aspx">Lista de clientes</a></li>
                                <li><a href="listaventas.aspx">Lista de ventas</a></li>
                             
                            </ul>
                        </li>                      
                    </ul>
                </div>
            </div><!--/.container-->
        </nav><!--/nav-->
 
    </header>
        <section id="portfolio">
        <div class="container">
            <div class="center">
               <h2>Formulario de registro de clientes</h2>
                  <asp:Panel ID="ErrorPanel" runat="server" Visible="false"
                CssClass="alert alert-danger" role="alert">
                Error al Guardar el Cliente
            </asp:Panel>

            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="NombreTextBox" runat="server"
                    CssClass="form-control">
                </asp:TextBox>
                <asp:RequiredFieldValidator runat="server"
                    ControlToValidate="NombreTextBox"
                    Display="Dynamic"
                    ForeColor="Red"
                    ValidationGroup="Contacto"
                    ErrorMessage="Debe ingresar el nombre">
                </asp:RequiredFieldValidator>
            </div>
            
            <div class="form-group">
                <label>Nit</label>
                <asp:TextBox ID="NitTextBox" runat="server"
                    CssClass="form-control">
                </asp:TextBox>
                <asp:RequiredFieldValidator runat="server"
                    ForeColor="Red"
                    ControlToValidate="NitTextBox"
                    Display="Dynamic"
                    ValidationGroup="Contacto"
                    ErrorMessage="Debe ingresar el NIT">
                </asp:RequiredFieldValidator>
            </div>
            
            

            <asp:LinkButton ID="SaveButton" runat="server"
                CssClass="btn btn-primary"
                ValidationGroup="Contacto"
                OnClick="SaveButton_Click">
                Guardar
            </asp:LinkButton>
            <asp:HyperLink runat="server" CssClass="btn"
                NavigateUrl="~/ListaContactos.aspx">
                Cancelar
            </asp:HyperLink>

            <asp:HiddenField ID="ContactoIdHiddenField" runat="server"
                Value="0" />

            </div>
        </div>
    </section>

        <!--/#portfolio-item-->
        <!--/#bottom-->
        <!--/#bottom-->
        <footer id="footer" class="midnight-blue">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                   &copy; 2016 derechos reservados <a target="_blank" href="https://github.com/royersin/practica" title="Gitgub"</a>. All Rights Reserved.
                 </div>
            </div>
        </div>
    </footer>
        <script type="text/javascript">
            jQuery(document).ready(function () {
                var offset = 300;
                var duration = 500;
                jQuery(window).scroll(function () {
                    if (jQuery(this).scrollTop() > offset) {
                        jQuery('.back-to-top').fadeIn(duration);
                    } else {
                        jQuery('.back-to-top').fadeOut(duration);
                    }
                });

                jQuery('.back-to-top').click(function (event) {
                    event.preventDefault();
                    jQuery('html, body').animate({ scrollTop: 0 }, duration);
                    return false;
                })
            });
        </script>
        <!-- /top-link-block -->
        <!-- Jscript -->
        <script src="js/jquery.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <script src="js/jquery.prettyPhoto.js" type="text/javascript"></script>
        <script src="js/jquery.isotope.min.js" type="text/javascript"></script>
        <script src="js/main.js" type="text/javascript"></script>
        <script src="js/wow.min.js" type="text/javascript"></script>
    </form>
</body>

</html>
