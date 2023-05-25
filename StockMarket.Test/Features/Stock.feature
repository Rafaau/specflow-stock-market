Feature: Stock

Scenario: Stocks price update
	Given The stock price of 'XYZ' is 50
	When the stock price of 'XYZ' is updated to 100
	Then the new price of stock 'XYZ' should be 100
