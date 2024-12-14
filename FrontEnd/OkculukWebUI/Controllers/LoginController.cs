using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using OkculukDto.LoginDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebUI.Models;

namespace OkculukWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto loginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content=new StringContent(JsonSerializer.Serialize(loginDto),Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7082/api/Login",content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler =new JwtSecurityTokenHandler(); // token ı okumak için kullanıyorum
                    var token = handler.ReadJwtToken(tokenModel.Token); //api den dönen token ı çözümledim
                    var claims=token.Claims.ToList(); // token ın içindeki bilgileri yani claimsleri bir listeye ekledim.
                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("accessToken", tokenModel.Token)); // token ı bir claim olarak ekledim. 
                        //access token key ini kullanarak daha sonra bu token e erişebilirim istersem ama zaten az sonra sisgninasync yaparak
                        //bu token içindeki bilgileri bir kimlik haline getirerek giriş yaptığım için buna çok gerek yok sanırım.
                        var claimsIdentity=new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc=tokenModel.ExpireDate,
                            IsPersistent=true
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProps);
                        return RedirectToAction("Events", "Event", new {area="Hakem"}); // burayı daha sonra değiştirebilirim
                    }
                }
            }
            return View();
        }
    }
}
