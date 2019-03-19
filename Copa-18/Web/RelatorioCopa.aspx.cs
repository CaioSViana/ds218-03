using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class RelatorioCopa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            //Instanciando o Table Adapter do Dataset
            dsRelatoriosTableAdapters.USP_OBTER_PARTIDASTableAdapter dta =
            new dsRelatoriosTableAdapters.USP_OBTER_PARTIDASTableAdapter();
            //Chamando a consulta contida no table adapter
            //Numero da Fase: O ideal seria passar os dados através de um item selecionado de um DropDownList
            DataTable dt = dta.GetData();
            //Indica que o processamento do relatório é local
            rptRelatorio.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = rptRelatorio.LocalReport;
            //Indica o caminho físico do relatório
            localReport.ReportPath = "Relatorios/PartidasCopa.rdlc";
            //Instância fonte de dados do relatório
            ReportDataSource rpds = new ReportDataSource();
            //Abaixo deve ser colocado o nome dado ao Dataset que contém os campos no relatório
            rpds.Name = "dsPartidas";//Pode ser que seu DataSource criado no relatório tenha um nome diferente.
            //Atribuição do resultado da pesquisa à fonte de dados do relatório
            rpds.Value = dt;
            //Limpa a fonte de dados do relatório, para evitar que dados anteriores fiquem no relatório
            rptRelatorio.LocalReport.DataSources.Clear();
            //Adiciona o dataSource instanciado aqui a cima para a fonte de dados do relatório
            rptRelatorio.LocalReport.DataSources.Add(rpds);
            rptRelatorio.Visible = true; //Deixa o relatório visível
        }
    }
}