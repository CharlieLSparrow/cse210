using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUsa() ? 5.0 : 35.0;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("PACKING LABEL");

        foreach (Product product in _products)
        {
            builder.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }

        return builder.ToString();
    }

    public string GetShippingLabel()
    {
        return "SHIPPING LABEL\n" + _customer.GetShippingLabel();
    }
}
