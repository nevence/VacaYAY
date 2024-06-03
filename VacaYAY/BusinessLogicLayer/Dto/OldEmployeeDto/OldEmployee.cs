namespace BusinessLogicLayer.Dto.OldEmployeeDto
{
    public class OldEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public int DaysOffNumber { get; set; }
        public OldLocation Location { get; set; }
        public OldLogin Login { get; set; }
        public OldPosition Position { get; set; }
    }
}