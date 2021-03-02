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
            Controle controle = new Controle();
            controle.Acessar(txb_email.Text, txb_password.Text);

            if (controle.mensagem.Equals(""))
            {
                if (controle.verificacao)
                {
                    
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
    }
}
