using BL.DTO;
using BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITagService 
    {
        Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(SpecifiedAmountModel specifiedAmountModel);
    }
}
