using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
        const string _mobile = "84908842280";
        const string _service_id = "SGN-BIKE";
        static async Task Main(string[] args)
        {
            var orderRequest = new OrderRequest();
            orderRequest.ServiceId = _service_id;
            orderRequest.Points = new List<OrderPoint>();
            orderRequest.Points.Add(new OrderPoint
            {
                Address = "725 Hẻm số 7 Thành Thái, Phường 14, Quận 10, Hồ Chí Minh, Việt Nam",
                Latitude = 10.7692105,
                Longitude = 106.6637935,
                ShortAddress = "Quận 10",
                Name = "nmbmb",
                Cod = 340000
            });
            orderRequest.Points.Add(new OrderPoint
            {
                Address = "Miss Ao Dai Building, 21 Nguyễn Trung Ngạn, Bến Nghé, Quận 1, Hồ Chí Minh",
                Latitude = 10.7828887,
                Longitude = 106.704898,
                ShortAddress = "Quận 10",
                Mobile = "0987 344 234",
                Name = "Bao",
                Remarks = "call me",
                Cod=340000
            }); 

            
            string token = null;
            var url = $"{_host}/v1/partner/register_account?api_key={_key}&mobile={_mobile}";
            var client = new HttpClient();
            var response = await client.GetAsync(url, cancellationToken: default);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var register = JsonConvert.DeserializeObject<RegisterResponse>(jsonResponse);
                token = register.Token;
                Console.WriteLine("Create new token:{0}", token);
            }

            var url2 = $"{_host}/v1/order/estimated_fee";
            var url3 = $"{_host}/v1/order/create";

            ICollection<KeyValuePair<string, string>> content = new Dictionary<string, string>();
            content.Add(new KeyValuePair<string, string>("token", token));
            content.Add(new KeyValuePair<string, string>("order_time", orderRequest.OrderTime.ToString()));
            content.Add(new KeyValuePair<string, string>("path", JsonConvert.SerializeObject(orderRequest.Points)));
            content.Add(new KeyValuePair<string, string>("service_id", orderRequest.ServiceId));
            content.Add(new KeyValuePair<string, string>("requests", JsonConvert.SerializeObject(orderRequest.Requests)));

            var request2 = new HttpRequestMessage(HttpMethod.Post, url3) { Content = new FormUrlEncodedContent(content) };
            var response2 = await client.SendAsync(request2);
            var json2 = await response2.Content.ReadAsStringAsync();
            Console.WriteLine(json2);
            //var order = JsonConvert.DeserializeObject<Order>(json2);
            var orderResponse = JsonConvert.DeserializeObject<OrderResponse>(json2);
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(orderResponse))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(orderResponse);
                Console.WriteLine("{0}:{1}", name, value);
            }

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(orderResponse.Order))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(orderResponse.Order);
                Console.WriteLine("{0}:{1}", name, value);
            }
        }
    }
}
