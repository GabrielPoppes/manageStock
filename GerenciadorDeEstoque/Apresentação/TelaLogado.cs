using GerenciadorDeEstoque.DAO;
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
using GerenciadorDeEstoque.Apresentação.Cliente;
using GerenciadorDeEstoque.Apresentação.Pedido;
using GerenciadorDeEstoque.Apresentação.Usuário;
using System.Windows.Forms.DataVisualization.Charting;

namespace GerenciadorDeEstoque.Apresentação
{
    // NOME DO BANCO DE DADOS: ESTOQUE
    // NOME DA TABELA: PRODUTOS
    public partial class TelaLogado : Form
    {
        // Variável do tipo SqlCommand para executar os cmds do BD
        SqlCommand cmdListView = new SqlCommand();

        // Conectando com o banco de dados ESTOQUE
        SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        // variáveis necessárias para pegar os dados do BD e atribuir na list view
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        // end 

        public TelaLogado()
        {
            // Método chamados na inicialização do programa
            InitializeComponent();

            // Método para criar o gráfico de vendas
            CriandoGraficoVendas();

            // Métodos pra esconder as telas da form TelaLogado
            EsconderBotoesEstoque();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderGroupBoxUsuario();
            EsconderAlaytics();
            EsconderSuporteTecnico();

            // Métodos para gerar as colunas das List Views das forms escondidas
            GerarColunasClientes();
            GerarColunas();
            GerarColunasUsuarios();
            AdicionarItemListViewPedidos();
            GerarColunaListViewAnaliseVendas();
        }


        public TelaLogado(AddProduct formProduct)
        {
            // Métodos para abrir a form TelaLogado na aba Produtos
            AdicionarItemListView();
            EsconderGroupBoxUsuario();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderAlaytics();
            EsconderSuporteTecnico();
            ExibirEstoque();
            RefreshList();
        }

        // Esconder o Group Box Usuário
        private void EsconderGroupBoxUsuario()
        {
            gpBoxUsuario.Hide();
        }

        // Mostrar Group Box Usuário
        private void MostrarGroupBoxUsuario()
        {
            gpBoxUsuario.Show();
        }

        // Mostrar interface gráfica do cliente
        private void MostrarBotoesCliente()
        {
            gpb_Cliente.Show();
        }
        // Esconder interface gráfica do cliente
        private void EsconderBotoesCliente()
        {
            gpb_Cliente.Hide();
        }
        // Esconder interface gráfica do estoque
        private void EsconderBotoesEstoque()
        {
            picture_AddProd.Hide();
            picture_Edit.Hide();
            label_AddProd.Hide();
            label_EditEstoq.Hide();
            listView_Cliente.Hide();
            gpb_Estoque.Hide();

        }

        // Exibir interface gráfica do estoque
        private void ExibirEstoque()
        {
            gpb_Estoque.Show();
            listView_Cliente.Show();
            picture_AddProd.Show();
            picture_Edit.Show();
            label_AddProd.Show();
            label_EditEstoq.Show();
        }

        // Gerar colunas da List View Produtos
        private void GerarColunas()
        {
            listView_Cliente.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listView_Cliente.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listView_Cliente.Columns.Add("Cor", 100).TextAlign = HorizontalAlignment.Center;
            listView_Cliente.Columns.Add("Preço", 100).TextAlign = HorizontalAlignment.Center;
            listView_Cliente.Columns.Add("Quantidade", 100).TextAlign = HorizontalAlignment.Center;
        }

        // Gerar colunas da List View Clientes
        private void GerarColunasClientes()
        {
            listView_Clientes.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Data de nascimento", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Telefone", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Celular", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("RG", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("CPF / CNPJ", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Endereço", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("E-mail", 100).TextAlign = HorizontalAlignment.Center;
            listView_Clientes.Columns.Add("Observações", 100).TextAlign = HorizontalAlignment.Center;
        }



        // Método para passar os dados do BD para a List View
        public void AdicionarItemListView()
        {
            // método para exibir os botões visuais do estoque
            ExibirEstoque();

            // Conectar com o banco de dados
            con.Open();
            // Instrução SQL para executar
            cmdListView = new SqlCommand("select * from produtos", con);
            da = new SqlDataAdapter(cmdListView);
            ds = new DataSet();
            // Fill, que passar os dados da tabela "estoque" para o data set = ds
            // estoque = nome da tabela
            da.Fill(ds, "estoque");

            // fechar conexão
            con.Close();
            // o data set (ds) não consegue passar os dados no "visual" do programa, então, passando para o data table (dt)
            // estoque = tabela do bd
            dt = ds.Tables["estoque"];

            // lógica com o for para atribuir os dados do bd nas colunas do list view do programa
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Cliente.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 4 colunas (sendo uma a ID), então aqui só criamos 3, a ID vai automática
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

            }
        }

        // Botão sair do menu
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Botão com imagem (ESTOQUE)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdicionarItemListView();
            EsconderGroupBoxUsuario();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderAlaytics();
            EsconderSuporteTecnico();
            ExibirEstoque();
            RefreshList();
        }

        // Imagem do "Criar novo produto"
        private void picture_AddProd_Click(object sender, EventArgs e)
        {
            AddProduct telaProduto = new AddProduct();
            telaProduto.ShowDialog();
            RefreshList();

        }

        // Método para atualizar a ListView Produtos
        public void RefreshList()
        {
            // Limpar o campo da List View
            listView_Cliente.Items.Clear();

            // Lógica para atualizar a list view
            con.Open();
            cmdListView = new SqlCommand("select * from produtos", con);
            da = new SqlDataAdapter(cmdListView);
            ds = new DataSet();
            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Cliente.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 4 colunas (sendo uma a ID), então aqui só criamos 3, a ID vai automática
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Cliente.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

            }
        }

        // Botão Editar Produtos do estoque
        private void picture_Edit_Click(object sender, EventArgs e)
        {
            EditarProduto abrirfrmEditarProduto = new EditarProduto();
            abrirfrmEditarProduto.ShowDialog();
            RefreshList();
        }

        // Botão imagem cliente
        private void btnImg_Cliente_Click(object sender, EventArgs e)
        {
            EsconderSuporteTecnico();
            EsconderBotoesEstoque();
            EsconderGroupBoxUsuario();
            EsconderAlaytics();
            MostrarBotoesCliente();
            EsconderTelaPedidos();
            AdicionarItemListViewCliente();
            RefreshListClient();
        }

        // Botão cadastrar novo cliente
        private void btn_NovoCliente_Click(object sender, EventArgs e)
        {
            AddClient abrirfrmAddCliente = new AddClient();
            abrirfrmAddCliente.ShowDialog();
            RefreshListClient(); // Método para atualizar a list view de clientes
        }

        // Botão para cadastrar novo cliente jurídico
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddClienteCNPJ abrirfrmClienteCNPJ = new AddClienteCNPJ();
            abrirfrmClienteCNPJ.ShowDialog();
            RefreshListClient();
        }

        // Método para passar os dados do BD para a List View (clientes)
        public void AdicionarItemListViewCliente()
        {
            // Conectar com o banco de dados
            con.Open();
            // Instrução SQL para executar
            cmdListView = new SqlCommand("select * from clientefisico", con);
            da = new SqlDataAdapter(cmdListView);
            ds = new DataSet();
            // Fill, que passar os dados da tabela "estoque" para o data set = ds
            // estoque = nome da tabela
            da.Fill(ds, "estoque");

            // fechar conexão
            con.Close();
            // o data set (ds) não consegue passar os dados no "visual" do programa, então, passando para o data table (dt)
            // estoque = tabela do bd
            dt = ds.Tables["estoque"];

            // lógica com o for para atribuir os dados do bd nas colunas do list view do programa
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Clientes.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 10 colunas (sendo uma a ID), então aqui só criamos 9, a ID vai automática
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());

            }
        }

        // Método para atualizar a ListView Cliente
        private void RefreshListClient()
        {
            // Limpar o campo da List View
            listView_Clientes.Items.Clear();

            // Lógica para atualizar a list view
            con.Open();
            cmdListView = new SqlCommand("select * from clientefisico", con);
            da = new SqlDataAdapter(cmdListView);
            ds = new DataSet();
            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Clientes.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 4 colunas (sendo uma a ID), então aqui só criamos 3, a ID vai automática
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                listView_Clientes.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());

            }
        }

        // Método para esconder a tela de pedidos
        private void EsconderTelaPedidos()
        {
            groupBox_pedidos.Hide();
        }

        // Método para mostrar a tela de pedidos
        private void MostrarTelaPedidos()
        {
            groupBox_pedidos.Show();
        }

        // Botão com imagem dos pedidos
        private void btn_pedido_Click(object sender, EventArgs e)
        {
            EsconderBotoesEstoque();
            EsconderGroupBoxUsuario();
            EsconderBotoesCliente();
            EsconderAlaytics();
            EsconderSuporteTecnico();
            MostrarTelaPedidos();
        }

        // Botão para fazer um novo pedido, joga para a tela "Pedidos"
        private void btn_criarPedido_Click(object sender, EventArgs e)
        {
            Pedidos formPedidos = new Pedidos();
            formPedidos.ShowDialog();
            RefreshPedidos(); // Atualizar lista pedidos quando fecha a form
        }

        // Gerar as colunas da list view pedidos
        public void GerarColunasPedidos()
        {
            listView_Pedido.Columns.Add("Data", 120).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("ID", 40).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Estado", 85).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Produto", 100).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Quantidade", 80).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Valor unitário", 80).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Comprador", 180).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Venda", 60).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Forma pagamento", 90).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Desconto (%)", 80).TextAlign = HorizontalAlignment.Center;
            listView_Pedido.Columns.Add("Valor total", 70).TextAlign = HorizontalAlignment.Center;
        }

        // Adicionar os itens na LIST VIEW de PEDIDOS
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
            SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados;", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
            }

        }

        // Refresh na LIST VIEW de PEDIDOS
        public void RefreshPedidos()
        {
            listView_Pedido.Items.Clear();
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados;", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
            }

        }

        // Abrir Form Encerrar Pedido
        private void pictureAlterarEstadoPedido_Click(object sender, EventArgs e)
        {
            EncerrarPedido abrirfrmEncerrarPedido = new EncerrarPedido();
            abrirfrmEncerrarPedido.ShowDialog();
            RefreshPedidos();
        }

        // Método para exibir somente pedidos PENDENTES, PAGOS ou CANCELADOS
        private void MetodoExibirPedidosporEstado()
        {
            // Se TODAS AS BOX tiverem desmarcadas
            if (checkBoxPendentes.Checked == false && checkBoxPago.Checked == false && checkBoxCancelados.Checked == false)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados;", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PENDENTES
            if (checkBoxPendentes.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pendente%';", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PAGO
            if (checkBoxPago.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pago%';", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX CANCELADO
            if (checkBoxCancelados.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Cancelado%';", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PAGO e a PENDENTE
            if (checkBoxPago.Checked == true && checkBoxPendentes.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pago%' or estado LIKE '%Pendente%' order by estado desc;", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PAGO e CANCELADO
            if (checkBoxPago.Checked == true && checkBoxCancelados.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pago%' or estado LIKE '%Cancelado%' order by estado desc;", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PENDENTE e CANCELADO
            if (checkBoxPendentes.Checked == true && checkBoxCancelados.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pendente%' or estado LIKE '%Cancelado%' order by estado desc;", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }

            // Se marcar somente a BOX PAGO, PENDENTE e CANCELADO
            if (checkBoxPago.Checked == true && checkBoxPendentes.Checked == true && checkBoxCancelados.Checked == true)
            {
                listView_Pedido.Items.Clear();
                SqlDataAdapter da;
                DataSet ds;

                // Conectar com o BD
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
                // Abrindo a conexão
                con.Open();

                // Variável do tipo SqlCOmmand para executar os cmds do BD
                SqlCommand cmdAddPedido = new SqlCommand($"select * from pedidos_encerrados where estado LIKE '%Pago%' or estado LIKE '%Pendente%' or estado LIKE '%Cancelado%' order by estado desc;", con);

                da = new SqlDataAdapter(cmdAddPedido);
                ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds, "estoque");

                con.Close();
                dt = ds.Tables["estoque"];

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    listView_Pedido.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[9].ToString());
                    listView_Pedido.Items[i].SubItems.Add(dt.Rows[i].ItemArray[10].ToString());
                }
            }
        }

        public void GerarColunasUsuarios()
        {
            listViewUsuario.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listViewUsuario.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listViewUsuario.Columns.Add("E-mail", 350).TextAlign = HorizontalAlignment.Center;
            listViewUsuario.Columns.Add("Celular", 150).TextAlign = HorizontalAlignment.Center;
        }

        public void AdicionarItensListaUsuario()
        {
            listViewUsuario.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"select idfuncionario, nome, email, celular from funcionario;", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewUsuario.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            }

        }



        // Check box pendentes
        private void checkBoxPendentes_CheckedChanged(object sender, EventArgs e)
        {
            MetodoExibirPedidosporEstado();
        }

        // Check box pagos
        private void checkBoxPago_CheckedChanged(object sender, EventArgs e)
        {
            MetodoExibirPedidosporEstado();
        }

        // Check box cancelados
        private void checkBoxCancelados_CheckedChanged(object sender, EventArgs e)
        {
            MetodoExibirPedidosporEstado();
        }

        // Botão para atualizar a lista de clientes
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RefreshListClient();
        }

        // Método para abrir a tela Editar Cliente
        private void pictureBoxEditarCliente_Click(object sender, EventArgs e)
        {
            EditarCliente abrirfrmEditarCliente = new EditarCliente();
            abrirfrmEditarCliente.ShowDialog();
            RefreshListClient(); // Atualizar a list view de clientes
        }

        // Botão usuário, quando clica exibe a tela
        private void picBoxUsuarios_Click(object sender, EventArgs e)
        {
            EsconderBotoesEstoque();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderAlaytics();
            EsconderSuporteTecnico();
            MostrarGroupBoxUsuario();
            AdicionarItensListaUsuario();
        }

        // Botão com imagem editar usuário
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EditarUsuario abrirfrmEditarUsuario = new EditarUsuario();
            abrirfrmEditarUsuario.ShowDialog();
            RefreshUsuario();
        }

        // Refresh para atualizar a list view de Usuário
        private void RefreshUsuario()
        {
            listViewUsuario.Items.Clear();

            // Lógica para atualizar a list view
            con.Open();
            cmdListView = new SqlCommand("select idfuncionario, nome, email, celular from funcionario;", con);
            da = new SqlDataAdapter(cmdListView);
            ds = new DataSet();
            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewUsuario.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 4 colunas (sendo uma a ID), então aqui só criamos 3, a ID vai automática
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewUsuario.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            }
        }

        // método para mostrar a tela de Analise
        private void MostrarAnalytics()
        {
            gpBoxAnalise.Show();
        }

        // método para esconder a tela de Analise
        private void EsconderAlaytics()
        {
            gpBoxAnalise.Hide();
        }

        // Botão com imagem da Análise
        private void imgSuporte_Click(object sender, EventArgs e)
        {
            EsconderBotoesEstoque();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderGroupBoxUsuario();
            EsconderSuporteTecnico();
            MostrarGroupBoxUsuario();
            MostrarAnalytics();
            AdicionarItensColunaAnaliseDeVendas();

            // Codificação do gráfico de vendas
            GerarGraficoVendas();

        }
        public void CriandoGraficoVendas()
        {
            Title title = new Title(); // Instanciando var do tipo title

            // Formatando e definindo valores do título
            title.Font = new Font("Arial", 14, FontStyle.Bold); // Bold = negrito
            title.ForeColor = Color.Brown;
            title.Text = "Vendas mensais";

            // Título do eixo X e Y; Eixo X = meses; Eixo Y = Valores
            // Eixo X
            graficoVendas.ChartAreas["ChartArea1"].AxisX.Title = "Ano de 2021"; // Deixe sempre o "ChartArea1", não mude se não da erro!!!
            graficoVendas.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            // Eixo Y
            graficoVendas.ChartAreas["ChartArea1"].AxisY.Title = "Faturamento (R$)";
            graficoVendas.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            // Removendo as "grades" verticais que aparecem de fundo do eixo X
            graficoVendas.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;

            // Adicionando o título e a formatação no gráfico de vendas
            graficoVendas.Titles.Add(title);

            
        }

        private void GerarGraficoVendas()
        {
            // Limpando o gráfico para não multiplicar os dados quando o usuário acessa várias vezes a sub tela
            graficoVendas.Series.Clear();

            // Criando uma série chamada Vendas. Série = conjunto de barras do gráfico (jan, fev, mar, abr, ...)
            graficoVendas.Series.Add("Vendas");
            // Legenda sobre o gráfico
            graficoVendas.Series["Vendas"].LegendText = "Faturamento";

            // Tipo do gráfico é o "Column" se fosse o pizza seria outro nome
            graficoVendas.Series["Vendas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            // Largura da barra do gráfico, no caso, defini como 4.
            graficoVendas.Series["Vendas"].BorderWidth = 2;

            // Comando para conectar com o banco de dados
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            con.Open(); // abrindo o banco de dados
            SqlCommand cmdAddPedido = new SqlCommand($"select sum(total) from analisevendas where dataPedido BETWEEN '01/01/2021' AND '31/01/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/02/2021' AND '28/02/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/03/2021' AND '31/03/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/04/2021' AND '30/04/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/05/2021' AND '30/05/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/06/2021' AND '30/06/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/07/2021' AND '31/07/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/08/2021' AND '31/08/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/09/2021' AND '30/09/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/10/2021' AND '31/10/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/11/2021' AND '30/11/2021' UNION ALL select sum(total) from analisevendas where dataPedido BETWEEN '01/12/2021' AND '31/12/2021';", con);
            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];

            // Gerando o gráfico de meses, janeiro a dezembro
            // No primeiro vai o X (meses), e depois os valores que estão no banco de dados
            graficoVendas.Series["Vendas"].Points.AddXY("Jan", dt.Rows[0].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Fev", dt.Rows[1].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Mar", dt.Rows[2].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Abr", dt.Rows[3].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Mai", dt.Rows[4].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Jun", dt.Rows[5].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Jul", dt.Rows[6].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Ago", dt.Rows[7].ItemArray[0].ToString());
            graficoVendas.Series["Vendas"].Points.AddXY("Set", dt.Rows[8].ItemArray[0].ToString());
            // graficoVendas.Series["Vendas"].Points.AddXY("Out", dt.Rows[9].ItemArray[0].ToString());
            // graficoVendas.Series["Vendas"].Points.AddXY("Nov", dt.Rows[10].ItemArray[0].ToString());
            // graficoVendas.Series["Vendas"].Points.AddXY("Dez", dt.Rows[11].ItemArray[0].ToString());

        }

        // Método para gerar as colunas da List View de Análise de vendas
        public void GerarColunaListViewAnaliseVendas()
        {
            listViewAnaliseVendas.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listViewAnaliseVendas.Columns.Add("Data", 200).TextAlign = HorizontalAlignment.Center;
            listViewAnaliseVendas.Columns.Add("Produto", 350).TextAlign = HorizontalAlignment.Center;
            listViewAnaliseVendas.Columns.Add("Quantidade", 150).TextAlign = HorizontalAlignment.Center;
            listViewAnaliseVendas.Columns.Add("Total", 150).TextAlign = HorizontalAlignment.Center;
        }

        public void AdicionarItensColunaAnaliseDeVendas()
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"select idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where estado = 'pago';", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());


            }

        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  janeiro
        private void btnJaneiro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/01/2021', 103); set @DataFinal= convert (datetime, '31/01/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  fevereiro
        private void btnFevereiro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/02/2021', 103); set @DataFinal= convert (datetime, '28/02/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  março
        private void btnMarco_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/03/2021', 103); set @DataFinal= convert (datetime, '31/03/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  abril
        private void btnAbril_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/04/2021', 103); set @DataFinal= convert (datetime, '30/04/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  maio
        private void btnMaio_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/05/2021', 103); set @DataFinal= convert (datetime, '31/05/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  junho
        private void btnJunho_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/06/2021', 103); set @DataFinal= convert (datetime, '30/06/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de julho
        private void btnJulho_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/07/2021', 103); set @DataFinal= convert (datetime, '31/07/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de agosto
        private void btnAgosto_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/08/2021', 103); set @DataFinal= convert (datetime, '31/08/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de setembro
        private void btnSetembro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/09/2021', 103); set @DataFinal= convert (datetime, '30/09/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de outubro
        private void btnOutubro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/10/2021', 103); set @DataFinal= convert (datetime, '31/10/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de novembro
        private void btnNovembro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/11/2021', 103); set @DataFinal= convert (datetime, '30/11/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de dezembro
        private void btnDezembro_Click(object sender, EventArgs e)
        {
            listViewAnaliseVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdAddPedido = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/12/2021', 103); set @DataFinal= convert (datetime, '31/12/2021', 103); SELECT idpedido, dataAddPedido, produto, quantidade, valortotal from pedidos_encerrados where convert(datetime, dataAddPedido, 121) between @DataInicial and @DataFinal AND estado = 'pago'; ", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listViewAnaliseVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listViewAnaliseVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
            }
        }

        // Método para esconder o Group Box do Suporte técnico
        private void EsconderSuporteTecnico()
        {
            gpBoxSuporte.Hide();
        }

        // Método para exibir o Group Box do suporte técnico
        private void MostrarSuporteTecnico()
        {
            gpBoxSuporte.Show();
        }

        private void pictureBoxSuporte_Click(object sender, EventArgs e)
        {
            EsconderBotoesEstoque();
            EsconderBotoesCliente();
            EsconderTelaPedidos();
            EsconderAlaytics();
            EsconderGroupBoxUsuario();
            MostrarSuporteTecnico();
        }
    }
}
