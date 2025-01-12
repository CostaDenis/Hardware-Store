using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_Login : Form
    {
        Frm_Adm frm_adm = new Frm_Adm();
        string sql;
        DataTable dt = new DataTable();

        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            /*     if (txt_cpf.Text.Length == 0 || txt_cpf.Text.Length == 0)
                 {
                     MessageBox.Show("Insira todos os dados necessários!");
                 }
                 else
                 {
                     sql = "SELECT * FROM TBCONTAS WHERE ID_CPF=" + txt_cpf.Text + " AND SENHA='" + txt_senha.Text + "'";
                     dt = Central.Consulta(sql);

                     if (dt.Rows.Count == 0)
                     {
                         MessageBox.Show("Credenciais não compatíveis! Tente Novamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                     else
                     {
                         frm_adm.Show();
                     }
            */
            frm_adm.Show();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            SetPlaceHolderCPF(txt_cpf, txt_senha, "CPF", "Password");
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

    }

}
