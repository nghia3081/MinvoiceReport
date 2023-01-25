using MinvoiceReport.Extensions;
using MinvoiceReport.Utils.Extensions;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace MinvoiceReport.Utils
{
    public class ApiClient : HttpClient
    {
        public ApiClient(string baseApiUrl)
        {
            if (baseApiUrl.IsNullOrEmpty()) throw new ArgumentNullException();
            this.BaseAddress = new Uri(baseApiUrl);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public T Get<T>(string requestUri) where T : class
        {
            HttpResponseMessage response = this.GetAsync(requestUri).Result;
            response.EnsureSuccessStatusCodeOption();
            var responseJson = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return responseJson;
        }
        public byte[] GetFile(string requestUri)
        {
            HttpResponseMessage response = this.GetAsync(requestUri).Result;
            response.EnsureSuccessStatusCodeOption();
            var responseJson = response.Content.ReadAsByteArrayAsync().Result;
            return responseJson;

        }
        public U Post<T, U>(string requestUri, T data) where T : class where U : class
        {
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.PostAsync(requestUri, content).Result;
            response.EnsureSuccessStatusCodeOption();
            var responseJson = response.Content.ReadAsAsync<U>().Result;
            return responseJson;
        }
    }
}
