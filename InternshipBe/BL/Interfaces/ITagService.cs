using BL.DTO;
using BL.Models;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITagService 
    {
        Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(SpecifiedAmountModel specifiedAmountModel);
        Task<List<Tag>> GetTagsAndCreateIfNotExistAsync(string[] tagNames);

        Task AddDiscountToTagsAsync(Discount discount, List<Tag> tags);
    }
}
