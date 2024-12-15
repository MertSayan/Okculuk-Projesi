using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.UserDtos;

namespace OkculukWebUI.Areas.Hakem.ViewComponents.ProfileViewComponents
{
    public class _UserProfileComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserProfileComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int UserId)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Users/ById?id="+UserId);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UserProfileInformation>(jsonData);
                return View(value);
            }

            return View();
        }
    }
}
