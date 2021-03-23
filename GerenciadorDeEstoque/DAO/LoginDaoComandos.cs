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
using GerenciadorDeEstoque.Apresentação.Pedido;
using GerenciadorDeEstoque.Apresentação.Cliente;
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

        // Método para remover o produto do estoque
        public string RemoverProdutoEstoque(string id)
        {
            if (!id.Equals(""))
            {
                comando.CommandText = "delete from produtos where idproduto = @id;";
                comando.Parameters.AddWithValue("@id", id);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Produto removido!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro na removação do produto!";
                }
            }
            return mensagem;
        }

        // Método para editar o Produto no estoque (EDITAR)
        public string EditarProdutoRemoverQnt(string id, string quantidade)
        {
            if (!id.Equals("") && !quantidade.Equals(""))
            {
                comando.CommandText = "update produtos set quantidade = quantidade - @quantidade where idproduto = @id;";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@quantidade", quantidade);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Quantidade removida com sucesso!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro na remoção da quantia do produto!";
                }
            }
            return mensagem;
        }

        // Método para editar o Produto no estoque (ADICIONAR)
        public string EditarProduto(string id, string quantidade)
        {
            if (!id.Equals("") && !quantidade.Equals(""))
            {
                comando.CommandText = "update produtos set quantidade = quantidade + @quantidade where idproduto = @id;";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@quantidade", quantidade);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Quantidade adicionada com sucesso!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro na adição de quantidade do produto!";
                }
            }
            return mensagem;
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

        // Método para adicionar novo Cliente Físico
        public string AddClienteFisico(string nome, string datanascimento, string telefone, string celular, string rg, string cpf, string endereco, string email, string observacoes)
        {
            if (!nome.Equals("") && !datanascimento.Equals("") && !celular.Equals("") && !cpf.Equals("") && !endereco.Equals("") && !email.Equals(""))
            {
                comando.CommandText = "insert into ClienteFisico(nome, datanascimento, telefone, celular, rg, cpf, endereco, email, observacoes)values(@nome, @datanascimento, @telefone, @celular, @rg, @cpf, @endereco, @email, @observacoes)";
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@datanascimento", datanascimento);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@celular", celular);
                comando.Parameters.AddWithValue("@rg", rg);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@endereco", endereco);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@observacoes", observacoes);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Cliente adicionado com sucesso!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro no cadastro do cliente!";
                }
            }
            return mensagem;
        }

        // Método para adicionar novo Cliente Juridico / CNPJ
        public string AddClienteJuridico(string nome, string telefone, string celular, string cpf, string endereco, string email, string observacoes)
        {
            if (!nome.Equals("") && !celular.Equals("") && !cpf.Equals("") && !endereco.Equals("") && !email.Equals(""))
            {
                comando.CommandText = "insert into ClienteFisico(nome, telefone, celular, cpf, endereco, email, observacoes)values(@nome, @telefone, @celular, @cpf, @endereco, @email, @observacoes)";
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@celular", celular);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@endereco", endereco);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@observacoes", observacoes);

                check = false;
                try
                {
                    comando.Connection = conect.Conectar();
                    comando.ExecuteNonQuery();
                    conect.Desconectar();
                    this.mensagem = "Cliente adicionado com sucesso!";

                    check = true;
                }

                catch (SqlException)
                {
                    this.mensagem = "Erro no cadastro do cliente!";
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

        // Método para cadastrar o Pedidos de clientes
        public string CadastrarPedidos(string produto, string qntproduto, string valorproduto, string nomecliente, string formapgt, string desconto, string valortotalpedido)
        {
            if (!produto.Equals("") && !qntproduto.Equals("") && !valorproduto.Equals("") && !nomecliente.Equals("") && !formapgt.Equals("") && !valortotalpedido.Equals(""))
            {
                comando.CommandText = "insert into pedidos(produto, quantidadepedido, valorunitario, cliente, formadepgt, desconto, valortotalpedido) values(@produto, @quantidadepedido, @valorunitario, @cliente, @formadepgt, @desconto, @valortotalpedido);";
                comando.Parameters.AddWithValue("@produto", produto);
                comando.Parameters.AddWithValue("@quantidadepedido", qntproduto);
                comando.Parameters.AddWithValue("@valorunitario", valorproduto);
                comando.Parameters.AddWithValue("@cliente", nomecliente);
                comando.Parameters.AddWithValue("@formadepgt", formapgt);
                comando.Parameters.AddWithValue("@desconto", desconto);
                comando.Parameters.AddWithValue("@valortotalpedido", valortotalpedido);

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

        // Método para cadastrar pedidos encerrados
        public string PedidosEncerrados(string id, Boolean pago, Boolean cancelado)
        {
            // Se o campo ID do pedido não estiver em branco
            if (!id.Equals(""))
            {
                if(pago == true && cancelado == true)
                {
                    this.mensagem = "Erro no cadastro do produto!";
                }

                else
                {
                    if (pago == true)
                    {
                        comando.CommandText = "INSERT INTO pedidos_encerrados(estado, produto, quantidade, valorunitario, comprador, formapgt, desconto, valortotal) SELECT 'Pago', produto, quantidadepedido, valorunitario, cliente, formadepgt, desconto, valortotalpedido FROM pedidos where idpedidos = @id;";
                        comando.Parameters.AddWithValue("@id", id);

                        check = false;
                        try
                        {
                            comando.Connection = conect.Conectar();
                            comando.ExecuteNonQuery();
                            conect.Desconectar();
                            this.mensagem = "Estado do pedido modificado!";

                            check = true;
                        }

                        catch (SqlException)
                        {
                            this.mensagem = "Erro no cadastro do produto!";
                        }
                    }

                    if (cancelado == true)
                    {
                        comando.CommandText = "INSERT INTO pedidos_encerrados(estado, produto, quantidade, valorunitario, comprador, formapgt, desconto, valortotal) SELECT 'Cancelado', produto, quantidadepedido, valorunitario, cliente, formadepgt, desconto, valortotalpedido FROM pedidos where idpedidos = @id;";
                        comando.Parameters.AddWithValue("@id", id);

                        check = false;
                        try
                        {
                            comando.Connection = conect.Conectar();
                            comando.ExecuteNonQuery();
                            conect.Desconectar();
                            this.mensagem = "Estado do pedido modificado!";

                            check = true;
                        }

                        catch (SqlException)
                        {
                            this.mensagem = "Erro no cadastro do produto!";
                        }
                    }
                }               
            }

            return mensagem;
        }

    }
}
