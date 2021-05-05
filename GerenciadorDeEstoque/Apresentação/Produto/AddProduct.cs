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

namespace GerenciadorDeEstoque.Apresentação
{
    public partial class AddProduct : Form
    {

        public AddProduct()
        {
            InitializeComponent();
        }

        public void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.CadastrarProdutos(txb_NomeProduto.Text, txb_Cor.Text, txb_Preco.Text, txb_Quantidade.Text);
            if (!txb_NomeProduto.Text.Equals("") && !txb_Preco.Equals("") && !txb_Quantidade.Equals(""))
            {
                MessageBox.Show("Produto cadastrado!");
            }
        }
    }
}
