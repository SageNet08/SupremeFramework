Feature: API_TEST_TEMPLATE
This is a general outline of how the API tests can be written and reused.

//Resource Allocation 
Background: The Url Set-Up 
	Given the user sets the baseUrl "https://www.api.google.com/"
	And set client with token
	| token          |
	| <insert-token> |

@tag1
Scenario: API Test
	Given the user sets a "GET" method
	Then the user sends a payload "payload" of type "path" 

	
Scenario:  Test
Given an API request is made
| methodType | urlParameter | urlResourceValue | requestBody            | 
| POST       | catalogId    | 1                | PostRequestCatalogJson |
When the request is executed
Then response is read 

