using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GerenciadorDeEstoque.Modelo;
using GerenciadorDeEstoque.Apresentação;
using GerenciadorDeEstoque.DAO;
using GerenciadorDeEstoque.Properties;

namespace GerenciadorDeEstoque.DAO
{
    public class LoginDaoComandos : Cadastrar
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

            catch (SqlException)
            {
                this.mensagem = "Erro com banco de dados!";
            }
            return check;
        }



        public string Cadastrar(string nome, string email, string senha, string confirmarsenha, string celular, string lembretesenha)
        {
            string check_email = email;
            bool valor_checkemail = check_email.Contains("@") && check_email.Contains(".com");
            if (valor_checkemail == true)
            {
                // checar se campos não estão em branco
                if (!nome.Equals("") && !email.Equals("") && !senha.Equals("") && !celular.Equals("") && !lembretesenha.Equals(""))
                {
                    // checar se senha e email tem caracteres minimos
                    if (senha.Length >= 5 && email.Length >= 8)
                    {
                        // checar se senha é igual a confirmar senha
                        if (senha.Equals(confirmarsenha))
                        {
                            comando.CommandText = "insert into funcionario(nome, email, senha, celular, lembretesenha)values(@nome, @email, @senha, @celular, @lembretesenha);";
                            comando.Parameters.AddWithValue("@nome", nome);
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

                        else
                        {
                            MessageBox.Show("As senhas devem ser iguais!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, use uma senha com mais de 5 caracteres!");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, não deixe campos em branco!");
                }
            }
            else
            {
                MessageBox.Show("Digite um e-mail válido!");
            }
            
            return mensagem;
        }
    }
}
