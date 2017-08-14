using MobileAshApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MobileAshApi.BL
{
    public class WebServiceClient
    {
        public async Task<T> WebClientResponse<T>(string url, object param)
        {
            HttpClientHandler handler = new HttpClientHandler();

            HttpClient httpClient = new HttpClient(handler);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, param);//, new { mn = mobile });

            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync().Result;

            Models.JSonResultParser parser = new JSonResultParser();

            return parser.Parse<T>(result);
        }
    }
}