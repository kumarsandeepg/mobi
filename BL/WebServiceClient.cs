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
        public async Task<T> WebClientResponse<T>(string url, object param, bool ensureStatus=true)
        {
            try
            {
                var result = await WebClientJSonStr(url, param, ensureStatus);
                Models.JSonResultParser parser = new JSonResultParser();

                return parser.Parse<T>(result);
            }
            catch(Exception) { throw; }
        }

        public async Task<string> WebClientJSonStr(string url, object param, bool ensureStatus)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();

                HttpClient httpClient = new HttpClient(handler);

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, param);//, new { mn = mobile });

                if (ensureStatus)
                {
                    response.EnsureSuccessStatusCode();
                }

                var result = response.Content.ReadAsStringAsync().Result;

                var root = Newtonsoft.Json.Linq.JObject.Parse(result);

                var d = root["d"].ToString();

                return d;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}