using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace laboras
{

    
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/edvinas68/laborjson/cars";

            //Http client siuncia "get request"
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                //readinamas stringas is response kontento
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //Printinamas jsonResponse
                //Console.WriteLine(jsonResponse);

                //Vykdomas Deserialize, Json atsakymas į C# array of type Post[]
                var myPosts = JsonConvert.DeserializeObject<List<Post>>(jsonResponse);
                //Printinamas arrayy objektai naudojant for each loop
                foreach (var post in myPosts)
                {
                    //Console.WriteLine($"{post.Id}  {post.Name}  {post.Year} {post.Engine}");
                    Console.WriteLine(String.Format("|{0,10}|{1,10}|{2,10}|{3,10}|", post.Id, post.Name, post.Year, post.Engine));

                }


                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Print exception message
                Console.WriteLine(e.Message);
            }
        }


    }
}
