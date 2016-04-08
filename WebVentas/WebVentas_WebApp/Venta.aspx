<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="WebVentas.Venta" %>

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
    <style type="text/css">
        .auto-style2 {
            width: 238px;
            height: 59px;
        }
        .auto-style3 {
            height: 47px;
            width: 197px;
        }
        .auto-style4 {
            width: 238px;
            height: 47px;
        }
        .auto-style5 {
            height: 59px;
            width: 197px;
        }
        .auto-style6 {
            height: 47px;
            width: 204px;
        }
        .auto-style7 {
            height: 59px;
            width: 204px;
        }
    </style>
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
               
    <div style="min-height:300px; width:913px;">
    <asp:Label ID="JlaberSubtotal" runat="server" Text="$ 0.00"></asp:Label>
    <fieldset style="min-height:300px; " >
        <legend>Ventas</legend>
        <table style="margin:10px;">
            <tr>
                <td class="auto-style6">Codigo Venta</td>
                <td class="auto-style3">Prodcuto:</td>
                <td class="auto-style4">cliente</td>
                <td class="auto-style4">Cantidad</td>
                <td class="auto-style4">Precio</td>
            </tr>
            <tr>
                <td class="auto-style7">
                   
                    <asp:TextBox ID="txtcodigoVenta" MaxLength="10" Width="90" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td class="auto-style5">
                   
                    <asp:DropDownList ID="DropDownListProducto" runat="server" DataSourceID="SqlDataSourceListaProducto" DataTextField="nombre" DataValueField="producto_id" Height="36px" Width="149px" CssClass="form-control">
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">
                   
                    <asp:DropDownList ID="DropDownListCliente" runat="server" DataSourceID="SqlDataSourceCliente" DataTextField="nombre" DataValueField="cliente_id" Height="37px" Width="149px" CssClass="form-control">
                    </asp:DropDownList>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtCANTIDAD" MaxLength="10" Width="90" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPrecio" MaxLength="10" Width="90" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width:100%; margin-bottom: 55px;">
            <tr>
                <td style="text-align:center;">
                    <br />
                    <asp:Button ID="btnGrabar" OnClick="btnGrabar_Click" Width="100px" 
                    Height="43px"  runat="server" Text="Grabar" CssClass="btn btn-primary" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancelar" OnClick="btnCancelar_Click" Width="100px" 
                    Height="43px" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
                    <br />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ListaVentas" AllowPaging="True" AutoGenerateColumns="False" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="cliente" HeaderText="cliente" SortExpression="cliente" />
                            <asp:BoundField DataField="nit" HeaderText="nit" SortExpression="nit" />
                            <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                            <asp:BoundField DataField="cantidad" HeaderText="cantidad" SortExpression="cantidad" />
                            <asp:BoundField DataField="producto" HeaderText="producto" SortExpression="producto" />
                            <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="ListaVentas" runat="server" ConnectionString="<%$ ConnectionStrings:VentaConnectionString %>" SelectCommand="SELECT tbl_cliente.nombre AS cliente, tbl_cliente.nit, tbl_detalleVenta.precio, tbl_detalleVenta.cantidad, tbl_producto.nombre AS producto, tbl_venta.fecha FROM tbl_venta INNER JOIN tbl_cliente ON tbl_venta.cliente_id = tbl_cliente.cliente_id INNER JOIN tbl_producto INNER JOIN tbl_detalleVenta ON tbl_producto.producto_id = tbl_detalleVenta.producto_id ON tbl_venta.venta_id = tbl_detalleVenta.venta_id"></asp:SqlDataSource>
                    <br />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <asp:SqlDataSource ID="SqlDataSourceListaProducto" runat="server" ConnectionString="<%$ ConnectionStrings:VentaConnectionString %>" SelectCommand="SELECT [producto_id], [nombre] FROM [tbl_producto]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceCliente" runat="server" ConnectionString="<%$ ConnectionStrings:VentaConnectionString %>" SelectCommand="SELECT [cliente_id], [nombre] FROM [tbl_cliente]"></asp:SqlDataSource>
    </fieldset>
    </div>
    
               
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
