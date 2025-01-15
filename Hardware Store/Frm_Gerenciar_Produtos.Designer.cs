namespace Hardware_Store
{
    partial class Frm_Gerenciar_Produtos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Gerenciar_Produtos));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_deleteproduct = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_addproduct = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.pic_picture = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_category = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_products = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_delete_category = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dgv_category = new System.Windows.Forms.DataGridView();
            this.txt_idcategory = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_addcategory = new System.Windows.Forms.Button();
            this.txt_category = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_picture)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_category)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(844, 716);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.txt_quantity);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.btn_deleteproduct);
            this.tabPage1.Controls.Add(this.txt_id);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_name);
            this.tabPage1.Controls.Add(this.btn_addproduct);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txt_price);
            this.tabPage1.Controls.Add(this.txt_description);
            this.tabPage1.Controls.Add(this.pic_picture);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmb_category);
            this.tabPage1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(836, 680);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Produtos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 108);
            this.panel1.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.Window;
            this.label15.Location = new System.Drawing.Point(1, 26);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(780, 70);
            this.label15.TabIndex = 5;
            this.label15.Text = "Cadastrar novos produtos";
            // 
            // txt_quantity
            // 
            this.txt_quantity.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_quantity.Location = new System.Drawing.Point(126, 402);
            this.txt_quantity.Margin = new System.Windows.Forms.Padding(4);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(153, 34);
            this.txt_quantity.TabIndex = 25;
            this.txt_quantity.Text = "0";
            this.txt_quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_quantity_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label14.Location = new System.Drawing.Point(122, 371);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 31);
            this.label14.TabIndex = 21;
            this.label14.Text = "Quantidade";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label13.Location = new System.Drawing.Point(431, 237);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 31);
            this.label13.TabIndex = 20;
            this.label13.Text = "R$";
            // 
            // btn_deleteproduct
            // 
            this.btn_deleteproduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_deleteproduct.BackgroundImage")));
            this.btn_deleteproduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_deleteproduct.Location = new System.Drawing.Point(582, 150);
            this.btn_deleteproduct.Margin = new System.Windows.Forms.Padding(4);
            this.btn_deleteproduct.Name = "btn_deleteproduct";
            this.btn_deleteproduct.Size = new System.Drawing.Size(85, 48);
            this.btn_deleteproduct.TabIndex = 19;
            this.btn_deleteproduct.UseVisualStyleBackColor = true;
            this.btn_deleteproduct.Visible = false;
            this.btn_deleteproduct.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_id.Location = new System.Drawing.Point(126, 166);
            this.txt_id.Margin = new System.Windows.Forms.Padding(4);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(243, 34);
            this.txt_id.TabIndex = 1;
            this.txt_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_id_KeyPress);
            this.txt_id.Leave += new System.EventHandler(this.txt_id_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label1.Location = new System.Drawing.Point(121, 202);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label7.Location = new System.Drawing.Point(121, 135);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 31);
            this.label7.TabIndex = 18;
            this.label7.Text = "Id do Produto";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_name.Location = new System.Drawing.Point(126, 233);
            this.txt_name.Margin = new System.Windows.Forms.Padding(4);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(243, 34);
            this.txt_name.TabIndex = 2;
            // 
            // btn_addproduct
            // 
            this.btn_addproduct.Font = new System.Drawing.Font("Arial", 15F);
            this.btn_addproduct.Location = new System.Drawing.Point(133, 594);
            this.btn_addproduct.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addproduct.Name = "btn_addproduct";
            this.btn_addproduct.Size = new System.Drawing.Size(541, 39);
            this.btn_addproduct.TabIndex = 17;
            this.btn_addproduct.Text = "Cadastrar produto";
            this.btn_addproduct.UseVisualStyleBackColor = true;
            this.btn_addproduct.Click += new System.EventHandler(this.btn_CadastrarProduto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label3.Location = new System.Drawing.Point(476, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Preço";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label6.Location = new System.Drawing.Point(472, 383);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 31);
            this.label6.TabIndex = 16;
            this.label6.Text = "Foto";
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_price.Location = new System.Drawing.Point(481, 234);
            this.txt_price.Margin = new System.Windows.Forms.Padding(4);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(135, 34);
            this.txt_price.TabIndex = 3;
            this.txt_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_price_KeyPress);
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_description.Location = new System.Drawing.Point(126, 481);
            this.txt_description.Margin = new System.Windows.Forms.Padding(4);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(335, 105);
            this.txt_description.TabIndex = 5;
            // 
            // pic_picture
            // 
            this.pic_picture.Location = new System.Drawing.Point(477, 414);
            this.pic_picture.Margin = new System.Windows.Forms.Padding(4);
            this.pic_picture.Name = "pic_picture";
            this.pic_picture.Size = new System.Drawing.Size(197, 172);
            this.pic_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_picture.TabIndex = 11;
            this.pic_picture.TabStop = false;
            this.pic_picture.Click += new System.EventHandler(this.pic_foto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label5.Location = new System.Drawing.Point(122, 450);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 31);
            this.label5.TabIndex = 14;
            this.label5.Text = "Descrição";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label4.Location = new System.Drawing.Point(121, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "Categoria";
            // 
            // cmb_category
            // 
            this.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_category.Font = new System.Drawing.Font("Arial", 14F);
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.Location = new System.Drawing.Point(126, 322);
            this.cmb_category.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(243, 34);
            this.cmb_category.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dgv_products);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(836, 680);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Visualizar Produtos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 108);
            this.panel2.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(1, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(572, 70);
            this.label2.TabIndex = 5;
            this.label2.Text = "Todos os produtos";
            // 
            // dgv_products
            // 
            this.dgv_products.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_products.Location = new System.Drawing.Point(8, 162);
            this.dgv_products.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_products.Name = "dgv_products";
            this.dgv_products.RowHeadersWidth = 62;
            this.dgv_products.Size = new System.Drawing.Size(824, 521);
            this.dgv_products.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.btn_delete_category);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.dgv_category);
            this.tabPage3.Controls.Add(this.txt_idcategory);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.btn_addcategory);
            this.tabPage3.Controls.Add(this.txt_category);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(836, 680);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Categorias";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(833, 108);
            this.panel3.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(4, 22);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(339, 70);
            this.label11.TabIndex = 5;
            this.label11.Text = "Categorias";
            // 
            // btn_delete_category
            // 
            this.btn_delete_category.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_delete_category.BackgroundImage")));
            this.btn_delete_category.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete_category.Location = new System.Drawing.Point(624, 204);
            this.btn_delete_category.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete_category.Name = "btn_delete_category";
            this.btn_delete_category.Size = new System.Drawing.Size(85, 48);
            this.btn_delete_category.TabIndex = 26;
            this.btn_delete_category.UseVisualStyleBackColor = true;
            this.btn_delete_category.Visible = false;
            this.btn_delete_category.Leave += new System.EventHandler(this.btn_excluir_Categoria_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 316);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(263, 32);
            this.label12.TabIndex = 25;
            this.label12.Text = "Todas as Categorias";
            // 
            // dgv_category
            // 
            this.dgv_category.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_category.Location = new System.Drawing.Point(24, 371);
            this.dgv_category.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_category.Name = "dgv_category";
            this.dgv_category.RowHeadersWidth = 62;
            this.dgv_category.Size = new System.Drawing.Size(443, 209);
            this.dgv_category.TabIndex = 24;
            // 
            // txt_idcategory
            // 
            this.txt_idcategory.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_idcategory.Location = new System.Drawing.Point(24, 175);
            this.txt_idcategory.Margin = new System.Windows.Forms.Padding(4);
            this.txt_idcategory.Name = "txt_idcategory";
            this.txt_idcategory.Size = new System.Drawing.Size(243, 34);
            this.txt_idcategory.TabIndex = 23;
            this.txt_idcategory.Leave += new System.EventHandler(this.txt_idCategoria_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label10.Location = new System.Drawing.Point(19, 144);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 31);
            this.label10.TabIndex = 22;
            this.label10.Text = "ID da Categoria";
            // 
            // btn_addcategory
            // 
            this.btn_addcategory.Font = new System.Drawing.Font("Arial", 15F);
            this.btn_addcategory.Location = new System.Drawing.Point(22, 226);
            this.btn_addcategory.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addcategory.Name = "btn_addcategory";
            this.btn_addcategory.Size = new System.Drawing.Size(541, 39);
            this.btn_addcategory.TabIndex = 21;
            this.btn_addcategory.Text = "Cadastrar categoria";
            this.btn_addcategory.UseVisualStyleBackColor = true;
            this.btn_addcategory.Click += new System.EventHandler(this.btn_categoria_Click);
            // 
            // txt_category
            // 
            this.txt_category.Font = new System.Drawing.Font("Arial", 14F);
            this.txt_category.Location = new System.Drawing.Point(320, 175);
            this.txt_category.Margin = new System.Windows.Forms.Padding(4);
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(243, 34);
            this.txt_category.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 15.25F);
            this.label9.Location = new System.Drawing.Point(315, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 31);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nome da Categoria";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // Frm_Gerenciar_Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(873, 744);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Gerenciar_Produtos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Produtos";
            this.Load += new System.EventHandler(this.Frm_Gerenciar_Produtos_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_picture)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_category)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_addproduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.PictureBox pic_picture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_category;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_idcategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_addcategory;
        private System.Windows.Forms.TextBox txt_category;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_category;
        private System.Windows.Forms.DataGridView dgv_products;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_deleteproduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_delete_category;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
    }
}