using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RentACar.Model;
using RentACar.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpPost("LoginKullanici")]
        public dynamic LoginKullanici([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string mailAdress = json.MailAdress;
            string parola = json.Parola;

            Kullanici item = repo.KullaniciRepository.FindByCondition(k => k.MailAdress == mailAdress && k.Parola == parola).SingleOrDefault<Kullanici>();


            if (item != null)
            {
                //cashing kullanilabilir
                Rol rol = repo.RolRepository.FindByCondition(r => r.Id == item.RolId).SingleOrDefault<Rol>();

                Dictionary<string, object> claims = new Dictionary<string, object>();


                claims.Add(ClaimTypes.Role, rol.Ad);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("VektörelKursAracKiralamaWebProjesi");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                if (item.AktifMi == false)
                {
                    return new
                    {
                        success = false,
                        message = "Kullanıcı Kaydınız Devredışı Bırakılmış Müşteri Hizmetleri İle İletişime Geçiniz."
                    };
                }

                return new
                {
                    success = true,
                    data = tokenHandler.WriteToken(token),
                    rol = rol?.Ad
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Mail Adresiniz Veya Parolanız Hatalı Tekrar Deneyin"
                };
            }
        }

        [HttpPost("LoginSube")]
        public dynamic LoginSube([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string mailAdress = json.MailAdress;
            string parola = json.Parola;

            Sube item = repo.SubeRepository.FindByCondition(k => k.MailAdress == mailAdress && k.Parola == parola).SingleOrDefault<Sube>();

            
            if (item != null)
            {
                //cashing kullanilabilir
                Rol rol = repo.RolRepository.FindByCondition(r => r.Id == item.RolId).SingleOrDefault<Rol>();

                Dictionary<string, object> claims = new Dictionary<string, object>();


                claims.Add(ClaimTypes.Role, rol.Ad);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("VektörelKursAracKiralamaWebProjesi");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                if (item.AktifMi == false)
                {
                    return new
                    {
                        success = false,
                        message = "Şube Kaydınız Devredışı Bırakılmış Müşteri Hizmetleri İle İletişime Geçiniz."
                    };
                }

                return new
                {
                    success = true,
                    data = tokenHandler.WriteToken(token),
                    rol = rol?.Ad
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Mail Adresiniz Veya Parolanız Hatalı Tekrar Deneyin"
                };
            }
        }
    }
}
