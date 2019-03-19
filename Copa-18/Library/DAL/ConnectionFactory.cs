using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ConnectionFactory
    {
        public string connectionName = "ConexaoHoracio";
        private SqlConnection conexao;

        public SqlConnection Conexao
        {
            get { return conexao; }
            set { conexao = value; }
        }
        private SqlCommand comando;

        public SqlCommand Comando
        {
            get { return comando; }
            set { comando = value; }
        }

       

        public ConnectionFactory()
        {
            string strConn = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            conexao = new SqlConnection(strConn);
        }
    }
}
