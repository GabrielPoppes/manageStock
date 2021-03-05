
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_AddProd = new System.Windows.Forms.Label();
            this.listView_Estoque = new System.Windows.Forms.ListView();
            this.label_EditEstoq = new System.Windows.Forms.Label();
            this.btn_AtualizarLista = new System.Windows.Forms.Button();
            this.picture_Edit = new System.Windows.Forms.PictureBox();
            this.picture_AddProd = new System.Windows.Forms.PictureBox();
            this.gpb_Estoque = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_AddProd)).BeginInit();
            this.gpb_Estoque.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(1, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 424);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.label_AddProd.Location = new System.Drawing.Point(17, 82);
            this.label_AddProd.Name = "label_AddProd";
            this.label_AddProd.Size = new System.Drawing.Size(94, 13);
            this.label_AddProd.TabIndex = 2;
            this.label_AddProd.Text = "Criar novo produto";
            // 
            // listView_Estoque
            // 
            this.listView_Estoque.HideSelection = false;
            this.listView_Estoque.Location = new System.Drawing.Point(16, 106);
            this.listView_Estoque.Name = "listView_Estoque";
            this.listView_Estoque.Size = new System.Drawing.Size(631, 312);
            this.listView_Estoque.TabIndex = 5;
            this.listView_Estoque.UseCompatibleStateImageBehavior = false;
            this.listView_Estoque.View = System.Windows.Forms.View.Details;
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
            // gpb_Estoque
            // 
            this.gpb_Estoque.Controls.Add(this.listView_Estoque);
            this.gpb_Estoque.Controls.Add(this.btn_AtualizarLista);
            this.gpb_Estoque.Controls.Add(this.picture_AddProd);
            this.gpb_Estoque.Controls.Add(this.label_EditEstoq);
            this.gpb_Estoque.Controls.Add(this.label_AddProd);
            this.gpb_Estoque.Controls.Add(this.picture_Edit);
            this.gpb_Estoque.Location = new System.Drawing.Point(126, -9);
            this.gpb_Estoque.Name = "gpb_Estoque";
            this.gpb_Estoque.Size = new System.Drawing.Size(674, 447);
            this.gpb_Estoque.TabIndex = 8;
            this.gpb_Estoque.TabStop = false;
            // 
            // TelaLogado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gpb_Estoque);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaLogado";
            this.Text = "X";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_AddProd)).EndInit();
            this.gpb_Estoque.ResumeLayout(false);
            this.gpb_Estoque.PerformLayout();
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
        private System.Windows.Forms.ListView listView_Estoque;
        private System.Windows.Forms.Label label_EditEstoq;
        private System.Windows.Forms.Button btn_AtualizarLista;
        private System.Windows.Forms.GroupBox gpb_Estoque;
    }
}