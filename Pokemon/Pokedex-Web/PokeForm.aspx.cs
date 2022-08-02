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
    public partial class PokeForm : System.Web.UI.Page
    {
        protected PokemonNegocio negocio;
        protected List<Pokemon> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.negocio = new PokemonNegocio();
                Session.Add("listaPokemones", negocio.listarConSP());
                dgvPokemons.DataSource = Session["listaPokemones"];
                dgvPokemons.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PokeAgregarForm.aspx", false);
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPokemons.SelectedDataKey.Value.ToString();
            if (id != null)
            {
                Response.Redirect($"PokeAgregarForm.aspx?id={id}");
            }
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            this.lista = (List<Pokemon>)Session["listaPokemones"];
            this.dgvPokemons.DataSource = this.lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            this.dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = !chkAvanzado.Checked;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedIndex == 2)
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.negocio = new PokemonNegocio();
                this.dgvPokemons.DataSource = null;
                this.dgvPokemons.DataSource = this.negocio.filtrar(
                    this.ddlCampo.SelectedItem.ToString(),
                    this.ddlCriterio.SelectedItem.ToString(),
                    this.txtFiltroAvanzado.Text,
                    this.ddlEstado.SelectedItem.ToString());
                this.dgvPokemons.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("Error desde el buscar", ex);
            }
        }

        protected void chkLimpiarFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if(chkLimpiarFiltros.Checked)
            {
                this.chkAvanzado.Checked = false;
                this.dgvPokemons.DataSource = null;
                this.dgvPokemons.DataSource = Session["listaPokemones"];
                this.dgvPokemons.DataBind();
            }
            
        }
    }
}