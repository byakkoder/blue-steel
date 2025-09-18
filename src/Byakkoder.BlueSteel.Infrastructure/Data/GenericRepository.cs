using Byakkoder.BlueSteel.Infrastructure.Data.Entities;
using Byakkoder.BlueSteel.SharedKernel.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Byakkoder.BlueSteel.Infrastructure.Data
{
    public class GenericRepository<TEntity> where TEntity : EntityBase
    {
        #region Fields

        private readonly MovieDBContext _movieDBContext;

        #endregion

        #region Constructor

        public GenericRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        #endregion

        #region Public Methods

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> searchExpression = null)
        {
            try
            {
                if (searchExpression == null)
                {
                    return _movieDBContext.Set<TEntity>().ToList();
                }
                else
                {
                    return _movieDBContext.Set<TEntity>().Where(searchExpression).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GenericResultsPage<TEntity>> GetAllPaged(int page, int pageSize, Expression<Func<TEntity, bool>> searchExpression = null)
        {
            GenericResultsPage<TEntity> resultsPage = new GenericResultsPage<TEntity>();

            if (searchExpression == null)
            {
                resultsPage.Results = await _movieDBContext.Set<TEntity>().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                resultsPage.TotalResults = await _movieDBContext.Set<TEntity>().CountAsync();
            }
            else
            {
                resultsPage.Results = await _movieDBContext.Set<TEntity>().Where(searchExpression).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
                resultsPage.TotalResults = await _movieDBContext.Set<TEntity>().Where(searchExpression).CountAsync();
            }

            resultsPage.PageNumber = page;
            resultsPage.PageSize = pageSize;
            resultsPage.TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(resultsPage.TotalResults) / Convert.ToDouble(pageSize)));

            return resultsPage;
        }

        public List<int> GetIdList()
        {
            try
            {
                return _movieDBContext.Set<TEntity>().Select(entity => entity.Id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _movieDBContext.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> searchExpression)
        {
            try
            {
                return _movieDBContext.Set<TEntity>().Where(searchExpression).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                entity = _movieDBContext.Set<TEntity>().Add(entity).Entity;

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                entity = _movieDBContext.Set<TEntity>().Update(entity).Entity;

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _movieDBContext.Set<TEntity>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        #endregion
    }
}
