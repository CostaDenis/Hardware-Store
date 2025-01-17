using System;
using System.Collections.Generic;
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

        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (Check_Texts())
            {
                sql = "Select * from TBCONTAS where id_cpf = @cpf";
                var parameters = new Dictionary<string, object>
                {
                    { "@cpf", txt_cpf.Text }
                };

                dt = Central.ExecuteQuery(sql, parameters);


                if (dt.Rows.Count == 0)
                {
                    //insert

                    if (CheckEmail("Insert"))
                    {

                        (string hash, string salt) = Central.HashPassword(txt_password.Text);

                        sql = "INSERT INTO TBCONTAS VALUES (@cpf, @name, @password, @salt, @email, " +
                        "@access, @active)";

                        var parametersInsert = new Dictionary<string, object>
                        {
                            { "@cpf", txt_cpf.Text },
                            { "@name", txt_name.Text },
                            { "@password", hash },
                            { "@salt", salt },
                            { "@email", txt_email.Text },
                            { "@access", txt_access.Text },
                            { "@active", cmb_active.Text }
                        };

                        Central.ExecuteQuery(sql, parametersInsert);
                        MessageBox.Show("Conta Adicionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clean_Form();
                        UpdateGrid();
                    }

                }
                else
                {
                    //update

                    if (CheckEmail("Update"))
                    {

                        if (txt_password.Text != "********")
                        {

                            (string hash, string salt) = Central.HashPassword(txt_password.Text);
                            sql = "UPDATE TBCONTAS SET nome = @name, senha = @password, salt = @salt, email = @email, " +
                            "acesso = @access, ativo = @active where id_cpf = @cpf";
                            var parametersUpdate = new Dictionary<string, object>
                        {
                            { "@cpf", txt_cpf.Text },
                            { "@name", txt_name.Text },
                            { "@password", hash },
                            { "@salt", salt },
                            { "@email", txt_email.Text },
                            { "@access", txt_access.Text },
                            { "@active", cmb_active.Text }
                        };
                            Central.ExecuteQuery(sql, parametersUpdate);
                            MessageBox.Show("Conta Alterada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clean_Form();
                            UpdateGrid();

                        }
                        else
                        {
                            sql = "UPDATE TBCONTAS SET nome = @name, email = @email, " +
                            "acesso = @access, ativo = @active where id_cpf = @cpf";
                            var parametersUpdate = new Dictionary<string, object>
                            {
                                { "@cpf", txt_cpf.Text },
                                { "@name", txt_name.Text },
                                { "@email", txt_email.Text },
                                { "@access", txt_access.Text },
                                { "@active", cmb_active.Text }
                            };
                            Central.ExecuteQuery(sql, parametersUpdate);
                            MessageBox.Show("Conta Alterada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clean_Form();
                            UpdateGrid();
                        }

                    }
                }
            }
        }
        private bool Check_Texts(string operation = null)
        {
            bool resp = true;
            if (txt_access.TextLength == 0 || txt_cpf.TextLength == 0 ||
               txt_name.TextLength == 0 || txt_password.TextLength == 0 ||
               txt_email.TextLength == 0 || cmb_active.Text.Length == 0 && operation == "Insert")
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resp = false;
            }

            if (txt_cpf.TextLength != 11)
            {
                MessageBox.Show("CPF deve ter 11 digitos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resp = false;
            }
            return resp;
        }


        private void Clean_Form()
        {
            txt_access.Clear();
            txt_name.Clear();
            txt_password.Clear();
            txt_email.Clear();
            txt_cpf.Clear();
            cmb_active.ResetText();
            txt_cpf.Focus();
        }

        private void Txt_cpf_Leave(object sender, EventArgs e)
        {
            sql = "Select * from TBCONTAS where id_cpf = @cpf";
            var parameters = new Dictionary<string, object>
            {
                { "@cpf", txt_cpf.Text }
            };
            dt = Central.ExecuteQuery(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                btn_delete.Visible = true;

                foreach (DataRow row in dt.Rows)
                {

                    txt_name.Text = row["nome"].ToString();
                    txt_email.Text = row["email"].ToString();
                    txt_access.Text = row["acesso"].ToString();
                    cmb_active.Text = row["ativo"].ToString();

                }
                txt_password.Text = "********";
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

        private void Btn_up_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_access.Text) == 0)
            {
                access = int.Parse(txt_access.Text) + 1;
                txt_access.Text = Convert.ToString(access);
            }
        }

        private void Btn_down_Click(object sender, EventArgs e)
        {
            if (int.Parse(txt_access.Text) == 1)
            {
                access = int.Parse(txt_access.Text) - 1;
                txt_access.Text = Convert.ToString(access);
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


        private void Txt_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Central.VerifyTextCPF(txt_cpf, e);
        }

        private bool CheckEmail(string option)
        {
            if (!txt_email.Text.Contains("@") && !txt_email.Text.Contains(".com"))
            {
                MessageBox.Show("Email inválido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string email = txt_email.Text;
            string cpf = txt_cpf.Text;


            if (option == "Insert")
            {
                sql = $"Select * from TBCONTAS where email = '{email}'";

                dt = Central.Query(sql);

                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Email já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                sql = $"Select * from TBCONTAS where email = '{email}' and id_cpf != '{cpf}'";
                dt = Central.Query(sql);

                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Email já cadastrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        }


        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_cpf.TextLength != 11)
            {
                if (MessageBox.Show("Tem certeza que deseja excluir essa conta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "delete from TBCONTAS where id_cpf = @cpf";
                    var parameters = new Dictionary<string, object>
            {
                { "@cpf", txt_cpf.Text }
            };
                    Central.ExecuteQuery(sql, parameters);
                    Clean_Form();
                    UpdateGrid();
                }
            }
            else
            {
                MessageBox.Show("Verifique o campo do CPF!", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
