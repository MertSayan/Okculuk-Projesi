using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.UserDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminEventViewComponents
{
    public class _AdminEventGetAllUserForSpesicifRegionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminEventGetAllUserForSpesicifRegionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {   
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Users/GetAllUserForVisibleEvent");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var users=JsonConvert.DeserializeObject<List<ResultAllUserForVisibleEvent>>(jsonData);  
                return View(users);
            }
            return View();
        }
    }
}
