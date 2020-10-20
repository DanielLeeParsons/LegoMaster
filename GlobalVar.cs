using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace LegoMaster
{
    public class GlobalVar
    {
        private static readonly string runmode = Environment.GetEnvironmentVariable("RUN_MODE");
        private static readonly string vaulturi = Environment.GetEnvironmentVariable("VAULT_URL");
        public string db1UserSecret = "";
        public string db1PwSecret = "";
        public string db1ConstrSecret = "";
        public string db1CatSecret = "";
        public string db1ConString = "";
        public GlobalVar()
        {
            if (runmode == "DEV")
            {
                db1UserSecret = GetSecret(Environment.GetEnvironmentVariable("DB1_USER_SECRETNAME")).Result;
                db1PwSecret = GetSecret(Environment.GetEnvironmentVariable("DB1_PW_SECRETNAME")).Result;
                db1ConstrSecret = GetSecret(Environment.GetEnvironmentVariable("DB1_CONSTR_SECRETNAME")).Result;
                db1CatSecret = GetSecret(Environment.GetEnvironmentVariable("DB1_CAT1_SECRETNAME")).Result;
                db1ConString = GetConnection(db1ConstrSecret, db1CatSecret, db1UserSecret, db1PwSecret);
            }
            else
            {
                db1UserSecret = Environment.GetEnvironmentVariable("DB1_USER_SECRETNAME");
                db1PwSecret = Environment.GetEnvironmentVariable("DB1_PW_SECRETNAME");
                db1ConstrSecret = Environment.GetEnvironmentVariable("DB1_CONSTR_SECRETNAME");
                db1CatSecret = Environment.GetEnvironmentVariable("DB1_CAT1_SECRETNAME");
                db1ConString = GetConnection(db1ConstrSecret, db1CatSecret, db1UserSecret, db1PwSecret);
            }
        }

        private static async Task<string> GetSecret(string secretName)
        {
            string vaulturi = Environment.GetEnvironmentVariable("VAULT_URL");
            try
            {
                var secretClient = new SecretClient(new Uri(vaulturi), new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    ExcludeVisualStudioCredential = true,
                    ExcludeVisualStudioCodeCredential = true
                }));
                KeyVaultSecret secret = await secretClient.GetSecretAsync(secretName);

                return (secret.Value.ToString());
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private string GetConnection(string db, string cat, string user, string pw)
        {
            string connectionstring = $"Server=tcp:{db},1433;Initial Catalog={cat};Persist Security Info=False;User ID={user};Password='{pw}';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return connectionstring;
        }
    }
}





