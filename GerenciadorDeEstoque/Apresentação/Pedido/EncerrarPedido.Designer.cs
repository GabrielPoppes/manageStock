
namespace GerenciadorDeEstoque.Apresentação.Pedido
{
    partial class EncerrarPedido
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
            this.btnExcluirPedido = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_Cancelado = new System.Windows.Forms.CheckBox();
            this.checkBox_Pago = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExcluirPedido
            // 
            this.btnExcluirPedido.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExcluirPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirPedido.Location = new System.Drawing.Point(9, 130);
            this.btnExcluirPedido.Name = "btnExcluirPedido";
            this.btnExcluirPedido.Size = new System.Drawing.Size(423, 23);
            this.btnExcluirPedido.TabIndex = 7;
            this.btnExcluirPedido.Text = "EXCLUIR PEDIDO";
            this.btnExcluirPedido.UseVisualStyleBackColor = false;
            this.btnExcluirPedido.Click += new System.EventHandler(this.btnExcluirPedido_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(9, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(423, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "MUDAR ESTADO DO PEDIDO";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_Cancelado
            // 
            this.checkBox_Cancelado.AutoSize = true;
            this.checkBox_Cancelado.Location = new System.Drawing.Point(237, 63);
            this.checkBox_Cancelado.Name = "checkBox_Cancelado";
            this.checkBox_Cancelado.Size = new System.Drawing.Size(77, 17);
            this.checkBox_Cancelado.TabIndex = 5;
            this.checkBox_Cancelado.Text = "Cancelado";
            this.checkBox_Cancelado.UseVisualStyleBackColor = true;
            // 
            // checkBox_Pago
            // 
            this.checkBox_Pago.AutoSize = true;
            this.checkBox_Pago.Location = new System.Drawing.Point(237, 40);
            this.checkBox_Pago.Name = "checkBox_Pago";
            this.checkBox_Pago.Size = new System.Drawing.Size(51, 17);
            this.checkBox_Pago.TabIndex = 4;
            this.checkBox_Pago.Text = "Pago";
            this.checkBox_Pago.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "STATUS DO PEDIDO";
            // 
            // txb_Id
            // 
            this.txb_Id.Location = new System.Drawing.Point(77, 21);
            this.txb_Id.Name = "txb_Id";
            this.txb_Id.Size = new System.Drawing.Size(100, 20);
            this.txb_Id.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // EncerrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(444, 163);
            this.Controls.Add(this.btnExcluirPedido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_Cancelado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Pago);
            this.Controls.Add(this.txb_Id);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EncerrarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar status do pedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_Cancelado;
        private System.Windows.Forms.CheckBox checkBox_Pago;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txb_Id;
        private System.Windows.Forms.Button btnExcluirPedido;
    }
}