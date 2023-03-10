
namespace Exercicio_POO_19_Interfaces.Domain.Services
{
    public class BrasilTaxService : ITaxServices
    {
        public double Tax(double amount)
        {
            if (amount < 100.00)
                return amount * 0.2;
            else
                return amount * 0.15;
        }
    }
}
