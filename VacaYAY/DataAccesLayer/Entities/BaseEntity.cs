using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; init; }
        public DateTime InsertDate { get; init; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; } 
    }
}
