using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{dictionary}")]
        public async Task<IActionResult> GetEnum([FromRoute] DictionariesList dictionary)
        {
            return this.Ok(await Task.FromResult(dictionary.ToString()));
        }

        //[HttpGet("poly")]
        //public IActionResult GetPoly()
        //{
        //    var productsViewModel = new ProductsViewModel()
        //    {
        //        Credits = new CreditGroupViewModel()
        //        {
        //            Products = new List<ProductViewModel>{
        //            new ProductViewModel{},
        //        }
        //        },
        //        TradeFinance = new TradeFinanceGroupViewModel()
        //        {
        //            Products = new List<ProductViewModel>{
        //            new ProductViewModel{},
        //            new ProductViewModel{},
        //        }
        //        }
        //    };

        //    var store = new StoreProducts();
        //    var result = store.Store(productsViewModel);
        //    return this.Ok(result);
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
