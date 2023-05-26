Feature: StockExchange

Scenario: Adding stock
	Given The stock list is empty
	When user adds a stock with symbol 'AAPL' and price 100
	Then the stock list should contain 'AAPL' stock with price 100

Scenario: Removing stock
	Given The stock list contains 'AAPL' stock with price 100
	When user removes 'AAPL' stock
	Then the stock list should be empty

Scenario: Getting market capitalization
	Given The stock list contains 'AAPL' stock with price 100
	And the stock list contains 'GOOG' stock with price 200
	When user gets the market capitalization
	Then the market capitalization should be 300

Scenario: Getting top performing stocks
	Given The stock list contains 'AAPL' stock with price 100
	And the stock list contains 'UAPC' stock with price 50
	And the stock list contains 'GOOG' stock with price 200
	When user gets the top 2 performing stocks
	Then the top performing stocks should be
		| Name | CurrentPrice |
		| GOOG | 200		  |
		| AAPL | 100          |

Scenario: Getitng least performing stocks
	Given The stock list contains 'AAPL' stock with price 100
	And the stock list contains 'UAPC' stock with price 50
	And the stock list contains 'GOOG' stock with price 200
	When user gets the least 2 performing stocks
	Then the top performing stocks should be
		| Name | CurrentPrice |
		| UAPC | 50			  |
		| AAPL | 100          |