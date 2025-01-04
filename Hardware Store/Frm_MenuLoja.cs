using System;
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
            string[] nomeCategorias;

            tc_categorias.TabPages.Clear();

            //Preenche o TabPages com a(s) categoria(s)
            for (int i = 0; i < BuscaDadosPorCategoria(out nomeCategorias); i++)
            {
                TabPage tabPage = new TabPage($"{nomeCategorias[i]}");
                tc_categorias.TabPages.Add(tabPage);

                FlowLayoutPanel flp = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true
                };

                //flp.Size = new Size(tabPage.Width, tabPage.Height);
                tabPage.Controls.Add(flp);

                for (int c = 0; c <= 200; c++)
                {
                    Button btn = new Button
                    {
                        Text = "Exemplo " + c,
                        Size = new Size(100, 30)
                    };
                    flp.Controls.Add(btn);
                }


            }

        }

        private int BuscaDadosPorCategoria(out string[] nome)
        {
            int numCategorias = 0;

            string sql = "select * from TBCATEGORIAS";
            DataTable dt = Central.Consulta(sql);

            nome = new string[dt.Rows.Count];

            foreach (DataRow row in dt.Rows)
            {
                numCategorias++;
                nome[numCategorias - 1] = (string)row["nome"];
            }

            return dt.Rows.Count;
        }

        private int BuscaDadosPorProduto(out string[] nome)
        {
            int numProdutos = 0;
            string sql = "select * from TBPRODUTOS where";
            DataTable dt = Central.Consulta(sql);
            nome = new string[dt.Rows.Count];
            foreach (DataRow row in dt.Rows)
            {
                numProdutos++;
                nome[numProdutos - 1] = (string)row["nome"];
            }
            return dt.Rows.Count;
        }
    }
}
