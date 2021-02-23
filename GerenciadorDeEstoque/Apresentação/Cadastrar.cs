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

namespace GerenciadorDeEstoque.Apresentação
{
    public partial class Cadastrar : Form
    {
        Thread TelaLogin;

        public Cadastrar()
        {
            InitializeComponent();
        }

        // Botão voltar
        private void txb_return_Click(object sender, EventArgs e)
        {
            TelaLogin = new Thread(OpenLogin);
            TelaLogin.SetApartmentState(ApartmentState.MTA);
            TelaLogin.Start();
            this.Close();
        }

        // Método para abrir a tela Login
        private void OpenLogin()
        {
            Application.Run(new TelaLogin());
        }
    }
}
