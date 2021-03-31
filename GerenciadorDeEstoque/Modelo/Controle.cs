using GerenciadorDeEstoque.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstoque.Modelo
{
    public class Controle
    {
        public bool verificacao;
        public string mensagem = "";

        // Método para acessar a acc
        public bool Acessar(string login, string senha)
        {
            // Instanciando a classe LoginDaoComandos e checando se o user/password estão corretos
            LoginDaoComandos loginDao = new LoginDaoComandos();
            verificacao = loginDao.VerificarLogin(login, senha);
            
            // Armazenando mensagem de erro
            if (!loginDao.mensagem.Equals(""))
            {
                this.mensagem = loginDao.mensagem;
            }
            return verificacao;
        }


        // Método para cadastrar a acc
        public string Cadastrar(string nome, string email, string senha, string confirmarsenha, string celular, string lembretesenha)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.Cadastrar(nome, email, senha, confirmarsenha, celular, lembretesenha);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para remover o produto do estoque
        public string RemoverProductEstoque(string id)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.RemoverProdutoEstoque(id);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }
        // Método para editar o produto no estoque (REMOVER QNT)
        public string EditarProdutosRemvQnt(string id, string quantidade)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.EditarProdutoRemoverQnt(id, quantidade);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para editar o produto no estoque (ADICIONAR QNT)
        public string EditarProdutos(string id, string quantidade)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.EditarProduto(id, quantidade);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para cadastrar um produto novo no estoque
        public string CadastrarProdutos(string nome, string cor, string preco, string quantidade)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.CadastrarProduto(nome, cor, preco, quantidade);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para cadastrar cliente físico
        public string CadastrarClientesFisico(string nome, string datanascimento, string telefone, string celular, string rg, string cpf, string endereco, string email, string observacoes)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.AddClienteFisico(nome, datanascimento, telefone, celular, rg, cpf, endereco, email, observacoes);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para cadastrar cliente jurídico / CNPJ
        public string CadastrarClientesJuridicos(string nome, string telefone, string celular, string cpf, string endereco, string email, string observacoes)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.AddClienteJuridico(nome, telefone, celular, cpf, endereco, email, observacoes);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para editar cliente 
        public string EditarClientes(string id, string nome, string datanascimento, string telefone, string celular, string rg, string cpf, string endereco, string email, string observacoes)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.EditarCliente(id, nome, datanascimento, telefone, celular, rg, cpf, endereco, email, observacoes);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para cadastrar pedido do cliente
        public string CadastrarPedidoCliente(string produto, string qntproduto, string valorproduto, string nomecliente, string formapgt, string desconto, string valortotalpedido)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.CadastrarPedidos(produto, qntproduto, valorproduto, nomecliente, formapgt, desconto, valortotalpedido);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para alterar estado do pedido
        public string CadastrarPedidoEstado(string id, Boolean pago, Boolean cancelado)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.PedidosEncerrados(id, pago, cancelado);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para remover cliente
        public string RemoverClientes(string id)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.RemoverCliente(id);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }

        // Método para remover pedido
        public string RemovePedidos(string id)
        {
            LoginDaoComandos loginDao = new LoginDaoComandos();
            this.mensagem = loginDao.RemoverPedido(id);

            if (loginDao.check)
            {
                this.verificacao = true;
            }
            return mensagem;
        }
    }
}
