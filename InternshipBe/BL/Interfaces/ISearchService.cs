using BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<DiscountDTO> SearchDisccountsByName(string name, int skip, int take);
        void Dispose();
    }
}
