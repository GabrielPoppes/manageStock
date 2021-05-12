using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GerenciadorDeEstoque.Apresentação;
using GerenciadorDeEstoque.Modelo;

namespace GerenciadorDeEstoque
{
    public partial class Form1 : Form
    {
        // Criando tela cadastro
        Thread TelaCadastro;
        public Form1()
        {
            InitializeComponent();
        }

        // Botão "Cadastrar"
        private void txb_register_Click(object sender, EventArgs e)
        {
            TelaCadastro = new Thread(OpenCadastro);
            TelaCadastro.SetApartmentState(ApartmentState.MTA);
            TelaCadastro.Start();
            this.Close();
        }

        // Método para abrir a tela "Cadastrar"
        public void OpenCadastro()
        {
            Application.Run(new Cadastrar());
        }

        // Botão sair
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botão entrar
        private void txb_join_Click(object sender, EventArgs e)
        {
            if (!txb_email.Text.Equals(""))
            {
                if (!txb_password.Text.Equals(""))
                {
                    Controle controle = new Controle();
                    controle.Acessar(txb_email.Text, txb_password.Text);

                    if (controle.mensagem.Equals(""))
                    {
                        if (controle.verificacao)
                        {
                            // Esconder a Form1 após o usuário validar o login
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Dados incorretos!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(controle.mensagem);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, digite uma senha!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite um e-mail!");
            }
            
        }

        // Quando altera o texto da text box senha
        private void txb_password_TextChanged(object sender, EventArgs e)
        {
            // Os caracteres da senha saem com *
            txb_password.PasswordChar = '*';
        }

        // Quando o user clica no text box senha, limpa a escrita "Senha"
        private void txb_password_Click(object sender, EventArgs e)
        {
            txb_password.Clear();
        }

        // Quando o user clica no text box E-mail, limpa a escrita "Email"
        private void txb_email_Click(object sender, EventArgs e)
        {
            txb_email.Clear();
        }
    }
}
