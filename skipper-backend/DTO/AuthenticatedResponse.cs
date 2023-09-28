namespace skipper_backend.DTO
{
    public class AuthenticatedResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public IList<string> Roles { get; set; }

    }
}
