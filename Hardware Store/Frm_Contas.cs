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
            string cpf = txt_cpf.Text;
            string name = txt_name.Text;
            string password = Central.EncryptData(txt_password.Text, Central.CheckDataBaseKey());
            string email = txt_email.Text;
            int access = int.Parse(txt_access.Text);
            string active = cmb_active.Text;

            if (Checar_Campos() == true)
            {
                sql = "SELECT * FROM TBCONTAS WHERE ID_CPF='" + txt_cpf.Text + "'";

                if (Central.Query(sql).Rows.Count > 0)
                {
                    string passwordCrypt = Central.EncryptData(txt_password.Text, Central.CheckDataBaseKey());

                    sql = $"Update TBCONTAS SET nome ='{txt_name.Text}', senha ='{passwordCrypt}', acesso =" +
                    $"'{access}', ativo ='{active}' WHERE id_cpf='{cpf}'";

                    Central.Query(sql);
                    MessageBox.Show("Conta Alterada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                }
                else
                {

                    if (CheckEmail())
                    {
                        sql = $"INSERT INTO TBCONTAS VALUES ('{cpf}', " +
                        $" '{name}', '{password}', '{email}', '{access}', " +
                        $"'{active}')";
                        Central.Query(sql);

                        MessageBox.Show("Conta Adicionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpar_Form();
                        UpdateGrid();
                    }
                    else
                    {
                        MessageBox.Show("Email já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
               txt_name.TextLength == 0 || txt_password.TextLength == 0 ||
               txt_email.TextLength == 0 || cmb_active.Text.Length == 0)
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
            txt_email.Clear();
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
                    try
                    {
                        string passwordCrypt = row["senha"].ToString();

                        if (Central.IsBase64String(passwordCrypt))
                        {
                            string password = Central.DecryptData(passwordCrypt, Central.CheckDataBaseKey());
                            txt_password.Text = password;
                        }
                        else
                        {
                            MessageBox.Show("O email armazenado não está no formato esperado.");
                            txt_email.Text = "";
                        }

                        txt_name.Text = row["nome"].ToString();
                        txt_email.Text = row["email"].ToString();
                        txt_access.Text = row["acesso"].ToString();
                        cmb_active.Text = row["ativo"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao descriptografar o email: {ex.Message}");
                    }
                }

                btn_add.Text = "Alterar";
            }
            else
            {
                txt_name.Text = "";
                txt_password.Text = "";
                txt_email.Text = "";
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
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            sql = "Select * from TBCONTAS";
            dgv.DataSource = Central.Query(sql);
        }


        private void txt_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_cpf.TextLength > 11)
            {
                e.Handled = true;
                MessageBox.Show("CPF deve ter 11 digitos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            if (txt_email.Text.Contains("@") && txt_email.Text.Contains(".com"))
            {
                MessageBox.Show("Email válido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email inválido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckEmail()
        {
            string email = txt_email.Text;

            sql = $"Select * from TBCONTAS where email = '{email}'";

            dt = Central.Query(sql);

            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
