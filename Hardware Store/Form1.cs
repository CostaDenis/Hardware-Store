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
            if (txt_cpf.Text.Length == 0 || txt_cpf.Text.Length == 0)
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

            }
        }
    }
}
