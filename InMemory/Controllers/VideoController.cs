using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InMemory.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InMemory.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ViedoController : ControllerBase {
        private readonly ILogger<ViedoController> _logger;
        private readonly IConfiguration _config ;
        public ViedoController (ILogger<ViedoController> logger, IConfiguration configuration) {
            _logger = logger;
            _config = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetYoutube([FromQuery] string query){
            query = query.Replace (" ","+");
            HtmlHelper htmlHelper = new HtmlHelper(_config);
            var response = await htmlHelper.getDatas(query);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> Select([FromQuery] string selector,[FromQuery] int index){
            HtmlHelper htmlHelper = new HtmlHelper(_config);
            var result = await htmlHelper.select(selector,index);
            var response = new List<dynamic>();
            foreach(var res in result){
                response.Add(JsonConvert.DeserializeObject<dynamic>(res));
            }
            return Ok(response);
        }

        [HttpGet("Html")]
        public async Task<IActionResult> Html(){
            HtmlHelper htmlHelper = new HtmlHelper(_config);
            var response = await htmlHelper.html();
            return Ok(response);
        }
    }
}