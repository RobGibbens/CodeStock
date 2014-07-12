using System.Collections.Generic;
using System.Threading.Tasks;
using CodeStock.Core.Models;

namespace CodeStock.Core
{
    public interface ITekConfService
    {
        Task<List<Conference>> GetConferences();
    }
}