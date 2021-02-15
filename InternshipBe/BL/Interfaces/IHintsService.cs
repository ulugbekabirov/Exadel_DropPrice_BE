using BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IHintsService
    {
        Task<IEnumerable<string>> HintsAsync(string subString, SpecifiedAmountModel specifiedAmountModel);
    }
}
