namespace NLayer.Web.Models;

public class Payzee
{
    public string password { get; set; }
    public string lang { get; set; }
    public string email { get; set; }
}

public class PayzeeResponseResult
{
    public long userId { get; set; }
    public string Token { get; set; }
}

public class PayzeeResponse
{
    public bool fail { get; set; }
    public int statusCode { get; set; }
    public List<Payzee> Result { get; set; }
    public int count { get; set; }
    public object errorCode { get; set; }
    public object errorDescription { get; set; }
}