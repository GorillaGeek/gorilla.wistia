using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Data
{
    public class Project
    {
        private readonly Client _client;

        public Project(Client client)
        {
            _client = client;
        }

        public async Task<Models.Project> Show(string hashedId)
        {
            var data = await _client.Get($"/projects/{hashedId}.json");
            return _client.Hydrate<Models.Project>(data);
        }

        public async Task<List<Models.Project>> List(int page = 1, int perPage = 10)
        {
            var pars = new Dictionary<string, string>
            {
                ["page"]     = page.ToString(),
                ["per_page"] = perPage.ToString()
            };
            
            var data = await _client.Get("/projects.json", pars);
            return _client.Hydrate<List<Models.Project>>(data);
        }

        public async Task<Models.Project> Create(string name, bool anonymousCanUpload = false,
            bool anonymousCanDownload = false, bool @public = false, string adminEmail = null)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["anonymousCanUpload"] = anonymousCanUpload ? "1" : null,
                ["anonymousCanDownload"] = anonymousCanDownload ? "1" : null,
                ["public"] = @public ? "1" : null
            };

            if (!string.IsNullOrWhiteSpace(adminEmail))
            {
                parameters.Add("adminEmail", adminEmail);
            }

            var data = await _client.Post("/projects.json", parameters);
            return _client.Hydrate<Models.Project>(data);
        }

        public async Task<Models.Project> Update(string hashedId, string name, bool anonymousCanUpload = false,
            bool anonymousCanDownload = false, bool @public = false)
        {
            var parameters = new Dictionary<string, string>
            {
                ["name"] = name,
                ["anonymousCanUpload"] = anonymousCanUpload ? "1" : "0",
                ["anonymousCanDownload"] = anonymousCanDownload ? "1" : "0",
                ["public"] = @public ? "1" : "0"
            };

            var data = await _client.Put($"/projects/{hashedId}.json", parameters);
            return _client.Hydrate<Models.Project>(data);
        }

        public async Task<Models.Project> Delete(string hashedId)
        {
            var data = await _client.Delete($"/projects/{hashedId}.json");
            return _client.Hydrate<Models.Project>(data);
        }

        public async Task<Models.Project> Copy(string hashedId)
        {
            var data = await _client.Post($"/projects/{hashedId}/copy.json");
            return _client.Hydrate<Models.Project>(data);
        }

    }
}