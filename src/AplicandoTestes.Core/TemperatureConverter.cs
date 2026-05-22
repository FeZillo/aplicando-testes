namespace AplicandoTestes.Core;

public static class TemperatureConverter
{
    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return Math.Round((fahrenheit - 32) / 1.8, 2, MidpointRounding.AwayFromZero);
    }
}
