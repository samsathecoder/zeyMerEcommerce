using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class GenericService<TEntity, TCreateDto, TUpdateDto, TDto>
       where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _repo;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<TDto>(created);
        }

        public virtual async Task<TDto?> UpdateAsync(TUpdateDto dto)
        {
            var entity = await _repo.GetByIdAsync((Guid)typeof(TUpdateDto).GetProperty("Id")!.GetValue(dto)!);
            if (entity == null) return default;

            _mapper.Map(dto, entity);
            var updated = await _repo.UpdateAsync(entity);
            return _mapper.Map<TDto>(updated);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public virtual async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<List<TDto>>(entities);
        }
    }

}
