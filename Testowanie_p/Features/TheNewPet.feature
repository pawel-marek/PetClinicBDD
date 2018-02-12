Feature: TheNewPet

@mytag
Scenario: Add two numbers
	Given I have logged to the application
	When When I click Find Owner tab the appropirate view should be opened
	When When I type "Marek" and click FindOwnerButton button
	Then The valid user should be found
	When I click Add New Pet button
	Then The New Pet window should be displayed and title should contain "PetClinic :: a Spring Framework demonstration"
	And  I am able to type the new data as "Reksio" "2017/09/03" "hamster" 
	Then When I click Add Pet button the new pet should be added to the owner



	