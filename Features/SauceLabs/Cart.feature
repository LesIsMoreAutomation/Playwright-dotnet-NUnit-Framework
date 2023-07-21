Feature: Cart
As a user
I want to be able to add items to the cart on the SauceDemo website

    Scenario: Add 4 items to the cart
        Given I am on the SauceDemo login page
        When I login with a valid "standard_user" and "secret_sauce"
        And click on the "Login" button
        Then the user should be successfully logged in
        When I add 4 items to the cart
        Then the user should see 4 items in the cart