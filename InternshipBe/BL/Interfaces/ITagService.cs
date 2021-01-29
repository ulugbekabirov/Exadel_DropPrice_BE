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
        IEnumerable<Tag> GetSpecifiedTags(int skip, int take);
    }
}
