using GerenciadorDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GerenciadorDeEstoque.Apresentação.Pedido
{
    public partial class Pedidos : Form
    {
        Thread TelaEncerrarPedido;

        public Pedidos()
        {
            InitializeComponent();
            QuantidadeDisponivel();
            AdicionarItemListViewPedidos();
        }

        // Método que adicionar os itens da Combo Box método de pagamento
        private void ComboBoxFormaPgmt()
        {
            comboBox_FormaPgt.Items.Add("Dinheiro");
            comboBox_FormaPgt.Items.Add("Cartão");
            comboBox_FormaPgt.Items.Add("Boleto");
        }

        // Método que carrega o nome dos Clientes e o nome dos produtos
        private void Pedidos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'nomeClientes.funcionario'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionarioTableAdapter.Fill(this.nomeClientes.funcionario);
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.estoqueDataSet.produtos);
        }



        private void QuantidadeDisponivel()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string nome = Convert.ToString(comboBox_Produto.SelectedValue);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select quantidade from produtos where nome = '{nome}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for(i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txb_QntEstoque.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        // Método para exibir o valor total do pedido (preço do produto * quantidade do pedido)
        private void ValorTotal()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string nome = Convert.ToString(comboBox_Produto.SelectedValue);
            // String quantidade para ver qual a quantidade do pedido
            string quantidade = txbQnt.Text;

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select preco * {quantidade} from produtos where nome = '{nome}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbValorTotal.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        // Método para exibir o valor da unidade do produto selecionado
        private void ValorProduto()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string produto = Convert.ToString(comboBox_Produto.SelectedValue);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select preco from produtos where nome = '{produto}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbValorPorUnidade.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        // Método para aplicar desconto no valorTotal do pedido
        private void PorcentagemValorTotalProduto()
        {
            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // As strings abaixos pegam o valor da quantidade do item e do valor, para chegar no total
            // A desconto pega o desconto informado pelo usuário em %, ex. 10%
            // Total calcula o valor total do produto (qnt * valor)
            double qnt = Convert.ToInt32(txbQnt.Text);
            double valor = Convert.ToInt32(txbValorPorUnidade.Text);
            double desconto = Convert.ToInt32(txbDesconto.Text);
            double total = qnt * valor;

            // Aqui aplicamos o desconto no valor
            double valorcomdesconto = total - (total * (desconto / 100));

            // Passamos o valor com desconto para a textbox do valor total, porem, convertendo para string novamente
            txbValorTotal.Text = Convert.ToString(valorcomdesconto);
            
        }

        private void comboBox_Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuantidadeDisponivel();
            ValorProduto();
        }

        // Métodos chamados quando o usuário escreve a quantidade do pedido
        private void txbQnt_TextChanged(object sender, EventArgs e)
        {
            // Se o campo quantidade não estiver em branco
            if (!txbQnt.Text.Equals(""))
            {
                // É exibido o valor total
                ValorTotal();
            }
            
        }

        // Botão para aplicar o desconto no valor total do pedido
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            // Método para aplicar o desconto no valor total do pedido
            PorcentagemValorTotalProduto();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();

            string mensagem = controle.CadastrarPedidoCliente(comboBox_Produto.Text, txbQnt.Text, txbValorPorUnidade.Text, comboBox_Cliente.Text, comboBox_FormaPgt.Text, txbDesconto.Text, txbValorTotal.Text);

            if (controle.verificacao)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }

            else
            {
                MessageBox.Show("Erro ao realizar o cadastro!");
            }

            AdicionarItemListViewPedidos();
        }

        public void GerarColunasPedidos()
        {
            listView_Pedidos.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Produto", 100).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Quantidade", 90).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Valor unitário", 90).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Comprador", 180).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Forma pagamento", 100).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Desconto (%)", 85).TextAlign = HorizontalAlignment.Center;
            listView_Pedidos.Columns.Add("Valor total", 80).TextAlign = HorizontalAlignment.Center;
        }

        public void AdicionarItemListViewPedidos()
        {
            GerarColunasPedidos();
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos;", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for(i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Pedidos.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView_Pedidos.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
            }

        }

        private void btnEncerrarPedido_Click(object sender, EventArgs e)
        {
            TelaEncerrarPedido = new Thread(AbrirTelaEncerrarPedido);
            TelaEncerrarPedido.SetApartmentState(ApartmentState.MTA);
            TelaEncerrarPedido.Start();
        }

        private void AbrirTelaEncerrarPedido()
        {
            Application.Run(new EncerrarPedido());
        }
    }
}
