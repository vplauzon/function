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
    log.LogInformation("Function B triggered");

    var client = new HttpClient();
    
    return new OkObjectResult($"42");
}