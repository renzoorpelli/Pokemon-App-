<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokeForm.aspx.cs" Inherits="Pokedex_Web.PokeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-light">Lista de pokemones</h1>
    <div class="col-6">
        <div class="mb-3">
            <asp:Label Text="Filtrar" runat="server" CssClass="text-light" />
            <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control bg-dark text-light" />
        </div>
        <div class="mb-3">
            <asp:CheckBox Text="Filtro Avanzado"
                CssClass="text-light"
                runat="server"
                ID="chkAvanzado"
                AutoPostBack="true"
                OnCheckedChanged="chkAvanzado_CheckedChanged" />
            <asp:CheckBox Text="Limpiar Filtros" runat="server" ID="chkLimpiarFiltros" AutoPostBack="true" CssClass="text-light" OnCheckedChanged="chkLimpiarFiltros_CheckedChanged" />
        </div>
    </div>
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%if (chkAvanzado.Checked)
                { %>
            <div class="row text-light">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblCampo" runat="server" Text="Campo"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control bg-dark text-light" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblCriterio" runat="server" Text="Criterio"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control bg-dark text-light" ID="ddlCriterio" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblFiltro" runat="server" Text="Filtro"></asp:Label>
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control bg-dark text-light" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                        <asp:DropDownList runat="server" CssClass="form-control bg-dark text-light" ID="ddlEstado">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
            <%  } %>



            <hr class="text-light" />
            <asp:GridView
                ID="dgvPokemons"
                runat="server"
                DataKeyNames="Id"
                CssClass="table table-dark table-hover"
                AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
                AllowPaging="true"
                PageSize="5"
                OnPageIndexChanging="dgvPokemons_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Editar" />
                </Columns>
            </asp:GridView>
            <asp:Button Text="Agregar Pokemon" ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-dark border" OnClick="btnAgregar_Click" />
            <hr class="text-light" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
