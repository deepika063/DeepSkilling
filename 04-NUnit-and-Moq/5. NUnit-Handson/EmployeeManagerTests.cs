using NUnit.Framework;
using CollectionsLib;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager manager;

        [SetUp]
        public void SetUp()
        {
            manager = new EmployeeManager();
        }

        // Scenario 1
        [Test]
        public void GetEmployees_ShouldNotContainNullValues()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees, Has.None.Null);
        }

        // Scenario 2
        [Test]
        public void GetEmployees_ShouldContainEmployeeWithId100()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees.Any(e => e.Id == 100), Is.True);
        }

        // Scenario 3
        [Test]
        public void GetEmployees_ShouldContainUniqueEmployees()
        {
            var employees = manager.GetEmployees();

            Assert.That(
                employees.Select(e => e.Id).Distinct().Count(),
                Is.EqualTo(employees.Count));
        }

        // Scenario 4
        [Test]
        public void EmployeeCollections_ShouldBeEqual()
        {
            var list1 = manager.GetEmployees();
            var list2 = manager.GetEmployeesWhoJoinedInPreviousYears();

            CollectionAssert.AreEqual(list1, list2);
        }
    }
}
