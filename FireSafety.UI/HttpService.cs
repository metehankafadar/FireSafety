using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FireSafety.UI
{
    public class HttpService
    {
        public T getService<T>(string url)
        {
            T result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                //HTTP GET
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var resresult = responseTask.Result;
                if (resresult.IsSuccessStatusCode)
                {
                    var readTask = resresult.Content.ReadAsStringAsync();
                    readTask.Wait();
                    result = JsonConvert.DeserializeObject<T>(readTask.Result);
                    return result;
                }

            }
            return default(T);
        }
        public TResponse postServiceAsync<TResponse, TRequest>(string url, TRequest request)
        {
            TResponse result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44316/api/");
                //HTTP GET
                HttpContent content = new StringContent(JsonConvert.SerializeObject(request), UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync(url, content);
                responseTask.Wait();

                var resresult = responseTask.Result;
                if (resresult.IsSuccessStatusCode)
                {
                    var readTask = resresult.Content.ReadAsStringAsync();
                    readTask.Wait();
                    result = JsonConvert.DeserializeObject<TResponse>(readTask.Result);
                    return result;
                }

            }
            return default(TResponse);
        }

    }
}