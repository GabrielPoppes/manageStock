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
    public partial class TelaLogado : Form
    {
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
            listView_Estoque.Columns.Add("Produto", 250).TextAlign = HorizontalAlignment.Center;
            listView_Estoque.Columns.Add("Quantidade", 100).TextAlign = HorizontalAlignment.Center;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picture_AddProd.Show();
            picture_Edit.Show();
            label_EditEstoq.Show();
            label_AddProd.Show();
            listView_Estoque.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
