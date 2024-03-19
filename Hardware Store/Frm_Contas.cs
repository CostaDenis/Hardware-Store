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

    public partial class Frm_Contas : Form
    {
        DataTable dt = new DataTable();
        string sql;
        int acesso;
        public Frm_Contas()
        {
            InitializeComponent();
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (Checar_Campos() == true)
            {
                sql = "SELECT * FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";

                if (Central.Consulta(sql).Rows.Count > 0)
                {
                    sql = "Update TBCONTAS SET NOME='" + txt_nome.Text + "', SENHA='" + txt_senha.Text + "', ACESSO='" +
                    txt_acesso.Text + "', ATIVO='" + cmb_ativo.Text + "' WHERE ID_CPF='" + txt_cpf.Text + "'";
                    Central.Consulta(sql);
                    MessageBox.Show("Conta Alterada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sql = "INSERT INTO TBCONTAS VALUES ('" + txt_cpf.Text + "', " +
                        "'" + txt_nome.Text + "', '" + txt_senha.Text + "', " + int.TryParse(txt_senha.Text, out int r) + ", '" +
                        cmb_ativo.Text + "')";
                    Central.Consulta(sql);

                    MessageBox.Show("Conta Adicionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar_Form();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private bool Checar_Campos()
        {
            bool resp = true;
            if (txt_acesso.TextLength == 0 || txt_cpf.TextLength == 0 ||
               txt_nome.TextLength == 0 || txt_senha.TextLength == 0 || cmb_ativo.Text.Length == 0)
            {
                resp = false;
            }
            return resp;
        }

        private void Limpar_Form()
        {
            txt_acesso.Clear();
            txt_nome.Clear();
            txt_senha.Clear();
            txt_cpf.Clear();
            cmb_ativo.ResetText();
            txt_cpf.Focus();
        }

        private void txt_cpf_Leave(object sender, EventArgs e)
        {
            sql = "SELECT * FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";
            dt = Central.Consulta(sql);

            if (dt.Rows.Count > 0)
            {
                btn_excluir.Visible = true;
                foreach (DataRow row in dt.Rows)
                {
                    txt_nome.Text = row["nome"].ToString();
                    txt_senha.Text = row["senha"].ToString();
                    txt_acesso.Text = row["acesso"].ToString();
                    cmb_ativo.Text = row["ativo"].ToString();
                }
                btn_adicionar.Text = "Alterar";
            }
            else
            {
                txt_nome.Text = "";
                txt_senha.Text = "";
                txt_acesso.Text = "0";
                btn_adicionar.Text = "Adicionar";
                btn_excluir.Visible = false;
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_acesso.Text) == 0)
            {
                acesso = int.Parse(txt_acesso.Text) + 1;
                txt_acesso.Text = Convert.ToString(acesso);
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_acesso.Text) == 1)
            {
                acesso = int.Parse(txt_acesso.Text) - 1;
                txt_acesso.Text = Convert.ToString(acesso);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_cpf.TextLength != 11)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir essa conta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";
                    Central.Consulta(sql);
                    Limpar_Form();
                }
            }
            else
            {
                MessageBox.Show("Verifique o campo do CPF!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void Frm_Contas_Load(object sender, EventArgs e)
        {
               sql = "Select * from TBCONTAS";
               dgv.DataSource = Central.Consulta(sql);   
        }

    }
}
