<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="CapaPresentación.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conten" runat="server">
    <section class="row">
        <div class="col-md-12">

            <asp:HyperLink runat="server" NavigateUrl="~/FormularioCliente.aspx"
                CssClass="btn btn-primary">
                Crear Cliente
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
                                CommandArgument='<%# Eval("clienteId") %>'>
                                <i class="glyphicon glyphicon-pencil"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Eliminar"
                                OnClientClick="return confirm('Esta seguro que desea eliminar el Cliente seleccionado?')"
                                CommandArgument='<%# Eval("clienteId") %>'>
                                <i class="glyphicon glyphicon-remove"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" />
                    <asp:BoundField DataField="Nit" HeaderText="Nit" />

                </Columns>
            </asp:GridView>



            
          
        </div>
    </section>
</asp:Content>