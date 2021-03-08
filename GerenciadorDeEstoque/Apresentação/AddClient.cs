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

        private void checkBox_Empresa_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Empresa.Checked == true)
            {
                gpbox_PessoaFisica.Hide();
            }

            if(checkBox_Empresa.Checked == false)
            {
                gpbox_PessoaFisica.Show();
            }
        }
    }
}
