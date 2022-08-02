using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
namespace Pokedex_Web
{
    public partial class PokeAgregarForm : System.Web.UI.Page
    {
        protected ElementoNegocio negocio;
        protected List<Elemento> listaElementos;
        protected PokemonNegocio pokemonNegocio;
        protected Pokemon aux;
        protected string idAux;
        protected string accion;

        public bool ConfimarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.negocio = new ElementoNegocio();
            this.listaElementos = new List<Elemento>();
            this.pokemonNegocio = new PokemonNegocio();
            this.accion = "Agregar";
            try
            {
                if (!IsPostBack)
                {
                    //configuracion inicial de pantalla
                    this.listaElementos = negocio.ListarTiposConSP();


                    this.ddlTipo.DataSource = this.listaElementos;
                    this.ddlTipo.DataTextField = "Descripcion";
                    this.ddlTipo.DataValueField = "Id";
                    this.ddlTipo.DataBind();

                    this.ddlDebilidad.DataSource = this.listaElementos;
                    this.ddlDebilidad.DataTextField = "Descripcion";
                    this.ddlDebilidad.DataValueField = "Id";
                    this.ddlDebilidad.DataBind();

                    //configuracion si vamos a modificar un objeto
                    this.idAux = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (idAux != string.Empty)
                    {
                        this.accion = "Gestión ";
                        this.btnAceptar.Visible = false;
                        this.btnModificar.Visible = true;
                        this.btnEliminar.Visible = true;
                        this.btnEstado.Visible = true;
                        //guarda el pokemon seleccionado en sesion
                        aux = pokemonNegocio.BuscarPorId(idAux);
                        Session.Add("auxPoke", aux);

                        this.txtNombre.Text = aux.Nombre;
                        this.txtNumero.Text = aux.Numero.ToString();
                        this.ddlTipo.SelectedIndex = aux.Tipo.Id;
                        this.ddlDebilidad.SelectedIndex = aux.Debilidad.Id;
                        this.txtDescripcion.Text = aux.Descripcion;
                        this.txtUrlImagen.Text = aux.UrlImagen;
                        this.imgSourcePokemon.ImageUrl = aux.UrlImagen;

                        if(!aux.Activo)
                        {
                            btnEstado.CssClass = "btn btn-success";
                            btnEstado.Text = "Reactivar";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error al cargar los tipos de Pokemon :(", ex);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtUrlImagen.Text))
            {
                this.imgSourcePokemon.ImageUrl = this.txtUrlImagen.Text;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon pokemon = new Pokemon(
                    PokemonNegocio.ValidarCamposInt(this.txtNumero.Text) ? int.Parse(this.txtNumero.Text) : new Random().Next(5, 100),
                    PokemonNegocio.ValidarCamposString(this.txtNombre.Text) ? this.txtNombre.Text : "Nombre Invalido",
                    PokemonNegocio.ValidarCamposString(this.txtDescripcion.Text) ? this.txtDescripcion.Text : "Descripcion Invalido",
                    PokemonNegocio.ValidarUrlImagen(this.txtUrlImagen.Text) ? this.txtUrlImagen.Text : "Url Invalida",
                    true
                    );
                pokemon.Tipo = new Elemento();
                pokemon.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                pokemon.Debilidad = new Elemento();
                pokemon.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                pokemonNegocio.agregarConSP(pokemon);
                Response.Redirect("PokeForm.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error al dar de alta un Pokemon :(", ex);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            this.aux = (Pokemon)Session["auxPoke"];
            if (this.aux != null)
            {
                try
                {
                    this.aux.Numero = PokemonNegocio.ValidarCamposInt(this.txtNumero.Text) ? int.Parse(this.txtNumero.Text) : new Random().Next(5, 100);
                    this.aux.Nombre = PokemonNegocio.ValidarCamposString(this.txtNombre.Text) ? this.txtNombre.Text : "Nombre Invalido";
                    this.aux.Descripcion = PokemonNegocio.ValidarCamposString(this.txtDescripcion.Text) ? this.txtDescripcion.Text : "Descripcion Invalido";
                    this.aux.UrlImagen = PokemonNegocio.ValidarUrlImagen(this.txtUrlImagen.Text) ? this.txtUrlImagen.Text : "Url Invalida";
                    this.aux.Tipo = new Elemento();
                    this.aux.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                    this.aux.Debilidad = new Elemento();
                    this.aux.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                    pokemonNegocio.modificarConSP(this.aux);
                    Response.Redirect("PokeForm.aspx", false);
                }
                catch (Exception ex)
                {

                    Session.Add("Error al dar de Modificar un Pokemon :(", ex);
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            this.ConfimarEliminacion = true;
        }

        protected void btnConfirmarElimnacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfimarEliminacion = true;
                if (chkConfirmarELiminacion.Checked)
                {
                    this.aux = (Pokemon)Session["auxPoke"];
                    if (this.aux != null)
                    {
                        this.pokemonNegocio.EliminarConSp(this.aux.Id);
                        Response.Redirect("PokeForm.aspx", false);
                    }
                }
                else
                {
                    chkConfirmarELiminacion.CssClass = "text-danger";
                    chkConfirmarELiminacion.Text = "Debe tildar la opción";
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error al eliminar un Pokemon", ex);
            }
        }

        protected void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                this.aux = (Pokemon)Session["auxPoke"];
                if (this.aux != null)
                {
                    if (this.aux.Activo)
                    {
                        this.pokemonNegocio.EliminarLogicoConSP(this.aux.Id);
                    }
                    else
                    {
                        this.pokemonNegocio.EliminarLogicoConSP(this.aux.Id, true);
                    }
                    Response.Redirect("PokeForm.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error al eliminar un Pokemon", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PokeForm.aspx", false);
        }
    }
}