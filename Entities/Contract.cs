﻿namespace TesteInterfaces.Entities
{
    internal class Contract
    {
        public int Number { get; set; }
        public DateOnly Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract(int number, DateOnly date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }
    }
}
