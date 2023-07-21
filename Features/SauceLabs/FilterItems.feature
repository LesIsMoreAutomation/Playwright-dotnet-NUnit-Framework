Feature: Filter Items
As a user
I want to be able to filter items on the SauceDemo website

    Scenario: Filter items by pricing
        Given I am on the SauceDemo login page
        When I login with a valid "standard_user" and "secret_sauce"
        And click on the "Login" button
        Then the user should be successfully logged in
        When I filter items "Price (low to high)" by pricing
        Then the user should see the first item is the lowest and the last item is the highest in price