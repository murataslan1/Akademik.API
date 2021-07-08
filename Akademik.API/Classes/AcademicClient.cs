using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Akademik.API.Classes.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Akademik.API.Classes
{
    public interface IAcademicClient
    {
        Task<HttpResponseMessage> Verify();
        Task<string> SearchWResearcherID(string rid);
    }

    public class AcademicClient : IAcademicClient
    {
        private ITokenHandler _tokenHandler;

        private string _academicEndPoint = "academic";
        


        private HttpClient _client;
        public AcademicClient(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _client = new HttpClient {BaseAddress = new Uri("https://publons.com/api/v2/")};
            _client.DefaultRequestHeaders.Add("Authorization", $"Token e6859f04467452254f9ec51ba4d14ccafefdae80");
            
        }
        
        public async Task<string> ContentHandler(HttpResponseMessage req)
        {
            var res = await req.Content.ReadAsStringAsync();
            var academicanDto = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(res));
       
            return academicanDto;
        }

        public async Task<HttpResponseMessage> Verify()
        {
            var res = await _client.GetAsync($"{_academicEndPoint}");
            if (res.StatusCode == HttpStatusCode.Unauthorized)
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            return res;
        }
        
        //


        public async Task<string> SearchWResearcherID(string rid)
        {
            var res = await _client.GetAsync($"{_academicEndPoint}/{rid}/");
            var convertedObj = await ContentHandler(res);
            return  convertedObj;
        }
        
        
        
        
        
    }
}