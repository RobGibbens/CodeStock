//CodeStock.Core/Services/TekConfService.cs
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
    public class TekConfService : ITekConfService
    {
        public async Task<List<Conference>> GetConferences()
        {
            IEnumerable<Conference> conferences = Enumerable.Empty<Conference>();

            using (var httpClient = CreateClient())
            {
                const string tekconfUrl = "http://api.tekconf.com/v1/conferences";
                string json = await httpClient.GetStringAsync(tekconfUrl).ConfigureAwait(false);

                //TODO : Deserialize json to strongly typed objects
                var dtos = await Task.Run(() =>
                                        JsonConvert.DeserializeObject<List<ConferenceDto>>(json)
                                 ).ConfigureAwait(false);
            }

            return conferences.ToList();
        }

        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler());

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            return httpClient;
        }
    }
}