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

namespace GerenciadorDeEstoque.Apresentação.Cliente
{
    public partial class EditarCliente : Form
    {
        public EditarCliente()
        {
            InitializeComponent();
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet2.clientefisico'. Você pode movê-la ou removê-la conforme necessário.
            this.clientefisicoTableAdapter.Fill(this.estoqueDataSet2.clientefisico);

        }

        private void Nome()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select nome from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbNome.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void DataNascimento()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select datanascimento from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbDataNascimento.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void Telefone()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select telefone from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbTelefone.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void Celular()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select celular from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbCelular.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void RG()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select rg from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbRG.Text = dt.Rows[i].ItemArray[0].ToString();
            }

        }

        private void CPF()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select cpf from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbCPF.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void Endereco()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select endereco from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbEndereco.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void Email()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select email from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbEmail.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void Observacoes()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string id = Convert.ToString(txbString.Text);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select observacoes from clientefisico where idclientefisico = '{id}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbObservacoes.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void btnAlterarDados_Click(object sender, EventArgs e)
        {
            // EDITAR DADOS DO CLIENTE
            Controle controle = new Controle();
            string mensagem = controle.EditarClientes(txbString.Text, txbNome.Text, txbDataNascimento.Text, txbTelefone.Text, txbCelular.Text, txbRG.Text, txbCPF.Text, txbEndereco.Text, txbEmail.Text, txbObservacoes.Text);
            if (!txbString.Text.Equals("") && !txbNome.Text.Equals("") && !txbDataNascimento.Equals("") && !txbTelefone.Equals("") && !txbCelular.Equals("") && !txbRG.Equals("") && !txbCPF.Equals("") && !txbEndereco.Equals("") && !txbEmail.Equals("") && !txbObservacoes.Equals(""))
            {
                MessageBox.Show("Cliente editado!");
            }
        }

        private void txbString_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nome();
            DataNascimento();
            Telefone();
            Celular();
            RG();
            CPF();
            Endereco();
            Email();
            Observacoes();
        }

        private void btnRemoverProdutos_Click(object sender, EventArgs e)
        {
            // REMOVER CLIENTE
            Controle controle = new Controle();
            string mensagem = controle.RemoverClientes(txbString.Text);
            if (!txbString.Text.Equals(""))
            {
                MessageBox.Show("Cliente removido!");
            }
        }
    }
}
