using System.Diagnostics;

namespace PayrollService
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 101,
                    Name = "Hej",
                    DutyStation = "SomeCity",
                    Wage = 2000,
                    WorkingDays = 20,
                    IsMarried = false,
                    TotalDependancies = 0,
                    IsDanger = true,
                    HasPensionPlan = true,
                    WorkPlatform = WorkPlatform.Office
                }


                
            };

            var zoneService = new ZoneService();

            var process = new SalarySlipProcessor(zoneService);


            foreach (var emp in employees)
            {
                Console.WriteLine(process.Process(emp));
            }



            Console.ReadKey();
        }
    }
}
