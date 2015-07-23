using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Stats
{
    public class Project
    {
        private readonly Client _client;

        public Project(Client client)
        {
            _client = client;
        }

        public async Task<Models.Stats.Project> Show(string projectId)
        {
            var data = await _client.Get($"/stats/projects/{projectId}.json");
            return _client.Hydrate<Models.Stats.Project>(data);
        }
    }
}