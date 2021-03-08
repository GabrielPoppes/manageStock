
namespace GerenciadorDeEstoque.Apresentação
{
    partial class EditarProduto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txb_Quantidade = new System.Windows.Forms.TextBox();
            this.label_nome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_idProduto = new System.Windows.Forms.TextBox();
            this.btn_AddQnt = new System.Windows.Forms.Button();
            this.btn_rmvQnt = new System.Windows.Forms.Button();
            this.btn_deleteProduto = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_deleteProduto);
            this.groupBox1.Controls.Add(this.btn_rmvQnt);
            this.groupBox1.Controls.Add(this.txb_Quantidade);
            this.groupBox1.Controls.Add(this.label_nome);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txb_idProduto);
            this.groupBox1.Controls.Add(this.btn_AddQnt);
            this.groupBox1.Location = new System.Drawing.Point(-1, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 247);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar produto";
            // 
            // txb_Quantidade
            // 
            this.txb_Quantidade.Location = new System.Drawing.Point(157, 93);
            this.txb_Quantidade.Name = "txb_Quantidade";
            this.txb_Quantidade.Size = new System.Drawing.Size(244, 20);
            this.txb_Quantidade.TabIndex = 8;
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(74, 70);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(18, 13);
            this.label_nome.TabIndex = 0;
            this.label_nome.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "QUANTIDADE";
            // 
            // txb_idProduto
            // 
            this.txb_idProduto.Location = new System.Drawing.Point(157, 67);
            this.txb_idProduto.Name = "txb_idProduto";
            this.txb_idProduto.Size = new System.Drawing.Size(244, 20);
            this.txb_idProduto.TabIndex = 1;
            // 
            // btn_AddQnt
            // 
            this.btn_AddQnt.Location = new System.Drawing.Point(157, 119);
            this.btn_AddQnt.Name = "btn_AddQnt";
            this.btn_AddQnt.Size = new System.Drawing.Size(113, 23);
            this.btn_AddQnt.TabIndex = 2;
            this.btn_AddQnt.Text = "ADICIONAR";
            this.btn_AddQnt.UseVisualStyleBackColor = true;
            this.btn_AddQnt.Click += new System.EventHandler(this.btn_AddQnt_Click);
            // 
            // btn_rmvQnt
            // 
            this.btn_rmvQnt.Location = new System.Drawing.Point(288, 119);
            this.btn_rmvQnt.Name = "btn_rmvQnt";
            this.btn_rmvQnt.Size = new System.Drawing.Size(113, 23);
            this.btn_rmvQnt.TabIndex = 9;
            this.btn_rmvQnt.Text = "REMOVER";
            this.btn_rmvQnt.UseVisualStyleBackColor = true;
            this.btn_rmvQnt.Click += new System.EventHandler(this.btn_rmvQnt_Click);
            // 
            // btn_deleteProduto
            // 
            this.btn_deleteProduto.Location = new System.Drawing.Point(157, 148);
            this.btn_deleteProduto.Name = "btn_deleteProduto";
            this.btn_deleteProduto.Size = new System.Drawing.Size(244, 23);
            this.btn_deleteProduto.TabIndex = 10;
            this.btn_deleteProduto.Text = "EXCLUIR PRODUTO";
            this.btn_deleteProduto.UseVisualStyleBackColor = true;
            this.btn_deleteProduto.Click += new System.EventHandler(this.btn_deleteProduto_Click);
            // 
            // EditarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 285);
            this.Controls.Add(this.groupBox1);
            this.Name = "EditarProduto";
            this.Text = "EditarProduto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txb_Quantidade;
        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_idProduto;
        private System.Windows.Forms.Button btn_AddQnt;
        private System.Windows.Forms.Button btn_deleteProduto;
        private System.Windows.Forms.Button btn_rmvQnt;
    }
}