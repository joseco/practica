﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="WebVentas.ListaClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Lista | Clientes</title>
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

      <nav class="navbar navbar-inverse" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                  <%--  <a class="navbar-brand" href="Default.aspx"><img src="images/logo.png" alt="logo"></a>--%>
                </div>
				
                <div class="collapse navbar-collapse navbar-right">
 <ul class="nav navbar-nav">
                        <li class="active"><a href="Inicio.aspx">Inicio</a></li>
                       <li><a href="FormularioProductos.aspx">Productos</a></li>
                        <li><a href="FormularioCliente.aspx">Clientes</a></li>                        
                        <li><a href="Venta.aspx">Venta</a></li>  
                          <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Listas <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu">
                                li><a href="Listaproducto.aspx">Lista de productos</a></li>
                                <li><a href="Listaclientes.aspx">Lista de clientes</a></li>
                                <li><a href="Venta.aspx">Lista de ventas</a></li
                             
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
                <section class="row">
        <div class="col-md-12">

            <asp:HyperLink runat="server" NavigateUrl="~/FormularioCliente.aspx"
                CssClass="btn btn-primary">
                Nuevo Cliente
            </asp:HyperLink>
            <br /><br />

            <asp:GridView ID="ClientesGridView" runat="server"
                CssClass="table" GridLines="None"
                AutoGenerateColumns="false"
                OnRowCommand="ClientesGridView_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" CommandName="Editar"
                                CommandArgument='<%# Eval("cliente_id") %>'>
                                <i class="glyphicon glyphicon-pencil"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Eliminar"
                                OnClientClick="return confirm('Esta seguro que desea eliminar el Cliente seleccionado?')"
                                CommandArgument='<%# Eval("cliente_id") %>'>
                                <i class="glyphicon glyphicon-remove"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nombre" HeaderText="Nombre Completo" />
                    <asp:BoundField DataField="nit" HeaderText="Nit CLiente" />
            
                </Columns>
            </asp:GridView>

        </div>
    </section>
               
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
        <a href="#" class="back-to-top"><i class="fa fa-2x fa-angle-up"></i></a>
    </footer>
        <!--/#footer-->
        <!-- Back To Top -->
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
