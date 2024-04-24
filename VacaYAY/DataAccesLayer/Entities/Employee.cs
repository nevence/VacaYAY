using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class Employee : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public int DaysOffNumber { get; set; }
        public int PositionId { get; set; }
        public Position Position {  get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime EmploymentEndDate { get; set; }
        public DateTime InsertDate { get; init; } = DateTime.Now;
        public DateTime DeleteDate { get; set; }
        public DateTime UpdateDate { get; set; }   
        public ICollection<VacationRequest> VacationRequests { get; set; }
    }
}
