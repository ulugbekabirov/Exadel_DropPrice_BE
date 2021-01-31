using BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITagService 
    {
        Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(int skip, int take);
    }
}
