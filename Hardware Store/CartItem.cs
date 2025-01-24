namespace Hardware_Store
{
    internal class CartItem
    {
        //Classe para armazenar os itens do carrinho
        public CartItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
