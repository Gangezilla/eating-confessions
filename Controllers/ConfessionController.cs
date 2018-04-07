using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eating_confessions.Models;
using System.Linq;

namespace eating_confessions.Models
{
    [Route("api/confession")]
    public class ConfessionController : Controller
    {
        private readonly ConfessionContext _context;

        public ConfessionController(ConfessionContext context)
        {
            _context = context;
            if(_context.Confessions.Count() == 0)
            {
                _context.Confessions.Add(new Confession {
                    Title = "Confession1",
                    Content = "Boy oh boy" 
                });
                _context.SaveChanges();
            }
        }

        [HttpGet()]
        //api/confession?startFrom=20/
        // public IActionResult Get([FromQuery(Name = "page")] string page)
        public IEnumerable<Confession> PaginateThroughConfessions()
        {
            // string page = HttpContext.Request.Query["page"].ToString();
            string StartFrom = HttpContext.Request.Query["startFrom"];
            int StartFromInt = System.Convert.ToInt32(StartFrom);
            return _context.Confessions.ToList();
        }

        [HttpGet("{id}", Name="GetConfession")]
        public IActionResult GetById(long id)
        {
            var item = _context.Confessions.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Confession confession) {
            if (confession == null)
            {
                return BadRequest();
            }

            _context.Confessions.Add(confession);
            _context.SaveChanges();

            return CreatedAtRoute("GetConfession", new Confession{Id = confession.Id }, confession);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Confession confession)
        {
            if (confession == null || confession.Id != id)
            {
                return BadRequest();
            }

            var newConfession = _context.Confessions.FirstOrDefault(t => t.Id == id);
            if (newConfession == null) {
                return NotFound();
            }

            newConfession.Title = confession.Title;
            newConfession.Content = confession.Content;

            _context.Confessions.Update(newConfession);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}