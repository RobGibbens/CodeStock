//CodeStock.Core/Services/ITekConfService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeStock.Core.Models;

namespace CodeStock.Core
{
	//TODO : Create interface to get conference data
    public interface ITekConfService
    {
        Task<List<Conference>> GetConferences();
    }
}