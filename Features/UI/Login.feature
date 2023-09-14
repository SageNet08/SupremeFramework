
Feature: Login

Login process; 








 @Chrome

Scenario: Successful Login for user1
    Given the user is on the homepage
	When the user click the Login link 
	Then the user is on the Login Page 
	
	When the user enters the credentials and click the login button
	| username               | password   |
	| demouser@microsoft.com | Pass@word1 |


	Then the user is logged in as emailname 
	| email					 |
	| demouser@microsoft.com |


 @Chrome

Scenario: Successful Login for user2
    Given the user is on the homepage
	When the user click the Login link 
	Then the user is on the Login Page 
	
	When the user enters the credentials and click the login button
	| username               | password      |
	| admin@microsoft.com    | Pass@word1    |


	Then the user is logged in as emailname 
	| email               |
	| admin@microsoft.com |  



 @Chrome
Scenario: Invalid Login 
	Given the user is on the homepage
	When the user click the Login link 
	Then the user is on the Login Page
	When the user enters the credentials and click the login button
	| username                 | password   |
	| spiderman@multiverse.com | hackerpwdZ |

	Then Invalid Login 

