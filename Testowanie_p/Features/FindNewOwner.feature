Feature: FindInvalidPetOwner

@mytag
Scenario Outline: Find invalid pet owner
	Given I have logged to the application
	When When I click Find Owner tab the appropirate view should be opened
	When When I type "<ownerName>" and click FindOwnerButton button
	Then The error text message should be displayed

	Examples: 
	| ownerName |
	| Daviss    |

Scenario Outline:  Find valid pet owner
	Given I have logged to the application
	When When I click Find Owner tab the appropirate view should be opened
	When When I type "Escobito" and click FindOwnerButton button	
	Then The valid user should be found
	And When I click on Edit Owner button the new owner window should be dispalyed
	And I type the new data as "<firstName>" "<lastName>" "<address>" "<city>" "<telephone>"
	Then When I click Update Owner button the new data should be saved

	#Examples: 
	#| ownerName|
	#| Escobito |
	Examples: 
	| firstName | lastName | address		| city    | telephone |
	| Pawel     | Marek    | Grunwaldzka 72 | Warszawa| 123456789 |

