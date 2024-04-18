namespace WebUI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
