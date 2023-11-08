using Restaurant.Domain.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.PaginationResponse
{
    public class PaginationResponseBuilder<T>
    {
        private PaginationResponse<T> response = new PaginationResponse<T>();
        

        public PaginationResponse<T> Build()
        {
            return response;
        }

        public PaginationResponseBuilder<T> SetItems (T items)
        {
            response.Items = items;
            return this;
        }


        public PaginationResponseBuilder<T> SetTotalCount(int TotalItemCount)
        {
            response.TotalItemsCount = TotalItemCount;  
            return this;
        }

        public PaginationResponseBuilder<T> SetItemsFrom(int pageSize, int pageNumber) 
        {
            response.ItemsFrom = pageSize*(pageNumber - 1)+1;
            return this;
        }

        public PaginationResponseBuilder<T> SetItemsTo(int pageSize, int pageNumber)
        {
            response.ItemsTo = (pageSize * (pageNumber - 1) + 1) + pageSize - 1;

            return this;
        }

        public PaginationResponseBuilder<T> SetPageParameters(int totalItemCount, int pageSize, int pageNumber)
        {

            //Calculate total number of pages
            response.TotalPage = (int)Math.Ceiling(totalItemCount /(double)pageSize);

            //Set field PageNumber
            response.PageNumber = pageNumber;
            //Set field PageSize 
            response.PageSize = pageSize;
            //Set PageAmplitude 
            response.PageStart = pageNumber - 5;
            response.PageEnd = pageNumber + 4;
            if (response.PageStart < 0)
            {
                response.PageEnd -= (response.PageStart - 1);
                response.PageStart = 1;
            }

            if (response.PageEnd == default)
            {
                return this;
            }

            if (response.PageEnd > response.TotalPage)
            {
                response.PageEnd = response.TotalPage;
                if (response.PageEnd > 10)
                {
                    response.PageStart = response.PageEnd - 9;
                }
            }
            return this;
        }

        
    }
}
