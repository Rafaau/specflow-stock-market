namespace StockMarket.Test.StepDefinitions;

[Binding]
public class StockSteps
{
	private readonly ScenarioContext _scenarioContext;

	public StockSteps(ScenarioContext scenarioContext)
	{
		_scenarioContext = scenarioContext;
	}

	[Given(@"The stock price of 'XYZ' is (\d+)")]
	public void GivenTheStockPriveOfIs(decimal price)
	{
		var stock = new Stock { Name = "XYZ", CurrentPrice = price };
		_scenarioContext.Add("stock", stock);
	}

	[When(@"the stock price of 'XYZ' is updated to (\d+)")]
	public void WhenTheStockPriceOfIsUpdatedTo(decimal price)
	{
		var stock = _scenarioContext.Get<Stock>("stock");
		stock.CurrentPrice = price;
	}

	[Then(@"the new price of stock 'XYZ' should be (\d+)")]
	public void ThenTheNewPriveOfStockShouldBe(decimal price)
	{
		var stock = _scenarioContext.Get<Stock>("stock");
		stock.CurrentPrice.Should().Be(price);
	}
}
