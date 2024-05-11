using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MeuDbContext _Db;
    protected readonly DbSet<TEntity> _DbSet;

    protected Repository(MeuDbContext db)
    {
        _Db = db;
        _DbSet = db.Set<TEntity>();
    }

    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await _DbSet.FirstAsync(Id);
    }

    public virtual async Task<List<TEntity>> ObterTodos()
    {
        return await _DbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
    {
        return await _DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task Adicionar(TEntity entity)
    {
        _DbSet.Add(entity);
        await SaveChangesAsync();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        _DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task Remover(Guid id)
    {
        _DbSet.Remove(new TEntity { Id = id });
        await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _Db.Dispose();
    }
}
