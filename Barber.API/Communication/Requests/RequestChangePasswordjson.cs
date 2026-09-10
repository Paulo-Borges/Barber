namespace Barber.API.Communication.Requests
{
    public class RequestChangePasswordjson
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
