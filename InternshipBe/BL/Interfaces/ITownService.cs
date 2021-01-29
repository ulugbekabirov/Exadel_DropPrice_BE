using BL.DTO;
using System.Collections.Generic;

namespace BL.Interfaces
{
    public interface ITownService
    {
        IEnumerable<TownDTO> GetTowns();
    }
}
