
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
    public class JogadorDAL
    {
        ConnectionFactory cf;
        byte[] semImagem = null;

        public void Insert(Jogador j)
        {
            //Connection Factory: Classe que gerencia o local da conexão, tendo o método responsável por obter a conexão
            cf = new ConnectionFactory();

            //StringBuilder: Construtor de String e o Método Append concatena cada linha dentro da variável chamada query
            StringBuilder query = new StringBuilder();
            query.AppendLine("INSERT INTO TB_JOGADOR ");
            query.AppendLine("(DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR, DS_IMAGEM_JOGADOR, DS_TIPO_IMAGEM_JOGADOR, DS_CAMINHO_IMAGEM_JOGADOR) ");
            query.AppendLine("VALUES (@DS_NOME, @NR_NUMERO, @ID_POSICAO_JOGADOR, @ID_SELECAO_JOGADOR, @DS_IMAGEM_JOGADOR, @DS_TIPO_IMAGEM_JOGADOR, @DS_CAMINHO_IMAGEM_JOGADOR) ");
            query.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

            //CreateCommand: Inicializa o objeto SqlCommand associando o comando com a conexão do Banco onde será executado
            cf.Comando = cf.Conexao.CreateCommand();

            //Abaixo os parametros que no momento da execução serão substituídos pelos valor das propriedades
                        
            cf.Comando.Parameters.AddWithValue("@DS_NOME", j.DsNome);
            cf.Comando.Parameters.AddWithValue("@NR_NUMERO", j.NrCamisa);
            cf.Comando.Parameters.AddWithValue("@ID_POSICAO_JOGADOR", j.IdPosicaoJogador);
            cf.Comando.Parameters.AddWithValue("@ID_SELECAO_JOGADOR", j.IdSelecaoJogador);

            //Se o array de bytes estiver diferente de vazio, salvará, caso contrário manda nulo para o banco
            if(j.DsImagemJogador.Length != 0)
                cf.Comando.Parameters.AddWithValue("@DS_IMAGEM_JOGADOR", j.DsImagemJogador);
            else
                cf.Comando.Parameters.AddWithValue("@DS_IMAGEM_JOGADOR", DBNull.Value);

            //Se o caminho da imagem não estiver vazio, salvará, caso contrário mando nulo para o banco
            if (!string.IsNullOrEmpty(j.DsCaminhoImagemJogador))
            {
                cf.Comando.Parameters.AddWithValue("@DS_CAMINHO_IMAGEM_JOGADOR", j.DsCaminhoImagemJogador);
                cf.Comando.Parameters.AddWithValue("@DS_TIPO_IMAGEM_JOGADOR", j.DsTipoImagem);
                
            }
            else
            {
                cf.Comando.Parameters.AddWithValue("@DS_CAMINHO_IMAGEM_JOGADOR", DBNull.Value);
                cf.Comando.Parameters.AddWithValue("@DS_TIPO_IMAGEM_JOGADOR", DBNull.Value);
            }

            //CommandType indica que o comando será via texto, poderia ser uma procedure no banco de dados por exemplo.
            cf.Comando.CommandType = CommandType.Text;//Clicar com o Direito para adicionar Using

            //CommandText: Propriedade do objeto command que receberá o texto do comando a ser executado.
            cf.Comando.CommandText = query.ToString();

            //Abre a conexão 
            cf.Conexao.Open();

            //ExecuteScalar retornar a primeira coluna do último select executado
            //Como o Scope_identity retorna a chave primária inserida, ele retornará o ID que guardaremos para o objeto Pessoa
            j.IdJogador = Convert.ToInt32(cf.Comando.ExecuteScalar());

            //Fecha a conexão
            cf.Conexao.Close();
        }

        public List<Jogador> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_JOGADOR, DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR, DS_IMAGEM_JOGADOR, DS_TIPO_IMAGEM_JOGADOR, DS_CAMINHO_IMAGEM_JOGADOR FROM TB_JOGADOR ";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Jogador> lista = new List<Jogador>();

            SqlDataReader dr = cf.Comando.ExecuteReader();

            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Jogador j = new Jogador();//Instancia o objeto da vez.
                j.IdJogador = Convert.ToInt32(dr["ID_JOGADOR"]);
                j.DsNome = Convert.ToString(dr["DS_NOME"]);
                j.NrCamisa = Convert.ToInt32(dr["NR_NUMERO"]);
                j.IdPosicaoJogador = Convert.ToInt32(dr["ID_POSICAO_JOGADOR"]);
                j.IdSelecaoJogador = Convert.ToInt32(dr["ID_SELECAO_JOGADOR"]);
                j.DsImagemJogador = (dr["DS_IMAGEM_JOGADOR"] != DBNull.Value) ? (byte[])(dr["DS_IMAGEM_JOGADOR"]) : semImagem;
                j.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_JOGADOR"]);
                j.DsCaminhoImagemJogador = Convert.ToString(dr["DS_CAMINHO_IMAGEM_JOGADOR"]);

                lista.Add(j);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }

        public List<Jogador> FindBySelecao(int idSelecao)
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_JOGADOR, DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR, DS_IMAGEM_JOGADOR, DS_TIPO_IMAGEM_JOGADOR, DS_CAMINHO_IMAGEM_JOGADOR FROM TB_JOGADOR WHERE ID_SELECAO_JOGADOR = @ID_SELECAO_JOGADOR ";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;

            cf.Comando.Parameters.AddWithValue("@ID_SELECAO_JOGADOR", idSelecao);

            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Jogador> lista = new List<Jogador>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Jogador j = new Jogador();//Instancia o objeto da vez.
                j.IdJogador = Convert.ToInt32(dr["ID_JOGADOR"]);
                j.DsNome = Convert.ToString(dr["DS_NOME"]);
                j.NrCamisa = Convert.ToInt32(dr["NR_NUMERO"]);
                j.IdPosicaoJogador = Convert.ToInt32(dr["ID_POSICAO_JOGADOR"]);
                j.IdSelecaoJogador = Convert.ToInt32(dr["ID_SELECAO_JOGADOR"]);
                j.DsImagemJogador = (dr["DS_IMAGEM_JOGADOR"] != DBNull.Value) ? (byte[])(dr["DS_IMAGEM_JOGADOR"]) : semImagem;
                j.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_JOGADOR"]); 
                j.DsCaminhoImagemJogador = Convert.ToString(dr["DS_CAMINHO_IMAGEM_JOGADOR"]);

                lista.Add(j);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }

        public List<Jogador> FindByPosicao(int idPosicao)
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_JOGADOR, DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR, DS_IMAGEM_JOGADOR, DS_TIPO_IMAGEM_JOGADOR, DS_CAMINHO_IMAGEM_JOGADOR FROM TB_JOGADOR WHERE ID_POSICAO_JOGADOR = @ID_POSICAO_JOGADOR ";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;

            cf.Comando.Parameters.AddWithValue("@ID_POSICAO_JOGADOR", idPosicao);

            //Abrindo a Conexão
            cf.Conexao.Open();
                        
            List<Jogador> lista = new List<Jogador>();

            SqlDataReader dr = cf.Comando.ExecuteReader();

            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Jogador j = new Jogador();//Instancia o objeto da vez.
                j.IdJogador = Convert.ToInt32(dr["ID_JOGADOR"]);
                j.DsNome = Convert.ToString(dr["DS_NOME"]);
                j.NrCamisa = Convert.ToInt32(dr["NR_NUMERO"]);
                j.IdPosicaoJogador = Convert.ToInt32(dr["ID_POSICAO_JOGADOR"]);
                j.IdSelecaoJogador = Convert.ToInt32(dr["ID_SELECAO_JOGADOR"]);
                j.DsImagemJogador = (dr["DS_IMAGEM_JOGADOR"] != DBNull.Value) ? (byte[])(dr["DS_IMAGEM_JOGADOR"]) : semImagem;
                j.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_JOGADOR"]);
                j.DsCaminhoImagemJogador = Convert.ToString(dr["DS_CAMINHO_IMAGEM_JOGADOR"]);

                lista.Add(j);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }
        public Jogador FindById(int idJogador)
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_JOGADOR, DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR, DS_IMAGEM_JOGADOR, DS_TIPO_IMAGEM_JOGADOR, DS_CAMINHO_IMAGEM_JOGADOR FROM TB_JOGADOR WHERE ID_JOGADOR = @ID_JOGADOR ";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;

            cf.Comando.Parameters.AddWithValue("@ID_JOGADOR", idJogador);

            //Abrindo a Conexão
            cf.Conexao.Open();

            Jogador j = null;

            SqlDataReader dr = cf.Comando.ExecuteReader();

            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                j = new Jogador();
                j.IdJogador = Convert.ToInt32(dr["ID_JOGADOR"]);
                j.DsNome = Convert.ToString(dr["DS_NOME"]);
                j.NrCamisa = Convert.ToInt32(dr["NR_NUMERO"]);
                j.IdPosicaoJogador = Convert.ToInt32(dr["ID_POSICAO_JOGADOR"]);
                j.IdSelecaoJogador = Convert.ToInt32(dr["ID_SELECAO_JOGADOR"]);
                j.DsImagemJogador = (dr["DS_IMAGEM_JOGADOR"] != DBNull.Value) ? (byte[])(dr["DS_IMAGEM_JOGADOR"]) : semImagem;
                j.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_JOGADOR"]);
                j.DsCaminhoImagemJogador = Convert.ToString(dr["DS_CAMINHO_IMAGEM_JOGADOR"]);                
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return j;
        }

    }
}
