using Exercicio_POO_19_Interfaces.Domain.Entities;

namespace Exercicio_POO_19_Interfaces.Domain.Services
{
    public class RentalService
    {
        private readonly ITaxServices _taxServices;
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        public RentalService(double pricePerHour, double pricePerDay, ITaxServices taxServices)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxServices = taxServices;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment;
            if (duration.TotalHours <= 12.0)
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            else
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);

            double Tax = _taxServices.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, Tax);
        }
    }
}
