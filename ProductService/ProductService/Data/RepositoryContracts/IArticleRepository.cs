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
        Task<ICollection<Article>> GetArticlesByDescription(string description);
        Task<ICollection<Article>> GetAllArticles<T>(params Expression<Func<Article, ICollection<T>>>[] includes) where T : IEntity;
        Task<Article> GetArticleByArticleId(string articleId);
        //Task<Article> GetArticleByBarcodeId(string articleId);
        Task<Article> CreateArticle(Article article);
        Task<Article> UpdateArticle(Article article);
        Task<bool> DeleteArticle(Article article);
        Task<bool> ArticleExixts(string articleId);

        Task<bool> SaveChanges();
    }
}
