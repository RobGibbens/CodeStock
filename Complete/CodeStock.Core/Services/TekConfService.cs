using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CodeStock.Core.Models;
using ModernHttpClient;
using Newtonsoft.Json;

namespace CodeStock.Core
{
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

    //public class TekConfService : ITekConfService
    //{
    //    public async Task<List<Conference>> GetConferences()
    //    {
    //        IEnumerable<Conference> conferences;

    //        using (var httpClient = CreateClient())
    //        {
    //            string json = await httpClient.GetStringAsync("http://api.tekconf.com/v1/conferences").ConfigureAwait(false);
    //            var dtos = await Task.Run(() => JsonConvert.DeserializeObject<List<ConferenceDto>>(json)).ConfigureAwait(false);
    //            conferences = await Task.Run(() => Mapper.Map<List<Conference>>(dtos)).ConfigureAwait(false);
    //        }

    //        return conferences.ToList();
    //    }

    //    private HttpClient CreateClient()
    //    {
    //        var httpClient = new HttpClient(new NativeMessageHandler());

    //        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

    //        return httpClient;
    //    }
    //}
}