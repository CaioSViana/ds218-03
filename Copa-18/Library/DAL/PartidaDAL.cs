
using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class PartidaDAL
    {
        ConnectionFactory cf;

        public List<Partida> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_PARTIDA, DT_PARTIDA, DS_PARTIDA, ID_FASE_PARTIDA, ID_ESTADIO_PARTIDA from TB_PARTIDA ";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Partida> lista = new List<Partida>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Partida p = new Partida();//Instancia o objeto da vez.
                p.IdPartida = Convert.ToInt32(dr["ID_PARTIDA"]);
                p.IdFase = Convert.ToInt32(dr["ID_FASE_PARTIDA"]);
                p.DtPartida = Convert.ToDateTime(dr["DT_PARTIDA"]);
                p.IdEstadio = Convert.ToInt32(dr["ID_ESTADIO_PARTIDA"]);
                

                lista.Add(p);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }

        public void Insert(Partida p)
        {
            //Connection Factory: Classe que gerencia o local da conexão, tendo o método responsável por obter a conexão
            cf = new ConnectionFactory();

            //StringBuilder: Construtor de String e o Método Append concatena cada linha dentro da variável chamada query
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO TB_PARTIDA ");
            query.AppendLine("(DT_PARTIDA, DS_PARTIDA, ID_FASE_PARTIDA, ID_ESTADIO_PARTIDA) ");
            query.AppendLine("VALUES (@DT_PARTIDA, @DS_PARTIDA, @ID_FASE_PARTIDA, @ID_ESTADIO_PARTIDA) ");
            query.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

            //CreateCommand: Inicializa o objeto SqlCommand associando o comando com a conexão do Banco onde será executado
            cf.Comando = cf.Conexao.CreateCommand();

            //Abaixo os parametros que no momento da execução serão substituídos pelos valor das propriedades

            cf.Comando.Parameters.AddWithValue("@DT_PARTIDA", p.DtPartida);
            cf.Comando.Parameters.AddWithValue("@DS_PARTIDA", p.DsPartida);
            cf.Comando.Parameters.AddWithValue("@ID_FASE_PARTIDA", p.IdFase);
            cf.Comando.Parameters.AddWithValue("@ID_ESTADIO_PARTIDA", p.IdEstadio);

            //CommandType indica que o comando será via texto, poderia ser uma procedure no banco de dados por exemplo.
            cf.Comando.CommandType = CommandType.Text;//Clicar com o Direito para adicionar Using

            //CommandText: Propriedade do objeto command que receberá o texto do comando a ser executado.
            cf.Comando.CommandText = query.ToString();

            //Abre a conexão 
            cf.Conexao.Open();

            //ExecuteScalar retornar a primeira coluna do último select executado
            //Como o Scope_identity retorna a chave primária inserida, ele retornará o ID que guardaremos para o objeto
            p.IdPartida = Convert.ToInt32(cf.Comando.ExecuteScalar());

            //Fecha a conexão
            cf.Conexao.Close();
        }
        public DataTable FindPartidas()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            StringBuilder query = new StringBuilder();

            query.AppendLine("SELECT a.ID_PARTIDA, a.DT_PARTIDA, a.DS_PARTIDA, p1.ID_PLACAR ID_SELECAO_1, p2.ID_PLACAR  ID_SELECAO_2, ");
            query.AppendLine("s1.DS_SELECAO + ' ' + CONVERT(VARCHAR(50), p1.NR_GOL + ISNULL(p1.NR_GOL_PRORROGACAO, 0)) ");
            query.AppendLine("+ CASE p1.NR_GOL_DECISAO_PENALTIS WHEN 0 THEN '' ELSE '(' + CONVERT(VARCHAR(50), p1.NR_GOL_DECISAO_PENALTIS) + ')' END ");
            query.AppendLine("+ ' X ' ");
            query.AppendLine("+ CASE p2.NR_GOL_DECISAO_PENALTIS WHEN 0 THEN '' ELSE '(' + CONVERT(VARCHAR(50), p2.NR_GOL_DECISAO_PENALTIS) + ')' END ");
            query.AppendLine("+ CONVERT(VARCHAR(50), p2.NR_GOL + ISNULL(p2.NR_GOL_PRORROGACAO, 0)) + ' ' + s2.DS_SELECAO DS_PLACAR, ");
            query.AppendLine("f.DS_FASE, g1.DS_GRUPO GRUPO_SELECAO_1, g2.DS_GRUPO GRUPO_SELECAO_2, ");
            query.AppendLine("s1.DS_IMAGEM_BANDEIRA BANDEIRA_1, s1.DS_TIPO_IMAGEM_BANDEIRA TIPO_IMAGEM_BANDEIRA_1, s1.DS_CAMINHO_IMAGEM_BANDEIRA CAMINHO_IMAGEM_BANDEIRA_1, ");
            query.AppendLine("s2.DS_IMAGEM_BANDEIRA BANDEIRA_2, s2.DS_TIPO_IMAGEM_BANDEIRA TIPO_IMAGEM_BANDEIRA_2, s2.DS_CAMINHO_IMAGEM_BANDEIRA CAMINHO_IMAGEM_BANDEIRA_2, ");
            query.AppendLine("e.DS_ESTADIO, e.DS_CIDADE, e.DS_CAPACIDADE, e.DS_IMAGEM_ESTADIO, e.DS_TIPO_IMAGEM_ESTADIO, e.DS_CAMINHO_IMAGEM_ESTADIO ");
            query.AppendLine("FROM TB_PARTIDA a ");
            query.AppendLine("INNER JOIN TB_PLACAR p1 ON a.ID_PARTIDA = p1.ID_PARTIDA_PLACAR AND p1.BL_MANDANTE = 1 ");
            query.AppendLine("INNER JOIN TB_PLACAR p2 ON a.ID_PARTIDA = p2.ID_PARTIDA_PLACAR AND p2.BL_MANDANTE = 0 ");
            query.AppendLine("INNER JOIN TB_SELECAO s1 ON p1.ID_SELECAO = s1.ID_SELECAO ");
            query.AppendLine("INNER JOIN TB_SELECAO s2 ON p2.ID_SELECAO = s2.ID_SELECAO ");
            query.AppendLine("INNER JOIN TB_FASE f ON a.ID_FASE_PARTIDA = f.ID_FASE ");
            query.AppendLine("INNER JOIN TB_ESTADIO e ON a.ID_ESTADIO_PARTIDA = e.ID_ESTADIO ");
            query.AppendLine("INNER JOIN TB_GRUPO g1 ON s1.ID_GRUPO_SELECAO = g1.ID_GRUPO ");
            query.AppendLine("INNER JOIN TB_GRUPO g2 ON s1.ID_GRUPO_SELECAO = g2.ID_GRUPO ");

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query.ToString();

            //DataTable
            DataTable dt = new DataTable();

            //Adptador de comando recebe dados do comando/conexão
            SqlDataAdapter da = new SqlDataAdapter(cf.Comando);

            //Abrindo a Conexão
            cf.Conexao.Open();
            //Preechendo o DataTable através do Table Adapter
            da.Fill(dt);
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando o DataTable.
            return dt;
        }
    }
}
