
namespace GerenciadorDeEstoque.Apresentação.Cliente
{
    partial class EditarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoverProdutos = new System.Windows.Forms.Button();
            this.btnAlterarDados = new System.Windows.Forms.Button();
            this.txbObservacoes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbCPF = new System.Windows.Forms.TextBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.txbRG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbCelular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTelefone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDataNascimento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbString = new System.Windows.Forms.ComboBox();
            this.clientefisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueDataSet2 = new GerenciadorDeEstoque.estoqueDataSet2();
            this.clientefisicoTableAdapter = new GerenciadorDeEstoque.estoqueDataSet2TableAdapters.clientefisicoTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientefisicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoverProdutos);
            this.groupBox1.Controls.Add(this.btnAlterarDados);
            this.groupBox1.Controls.Add(this.txbObservacoes);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txbEmail);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txbEndereco);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txbCPF);
            this.groupBox1.Controls.Add(this.labelCPF);
            this.groupBox1.Controls.Add(this.txbRG);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbCelular);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbTelefone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbDataNascimento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbNome);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbString);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // btnRemoverProdutos
            // 
            this.btnRemoverProdutos.Location = new System.Drawing.Point(381, 177);
            this.btnRemoverProdutos.Name = "btnRemoverProdutos";
            this.btnRemoverProdutos.Size = new System.Drawing.Size(130, 23);
            this.btnRemoverProdutos.TabIndex = 21;
            this.btnRemoverProdutos.Text = "REMOVER CLIENTE";
            this.btnRemoverProdutos.UseVisualStyleBackColor = true;
            this.btnRemoverProdutos.Click += new System.EventHandler(this.btnRemoverProdutos_Click);
            // 
            // btnAlterarDados
            // 
            this.btnAlterarDados.Location = new System.Drawing.Point(158, 177);
            this.btnAlterarDados.Name = "btnAlterarDados";
            this.btnAlterarDados.Size = new System.Drawing.Size(215, 23);
            this.btnAlterarDados.TabIndex = 20;
            this.btnAlterarDados.Text = "ALTERAR DADOS";
            this.btnAlterarDados.UseVisualStyleBackColor = true;
            this.btnAlterarDados.Click += new System.EventHandler(this.btnAlterarDados_Click);
            // 
            // txbObservacoes
            // 
            this.txbObservacoes.Location = new System.Drawing.Point(82, 140);
            this.txbObservacoes.Name = "txbObservacoes";
            this.txbObservacoes.Size = new System.Drawing.Size(662, 20);
            this.txbObservacoes.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Observações";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(400, 87);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(344, 20);
            this.txbEmail.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "E-mail";
            // 
            // txbEndereco
            // 
            this.txbEndereco.Location = new System.Drawing.Point(82, 112);
            this.txbEndereco.Name = "txbEndereco";
            this.txbEndereco.Size = new System.Drawing.Size(662, 20);
            this.txbEndereco.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Endereço";
            // 
            // txbCPF
            // 
            this.txbCPF.Location = new System.Drawing.Point(82, 86);
            this.txbCPF.Name = "txbCPF";
            this.txbCPF.Size = new System.Drawing.Size(250, 20);
            this.txbCPF.TabIndex = 13;
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Location = new System.Drawing.Point(6, 89);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(59, 13);
            this.labelCPF.TabIndex = 12;
            this.labelCPF.Text = "CPF/CNPJ";
            // 
            // txbRG
            // 
            this.txbRG.Location = new System.Drawing.Point(517, 61);
            this.txbRG.Name = "txbRG";
            this.txbRG.Size = new System.Drawing.Size(227, 20);
            this.txbRG.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(488, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "RG";
            // 
            // txbCelular
            // 
            this.txbCelular.Location = new System.Drawing.Point(278, 61);
            this.txbCelular.Name = "txbCelular";
            this.txbCelular.Size = new System.Drawing.Size(184, 20);
            this.txbCelular.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Celular";
            // 
            // txbTelefone
            // 
            this.txbTelefone.Location = new System.Drawing.Point(82, 61);
            this.txbTelefone.Name = "txbTelefone";
            this.txbTelefone.Size = new System.Drawing.Size(131, 20);
            this.txbTelefone.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefone";
            // 
            // txbDataNascimento
            // 
            this.txbDataNascimento.Location = new System.Drawing.Point(626, 36);
            this.txbDataNascimento.Name = "txbDataNascimento";
            this.txbDataNascimento.Size = new System.Drawing.Size(118, 20);
            this.txbDataNascimento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data de nascimento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(194, 35);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(309, 20);
            this.txbNome.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // txbString
            // 
            this.txbString.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientefisicoBindingSource, "idclientefisico", true));
            this.txbString.DataSource = this.clientefisicoBindingSource;
            this.txbString.DisplayMember = "idclientefisico";
            this.txbString.FormattingEnabled = true;
            this.txbString.Location = new System.Drawing.Point(82, 34);
            this.txbString.Name = "txbString";
            this.txbString.Size = new System.Drawing.Size(56, 21);
            this.txbString.TabIndex = 0;
            this.txbString.ValueMember = "idclientefisico";
            this.txbString.SelectedIndexChanged += new System.EventHandler(this.txbString_SelectedIndexChanged);
            // 
            // clientefisicoBindingSource
            // 
            this.clientefisicoBindingSource.DataMember = "clientefisico";
            this.clientefisicoBindingSource.DataSource = this.estoqueDataSet2;
            // 
            // estoqueDataSet2
            // 
            this.estoqueDataSet2.DataSetName = "estoqueDataSet2";
            this.estoqueDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientefisicoTableAdapter
            // 
            this.clientefisicoTableAdapter.ClearBeforeFill = true;
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 246);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Cliente";
            this.Load += new System.EventHandler(this.EditarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientefisicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private estoqueDataSet2 estoqueDataSet2;
        private System.Windows.Forms.BindingSource clientefisicoBindingSource;
        private estoqueDataSet2TableAdapters.clientefisicoTableAdapter clientefisicoTableAdapter;
        private System.Windows.Forms.Button btnRemoverProdutos;
        private System.Windows.Forms.Button btnAlterarDados;
        private System.Windows.Forms.TextBox txbObservacoes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbCPF;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.TextBox txbRG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbCelular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDataNascimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNome;
        public System.Windows.Forms.ComboBox txbString;
    }
}