namespace StockMarket;

public class InvestmentPortfolio
{
    public int Id { get; set; }
    public Dictionary<Stock, int> Stocks { get; set; } = new Dictionary<Stock, int>();

    public void BuyStock(Stock stock, int quantity)
    {
        if (Stocks.ContainsKey(stock))
        {
            Stocks[stock] += quantity;
		}
		else
        {
			Stocks.Add(stock, quantity);
		}
    }

    public void SellStock(Stock stock, int quantity)
    {
	    if (Stocks.ContainsKey(stock) && Stocks[stock] >= quantity)
        {
            Stocks[stock] -= quantity;

            if (Stocks[stock] == 0)
            {
				Stocks.Remove(stock);
			}
        }
        else
        {
            throw new InvalidOperationException("Not enough stocks to sell.");
        }
	}

    public decimal EvaluatePortfolio()
    {
        return Stocks.Sum(s => s.Key.CurrentPrice * s.Value);
    }

    public int GetStockQuantity(Stock stock)
    {
		return Stocks.ContainsKey(stock) ? Stocks[stock] : 0;
	}
}
