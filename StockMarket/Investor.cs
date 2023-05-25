namespace StockMarket;

public class Investor
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public InvestmentPortfolio Portfolio { get; set; } = new InvestmentPortfolio();
    public decimal Balance { get; set; }

    public void MakeInvestment(Stock stock, int quantity)
    {
		if (Balance >= stock.CurrentPrice * quantity)
        {
			Balance -= stock.CurrentPrice * quantity;
			Portfolio.BuyStock(stock, quantity);
		}
		else
        {
			throw new InvalidOperationException("Not enough money to buy stocks.");
		}
	}

	public void SellInvestment(Stock stock, int quantity)
	{
		if (Portfolio.GetStockQuantity(stock) >= quantity)
		{
			Balance += stock.CurrentPrice * quantity;
			Portfolio.SellStock(stock, quantity);
		}
		else
		{
			throw new InvalidOperationException("Not enough stocks to sell.");
		}
	}

	public void WithdrawFunds(decimal amount)
	{
		if (Balance >= amount)
		{
			Balance -= amount;
		}
		else
		{
			throw new InvalidOperationException("Not enough money to withdraw.");
		}
	}

	public void DepositFunds(decimal amount)
	{
		Balance += amount;
	}

	public decimal GetNetWorth()
	{
		return Balance + Portfolio.EvaluatePortfolio();
	}

	public Dictionary<Stock, int> GetInvestorHoldings()
	{
		return Portfolio.Stocks;
	}
}
