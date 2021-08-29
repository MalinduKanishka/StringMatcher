using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StringMatcher.Interfaces;
using StringMatcher.Models;
using StringMatcher.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StringMatcher.Helpers.EnumHelper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StringMatcher.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StringMatchController : ControllerBase
    {

        private readonly ILogger<StringMatchController> _logger;

        public StringMatchController(ILogger<StringMatchController> logger)
        {
            _logger = logger;
        }



        // POST api/<StringMatchController>
        [HttpPost]
        public Compare Post([FromBody]Compare input)
        {
            ICompare provider = new StringComparisonProvider(input.InputString, input.SubString, input.CaseSearch);

            return provider.findWords();            
        }

    }
}
