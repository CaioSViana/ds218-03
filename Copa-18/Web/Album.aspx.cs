using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Album : System.Web.UI.Page
    {
        PosicaoBLL pService = new PosicaoBLL();
        SelecaoBLL selService = new SelecaoBLL();
        JogadorBLL jService = new JogadorBLL();

        public void CarregarPosicoes()
        {
            ddlPosicao.DataSource = pService.FindaAll();
            ddlPosicao.DataTextField = "DsPosicao";
            ddlPosicao.DataValueField = "idPosicao";
            ddlPosicao.DataBind();

            ddlPosicao.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarSelecoes()
        {
            ddlSelecao.DataSource = selService.FindaAll();
            ddlSelecao.DataTextField = "DsSelecao";
            ddlSelecao.DataValueField = "idSelecao";
            ddlSelecao.DataBind();

            ddlSelecao.Items.Insert(0, new ListItem("---Selecione---", "0"));
        }

        public void CarregarJogadores()
        {
            dataListJogadores.DataSource = jService.FindaAll();
            dataListJogadores.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CarregarPosicoes();
                CarregarSelecoes();
                CarregarJogadores();
            }
        }

        protected void btnSalvarJogador_Click(object sender, EventArgs e)
        {
            try
            {
                string pastaImagens = ConfigurationManager.AppSettings["PastaBaseCopa18"];

                string nomeArquivo = fupJogador.FileName;

                string caminhoRelativoImagem = string.Format("\\{0}\\{1}", ddlSelecao.SelectedItem.Text, nomeArquivo);

                string caminhoCompletoPasta = string.Format("{0}\\{1}", pastaImagens, ddlSelecao.SelectedItem.Text);

                string caminhoCompletoImagem = string.Format("{0}\\{1}", caminhoCompletoPasta, nomeArquivo);

                string extensaoImagem = Path.GetExtension(fupJogador.PostedFile.FileName).ToLower();

                byte[] imagemBytes = new byte[fupJogador.PostedFile.InputStream.Length + 1];

                fupJogador.PostedFile.InputStream.Read(imagemBytes, 0, imagemBytes.Length);

                Jogador j = new Jogador();
                j.DsNome = txtNome.Text;
                j.NrCamisa = Convert.ToInt32(txtNumeroCamisa.Text);
                j.IdPosicaoJogador = Convert.ToInt32(ddlPosicao.SelectedValue);
                j.IdSelecaoJogador = Convert.ToInt32(ddlSelecao.SelectedValue);
                j.DsCaminhoImagemJogador = caminhoRelativoImagem;
                j.DsImagemJogador = imagemBytes;

                if (extensaoImagem == ".gif")
                    j.DsTipoImagem = "image/gif";
                else if (extensaoImagem == ".jpg" || extensaoImagem == ".jpeg" || extensaoImagem == ".jpeg")
                    j.DsTipoImagem = "image/jpeg";
                else
                    throw new Exception("Tipo de imagem não permitido");

                if (jService.Insert(j))
                {
                    if (!Directory.Exists(caminhoCompletoPasta))
                        Directory.CreateDirectory(caminhoCompletoPasta);

                    fupJogador.SaveAs(caminhoCompletoImagem);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnFiltarSelecao_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSelecao.SelectedValue == "0")
                    throw new Exception("Selecione uma seleção");

                int idSelecao = Convert.ToInt32(ddlSelecao.SelectedValue);

                dataListJogadores.DataSource = jService.FindBySelecao(idSelecao);
                dataListJogadores.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnFiltrarPosicao_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPosicao.SelectedValue == "0")
                    throw new Exception("Selecione uma posição");

                int idPosicao = Convert.ToInt32(ddlPosicao.SelectedValue);

                dataListJogadores.DataSource = jService.FindByPosicao(idPosicao);
                dataListJogadores.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    
    }
}