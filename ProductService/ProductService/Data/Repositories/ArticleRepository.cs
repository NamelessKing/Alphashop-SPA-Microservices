using Microsoft.EntityFrameworkCore;
using ProductService.Data.RepositoryContracts;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<Article>> GetAllArticles()
        {
            return await dbContext.Articles.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Article> GetArticleByArticleId(string articleId)
        {
            return await dbContext.Articles.FindAsync(articleId);
        }

        public async Task<ICollection<Article>> GetArticlesByDescription(string description)
        {
            return await dbContext.Articles.Where(x => x.Descrizione.Contains(description)).ToListAsync();
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
