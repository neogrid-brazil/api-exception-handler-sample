using ExceptionHandlerSample.Domain;
using System;

namespace ExceptionHandlerSample.Business
{
    public class WeatherForecastBusiness : IWeatherForecastBusiness
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast DoForecast(string location)
        {
            static bool IsEvenRandomNumber() => new Random().Next(0, 1000) % 2 == 0;

            if (IsEvenRandomNumber())
            {
                throw new WeatherForecastBusinessException("Randomly generated exception");
            }

            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Location = location
            };
        }
    }
}
