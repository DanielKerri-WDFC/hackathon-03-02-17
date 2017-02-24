using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace McsAdapter.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "MCS Adapter" };
        }
    }
}
