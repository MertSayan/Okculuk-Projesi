using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.GoogleFormDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminMainGoogleFormDatasComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminMainGoogleFormDatasComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/GoogleForms");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAllGoogleFormDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
