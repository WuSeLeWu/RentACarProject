namespace RentACar.Web.Code
{
    public class Repo
    {
        public static class Session
        {

            public static string? MailAdress
            {
                get
                {
                    string ad = new HttpContextAccessor().HttpContext.Session.GetString("MailAdress");
                    return ad;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("MailAdress", value ?? "");
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value ?? "");
                }
            }
            public static string? Rol
            {
                get
                {
                    string rol = (new HttpContextAccessor()).HttpContext.Session.GetString("Rol");
                    return rol;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Rol", value ?? "");
                }
            }
        }
    }
}
