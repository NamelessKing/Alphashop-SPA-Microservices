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

        private DataContext Context { get; }

        public ArticleRepository(DataContext context)
        {
            Context = context;
        }

        public Task<bool> ArticleExixts(string articleId)
        {
            throw new NotImplementedException();
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
            return await Context.Articles.ToListAsync();
            //throw new NotImplementedException();
        }

        public Task<Article> GetArticleByArticleId(string articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetArticlesByDescription(string description)
        {
            throw new NotImplementedException();
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
