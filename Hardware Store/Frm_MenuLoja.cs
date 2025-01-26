using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hardware_Store
{
    //Arrumar o total do valor
    public partial class Frm_MenuLoja : Form
    {
        BindingList<CartItem> cart = Central.cart;
        double amount = 0;
        string sql = "";
        DataTable dt = new DataTable();
        List<int> productsIdAdded = new List<int>();
        bool pairFirst = false;
        int index = 0, nextIndexCol = 3, indexCol = 1;
        CultureInfo currentCulture = CultureInfo.CurrentCulture;


        public Frm_MenuLoja()
        {
            InitializeComponent();
        }

        private void Frm_MenuLoja_Load(object sender, EventArgs e)
        {
            string[] categoryName = SearchNameCategory();
            int numCategory = categoryName.Length;

            tc_category.TabPages.Clear();

            //Preenche o TabPages com a(s) categoria(s)
            for (int i = 0; i < numCategory; i++)
            {
                TabPage tabPage = new TabPage($"{categoryName[i]}");
                tc_category.TabPages.Add(tabPage);

                Panel panel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                tabPage.Controls.Add(panel);
                FillProducts();

            }
            UpdateTotalAmount();

        }

        private string[] SearchNameCategory()
        {
            string sql = "select nome from TBCATEGORIAS";
            DataTable dt = Central.Query(sql);
            string[] nome = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nome[i] = dt.Rows[i]["nome"].ToString();
            }
            return nome;
        }

        private void FillProducts()
        {
            Dictionary<int, string> categorias = Central.ObterCategoriasIdParaNome();
            var tabPagesMap = tc_category.TabPages.Cast<TabPage>()
                .ToDictionary(tabPage => tabPage.Text, tabPage => tabPage);
            string sql = "select Distinct id, nome, preco, quantidade, id_categoria, descricao, foto from TBPRODUTOS";
            string productName = "", productPicture = "";
            float productPrice = 0.0f;
            string productPriceFormatted = "";
            string productDescription = "";
            int productId = 0;
            int productQuantity = 0;
            DataTable dt = Central.Query(sql);
            int idCategoria = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                productId = Convert.ToInt32(dt.Rows[i]["id"]);
                productName = dt.Rows[i]["nome"].ToString().Trim();
                idCategoria = Convert.ToInt32(dt.Rows[i]["id_categoria"]);
                productPrice = float.Parse(dt.Rows[i]["preco"].ToString());
                productQuantity = Convert.ToInt32(dt.Rows[i]["quantidade"]);
                productDescription = dt.Rows[i]["descricao"].ToString();
                productPicture = dt.Rows[i]["foto"].ToString();

                if (categorias.TryGetValue(idCategoria, out string nomeCategoria) &&
                    tabPagesMap.TryGetValue(nomeCategoria, out TabPage tabPage) &&
                    tabPage.Controls[0] is Panel panel)
                {

                    if (!productsIdAdded.Contains(productId))
                    {
                        productPriceFormatted = productPrice.ToString("C", currentCulture);

                        productsIdAdded.Add(productId);
                        AddProduct(productName, productPriceFormatted, productDescription, productPicture, productQuantity,
                            panel);
                    }

                }

            }
            pairFirst = !pairFirst;
        }

        private void AddProduct(string name, string price, string description, string image,
            int quantity, Panel panel)
        {


            if (index == nextIndexCol)
            {
                indexCol++;
                index = 0;
            }
            index++;

            PictureBox pb = CreateProductPictureBox(image, panel, name, price.ToString(), quantity, description);
            Label lblName = CreateProductLabelsTop(name, quantity, pb, panel, index);
            Label lblPrice = CreateProductLabelsBottom(price, quantity, pb, panel, index);

        }

        private Label CreateProductLabelsTop(string name, int quantity, PictureBox pb, Panel panel, int index)
        {
            Label lblName = new Label
            {
                Text = name,
                Name = $"lblName_{index}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

            if (quantity == 0)
            {
                lblName.ForeColor = Color.Gray;
            }

            panel.Controls.Add(lblName);
            CenterLabelTop(pb, lblName);

            return lblName;

        }

        private void CenterLabelTop(PictureBox pb, Label lbl)
        {
            int centerX = pb.Left + pb.Width / 2;
            int labelTop = pb.Top - lbl.Height - 10;

            lbl.Left = centerX - lbl.Width / 2;
            lbl.Top = labelTop;
        }

        private Label CreateProductLabelsBottom(string price, int quantity, PictureBox pb, Panel panel, int index)
        {
            Label lblPrice = new Label
            {
                Text = price.ToString(),
                Name = $"lblPrice_{index}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

            if (quantity == 0)
            {
                lblPrice.ForeColor = Color.Gray;
            }

            panel.Controls.Add(lblPrice);
            CenterLabelBottom(pb, lblPrice);

            return lblPrice;
        }

        private void CenterLabelBottom(PictureBox pb, Label lbl, string option = null)
        {
            int labelTop;
            if (option == null)
            {
                labelTop = pb.Top - lbl.Bottom + 170;
            }
            else
            {
                labelTop = pb.Top + pb.Height + 10;
            }
            int centerX = pb.Left + pb.Width / 2;

            lbl.Left = centerX - lbl.Width / 2;
            lbl.Top = labelTop;
        }

        private PictureBox CreateProductPictureBox(string image, Panel panel, string name, string price,
                int quantity, string description)
        {
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pictureBox.Location = CalculateNewPoint(index, indexCol, pictureBox);

            string imagePath = Path.Combine(Application.StartupPath + "\\", image);
            if (File.Exists(imagePath))
            {
                pictureBox.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show($"Imagem não encontrada: {imagePath}");
            }

            pictureBox.Click += (sender, e) =>
            {
                SelectProduct(imagePath, name, price, quantity, description);
            };


            panel.Controls.Add(pictureBox);

            return pictureBox;

        }

        private void Btn_addToCart_Click(object sender, EventArgs e)
        {

            if (VerifyQuantity())
            {
                double.TryParse(lbl_price.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double price);
                cart.Add(new CartItem(GetIdProduct(lbl_name.Text), lbl_name.Text, price, Convert.ToInt32(txt_quantity.Text)));
                UpdateTotalAmount();
            }
        }

        private void UpdateTotalAmount()
        {
            amount = cart.Sum(item => item.ProductPrice * item.Quantity);
            lbl_amount.Text = $"Total: {amount.ToString("C", currentCulture)}";
        }

        private Point CalculateNewPoint(int numberProduct, int indexCol, PictureBox pb)
        {
            const int horizontalSpacing = 200;
            const int verticalSpacing = 100;
            const int initialX = 80;

            int totalHeight = pb.Height + verticalSpacing;
            int posX = initialX + (numberProduct - 1) * horizontalSpacing;
            int posY = (indexCol - 1) * totalHeight + 100;

            return new Point(posX, posY);
        }

        private void SelectProduct(string picLocation, string name, string price, int quantity, string description)
        {
            if (File.Exists(picLocation))
            {
                pb_imageProduct.ImageLocation = picLocation;
            }
            else
            {
                MessageBox.Show("Imagem não encontrada!");
            }


            lbl_name.Text = name;
            lbl_name.Visible = true;

            lbl_price.Text = price;
            lbl_price.Visible = true;

            txt_description.Text = description;
            txt_description.Visible = true;

            pb_imageProduct.Visible = true;

            lbl_QTDE.Visible = true;

            txt_quantity.Visible = true;
            txt_quantity.Text = "0";

            btn_addToCart.Visible = true;


            CenterLabelTop(pb_imageProduct, lbl_name);
            CenterLabelBottom(pb_imageProduct, lbl_price, "Select");

            if (quantity > 0)
            {
                btn_addToCart.Enabled = true;
                btn_addToCart.Text = "Adicionar ao carrinho";
                btn_addToCart.BackColor = SystemColors.Highlight;
            }
            else
            {
                btn_addToCart.Enabled = false;
                btn_addToCart.Text = "Produto Indisponível";
                btn_addToCart.BackColor = Color.Gray;
            }

            this.Refresh();

        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_buyCart_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (cart.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");
                return;
            }

            sql = "insert into TBVENDAS (data_venda, id_vendedor, valor_total)" +
                " Values (@sale_date, @seller_id, @total_amount)";
            var parameters = new Dictionary<string, object>
            {
                {"@sale_date", DateTime.Now},
                {"@seller_id", Central.cpf},
                {"@total_amount", amount}
            };

            Central.ExecuteQuery(sql, parameters);

            //Arrumar
            //while (i < cart.Count)
            //{
            //    sql = "insert into TBVENDAS_PRODUTOS (id_venda, id_produto, quantidade)" +
            //        " Values (@sale_id, @product_id, @quantity)";
            //    var parameters2 = new Dictionary<string, object>
            //    {
            //        {"@sale_id", Central.GetLastSaleId()},
            //        {"@product_id", cart[i].ProductId},
            //        {"@quantity", cart[i].Quantity}
            //    };
            //    Central.ExecuteQuery(sql, parameters2);
            //    i++;
            //}

            MessageBox.Show("Compra realizada com sucesso!");
        }

        private void Btn_verifyCart_Click(object sender, EventArgs e)
        {
            Frm_VerifyCart frm_VerifyCart = new Frm_VerifyCart();
            frm_VerifyCart.Show();
        }

        private void Frm_MenuLoja_Activated(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        private bool VerifyQuantity()
        {

            if (txt_quantity.Text == "0")
            {
                MessageBox.Show("Selecione a quantidade do produto!");
                return false;
            }

            int idProduct = GetIdProduct(lbl_name.Text);
            int availableQuantity = 0, requestedQuantity = 0;

            sql = "select quantidade from TBPRODUTOS where id = @id";
            var parameters = new Dictionary<string, object>
            {
                {"@id", idProduct}
            };

            dt = Central.ExecuteQuery(sql, parameters);

            availableQuantity = Convert.ToInt32(dt.Rows[0]["quantidade"]);
            requestedQuantity = Convert.ToInt32(txt_quantity.Text);


            if (requestedQuantity > availableQuantity)
            {
                MessageBox.Show("Quantidade indisponível!");
                return false;
            }
            return true;
        }

        private int GetIdProduct(string name)
        {
            sql = "select id from TBPRODUTOS where nome = @name";
            var parameters = new Dictionary<string, object>
            {
                {"@name", name}
            };
            dt = Central.ExecuteQuery(sql, parameters);
            return Convert.ToInt32(dt.Rows[0]["id"]);


        }
    }
}

