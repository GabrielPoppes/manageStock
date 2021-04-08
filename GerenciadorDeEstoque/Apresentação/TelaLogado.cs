﻿using GerenciadorDeEstoque.DAO;
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

namespace GerenciadorDeEstoque.Apresentação
{
    // NOME DO BANCO DE DADOS: ESTOQUE
    // NOME DA TABELA: PRODUTOS
    public partial class TelaLogado : Form
    {
        // Thread da tela para editar usuários
        Thread EditarUsuario;

        // Thread da tela para editar clientes
        Thread EditarCliente;

        // Thread da tela para encerrar o pedido
        Thread TelaEncerrarPedido;

        // Thread da tela de adicionar novo cliente jurídico
        Thread AddClientsCNPJ;

        // Thread da tela de adicionar novo cliente físico
        Thread AddClients;
        // Thread da tela de adicionar novo produto no estoque
        Thread AddProduto;

        // Thraed da tela de editar produto no estoque;
        Thread EditarProduto;

        // Thread da tela adicionar pedido
        Thread TelaAdicionarPedido;

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
            GerarColunaTotalVendasAnalise();
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
            AddProduto = new Thread(TelaAddProduct);
            AddProduto.SetApartmentState(ApartmentState.MTA);
            AddProduto.Start();
        }

        // Método para abrir a tela para Adicionar um novo produto
        private void TelaAddProduct()
        {
            Application.Run(new AddProduct());
        }

        // Método para atualizar a ListView Produtos
        private void RefreshList()
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
            // Lógica para chamar a tela (thread) editar produtos
            EditarProduto = new Thread(EditProduct);
            EditarProduto.SetApartmentState(ApartmentState.MTA);
            EditarProduto.Start();
        }


        // Chamando a tela para Editar produtos do estoque
        private void EditProduct()
        {
            Application.Run(new EditarProduto());
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

        private void btn_NovoCliente_Click(object sender, EventArgs e)
        {
            AddClients = new Thread(TelaAddClients);
            AddClients.SetApartmentState(ApartmentState.MTA);
            AddClients.Start();
        }

        private void TelaAddClients()
        {
            Application.Run(new AddClient());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Lógica para chamar a tela (thread) cliente novo juridico
            AddClientsCNPJ = new Thread(AddClienteCNPJ);
            AddClientsCNPJ.SetApartmentState(ApartmentState.MTA);
            AddClientsCNPJ.Start();
        }

        private void AddClienteCNPJ()
        {
            Application.Run(new AddClienteCNPJ());
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
            TelaAdicionarPedido = new Thread(NovaTelaPedido);
            TelaAdicionarPedido.SetApartmentState(ApartmentState.MTA);
            TelaAdicionarPedido.Start();
        }

        // Método para rodar a tela "Pedidos"
        private void NovaTelaPedido()
        {
            Application.Run(new Pedidos());
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

        private void AbrirTelaEncerrarPedido()
        {
            Application.Run(new EncerrarPedido());
        }

        private void pictureAlterarEstadoPedido_Click(object sender, EventArgs e)
        {
            TelaEncerrarPedido = new Thread(AbrirTelaEncerrarPedido);
            TelaEncerrarPedido.SetApartmentState(ApartmentState.MTA);
            TelaEncerrarPedido.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
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

        // Botão atualizar lista
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        // Método para abrir a tela Editar Cliente
        private void AbrirTelaEditarCliente()
        {
            Application.Run(new EditarCliente());
        }

        // Método para abrir a tela Editar Cliente
        private void pictureBoxEditarCliente_Click(object sender, EventArgs e)
        {
            EditarCliente = new Thread(AbrirTelaEditarCliente);
            EditarCliente.SetApartmentState(ApartmentState.MTA);
            EditarCliente.Start();
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
            EditarUsuario = new Thread(TelaEditUser);
            EditarUsuario.SetApartmentState(ApartmentState.MTA);
            EditarUsuario.Start();
        }

        // Método para abrir a tela para editar um usuário
        private void TelaEditUser()
        {
            Application.Run(new EditarUsuario());
        }

        // Refresh para atualizar a list view de Usuário
        private void RefreshUsuario()
        {
            listViewUsuario.Items.Clear();

            // Lógica para atualizar a list view
            con.Open();
            cmdListView = new SqlCommand("select * from funcionario;", con);
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

        // método para atualizar o list view dos usuários
        private void imagemRefreshList_Click(object sender, EventArgs e)
        {
            RefreshUsuario();
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
            AdicionarItensTotalAnaliseVendas();

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

        // Método para gerar as colunas da List View de Análise de vendas (TOTAL DE VENDAS)
        public void GerarColunaTotalVendasAnalise()
        {
            listviewTotalVendas.Columns.Add("Quantidade total", 150).TextAlign = HorizontalAlignment.Center;
            listviewTotalVendas.Columns.Add("Valor total", 150).TextAlign = HorizontalAlignment.Center;
        }

        public void AdicionarItensTotalAnaliseVendas()
        {
            listviewTotalVendas.Items.Clear();

            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido = new SqlCommand($"select count(*), sum(total) from analisevendas;", con);

            da = new SqlDataAdapter(cmdAddPedido);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listviewTotalVendas.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
            }

        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  janeiro
        private void btnJaneiro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/01/2021', 103); set @DataFinal= convert (datetime, '31/01/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  fevereiro
        private void btnFevereiro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/02/2021', 103); set @DataFinal= convert (datetime, '28/02/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  março
        private void btnMarco_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/03/2021', 103); set @DataFinal= convert (datetime, '31/03/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  abril
        private void btnAbril_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/04/2021', 103); set @DataFinal= convert (datetime, '30/04/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  maio
        private void btnMaio_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/05/2021', 103); set @DataFinal= convert (datetime, '31/05/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de  junho
        private void btnJunho_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/06/2021', 103); set @DataFinal= convert (datetime, '30/06/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de julho
        private void btnJulho_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/07/2021', 103); set @DataFinal= convert (datetime, '31/07/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de agosto
        private void btnAgosto_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/08/2021', 103); set @DataFinal= convert (datetime, '31/08/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de setembro
        private void btnSetembro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/09/2021', 103); set @DataFinal= convert (datetime, '30/09/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de outubro
        private void btnOutubro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/10/2021', 103); set @DataFinal= convert (datetime, '31/10/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de novembro
        private void btnNovembro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/11/2021', 103); set @DataFinal= convert (datetime, '30/11/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
            }
        }

        // Botão para fazer o filtro das datas na análise de vendas do mês de dezembro
        private void btnDezembro_Click(object sender, EventArgs e)
        {
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA PRIMEIRA  LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//

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
            // ***********************************************//
            // ***********************************************//
            // ATUALIZAÇÃO DA SEGUNDA LISTA VIEW PARA O FILTRO
            // ***********************************************//
            // ***********************************************//
            listviewTotalVendas.Items.Clear();

            con.Open();

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            // Count(*) = vai pegar o total de registros cadastrados na tabela; sum() = vai fazer a soma do total de todos os valores da coluna
            SqlCommand cmdAddPedido1 = new SqlCommand($"declare @DataInicial datetime, @DataFinal datetime; set @DataInicial= convert (datetime, '01/12/2021', 103); set @DataFinal= convert (datetime, '31/12/2021', 103); SELECT count(*), sum(total) from analisevendas where convert (datetime, dataPedido, 121) between @DataInicial and @DataFinal;", con);

            da = new SqlDataAdapter(cmdAddPedido1);
            ds = new DataSet();

            da.Fill(ds, "estoque");

            con.Close();
            dt = ds.Tables["estoque"];

            int j;
            for (j = 0; j <= dt.Rows.Count - 1; j++)
            {
                listviewTotalVendas.Items.Add(dt.Rows[j].ItemArray[0].ToString());
                listviewTotalVendas.Items[j].SubItems.Add(dt.Rows[j].ItemArray[1].ToString());
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
