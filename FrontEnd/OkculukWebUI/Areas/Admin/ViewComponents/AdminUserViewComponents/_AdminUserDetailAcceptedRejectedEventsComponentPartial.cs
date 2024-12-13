using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.UserDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminUserViewComponents
{
    public class _AdminUserDetailAcceptedRejectedEventsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminUserDetailAcceptedRejectedEventsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/GetAllEventByUserId?userId="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AdminResultAllEventByUserId>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
