namespace StockMarket;

public class StockExchange
{
    public List<Stock> StockList { get; set; } = new List<Stock>();

    public void AddStock(Stock stock)
    {
		StockList.Add(stock);
	}

    public void RemoveStock(Stock stock)
    {
        StockList.Remove(stock);
    }

    public decimal GetMarketCapitalization()
    {
		return StockList.Sum(s => s.CurrentPrice);
	}

    public Dictionary<string, decimal> GetTopPerformingStocks(int topN)
    { 
        return StockList.OrderByDescending(s => s.CurrentPrice).Take(topN).ToDictionary(s => s.Name, s => s.CurrentPrice);
    }

    public Dictionary<string, decimal> GetLeastPerformingStocks(int topN)
    {
		return StockList.OrderBy(s => s.CurrentPrice).Take(topN).ToDictionary(s => s.Name, s => s.CurrentPrice);
	}
}
