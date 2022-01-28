using Microsoft.AspNetCore.Mvc;
using MovieApp.Data;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApp.Models
{
    [Route("api/movie")]
    [ApiController]
    public class apiMovie : ControllerBase
    {

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public MovieData Get(int id)
        {
            return _context.MovieData.Find(id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.MovieData.Find(id);
        }

        public apiMovie(ApplicationDbContext context)
    {
            _context = context;
        }
        private readonly ApplicationDbContext _context;
    }
}
