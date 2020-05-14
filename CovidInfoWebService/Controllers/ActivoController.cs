using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CovidInfoWebService.Utils;

namespace CovidInfoWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetActivo()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"{UrlExtractor.ExtractBaseUrl(Request.GetDisplayUrl())}/api/reportecaso");
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok("API REST Activa.");
            }
            return Ok($"Hay un problema con el servicio. ${response.StatusCode}");
            
        }
    }
}