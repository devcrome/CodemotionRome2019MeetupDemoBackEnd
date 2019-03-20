using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private BloggingContext _bloggingContext;
        public BlogPostController(BloggingContext bloggingContext)
        {
            _bloggingContext=bloggingContext;
            _bloggingContext.Database.EnsureCreated();
        }
        // GET api/blogpost
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> Get()
        {
            return _bloggingContext.BlogPosts.ToList();
        }

        // GET api/blogpost/5
        [HttpGet("{id}")]
        public ActionResult<BlogPost> Get(int id)
        {
            return _bloggingContext.BlogPosts.Find(id);
        }

        // POST api/blogpost
        [HttpPost]
        [EnableCors]
        public IActionResult Post([FromBody] BlogPost blogPost)
        {

            _bloggingContext.BlogPosts.Add(blogPost);
            _bloggingContext.SaveChanges();
            return Ok(blogPost.BlogId);
        }

        // PUT api/blogpost/5
        [HttpPut("{id}")]
        [EnableCors]
        public IActionResult Put(int id, [FromBody] BlogPost blogPost)
        {
           
            if (blogPost.BlogId != id){
                return BadRequest();
            }
            _bloggingContext.Entry(blogPost).State = EntityState.Modified;
            _bloggingContext.SaveChanges();
            return Ok();
        }

        // DELETE api/blogpost/5
        [HttpDelete("{id}")]
        [EnableCors]
        public IActionResult Delete(int id)
        {
            BlogPost blogPost = _bloggingContext.BlogPosts.Find(id);
            if (blogPost==null)
            {
                return NotFound();
            }

            _bloggingContext.BlogPosts.Remove(blogPost);
            _bloggingContext.SaveChanges();
            return NoContent();
        }
    }
}
