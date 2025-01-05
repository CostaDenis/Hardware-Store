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
            //PreencheProdutos(1);
            int numCategorias = BuscaQTDECategoria();
            string[] nomeCategorias = BuscaNomeCategoria();

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

                //flp.Size = new Size(tabPage.Width, tabPage.Height);
                tabPage.Controls.Add(flp);

                //PreencheProdutos(nomeCategorias[i], 10);

                for (int c = 0; c <= 10; c++)
                {
                    //Button btn = new Button
                    //{
                    //    Text = "Exemplo " + c,
                    //    Size = new Size(100, 30)
                    //};

                    PictureBox pb = new PictureBox
                    {
                        Size = new Size(150, 150),
                        Image = Image.FromFile(Application.StartupPath + "\\Img\\Produtos\\mouse_pad.jpg")
                    };
                    flp.Controls.Add(pb);
                }


            }

        }

        //private int BuscaDadosCategoria(out string[] nome) //Retorna o nome das categorias
        //{
        //    int numCategorias = 0;

        //    string sql = "select * from TBCATEGORIAS";
        //    DataTable dt = Central.Consulta(sql);

        //    nome = new string[dt.Rows.Count];

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        numCategorias++;
        //        nome[numCategorias - 1] = (string)row["nome"];
        //    }

        //    return dt.Rows.Count;  //Retorna a quantidade de categorias
        //}

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

        private void PreencheProdutos(int id)
        {
            string sql = $"select id_categoria from TBPRODUTOS " +
                $"INNER JOIN TBCATEGORIAS on TBCATEGORIAS.id = TBPRODUTOS.id";
            DataTable dt = Central.Consulta(sql);
            MessageBox.Show(dt.Rows.Count.ToString());

        }
    }
}
