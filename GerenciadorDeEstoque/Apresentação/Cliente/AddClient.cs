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

        private void NotificacaoM(string elemento)
        {
            MessageBox.Show($"Por favor, preencha o {elemento}");
        }

        private void NotificacaoF(string elemento)
        {
            MessageBox.Show($"Por favor, preencha a {elemento}");
        }

        // Botão Cadastrar cliente novo
        private void btn_CadastrarCliente_Click(object sender, EventArgs e)
        {
            if (!txb_Nome.Text.Equals(""))
            {
                if (!txb_DataNascimento.Text.Equals(""))
                {
                    if (!txb_Telefone.Text.Equals(""))
                    {
                        if (!txb_Celular.Text.Equals(""))
                        {
                            if (!txb_RG.Text.Equals(""))
                            {
                                if (!txb_CPF.Text.Equals(""))
                                {
                                    if (!txb_Endereco.Text.Equals(""))
                                    {
                                        if (!txb_Email.Text.Equals(""))
                                        {
                                            Controle controle = new Controle();
                                            string mensagem = controle.CadastrarClientesFisico(txb_Nome.Text, txb_DataNascimento.Text, txb_Telefone.Text, txb_Celular.Text, txb_RG.Text, txb_CPF.Text, txb_Endereco.Text, txb_Email.Text, txb_Observacoes.Text);
                                            MessageBox.Show("Cliente cadastrado!");
                                            LimparCamposClienteNovo();
                                        }
                                        else
                                        {
                                            NotificacaoM("e-mail");
                                        }
                                    }
                                    else
                                    {
                                        NotificacaoM("endereço");
                                    }
                                }
                                else
                                {
                                    NotificacaoM("CPF");
                                }
                            }
                            else
                            {
                                NotificacaoM("RG");
                            }
                        }
                        else
                        {
                            NotificacaoM("celular");
                        }
                    }
                    else
                    {
                        NotificacaoM("telefone");
                    }
                }
                else
                {
                    NotificacaoF("data de nascimento");
                }
            }
            else
            {
                NotificacaoM("nome");
            }
        }
    }
}
