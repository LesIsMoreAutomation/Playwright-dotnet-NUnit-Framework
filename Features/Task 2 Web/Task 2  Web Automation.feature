Feature: Task_2__Web_Automation
Testing Web Automation page to add unique users

    @DataSource:testData.csv
    Scenario: This test is to test automation process of adding user to the table
        Given Navigate to http://www.way2automation.com/angularjs-protractor/webtables/
        And Validate that you are on the User List Table
        And Ensure that User Name <User Name> is unique on each run
        When I Click Add user 
        And populate First Name <First Name>	
        And populate Last Name <Last Name>
        And populate User Name <User Name>
        And populate Password <Password>
        And click Customer option as <Customer>
        And select role on the options <Role>
        And populate E-mail <E-mail>
        And populate Cell Phone <Cell>
        Then click on "save" 
        Then Ensure that your users are added to the list