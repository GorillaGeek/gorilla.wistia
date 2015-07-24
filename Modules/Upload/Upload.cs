using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gorilla.Wistia.Modules.Upload
{
    public class Upload
    {
        
        private readonly Client _client;

        public Upload(Client client)
        {
            _client = client;
        }

        public async Task<Models.Media> File(Stream fileStream, string name = "", string description = "", string projectId = null)
        {
            using (var formData = new MultipartFormDataContent())
            {
                AddStringContent(formData, _client.Authentication.FieldName, _client.Authentication.Value);
                AddStringContent(formData, "project_id", projectId);
                AddStringContent(formData, "name", name);
                AddStringContent(formData, "description", description);

                // Add the file stream
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.Add("Content-Type", "application/octet-stream");
                fileContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + name + "\"");
                formData.Add(fileContent, "file", name);

                // HttpClient problem workaround
                var boundaryValue = formData.Headers.ContentType.Parameters.FirstOrDefault(p => p.Name == "boundary");
                if (boundaryValue != null)
                {
                    boundaryValue.Value = boundaryValue.Value.Replace("\"", string.Empty);
                }

                // Upload the file
                var response = await _client.Post(Client.UploadUrl, formData);

                return _client.Hydrate<Models.Media>(response);
            }
        }

        public async Task<Models.Media> Url(string url, string name = null, string description = null, string projectId = null)
        {
            var pars = new Dictionary<string, string>
            {
                ["url"] = url,
                ["project_id"] = projectId,
                ["name"] = name,
                ["description"] = description
            };

            var response = await _client.Post(Client.UploadUrl, pars);
            return _client.Hydrate<Models.Media>(response);
        }
        
        private static void AddStringContent(MultipartFormDataContent form, string name, string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var content = new StringContent(value);
            content.Headers.Add("Content-Disposition", "form-data; name=\"" + name + "\"");
            form.Add(content, name);
        }
    }
}