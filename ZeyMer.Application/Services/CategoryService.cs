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
        public class CategoryService : ICategoryService
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            {
                return await _categoryRepository.GetAllAsync();
            }

            public async Task<Category?> GetCategoryByIdAsync(Guid id)
            {
                return await _categoryRepository.GetByIdAsync(id);
            }

            public async Task<Category> CreateCategoryAsync(Category category)
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();
                return category;
            }

            public async Task UpdateCategoryAsync(Category category)
            {
                _categoryRepository.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync();
            }

            public async Task DeleteCategoryAsync(Guid id)
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category != null)
                {
                    _categoryRepository.DeleteAsync(id);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }
    }

