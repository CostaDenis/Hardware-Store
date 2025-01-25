using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_VerifyCart : Form
    {
        BindingList<CartItem> cart = Central.cart;

        public Frm_VerifyCart()
        {
            InitializeComponent();
        }

        private void Frm_VerifyCart_Load(object sender, System.EventArgs e)
        {
            dgv_cart.Rows.Clear();
            dgv_cart.Columns.Clear();
            dgv_cart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_cart.CellFormatting += (s, ev) =>
            {
                if (dgv_cart.Columns[ev.ColumnIndex].Name == "ProductPrice" && ev.Value != null)
                {
                    ev.Value = string.Format(CultureInfo.CurrentCulture, "{0:C}", ev.Value);
                    ev.FormattingApplied = true;
                }
            };

            dgv_cart.DataSource = cart;
            dgv_cart.Columns["ProductId"].HeaderText = "Id do produto";
            dgv_cart.Columns["ProductName"].HeaderText = "Produto";
            dgv_cart.Columns["ProductPrice"].HeaderText = "Preço";
            dgv_cart.Columns["Quantity"].HeaderText = "Quantidade";

            foreach (DataGridViewColumn column in dgv_cart.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            var btn = new DataGridViewButtonColumn
            {
                Text = "Remover",
                UseColumnTextForButtonValue = true,
                Name = "Excluir"
            };
            dgv_cart.CellClick += Dgv_cart_CellClick;
            dgv_cart.Columns.Add(btn);
        }

        private void Dgv_cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_cart.Columns["Excluir"].Index && e.RowIndex >= 0)
            {
                var ProductName = dgv_cart.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();

                var resp = MessageBox.Show($"Essa ação irá excluir o {ProductName} do seu carrinho! " +
                    "Deseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resp == DialogResult.Yes)
                {
                    var productToRemove = cart[e.RowIndex];
                    cart.Remove(productToRemove);
                }


            }
        }

    }
}
