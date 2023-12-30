namespace TARA.DATAENTRY.API.Models.Users
{
    public class AuthResponseDto
    {
        public string Userid { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
