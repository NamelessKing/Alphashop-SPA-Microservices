using Microsoft.AspNetCore.Mvc;
using ProductService.Data.RepositoryContracts;
using ProductService.Dtos;
using ProductService.Models;
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

        // GET: ArticleController
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetAllArticles();

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

            if (article != null)
            {
                var artcleDto = new ArticleDto()
                {
                    ArticleId = article.ArticleId,
                    CodStat = article.CodStat,
                    DataCreazione = article.DataCreazione,
                    Descrizione = article.Descrizione,
                    PesoNetto = article.PesoNetto,
                    PzCart = article.PzCart,
                    Um = article.Um
                };
                return Ok(artcleDto);
            }

            return NotFound($"Non è stato trovato alcun articolo con ID '{articleId}'");
        }

        [HttpGet("description/{description}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ICollection<Article>))]
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

        public async Task<IActionResult> GetArticleByBarcodeId(string barcodeId)
        {
            var barcode = await BarcodeRepository.GetBarcodeByBarcodeId(barcodeId);

            if (barcode == null)
                return NotFound($"Non è stato trovato alcun barcode con id '{barcode}'");

            return await GetArticleByArticleId(barcode.ArticleId);
        }

        private List<ArticleDto> MapArticlesToArticlesDto(List<Article> articles)
        {
            var articlesDto = new List<ArticleDto>();

            articles.ForEach(artcleDto =>
            {
                articlesDto.Add(
                    new ArticleDto()
                    {
                        ArticleId = artcleDto.ArticleId,
                        CodStat = artcleDto.CodStat,
                        DataCreazione = artcleDto.DataCreazione,
                        Descrizione = artcleDto.Descrizione,
                        PesoNetto = artcleDto.PesoNetto,
                        PzCart = artcleDto.PzCart,
                        Um = artcleDto.Um
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
