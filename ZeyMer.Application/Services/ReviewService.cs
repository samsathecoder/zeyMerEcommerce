using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<Review> AddAsync(Review review)
        {
            return await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _reviewRepository.DeleteAsync(id);
        }
    }
}
