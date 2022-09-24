using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Umbraco.React.Ssr.Prerendering
{
    [HtmlTargetElement(Attributes = PrerenderModuleAttributeName)]
    public class PrerenderTagHelper : TagHelper
    {
        private const string PrerenderModuleAttributeName = "asp-prerender-module";
        private const string PrerenderDataAttributeName = "asp-prerender-data";

        private readonly HttpClient _httpClient;

        public PrerenderTagHelper(IConfiguration configuration)
        {
            var endpoint = configuration.GetSection("SsrEndpoint")?.Value;

            if (string.IsNullOrEmpty(endpoint))
            {
                var message = "Endpoint is null or empty.";
                throw new ArgumentNullException(message);
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(endpoint),
                Timeout = TimeSpan.FromSeconds(10)
            };
        }


        [HtmlAttributeName(PrerenderModuleAttributeName)]
        public string ModuleName { get; set; }

        [HtmlAttributeName(PrerenderDataAttributeName)]
        public object Parameters { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var json = JsonConvert.SerializeObject(
                Parameters, 
                new JsonSerializerSettings 
                { 
                    ContractResolver = new CamelCasePropertyNamesContractResolver() 
                }
            );

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", content);

            ViewContext.HttpContext.Response.StatusCode = (int)response.StatusCode;

            var result = await response.Content.ReadAsStringAsync();

            output.Content.SetHtmlContent(result);
        }
    }
}
