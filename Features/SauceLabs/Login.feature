Feature: Login
As a user
I want to be able to login to the SauceDemo website

    Scenario: Login with a valid username and password
        Given I am on the SauceDemo login page
        When I login with a valid "standard_user" and "secret_sauce"
        And click on the login button
        Then the user should be successfully logged in

    Scenario: Login with a locked username and password
        Given I am on the SauceDemo login page
        When I login with a valid "locked_out_user" and "secret_sauce"
        And click on the login button
        Then the user should not login successfully
        
    Scenario: Login with a problem username and password
        Given I am on the SauceDemo login page
        When I login with a valid "problem_user" and "secret_sauce"
        And click on the login button
        Then the user should be successfully logged in
