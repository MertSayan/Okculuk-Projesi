using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.EventDtos;

namespace OkculukWebUI.Areas.Hakem.ViewComponents.EventViewComponents
{
    public class _EventDetailForAcceptOrRejectComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EventDetailForAcceptOrRejectComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync(int EventId)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Events/ById?id="+ EventId);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ResultEventForAcceptOrReject>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
