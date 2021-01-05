using ProductService.Models;
using ProductService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductService.Data.RepositoryContracts
{
    public interface IArticleRepository
    {
        Task<ICollection<Article>> GetArticlesByDescription<T>(string description, params Expression<Func<Article, T>>[] includes) where T : class;
        Task<ICollection<Article>> GetAllArticles<T>(params Expression<Func<Article, T>>[] includes) where T : class;
        Task<Article> GetArticleByArticleId<T>(string articleId, params Expression<Func<Article, T>>[] includes) where T : class;
        //Task<Article> GetArticleByBarcodeId(string articleId);
        Task<bool> CreateArticle(Article article);
        Task<bool> UpdateArticle(Article article);
        Task<bool> DeleteArticle(Article article);
        Task<bool> ArticleExixts(string articleId);

        Task<bool> SaveChanges();
    }
}
