<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card bg-dark border  border-secondary" style="width: 18rem;">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="pokeImage">
                        <div class="card-body text-light">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <asp:Button Text="Más Información" CssClass="btn btn-primary btn-dark border  border-secondary" ID="btnInfo" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonId" OnClick="btnInfo_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
