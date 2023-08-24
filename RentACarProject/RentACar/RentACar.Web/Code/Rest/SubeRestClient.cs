using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace RentACar.Web.Code.Rest
{
    public class SubeRestClient : BaseRestClient
    {

        public dynamic LoginSube(string mailAdress, string parola)
        {
            RestRequest req = new RestRequest("/Auth/LoginSube", Method.Post);
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
