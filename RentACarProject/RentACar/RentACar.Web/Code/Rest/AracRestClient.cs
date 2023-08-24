using Newtonsoft.Json.Linq;
using RestSharp;

namespace RentACar.Web.Code.Rest
{
    public class AracRestClient : BaseRestClient
    {
        public dynamic AracGetir(int id)
        {
            RestRequest req = new RestRequest($"/Arac/AracDetayGetir/{id}", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
