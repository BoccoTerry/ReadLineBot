using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LineBot.Controllers
{
    [Route("[controller]")]
    public class LineBotController : ControllerBase
    {
    
        [HttpPost("[action]")]
        public async Task<string> ReadLineBot()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var result =  await reader.ReadToEndAsync();
                Console.WriteLine(result);
                Log.Information(result);
                return result;
            }
        }


    }
}
