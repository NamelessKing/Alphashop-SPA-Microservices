using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProductService.Data.RepositoryContracts;
using ProductService.Models;
using ProductService.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Data.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private DataContext dbContext { get; }

        public ArticleRepository(DataContext context)
        {
            dbContext = context;
        }

        public async Task<bool> ArticleExixts(string articleId)
        {
            return await dbContext.Articles.AnyAsync(article => article.ArticleId == articleId);
        }
        
        public Task<Article> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }


        public async Task<ICollection<Article>> GetAllArticles<T>(params Expression<Func<Article, T>>[] includes) where T : class
        {
            IQueryable<Article> query = dbContext.Articles;

            query = includes.Aggregate(query,
                (current, includeproperty) => current.Include(includeproperty));

            return await query.ToListAsync();
        }
    

        //public async Task<ICollection<Article>> GetAllArticles(params Expression<Func<Article,ICollection<IEntity>>>[] includes)
        //{
        //    //var a =  dbContext.Articles.Include(x => x.Barcodes).Include(x => x.AssortmentFamily);
        //    //throw new NotImplementedException();
        //    //var q = DbSet.AsNoTracking<IEntity>();
        //    //IQueryable<Article> q = dbContext.Articles;

        //    //var q = dbContext.Articles.Include(includes.First());
        //    //enumerator.MoveNext();

        //    //q = includes.Aggregate(q.Include(includes[0]), 
        //    //    (current, includeProperty) => current.Include(includeProperty)
        //    //    );

        //    IQueryable<Article> query = dbContext.Articles;

        //    foreach (var item in includes)
        //    {
        //        query = query.Include(item);
        //    }

        //    return await query.ToListAsync();
        //}

        public async Task<Article> GetArticleByArticleId<T>(string articleId, params Expression<Func<Article, T>>[] includes) where T : class
        {
            IQueryable<Article> query = dbContext.Articles;

            query = includes.Aggregate(query,
                (current, includeproperty) => current.Include(includeproperty));

            return await query.FirstOrDefaultAsync(article => article.ArticleId == articleId);
        }

        public async Task<ICollection<Article>> GetArticlesByDescription<T>(string description, params Expression<Func<Article, T>>[] includes) where T : class
        {
            IQueryable<Article> query = dbContext.Articles.Where(x => x.Descrizione.Contains(description));

            query = includes.Aggregate(query,
                (current, includeproperty) => current.Include(includeproperty));

            return await query.ToListAsync();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<Article> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        
    }
}
