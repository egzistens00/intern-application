using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace InternAPI.Services
{
    public class VaultService
    {
        private readonly VaultClient _vaultClient;

        public VaultService()
        {
            var vaultUri = "http://127.0.0.1:8200";
            var vaultToken = Environment.GetEnvironmentVariable("VAULT_TOKEN");
            // Replace with secure token source later

            var authMethod = new TokenAuthMethodInfo(vaultToken);
            var settings = new VaultClientSettings(vaultUri, authMethod);
            _vaultClient = new VaultClient(settings);
        }

        public async Task<(string Username, string Password)> GetDbCredentialsAsync()
        {
            var secret = await _vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: "db", mountPoint: "secret");
            var data = secret.Data.Data;

            // Validate the presence of required keys
            if (!data.TryGetValue("username", out object? usernameObj) || usernameObj is null ||
                !data.TryGetValue("password", out object? passwordObj) || passwordObj is null)
            {
                throw new Exception("Vault secret is missing 'username' or 'password'.");
            }

            // Now these are guaranteed non-null
            var username = usernameObj.ToString()!;
            var password = passwordObj.ToString()!;

            return (username, password);
        }


    }
}
