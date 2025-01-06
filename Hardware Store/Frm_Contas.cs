using System;
using System.Data;
using System.Windows.Forms;

namespace Hardware_Store
{

    public partial class Frm_Contas : Form
    {
        DataTable dt = new DataTable();
        string sql;
        int access = 0;
        public Frm_Contas()
        {
            InitializeComponent();
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            if (Checar_Campos() == true)
            {
                sql = "SELECT * FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";

                if (Central.Query(sql).Rows.Count > 0)
                {
                    sql = "Update TBCONTAS SET NOME='" + txt_name.Text + "', SENHA='" + txt_password.Text + "', ACESSO='" +
                    txt_access.Text + "', ATIVO='" + cmb_active.Text + "' WHERE ID_CPF='" + txt_cpf.Text + "'";
                    Central.Query(sql);
                    MessageBox.Show("Conta Alterada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sql = "INSERT INTO TBCONTAS VALUES ('" + txt_cpf.Text + "', " +
                        "'" + txt_name.Text + "', '" + txt_password.Text + "', " + int.TryParse(txt_password.Text, out int r) + ", '" +
                        cmb_active.Text + "')";
                    Central.Query(sql);

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
            if (txt_access.TextLength == 0 || txt_cpf.TextLength == 0 ||
               txt_name.TextLength == 0 || txt_password.TextLength == 0 || cmb_active.Text.Length == 0)
            {
                resp = false;
            }
            return resp;
        }

        private void Limpar_Form()
        {
            txt_access.Clear();
            txt_name.Clear();
            txt_password.Clear();
            txt_cpf.Clear();
            cmb_active.ResetText();
            txt_cpf.Focus();
        }

        private void txt_cpf_Leave(object sender, EventArgs e)
        {
            sql = "SELECT * FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";
            dt = Central.Query(sql);

            if (dt.Rows.Count > 0)
            {
                btn_delete.Visible = true;
                foreach (DataRow row in dt.Rows)
                {
                    txt_name.Text = row["nome"].ToString();
                    txt_password.Text = row["senha"].ToString();
                    txt_access.Text = row["acesso"].ToString();
                    cmb_active.Text = row["ativo"].ToString();
                }
                btn_add.Text = "Alterar";
            }
            else
            {
                txt_name.Text = "";
                txt_password.Text = "";
                txt_access.Text = "0";
                btn_add.Text = "Adicionar";
                btn_delete.Visible = false;
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_access.Text) == 0)
            {
                access = int.Parse(txt_access.Text) + 1;
                txt_access.Text = Convert.ToString(access);
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_access.Text) == 1)
            {
                access = int.Parse(txt_access.Text) - 1;
                txt_access.Text = Convert.ToString(access);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_cpf.TextLength != 11)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir essa conta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "DELETE FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";
                    Central.Query(sql);
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
            dgv.DataSource = Central.Query(sql);
        }

    }
}
