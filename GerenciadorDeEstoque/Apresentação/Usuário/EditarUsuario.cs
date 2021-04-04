﻿using GerenciadorDeEstoque.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEstoque.Apresentação.Usuário
{
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
            InitializeComponent();
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet3.funcionario'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionarioTableAdapter.Fill(this.estoqueDataSet3.funcionario);

        }

        // Botão para editar o usuário
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.EditarUsuarios(comboBox_Produto.Text, txbEmail.Text, txbCelular.Text);
            if (!comboBox_Produto.Text.Equals("") && !txbEmail.Text.Equals("") && !txbCelular.Text.Equals(""))
            {
                MessageBox.Show("Usuário editado com sucesso!");
            }
        }

        // Método para exibir na list view o e-mail do usuário
        private void EmailUsuario()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string nome = Convert.ToString(comboBox_Produto.SelectedValue);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select email from funcionario where nome = '{nome}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbEmail.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        // Método para exibir na list view o e-mail do usuário
        private void CelularUsuario()
        {
            SqlDataAdapter da;
            DataSet ds;

            // Conectar com o BD
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = estoque; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            // Abrindo a conexão
            con.Open();

            // Criei a string nome, e estou convertendo o nome do produto selecionado pelo usuário na ComboBox para String
            string nome = Convert.ToString(comboBox_Produto.SelectedValue);

            // Variável do tipo SqlCOmmand para executar os cmds do BD
            SqlCommand cmdComboBox = new SqlCommand($"select celular from funcionario where nome = '{nome}';", con);

            da = new SqlDataAdapter(cmdComboBox);
            ds = new DataSet();
            DataTable dt = new DataTable();

            da.Fill(ds, "estoque");
            con.Close();

            dt = ds.Tables["estoque"];


            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                txbCelular.Text = dt.Rows[i].ItemArray[0].ToString();
            }
        }

        private void comboBox_Produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmailUsuario();
            CelularUsuario();
        }
    }
}
