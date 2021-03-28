
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.estoqueDataSet2 = new GerenciadorDeEstoque.estoqueDataSet2();
            this.clientefisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientefisicoTableAdapter = new GerenciadorDeEstoque.estoqueDataSet2TableAdapters.clientefisicoTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientefisicoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.clientefisicoBindingSource, "idclientefisico", true));
            this.comboBox1.DataSource = this.clientefisicoBindingSource;
            this.comboBox1.DisplayMember = "idclientefisico";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(105, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "idclientefisico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // estoqueDataSet2
            // 
            this.estoqueDataSet2.DataSetName = "estoqueDataSet2";
            this.estoqueDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientefisicoBindingSource
            // 
            this.clientefisicoBindingSource.DataMember = "clientefisico";
            this.clientefisicoBindingSource.DataSource = this.estoqueDataSet2;
            // 
            // clientefisicoTableAdapter
            // 
            this.clientefisicoTableAdapter.ClearBeforeFill = true;
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 274);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditarCliente";
            this.Text = "Editar Cliente";
            this.Load += new System.EventHandler(this.EditarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientefisicoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private estoqueDataSet2 estoqueDataSet2;
        private System.Windows.Forms.BindingSource clientefisicoBindingSource;
        private estoqueDataSet2TableAdapters.clientefisicoTableAdapter clientefisicoTableAdapter;
    }
}