using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperMvcCRUD2.Models;
using Newtonsoft.Json;
using RestSharp;

public static class WebApiHelper
{
    //private static readonly string apiBaseUrl = "http://localhost:44385/api";
    //public class BolumApiClient
    //{
    //    private readonly HttpClient _httpClient;

    //    public BolumApiClient(string baseUri)
    //    {
    //        _httpClient = new HttpClient { BaseAddress = new Uri(baseUri) };
    //        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //    }

    //    public async Task<BolumModel> GetBolumByIdAsync(int id)
    //    {
    //        var response = await _httpClient.GetAsync($"api/Bolum/{id}");

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return await response.Content.ReadAsAsync<BolumModel>();
    //        }


    //        return null;
    //    }

    //    public async Task<bool> AddOrUpdateBolumAsync(BolumModel bolum)
    //    {
    //        var response = await _httpClient.PostAsJsonAsync("api/bolum", bolum);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return true;
    //        }


    //        return false;
    //    }

    //    public async Task<bool> DeleteBolumAsync(int id)
    //    {
    //        var response = await _httpClient.DeleteAsync($"api/Bolum/BolumDelete{id}");

    //        if (response.IsSuccessStatusCode)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //}

    //public static async Task<List<BolumModel>> GetBolumList()
    //{
    //    try
    //    {
    //        var options = new RestClientOptions("https://localhost:44385")
    //        {
    //            MaxTimeout = -1,
    //        };
    //        var client = new RestClient(options);
    //        var request = new RestRequest("/api/Bolum/GetAllBolum", Method.Get);
    //        RestResponse response = await client.ExecuteAsync(request);

    //        return JsonConvert.DeserializeObject<List<BolumModel>>(response.Content);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }
    //}


    //public static async Task<bool> CreateBolum(BolumModel bolumModel)
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        string apiUrl = "https://localhost:44385/api/Bolum/CreateBolum";

    //        var jsonBody = JsonConvert.SerializeObject(new
    //        {
    //            //bolumID = bolumModel.BolumID,
    //            bolumAd = bolumModel.BolumAd
    //        });

    //        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

    //        return response.IsSuccessStatusCode;
    //    }

    //}
    //public static async Task<List<BolumModel>> BolumList()
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        string apiUrl = "https://localhost:44385/api/Bolum/GetAllBolum";
    //        HttpResponseMessage response = await client.GetAsync(apiUrl);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            string data = await response.Content.ReadAsStringAsync();
    //            return JsonConvert.DeserializeObject<List<BolumModel>>(data);
    //        }
    //        else
    //        {
    //            return new List<BolumModel>();
    //        }
    //    }
    //}

    //public static async Task<bool> UpdateBolum(BolumModel updatedBolum)
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        string apiUrl = "https://localhost:44385/api/Bolum/UpdateBolum";


    //        var jsonBody = JsonConvert.SerializeObject(new
    //        {
    //            bolumID = updatedBolum.BolumID,
    //            bolumAd = updatedBolum.BolumAd
    //        });

    //        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = await client.PutAsync(apiUrl, content);
    //        return response.IsSuccessStatusCode;
    //    }
    //}


    //public static async Task<bool> DeleteBolum(int id)
    //{
    //    var options = new RestClientOptions("https://localhost:44385")
    //    {
    //        MaxTimeout = -1,
    //    };

    //    var client = new RestClient(options);
    //    var request = new RestRequest($"/api/Bolum/DeleteBolum/{id}", Method.Delete);
    //    request.AddHeader("Content-Type", "application/json");

    //    RestResponse response = await client.ExecuteAsync(request);
    //    Console.WriteLine(response.Content);
    //    return response.IsSuccessStatusCode;
    //}

}


