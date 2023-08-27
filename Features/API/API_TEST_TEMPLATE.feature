Feature: API_TEST_TEMPLATE
This is a general outline of how the API tests can be written and reused.
Background: The Url Set-Up 
	Given the user sets the baseUrl
	| url                         |
	| https://www.api.google.com/ |


@tag1
Scenario: API Test
	Given the user sets the "GET" method with payload type "query" 
	When 
	Then [outcome]
