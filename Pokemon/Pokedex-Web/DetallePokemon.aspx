<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePokemon.aspx.cs" Inherits="Pokedex_Web.DetallePokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="text-light">Nombre <%: this.pokemonSeleccionado.Nombre %></h2>
        <hr class="text-light"/>
        <div class="card mb-3 mx-auto bg-dark border  border-secondary text-light" style="max-width: 700px" >
            <div class="row g-0">
                <div class="col-md-4">
                    <img src="<%:this.pokemonSeleccionado.UrlImagen %>" class="img-fluid rounded-start" alt="...">
                </div>
                <div class="col-md-8">
                    <div class="card-body">
                        <h5 class="card-title">DETALLES</h5>
                        <p class="card-text">Numero: <%: this.pokemonSeleccionado.Numero%></p>
                        <p class="card-text">Tipo: <%: this.pokemonSeleccionado.Tipo%></p>
                        <p class="card-text">Debilidad: <%: this.pokemonSeleccionado.Debilidad%></p>
                        <p class="card-text">Activo: <%:this.pokemonSeleccionado.Activo ? "Si": "No" %></p>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr class="text-light"/>
</asp:Content>
