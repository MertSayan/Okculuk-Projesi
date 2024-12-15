using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;

namespace OkculukWebUI.Areas.Hakem.ViewComponents.ProfileViewComponents
{
    public class _UserProfileEventsCountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserProfileEventsCountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int UserId)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/GetEventsCountByStatusAndUserId?userId="+UserId);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResutlEventsCountByUserId>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
