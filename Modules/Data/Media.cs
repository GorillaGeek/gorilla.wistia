using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Media
    {
        private readonly Client _client;

        public Media(Client client)
        {
            _client = client;
        }
        
        public async Task<Models.Media> Show(string hashedId)
        {
            var data = await _client.Get($"/medias/{hashedId}.json");
            return _client.Hydrate<Models.Media>(data);
        }

        public async Task<List<Models.Media>> List(int page = 1, int perPage = 10, string name = null, string projectId = null, string hashedId = null, string type = null)
        {
            var pars = new Dictionary<string, string>
            {
                ["page"]       = page.ToString(),
                ["per_page"]   = perPage.ToString(),
                ["project_id"] = projectId,
                ["name"]       = name,
                ["hashed_id "] = hashedId,
                ["type"]       = type
            };

            var data = await _client.Get("/medias.json", pars);
            return _client.Hydrate<List<Models.Media>>(data);
        }

        public async Task<Models.Media> Update(string hashedId, string name, string description = null, string new_still_media_id = null)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["description"] = description,
                ["new_still_media_id"] = new_still_media_id
            };

            var data = await _client.Put($"/medias/{hashedId}.json", parameters);
            return _client.Hydrate<Models.Media>(data);
        }

        public async Task<Models.Media> Delete(string hashedId)
        {
            var data = await _client.Delete($"/medias/{hashedId}.json");
            return _client.Hydrate<Models.Media>(data);
        }

        public async Task<Models.Media> Copy(string hashedId)
        {
            var data = await _client.Post($"/medias/{hashedId}/copy.json");
            return _client.Hydrate<Models.Media>(data);
        }
    }
}