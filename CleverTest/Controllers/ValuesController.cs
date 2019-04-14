using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace CleverTest.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            var res =new List<int>();
            for (int i = 0; i < 10; i++)
            {
                res.Add(Server.GetCount());
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            Server.AddToCount(id);
            return Ok();
        }

    }
}
