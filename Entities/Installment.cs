using System.Globalization;

namespace TesteInterfaces.Entities
{
    internal class Installment
    {
        public DateOnly DueDate { get; set; }
        public double Amount { get; set; }

        public Installment()
        {
        }

        public Installment(DateOnly dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return DueDate + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
