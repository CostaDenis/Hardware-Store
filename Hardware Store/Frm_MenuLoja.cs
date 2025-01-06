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
            string sql = "select nome, preco, id_categoria, descricao, foto from TBPRODUTOS";
            string nomeProduto = "";
            bool produtoExiste = false;
            DataTable dt = Central.Consulta(sql);
            int idCategoria = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                idCategoria = Convert.ToInt32(dt.Rows[i]["id_categoria"]);

                if (categorias.TryGetValue(idCategoria, out string nomeCategoria) &&
                    tabPagesMap.TryGetValue(nomeCategoria, out TabPage tabPage) &&
                    tabPage.Controls[0] is FlowLayoutPanel flp)
                {
                    nomeProduto = dt.Rows[i]["nome"].ToString();
                    produtoExiste = flp.Controls.OfType<Button>().Any(button => button.Text == nomeProduto);

                    if (!produtoExiste)
                    {
                        Button bt = new Button()
                        {
                            Text = nomeProduto,
                            Size = new Size(150, 150),
                            TextAlign = ContentAlignment.BottomCenter
                        };
                        flp.Controls.Add(bt);

                        PictureBox pictureBox = new PictureBox
                        {
                            Size = new Size(150, 150),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        string imagePath = Path.Combine(Application.StartupPath, dt.Rows[i]["foto"].ToString());

                        if (File.Exists(imagePath))
                        {
                            pictureBox.ImageLocation = imagePath; // Define a imagem no PictureBox
                        }
                        else
                        {
                            MessageBox.Show($"Imagem não encontrada: {imagePath}");
                        }
                        flp.Controls.Add(pictureBox);
                    }


                }

            }
        }

    }
}
