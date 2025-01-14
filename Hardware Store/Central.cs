using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Hardware_Store
{
    internal class Central
    {

        private static SQLiteConnection connection;

        public static string CheckDataBaseKey()
        {
            string key = Environment.GetEnvironmentVariable("CATELOGIC_DB_KEY", EnvironmentVariableTarget.User);

            if (!string.IsNullOrEmpty(key))
            {
                return key;
            }
            else
            {
                string newKey = CreateDataBaseKey();

                Environment.SetEnvironmentVariable("CATELOGIC_DB_KEY", newKey, EnvironmentVariableTarget.User);

                MessageBox.Show("Chave de criptografia gerada com sucesso nas variáveis de ambiente do seu usuário! NÃO A EXCLUA, pois ela será necessária para acessar o banco de dados.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return newKey;
            }
        }

        public static string CreateDataBaseKey()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                string key = Convert.ToBase64String(aes.Key);

                return Convert.ToBase64String(aes.Key);
            }
        }

        public static string EncryptData(string sql, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = new byte[16];
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(sql);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string DecryptData(string sql, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = new byte[16];
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(Convert.FromBase64String(sql)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static SQLiteConnection ConexaoBanco()
        {
            connection = new SQLiteConnection("Data Source = " + Application.StartupPath + "\\DataBase\\Hardware_DataBase.db");
            connection.Open();
            return connection;
        }

        public static DataTable Query(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static Dictionary<string, int> ObterCategoriasNomeParaId()
        {
            Dictionary<string, int> categorias = new Dictionary<string, int>();
            string sql = "select id, nome from TBCATEGORIAS";
            DataTable dt = Query(sql);

            foreach (DataRow row in dt.Rows)
            {
                categorias.Add(row["nome"].ToString(), Convert.ToInt32(row["id"]));
            }

            return categorias;
        }

        public static Dictionary<int, string> ObterCategoriasIdParaNome()
        {
            Dictionary<int, string> categorias = new Dictionary<int, string>();
            string sql = "select id, nome from TBCATEGORIAS";
            DataTable dt = Query(sql);

            foreach (DataRow row in dt.Rows)
            {
                categorias.Add(Convert.ToInt32(row["id"]), row["nome"].ToString());
            }

            return categorias;
        }

        public static bool IsBase64String(string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return false;

            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string StringToBase64(string texto)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(texto);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64ToString(string textoBase64)
        {
            byte[] bytes = Convert.FromBase64String(textoBase64);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
