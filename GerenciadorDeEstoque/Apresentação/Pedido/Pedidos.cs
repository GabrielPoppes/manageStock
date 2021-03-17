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

namespace GerenciadorDeEstoque.Apresentação.Pedido
{
    public partial class Pedidos : Form
    {
        public Pedidos()
        {
            InitializeComponent();
            AdicionarItemComboBoxQnt();
        }

        private void ComboBoxFormaPgmt()
        {
            comboBox_FormaPgt.Items.Add("Dinheiro");
            comboBox_FormaPgt.Items.Add("Cartão");
            comboBox_FormaPgt.Items.Add("Boleto");
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'nomeClientes.funcionario'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionarioTableAdapter.Fill(this.nomeClientes.funcionario);
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.estoqueDataSet.produtos);
        }



        private void AdicionarItemComboBoxQnt()
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

        private void comboBox_Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdicionarItemComboBoxQnt();
        }

    }
}
