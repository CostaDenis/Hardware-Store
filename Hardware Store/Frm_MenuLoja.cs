using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            string sql = "select nome, preco, id_categoria, descricao, foto from TBPRODUTOS";
            DataTable dt = Central.Consulta(sql);
            int idCategoria = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                idCategoria = Convert.ToInt32(dt.Rows[i]["id_categoria"]);

                if (categorias.TryGetValue(idCategoria, out string nomeCategoria))
                {
                    for (int c = 0; c < tc_categorias.TabPages.Count; c++)
                    {
                        if (tc_categorias.TabPages[c].Text == nomeCategoria)
                        {

                            //Teste
                            FlowLayoutPanel flp = (FlowLayoutPanel)tc_categorias.TabPages[c].Controls[0];
                            Button bt = new Button()
                            {
                                Text = dt.Rows[i]["nome"].ToString(),
                                Size = new Size(150, 150),
                                TextAlign = ContentAlignment.BottomCenter
                            };
                            flp.Controls.Add(bt);
                        }
                    }

                }

            }
        }
    }
}
