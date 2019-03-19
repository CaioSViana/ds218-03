using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class PlacarDAL
    {
        private ConnectionFactory cf;

        public void Insert(Placar p)
        {
            //Connection Factory: Classe que gerencia o local da conexão, tendo o método responsável por obter a conexão
            cf = new ConnectionFactory();

            //StringBuilder: Construtor de String e o Método Append concatena cada linha dentro da variável chamada query
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO TB_PLACAR ");
            query.AppendLine("(ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) ");
            query.AppendLine("VALUES (@ID_PARTIDA_PLACAR, @ID_SELECAO, @BL_MANDANTE, @NR_GOL, @NR_GOL_PRORROGACAO, @NR_GOL_DECISAO_PENALTIS) ");
            query.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

            //CreateCommand: Inicializa o objeto SqlCommand associando o comando com a conexão do Banco onde será executado
            cf.Comando = cf.Conexao.CreateCommand();

            //Abaixo os parametros que no momento da execução serão substituídos pelos valor das propriedades

            cf.Comando.Parameters.AddWithValue("@ID_PARTIDA_PLACAR", p.IdPartida);
            cf.Comando.Parameters.AddWithValue("@ID_SELECAO", p.IdSelecao);
            cf.Comando.Parameters.AddWithValue("@BL_MANDANTE", p.BlMandante);
            cf.Comando.Parameters.AddWithValue("@NR_GOL", p.NrGol);
            cf.Comando.Parameters.AddWithValue("@NR_GOL_PRORROGACAO", p.NrGolProrrogacao);
            cf.Comando.Parameters.AddWithValue("@NR_GOL_DECISAO_PENALTIS", p.NrGolPenaltis);

            //CommandType indica que o comando será via texto, poderia ser uma procedure no banco de dados por exemplo.
            cf.Comando.CommandType = CommandType.Text;//Clicar com o Direito para adicionar Using

            //CommandText: Propriedade do objeto command que receberá o texto do comando a ser executado.
            cf.Comando.CommandText = query.ToString();

            //Abre a conexão 
            cf.Conexao.Open();

            //ExecuteScalar retornar a primeira coluna do último select executado
            //Como o Scope_identity retorna a chave primária inserida, ele retornará o ID que guardaremos para o objeto
            p.IdPlacar = Convert.ToInt32(cf.Comando.ExecuteScalar());

            //Fecha a conexão
            cf.Conexao.Close();
        }
    }
}
