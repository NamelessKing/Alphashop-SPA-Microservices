using Microsoft.AspNetCore.Mvc;
using ProductService.Data.RepositoryContracts;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.Models.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {

        private IArticleRepository ArticleRepository { get; }
        private IBarcodeRepository BarcodeRepository { get; }

        public ArticleController(IArticleRepository articleRepository, IBarcodeRepository barcodeRepository)
        {
            ArticleRepository = articleRepository;
            BarcodeRepository = barcodeRepository;
        }

        //GET: ArticleController
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetAllArticles<IEntity>();

            if (articles.Count == 0)
            {
                return NotFound($"Non è stato trovato alcun articolo.");
            }

            var articlesDto = MapArticlesToArticlesDto(articles);

            return Ok(articlesDto);
        }

        [HttpGet("withBarcodes")]
        public async Task<IActionResult> GetAllArticlesIncludedBarcodes()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetAllArticles( x => x.Barcodes);

            if (articles.Count == 0)
            {
                return NotFound($"Non è stato trovato alcun articolo.");
            }

            var articlesDto = MapArticlesToArticlesDto(articles);

            return Ok(articlesDto);
        }

        // GET: api/article/{id}
        [HttpGet("articleId/{articleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        public async Task<IActionResult> GetArticleByArticleId(string articleId)
        {
            var article = await ArticleRepository.GetArticleByArticleId(articleId);

            if (article == null)
            {
                return NotFound($"Non è stato trovato alcun articolo con ID '{articleId}'");
            }

            var artcleDto = MapArticleToArticleDto(article);
            return Ok(artcleDto);
        }

        [HttpGet("description/{description}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ICollection<ArticleDto>))]
        public async Task<IActionResult> GetArticlesByDescription(string description)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetArticlesByDescription(description);

            if (articles.Count == 0)
            {
                return NotFound($"Non è stato trovato alcun articolo con il filtro '{description}'");
            }

            List<ArticleDto> articlesDto = MapArticlesToArticlesDto(articles);

            return Ok(articlesDto);
        }

        [HttpGet("barcodeId/{barcodeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        public async Task<IActionResult> GetArticleByBarcodeId(string barcodeId)
        {
            var barcode = await BarcodeRepository.GetBarcodeByBarcodeId(barcodeId);

            if (barcode == null)
                return NotFound($"Non è stato trovato alcun barcode con id '{barcode}'");

            if (barcode.Article == null)
                return BadRequest($"Il barcode con id '{barcodeId}' non è colegato a nessun articolo");

            return Ok(MapArticleToArticleDto(barcode.Article));
        }

        private ArticleDto MapArticleToArticleDto(Article article)
        {
            return new ArticleDto()
            {
                ArticleId = article.ArticleId,
                CodStat = article.CodStat,
                DataCreazione = article.DataCreazione,
                Descrizione = article.Descrizione,
                PesoNetto = article.PesoNetto,
                PzCart = article.PzCart,
                Um = article.Um,
                Barcodes = article.Barcodes
            };
        }

        private List<ArticleDto> MapArticlesToArticlesDto(List<Article> articles)
        {
            var articlesDto = new List<ArticleDto>();

            articles.ForEach(article =>
            {
                articlesDto.Add(
                    new ArticleDto()
                    {
                        ArticleId = article.ArticleId,
                        CodStat = article.CodStat,
                        DataCreazione = article.DataCreazione,
                        Descrizione = article.Descrizione,
                        PesoNetto = article.PesoNetto,
                        PzCart = article.PzCart,
                        Um = article.Um,
                        Barcodes = article.Barcodes
                    });
            });
            return articlesDto;
        }

        //// GET: ArticleController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ArticleController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ArticleController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ArticleController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ArticleController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ArticleController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
