using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndyBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndyBooks.Controllers
{
    [Route("api/[controller]")]
    public class WriterController : Controller
    {
        private IndyBooksDataContext _db;
        public WriterController(IndyBooksDataContext db) { _db = db; }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var Writers = _db.Writers;

            if (Writers == null)
                return NotFound();
            return Json(Writers);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)

        {
            var writer = _db.Writers.SingleOrDefault(i => i.Id == id);
            if (writer == null)
                return NotFound();
            return Json(writer);
        }

        // POST api/values
        [HttpPost]

        public void Post([FromBody] Writer writer)
        {
             var writers = _db.Writers.SingleOrDefault(i => i.Id == writer.Id);
            if ( writers == null)
                _db.Writers.Add(writer);
            _db.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]long id, Writer writer)
        {
            var writes = _db.Writers.SingleOrDefault(i => i.Id == id);
            if(writes == null)
                return NotFound();

            writes.Name = writer.Name;
            _db.Writers.Update(writes);


            _db.SaveChanges();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
