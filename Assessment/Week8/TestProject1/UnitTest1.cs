using Week08assisssment;

namespace PerformanceBonusTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            EmployeeBonus emp = new EmployeeBonus()
            {
                BaseSalary = 500000,
                PerformanceRating = 5,
                YearsOfExperience = 6,
                DeparmentMultiplier = 1.1m,
                AttendencePercentage = 95

            };
            decimal expected = 123200.00m;
            decimal actual = emp.NetAnnualBonus;
            Assert.AreEqual(actual, expected);


        }
        [Test]
        public void Test2()
        {

            EmployeeBonus emp = new EmployeeBonus()
            {
                BaseSalary = 555555,
                PerformanceRating = 6,
                YearsOfExperience = 6,
                DeparmentMultiplier = 1.13m,
                AttendencePercentage = 92

            };
            decimal expected = 118649.88m;
            decimal actual = emp.NetAnnualBonus;
            Assert.AreEqual(actual, expected);


        }
        [Test]
        public void Test3()
        {

            EmployeeBonus emp = new EmployeeBonus()
            {
                BaseSalary = 555555,
                PerformanceRating = 4,
                YearsOfExperience = 6,
                DeparmentMultiplier = 1.13m,
                AttendencePercentage = 92

            };
            decimal expected = 118649.88m;
            decimal actual = emp.NetAnnualBonus;
            Assert.AreEqual(actual, expected);


        }
    }
}