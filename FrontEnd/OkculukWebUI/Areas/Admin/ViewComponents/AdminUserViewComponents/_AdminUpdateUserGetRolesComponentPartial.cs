using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkculukDto.RoleDtos;

namespace OkculukWebUI.Areas.Admin.ViewComponents.AdminUserViewComponents
{
    
    public class _AdminUpdateUserGetRolesComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminUpdateUserGetRolesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7082/api/Roles");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<GetAllRoles>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
