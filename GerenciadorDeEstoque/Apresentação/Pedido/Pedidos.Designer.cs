
namespace GerenciadorDeEstoque.Apresentação.Pedido
{
    partial class Pedidos
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
            this.txbQnt = new System.Windows.Forms.TextBox();
            this.txb_QntEstoque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbValorTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listView_Pedidos = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_FormaPgt = new System.Windows.Forms.ComboBox();
            this.label_formPagt = new System.Windows.Forms.Label();
            this.comboBox_Cliente = new System.Windows.Forms.ComboBox();
            this.funcionarioBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.nomeClientes = new GerenciadorDeEstoque.NomeClientes();
            this.funcionarioBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_Produto = new System.Windows.Forms.ComboBox();
            this.produtosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueDataSet = new GerenciadorDeEstoque.estoqueDataSet();
            this.produtosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_cliente = new System.Windows.Forms.Label();
            this.label_Qnt = new System.Windows.Forms.Label();
            this.label_Produto = new System.Windows.Forms.Label();
            this.produtosBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.produtosTableAdapter = new GerenciadorDeEstoque.estoqueDataSetTableAdapters.produtosTableAdapter();
            this.produtosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.produtosBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtosBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.produtosBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.funcionarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionarioTableAdapter = new GerenciadorDeEstoque.NomeClientesTableAdapters.funcionarioTableAdapter();
            this.nomeClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.funcionarioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txbValorPorUnidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbValorPorUnidade);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbQnt);
            this.groupBox1.Controls.Add(this.txb_QntEstoque);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbValorTotal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listView_Pedidos);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox_FormaPgt);
            this.groupBox1.Controls.Add(this.label_formPagt);
            this.groupBox1.Controls.Add(this.comboBox_Cliente);
            this.groupBox1.Controls.Add(this.comboBox_Produto);
            this.groupBox1.Controls.Add(this.label_cliente);
            this.groupBox1.Controls.Add(this.label_Qnt);
            this.groupBox1.Controls.Add(this.label_Produto);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txbQnt
            // 
            this.txbQnt.Location = new System.Drawing.Point(657, 23);
            this.txbQnt.Name = "txbQnt";
            this.txbQnt.Size = new System.Drawing.Size(148, 20);
            this.txbQnt.TabIndex = 19;
            this.txbQnt.TextChanged += new System.EventHandler(this.txbQnt_TextChanged);
            // 
            // txb_QntEstoque
            // 
            this.txb_QntEstoque.Location = new System.Drawing.Point(438, 23);
            this.txb_QntEstoque.Name = "txb_QntEstoque";
            this.txb_QntEstoque.ReadOnly = true;
            this.txb_QntEstoque.Size = new System.Drawing.Size(100, 20);
            this.txb_QntEstoque.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Quantidade em estoque";
            // 
            // txbValorTotal
            // 
            this.txbValorTotal.Location = new System.Drawing.Point(670, 75);
            this.txbValorTotal.Name = "txbValorTotal";
            this.txbValorTotal.ReadOnly = true;
            this.txbValorTotal.Size = new System.Drawing.Size(135, 20);
            this.txbValorTotal.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(612, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "TOTAL R$:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(506, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "APLICAR DESCONTO";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(446, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Desconto %";
            // 
            // listView_Pedidos
            // 
            this.listView_Pedidos.HideSelection = false;
            this.listView_Pedidos.Location = new System.Drawing.Point(24, 139);
            this.listView_Pedidos.Name = "listView_Pedidos";
            this.listView_Pedidos.Size = new System.Drawing.Size(781, 236);
            this.listView_Pedidos.TabIndex = 9;
            this.listView_Pedidos.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(781, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "INSERIR ITENS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox_FormaPgt
            // 
            this.comboBox_FormaPgt.FormattingEnabled = true;
            this.comboBox_FormaPgt.Items.AddRange(new object[] {
            "Dinheiro",
            "Cartão",
            "Boleto"});
            this.comboBox_FormaPgt.Location = new System.Drawing.Point(129, 75);
            this.comboBox_FormaPgt.Name = "comboBox_FormaPgt";
            this.comboBox_FormaPgt.Size = new System.Drawing.Size(148, 21);
            this.comboBox_FormaPgt.TabIndex = 7;
            this.comboBox_FormaPgt.Text = "Selecione";
            // 
            // label_formPagt
            // 
            this.label_formPagt.AutoSize = true;
            this.label_formPagt.Location = new System.Drawing.Point(21, 78);
            this.label_formPagt.Name = "label_formPagt";
            this.label_formPagt.Size = new System.Drawing.Size(107, 13);
            this.label_formPagt.TabIndex = 6;
            this.label_formPagt.Text = "Forma de pagamento";
            // 
            // comboBox_Cliente
            // 
            this.comboBox_Cliente.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.funcionarioBindingSource2, "nome", true));
            this.comboBox_Cliente.DataSource = this.funcionarioBindingSource3;
            this.comboBox_Cliente.DisplayMember = "nome";
            this.comboBox_Cliente.FormattingEnabled = true;
            this.comboBox_Cliente.Location = new System.Drawing.Point(71, 47);
            this.comboBox_Cliente.Name = "comboBox_Cliente";
            this.comboBox_Cliente.Size = new System.Drawing.Size(467, 21);
            this.comboBox_Cliente.TabIndex = 5;
            this.comboBox_Cliente.ValueMember = "nome";
            // 
            // funcionarioBindingSource2
            // 
            this.funcionarioBindingSource2.DataMember = "funcionario";
            this.funcionarioBindingSource2.DataSource = this.nomeClientes;
            // 
            // nomeClientes
            // 
            this.nomeClientes.DataSetName = "NomeClientes";
            this.nomeClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // funcionarioBindingSource3
            // 
            this.funcionarioBindingSource3.DataMember = "funcionario";
            this.funcionarioBindingSource3.DataSource = this.nomeClientes;
            // 
            // comboBox_Produto
            // 
            this.comboBox_Produto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtosBindingSource1, "nome", true));
            this.comboBox_Produto.DataSource = this.produtosBindingSource;
            this.comboBox_Produto.DisplayMember = "nome";
            this.comboBox_Produto.FormattingEnabled = true;
            this.comboBox_Produto.Location = new System.Drawing.Point(71, 23);
            this.comboBox_Produto.Name = "comboBox_Produto";
            this.comboBox_Produto.Size = new System.Drawing.Size(235, 21);
            this.comboBox_Produto.TabIndex = 3;
            this.comboBox_Produto.ValueMember = "nome";
            this.comboBox_Produto.SelectedIndexChanged += new System.EventHandler(this.comboBox_Produto_SelectedIndexChanged);
            // 
            // produtosBindingSource1
            // 
            this.produtosBindingSource1.DataMember = "produtos";
            this.produtosBindingSource1.DataSource = this.estoqueDataSet;
            // 
            // estoqueDataSet
            // 
            this.estoqueDataSet.DataSetName = "estoqueDataSet";
            this.estoqueDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtosBindingSource
            // 
            this.produtosBindingSource.DataMember = "produtos";
            this.produtosBindingSource.DataSource = this.estoqueDataSet;
            // 
            // label_cliente
            // 
            this.label_cliente.AutoSize = true;
            this.label_cliente.Location = new System.Drawing.Point(21, 50);
            this.label_cliente.Name = "label_cliente";
            this.label_cliente.Size = new System.Drawing.Size(39, 13);
            this.label_cliente.TabIndex = 2;
            this.label_cliente.Text = "Cliente";
            // 
            // label_Qnt
            // 
            this.label_Qnt.AutoSize = true;
            this.label_Qnt.Location = new System.Drawing.Point(548, 25);
            this.label_Qnt.Name = "label_Qnt";
            this.label_Qnt.Size = new System.Drawing.Size(112, 13);
            this.label_Qnt.TabIndex = 1;
            this.label_Qnt.Text = "Quantidade do pedido";
            // 
            // label_Produto
            // 
            this.label_Produto.AutoSize = true;
            this.label_Produto.Location = new System.Drawing.Point(21, 26);
            this.label_Produto.Name = "label_Produto";
            this.label_Produto.Size = new System.Drawing.Size(44, 13);
            this.label_Produto.TabIndex = 0;
            this.label_Produto.Text = "Produto";
            // 
            // produtosBindingSource5
            // 
            this.produtosBindingSource5.DataMember = "produtos";
            this.produtosBindingSource5.DataSource = this.estoqueDataSet;
            // 
            // produtosTableAdapter
            // 
            this.produtosTableAdapter.ClearBeforeFill = true;
            // 
            // produtosBindingSource2
            // 
            this.produtosBindingSource2.DataMember = "produtos";
            this.produtosBindingSource2.DataSource = this.estoqueDataSet;
            // 
            // produtosBindingSource3
            // 
            this.produtosBindingSource3.DataMember = "produtos";
            this.produtosBindingSource3.DataSource = this.estoqueDataSet;
            // 
            // estoqueDataSetBindingSource
            // 
            this.estoqueDataSetBindingSource.DataSource = this.estoqueDataSet;
            this.estoqueDataSetBindingSource.Position = 0;
            // 
            // produtosBindingSource4
            // 
            this.produtosBindingSource4.DataMember = "produtos";
            this.produtosBindingSource4.DataSource = this.estoqueDataSetBindingSource;
            // 
            // produtosBindingSource6
            // 
            this.produtosBindingSource6.DataMember = "produtos";
            this.produtosBindingSource6.DataSource = this.estoqueDataSet;
            // 
            // funcionarioBindingSource
            // 
            this.funcionarioBindingSource.DataMember = "funcionario";
            this.funcionarioBindingSource.DataSource = this.nomeClientes;
            // 
            // funcionarioTableAdapter
            // 
            this.funcionarioTableAdapter.ClearBeforeFill = true;
            // 
            // nomeClientesBindingSource
            // 
            this.nomeClientesBindingSource.DataSource = this.nomeClientes;
            this.nomeClientesBindingSource.Position = 0;
            // 
            // funcionarioBindingSource1
            // 
            this.funcionarioBindingSource1.DataMember = "funcionario";
            this.funcionarioBindingSource1.DataSource = this.nomeClientesBindingSource;
            // 
            // txbValorPorUnidade
            // 
            this.txbValorPorUnidade.Location = new System.Drawing.Point(657, 48);
            this.txbValorPorUnidade.Name = "txbValorPorUnidade";
            this.txbValorPorUnidade.ReadOnly = true;
            this.txbValorPorUnidade.Size = new System.Drawing.Size(148, 20);
            this.txbValorPorUnidade.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Valor por unidade";
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomeClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionarioBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbValorTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView_Pedidos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_FormaPgt;
        private System.Windows.Forms.Label label_formPagt;
        private System.Windows.Forms.ComboBox comboBox_Cliente;
        private System.Windows.Forms.ComboBox comboBox_Produto;
        private System.Windows.Forms.Label label_cliente;
        private System.Windows.Forms.Label label_Qnt;
        private System.Windows.Forms.Label label_Produto;
        private estoqueDataSet estoqueDataSet;
        private System.Windows.Forms.BindingSource produtosBindingSource;
        private estoqueDataSetTableAdapters.produtosTableAdapter produtosTableAdapter;
        private System.Windows.Forms.BindingSource produtosBindingSource1;
        private System.Windows.Forms.BindingSource produtosBindingSource3;
        private System.Windows.Forms.BindingSource produtosBindingSource2;
        private System.Windows.Forms.BindingSource produtosBindingSource5;
        private System.Windows.Forms.BindingSource estoqueDataSetBindingSource;
        private System.Windows.Forms.BindingSource produtosBindingSource4;
        private System.Windows.Forms.TextBox txb_QntEstoque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbQnt;
        private System.Windows.Forms.BindingSource produtosBindingSource6;
        private NomeClientes nomeClientes;
        private System.Windows.Forms.BindingSource funcionarioBindingSource;
        private NomeClientesTableAdapters.funcionarioTableAdapter funcionarioTableAdapter;
        private System.Windows.Forms.BindingSource funcionarioBindingSource2;
        private System.Windows.Forms.BindingSource funcionarioBindingSource3;
        private System.Windows.Forms.BindingSource nomeClientesBindingSource;
        private System.Windows.Forms.BindingSource funcionarioBindingSource1;
        private System.Windows.Forms.TextBox txbValorPorUnidade;
        private System.Windows.Forms.Label label2;
    }
}