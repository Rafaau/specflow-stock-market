namespace StockMarket.Test.StepDefinitions;

[Binding]
public class InvestorSteps
{
	private readonly ScenarioContext _scenarioContext;
	private readonly StockExchange _stockExchange;

	public InvestorSteps(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;
		_stockExchange = new StockExchange();
	}

	[Given(@"The investor wants to buy (\d+) stocks of 'XYZ'")]
	public void GivenTheInvestorWantsToBuyStocks(int quantity)
	{
		var investor = new Investor();
		_scenarioContext.Add("investor", investor);
		_scenarioContext.Add("quantity", quantity);

		var stock = new Stock { Name = "XYZ" };
		_stockExchange.StockList.Add(stock);
		_scenarioContext.Add("stock", stock);
	}

	[Given(@"current price of stock 'XYZ' is (\d+)")]
	public void GivenCurrentPriceOfStockIs(decimal price)
	{
		var stock = _scenarioContext.Get<Stock>("stock");
		stock.CurrentPrice = price;
	}

	[Given(@"the investor has a balance of (\d+)")]
	public void GivenTheInvestorHasABalanceOf(decimal balance)
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		investor.Balance = balance;
	}

	[Given(@"The investor has (\d+) stocks of 'XYZ'")]
	public void GivenTheInvestorHasStocks(int quantity)
	{
		var investor = new Investor();
		_scenarioContext.Add("investor", investor);

		var stock = new Stock { Name = "XYZ" };
		_stockExchange.StockList.Add(stock);
		_scenarioContext.Add("stock", stock);

		investor.Portfolio = new InvestmentPortfolio();
		investor.Portfolio.Stocks.Add(stock, quantity);
	}

	[Given(@"the investor has (\d+) stocks of 'ABC'")]
	public void GivenTheInvestorHasStocksOf(int quantity)
	{
		var investor = _scenarioContext.Get<Investor>("investor");

		var stock = new Stock { Name = "ABC" };
		_stockExchange.StockList.Add(stock);
		_scenarioContext.Add("stock_2", stock);

		investor.Portfolio.Stocks.Add(stock, quantity);
	}

	[Given(@"current price of stock 'ABC' is (\d+)")]
	public void GivenCurrentPriceOfStockIsABC(decimal price)
	{
		var stock = _scenarioContext.Get<Stock>("stock_2");
		stock.CurrentPrice = price;
	}

	[Given(@"The investor has a balance of (\d+)")]
	public void GivenTheInvestorHasABalance(decimal balance)
	{
		var investor = new Investor { Balance = balance };
		_scenarioContext.Add("investor", investor);
	}

	[When(@"the investor getting holdings")]
	public void WhenTheInvestorGettingHoldings()
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		var holdings = investor.GetInvestorHoldings();
		_scenarioContext.Add("holdings", holdings);
	}

	[When(@"the investor deposits (\d+)")]
	public void WhenTheInvestorDeposits(decimal amount)
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		investor.DepositFunds(amount);
	}

	[When(@"the investor withdraws (\d+)")]
	public void WhenTheInvestorWithdraws(decimal amount)
	{
		try
		{
			var investor = _scenarioContext.Get<Investor>("investor");
			investor.WithdrawFunds(amount);
		}
		catch (Exception ex)
		{
			_scenarioContext.Add("exception", ex);
		}
	}

	[When(@"the investor evaluates the portfolio")]
	public void WhenTheInvestorEvaluatesThePortfolio()
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		var netWorth = investor.GetNetWorth();
		_scenarioContext.Add("netWorth", netWorth);
	}

	[When(@"the investor makes the investment")]
	public void WhenTheInvestorMakesTheInvestment()
	{
		try
		{
			var investor = _scenarioContext.Get<Investor>("investor");
			var stock = _scenarioContext.Get<Stock>("stock");
			var quantity = _scenarioContext.Get<int>("quantity");
			investor.MakeInvestment(stock, quantity);
		}
		catch (Exception ex)
		{
			_scenarioContext.Add("exception", ex);
		}
	}

	[When(@"the investor sells (\d+) stocks of 'XYZ'")]
	public void WhenTheInvestorSellsStocks(int quantity)
	{
		try
		{
			var investor = _scenarioContext.Get<Investor>("investor");
			var stock = _scenarioContext.Get<Stock>("stock");
			investor.SellInvestment(stock, quantity);
		}
		catch (Exception ex)
		{
			_scenarioContext.Add("exception", ex);
		}
	}

	[Then(@"the investor holdings should be")]
	public void ThenTheInvestorHoldingsShouldBe(Table table)
	{
		var holdings = _scenarioContext.Get<Dictionary<Stock, int>>("holdings");
		foreach (var row in table.Rows)
		{
			var stockName = row["Stock"];
			var quantity = int.Parse(row["Quantity"]);
			var stock = _stockExchange.StockList.FirstOrDefault(s => s.Name == stockName);

			holdings[stock!].Should().Be(quantity);
		}
	}

	[Then(@"the net worth should be (\d+)")]
	public void ThenTheNetWorthShouldBe(decimal netWorth)
	{
		var contextNetWorth = _scenarioContext.Get<decimal>("netWorth");
		contextNetWorth.Should().Be(netWorth);
	}

	[Then(@"the investor should have (\d+) stocks of 'XYZ'")]
	public void ThenTheInvestorShouldHaveStocks(int quantity)
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		var stock = _scenarioContext.Get<Stock>("stock");
		quantity.Should().Be(investor.Portfolio.GetStockQuantity(stock));
	}

	[Then(@"the investor should have a balance of (\d+)")]
	public void ThenTheInvestorShouldHaveABalanceOf(decimal balance)
	{
		var investor = _scenarioContext.Get<Investor>("investor");
		balance.Should().Be(investor.Balance);
	}

	[Then(@"the error '(.*)' should be raised")]
	public void ThenTheErrorShouldBeRaised(string errorMessage)
	{
		var exception = _scenarioContext.Get<Exception>("exception");
		exception.Message.Should().Be(errorMessage);
	}
}
