using AplicandoTestes.Core;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AplicandoTestes.BddTests.StepDefinitions;

[Binding]
public sealed class TemperatureConversionSteps
{
    private double _fahrenheit;
    private double _actualCelsius;

    [Given(@"the Fahrenheit temperature is (.*)")]
    public void GivenTheFahrenheitTemperatureIs(double fahrenheit)
    {
        _fahrenheit = fahrenheit;
    }

    [When(@"I convert it to Celsius")]
    public void WhenIConvertItToCelsius()
    {
        _actualCelsius = TemperatureConverter.FahrenheitToCelsius(_fahrenheit);
    }

    [Then(@"the Celsius result should be (.*)")]
    public void ThenTheCelsiusResultShouldBe(double expectedCelsius)
    {
        _actualCelsius.Should().Be(expectedCelsius);
    }
}
