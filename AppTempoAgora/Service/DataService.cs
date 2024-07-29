using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using AppTempoAgora;
using AppTempoAgora.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppTempoAgora.Service
{
    internal class DataService
    {
        public static async Task<Tempo?> GetPrevisaoDoTempo(string cidade)
        {
            // https://openweathermap.org/current#current_JSON
            // https://home.openweathermap.org/api_keys

            string appId = "6135072afe7f6cec1537d5cb08a5a1a2";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q=" +
                         $"{cidade}&units=metric&appid={appId}";

            Tempo tempo = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string Json = response.Content.ReadAsStringAsync().Result;

                    var rascunho = JSObject.Parse(Json);

                    DateTime time = DateTime(1970, 1, 1, 0, 0, 0, 0);
                    DateTime sunrise = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                    DateTime sunset = time.AddSeconds((double)rascunho["sys"]["sunrise"]).ToLocalTime();
                }

            }
        }
    }
