using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SerializeJsonDemo
{
    class Program
    {
        const string _host = "https://apistg.ahamove.com/";
        const string _key = "e383621e871dd41d6f254f7eca3f25d6";
        const string _mobile = "0868217945";
        const string _mobileV1 = "84908842280";
        //const string _service_id = "SGN-BIKE";
        const string _service_id = "SGN-TMDT";
        const string _request_id = "SGN-TMDT-TRANSFER-COD";
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var orderTime = 0;
            var paymentMethod = "BALANCE";

            var points = new List<OrderPoint>();
            points.Add(new OrderPoint
            {
                Address = "FPT town",
                Latitude = 10.835668,
                Longitude = 106.807654,
                ShortAddress = "Thủ Đức",
                Name = "Test Shopper",
            });
            points.Add(new OrderPoint
            {
                Address = "ĐẠI HỌC FPT HCM Q9",
                Latitude = 10.841889,
                Longitude = 106.809325,
                ShortAddress = "ĐẠI HỌC FPT",
                Mobile = "0987 344 234",
                Name = "Bao",
                Remarks = "call me",
                Cod = 510000
            });
            var request = new List<object>();
            request.Add(
                new 
                {
                    _id= "SGN-TMDT-TRANSFER-COD",
                    price = 510000
                }
                );
            
            string token = null;
            var url = $"{_host}/v1/partner/register_account?api_key={_key}&mobile={_mobile}";
            var client = new HttpClient();
            var response = await client.GetAsync(url, cancellationToken: default);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var register = JsonConvert.DeserializeObject<RegisterResponse>(jsonResponse);
                token = register.Token;
                Console.WriteLine("Create new token:");
                Console.WriteLine(token);
            }

            var url2 = $"{_host}/v1/order/estimated_fee";
            var url3 = $"{_host}/v1/order/create";
            var url4 = $"{_host}/v1/order/list";
            var url5 = $"{_host}/v1/order/detail";

            ICollection<KeyValuePair<string, string>> content = new Dictionary<string, string>();
            content.Add(new KeyValuePair<string, string>("token", token));
            content.Add(new KeyValuePair<string, string>("order_time", orderTime.ToString()));
            content.Add(new KeyValuePair<string, string>("path", JsonConvert.SerializeObject(points)));
            content.Add(new KeyValuePair<string, string>("service_id", _service_id));
            content.Add(new KeyValuePair<string, string>("requests", JsonConvert.SerializeObject(request)));
            content.Add(new KeyValuePair<string, string>("payment_method", paymentMethod));


            var request2 = new HttpRequestMessage(HttpMethod.Post, url3) { Content = new FormUrlEncodedContent(content) };
            var response2 = await client.SendAsync(request2);
            var json2 = await response2.Content.ReadAsStringAsync();

            Console.WriteLine(json2);
            ////var order = JsonConvert.DeserializeObject<Order>(json2); // for url2
            //var order = JObject.Parse(json2)["order"].ToObject<Order>();// for url3

            //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(order))
            //{
            //    string name = descriptor.Name;
            //    object value = descriptor.GetValue(order);
            //    Console.WriteLine("{0}:{1}", name, value);
            //}

        }
    }
}
