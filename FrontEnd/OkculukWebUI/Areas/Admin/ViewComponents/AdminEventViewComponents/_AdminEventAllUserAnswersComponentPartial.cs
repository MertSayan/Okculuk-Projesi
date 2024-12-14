using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;
using OkculukDto.UserDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminEventViewComponents
{
    public class _AdminEventAllUserAnswersComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminEventAllUserAnswersComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Users/GetAllUserByEventId?eventId="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<AdminResultAllUserByEventId>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
