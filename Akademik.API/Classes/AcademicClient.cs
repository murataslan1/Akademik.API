using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Akademik.API.Classes.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Akademik.API.Classes
{
    public interface IAcademicClient
    {
        Task<HttpResponseMessage> Verify(string token);
        Task<string> SearchWResearcherID(string rid,string token);
    }

    public class AcademicClient : IAcademicClient
    {
        private ITokenHandler _tokenHandler;

        private string _academicEndPoint = "academic/";


        private HttpClient _client;

        public AcademicClient(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _client = new HttpClient {BaseAddress = new Uri("https://publons.com/api/v2/")};
        }

        public async Task<string> ContentHandler(HttpResponseMessage req)
        {
            var res = await req.Content.ReadAsStringAsync();
            var academicanDto = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(res));

            return academicanDto;
        }

        public async Task<HttpResponseMessage> Verify(string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            var res = await _client.GetAsync(_academicEndPoint);
            if (res.StatusCode == HttpStatusCode.Unauthorized)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            return res;
        }
        
        public async Task<string> SearchWResearcherID(string rid,string token)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Token " + token);
            var res = await _client.GetAsync($"{_academicEndPoint}/{rid}/");
            var convertedObj = await ContentHandler(res);
            return convertedObj;
        }
    }
}