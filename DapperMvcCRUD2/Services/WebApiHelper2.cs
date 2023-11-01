using DapperMvcCRUD2.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DapperMvcCRUD2.Services
{
    public class WebApiHelper2
    {
        private static readonly string apiBaseUrl = "http://localhost:7042/api";
        public class PersonelApiClient
        {
            private readonly HttpClient _httpClient;

            public PersonelApiClient(string baseUri)
            {
                _httpClient = new HttpClient { BaseAddress = new Uri(baseUri) };
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            public async Task<PersonelModel> GetPersonelByIdAsync(int id)
            {
                var response = await _httpClient.GetAsync($"api/Personel/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonelModel>();
                }


                return null;
            }

            public async Task<bool> AddOrUpdatePersonelAsync(PersonelModel personel)
            {
                var response = await _httpClient.PostAsJsonAsync("api/personel", personel);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }


                return false;
            }

            public async Task<bool> DeletePersonelAsync(int id)
            {
                var response = await _httpClient.DeleteAsync($"api/Personel/PersonelDelete{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public static async Task<List<PersonelModel>> GetPersonelList()
        {
            try
            {
                var options = new RestClientOptions("https://localhost:7042")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Personel/GetAllPersonel", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                return JsonConvert.DeserializeObject<List<PersonelModel>>(response.Content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static async Task<bool> CreatePersonel(PersonelModel personelModel)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7042/api/Personel/CreatePersonel";

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    bolumID = personelModel.BolumID,
                    ad = personelModel.Ad,
                    soyad = personelModel.Soyad,
                    doğumtarihi = personelModel.DoğumTarihi,
                });

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                return response.IsSuccessStatusCode;
            }

        }
        public static async Task<List<PersonelModel>> PersonelList()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7042/api/Personel/GetAllPersonel";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PersonelModel>>(data);
                }
                else
                {
                    return new List<PersonelModel>();
                }
            }
        }

        public static async Task<bool> UpdatePersonel(PersonelModel updatedPersonel)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7042/api/Personel/UpdatePersonel";


                var jsonBody = JsonConvert.SerializeObject(new
                {
                    personelID = updatedPersonel.PersonelID,
                    bolumID = updatedPersonel.BolumID,
                    ad = updatedPersonel.Ad,
                    soyad = updatedPersonel.Soyad,
                    doğumtarihi = updatedPersonel.DoğumTarihi
                });

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(apiUrl, content);
                return response.IsSuccessStatusCode;
            }
        }


        public static async Task<bool> DeletePersonel(int id)
        {
            var options = new RestClientOptions("https://localhost:7042")
            {
                MaxTimeout = -1,
            };

            var client = new RestClient(options);
            var request = new RestRequest($"/api/Personel/DeletePersonel/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return response.IsSuccessStatusCode;
        }

    }
}
