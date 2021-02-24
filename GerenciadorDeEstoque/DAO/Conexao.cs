using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoque.DAO
{
    public class Conexao
    {
        SqlConnection conectar = new SqlConnection();

        public Conexao()
        {
            conectar.ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        // Checando se o banco está fechado, antes de abri-lo
        public SqlConnection Conectar()
        {
            if(conectar.State == System.Data.ConnectionState.Closed)
            {
                conectar.Open();
            }
            return conectar;
        }

        // Checando se o banco está aberto, antes de fecha-lo
        public void Desconectar()
        {
            if(conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }


    }
}
