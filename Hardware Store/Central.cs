using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Hardware_Store
{
    internal class Central
    {
        public static BindingList<CartItem> cart = new BindingList<CartItem>();
        private static SQLiteConnection connection;
        public static string cpf = "";

        public static DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(BDConnection().ConnectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {

                        if (parameters != null)
                        {
                            foreach (var p in parameters)
                            {
                                cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                            }
                        }

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public static SQLiteConnection BDConnection()
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
                using (var cmd = BDConnection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, BDConnection());
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        //Hash senha
        public static (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            string saltBase64 = Convert.ToBase64String(salt);
            string hashBase64 = Convert.ToBase64String(hash);

            return (hashBase64, saltBase64);
        }

        public static bool VerifyPassword(string storedPassword, string storedHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);

            var pbkdf2 = new Rfc2898DeriveBytes(storedPassword, salt, 10000);
            byte[] inputHash = pbkdf2.GetBytes(20);

            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            return inputHash.SequenceEqual(storedHashBytes);
        }


        public static Dictionary<string, int> GetCategoryNameToId()
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

        public static Dictionary<int, string> GetCategoryIdToName()
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

        public static void VerifyTextCPF(TextBox txt_cpf, KeyPressEventArgs e)
        {
            if (txt_cpf.TextLength >= 11 && e.KeyChar != (char)8)
            {
                e.Handled = true;
                MessageBox.Show("CPF deve ter 11 digitos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                e.Handled = false;
            }

        }

        public static int GetLastSaleId()
        {
            string sql = "select max(id) from TBVENDAS";
            DataTable dt = Query(sql);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static double GetProductPrice(int id)
        {
            string sql = "select preco from TBPRODUTOS where id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            DataTable dt = ExecuteQuery(sql, parameters);
            return Convert.ToDouble(dt.Rows[0][0]);
        }
    }
}
