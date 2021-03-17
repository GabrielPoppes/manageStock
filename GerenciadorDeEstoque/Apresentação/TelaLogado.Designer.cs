
namespace GerenciadorDeEstoque.Apresentação
{
    partial class TelaLogado
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_pedido = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImg_Cliente = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_AddProd = new System.Windows.Forms.Label();
            this.listView_Cliente = new System.Windows.Forms.ListView();
            this.label_EditEstoq = new System.Windows.Forms.Label();
            this.btn_AtualizarLista = new System.Windows.Forms.Button();
            this.gpb_Estoque = new System.Windows.Forms.GroupBox();
            this.gpb_Cliente = new System.Windows.Forms.GroupBox();
            this.btn_atualizarlistaClientes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_NovoCliente = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView_Clientes = new System.Windows.Forms.ListView();
            this.picture_AddProd = new System.Windows.Forms.PictureBox();
            this.picture_Edit = new System.Windows.Forms.PictureBox();
            this.groupBox_pedidos = new System.Windows.Forms.GroupBox();
            this.btn_criarPedido = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listView_Pedido = new System.Windows.Forms.ListView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImg_Cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gpb_Estoque.SuspendLayout();
            this.gpb_Cliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_NovoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_AddProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edit)).BeginInit();
            this.groupBox_pedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_criarPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btn_pedido);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnImg_Cliente);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(1, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 424);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pedido";
            // 
            // btn_pedido
            // 
            this.btn_pedido.Image = global::GerenciadorDeEstoque.Properties.Resources._3688519_128;
            this.btn_pedido.Location = new System.Drawing.Point(8, 185);
            this.btn_pedido.Name = "btn_pedido";
            this.btn_pedido.Size = new System.Drawing.Size(100, 65);
            this.btn_pedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_pedido.TabIndex = 4;
            this.btn_pedido.TabStop = false;
            this.btn_pedido.Click += new System.EventHandler(this.btn_pedido_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente";
            // 
            // btnImg_Cliente
            // 
            this.btnImg_Cliente.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_User_Customers_1218712;
            this.btnImg_Cliente.Location = new System.Drawing.Point(8, 104);
            this.btnImg_Cliente.Name = "btnImg_Cliente";
            this.btnImg_Cliente.Size = new System.Drawing.Size(100, 65);
            this.btnImg_Cliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImg_Cliente.TabIndex = 2;
            this.btnImg_Cliente.TabStop = false;
            this.btnImg_Cliente.Click += new System.EventHandler(this.btnImg_Cliente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estoque";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_kthememgr_7240;
            this.pictureBox1.Location = new System.Drawing.Point(8, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // label_AddProd
            // 
            this.label_AddProd.AutoSize = true;
            this.label_AddProd.Location = new System.Drawing.Point(27, 82);
            this.label_AddProd.Name = "label_AddProd";
            this.label_AddProd.Size = new System.Drawing.Size(72, 13);
            this.label_AddProd.TabIndex = 2;
            this.label_AddProd.Text = "Novo produto";
            // 
            // listView_Cliente
            // 
            this.listView_Cliente.HideSelection = false;
            this.listView_Cliente.Location = new System.Drawing.Point(16, 106);
            this.listView_Cliente.Name = "listView_Cliente";
            this.listView_Cliente.Size = new System.Drawing.Size(1013, 488);
            this.listView_Cliente.TabIndex = 5;
            this.listView_Cliente.UseCompatibleStateImageBehavior = false;
            this.listView_Cliente.View = System.Windows.Forms.View.Details;
            // 
            // label_EditEstoq
            // 
            this.label_EditEstoq.AutoSize = true;
            this.label_EditEstoq.Location = new System.Drawing.Point(120, 82);
            this.label_EditEstoq.Name = "label_EditEstoq";
            this.label_EditEstoq.Size = new System.Drawing.Size(73, 13);
            this.label_EditEstoq.TabIndex = 6;
            this.label_EditEstoq.Text = "Editar produto";
            // 
            // btn_AtualizarLista
            // 
            this.btn_AtualizarLista.Location = new System.Drawing.Point(544, 72);
            this.btn_AtualizarLista.Name = "btn_AtualizarLista";
            this.btn_AtualizarLista.Size = new System.Drawing.Size(103, 23);
            this.btn_AtualizarLista.TabIndex = 7;
            this.btn_AtualizarLista.Text = "Atualizar lista";
            this.btn_AtualizarLista.UseVisualStyleBackColor = true;
            this.btn_AtualizarLista.Click += new System.EventHandler(this.btn_AtualizarLista_Click);
            // 
            // gpb_Estoque
            // 
            this.gpb_Estoque.Controls.Add(this.gpb_Cliente);
            this.gpb_Estoque.Controls.Add(this.listView_Cliente);
            this.gpb_Estoque.Controls.Add(this.btn_AtualizarLista);
            this.gpb_Estoque.Controls.Add(this.picture_AddProd);
            this.gpb_Estoque.Controls.Add(this.label_EditEstoq);
            this.gpb_Estoque.Controls.Add(this.label_AddProd);
            this.gpb_Estoque.Controls.Add(this.picture_Edit);
            this.gpb_Estoque.Location = new System.Drawing.Point(126, -9);
            this.gpb_Estoque.Name = "gpb_Estoque";
            this.gpb_Estoque.Size = new System.Drawing.Size(1041, 634);
            this.gpb_Estoque.TabIndex = 8;
            this.gpb_Estoque.TabStop = false;
            // 
            // gpb_Cliente
            // 
            this.gpb_Cliente.Controls.Add(this.btn_atualizarlistaClientes);
            this.gpb_Cliente.Controls.Add(this.pictureBox2);
            this.gpb_Cliente.Controls.Add(this.label5);
            this.gpb_Cliente.Controls.Add(this.btn_NovoCliente);
            this.gpb_Cliente.Controls.Add(this.label3);
            this.gpb_Cliente.Controls.Add(this.label4);
            this.gpb_Cliente.Controls.Add(this.listView_Clientes);
            this.gpb_Cliente.Location = new System.Drawing.Point(0, 9);
            this.gpb_Cliente.Name = "gpb_Cliente";
            this.gpb_Cliente.Size = new System.Drawing.Size(1041, 625);
            this.gpb_Cliente.TabIndex = 8;
            this.gpb_Cliente.TabStop = false;
            // 
            // btn_atualizarlistaClientes
            // 
            this.btn_atualizarlistaClientes.Location = new System.Drawing.Point(544, 58);
            this.btn_atualizarlistaClientes.Name = "btn_atualizarlistaClientes";
            this.btn_atualizarlistaClientes.Size = new System.Drawing.Size(103, 23);
            this.btn_atualizarlistaClientes.TabIndex = 13;
            this.btn_atualizarlistaClientes.Text = "Atualizar lista";
            this.btn_atualizarlistaClientes.UseVisualStyleBackColor = true;
            this.btn_atualizarlistaClientes.Click += new System.EventHandler(this.btn_atualizarlistaClientes_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_sign_add_299068;
            this.pictureBox2.Location = new System.Drawing.Point(127, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cliente jurídico";
            // 
            // btn_NovoCliente
            // 
            this.btn_NovoCliente.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_sign_add_299068;
            this.btn_NovoCliente.Location = new System.Drawing.Point(38, 27);
            this.btn_NovoCliente.Name = "btn_NovoCliente";
            this.btn_NovoCliente.Size = new System.Drawing.Size(48, 38);
            this.btn_NovoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_NovoCliente.TabIndex = 7;
            this.btn_NovoCliente.TabStop = false;
            this.btn_NovoCliente.Click += new System.EventHandler(this.btn_NovoCliente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cliente físico";
            // 
            // listView_Clientes
            // 
            this.listView_Clientes.HideSelection = false;
            this.listView_Clientes.Location = new System.Drawing.Point(16, 97);
            this.listView_Clientes.Name = "listView_Clientes";
            this.listView_Clientes.Size = new System.Drawing.Size(1013, 501);
            this.listView_Clientes.TabIndex = 0;
            this.listView_Clientes.UseCompatibleStateImageBehavior = false;
            this.listView_Clientes.View = System.Windows.Forms.View.Details;
            // 
            // picture_AddProd
            // 
            this.picture_AddProd.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_sign_add_299068;
            this.picture_AddProd.Location = new System.Drawing.Point(38, 41);
            this.picture_AddProd.Name = "picture_AddProd";
            this.picture_AddProd.Size = new System.Drawing.Size(48, 38);
            this.picture_AddProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_AddProd.TabIndex = 2;
            this.picture_AddProd.TabStop = false;
            this.picture_AddProd.Click += new System.EventHandler(this.picture_AddProd_Click);
            // 
            // picture_Edit
            // 
            this.picture_Edit.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_General_Office_09_2530835;
            this.picture_Edit.Location = new System.Drawing.Point(135, 41);
            this.picture_Edit.Name = "picture_Edit";
            this.picture_Edit.Size = new System.Drawing.Size(40, 38);
            this.picture_Edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_Edit.TabIndex = 4;
            this.picture_Edit.TabStop = false;
            this.picture_Edit.Click += new System.EventHandler(this.picture_Edit_Click);
            // 
            // groupBox_pedidos
            // 
            this.groupBox_pedidos.Controls.Add(this.btn_criarPedido);
            this.groupBox_pedidos.Controls.Add(this.label8);
            this.groupBox_pedidos.Controls.Add(this.label9);
            this.groupBox_pedidos.Controls.Add(this.listView_Pedido);
            this.groupBox_pedidos.Location = new System.Drawing.Point(126, 10);
            this.groupBox_pedidos.Name = "groupBox_pedidos";
            this.groupBox_pedidos.Size = new System.Drawing.Size(1041, 625);
            this.groupBox_pedidos.TabIndex = 14;
            this.groupBox_pedidos.TabStop = false;
            // 
            // btn_criarPedido
            // 
            this.btn_criarPedido.Image = global::GerenciadorDeEstoque.Properties.Resources.iconfinder_sign_add_299068;
            this.btn_criarPedido.Location = new System.Drawing.Point(38, 27);
            this.btn_criarPedido.Name = "btn_criarPedido";
            this.btn_criarPedido.Size = new System.Drawing.Size(48, 38);
            this.btn_criarPedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_criarPedido.TabIndex = 7;
            this.btn_criarPedido.TabStop = false;
            this.btn_criarPedido.Click += new System.EventHandler(this.btn_criarPedido_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Criar pedido";
            // 
            // listView_Pedido
            // 
            this.listView_Pedido.HideSelection = false;
            this.listView_Pedido.Location = new System.Drawing.Point(16, 97);
            this.listView_Pedido.Name = "listView_Pedido";
            this.listView_Pedido.Size = new System.Drawing.Size(1013, 501);
            this.listView_Pedido.TabIndex = 0;
            this.listView_Pedido.UseCompatibleStateImageBehavior = false;
            this.listView_Pedido.View = System.Windows.Forms.View.Details;
            // 
            // TelaLogado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 625);
            this.Controls.Add(this.groupBox_pedidos);
            this.Controls.Add(this.gpb_Estoque);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaLogado";
            this.Text = "X";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnImg_Cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpb_Estoque.ResumeLayout(false);
            this.gpb_Estoque.PerformLayout();
            this.gpb_Cliente.ResumeLayout(false);
            this.gpb_Cliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_NovoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_AddProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edit)).EndInit();
            this.groupBox_pedidos.ResumeLayout(false);
            this.groupBox_pedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_criarPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picture_AddProd;
        private System.Windows.Forms.Label label_AddProd;
        private System.Windows.Forms.PictureBox picture_Edit;
        private System.Windows.Forms.ListView listView_Cliente;
        private System.Windows.Forms.Label label_EditEstoq;
        private System.Windows.Forms.Button btn_AtualizarLista;
        private System.Windows.Forms.GroupBox gpb_Estoque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnImg_Cliente;
        private System.Windows.Forms.GroupBox gpb_Cliente;
        private System.Windows.Forms.ListView listView_Clientes;
        private System.Windows.Forms.PictureBox btn_NovoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_atualizarlistaClientes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox btn_pedido;
        private System.Windows.Forms.GroupBox groupBox_pedidos;
        private System.Windows.Forms.PictureBox btn_criarPedido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView_Pedido;
    }
}