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

namespace GerenciadorDeEstoque.Apresentação
{
    // NOME DO BANCO DE DADOS: ESTOQUE
    // NOME DA TABELA: PRODUTOS
    public partial class TelaLogado : Form
    {
        // Thread da tela de adicionar novo cliente jurídico
        Thread AddClientsCNPJ;

        // Thread da tela de adicionar novo cliente físico
        Thread AddClients;
        // Thread da tela de adicionar novo produto no estoque
        Thread AddProduto;

        // Thred da tela de editar produto no estoque;
        Thread EditarProduto;

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
            InitializeComponent();
            EsconderBotoesEstoque();
            GerarColunas();
            EsconderBotoesCliente();
            GerarColunasClientes();
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
            btn_AtualizarLista.Hide();
        }

        // Exibir interface gráfica do estoque
        private void ExibirEstoque()
        {
            listView_Cliente.Show();
            picture_AddProd.Show();
            picture_Edit.Show();
            label_AddProd.Show();
            label_EditEstoq.Show();
            btn_AtualizarLista.Show();
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
            listView_Clientes.Columns.Add("CPF", 100).TextAlign = HorizontalAlignment.Center;
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
            EsconderBotoesCliente();
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
        // Botão Atualizar list View
        private void btn_AtualizarLista_Click(object sender, EventArgs e)
        {
            RefreshList();
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

        private void btnImg_Cliente_Click(object sender, EventArgs e)
        {
            EsconderBotoesEstoque();
            MostrarBotoesCliente();
            AdicionarItemListViewCliente();
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

        // Método para passar os dados do BD para a List View
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

        private void btn_atualizarlistaClientes_Click(object sender, EventArgs e)
        {
            RefreshListClient();
        }
    }
}
