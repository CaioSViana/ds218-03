
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
    public class SelecaoDAL
    {
        ConnectionFactory cf;

        public List<Selecao> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_SELECAO, DS_SELECAO, ID_GRUPO_SELECAO, DS_IMAGEM_BANDEIRA, DS_TIPO_IMAGEM_BANDEIRA, DS_CAMINHO_IMAGEM_BANDEIRA FROM TB_SELECAO";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Selecao> lista = new List<Selecao>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Selecao s = new Selecao();//Instancia o objeto da vez.
                s.IdSelecao = Convert.ToInt32(dr["ID_SELECAO"]);
                s.DsSelecao = Convert.ToString(dr["DS_SELECAO"]);                
                s.IdGrupoSelecao = Convert.ToInt32(dr["ID_GRUPO_SELECAO"]);                
                s.DsImagemBandeira = Convert.ToString(dr["DS_IMAGEM_BANDEIRA"]);
                s.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_BANDEIRA"]);
                s.DsCaminhoImagemBandeira = Convert.ToString(dr["DS_CAMINHO_IMAGEM_BANDEIRA"]);              
                

                lista.Add(s);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }

        public List<Selecao> FindaByGrupo(int idGrupo)
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_SELECAO, DS_SELECAO, ID_GRUPO_SELECAO, DS_IMAGEM_BANDEIRA, DS_TIPO_IMAGEM_BANDEIRA, DS_CAMINHO_IMAGEM_BANDEIRA FROM TB_SELECAO WHERE ID_GRUPO_SELECAO = @ID_GRUPO_SELECAO";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;

            cf.Comando.Parameters.AddWithValue("@ID_GRUPO_SELECAO", idGrupo);
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Selecao> lista = new List<Selecao>();

            SqlDataReader dr = cf.Comando.ExecuteReader();

            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Selecao s = new Selecao();//Instancia o objeto da vez.
                s.IdSelecao = Convert.ToInt32(dr["ID_SELECAO"]);
                s.DsSelecao = Convert.ToString(dr["DS_SELECAO"]);
                s.IdGrupoSelecao = Convert.ToInt32(dr["ID_GRUPO_SELECAO"]);
                s.DsImagemBandeira = Convert.ToString(dr["DS_IMAGEM_BANDEIRA"]);
                s.DsTipoImagem = Convert.ToString(dr["DS_TIPO_IMAGEM_BANDEIRA"]);
                s.DsCaminhoImagemBandeira = Convert.ToString(dr["DS_CAMINHO_IMAGEM_BANDEIRA"]);

                lista.Add(s);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }

    }
}
