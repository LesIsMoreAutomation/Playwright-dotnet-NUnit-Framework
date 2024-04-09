Feature: Office_Login
	Testing Microsoft office login 

@mytag
Scenario: Microsoft office login 
	Given I navigate to "https://www.office.com/"
	When click on the "Sign in" button
	And enter "lesibana.george@gmail.com" input data on the "Email, phone, or Skype"
	And click on the "Next" button
	Then click on "Other ways to sign in"
	And click on "Use my password"
	When enter "Password%23" input data on the "Password"
	When click on the "Sign in" button