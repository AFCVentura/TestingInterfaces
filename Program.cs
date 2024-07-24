using System.Globalization;
using TesteInterfaces.Entities;
using TesteInterfaces.Services;

namespace TesteInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ContractService contractService = new ContractService(new PaypalService());

                    Console.WriteLine("Enter contract data");
                    Console.Write("Number: ");
                    int contractNumber = int.Parse(Console.ReadLine());
                    
                    Console.Write("Date (dd/MM/yyyy): ");
                    DateOnly contractDate = DateOnly.Parse(Console.ReadLine());

                    Console.Write("Contract value: ");
                    double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Enter number of installments: ");
                    int contractNumberOfInstallments = int.Parse(Console.ReadLine());

                    // instance Contract
                    Contract contract = new Contract(contractNumber, contractDate, contractValue);

                    // use ContractService to calculate the installments and print them
                    contractService.ProcessContract(contract, contractNumberOfInstallments);

                    Console.WriteLine("Installments");
                    foreach (Installment installment in contract.Installments)
                    {
                        Console.WriteLine(installment);
                    }






                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
    }
}
