using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.PaginationResponse
{
    public interface IPaginationResponse<T>
    {
        T Items { get; set; }

        int TotalPage { get; set; } 

        int ItemsFrom { get; set; }
        
        int ItemsTo {  get; set; }  

        int TotalItemsCount {  get; set; }
        
        int PageSize {  get; set; }

        int PageNumber { get; set; }   
        
        int PageStart { get; set; }

        int PageEnd { get; set; }

    }

    public class PaginationResponse<T> : IPaginationResponse<T>
    {
        public T Items { get; set; }

        public int TotalPage { get; set; }

        public int ItemsFrom { get; set; }  

        public int ItemsTo { get; set; }    

        public int TotalItemsCount { get; set;}

        public int PageSize { get; set; }

        public int PageNumber { get; set; } 

        public int PageStart { get; set; }

        public int PageEnd { get; set; }
    }
}
