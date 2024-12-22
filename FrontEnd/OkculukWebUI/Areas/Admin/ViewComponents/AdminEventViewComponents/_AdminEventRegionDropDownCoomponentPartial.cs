using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.RegionDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminEventViewComponents
{
    public class _AdminEventRegionDropDownCoomponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminEventRegionDropDownCoomponentPartial(IHttpClientFactory httpClientFactory)
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
                var regions=JsonConvert.DeserializeObject<List<ResultAllRegion>>(jsonData);
                return View(regions);
            }

            return View();
        }
    }
}
