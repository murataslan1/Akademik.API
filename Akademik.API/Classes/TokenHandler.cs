using System;
using System.Collections.Generic;
using System.Linq;
using Akademik.API.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;

namespace Akademik.API.Classes
{
    public class TokenHandler : ITokenHandler
    {
   
        private string _token;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

      
        }
        
        public bool SetToken(string token)
        {
            try
            {
                if (_httpContextAccessor.HttpContext != null)
                    _httpContextAccessor.HttpContext.Session.SetString(ESession.TokenSession.ToString(), token);
                _token = token;
            }
            catch(Exception ex)
            {
                
                return false;
            }

            return true;
        }
        public string GetToken() =>
             _httpContextAccessor.HttpContext == null ? string.Empty : _httpContextAccessor.HttpContext.Session.GetString(ESession.TokenSession.ToString());
 
    }
}