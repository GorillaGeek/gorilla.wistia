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
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                AddStringContent(formData, _client.Authentication.FieldName, _client.Authentication.Value);
                if (!string.IsNullOrWhiteSpace(projectId)) { AddStringContent(formData, "project_id", projectId); }
                if (!string.IsNullOrWhiteSpace(name)) { AddStringContent(formData, "name", name); }
                if (!string.IsNullOrWhiteSpace(description)) { AddStringContent(formData, "description", description); }

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
                var response = await client.PostAsync(Client.UploadUrl, formData);

                return await FormatResponse(response);
            }
        }

        public async Task<Models.Media> Url(string url, string name = "", string description = "", string projectId = null)
        {
            using (var client = new HttpClient())
            {
                var pars = new Dictionary<string, string>
                {
                    ["url"] = url,
                    [_client.Authentication.FieldName] = _client.Authentication.Value
                };

                if (!string.IsNullOrWhiteSpace(projectId)) { pars.Add("project_id", projectId); }
                if (!string.IsNullOrWhiteSpace(name)) { pars.Add("name", name); }
                if (!string.IsNullOrWhiteSpace(description)) { pars.Add("description", description); }

                var response = await client.PostAsync(Client.UploadUrl, new FormUrlEncodedContent(pars));

                return await FormatResponse(response);
            }
        }

        private static async Task<Models.Media> FormatResponse(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Media>(await response.Content.ReadAsStringAsync());
        }

        private static void AddStringContent(MultipartFormDataContent form, string name, string value)
        {
            var content = new StringContent(value);
            content.Headers.Add("Content-Disposition", "form-data; name=\"" + name + "\"");
            form.Add(content, name);
        }
    }
}