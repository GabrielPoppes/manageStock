using GerenciadorDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEstoque.Apresentação
{
    public partial class EditarProduto : Form
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        // ADICIONAR QUANTIDADE DO PRODUTO
        private void btn_AddQnt_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.EditarProdutos(txb_idProduto.Text, txb_Quantidade.Text);
            if (!txb_idProduto.Text.Equals("") && !txb_Quantidade.Equals(""))
            {
                MessageBox.Show("Produto editado!");
            }
        }

        // REMOVER QUANTIDADE DO PRODUTO
        private void btn_rmvQnt_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.EditarProdutosRemvQnt(txb_idProduto.Text, txb_Quantidade.Text);
            if (!txb_idProduto.Text.Equals("") && !txb_Quantidade.Equals(""))
            {
                MessageBox.Show("Produto editado!");
            }
        }
    }
}
