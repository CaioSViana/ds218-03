
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
    public class PosicaoDAL
    {
        ConnectionFactory cf;

        public List<Posicao> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_POSICAO, DS_POSICAO FROM TB_POSICAO";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Posicao> lista = new List<Posicao>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Posicao g = new Posicao();//Instancia o objeto da vez.
                g.IdPosicao = Convert.ToInt32(dr["ID_POSICAO"]);
                g.DsPosicao = Convert.ToString(dr["DS_POSICAO"]);
                
                lista.Add(g);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }
       
    }
}
