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
            CreateProductLabels(name, price, panel);
            //CreateProductPictureBox(image, flp);
            //CreateProductButton(flp);

            numberProducts++;
            pairFirst = pairFirst ? false : true;
            //MessageBox.Show($"NP: {numberProducts}, PF: {pairFirst}");
        }

        private void CreateProductLabels(string name, float price, Panel panel)
        {
            Label lblName = new Label
            {
                Text = name,
                AutoSize = true,
            };
            CalculateNewPoint(numberProducts, true, lblName, null, null, null);

            Label lblPrice = new Label
            {
                Text = price.ToString(),
                AutoSize = true
            };

            panel.Controls.Add(lblName);
            //flp.Controls.Add(lblPrice);
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

        private void CreateProductPictureBox(string image, Panel panel)
        {
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
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
