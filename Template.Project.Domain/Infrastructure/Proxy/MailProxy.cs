using Template.Project.Domain.Infrastructure.Proxy.Interfaces;
using Template.Project.Domain.Infrastructure.Proxy.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

namespace Template.Project.Domain.Infrastructure.Proxy
{
    public class MailProxy : IMailProxy
    {
        private readonly static HttpClient _httpResponseMessage = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MailProxy(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SendMailMessage(MailModel mailModel)
        {
            try
            {
                var apiUrl = 
                    _httpContextAccessor.HttpContext.Request.Host.Value;

                if (apiUrl.Contains("localhost"))
                    apiUrl = "http://localhost:53191/api/";

                var requestUri = 
                    new Uri($"{_httpContextAccessor.HttpContext.Request.Scheme}://{apiUrl}/api/mail/SendMailByTemplate");

                var jsonContent = 
                    JsonConvert.SerializeObject(mailModel);

                var contentString = 
                    new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = 
                    await _httpResponseMessage.PostAsync(requestUri, contentString);

                return response == null || !response.IsSuccessStatusCode
                    ? throw new Exception($"Error sending mail: {response.StatusCode}")
                    : true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error sending mail: {ex}");
            }
        }
    }
}
