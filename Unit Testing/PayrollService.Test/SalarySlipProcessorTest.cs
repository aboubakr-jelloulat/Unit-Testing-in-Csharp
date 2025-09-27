using Moq;

namespace PayrollService.Test
{
    public class SalarySlipProcessorTest
    {

        // Signature Naming : 

        //[Fact]
        //public void Methode_Scenario_Outcome()
        //{

        // Thriple A: Arrange  Act  Assert

        //}



        [Fact]
        public void CalculateBasicSalary_EmployeeIsNull_ReturnThrowArgumantNullException()
        {
            // Thriple A: Arrange  Act  Assert

            // Arrange
            Employee employee = null;

            // Act
            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateBasicSalary(employee);

            var expected = 10000m;

            // Assert
            Assert.Throws<ArgumentNullException>(() => func(employee));
        }

        [Fact]
        public void CalculateBasicSalary_ForEmployeeWageAndWorkingDays_ReturnBasicsSalary()
        {
            // Thriple A: Arrange  Act  Assert

            // Arrange
            var employee = new Employee { Wage = 500m, WorkingDays = 20 };

            // Act
            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            var actual = salarySlipProcessor.CalculateBasicSalary(employee);

            var expected = 10000m;

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void CalculateTransportationAllowece_EmployeeIsNull_ThrowArgumentNullException()
        {
            // Arrange
            Employee employee = null;

            // Act
            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateTransportationAllowece(employee);

            // Assert 
            Assert.Throws<ArgumentNullException>(() => func(employee));
        }

        [Fact]
        public void CalculateTransportationAllowece_EmployeeWorkInOffice_ReturnsTransporationAllowance()
        {
            // Arrange

            var employee = new Employee { WorkPlatform = WorkPlatform.Office };

            // Act

            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);

            var expected = Constants.TransportationAllowanceAmount;


            // Assert
            
            Assert.Equal(actual, expected);
        }

        [Fact]

        public void CalculateTransportationAllowece_EmployeeWorkRemote_ReturnsTransporationAllowance()
        {
            // Arrange

            var employee = new Employee { WorkPlatform = WorkPlatform.Remote };

            // Act

            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);

            var expected = 0m;


            // Assert

            Assert.Equal(actual, expected);
        }


        [Fact]

        public void CalculateTransportationAllowece_EmployeeWorkHybridMode_ReturnsTransporationAllowance()
        {
            // Arrange

            var employee = new Employee { WorkPlatform = WorkPlatform.Hybrid };

            // Act

            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            var actual = salarySlipProcessor.CalculateTransportationAllowece(employee);

            var expected = Constants.TransportationAllowanceAmount / 2;


            // Assert

            Assert.Equal(actual, expected);
        }



        [Fact]
        public void CalculateDangerPay_EmployeeIsNull_ThrowArgumentNullException()
        {
            // Arrange


            Employee employee = null;

            // Act

            var salarySlipProcessor = new SalarySlipProcessor(zoneService: null!);

            Func<Employee, decimal> func = (e) => salarySlipProcessor.CalculateDangerPay(employee);

            // Assert 

            Assert.Throws<ArgumentNullException>(() => func(employee));

        }


        [Fact]
        public void CalculateDangerPay_EmployeeIsDangerOn_ReturnsDangerPay()
        {
            // Arrange

            var employee = new Employee { IsDanger = true };

            // Act

            var salarySlipProcessor = new SalarySlipProcessor(zoneService : null!);

            var actual = salarySlipProcessor.CalculateDangerPay(employee);

            var expected = Constants.DangerPayAmount;

            // Assert

            Assert.Equal(actual, expected);
        }


        [Fact]
        public void CalculateDangerPay_EmployeeIsDangerOffAndInDangerZone_ReturnsDangerPay()
        {
            // Arrange

            var employee = new Employee { IsDanger = false, DutyStation = "Ukrain" };

            var mockZoneService = new Mock<IZoneService>();

            mockZoneService.Setup(z => z.IsDangerZone("Ukrain")).Returns(true);


            // Act

            //var zoneService = new ZoneService();

            var salarySlipProcessor = new SalarySlipProcessor(mockZoneService.Object);

            var actual = salarySlipProcessor.CalculateDangerPay(employee);

            var expected = Constants.DangerPayAmount;

            // Assert

            Assert.Equal(actual, expected);
        }


        [Fact]

        public void CalculateDangerPay_EmployeeIsDangerOffAndNotInDangerZone_ReturnsDangerPay()
        {
            // Arrange

            var employee = new Employee { IsDanger = false, DutyStation = "Ukrain" };

            var mockZoneService = new Mock<IZoneService>();

            mockZoneService.Setup(z => z.IsDangerZone(employee.DutyStation)).Returns(false);


            // Act

            //var zoneService = new ZoneService();

            var salarySlipProcessor = new SalarySlipProcessor(mockZoneService.Object);

            var actual = salarySlipProcessor.CalculateDangerPay(employee);

            var expected = 0m;

            // Assert

            Assert.Equal(actual, expected);
        }



    }
}
