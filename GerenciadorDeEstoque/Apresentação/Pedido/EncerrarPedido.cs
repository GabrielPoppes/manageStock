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

namespace GerenciadorDeEstoque.Apresentação.Pedido
{
    public partial class EncerrarPedido : Form
    {
        public EncerrarPedido()
        {
            InitializeComponent();
        }

        private void CheckarCheckedBox()
        {
            if(checkBox_Pago.Checked == true)
            {
                checkBox_Cancelado.Checked = false;
            }

            if(checkBox_Cancelado.Checked == true)
            {
                checkBox_Cancelado.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.CadastrarPedidoEstado(txb_Id.Text, checkBox_Pago.Checked, checkBox_Cancelado.Checked);

            if (controle.verificacao)
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }

            else
            {
                MessageBox.Show("Erro ao realizar o cadastro!");
            }

        }
    }
}
