using Microsoft.AspNetCore.Mvc;
using SmartWork.Core.Abstractions;
using SmartWork.Core.Abstractions.EntityConvertors;
using SmartWork.Core.Abstractions.Services;
using SmartWork.Core.Entities;
using SmartWork.Core.Enums;
using SmartWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmartWork.BLL.Services
{
    public abstract class EntityService<TEntity, TAddDTO, TUpdateDTO> : 
        IEntityService<TEntity, TAddDTO, TUpdateDTO>
        where TEntity : Entity
        where TAddDTO : IDTO
        where TUpdateDTO : IDTO 
    {
        private readonly IGeneralEntityService<TEntity> _generalEntityService;
        private readonly IEntityConverter<TEntity, TAddDTO, TUpdateDTO> _entityConverter;

        public EntityService(IGeneralEntityService<TEntity> generalEntityService, 
            IEntityConverter<TEntity, TAddDTO, TUpdateDTO> entityConverter)
        {
            _generalEntityService = generalEntityService;
            _entityConverter = entityConverter;
        }

        public async Task<IActionResult> AddAsync(TAddDTO transferObject)
        {
            var entity = _entityConverter.ToEntity(transferObject);

            if (await _generalEntityService.AddAsync(entity))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> AddAsync(IEnumerable<TAddDTO> transferObjects)
        {
            var entities = _entityConverter.ToEntities(transferObjects);

            if (await _generalEntityService.AddAsync(entities))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> FindAsync(int id)
        {
            var entity = await _generalEntityService.FindAsync(id);

            if (entity != null)
            {
                return new OkObjectResult(entity);
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _generalEntityService.FindAsync(expression);

            if (entity != null)
            {
                return new OkObjectResult(entity);
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> AnyAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return new OkObjectResult(await _generalEntityService.AnyAsync(expression));
        }

        public async Task<IActionResult> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return new OkObjectResult(await _generalEntityService.GetAsync(expression));
        }

        public async Task<IActionResult> RemoveAsync(TEntity entity)
        {
            if (await _generalEntityService.RemoveAsync(entity))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> RemoveAsync(IEnumerable<TEntity> entities)
        {
            if (await _generalEntityService.RemoveAsync(entities))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> UpdateAsync(TUpdateDTO transferObject)
        {
            var entity = _entityConverter.ToEntity(transferObject);

            if (await _generalEntityService.UpdateAsync(entity))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }

        public async Task<IActionResult> UpdateAsync(IEnumerable<TUpdateDTO> transferObjects)
        {
            var entities = _entityConverter.ToEntities(transferObjects);

            if (await _generalEntityService.UpdateAsync(entities))
            {
                return new OkObjectResult(Response.GetResponse(ResponseType.Success));
            }

            return new BadRequestObjectResult(Response.GetResponse(ResponseType.Failed));
        }
    }
}
