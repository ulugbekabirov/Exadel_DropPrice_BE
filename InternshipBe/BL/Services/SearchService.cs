using BL.DTO;
using BL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
