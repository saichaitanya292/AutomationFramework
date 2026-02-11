Feature: Purchase Validation and Complete Flow

  As a registered user
  I want to validate login, product addition and complete purchase
  So that I can ensure end-to-end functionality works correctly



  Scenario: Validate successful login
    Given User navigates to login page
    When User logs in with generated credentials
    Then Login should be successful



  Scenario: Validate product search and add to cart
    Given User navigates to login page
    When User logs in with generated credentials
    And User navigates to products page
    And User searches for product "Blue Top"
    And User adds first product to cart
    And User navigates to cart
    Then Product should be added to cart



  Scenario: Complete purchase flow
    Given User navigates to login page
    When User logs in with generated credentials
    Then Login should be successful
    When User navigates to products page
    And User searches for product "Blue Top"
    And User adds first product to cart
    And User navigates to cart
    Then Product should be added to cart
    When User proceeds to checkout
    And User places the order
    And User enters payment details
    Then Order should be placed successfully
