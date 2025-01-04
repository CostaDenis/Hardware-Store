using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                float preco = float.Parse(txt_preco.Text, CultureInfo.InvariantCulture);
                try
                {

                    var categorias = ObterCategoriasBanco();

                    if (!categorias.TryGetValue(cmb_categoria.Text, out int idCategoria))
                    {
                        throw new Exception("Categoria não encontrada!");
                    }


                    sql = "SELECT * FROM TBPRODUTOS WHERE id = " + int.Parse(txt_id.Text) + "";
                    dt = Central.Consulta(sql);
                    if (dt.Rows.Count > 0)
                    {

                        sql = $"Update TBPRODUTOS set nome = {txt_nome.Text}, preco = {preco}, id_categoria = {idCategoria}," +
                            $"descricao = {txt_descricao.Text}, foto = {pic_foto.ImageLocation} where id = {int.Parse(txt_id.Text)}";


                        Central.Consulta(sql);
                        MessageBox.Show("Produto Alterado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "Select * from TBPRODUTOS";
                        Atualizar_dgvProduto(sql);
                    }
                    else
                    {
                        sql = $"INSERT INTO TBPRODUTOS (id, nome, preco, id_categoria, descricao, foto) " +
                        $"VALUES ({int.Parse(txt_id.Text)}, '{txt_nome.Text}', '{preco}', {idCategoria}, " +
                        $"'{txt_descricao.Text}', '{pic_foto.ImageLocation}')";

                        Central.Consulta(sql);
                        MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "Select * from TBPRODUTOS";
                        Atualizar_dgvProduto(sql);
                    }
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

        private Dictionary<string, int> ObterCategoriasBanco()
        {
            Dictionary<string, int> categorias = new Dictionary<string, int>();
            sql = "Select * from TBCATEGORIAS";
            DataTable dt = Central.Consulta(sql);

            foreach (DataRow r in dt.Rows)
            {
                string nome = r["nome"].ToString();
                int id = Convert.ToInt32(r["id"]);


                if (!categorias.ContainsKey(nome))
                {
                    categorias.Add(nome, id);
                }
            }

            return categorias;

        }

        private void btn_categoria_Click(object sender, EventArgs e)
        {
            if (Checar_Campos("Categorias") == true)
            {
                sql = "SELECT * FROM TBCATEGORIAS WHERE id = " + int.Parse(txt_idCategoria.Text) + "";
                if (Central.Consulta(sql).Rows.Count > 0)
                {
                    sql = "UPDATE TBCATEGORIAS SET NOME = '" + txt_categoria.Text + "' WHERE id = " + int.Parse(txt_idCategoria.Text);
                    Central.Consulta(sql);
                    sql = "Select * from TBCATEGORIAS";
                    Atualizar_dgvCategoria(sql);
                    MessageBox.Show("Alterado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sql = "Insert into TBCATEGORIAS (id, nome) Values (" + int.Parse(txt_idCategoria.Text) + ", '" + txt_categoria.Text + "')";
                    Central.Consulta(sql);
                    MessageBox.Show("Cadastrado com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "Select * from TBCATEGORIAS";
                    Atualizar_dgvCategoria(sql);
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
                    if (txt_id.TextLength == 0 || txt_nome.TextLength == 0 || txt_preco.TextLength == 0 || cmb_categoria.Text.Length == 0 ||
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

        private void pic_foto_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\Img\\Produtos\\";
            openFileDialog1.Title = "Selecione uma foto!";
            openFileDialog1.Filter = "Imagens (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminho_foto = openFileDialog1.FileName;
                pic_foto.ImageLocation = caminho_foto;
            }
        }

        private void txt_id_Leave(object sender, EventArgs e)
        {
            sql = "Select * from TBPRODUTOS where id ='" + txt_id.Text + "'";
            dt = Central.Consulta(sql);
            if (dt.Rows.Count > 0)
            {
                btn_excluir.Visible = true;
                foreach (DataRow r in dt.Rows)
                {
                    txt_nome.Text = r["nome"].ToString();
                    txt_preco.Text = r["preco"].ToString();
                    cmb_categoria.Text = r["id_categoria"].ToString();
                    txt_descricao.Text = r["descricao"].ToString();
                    pic_foto.ImageLocation = r["foto"].ToString();
                }
                btn_CadastrarProduto.Text = "Alterar Produto";
            }
            else
            {
                Limpar_Campos("Produtos");
            }
        }

        private void txt_idCategoria_Leave(object sender, EventArgs e)
        {
            sql = "SELECT NOME FROM TBCATEGORIAS WHERE id = " + int.Parse(txt_idCategoria.Text) + "";
            dt = Central.Consulta(sql);
            if (dt.Rows.Count > 0)
            {
                object obj = dt.Rows[0][0];
                btn_excluir_Categoria.Visible = true;
                txt_categoria.Text = obj.ToString();
                btn_categoria.Text = "Alterar Categoria";
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
                    txt_nome.Text = "";
                    txt_preco.Text = "";
                    cmb_categoria.Text = "";
                    txt_descricao.Text = "";
                    pic_foto.Image = null;
                    btn_excluir.Visible = false;
                    btn_CadastrarProduto.Text = "Cadastrar Produto";
                    break;

                case "Categorias":
                    txt_categoria.Text = "";
                    btn_excluir_Categoria.Visible = false;
                    btn_categoria.Text = "Cadastrar Categoria";
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
                    Central.Consulta(sql);
                    MessageBox.Show("Produto Deletado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar_Campos("Produtos");
                    txt_id.Text = "";
                    Atualizar_dgvCategoria("select * from tbprodutos");
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
                    sql = "Delete from TBCATEGORIAS WHERE id = " + int.Parse(txt_idCategoria.Text) + "";
                    Central.Consulta(sql);
                    MessageBox.Show("Categoria Deletada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar_Campos("Categorias");
                    txt_idCategoria.Text = "";
                    Atualizar_dgvCategoria("select * from tbcategorias");
                }
                catch
                {
                    MessageBox.Show("Verifique a ID!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
