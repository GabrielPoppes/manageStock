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
        Thread TelaCadastro; // Criando tela cadastro
        public Form1()
        {
            InitializeComponent();
        }

        Controle controle = new Controle(); // Instanciando a classe controle

        private void txb_register_Click(object sender, EventArgs e) // Botão "Cadastrar"
        {
            TelaCadastro = new Thread(OpenCadastro);
            TelaCadastro.SetApartmentState(ApartmentState.MTA);
            TelaCadastro.Start();
            this.Close();
        }

        public void OpenCadastro() // Método para abrir a tela "Cadastrar"
        {
            Application.Run(new Cadastrar());
        }

        private void button1_Click(object sender, EventArgs e) // Botão sair
        {
            this.Close();
        }

        private void txb_join_Click(object sender, EventArgs e) // Botão entrar
        {
            if (!txb_email.Text.Equals(""))
            {
                if (!txb_password.Text.Equals(""))
                {
                    controle.Acessar(txb_email.Text, txb_password.Text);

                    if (controle.mensagem.Equals(""))
                    {
                        if (controle.verificacao)
                        {
                            this.Hide(); // Esconder a Form1 após o usuário validar o login
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

        private void txb_password_TextChanged(object sender, EventArgs e) // Quando altera o texto da text box senha
        {
            txb_password.PasswordChar = '*'; // Os caracteres da senha saem com *
        }

        private void txb_password_Click(object sender, EventArgs e) // Quando o user clica no text box senha, limpa a escrita "Senha"
        {
            txb_password.Clear();
        }
        
        private void txb_email_Click(object sender, EventArgs e) // Quando o user clica no text box E-mail, limpa a escrita "Email"
        {
            txb_email.Clear();
        }
    }
}
