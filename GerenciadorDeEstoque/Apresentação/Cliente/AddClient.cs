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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
            // Tela pessoa jurídica começa escondida
            gpbox_CNPJ.Hide();
        }
        
        

        // Método para limpar os campos do cadastro após criar o cadastro do cliente
        private void LimparCamposClienteNovo()
        {
            txb_Nome.Clear();
            txb_DataNascimento.Clear();
            txb_Telefone.Clear();
            txb_Telefone.Clear();
            txb_Celular.Clear();
            txb_RG.Clear();
            txb_CPF.Clear();
            txb_Endereco.Clear();
            txb_Email.Clear();
            txb_Observacoes.Clear();
        }

        // Botão Cadastrar cliente novo
        private void btn_CadastrarCliente_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.CadastrarClientesFisico(txb_Nome.Text, txb_DataNascimento.Text, txb_Telefone.Text, txb_Celular.Text, txb_RG.Text, txb_CPF.Text, txb_Endereco.Text, txb_Email.Text, txb_Observacoes.Text);
            if (!txb_Nome.Text.Equals("") && !txb_DataNascimento.Equals("") && !txb_Telefone.Equals("") && !txb_Celular.Equals("") && !txb_RG.Equals("") && !txb_CPF.Equals("") && !txb_Endereco.Equals("") && !txb_Email.Equals("") && !txb_Observacoes.Equals(""))
            {
                MessageBox.Show("Cliente cadastrado!");
                LimparCamposClienteNovo();
            }
        }

        // Checar se está selecionado pessoa física ou jurídica
        // Checked Tela Pessoa física
        private void checkBox_Empresa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Empresa.Checked == true)
            {
                gpbox_PessoaFisica.Hide();
                gpbox_CNPJ.Show();
                checkBox_Tipo.Checked = true;
            }

        }
    }
}
