namespace Demo.Entities
{
    public class OrderItem : Base
    {
        public OrderItem(Product product, int quantityOfProducts)
        {
            Product = product;
            QuantityOfProducts = quantityOfProducts;
            TotalValue = 0.0;
        }

        public Product Product { get; set; }
        public int QuantityOfProducts { get; set; }
        public double TotalValue { get; private set; }

        public void CalculateTotalValue()
        {
            TotalValue = QuantityOfProducts * Product.Price;
        }
    }
}