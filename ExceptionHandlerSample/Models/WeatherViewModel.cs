using FluentValidation;

namespace ExceptionHandlerSample.Models
{
    public class WeatherViewModel
    {
        public string Location { get; set; }
    }
    public class WeatherViewModelValidator : AbstractValidator<WeatherViewModel>
    {
        public WeatherViewModelValidator()
        {
            RuleFor(x => x.Location).NotNull().WithMessage("Location is required.");
        }

    }
}
