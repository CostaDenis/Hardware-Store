namespace Hardware_Store
{
    partial class Frm_Adm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Adm));
            this.btn_relatorios = new System.Windows.Forms.Button();
            this.btn_produtos = new System.Windows.Forms.Button();
            this.btn_contas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_relatorios
            // 
            this.btn_relatorios.Location = new System.Drawing.Point(58, 181);
            this.btn_relatorios.Name = "btn_relatorios";
            this.btn_relatorios.Size = new System.Drawing.Size(154, 29);
            this.btn_relatorios.TabIndex = 5;
            this.btn_relatorios.Text = "Relatórios";
            this.btn_relatorios.UseVisualStyleBackColor = true;
            // 
            // btn_produtos
            // 
            this.btn_produtos.Location = new System.Drawing.Point(278, 86);
            this.btn_produtos.Name = "btn_produtos";
            this.btn_produtos.Size = new System.Drawing.Size(154, 29);
            this.btn_produtos.TabIndex = 4;
            this.btn_produtos.Text = "Gerenciar Produtos";
            this.btn_produtos.UseVisualStyleBackColor = true;
            this.btn_produtos.Click += new System.EventHandler(this.btn_produtos_Click);
            // 
            // btn_contas
            // 
            this.btn_contas.Location = new System.Drawing.Point(58, 86);
            this.btn_contas.Name = "btn_contas";
            this.btn_contas.Size = new System.Drawing.Size(154, 29);
            this.btn_contas.TabIndex = 3;
            this.btn_contas.Text = "Contas";
            this.btn_contas.UseVisualStyleBackColor = true;
            this.btn_contas.Click += new System.EventHandler(this.btn_contas_Click);
            // 
            // Frm_Adm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 297);
            this.Controls.Add(this.btn_relatorios);
            this.Controls.Add(this.btn_produtos);
            this.Controls.Add(this.btn_contas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Adm";
            this.Text = "Administrador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_relatorios;
        private System.Windows.Forms.Button btn_produtos;
        private System.Windows.Forms.Button btn_contas;
    }
}