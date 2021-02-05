using BL.DTO;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<DiscountDTO> SearchDisccountsByName(string name, int skip, int take);
    }
}
