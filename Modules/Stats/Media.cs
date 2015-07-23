using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Media
    {
        private readonly Client _client;

        public Media(Client client)
        {
            _client = client;
        }

        public async Task<Models.Stats.Media> Show(string hashedId)
        {
            var data = await _client.Get($"/stats/medias/{hashedId}.json");
            return _client.Hydrate<Models.Stats.Media>(data);
        }
    }
}