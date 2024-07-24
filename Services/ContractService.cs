using TesteInterfaces.Entities;

namespace TesteInterfaces.Services
{
    internal class ContractService
    {
        // instance the interface
        private IOnlinePaymentService _paymentService;

        // prepare the constructor to make dependency injection
        public ContractService(IOnlinePaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            
            double initialQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                Installment installment = new Installment();

                // define amount of each installment
                installment.Amount = initialQuota + _paymentService.Interest(initialQuota, i);
                installment.Amount += _paymentService.PaymentFee(installment.Amount);

                // define specific data of each installment
                installment.DueDate = contract.Date;
                installment.DueDate = installment.DueDate.AddMonths(i);

                contract.Installments.Add(installment);
            }
        }
    }
}
