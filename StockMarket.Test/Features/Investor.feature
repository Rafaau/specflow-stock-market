Feature: Investor

Scenario: Stocks purchase
	Given The investor wants to buy 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 1000
	When the investor makes the investment
	Then the investor should have 10 stocks of 'XYZ'
	Then the investor should have a balance of 500

Scenario: Stocks sell
	Given The investor has 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 1000
	When the investor sells 10 stocks of 'XYZ'
	Then the investor should have a balance of 1500
	Then the investor should have 0 stocks of 'XYZ'

Scenario: Getting Net Worth
	Given The investor has 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has 5 stocks of 'ABC'
	And current price of stock 'ABC' is 100
	When the investor evaluates the portfolio
	Then the net worth should be 1000


