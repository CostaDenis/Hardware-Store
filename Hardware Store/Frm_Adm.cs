using System;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Adm : Form
    {
        public Frm_Adm()
        {
            InitializeComponent();
        }

        private void Pb_accounts_Click(object sender, EventArgs e)
        {
            Frm_Contas frm_contas = new Frm_Contas();
            frm_contas.Show();
        }

        private void Pb_products_Click(object sender, EventArgs e)
        {
            Frm_Gerenciar_Produtos frm_gerenciar_produtos = new Frm_Gerenciar_Produtos();
            frm_gerenciar_produtos.Show();
        }

        private void Pb_store_Click(object sender, EventArgs e)
        {
            Frm_MenuLoja frm_menuloja = new Frm_MenuLoja();
            frm_menuloja.Show();
        }
    }
}
