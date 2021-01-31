using BL.DTO;
using BL.Interfaces;
using System;
using System.Collections.Generic;

namespace BL.Services
{
    public class SearchService : ISearchService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerable<DiscountDTO> ISearchService.SearchDisccountsByName(string name, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
