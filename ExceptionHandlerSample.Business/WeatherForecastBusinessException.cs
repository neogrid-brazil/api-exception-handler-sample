using System;

namespace ExceptionHandlerSample.Business
{
    public class WeatherForecastBusinessException : Exception
    {
        public WeatherForecastBusinessException() { }

        public WeatherForecastBusinessException(string message)
            : base(message) { }

        public WeatherForecastBusinessException(string message, Exception inner)
            : base(message, inner) { }
    }
}
