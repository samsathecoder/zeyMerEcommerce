using Microsoft.AspNetCore.Mvc;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Entities;

namespace ZeyMer.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Review review)
        {
            var createdReview = await _reviewService.AddAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = createdReview.Id }, createdReview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Review review)
        {
            if (id != review.Id)
                return BadRequest();

            await _reviewService.UpdateAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
    }
}
