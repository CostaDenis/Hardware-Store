namespace Hardware_Store
{
    internal class CartItem
    {
        //Classe para armazenar os itens do carrinho
        public CartItem(int productId, string productName,
            double productPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
