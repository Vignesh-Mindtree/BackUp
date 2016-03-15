using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Models;
using Entities;

namespace EntityConverterDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CabinClassModel model)
        {
            if(model == null)
            {
              return await Task.Run(()=> { return HttpBadRequest(); });
            }
            if(!ModelState.IsValid)
            {
                return HttpBadRequest();
            }

            CabinClass cabinClass = EntityConverter.ConvertTypeStoTypeT<CabinClass, CabinClassModel>(model);
            return Ok(cabinClass);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
