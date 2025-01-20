using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_MenuLoja : Form
    {
        List<int> productsIdAdded = new List<int>();
        bool pairFirst = false;
        int index = 0, nextIndexCol = 3, indexCol = 1;

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
            string sql = "select Distinct id, nome, preco, id_categoria, descricao, foto from TBPRODUTOS";
            string productName = "", productPicture = "";
            float productPrice = 0.0f;
            int productId = 0;
            DataTable dt = Central.Query(sql);
            int idCategoria = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                productId = Convert.ToInt32(dt.Rows[i]["id"]);
                productName = dt.Rows[i]["nome"].ToString().Trim();
                idCategoria = Convert.ToInt32(dt.Rows[i]["id_categoria"]);
                productPrice = float.Parse(dt.Rows[i]["preco"].ToString());
                productPicture = dt.Rows[i]["foto"].ToString();

                if (categorias.TryGetValue(idCategoria, out string nomeCategoria) &&
                    tabPagesMap.TryGetValue(nomeCategoria, out TabPage tabPage) &&
                    tabPage.Controls[0] is Panel panel)
                {

                    if (!productsIdAdded.Contains(productId))
                    {
                        productsIdAdded.Add(productId);
                        AddProduct(productName, productPrice, productPicture, panel);
                    }

                }

            }
            pairFirst = !pairFirst;
        }

        private void AddProduct(string name, float price, string image, Panel panel)
        {


            if (index == nextIndexCol)
            {
                indexCol++;
                index = 0;
            }
            index++;

            PictureBox pb = CreateProductPictureBox(image, panel, name, price.ToString());
            Label lblName = CreateProductLabelsTop(name, pb, panel, index);
            Label lblPrice = CreateProductLabelsBottom(price, pb, panel, index);
            Button btn = CreateProductButton(panel, lblPrice);

        }

        private Label CreateProductLabelsTop(string name, PictureBox pb, Panel panel, int index)
        {
            Label lblName = new Label
            {
                Text = name,
                Name = $"lblName_{index}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

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

        private Label CreateProductLabelsBottom(float price, PictureBox pb, Panel panel, int index)
        {
            Label lblPrice = new Label
            {
                Text = price.ToString(),
                Name = $"lblPrice_{index}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

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
                labelTop = pb.Top + pb.Height + 20;
            }
            int centerX = pb.Left + pb.Width / 2;
            //int labelTop = pb.Top - lbl.Bottom + 170;

            lbl.Left = centerX - lbl.Width / 2;
            lbl.Top = labelTop;
        }

        private PictureBox CreateProductPictureBox(string image, Panel panel, string name, string price)
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
                SelectProduct(imagePath, name, price);
            };


            panel.Controls.Add(pictureBox);

            return pictureBox;

        }

        private Button CreateProductButton(Panel panel, Label lblBottom)
        {
            Button btn = new Button()
            {
                Text = "Adicionar ao carrinho",
                AutoSize = true,
                TextAlign = ContentAlignment.BottomCenter,
                Font = new Font("Arial", 12, FontStyle.Regular),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Highlight
            };
            panel.Controls.Add(btn);

            int centerX = lblBottom.Left + lblBottom.Width / 2;
            int labelTop = lblBottom.Top - btn.Bottom + 50;

            btn.Left = centerX - btn.Width / 2;
            btn.Top = labelTop;

            return btn;
        }


        private Point CalculateNewPoint(int numberProduct, int indexCol, PictureBox pb)
        {
            const int horizontalSpacing = 200;
            const int verticalSpacing = 100;
            const int initialX = 80;

            int totalHeight = pb.Height + verticalSpacing;
            int posX = initialX + (numberProduct - 1) * horizontalSpacing;
            int posY = (indexCol - 1) * totalHeight + 60;

            return new Point(posX, posY);
        }

        private void SelectProduct(string picLocation, string name, string price)
        {
            if (File.Exists(picLocation))
            {
                pb_imageProduct.ImageLocation = picLocation;
            }
            else
            {
                MessageBox.Show("Imagem não encontrada!");
            }

            //Arrumar bug do preço
            lbl_name.Text = name;
            lbl_name.Visible = true;
            CenterLabelTop(pb_imageProduct, lbl_name);

            lbl_price.Text = price;
            lbl_price.Visible = true;
            CenterLabelBottom(pb_imageProduct, lbl_price, "Select");

            this.Refresh();

        }


    }
}
