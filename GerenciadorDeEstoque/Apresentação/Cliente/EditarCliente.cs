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
    public partial class EditarCliente : Form
    {
        public EditarCliente()
        {
            InitializeComponent();
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet2.clientefisico'. Você pode movê-la ou removê-la conforme necessário.
            this.clientefisicoTableAdapter.Fill(this.estoqueDataSet2.clientefisico);

        }
    }
}
