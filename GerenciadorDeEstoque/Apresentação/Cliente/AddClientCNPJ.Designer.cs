
namespace GerenciadorDeEstoque.Apresentação.Cliente
{
    partial class AddClientCNPJ
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
            this.gpbox_CNPJ = new System.Windows.Forms.GroupBox();
            this.txb_CNPJ = new System.Windows.Forms.MaskedTextBox();
            this.btn_CadastrarCliente = new System.Windows.Forms.Button();
            this.checkBox_Empresa = new System.Windows.Forms.CheckBox();
            this.txb_Celular = new System.Windows.Forms.MaskedTextBox();
            this.txb_Nome = new System.Windows.Forms.TextBox();
            this.txb_Telefone = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_Observacoes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_Email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CNPJ = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_Endereco = new System.Windows.Forms.TextBox();
            this.gpbox_CNPJ.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbox_CNPJ
            // 
            this.gpbox_CNPJ.Controls.Add(this.txb_CNPJ);
            this.gpbox_CNPJ.Controls.Add(this.btn_CadastrarCliente);
            this.gpbox_CNPJ.Controls.Add(this.checkBox_Empresa);
            this.gpbox_CNPJ.Controls.Add(this.txb_Celular);
            this.gpbox_CNPJ.Controls.Add(this.txb_Nome);
            this.gpbox_CNPJ.Controls.Add(this.txb_Telefone);
            this.gpbox_CNPJ.Controls.Add(this.label2);
            this.gpbox_CNPJ.Controls.Add(this.label10);
            this.gpbox_CNPJ.Controls.Add(this.label4);
            this.gpbox_CNPJ.Controls.Add(this.txb_Observacoes);
            this.gpbox_CNPJ.Controls.Add(this.label9);
            this.gpbox_CNPJ.Controls.Add(this.txb_Email);
            this.gpbox_CNPJ.Controls.Add(this.label8);
            this.gpbox_CNPJ.Controls.Add(this.CNPJ);
            this.gpbox_CNPJ.Controls.Add(this.label7);
            this.gpbox_CNPJ.Controls.Add(this.txb_Endereco);
            this.gpbox_CNPJ.Location = new System.Drawing.Point(12, 7);
            this.gpbox_CNPJ.Name = "gpbox_CNPJ";
            this.gpbox_CNPJ.Size = new System.Drawing.Size(776, 436);
            this.gpbox_CNPJ.TabIndex = 25;
            this.gpbox_CNPJ.TabStop = false;
            // 
            // txb_CNPJ
            // 
            this.txb_CNPJ.Location = new System.Drawing.Point(149, 147);
            this.txb_CNPJ.Mask = "000.000.000-00";
            this.txb_CNPJ.Name = "txb_CNPJ";
            this.txb_CNPJ.Size = new System.Drawing.Size(190, 20);
            this.txb_CNPJ.TabIndex = 25;
            // 
            // btn_CadastrarCliente
            // 
            this.btn_CadastrarCliente.Location = new System.Drawing.Point(35, 259);
            this.btn_CadastrarCliente.Name = "btn_CadastrarCliente";
            this.btn_CadastrarCliente.Size = new System.Drawing.Size(703, 23);
            this.btn_CadastrarCliente.TabIndex = 24;
            this.btn_CadastrarCliente.Text = "CADASTRAR CLIENTE";
            this.btn_CadastrarCliente.UseVisualStyleBackColor = true;
            // 
            // checkBox_Empresa
            // 
            this.checkBox_Empresa.AutoSize = true;
            this.checkBox_Empresa.Checked = true;
            this.checkBox_Empresa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Empresa.Location = new System.Drawing.Point(608, 96);
            this.checkBox_Empresa.Name = "checkBox_Empresa";
            this.checkBox_Empresa.Size = new System.Drawing.Size(67, 17);
            this.checkBox_Empresa.TabIndex = 23;
            this.checkBox_Empresa.Text = "Empresa";
            this.checkBox_Empresa.UseVisualStyleBackColor = true;
            // 
            // txb_Celular
            // 
            this.txb_Celular.Location = new System.Drawing.Point(436, 120);
            this.txb_Celular.Mask = "(000) 00000-0000";
            this.txb_Celular.Name = "txb_Celular";
            this.txb_Celular.Size = new System.Drawing.Size(190, 20);
            this.txb_Celular.TabIndex = 22;
            // 
            // txb_Nome
            // 
            this.txb_Nome.Location = new System.Drawing.Point(149, 94);
            this.txb_Nome.Name = "txb_Nome";
            this.txb_Nome.Size = new System.Drawing.Size(431, 20);
            this.txb_Nome.TabIndex = 2;
            // 
            // txb_Telefone
            // 
            this.txb_Telefone.Location = new System.Drawing.Point(149, 120);
            this.txb_Telefone.Mask = "(000) 0000-0000";
            this.txb_Telefone.Name = "txb_Telefone";
            this.txb_Telefone.Size = new System.Drawing.Size(190, 20);
            this.txb_Telefone.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "NOME";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "OBSERVAÇÕES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "TELEFONE";
            // 
            // txb_Observacoes
            // 
            this.txb_Observacoes.Location = new System.Drawing.Point(148, 225);
            this.txb_Observacoes.Name = "txb_Observacoes";
            this.txb_Observacoes.Size = new System.Drawing.Size(590, 20);
            this.txb_Observacoes.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "E-MAIL";
            // 
            // txb_Email
            // 
            this.txb_Email.Location = new System.Drawing.Point(148, 199);
            this.txb_Email.Name = "txb_Email";
            this.txb_Email.Size = new System.Drawing.Size(355, 20);
            this.txb_Email.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "CELULAR";
            // 
            // CNPJ
            // 
            this.CNPJ.AutoSize = true;
            this.CNPJ.Location = new System.Drawing.Point(32, 150);
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Size = new System.Drawing.Size(27, 13);
            this.CNPJ.TabIndex = 11;
            this.CNPJ.Text = "CPF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ENDEREÇO";
            // 
            // txb_Endereco
            // 
            this.txb_Endereco.Location = new System.Drawing.Point(148, 173);
            this.txb_Endereco.Name = "txb_Endereco";
            this.txb_Endereco.Size = new System.Drawing.Size(590, 20);
            this.txb_Endereco.TabIndex = 12;
            // 
            // AddClientCNPJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpbox_CNPJ);
            this.Name = "AddClientCNPJ";
            this.Text = "AddClientCNPJ";
            this.gpbox_CNPJ.ResumeLayout(false);
            this.gpbox_CNPJ.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbox_CNPJ;
        private System.Windows.Forms.MaskedTextBox txb_CNPJ;
        private System.Windows.Forms.Button btn_CadastrarCliente;
        private System.Windows.Forms.CheckBox checkBox_Empresa;
        private System.Windows.Forms.MaskedTextBox txb_Celular;
        private System.Windows.Forms.TextBox txb_Nome;
        private System.Windows.Forms.MaskedTextBox txb_Telefone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_Observacoes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_Email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label CNPJ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_Endereco;
    }
}