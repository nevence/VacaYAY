using BusinessLogicLayer.Dto.VacationRequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ViewModel
{
    public class PaginatedResponse<T>
    {
        public List<T> Items { get; set;}
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string SearchTerm { get; set; } 

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PaginatedResponse(IEnumerable<T> dtos, int count, RequestParameters requestParameters)
        {
            Items = new List<T>(dtos);
            TotalCount = count;
            PageSize = requestParameters.PageSize;
            CurrentPage = requestParameters.PageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)requestParameters.PageSize);
            SearchTerm = requestParameters.SearchTerm;  
        }
    }
}
