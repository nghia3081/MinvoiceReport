using MinvoiceReport.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
namespace MinvoiceReport.Utils.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static void EnsureSuccessStatusCodeOption(this HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized) throw new Exception("Vui lòng thoát ra và đăng nhập lại");
            if (response.StatusCode != HttpStatusCode.OK) throw new Exception("Có lỗi xảy ra");
            var responseContentString = response.Content.ReadAsStringAsync().Result;
            try
            {
                var responseJson = JObject.Parse(responseContentString);
                if (responseJson is null) throw new Exception("Có lỗi xảy ra");
                string message = responseJson?["message"]?.ToString();
                string error = responseJson?["error"]?.ToString();
                if (!message.IsNullOrEmpty() || !error.IsNullOrEmpty()) throw new Exception(error ?? message);
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
