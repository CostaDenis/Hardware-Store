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
        int numberProducts = 0;
        bool pairFirst = true;
        int index = 0;

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
        }

        private void AddProduct(string name, float price, string image, Panel panel)
        {

            //CreateProductPictureBox(image, CreateProductLabelsTop(name, price, panel), panel);
            PictureBox pb = CreateProductPictureBox(image, panel);
            CreateProductLabelsTop(name, pb, panel, index);
            CreateProductLabelsBottom(price, pb, panel, index);
            //CreateProductButton(flp);

            //numberProducts++;
            //pairFirst = pairFirst ? false : true;
            //MessageBox.Show($"NP: {numberProducts}, PF: {pairFirst}");
            index++;
        }

        private void CreateProductLabelsTop(string name, PictureBox pb, Panel panel, int index)
        {
            Label lblName = new Label
            {
                Text = name,
                Name = $"lblName_{index}",
                AutoSize = true,
            };

            panel.Controls.Add(lblName);

            int centerX = pb.Left + pb.Width / 2;
            int labelTop = pb.Top - lblName.Height - 10;

            lblName.Left = centerX - lblName.Width / 2;
            lblName.Top = labelTop;

        }

        private void CreateProductLabelsBottom(float price, PictureBox pb, Panel panel, int index)
        {
            Label lblPrice = new Label
            {
                Text = price.ToString(),
                Name = $"lblPrice_{index}",
                AutoSize = true
            };

            panel.Controls.Add(lblPrice);

            int centerX = pb.Left + pb.Width / 2;
            int labelTop = pb.Top - lblPrice.Bottom + 170;

            lblPrice.Left = centerX - lblPrice.Width / 2;
            lblPrice.Top = labelTop;

        }

        private PictureBox CreateProductPictureBox(string image, Panel panel)
        {
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                Location = new Point(100, 54), //Teste
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            string imagePath = Path.Combine(Application.StartupPath + "\\", image);
            if (File.Exists(imagePath))
            {
                pictureBox.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show($"Imagem não encontrada: {imagePath}");
            }
            panel.Controls.Add(pictureBox);

            return pictureBox;

        }

        private void CreateProductButton(Panel panel)
        {
            Button bt = new Button()
            {
                Text = "Adicionar ao carrinho",
                AutoSize = true,
                TextAlign = ContentAlignment.BottomCenter,

            };
            panel.Controls.Add(bt);
        }


        //Parametros opcionais com controls
        private void CalculateNewPoint(int numberProduct, bool pairFirst,
           Label lblname = null,
           Label lblPrice = null,
           PictureBox pb = null,
           Button btn = null)
        {
            List<Control> controlsList = new List<Control> { lblname, lblPrice, pb, btn };

            foreach (Control control in controlsList)
            {

                if (control != null)
                {
                    Point location = Point.Empty;

                    if (pairFirst)
                    {

                        switch (numberProduct)
                        {
                            case 1:
                                location = new Point(172, 54);
                                break;
                            case 2:
                                location = new Point(430, 54);
                                break;
                            case 3:
                                location = new Point(693, 54);
                                break;
                        }
                    }
                    else
                    {
                        switch (numberProduct)
                        {
                            case 1:
                                location = new Point(172, 100);
                                break;
                            case 2:
                                location = new Point(430, 100);
                                break;
                            case 3:
                                location = new Point(693, 100);
                                break;
                        }
                    }
                    MessageBox.Show($"Setting location of {control.GetType().Name} to {location}");
                    control.Location = location;


                }
            }

        }


    }
}
