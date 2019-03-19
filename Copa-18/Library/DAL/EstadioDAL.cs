
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
    public class EstadioDAL
    {
        ConnectionFactory cf;

        public List<Estadio> FindAll()
        {
            //Instancia a Classe que Controla o Banco
            cf = new ConnectionFactory();

            //Comando SQL armazenado em uma string
            string query = "SELECT ID_ESTADIO, DS_ESTADIO FROM TB_ESTADIO";

            //Iniciando a propriedade de comando de acordo com a conexão.
            cf.Comando = cf.Conexao.CreateCommand();

            //Informando o tipo de Comando, poderia ser Stored Procedure também
            cf.Comando.CommandType = CommandType.Text;

            //Passando a variável de comando para a propriedade Command Text
            cf.Comando.CommandText = query;
            
            //Abrindo a Conexão
            cf.Conexao.Open();

            
            List<Estadio> lista = new List<Estadio>();

            SqlDataReader dr = cf.Comando.ExecuteReader();
            
            //Se a consulta retornar dados do banco, cada registro será lido, cada coluna e depois inserido na lista
            while (dr.Read())
            {
                Estadio e = new Estadio();//Instancia o objeto da vez.
                e.IdEstadio = Convert.ToInt32(dr["ID_ESTADIO"]);
                e.DsEstadio = Convert.ToString(dr["DS_ESTADIO"]);
                
                lista.Add(e);//Após carregar o objeto com os dados do banco, insere na lista.
            }
            //Fechando a conexão
            cf.Conexao.Close();

            //Retornando a lista preenchida.
            return lista;
        }
       
    }
}
