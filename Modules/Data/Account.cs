using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Account
    {
        private readonly Client _client;

        public Account(Client client)
        {
            _client = client;
        }

        public async Task<Models.Account> Show()
        {
            var data = await _client.Get("/account.json");
            return _client.Hydrate<Models.Account>(data);
        }

    }
}