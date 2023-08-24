using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace RentACar.Web.Code.Rest
{
    public class UserRestClient : BaseRestClient
    {
        public dynamic Login(string mailAdress, string parola)
        {

            RestRequest req = new RestRequest("/Auth/LoginKullanici", Method.Post);
            req.AddJsonBody(new
            {
                MailAdress = mailAdress,
                Parola = parola
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
