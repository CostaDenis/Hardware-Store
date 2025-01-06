using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Hardware_Store
{
    internal class Central
    {

        private static SQLiteConnection connection;

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
    }
}
