using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gorilla.Wistia;
using Gorilla.Wistia.Authentication;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new Client(new Password("YOUR_API_PASSWORD"));

            //var fs = File.OpenRead(@"C:\Temp\video.mp4");
            //var result = client.Upload.File(fs, "video.mp4", "yay").Result;

            //var result = client.Upload.Url("https://someurl", "video.mp4", "description").Result;

            //var result = Task.Run(async () => await client.Project.Show("6iacldoykb")).Result;
            //var result = Task.Run(async () => await client.Project.List()).Result;
            //var result = Task.Run(async () => await client.Project.Create("Prado Feio")).Result;
            //var result = Task.Run(async () => await client.Project.Update("2wuj01wtig", "works")).Result;
            //var result = Task.Run(async () => await client.Project.Delete("2wuj01wtig")).Result;
            //var result = Task.Run(async () => await client.Media.List()).Result;
            //var result = Task.Run(async () => await client.Media.Update("t5w12nnlzt", "Yay!", "done")).Result;
            //var result = Task.Run(async () => await client.Media.Delete("r9s5thz641")).Result;
            //var result = Task.Run(async () => await client.Media.Copy("2t98ah8i2i")).Result;
            //var result = Task.Run(async () => await client.Account.Show()).Result;

            try
            {
                var result = Task.Run(async () => await client.Stats.Account.Show()).Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
