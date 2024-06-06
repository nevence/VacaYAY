using OldVacaYAYApi.Entities;

namespace OldVacaYAYApi.Services
{
    public interface IOldVacaYAYService
    {
        IEnumerable<MockUpEmployee> GetEmployeesFromOldSystem();
    }
}
