
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_Cancelado = new System.Windows.Forms.CheckBox();
            this.checkBox_Pago = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_Id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox_Cancelado);
            this.groupBox1.Controls.Add(this.checkBox_Pago);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txb_Id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baixa no pedido";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(423, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ENCERRAR PEDIDO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_Cancelado
            // 
            this.checkBox_Cancelado.AutoSize = true;
            this.checkBox_Cancelado.Location = new System.Drawing.Point(261, 96);
            this.checkBox_Cancelado.Name = "checkBox_Cancelado";
            this.checkBox_Cancelado.Size = new System.Drawing.Size(77, 17);
            this.checkBox_Cancelado.TabIndex = 5;
            this.checkBox_Cancelado.Text = "Cancelado";
            this.checkBox_Cancelado.UseVisualStyleBackColor = true;
            // 
            // checkBox_Pago
            // 
            this.checkBox_Pago.AutoSize = true;
            this.checkBox_Pago.Location = new System.Drawing.Point(261, 73);
            this.checkBox_Pago.Name = "checkBox_Pago";
            this.checkBox_Pago.Size = new System.Drawing.Size(51, 17);
            this.checkBox_Pago.TabIndex = 4;
            this.checkBox_Pago.Text = "Pago";
            this.checkBox_Pago.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "STATUS DO PEDIDO";
            // 
            // txb_Id
            // 
            this.txb_Id.Location = new System.Drawing.Point(101, 54);
            this.txb_Id.Name = "txb_Id";
            this.txb_Id.Size = new System.Drawing.Size(100, 20);
            this.txb_Id.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // EncerrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 178);
            this.Controls.Add(this.groupBox1);
            this.Name = "EncerrarPedido";
            this.Text = "EncerrarPedido";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_Cancelado;
        private System.Windows.Forms.CheckBox checkBox_Pago;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txb_Id;
    }
}