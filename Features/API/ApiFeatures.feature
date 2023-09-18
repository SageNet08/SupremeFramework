Feature: API_TEST_TEMPLATE
This feature file has the scenarios for the API tests. 
Make use your localhost is running before the test. 

Background:  Get Token For Admin 
	* the user sets the baseUrl "https://localhost:44339/"
	* an API request is made
	| methodType | urlParameter     | urlResourceValue | requestBody     |
	| POST       | api/authenticate | null             | PostCredentials |
	When the request is executed 
	Then authenication token is saved 

Scenario:  Get Request for CatalogItemID

    Given user has authenticaion token 
	Given an API request is made
	| methodType | urlParameter                      | urlResourceValue | requestBody |
	| GET        | api/catalog-items/{catalogItemId} | 1                | noBody      |
	When the request is executed
	Then the Status Code "200" should be received
	Then the "GetCatalogItemIdResp" type is received 
	Then the response is verified for the following fields
	| id | name                      | price | pictureUri             | catalogTypeId | catalogBrandId |
	| 1  | .NET Bot Black Sweatshirt | 19.50 | /images/products/1.png | 2             | 2              |
	
Scenario: Post Request 
     Given user has authenticaion token
	 Given an API request is made
	 | methodType | urlParameter       | urlResourceValue | requestBody            |
	 | POST       | api/catalog-items/ | null             | PostRequestCatalogJson |
	 When the request is executed
	 Then the Status Code "201" should be received
	 Then the "PostCatalogItemResp" type is received
	 Then the response is verified for the following fields
	| id | name | price | pictureUri                                    | catalogTypeId | catalogBrandId |
	| 75 | novel63   | 10    | images\\products\\eCatalog-item-default.png?0 | 2             | 2              |


Scenario: Delete Request 
     Given user has authenticaion token
	 * an API request is made
	 | methodType | urlParameter                        | urlResourceValue | requestBody |
	 | DELETE     | api/catalog-items/{catalog-ItemsId} | 75              | noBody      |
	 When the request is executed
	 Then the Status Code "200" should be received
	 Then the "DeleteCatalogIdResponse" type is received
	 Then the DELETE response is verified for the following field
	 | status  |
	 | Deleted |
	#Delete Request might fail when run as the resource might already been deleted. Be sure to change the resource value. 

Scenario: Put Request
	Given user has authenticaion token
	 * an API request is made
	 | methodType | urlParameter      | urlResourceValue | requestBody |
	 | PUT        | api/catalog-items/ | null             | PutRequest  |
	 When the request is executed
	 Then the "PutResponse" type is received
	 * the Status Code "200" should be received
	 Then the response is verified for the following fields
	| id | name | price | pictureUri                                    | catalogTypeId | catalogBrandId |
	| 57 | NEW   | 10    | images\\products\\eCatalog-item-default.png?0 | 2             | 2              |

Scenario: Get Request By Page 
	Given user has authenticaion token
	* an API request is made
	 | methodType | urlParameter       | urlResourceValue | requestBody          |
	 | GET        | api/catalog-items/ | null             | GetRequestByPageJson |
	  And the user adds query parameters to the request
	  | key            | value |
	  | pageSize       | 1     |
	  | pageIndex      | 1     |
	  | catalogBrandId | 2     |
	  | catalogTypeId  | 2     |
	 When the request is executed 
	 Then the GetRequestByPage type is received
	 * the Status Code "200" should be received 
	 Then the GetByPage response is verified for the following field
	 | id | name                      | price | pictureUri             | catalogTypeId | catalogBrandId | pageCount |
	 | 4  | .NET Bot Black Sweatshirt | 12.00 | /images/products/4.png | 2             | 2              | 15        |