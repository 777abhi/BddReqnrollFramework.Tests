
Feature: Calculator
    As a user
    I want to perform basic arithmetic operations
    So that I can do quick calculations

Scenario: Add two numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120

Scenario: Subtract two numbers
    Given I have entered 50 into the calculator
    And I have entered 30 into the calculator
    When I press subtract
    Then the result should be 20