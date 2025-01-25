namespace Hardware_Store
{
    partial class Frm_MenuLoja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MenuLoja));
            this.pb_imageProduct = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tc_category = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.btn_addToCart = new System.Windows.Forms.Button();
            this.lbl_QTDE = new System.Windows.Forms.Label();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_verifyCart = new System.Windows.Forms.Button();
            this.btn_buyCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imageProduct)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tc_category.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_imageProduct
            // 
            this.pb_imageProduct.Location = new System.Drawing.Point(1107, 151);
            this.pb_imageProduct.Margin = new System.Windows.Forms.Padding(4);
            this.pb_imageProduct.Name = "pb_imageProduct";
            this.pb_imageProduct.Size = new System.Drawing.Size(286, 222);
            this.pb_imageProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imageProduct.TabIndex = 1;
            this.pb_imageProduct.TabStop = false;
            this.pb_imageProduct.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1019, 527);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.hScrollBar1);
            this.tabPage1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1019, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(835, 193);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(8, 8);
            this.hScrollBar1.TabIndex = 1;
            // 
            // tc_category
            // 
            this.tc_category.Controls.Add(this.tabPage1);
            this.tc_category.Controls.Add(this.tabPage2);
            this.tc_category.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_category.Location = new System.Drawing.Point(19, 119);
            this.tc_category.Margin = new System.Windows.Forms.Padding(4);
            this.tc_category.Name = "tc_category";
            this.tc_category.SelectedIndex = 0;
            this.tc_category.Size = new System.Drawing.Size(1027, 563);
            this.tc_category.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1402, 113);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 70);
            this.label2.TabIndex = 5;
            this.label2.Text = "Loja";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(1233, 124);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(62, 23);
            this.lbl_name.TabIndex = 13;
            this.lbl_name.Text = "label1";
            this.lbl_name.Visible = false;
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.Location = new System.Drawing.Point(1233, 377);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(62, 23);
            this.lbl_price.TabIndex = 14;
            this.lbl_price.Text = "label3";
            this.lbl_price.Visible = false;
            // 
            // txt_description
            // 
            this.txt_description.BackColor = System.Drawing.SystemColors.Control;
            this.txt_description.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Location = new System.Drawing.Point(1107, 427);
            this.txt_description.Margin = new System.Windows.Forms.Padding(4);
            this.txt_description.Multiline = true;
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(286, 145);
            this.txt_description.TabIndex = 22;
            this.txt_description.Visible = false;
            // 
            // btn_addToCart
            // 
            this.btn_addToCart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_addToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addToCart.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addToCart.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_addToCart.Location = new System.Drawing.Point(1107, 631);
            this.btn_addToCart.Name = "btn_addToCart";
            this.btn_addToCart.Size = new System.Drawing.Size(286, 51);
            this.btn_addToCart.TabIndex = 23;
            this.btn_addToCart.Text = "Adicionar ao carrinho";
            this.btn_addToCart.UseVisualStyleBackColor = false;
            this.btn_addToCart.Visible = false;
            this.btn_addToCart.Click += new System.EventHandler(this.Btn_addToCart_Click);
            // 
            // lbl_QTDE
            // 
            this.lbl_QTDE.AutoSize = true;
            this.lbl_QTDE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QTDE.Location = new System.Drawing.Point(1104, 602);
            this.lbl_QTDE.Name = "lbl_QTDE";
            this.lbl_QTDE.Size = new System.Drawing.Size(65, 23);
            this.lbl_QTDE.TabIndex = 24;
            this.lbl_QTDE.Text = "QTDE";
            this.lbl_QTDE.Visible = false;
            // 
            // txt_quantity
            // 
            this.txt_quantity.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quantity.Location = new System.Drawing.Point(1175, 598);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(100, 27);
            this.txt_quantity.TabIndex = 25;
            this.txt_quantity.Visible = false;
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_amount.Location = new System.Drawing.Point(22, 750);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(31, 33);
            this.lbl_amount.TabIndex = 27;
            this.lbl_amount.Text = "0";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.DarkRed;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(524, 715);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(286, 68);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // btn_verifyCart
            // 
            this.btn_verifyCart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_verifyCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verifyCart.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verifyCart.ForeColor = System.Drawing.Color.White;
            this.btn_verifyCart.Location = new System.Drawing.Point(816, 715);
            this.btn_verifyCart.Name = "btn_verifyCart";
            this.btn_verifyCart.Size = new System.Drawing.Size(284, 68);
            this.btn_verifyCart.TabIndex = 29;
            this.btn_verifyCart.Text = "Verificar pedido";
            this.btn_verifyCart.UseVisualStyleBackColor = false;
            this.btn_verifyCart.Click += new System.EventHandler(this.Btn_verifyCart_Click);
            // 
            // btn_buyCart
            // 
            this.btn_buyCart.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_buyCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buyCart.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buyCart.ForeColor = System.Drawing.Color.White;
            this.btn_buyCart.Location = new System.Drawing.Point(1107, 715);
            this.btn_buyCart.Name = "btn_buyCart";
            this.btn_buyCart.Size = new System.Drawing.Size(286, 68);
            this.btn_buyCart.TabIndex = 30;
            this.btn_buyCart.Text = "Finalizar pedido";
            this.btn_buyCart.UseVisualStyleBackColor = false;
            this.btn_buyCart.Click += new System.EventHandler(this.Btn_buyCart_Click);
            // 
            // Frm_MenuLoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1406, 795);
            this.Controls.Add(this.btn_buyCart);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_verifyCart);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.txt_quantity);
            this.Controls.Add(this.lbl_QTDE);
            this.Controls.Add(this.btn_addToCart);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb_imageProduct);
            this.Controls.Add(this.tc_category);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_MenuLoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja";
            this.Load += new System.EventHandler(this.Frm_MenuLoja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_imageProduct)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tc_category.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_imageProduct;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tc_category;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_price;
        internal System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Button btn_addToCart;
        private System.Windows.Forms.Label lbl_QTDE;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_verifyCart;
        private System.Windows.Forms.Button btn_buyCart;
    }
}