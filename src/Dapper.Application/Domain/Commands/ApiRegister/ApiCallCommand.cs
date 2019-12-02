using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Dapper.Api.Domain.Entities;

namespace Dapper.Application.Domain.Commands.ApiRegister
{
    public class ApiCallCommand
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private Request _request;

        public ApiCallCommand(IHttpClientFactory httpClientFactory, Request request)
        {
            _httpClientFactory = httpClientFactory;
            _request = request;
        }

        protected async Task<string> RunAsync(Request request)
        {
            //var httpClient = _httpClientFactory.CreateClient("api-b")
            var httpClient = _httpClientFactory.CreateClient("zuul-server");         
            var res = await httpClient.PostAsync("api/Example", _request ?? new Request( "gd_ti_integracao@brmalls.com.br", IList<"teste@gmail.com"> ,"teste","teste", 2)
            , new JsonMediaTypeFormatter());
            var content = await res.Content.ReadAsStringAsync();

            if (res.StatusCode == HttpStatusCode.InternalServerError)
                throw new Exception(content);

            if (res.StatusCode != HttpStatusCode.OK)
                return $"{res.StatusCode} - {content}";

            return await res.Content.ReadAsStringAsync();
        }
    }
}