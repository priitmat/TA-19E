using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using StarwarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsApp.Services
{
    public class RemoteDataService
    {
        public async Task<People> GetStarwarsPeople()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.dev/api/people/");
            People data = null;
            if(response != null)
            {
                data = JsonConvert.DeserializeObject<People>(response);
            }
            return data;         
        }
    }
}