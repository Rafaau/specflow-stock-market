namespace StockMarket.Test.StepDefinitions;

[Binding]
public class StockExchangeSteps
{
	private readonly ScenarioContext _scenarioContext;

	public StockExchangeSteps(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;
	}

	[Given(@"The stock list is empty")]
	public void GivenTheStockListIsEmpty()
	{
		var stockExchange = new StockExchange();
		_scenarioContext.Add("stockExchange", stockExchange);
	}

	[Given(@"The stock list contains '(.*)' stock with price (\d+)")]
	public void GivenTheListContainsStockWithPrice(string stockName, decimal price)
	{
		var stock = new Stock { Name = stockName, CurrentPrice = price };
		var stockExchange = new StockExchange();
		stockExchange.StockList.Add(stock);
		_scenarioContext.Add("stockExchange", stockExchange);
	}

	[Given(@"the stock list contains '(.*)' stock with price (\d+)")]
	public void GivenTheStockListContainsStockWithPrice(string stockName, decimal price)
	{
		var stock = new Stock { Name = stockName, CurrentPrice = price };
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		stockExchange.StockList.Add(stock);
	}

	[When(@"user gets the market capitalization")]
	public void WhenUserGetsTheMarketCapitalization()
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		_scenarioContext.Add("marketCapitalization", stockExchange.GetMarketCapitalization());
	}

	[When(@"user gets the top (\d+) performing stocks")]
	public void WhenUserGetsTheTopPerformingStocks(int topN)
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		_scenarioContext.Add("topPerformingStocks", stockExchange.GetTopPerformingStocks(topN));
	}

	[When(@"user gets the least (\d+) performing stocks")]
	public void WhenUserGetsTheLeastPerformingStocks(int topN)
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		_scenarioContext.Add("topPerformingStocks", stockExchange.GetLeastPerformingStocks(topN));
	}

	[When(@"user removes '(.*)' stock")]
	public void WhenUserRemovesStock(string stockName)
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		var stock = stockExchange.StockList.FirstOrDefault(s => s.Name == stockName);
		stockExchange.RemoveStock(stock!);
	}

	[When(@"user adds a stock with symbol '(.*)' and price (\d+)")]
	public void WhenUserAddsAStockWith(string stockName, decimal price)
	{
		var stock = new Stock { Name = stockName, CurrentPrice = price };
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		stockExchange.AddStock(stock);
	}

	[Then(@"the top performing stocks should be")]
	public void ThenTheTopPerformingStocksShouldBe(Table table)
	{
		var topPerformingStocks = _scenarioContext.Get<Dictionary<string, decimal>>("topPerformingStocks");
		
		foreach (var row in table.Rows)
		{
			var stockName = row["Name"];
			var price = decimal.Parse(row["CurrentPrice"]);

			topPerformingStocks[stockName].Should().Be(price);
		}
	}

	[Then(@"the market capitalization should be (\d+)")]
	public void ThenTheMarketCapitalizationShouldBe(decimal marketCapitalization)
	{
		var actualMarketCapitalization = _scenarioContext.Get<decimal>("marketCapitalization");
		actualMarketCapitalization.Should().Be(marketCapitalization);
	}

	[Then(@"the stock list should be empty")]
	public void ThenTheStockListShouldBeEmpty()
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		stockExchange.StockList.Should().BeEmpty();
	}

	[Then(@"the stock list should contain '(.*)' stock with price (\d+)")]
	public void ThenTheStockListShouldContainStockWithPrice(string stockName, decimal price)
	{
		var stockExchange = _scenarioContext.Get<StockExchange>("stockExchange");
		stockExchange.StockList.Should().Contain(s => s.Name == stockName && s.CurrentPrice == price);
	}
}
