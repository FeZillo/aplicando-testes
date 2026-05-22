using AplicandoTestes.Core;

namespace AplicandoTestes.UnitTests;

public class TemperatureConverterTests
{
    [Theory]
    [InlineData(32, 0)]
    [InlineData(86, 30)]
    [InlineData(212, 100)]
    [InlineData(-40, -40)]
    public void FahrenheitToCelsius_ShouldConvertKnownValues(double fahrenheit, double expectedCelsius)
    {
        double actualCelsius = TemperatureConverter.FahrenheitToCelsius(fahrenheit);

        Assert.Equal(expectedCelsius, actualCelsius);
    }
}
