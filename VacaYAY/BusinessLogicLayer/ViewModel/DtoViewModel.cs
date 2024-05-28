using BusinessLogicLayer.Dto.VacationRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ViewModel
{
    public class DtoViewModel<T>
    {
        List<T> Items { get; set;}
        MetaData MetaData { get; set;}
        public DtoViewModel(IEnumerable<T> dtos, int count, int pageNumber, int pageSize)
        {
            Items.AddRange(dtos);
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            };
        }
    }
}
