using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITagService 
    {
        Task<IEnumerable<TagDTO>> GetSpecifiedAmountAsync(int skip, int take);
    }
}
