﻿
namespace GerenciadorDeEstoque.Apresentação
{
    partial class AddProduct
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
            this.label_nome = new System.Windows.Forms.Label();
            this.txb_NomeProduto = new System.Windows.Forms.TextBox();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.txb_Cor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_Preco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_Quantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Location = new System.Drawing.Point(6, 13);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(39, 13);
            this.label_nome.TabIndex = 0;
            this.label_nome.Text = "NOME";
            // 
            // txb_NomeProduto
            // 
            this.txb_NomeProduto.Location = new System.Drawing.Point(89, 10);
            this.txb_NomeProduto.Name = "txb_NomeProduto";
            this.txb_NomeProduto.Size = new System.Drawing.Size(244, 20);
            this.txb_NomeProduto.TabIndex = 1;
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cadastrar.Location = new System.Drawing.Point(89, 122);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(244, 23);
            this.btn_Cadastrar.TabIndex = 2;
            this.btn_Cadastrar.Text = "CADASTRAR";
            this.btn_Cadastrar.UseVisualStyleBackColor = false;
            this.btn_Cadastrar.Click += new System.EventHandler(this.btn_Cadastrar_Click);
            // 
            // txb_Cor
            // 
            this.txb_Cor.Location = new System.Drawing.Point(89, 36);
            this.txb_Cor.Name = "txb_Cor";
            this.txb_Cor.Size = new System.Drawing.Size(244, 20);
            this.txb_Cor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "COR";
            // 
            // txb_Preco
            // 
            this.txb_Preco.Location = new System.Drawing.Point(89, 62);
            this.txb_Preco.Name = "txb_Preco";
            this.txb_Preco.Size = new System.Drawing.Size(244, 20);
            this.txb_Preco.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PREÇO";
            // 
            // txb_Quantidade
            // 
            this.txb_Quantidade.Location = new System.Drawing.Point(89, 88);
            this.txb_Quantidade.Name = "txb_Quantidade";
            this.txb_Quantidade.Size = new System.Drawing.Size(244, 20);
            this.txb_Quantidade.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "QUANTIDADE";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(354, 160);
            this.Controls.Add(this.txb_Quantidade);
            this.Controls.Add(this.label_nome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_Cor);
            this.Controls.Add(this.txb_NomeProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_Preco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cadastrar);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar produto";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.TextBox txb_NomeProduto;
        private System.Windows.Forms.TextBox txb_Cor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_Preco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_Quantidade;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btn_Cadastrar;
    }
}