using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Store
{
    internal class Central
    {

        private static SQLiteConnection conexao;

        public static SQLiteConnection ConexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = " + Application.StartupPath + "\\DataBase\\Hardware_DataBase.db");
            conexao.Open();
            return conexao;
        }

        public static DataTable Consulta(string sql)
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

    }
}
