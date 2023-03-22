Feature: Test11
	Testing ultimate automation sign in page

	@DataSource:test.csv
	Scenario: This test is to test ultimate automation sign in
		Given I navigate to ultimate automation website <env>
		Then assert sign in page has header "Welcome Back!"
		When I enter email "test@testing1.co.za"
		And I enter paasword "WelcomeBack!"
		Then I click on the sign in button
		
	

