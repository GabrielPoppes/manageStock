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
using System.Threading;

namespace GerenciadorDeEstoque.DAO
{
    public class LoginDaoComandos : Cadastrar
    {
        // tela após logar
        Thread TelaInicial;
        public bool check = false;
        public string mensagem = "";
        SqlCommand comando = new SqlCommand();
        Conexao conect = new Conexao();
        SqlDataReader armazenardados;

        // Método para abrir a tela após logar
        private void telaLogada()
        {
            Application.Run(new TelaLogado());
        }

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
                    // Cmds para abrir a tela "TelaLogado" após a checagem dos logins
                    this.Visible = false;
                    TelaInicial = new Thread(telaLogada);
                    TelaInicial.SetApartmentState(ApartmentState.MTA);
                    TelaInicial.Start();

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
        
        // Método para cadastrar o Produto no estoque
        public string CadastrarProduto(string nome, string cor, string preco, string quantidade)
        {
            if (!nome.Equals("") && !preco.Equals("") && !quantidade.Equals(""))
            {
                comando.CommandText = "insert into produtos(nome, cor, preco, quantidade)values(@nome, @cor, @preco, @quantidade);";
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@cor", cor);
                comando.Parameters.AddWithValue("@preco", preco);
                comando.Parameters.AddWithValue("@quantidade", quantidade);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Produto cadastrado!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro no cadastro do produto!";
                }
            }
            return mensagem;
        }



        public string Cadastrar(string nome, string email, string senha, string confirmarsenha, string celular, string lembretesenha)
        {
            // Validar se o e-mail digitado contem @ e .com
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginDaoComandos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "LoginDaoComandos";
            this.Load += new System.EventHandler(this.LoginDaoComandos_Load);
            this.ResumeLayout(false);

        }

        private void LoginDaoComandos_Load(object sender, EventArgs e)
        {

        }
    }
}
