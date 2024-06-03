namespace OldVacaYAYApi.Entities
{
    public static class DataGenerator
    {
        public static readonly List<MockUpEmployee> Employees = new();
        public static void InitBogusData()
        {
            var employeeGenerator = MockUpEmployee.GetEmployeeGenerator();
            var generatedEmployees = employeeGenerator.Generate(10);
            Employees.AddRange(generatedEmployees);
        }
    }
}
