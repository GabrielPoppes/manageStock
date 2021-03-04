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

namespace GerenciadorDeEstoque.Apresentação
{
    // NOME DO BANCO DE DADOS: ESTOQUE
    // NOME DA TABELA: PRODUTOS
    public partial class TelaLogado : Form
    {
        // Thread da tela de adicionar novo produto no estoque
        Thread AddProduto;

        // Variável do tipo SqlCommand para executar os cmds do BD
        SqlCommand cmdListView = new SqlCommand();

        // Conectando no banco de dados
        SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        // variáveis necessárias para pegar os dados do BD e atribuir na list view
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        // end 

        public TelaLogado()
        {
            InitializeComponent();
            EsconderBotoes();
            GerarColunas();
        }

        private void EsconderBotoes()
        {
            picture_AddProd.Hide();
            picture_Edit.Hide();
            label_AddProd.Hide();
            label_EditEstoq.Hide();
            listView_Estoque.Hide();
        }
        private void GerarColunas()
        {
            listView_Estoque.Columns.Add("ID", 50).TextAlign = HorizontalAlignment.Center;
            listView_Estoque.Columns.Add("Nome", 250).TextAlign = HorizontalAlignment.Center;
            listView_Estoque.Columns.Add("Cor", 100).TextAlign = HorizontalAlignment.Center;
            listView_Estoque.Columns.Add("Preço", 100).TextAlign = HorizontalAlignment.Center;
            listView_Estoque.Columns.Add("Quantidade", 100).TextAlign = HorizontalAlignment.Center;
        }

        private void ExibirEstoque()
        {
            listView_Estoque.Show();
            picture_AddProd.Show();
            picture_Edit.Show();
            label_AddProd.Show();
            label_EditEstoq.Show();
        }

        // Método para passar os dados do BD para a List View
        private void AdicionarItemListView()
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
                listView_Estoque.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                // temos 4 colunas (sendo uma a ID), então aqui só criamos 3, a ID vai automática
                listView_Estoque.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView_Estoque.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView_Estoque.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView_Estoque.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

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
        }

        // Imagem do "Criar novo produto"
        private void picture_AddProd_Click(object sender, EventArgs e)
        {
            AddProduto = new Thread(TelaAddProduct);
            AddProduto.SetApartmentState(ApartmentState.MTA);
            AddProduto.Start();
        }

        private void TelaAddProduct()
        {
            Application.Run(new AddProduct());
        }
    }
}
