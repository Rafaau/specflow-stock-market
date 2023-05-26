Feature: Investor

Scenario: Stocks purchase successfully
	Given The investor wants to buy 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 1000
	When the investor makes the investment
	Then the investor should have 10 stocks of 'XYZ'
	Then the investor should have a balance of 500

Scenario: Stocks purchase when not enough money
	Given The investor wants to buy 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 100
	When the investor makes the investment
	Then the error 'Not enough money to buy stocks.' should be raised
	Then the investor should have 0 stocks of 'XYZ'
	Then the investor should have a balance of 100

Scenario: Stocks sell successfully
	Given The investor has 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 1000
	When the investor sells 10 stocks of 'XYZ'
	Then the investor should have a balance of 1500
	Then the investor should have 0 stocks of 'XYZ'

Scenario: Stocks sell when not enough stocks
	Given The investor has 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has a balance of 1000
	When the investor sells 20 stocks of 'XYZ'
	Then the error 'Not enough stocks to sell.' should be raised
	Then the investor should have a balance of 1000
	Then the investor should have 10 stocks of 'XYZ'

Scenario: Getting Net Worth
	Given The investor has 10 stocks of 'XYZ'
	And current price of stock 'XYZ' is 50
	And the investor has 5 stocks of 'ABC'
	And current price of stock 'ABC' is 100
	When the investor evaluates the portfolio
	Then the net worth should be 1000

Scenario: Withdrawing funds successfully
	Given The investor has a balance of 1000
	When the investor withdraws 500
	Then the investor should have a balance of 500

Scenario: Withdrawing funds when not enough funds
	Given The investor has a balance of 1000
	When the investor withdraws 1500
	Then the error 'Not enough money to withdraw.' should be raised
	Then the investor should have a balance of 1000

Scenario: Depositing funds successfully
	Given The investor has a balance of 1000
	When the investor deposits 500
	Then the investor should have a balance of 1500

Scenario: Getting investor holdings
	Given The investor has 10 stocks of 'XYZ'
	And the investor has 5 stocks of 'ABC'
	When the investor getting holdings
	Then the investor holdings should be
		| Stock | Quantity |
		| XYZ   | 10       |
		| ABC   | 5        |


