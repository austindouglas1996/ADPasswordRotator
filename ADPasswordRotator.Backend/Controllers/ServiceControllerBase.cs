using EFRepository;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    public abstract class ServiceControllerBase<TService, TKey, TEntity> : ControllerBase
        where TEntity : class, IEntity<TKey>
        where TService : class, IEntityService<TKey,TEntity>
    {
        protected readonly TService _service;

        public ServiceControllerBase(TService service)
        {
            _service = service;
        }

        [HttpPost("Add")]
        public virtual async Task<ActionResult<TEntity>> AddAsync(TEntity entity)
        {
            await _service.AddAsync(entity);
            await _service.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("Get/{id}")]
        public virtual async Task<ActionResult<TEntity>> GetAsync(TKey id)
        {
            var entity = await _service.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpDelete("Remove/{id}")]
        public virtual async Task<IActionResult> RemoveAsync(TKey id)
        {
            var entity = await _service.GetAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _service.RemoveAsync(id);
            await _service.SaveChangesAsync();

            return NoContent();
        }
    }
}
