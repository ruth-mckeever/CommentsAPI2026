using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommentsAPI2026.Models;

namespace CommentsAPI2026.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext _context;

        
        public CommentController(CommentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all comment items
        /// </summary>
        /// <returns>comment items</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentItem>>> GetCommentItems()
        {
            return await _context.CommentItems.ToListAsync();
        }

        // GET: api/Comment/5
        /// <summary>
        /// Get comment by id
        /// </summary>
        /// <param name="id">ID of specific comment required</param>
        /// <returns>The requested comment</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentItem>> GetCommentItem(int id)
        {
            var commentItem = await _context.CommentItems.FindAsync(id);

            if (commentItem == null)
            {
                return NotFound();
            }

            return commentItem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentItem"></param>
        /// <returns></returns>
        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentItem(int id, CommentItem commentItem)
        {
            if (id != commentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentItemExists(id))
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentItem"></param>
        /// <returns></returns>
        // POST: api/Comment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentItem>> PostCommentItem(CommentItem commentItem)
        {
            _context.CommentItems.Add(commentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommentItem), new { id = commentItem.Id }, commentItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentItem(int id)
        {
            var commentItem = await _context.CommentItems.FindAsync(id);
            if (commentItem == null)
            {
                return NotFound();
            }

            _context.CommentItems.Remove(commentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentItemExists(int id)
        {
            return _context.CommentItems.Any(e => e.Id == id);
        }
    }
}
