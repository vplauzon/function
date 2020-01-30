#r "System.Text.Json"

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

//  Using https://codebeautify.org/csharp-escape-unescape/ to compress
//  into a one-liner for ARM Template
//  Post process:  need to replace \' by ' as it fails in ARM Templates
public static async Task<IActionResult> Run(
    HttpRequest request,
    ILogger log)
{
    log.LogInformation("Function A triggered");

    var targetUrl = Environment.GetEnvironmentVariable("target-url");

    if (string.IsNullOrWhiteSpace(targetUrl))
    {
        throw new ArgumentNullException("target-url");
    }

    var client = new HttpClient();

    //  Send events to Event Grid Topic
    var response = await client.GetAsync(targetUrl);

    if (response.StatusCode != HttpStatusCode.OK)
    {
        var output = await response.Content.ReadAsStringAsync();

        return new BadRequestObjectResult($"Error calling function B:  {output}");
    }
    else
    {
        var output = await response.Content.ReadAsStringAsync();

        log.LogInformation($"Function B returned {output}");

        return new OkObjectResult($"Function B returned {output}");
    }
}