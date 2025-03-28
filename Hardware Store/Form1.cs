﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Login : Form
    {
        string sql;
        DataTable dt = new DataTable();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {

            if (txt_cpf.Text == "CPF" || txt_password.Text == "Password")
            {
                MessageBox.Show("Insira todos os dados necessários!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                sql = "Select senha, salt, acesso, ativo from TBCONTAS where id_cpf = @cpf";

                var parameters = new Dictionary<string, object>
            {
                { "@cpf", txt_cpf.Text }
            };

                dt = Central.ExecuteQuery(sql, parameters);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("CPF não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string active = dt.Rows[0]["ativo"].ToString();
                int access = int.Parse(dt.Rows[0]["acesso"].ToString());
                string storedHash = dt.Rows[0]["senha"].ToString();
                string storedSalt = dt.Rows[0]["salt"].ToString();

                if (active != "Sim")
                {
                    MessageBox.Show("Conta desativada! Entre em contato com o administrador", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Central.VerifyPassword(txt_password.Text, storedHash, storedSalt))
                {
                    Central.cpf = txt_cpf.Text;

                    switch (access)
                    {
                        case 0:
                            Frm_Menu frm_menuLoja = new Frm_Menu();
                            frm_menuLoja.Show();
                            break;

                        case 1:
                            Frm_Adm frm_adm = new Frm_Adm();
                            frm_adm.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Senha incorreta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }


        }


        private void Frm_Login_Load(object sender, EventArgs e)
        {
            SetPlaceHolderCPF(txt_cpf, txt_password, "CPF", "Password");
        }

        private void SetPlaceHolderCPF(TextBox textBoxCPF, TextBox textBoxPassword, string placeholderCPF,
                                         string placeholderPassword)
        {
            textBoxCPF.Text = placeholderCPF;
            textBoxCPF.ForeColor = Color.Gray;
            textBoxPassword.Text = placeholderPassword;
            textBoxPassword.ForeColor = Color.Gray;

            textBoxCPF.Enter += (s, e) =>
            {
                if (textBoxCPF.Text == placeholderCPF)
                {
                    textBoxCPF.Text = "";
                    textBoxCPF.ForeColor = Color.Black;
                }
            };

            textBoxCPF.Leave += (s, e) =>
            {
                if (textBoxCPF.Text.Length == 0)
                {
                    textBoxCPF.Text = placeholderCPF;
                    textBoxCPF.ForeColor = Color.Gray;
                }
            };


            textBoxPassword.Enter += (s, e) =>
            {
                if (textBoxPassword.Text == placeholderPassword)
                {
                    textBoxPassword.Text = "";
                    textBoxPassword.ForeColor = Color.Black;
                }
            };

            textBoxPassword.Leave += (s, e) =>
            {
                if (textBoxPassword.Text.Length == 0)
                {
                    textBoxPassword.Text = placeholderPassword;
                    textBoxPassword.ForeColor = Color.Gray;
                }
            };
        }

        private void Chb_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_showPasword.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void Lbl_recoverPassword_Click(object sender, EventArgs e)
        {
            Frm_RecoverPassword frm_recoverPassword = new Frm_RecoverPassword();
            frm_recoverPassword.Show();
        }

        private void Txt_cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Central.VerifyTextCPF(txt_cpf, e);
        }


    }

}
