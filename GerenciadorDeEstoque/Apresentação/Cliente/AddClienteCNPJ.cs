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

namespace GerenciadorDeEstoque.Apresentação.Cliente
{
    public partial class AddClienteCNPJ : Form
    {
        public AddClienteCNPJ()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.CadastrarClientesJuridicos(txb_NomeCNPJ.Text, txb_telefoneCNPJ.Text, txb_celularCNPJ.Text, txb_CNPJ.Text, txb_endereco.Text, txb_email.Text, txb_observacoes.Text);
            if (!txb_NomeCNPJ.Text.Equals("") && !txb_telefoneCNPJ.Equals("") && !txb_celularCNPJ.Equals("") && !txb_CNPJ.Equals("") && !txb_endereco.Equals("") && !txb_email.Equals("") && !txb_observacoes.Equals(""))
            {
                MessageBox.Show("Cliente cadastrado!");
            }
        }
    }
}
