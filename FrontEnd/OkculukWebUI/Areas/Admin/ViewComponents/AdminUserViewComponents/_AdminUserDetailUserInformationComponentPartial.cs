using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.UserDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminUserViewComponents
{
    public class _AdminUserDetailUserInformationComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminUserDetailUserInformationComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
              
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Users/ByIdForAdmin?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value =JsonConvert.DeserializeObject<AdminResultUserInformation>(jsonData);
                return View(value);
            }

            return View();  
        }
    }
}
