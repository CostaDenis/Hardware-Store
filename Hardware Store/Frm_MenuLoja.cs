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

        public Frm_MenuLoja()
        {
            InitializeComponent();
        }

        private void Frm_MenuLoja_Load(object sender, EventArgs e)
        {
            //PreencheProdutos(1);
            string[] nomeCategorias = BuscaNomeCategoria();
            int numCategorias = nomeCategorias.Length;

            tc_categorias.TabPages.Clear();

            //Preenche o TabPages com a(s) categoria(s)
            for (int i = 0; i < numCategorias; i++)
            {
                TabPage tabPage = new TabPage($"{nomeCategorias[i]}");
                tc_categorias.TabPages.Add(tabPage);

                FlowLayoutPanel flp = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };
                tabPage.Controls.Add(flp);
                PreencheProdutos();
                //for (int c = 0; c <= 10; c++)
                //{
                //    PictureBox pb = new PictureBox
                //    {
                //        Size = new Size(150, 150),
                //        Image = Image.FromFile(Application.StartupPath + "\\Img\\Produtos\\mouse_pad.jpg")
                //    };
                //    flp.Controls.Add(pb);
                //}


            }

        }

        private int BuscaQTDECategoria()
        {
            string sql = "select * from TBCATEGORIAS";
            DataTable dt = Central.Consulta(sql);

            return dt.Rows.Count;
        }

        private string[] BuscaNomeCategoria()
        {
            string sql = "select nome from TBCATEGORIAS";
            DataTable dt = Central.Consulta(sql);
            string[] nome = new string[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nome[i] = dt.Rows[i]["nome"].ToString();
            }
            return nome;
        }

        private void PreencheProdutos()
        {
            Dictionary<int, string> categorias = Central.ObterCategoriasIdParaNome();
            var tabPagesMap = tc_categorias.TabPages.Cast<TabPage>()
                .ToDictionary(tabPage => tabPage.Text, tabPage => tabPage);
            string sql = "select Distinct id, nome, preco, id_categoria, descricao, foto from TBPRODUTOS";
            string productName = "", productPicture = "";
            float productPrice = 0.0f;
            int productId = 0;
            DataTable dt = Central.Consulta(sql);
            //List<string> productsAdded = new List<string
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
                    tabPage.Controls[0] is FlowLayoutPanel flp)
                {

                    if (!productsIdAdded.Contains(productId))
                    {
                        productsIdAdded.Add(productId);
                        AddProduct(productName, productPrice, productPicture, flp);
                    }

                }

            }
        }

        private void AddProduct(string name, float price, string image, FlowLayoutPanel flp)
        {
            CreateProductLabels(name, price, flp);
            CreateProductPictureBox(image, flp);
            CreateProductButton(flp);
        }

        private void CreateProductButton(FlowLayoutPanel flp)
        {
            Button bt = new Button()
            {
                Text = "Adicionar ao carrinho",
                AutoSize = true,
                TextAlign = ContentAlignment.BottomCenter
            };
            flp.Controls.Add(bt);
        }

        private void CreateProductLabels(string name, float price, FlowLayoutPanel flp)
        {
            Label lblName = new Label
            {
                Text = name,
                AutoSize = true
            };


            Label lblPrice = new Label
            {
                Text = price.ToString(),
                AutoSize = true
            };


            flp.Controls.Add(lblName);
            flp.Controls.Add(lblPrice);
        }

        private void CreateProductPictureBox(string image, FlowLayoutPanel flp)
        {
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(150, 150),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            string imagePath = Path.Combine(Application.StartupPath, image);
            if (File.Exists(imagePath))
            {
                pictureBox.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show($"Imagem não encontrada: {imagePath}");
            }
            flp.Controls.Add(pictureBox);
        }

    }
}
