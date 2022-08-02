<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="Pokedex_Web.UpdatePanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Requerido para usar UPDATE PANEL --%>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row ">
                <div class="col">
                    <asp:DropDownList ID="ddlTiposPoke"
                        runat="server"
                        AutoPostBack="true"
                        CssClass="btn btn-outline-dark dropdown-toggle text-light"
                        OnSelectedIndexChanged="ddlTiposPoke_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList ID="ddlPokemones"
                        runat="server"
                        CssClass="btn btn-outline-dark dropdown-toggle text-light"
                        OnSelectedIndexChanged="ddlPokemones_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <h2 class ="text-light">Seleccionar Imagen</h2>
                    <div class="mt-4">
                        <asp:TextBox 
                            ID="txtUrlImagen" 
                            runat="server" 
                            CssClass="form-control"
                            AutoPostBack="true"
                            OnTextChanged="txtUrlImagen_TextChanged">
                        </asp:TextBox>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-dark" OnClick="btnEnviar_Click"/>
                        <img src="<%= this.UrlImagen%>" alt="image" />
                    </div>

                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
