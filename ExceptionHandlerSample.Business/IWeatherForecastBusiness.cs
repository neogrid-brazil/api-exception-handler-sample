using ExceptionHandlerSample.Domain;
using System.Threading.Tasks;

namespace ExceptionHandlerSample.Business
{
    public interface IWeatherForecastBusiness
    {
        WeatherForecast DoForecast(string location);
    }
}
