using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.RegionDtos;

namespace OkculukWebUI.ViewComponents.RegisterViewComponent
{
    public class _ResultAllRegionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ResultAllRegionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Regions");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllRegion>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
