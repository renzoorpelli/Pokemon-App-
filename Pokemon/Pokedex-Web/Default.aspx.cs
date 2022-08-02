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
    public partial class Default : System.Web.UI.Page
    {
        protected PokemonNegocio negocio;

        public List<Pokemon> ListaPokemon;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.negocio = new PokemonNegocio();
            ListaPokemon = negocio.listarConSP();
            if (!IsPostBack)
            {
                this.repRepetidor.DataSource = ListaPokemon;
                this.repRepetidor.DataBind();
            }

        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {
            string valor = (sender as Button).CommandArgument;
            if (valor != null)
            {
                Response.Redirect($"DetallePokemon.aspx?id={valor}");
            }
        }
    }
}