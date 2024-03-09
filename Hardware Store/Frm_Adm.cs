using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Adm : Form
    {
        public Frm_Adm()
        {
            InitializeComponent();
        }

        private void btn_contas_Click(object sender, EventArgs e)
        {
            Frm_Contas frm_contas = new Frm_Contas();
            frm_contas.Show();
        }

        private void btn_produtos_Click(object sender, EventArgs e)
        {
            Frm_Gerenciar_Produtos frm_gerenciar_produtos = new Frm_Gerenciar_Produtos();
            frm_gerenciar_produtos.Show();
        }
    }
}
