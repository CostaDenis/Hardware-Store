using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_RecoverPassword : Form
    {
        string sql = "";
        string email_store = Environment.GetEnvironmentVariable("email_store");
        string password_store = Environment.GetEnvironmentVariable("senha_store");

        public Frm_RecoverPassword()
        {
            InitializeComponent();
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            sql = $"Select * from TBCONTAS where email = '{email}'";
            DataTable dt = Central.Query(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Email não encontrado");
            }
            else
            {
                MessageBox.Show($"email: {email_store}, senha: {password_store}");
                SendEmail(email, "Recuperação de senha", $"Sua senha é: {dt.Rows[0]["senha"].ToString()}");

            }
        }

        private void SendEmail(string clientEmail, string topic, string message)
        {

            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587)
                {
                    Credentials = new NetworkCredential($"{email_store}", $"{password_store}"),
                    EnableSsl = true
                };

                MailMessage email = new MailMessage()
                {
                    From = new MailAddress($"{email_store}", "Store"),
                    Subject = topic,
                    Body = message,
                    IsBodyHtml = false
                };

                email.To.Add(clientEmail);
                smtpClient.Send(email);
                MessageBox.Show("E-mail enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar o e-mail: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
