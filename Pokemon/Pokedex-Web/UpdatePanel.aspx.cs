using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace Pokedex_Web
{
    public partial class UpdatePanel : System.Web.UI.Page
    {
        protected ElementoNegocio negocio;
        protected PokemonNegocio negocioDos;
        protected List<Pokemon> pokemonList;
        protected List<Elemento> elementoList;
        //otro ejemplo url imagen
        private string urlImagen;

        protected string UrlImagen { get => urlImagen; set => urlImagen = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.negocio = new ElementoNegocio();
                    this.negocioDos = new PokemonNegocio();
                    this.pokemonList = negocioDos.listarConSP();
                    this.elementoList = negocio.ListarTiposConSP();

                    Session["listaPokemones"] = pokemonList;
                    ddlPokemones.DataBind();

                    ddlTiposPoke.DataSource = elementoList;
                    ddlTiposPoke.DataTextField = "Descripcion";
                    ddlTiposPoke.DataValueField = "Id";
                    ddlTiposPoke.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        protected void ddlTiposPoke_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlTiposPoke.SelectedItem.Value);
            ddlPokemones.DataSource = ((List<Pokemon>)Session["listaPokemones"]).FindAll(x => x.Tipo.Id == id);
            //ddlPokemones.DataTextField = "Nombre";
            ddlPokemones.DataBind();
        }

        protected void ddlPokemones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtUrlImagen.Text))
            {
                this.UrlImagen = this.txtUrlImagen.Text;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}