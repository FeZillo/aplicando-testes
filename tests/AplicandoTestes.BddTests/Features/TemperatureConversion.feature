Feature: Temperature conversion
  To compare temperatures in a familiar scale
  As a user of the converter
  I want Fahrenheit values to be converted to Celsius

Scenario: Convert the freezing point of water
  Given the Fahrenheit temperature is 32
  When I convert it to Celsius
  Then the Celsius result should be 0

Scenario: Convert the boiling point of water
  Given the Fahrenheit temperature is 212
  When I convert it to Celsius
  Then the Celsius result should be 100
