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
    public partial class DetallePokemon : System.Web.UI.Page
    {
        protected PokemonNegocio negocio;
        protected Pokemon pokemonSeleccionado;
        public List<Pokemon> ListarPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.negocio = new PokemonNegocio();

                if(Request.QueryString["id"].ToString() != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    this.ListarPokemon = negocio.listarConSP();
                    pokemonSeleccionado = this.ListarPokemon.Find(x => x.Id==id);
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
                
            }
        }
    }
}