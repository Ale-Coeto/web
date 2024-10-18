using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Books.Controllers
{
    [Route("api/[controller]")]
    public class PageController : Controller
    {

        // GET: api/values/
        [HttpGet("{id}")]
        public IEnumerable<Page> GetPages(int id)
        {
            List<Page> list = new List<Page>();
            list = DatabaseManager.GetPages(id);

            return list; 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Page page)
        {
            DatabaseManager.InsertPage(page);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DatabaseManager.DeletePage(id);
        }
    }
}

