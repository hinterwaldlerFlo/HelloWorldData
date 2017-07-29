using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloWorldData.Models;

namespace HelloWorldData.Controllers
{
    [Produces("application/json")]
    [Route("api/MeasuredValues")]
    public class MeasuredValuesController : Controller
    {
        private readonly HelloDataContext _context;

        public MeasuredValuesController(HelloDataContext context)
        {
            _context = context;
        }

        // GET: api/MeasuredValues
        [HttpGet]
        public IEnumerable<MeasuredValues> GetMeasuredValues()
        {
            return _context.MeasuredValues;
        }

        // GET: api/MeasuredValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeasuredValues([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measuredValues = await _context.MeasuredValues.SingleOrDefaultAsync(m => m.Id == id);

            if (measuredValues == null)
            {
                return NotFound();
            }

            return Ok(measuredValues);
        }

        // PUT: api/MeasuredValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasuredValues([FromRoute] int id, [FromBody] MeasuredValues measuredValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measuredValues.Id)
            {
                return BadRequest();
            }

            _context.Entry(measuredValues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasuredValuesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MeasuredValues
        [HttpPost]
        public async Task<IActionResult> PostMeasuredValues([FromBody] MeasuredValues measuredValues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MeasuredValues.Add(measuredValues);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasuredValues", new { id = measuredValues.Id }, measuredValues);
        }

        // DELETE: api/MeasuredValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasuredValues([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measuredValues = await _context.MeasuredValues.SingleOrDefaultAsync(m => m.Id == id);
            if (measuredValues == null)
            {
                return NotFound();
            }

            _context.MeasuredValues.Remove(measuredValues);
            await _context.SaveChangesAsync();

            return Ok(measuredValues);
        }

        private bool MeasuredValuesExists(int id)
        {
            return _context.MeasuredValues.Any(e => e.Id == id);
        }
    }
}