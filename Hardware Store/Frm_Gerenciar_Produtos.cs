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
    public partial class Frm_Gerenciar_Produtos : Form
    {
        public Frm_Gerenciar_Produtos()
        {
            InitializeComponent();
        }

        private void btn_CadastrarProduto_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Produtos") == true)
            {

            }
            else
            {
                MessageBox.Show("Complete todos os campos antes de cadastrar!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool Checar_Campos(string tipo)
        {
            bool resp = true;

            switch (tipo)
            {
                case "Produtos":
                    if (txt_nome.TextLength == 0 || txt_preco.TextLength == 0 || cmb_categoria.Text.Length == 0 ||
                        txt_descricao.TextLength == 0 || pic_foto.Image == null)
                    {
                        resp = false;
                    }
                    break;

                case "Categorias":
                    if (txt_idCategoria.TextLength == 0 || txt_categoria.TextLength == 0)
                    {
                        resp = false;
                    }
                    break;
            }
            return resp;
        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Categoria") == true)
            {

            }
            else
            {
                MessageBox.Show("Complete todos os campos antes de cadastrar!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
