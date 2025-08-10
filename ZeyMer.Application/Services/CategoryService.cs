using AutoMapper;

using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Dtos.Category;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;


namespace ZeyMer.Application.Services
    {
    public class CategoryService : GenericService<Category, CategoryDto,CategoryUpdateDto,CategoryCreateDto>, ICategoryService
    {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,IMapper mapper)
            :base (categoryRepository,mapper) 
              {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

    

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
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

