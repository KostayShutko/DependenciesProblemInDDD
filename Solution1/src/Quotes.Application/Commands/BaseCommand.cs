using Quotes.Domain.Entities;
using Quotes.Infrastructure.Repository;

namespace Quotes.Application.Commands;

public abstract class BaseCommand<TEntity>
    where TEntity : Entity
{
    protected readonly IRepository<TEntity> repository;

    protected BaseCommand(IRepository<TEntity> repository)
    {
        this.repository = repository;
    }

    protected async Task<TEntity> FindByIdAsync(int entityId)
    {
        return await repository.FindByIdAsync(entityId);
    }

    protected IQueryable<TEntity> FindBySpecification(ISpecification<TEntity> specification)
    {
        return repository.Find(specification);
    }

    protected async Task<TEntity> SaveChangesAsync(TEntity entity)
    {
        if (entity.IsNew())
        {
            var addedEntity = await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
            return addedEntity;
        }

        repository.Update(entity);
        await repository.SaveChangesAsync();
        return entity;
    }
}
