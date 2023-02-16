using IdentityServer4.Models;

namespace IndentityServerCenter
{
    public class Config
    {
        public static  IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> { new ApiResource("api","My Api") };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> { new Client()
            {
              ClientId = "client",
              AllowedGrantTypes = {  GrantType.ClientCredentials },
              ClientSecrets = { new Secret("secret".Sha256()) },
              AllowedScopes = { "api" },  
            }
            };
        }
    }
}
