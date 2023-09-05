Feature: API_TEST_TEMPLATE
This is a general outline of how the API tests can be written and reused.

//Resource Allocation 







Background:  Get Token
	* the user sets the baseUrl "https://localhost:44339/"
	* an API request is made
	| methodType | urlParameter     | urlResourceValue | requestBody     |
	| POST       | api/authenticate |       null      | PostCredentials |
	When the request is executed 
	Then authenication token is saved 


	
	



@TheGreatSage
Scenario:  Get Request for CatalogItemID

    Given user has authenticaion token 
	Given an API request is made
	| methodType | urlParameter                      | urlResourceValue | requestBody            |
	| GET        | api/catalog-items/{catalogItemId} | 1                | PostRequestCatalogJson |
	When the request is executed
	Then the GetResponsforCatalogItem is received 
