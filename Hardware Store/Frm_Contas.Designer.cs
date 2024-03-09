namespace Hardware_Store
{
    partial class Frm_Contas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Contas));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.cmb_ativo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_acesso = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.txt_cpf = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 360);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_excluir);
            this.tabPage1.Controls.Add(this.cmb_ativo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btn_adicionar);
            this.tabPage1.Controls.Add(this.btn_down);
            this.tabPage1.Controls.Add(this.btn_up);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_acesso);
            this.tabPage1.Controls.Add(this.txt_nome);
            this.tabPage1.Controls.Add(this.txt_senha);
            this.tabPage1.Controls.Add(this.txt_cpf);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Contas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_excluir.BackgroundImage")));
            this.btn_excluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excluir.Location = new System.Drawing.Point(381, 236);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(64, 39);
            this.btn_excluir.TabIndex = 10;
            this.btn_excluir.UseVisualStyleBackColor = true;
            this.btn_excluir.Visible = false;
            // 
            // cmb_ativo
            // 
            this.cmb_ativo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_ativo.FormattingEnabled = true;
            this.cmb_ativo.Items.AddRange(new object[] {
            "Sim",
            "Não"});
            this.cmb_ativo.Location = new System.Drawing.Point(270, 146);
            this.cmb_ativo.Name = "cmb_ativo";
            this.cmb_ativo.Size = new System.Drawing.Size(196, 30);
            this.cmb_ativo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(266, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Ativo";
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.Location = new System.Drawing.Point(10, 281);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(435, 35);
            this.btn_adicionar.TabIndex = 5;
            this.btn_adicionar.Text = "Adicionar ";
            this.btn_adicionar.UseVisualStyleBackColor = true;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // btn_down
            // 
            this.btn_down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_down.BackgroundImage")));
            this.btn_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_down.Location = new System.Drawing.Point(281, 224);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(33, 28);
            this.btn_down.TabIndex = 5;
            this.btn_down.UseVisualStyleBackColor = true;
            // 
            // btn_up
            // 
            this.btn_up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_up.BackgroundImage")));
            this.btn_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_up.Location = new System.Drawing.Point(242, 223);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(33, 28);
            this.btn_up.TabIndex = 4;
            this.btn_up.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nivel de acesso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Senha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "CPF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cadastrar novas contas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome";
            // 
            // txt_acesso
            // 
            this.txt_acesso.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acesso.Location = new System.Drawing.Point(7, 223);
            this.txt_acesso.Name = "txt_acesso";
            this.txt_acesso.ReadOnly = true;
            this.txt_acesso.Size = new System.Drawing.Size(229, 29);
            this.txt_acesso.TabIndex = 3;
            this.txt_acesso.Text = "0";
            // 
            // txt_nome
            // 
            this.txt_nome.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome.Location = new System.Drawing.Point(238, 66);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(229, 29);
            this.txt_nome.TabIndex = 1;
            // 
            // txt_senha
            // 
            this.txt_senha.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_senha.Location = new System.Drawing.Point(10, 147);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.Size = new System.Drawing.Size(229, 29);
            this.txt_senha.TabIndex = 2;
            // 
            // txt_cpf
            // 
            this.txt_cpf.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cpf.Location = new System.Drawing.Point(10, 66);
            this.txt_cpf.Name = "txt_cpf";
            this.txt_cpf.Size = new System.Drawing.Size(176, 29);
            this.txt_cpf.TabIndex = 0;
            this.txt_cpf.Leave += new System.EventHandler(this.txt_cpf_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Visualizar Contas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 30);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(463, 298);
            this.dgv.TabIndex = 0;
            // 
            // Frm_Contas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 376);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Contas";
            this.Text = "Contas";
            this.Load += new System.EventHandler(this.Frm_Contas_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.ComboBox cmb_ativo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_acesso;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.TextBox txt_cpf;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv;
    }
}