using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackersHubV2.Entities;
using HackersHubV2.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackersHubV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly DataContext _context;

        public EventsController(DataContext context)
        {
            _context = context;

            if (_context.Events.Count() == 0)
            {
                _context.Events.Add(new Event { Name = "Event1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Event>> GetAll()
        {
            return _context.Events.ToList();
        }

        [HttpGet("{id}", Name = "GetEvent")]
        public ActionResult<Event> GetById(long id)
        {
            var item = _context.Events.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Event item)
        {
            _context.Events.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEvent", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Events.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Events.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Event item)
        {
            var evt = _context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }
            else
            {
                evt.Type = item.Type;
                evt.Location = item.Location;
                evt.Name = item.Name;
                evt.Date = item.Date;
                evt.Time = item.Time;
            }


            _context.Events.Update(evt);
            _context.SaveChanges();
            return NoContent();
        }
    }
}