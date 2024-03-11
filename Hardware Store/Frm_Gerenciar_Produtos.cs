using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Gerenciar_Produtos : Form
    {
        string sql;
        DataTable dt;
        string caminho_foto;
        public Frm_Gerenciar_Produtos()
        {
            InitializeComponent();
        }

        private void btn_CadastrarProduto_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Produtos") == true)
            {
                sql = "select * from TBPRODUTOS where id_produto = " + int.TryParse(txt_id.Text, out int id) + "";
                if(Conferir_Disponibilidade(sql) == true)
                {
                    sql = "Insert into TBPRODUTOS VALUES (" + int.TryParse(txt_id.Text, out int r) + ", " +
                    "'" + txt_nome.Text + "', " + float.TryParse(txt_preco.Text, out float preco) + ", " +
                    " '" + cmb_categoria.Text + "', '" + txt_descricao.Text + "', '" + pic_foto.ImageLocation + "')";
                    Central.Consulta(sql);
                    MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "Select * from TBPRODUTOS";
                    Atualizar_dgvProduto(sql);
                } else
                {
                    MessageBox.Show("ID de Produto já usado!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
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
                sql = "Select * from TBCATEGORIAS WHERE id_categoria = " + int.TryParse(txt_idCategoria.Text, out int categoria) + "";
                if (Conferir_Disponibilidade(sql) == true)
                {
                    sql = "Insert into TBCATEGORIAS (id_categoria, nome) Values (" + int.TryParse(txt_idCategoria.Text, out int c) + ", '" + txt_categoria.Text + "')";
                    Central.Consulta(sql);
                    MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "Select * from TBCATEGORIAS";
                    Atualizar_dgvCategoria(sql);
                } else
                {
                    MessageBox.Show("ID de Categoria já usado!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Complete todos os campos antes de cadastrar!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Atualizar_dgvCategoria(string s)
        {
            dgv_categoria.DataSource = Central.Consulta(s);
        }

        private void Atualizar_dgvProduto(string s)
        {
            dgv_produto.DataSource = Central.Consulta(s);
        }

        private void Frm_Gerenciar_Produtos_Load(object sender, EventArgs e)
        {
            //Povoando DGV de Categorias e a ComboBox
            sql = "Select * from TBCATEGORIAS";
            Atualizar_dgvCategoria(sql);
            dt = Central.Consulta(sql);
            foreach (DataRow categorias in dt.Rows)
            {
                cmb_categoria.Items.Add(categorias["nome"]);
            }

            //Povoando o DGV de Produtos
            sql = "Select * from TBPRODUTOS";
            Atualizar_dgvProduto(sql);

        }
        private bool Conferir_Disponibilidade(string consulta)
        {
            DataTable dataTable = new DataTable();
            bool resp = true;

            dataTable = Central.Consulta(consulta);
            if (dataTable.Rows.Count > 0)
            {
                resp = false;
            }
            return resp;
        }

        private void pic_foto_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Img\\Produtos\\";
            openFileDialog1.Title = "Selecione uma foto!";
            openFileDialog1.Filter = "Imagens (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminho_foto = openFileDialog1.FileName;
                pic_foto.ImageLocation = caminho_foto;
            }
        }

        private void txt_id_Leave(object sender, EventArgs e)
        {
            sql = "Select * from TBPRODUTOS where id_produto ='" + txt_id.Text + "'";
            dt = Central.Consulta(sql);
            if (dt.Rows.Count > 0)
            {
                btn_excluir.Visible = true;
                foreach(DataRow r in dt.Rows)
                {
                    txt_nome.Text = r["nome"].ToString();
                    txt_preco.Text = r["preco"].ToString();
                    cmb_categoria.Text = r["categoria"].ToString();
                    txt_descricao.Text = r["descricao"].ToString();
                    pic_foto.ImageLocation = r["foto"].ToString();
                }
                btn_CadastrarProduto.Text = "Alterar Produto";
            } else {
                txt_nome.Text = "";
                txt_preco.Text = "";
                cmb_categoria.Text = "";
                txt_descricao.Text = "";
                pic_foto.Image = null;
                btn_excluir.Visible = false;
            }
        }
    }
}
