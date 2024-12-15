using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminUserViewComponents
{
    public class _AdminUserDetailEventCountComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminUserDetailEventCountComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/GetEventsCountByStatusAndUserId?userId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResutlEventsCountByUserId>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
