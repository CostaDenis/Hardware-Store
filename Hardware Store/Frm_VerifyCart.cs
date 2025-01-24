using System.Collections.Generic;
using System.Windows.Forms;

namespace Hardware_Store
{
    public partial class Frm_VerifyCart : Form
    {
        int i = 0;
        List<CartItem> cart = Central.cart;

        public Frm_VerifyCart()
        {
            InitializeComponent();
        }

        private void Frm_VerifyCart_Load(object sender, System.EventArgs e)
        {
            while (i < cart.Count)
            {

                Label lbl = new Label()
                {
                    Text = cart[i].ProductId.ToString(),
                };

                lbl.Location = new System.Drawing.Point(210 + (i * 2), 108);



                i++;
            }
        }
    }
}
