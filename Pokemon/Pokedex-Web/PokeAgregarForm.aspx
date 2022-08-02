<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokeAgregarForm.aspx.cs" Inherits="Pokedex_Web.PokeAgregarForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <div class="row justify-content-center text-light">
        <div class="mb-3">
            <h1 class="justify-content-left"><%: this.accion %>Pokemons</h1>
            <hr class="bg-secondary" />
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control bg-dark border border-secondary text-light" placeholder="Ingrese el Nombre del Pokemon"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero: </label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control bg-dark border border-secondary text-light" placeholder="Ingrese la Descripcion del Pokemon"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo: </label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select bg-dark border border-secondary text-light "></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad: </label>
                <asp:DropDownList ID="ddlDebilidad" runat="server" CssClass="form-select bg-dark border border-secondary text-light"></asp:DropDownList>
            </div>
            <div class="mb-4">
                <asp:Button Text="Agregar" runat="server" ID="btnAceptar" CssClass="btn btn-success" OnClick="btnAceptar_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-dark" OnClick="btnCancelar_Click"/>
                <asp:Button Text="Modificar" runat="server" ID="btnModificar" CssClass="btn btn-warning" Visible="false" OnClick="btnModificar_Click" />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-danger" Visible="false" OnClick="btnEliminar_Click" />
                <asp:Button Text="Inactivar" runat="server" ID="btnEstado" CssClass="btn btn-warning" Visible="false" OnClick="btnEstado_Click" />
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control bg-dark border border-secondary text-light" placeholder="Ingrese la Descripcion del Pokemon"></asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen: </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtUrlImagen"
                            CssClass="form-control bg-dark border border-secondary text-light"
                            placeholder="Ingrese el la Url de la Imagen del Pokemon"
                            AutoPostBack="true"
                            OnTextChanged="txtUrlImagen_TextChanged">
                        </asp:TextBox>
                    </div>
                    <asp:Image
                        ID="imgSourcePokemon"
                        runat="server"
                        Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%if (ConfimarEliminacion)
                    { %>
                <div class="mb-3">
                    <asp:CheckBox Text=" Confirmar Eliminación" ID="chkConfirmarELiminacion" CssClass="text-light" runat="server" />
                    <asp:Button CssClass="btn btn-danger" Text="Confirmar Eliminacion" runat="server" ID="btnConfirmarElimnacion" OnClick="btnConfirmarElimnacion_Click" />
                </div>
                <%} %>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>
