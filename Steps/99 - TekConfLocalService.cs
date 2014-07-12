//CodeStock.Core/Services/TekConfLocalService.cs
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CodeStock.Core.Models;

namespace CodeStock.Core
{
    //TODO : Create local service to read json (in case web is down)
    public class TekConfLocalService : ITekConfService
    {
        public async Task<List<Conference>> GetConferences()
        {
            var ts = Assembly.Load(new AssemblyName("CodeStock.Core")).GetManifestResourceStream(@"CodeStock.Core.conferences.json");
            var sr = new StreamReader(ts);
            string json = sr.ReadToEnd();

            var conferences = await Task.Run(() => JsonConvert.DeserializeObject<List<Conference>>(json));
            return conferences;
        }
    }
}