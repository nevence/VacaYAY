using OldVacaYAYApi.Entities;

namespace OldVacaYAYApi.Services
{
    public class OldVacaYAYService : IOldVacaYAYService
    {
        public IEnumerable<MockUpEmployee> GetEmployeesFromOldSystem()
        {
            DataGenerator.InitBogusData();
            var employees = DataGenerator.Employees;
            return employees;
        }
    }
}
