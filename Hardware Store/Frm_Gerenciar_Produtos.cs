using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Gerenciar_Produtos : Form
    {
        string sql;
        DataTable dt;
        string caminho_foto;
        string relativePath;
        Dictionary<string, int> categoriasId = Central.ObterCategoriasNomeParaId();
        Dictionary<int, string> categoriasName = Central.ObterCategoriasIdParaNome();
        public Frm_Gerenciar_Produtos()
        {
            InitializeComponent();
        }

        private void btn_CadastrarProduto_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Produtos") == true)
            {
                string productName = txt_name.Text;
                string productDescription = txt_description.Text;
                int quantityProduct = int.Parse(txt_quantity.Text);

                if (pic_picture.Image != null)
                {
                    relativePath = pic_picture.ImageLocation;
                }

                try
                {
                    float preco = float.Parse(txt_price.Text, CultureInfo.InvariantCulture);

                    if (!categoriasId.TryGetValue(cmb_category.Text, out int idCategory))
                    {
                        throw new Exception("Categoria não encontrada!");
                    }

                    if (!int.TryParse(txt_id.Text, out int idProduct))
                    {
                        throw new Exception("ID do produto inválido!");
                    }


                    sql = $"SELECT * FROM TBPRODUTOS WHERE id = {idProduct}";
                    dt = Central.Query(sql);
                    if (dt.Rows.Count > 0)
                    {

                        sql = $"Update TBPRODUTOS set nome = '{productName}', preco = '{preco}', quantidade = '{quantityProduct}', id_categoria = '{idCategory}'," +
                            $"descricao = '{productDescription}', foto = '{relativePath}' where id = '{idProduct}'";


                        Central.Query(sql);
                        MessageBox.Show("Produto Alterado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "Select * from TBPRODUTOS";
                        Atualizar_dgvProduto(sql);
                    }
                    else
                    {
                        sql = $"INSERT INTO TBPRODUTOS (id, nome, preco, quantidade, id_categoria, descricao, foto) " +
                        $"VALUES ({idProduct}, '{productName}', '{preco}', '{quantityProduct}', {idCategory}, " +
                        $"'{productDescription}', '{relativePath}')";

                        Central.Query(sql);
                        MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "Select * from TBPRODUTOS";
                        Atualizar_dgvProduto(sql);
                        Limpar_Campos("Produtos");
                    }
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Digite um dado válido para o id/preço!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Erro!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Complete todos os campos antes de cadastrar!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Categorias") == true)
            {
                sql = "SELECT * FROM TBCATEGORIAS WHERE id = " + int.Parse(txt_idcategory.Text) + "";
                if (Central.Query(sql).Rows.Count > 0)
                {
                    sql = "UPDATE TBCATEGORIAS SET NOME = '" + txt_category.Text + "' WHERE id = " + int.Parse(txt_idcategory.Text);
                    Central.Query(sql);
                    sql = "Select * from TBCATEGORIAS";
                    Atualizar_dgvCategoria(sql);
                    MessageBox.Show("Alterado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sql = "Insert into TBCATEGORIAS (id, nome) Values (" + int.Parse(txt_idcategory.Text) + ", '" + txt_category.Text + "')";
                    Central.Query(sql);
                    MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "Select * from TBCATEGORIAS";
                    Atualizar_dgvCategoria(sql);
                    Limpar_Campos("Categorias");
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
                    if (txt_id.TextLength == 0 || txt_name.TextLength == 0 || txt_price.TextLength == 0 || cmb_category.Text.Length == 0 ||
                        txt_quantity.TextLength == 0 || txt_description.TextLength == 0 || pic_picture.Image == null)
                    {
                        resp = false;
                    }
                    break;

                case "Categorias":
                    if (txt_idcategory.TextLength == 0 || txt_category.TextLength == 0)
                    {
                        resp = false;
                    }
                    break;
            }
            return resp;
        }

        private void Atualizar_dgvCategoria(string s)
        {
            dgv_category.DataSource = Central.Query(s);
        }

        private void Atualizar_dgvProduto(string s)
        {
            dgv_products.DataSource = Central.Query(s);
        }

        private void Frm_Gerenciar_Produtos_Load(object sender, EventArgs e)
        {
            //Povoando DGV de Categorias e a ComboBox
            sql = "Select * from TBCATEGORIAS";
            Atualizar_dgvCategoria(sql);
            dt = Central.Query(sql);
            foreach (DataRow categorias in dt.Rows)
            {
                cmb_category.Items.Add(categorias["nome"]);
            }

            //Povoando o DGV de Produtos
            sql = "Select * from TBPRODUTOS";
            Atualizar_dgvProduto(sql);

        }

        private void pic_foto_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Img\\Produtos\\";
            openFileDialog1.Title = "Selecione uma foto!";
            openFileDialog1.Filter = "Imagens (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminho_foto = openFileDialog1.FileName;
                pic_picture.ImageLocation = caminho_foto;
                relativePath = $"Img\\Produtos\\{Path.GetFileName(caminho_foto)}";
            }
        }

        private void txt_id_Leave(object sender, EventArgs e)
        {
            sql = "Select * from TBPRODUTOS where id ='" + txt_id.Text + "'";
            dt = Central.Query(sql);
            if (dt.Rows.Count > 0)
            {
                btn_deleteproduct.Visible = true;
                foreach (DataRow r in dt.Rows)
                {
                    txt_name.Text = r["nome"].ToString();
                    txt_price.Text = r["preco"].ToString();
                    txt_quantity.Text = r["quantidade"].ToString();
                    if (categoriasName.TryGetValue(int.Parse(r["id_categoria"].ToString()), out string categoria))
                    {
                        cmb_category.Text = categoria;
                    }
                    txt_description.Text = r["descricao"].ToString();
                    pic_picture.ImageLocation = r["foto"].ToString();
                }
                btn_addproduct.Text = "Alterar Produto";
            }

        }

        private void txt_idCategoria_Leave(object sender, EventArgs e)
        {
            sql = "SELECT NOME FROM TBCATEGORIAS WHERE id = " + int.Parse(txt_idcategory.Text) + "";
            dt = Central.Query(sql);
            if (dt.Rows.Count > 0)
            {
                object obj = dt.Rows[0][0];
                btn_delete_category.Visible = true;
                txt_category.Text = obj.ToString();
                btn_addcategory.Text = "Alterar Categoria";
            }
            else
            {
                Limpar_Campos("Categorias");
            }
        }

        private void Limpar_Campos(string campos)
        {
            switch (campos)
            {
                case "Produtos":
                    txt_id.Text = "";
                    txt_name.Text = "";
                    txt_price.Text = "";
                    cmb_category.SelectedIndex = -1;
                    txt_quantity.Text = "";
                    txt_description.Text = "";
                    pic_picture.Image = null;
                    btn_deleteproduct.Visible = false;
                    btn_addproduct.Text = "Cadastrar Produto";
                    break;

                case "Categorias":
                    txt_idcategory.Text = "";
                    txt_category.Text = "";
                    btn_delete_category.Visible = false;
                    btn_addcategory.Text = "Cadastrar Categoria";
                    break;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você está prestes a excluir esse produto da base de dados! Deseja Continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sql = "Delete from TBPRODUTOS WHERE id = " + int.Parse(txt_id.Text) + "";
                    Central.Query(sql);
                    MessageBox.Show("Produto Deletado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar_Campos("Produtos");
                    txt_id.Text = "";
                    Atualizar_dgvProduto("select * from tbprodutos");
                }
                catch
                {
                    MessageBox.Show("Verifique a ID!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_excluir_Categoria_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você está prestes a excluir essa categoria da base de dados! Deseja Continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    sql = "Delete from TBCATEGORIAS WHERE id = " + int.Parse(txt_idcategory.Text) + "";
                    Central.Query(sql);
                    MessageBox.Show("Categoria Deletada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar_Campos("Categorias");
                    txt_idcategory.Text = "";
                    Atualizar_dgvCategoria("select * from tbcategorias");
                }
                catch
                {
                    MessageBox.Show("Verifique a ID!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CheckForNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForNumbers(sender, e);
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForNumbers(sender, e);
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckForNumbers(sender, e);
        }
    }
}
