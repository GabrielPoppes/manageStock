﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoque.DAO
{
    public class LoginDaoComandos
    {
        public bool check = false;
        public string mensagem = "";
        SqlCommand comando = new SqlCommand();
        Conexao conect = new Conexao();
        SqlDataReader armazenardados;

        // Método que verifica se login e senha estão corretos, passando a string true or false
        public bool VerificarLogin(string login, string senha)
        {
            comando.CommandText = "select * from funcionario where email = @login and senha = @senha";
            comando.Parameters.AddWithValue("@login", login);
            comando.Parameters.AddWithValue("@senha", senha);

            try
            {
                comando.Connection = conect.Conectar();
                armazenardados = comando.ExecuteReader();

                if (armazenardados.HasRows)
                {
                    check = true;
                }
                conect.Desconectar();
                armazenardados.Close();
            }

            catch(SqlException)
            {
                this.mensagem = "Erro com banco de dados!";
            }
            return check;
        }

        public string Cadastrar(string email, string senha, string confirmarsenha, string celular, string lembretesenha)
        {
            if (senha.Equals(confirmarsenha))
            {
                comando.CommandText = "insert into funcionario(email, senha, celular, lembretesenha)values(@email, @senha, @celular, @lembretesenha);";
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senha);
                comando.Parameters.AddWithValue("@celular", celular);
                comando.Parameters.AddWithValue("@lembretesenha", lembretesenha);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    
                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro com o banco de dados!";
                }
            }
            return mensagem;
        }
    }
}
