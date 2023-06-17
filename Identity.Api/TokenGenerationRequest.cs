namespace Identity.Api;

public class TokenGenerationRequest
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public Dictionary<string,string> CustomClaims { get; set; }
}