using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Tabela : System.Web.UI.Page
    {
        FaseBLL faseService = new FaseBLL();
        EstadioBLL estadioService = new EstadioBLL();
        SelecaoBLL selecaoService = new SelecaoBLL();
        PartidaBLL partidaService = new PartidaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarFases();
                CarregarEstadios();
                CarregarSelecao1();
                CarregarSelecao2();
                CarregarPartidas();
            }
        }

        public void CarregarFases()
        {
            ddlFase.DataSource = faseService.FindaAll();
            ddlFase.DataValueField = "IdFase";
            ddlFase.DataTextField = "DsFase";
            ddlFase.DataBind();
            //Código abaixo insere item default para evitar que já exista um selecionado
            ddlFase.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarEstadios()
        {
            ddlEstadio.DataSource = estadioService.FindaAll();
            ddlEstadio.DataValueField = "IdEstadio";
            ddlEstadio.DataTextField = "DsEstadio";
            ddlEstadio.DataBind();
            //Código abaixo insere item default para evitar que já exista um selecionado
            ddlEstadio.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarSelecao1()
        {
            ddlSelecaoOrdem1.DataSource = selecaoService.FindaAll();
            ddlSelecaoOrdem1.DataValueField = "IdSelecao";
            ddlSelecaoOrdem1.DataTextField = "DsSelecao";
            ddlSelecaoOrdem1.DataBind();
            //Código abaixo insere item default para evitar que já exista um selecionado
            ddlSelecaoOrdem1.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarSelecao2()
        {
            ddlSelecaoOrdem2.DataSource = selecaoService.FindaAll();
            ddlSelecaoOrdem2.DataValueField = "IdSelecao";
            ddlSelecaoOrdem2.DataTextField = "DsSelecao";
            ddlSelecaoOrdem2.DataBind();
            //Código abaixo insere item default para evitar que já exista um selecionado
            ddlSelecaoOrdem2.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarPartidas()
        {
            gvPartidas.DataSource = partidaService.FindPartidas();
            gvPartidas.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSelecaoOrdem1.SelectedValue == ddlSelecaoOrdem2.SelectedValue)
                    throw new Exception("Escolha duas seleções diferentes");

                Partida p = new Partida();
                p.IdEstadio = Convert.ToInt32(ddlEstadio.SelectedValue);
                p.IdFase = Convert.ToInt32(ddlFase.SelectedValue);
                p.DtPartida = Convert.ToDateTime(txtData.Text);
                p.DsPartida = string.Format("{0} x {1}", ddlSelecaoOrdem1.SelectedItem.Text, ddlSelecaoOrdem2.SelectedItem.Text);
                p.ListaPlacar = new List<Placar>();

                Placar p1 = new Placar();
                p1.BlMandante = true;
                p1.IdSelecao = Convert.ToInt32(ddlSelecaoOrdem1.SelectedValue);
                p1.NrGol = Convert.ToInt32(txtPlacarSelecao1.Text);
                if (!string.IsNullOrEmpty(txtPlacarSelecao1Prorrogacao.Text))
                    p1.NrGolProrrogacao = Convert.ToInt32(txtPlacarSelecao1Prorrogacao.Text);
                else
                    p1.NrGolProrrogacao = 0;

                if (!string.IsNullOrEmpty(txtPlacarSelecao1Penaltis.Text))
                    p1.NrGolPenaltis = Convert.ToInt32(txtPlacarSelecao1Penaltis.Text);
                else
                    p1.NrGolPenaltis = 0;

                p.ListaPlacar.Add(p1);

                Placar p2 = new Placar();
                p2.BlMandante = false;
                p2.IdSelecao = Convert.ToInt32(ddlSelecaoOrdem2.SelectedValue);
                p2.NrGol = Convert.ToInt32(txtPlacarSelecao2.Text);
                if (!string.IsNullOrEmpty(txtPlacarSelecao2Prorrogacao.Text))
                    p2.NrGolProrrogacao = Convert.ToInt32(txtPlacarSelecao2Prorrogacao.Text);
                else
                    p2.NrGolProrrogacao = 0;

                if (!string.IsNullOrEmpty(txtPlacarSelecao2Penaltis.Text))
                    p2.NrGolPenaltis = Convert.ToInt32(txtPlacarSelecao2Penaltis.Text);
                else
                    p2.NrGolPenaltis = 0;

                p.ListaPlacar.Add(p2);

                if (partidaService.Insert(p))
                {
                    CarregarPartidas();
                    Response.Write("Partida salva com sucesso.");
                }

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}