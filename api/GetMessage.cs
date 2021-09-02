using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StaticWebAppsEndToEndTesting.GetMessage
{
    public static class GetMessage
    {
        [FunctionName("GetMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request! :) ");
            log.LogInformation($"CWD: {System.IO.Directory.GetCurrentDirectory()}");
            string[] allfiles = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories);
            foreach (var file in allfiles){
                 log.LogInformation($"File: {file}");
            }
            string newContent = await File.ReadAllTextAsync(Path.Combine(System.IO.Directory.GetCurrentDirectory(),"content.txt"));
            return new OkObjectResult(newContent);
        }
    }
}
