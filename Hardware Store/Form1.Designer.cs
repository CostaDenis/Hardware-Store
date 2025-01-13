namespace Hardware_Store
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.btn_entrar = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_recoverPassword = new System.Windows.Forms.Label();
            this.chb_mostrarSenha = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_entrar
            // 
            this.btn_entrar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_entrar.Location = new System.Drawing.Point(97, 489);
            this.btn_entrar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_entrar.Name = "btn_entrar";
            this.btn_entrar.Size = new System.Drawing.Size(473, 42);
            this.btn_entrar.TabIndex = 8;
            this.btn_entrar.Text = "Entrar";
            this.btn_entrar.UseVisualStyleBackColor = true;
            this.btn_entrar.Click += new System.EventHandler(this.btn_entrar_Click);
            // 
            // txt_senha
            // 
            this.txt_senha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_senha.Location = new System.Drawing.Point(97, 380);
            this.txt_senha.Margin = new System.Windows.Forms.Padding(4);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.Size = new System.Drawing.Size(473, 35);
            this.txt_senha.TabIndex = 7;
            this.txt_senha.TabStop = false;
            this.txt_senha.UseSystemPasswordChar = true;
            // 
            // txt_cpf
            // 
            this.txt_cpf.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(97, 294);
            this.txt_cpf.Margin = new System.Windows.Forms.Padding(4);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(473, 35);
            this.txt_cpf.TabIndex = 6;
            this.txt_cpf.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.lbl_recoverPassword);
            this.panel1.Controls.Add(this.chb_mostrarSenha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_entrar);
            this.panel1.Controls.Add(this.txt_cpf);
            this.panel1.Controls.Add(this.txt_senha);
            this.panel1.Location = new System.Drawing.Point(1, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 749);
            this.panel1.TabIndex = 11;
            // 
            // lbl_recoverPassword
            // 
            this.lbl_recoverPassword.AutoSize = true;
            this.lbl_recoverPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_recoverPassword.Location = new System.Drawing.Point(406, 423);
            this.lbl_recoverPassword.Name = "lbl_recoverPassword";
            this.lbl_recoverPassword.Size = new System.Drawing.Size(164, 22);
            this.lbl_recoverPassword.TabIndex = 14;
            this.lbl_recoverPassword.Text = "Recuperar senha >";
            this.lbl_recoverPassword.Click += new System.EventHandler(this.lbl_recoverPassword_Click);
            // 
            // chb_mostrarSenha
            // 
            this.chb_mostrarSenha.AutoSize = true;
            this.chb_mostrarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_mostrarSenha.Location = new System.Drawing.Point(97, 422);
            this.chb_mostrarSenha.Name = "chb_mostrarSenha";
            this.chb_mostrarSenha.Size = new System.Drawing.Size(146, 26);
            this.chb_mostrarSenha.TabIndex = 13;
            this.chb_mostrarSenha.Text = "Mostrar senha";
            this.chb_mostrarSenha.UseVisualStyleBackColor = true;
            this.chb_mostrarSenha.CheckedChanged += new System.EventHandler(this.chb_mostrarSenha_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(173, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 70);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bem vindo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(706, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 431);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1290, 743);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_entrar;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.TextBox txt_cpf;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_recoverPassword;
        private System.Windows.Forms.CheckBox chb_mostrarSenha;
    }
}

