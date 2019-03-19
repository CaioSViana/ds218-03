
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
    public class GrupoDAL
    {
        ConnectionFactory cf;

        public List<Grupo> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_GRUPO, DS_GRUPO FROM TB_GRUPO";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Grupo> lista = new List<Grupo>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Grupo g = new Grupo();//Instancia o objeto da vez.
                g.IdGrupo = Convert.ToInt32(dr["ID_GRUPO"]);
                g.DsGrupo = Convert.ToChar(dr["DS_GRUPO"]);
                
                lista.Add(g);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }
       
    }
}
