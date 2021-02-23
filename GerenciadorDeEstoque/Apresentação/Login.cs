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

namespace GerenciadorDeEstoque
{
    public partial class TelaLogin : Form
    {
        // Criando tela cadastro
        Thread TelaCadastro;
        public TelaLogin()
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
    }
}
