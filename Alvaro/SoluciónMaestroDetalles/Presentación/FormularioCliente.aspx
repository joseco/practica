<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="CapaPresentación.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conten" runat="server">
<section class="row">
        <div class="col-md-6">

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
                    ValidationGroup="Cliente"
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
                    ValidationGroup="Cliente"
                    ErrorMessage="Debe ingresar el Nit">
                </asp:RequiredFieldValidator>
            </div>
            
           

            <asp:LinkButton ID="SaveButton" runat="server"
                CssClass="btn btn-primary"
                ValidationGroup="Cliente"
                OnClick="SaveButton_Click">
                Guardar
            </asp:LinkButton>
            <asp:HyperLink runat="server" CssClass="btn"
                NavigateUrl="~/ListaClientes.aspx">
                Cancelar
            </asp:HyperLink>

            <asp:HiddenField ID="ClienteIdHiddenField" runat="server"
                Value="0" />
        </div>
    </section>
</asp:Content>

