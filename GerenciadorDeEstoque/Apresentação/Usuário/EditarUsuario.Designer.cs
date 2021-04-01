
namespace GerenciadorDeEstoque.Apresentação.Usuário
{
    partial class EditarUsuario
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
            this.gpBoxEditUsuario = new System.Windows.Forms.GroupBox();
            this.comboBox_Produto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.estoqueDataSet3 = new GerenciadorDeEstoque.estoqueDataSet3();
            this.funcionarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionarioTableAdapter = new GerenciadorDeEstoque.estoqueDataSet3TableAdapters.funcionarioTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gpBoxEditUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gpBoxEditUsuario
            // 
            this.gpBoxEditUsuario.Controls.Add(this.button1);
            this.gpBoxEditUsuario.Controls.Add(this.textBox2);
            this.gpBoxEditUsuario.Controls.Add(this.label3);
            this.gpBoxEditUsuario.Controls.Add(this.textBox1);
            this.gpBoxEditUsuario.Controls.Add(this.label2);
            this.gpBoxEditUsuario.Controls.Add(this.label1);
            this.gpBoxEditUsuario.Controls.Add(this.comboBox_Produto);
            this.gpBoxEditUsuario.Location = new System.Drawing.Point(12, 12);
            this.gpBoxEditUsuario.Name = "gpBoxEditUsuario";
            this.gpBoxEditUsuario.Size = new System.Drawing.Size(406, 191);
            this.gpBoxEditUsuario.TabIndex = 0;
            this.gpBoxEditUsuario.TabStop = false;
            // 
            // comboBox_Produto
            // 
            this.comboBox_Produto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.funcionarioBindingSource, "nome", true));
            this.comboBox_Produto.DataSource = this.funcionarioBindingSource;
            this.comboBox_Produto.DisplayMember = "nome";
            this.comboBox_Produto.FormattingEnabled = true;
            this.comboBox_Produto.Location = new System.Drawing.Point(99, 32);
            this.comboBox_Produto.Name = "comboBox_Produto";
            this.comboBox_Produto.Size = new System.Drawing.Size(235, 21);
            this.comboBox_Produto.TabIndex = 4;
            this.comboBox_Produto.ValueMember = "nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome";
            // 
            // estoqueDataSet3
            // 
            this.estoqueDataSet3.DataSetName = "estoqueDataSet3";
            this.estoqueDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // funcionarioBindingSource
            // 
            this.funcionarioBindingSource.DataMember = "funcionario";
            this.funcionarioBindingSource.DataSource = this.estoqueDataSet3;
            // 
            // funcionarioTableAdapter
            // 
            this.funcionarioTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "E-mail:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 103);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(235, 20);
            this.textBox2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Celular:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "EDITAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 221);
            this.Controls.Add(this.gpBoxEditUsuario);
            this.Name = "EditarUsuario";
            this.Text = "EditarUsuario";
            this.Load += new System.EventHandler(this.EditarUsuario_Load);
            this.gpBoxEditUsuario.ResumeLayout(false);
            this.gpBoxEditUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBoxEditUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Produto;
        private estoqueDataSet3 estoqueDataSet3;
        private System.Windows.Forms.BindingSource funcionarioBindingSource;
        private estoqueDataSet3TableAdapters.funcionarioTableAdapter funcionarioTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}