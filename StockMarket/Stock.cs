namespace StockMarket;

public class Stock
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal CurrentPrice { get; set; }

    public void UpdatePrice(decimal price) => CurrentPrice = price;
}