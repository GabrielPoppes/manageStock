
namespace GerenciadorDeEstoque
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txb_join = new System.Windows.Forms.Button();
            this.txb_register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.txb_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txb_join
            // 
            this.txb_join.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.txb_join, "txb_join");
            this.txb_join.Name = "txb_join";
            this.txb_join.UseVisualStyleBackColor = false;
            this.txb_join.Click += new System.EventHandler(this.txb_join_Click);
            // 
            // txb_register
            // 
            this.txb_register.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.txb_register, "txb_register");
            this.txb_register.Name = "txb_register";
            this.txb_register.UseVisualStyleBackColor = false;
            this.txb_register.Click += new System.EventHandler(this.txb_register_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txb_email
            // 
            resources.ApplyResources(this.txb_email, "txb_email");
            this.txb_email.Name = "txb_email";
            // 
            // txb_password
            // 
            resources.ApplyResources(this.txb_password, "txb_password");
            this.txb_password.Name = "txb_password";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.txb_email);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txb_join);
            this.groupBox1.Controls.Add(this.txb_password);
            this.groupBox1.Controls.Add(this.txb_register);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txb_join;
        private System.Windows.Forms.Button txb_register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.TextBox txb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

