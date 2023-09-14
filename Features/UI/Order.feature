

Feature: Order
In this feature file, orders will be placed;






Background:  Homepage To Login Page
	Given the user is on the homepage
	When the user click the Login link 
	Then the user is on the Login Page








 @Edge
Scenario: Order a Product



    When the user enters the credentials and click the login button
	| username               | password   |
	| demouser@microsoft.com | Pass@word1 |
	When the user selects the brand and the type filters of the products
	| brand | type |
	| Other | All  |
	And the user adds an item to basket
	| items		          |
	| Prism White T-Shirt |
	And the Basket page appears 
	When the user checks out with the required quantity
	| quantity |
	| 5        |
	And the user completes payment 
	When the user access his orders 
	| username               |
	| demouser@microsoft.com |

	Then the MyOrder History is verified
	| items               | quantity |
	| Prism White T-Shirt | 5        |




 @Edge
Scenario: Invalid Quantity
	 When the user enters the credentials and click the login button
	| username               | password   |
	| demouser@microsoft.com | Pass@word1 |
	When the user selects the brand and the type filters of the products
	| brand | type |
	| Other | All  |
	And the user adds an item to basket
	| items		          |
	| Prism White T-Shirt |
	When the Basket page appears 
	And the user tries to check out with an invalid quantity
	| quantity |
	| -1	   |
	Then user gets an error message
	


 @Edge
Scenario: User orders 5 items
	 When the user enters the credentials and click the login button
	| username               | password   |
	| demouser@microsoft.com | Pass@word1 |
	When the user selects the brand and the type filters of the products
	| brand | type |
	| Other | All  |
	And the user adds 5 items to basket
	| items                  | brand | type | quantity |
	| Prism White T-Shirt    | Other | All  | 1        |
	| Roslyn Red Sheet       | Other | All  | 2        |
	| Roslyn Red T-Shirt     | Other | All  | 3        |
	| Kudu Purple Sweatshirt | Other | All  | 4        |
	| Prism White TShirt     | Other | All  | 5        |
	And the Basket page appears
	When the user checks out the five items
	And the user completes payment
	When the user access his orders 
	| username               |
	| demouser@microsoft.com |
	Then the MyOrder History is verified
	| items                  | quantity |
	| Prism White T-Shirt    | 1        |
	| Roslyn Red Sheet       | 2        |
	| Roslyn Red T-Shirt     | 3        |
	| Kudu Purple Sweatshirt | 4        |
	| Prism White TShirt     | 5        |


