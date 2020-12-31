using Microsoft.AspNetCore.Mvc;
using ProductService.Data.RepositoryContracts;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.Models.Contracts;
using System;
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
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo.",HttpContext.Response.StatusCode.ToString()));
            }

            var articlesDto = MapArticlesToArticleDtos(articles);

            return Ok(articlesDto);
        }

        [HttpGet("description/{description}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(ICollection<ArticleDto>))]
        public async Task<IActionResult> GetArticlesByDescription(string description)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = await ArticleRepository.GetArticlesByDescription<IEntity>(description);

            if (articles.Count == 0)
            {
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo con il filtro '{description}'", HttpContext.Response.StatusCode.ToString()));
            }

            ICollection<ArticleDto> articlesDto = MapArticlesToArticleDtos(articles);

            return Ok(articlesDto);
        }

        [HttpGet("withAllProperties")]
        public async Task<IActionResult> GetAllArticlesWithAllProperties()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetAllArticles<object>(
                a => a.Barcodes,
                a => a.AssortmentFamily,
                a => a.Ingredient,
                a => a.Iva
                );

            if (articles.Count == 0)
            {
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo.", HttpContext.Response.StatusCode.ToString()));
            }

            var articlesDto = MapArticlesToArticleDtos(articles);

            return Ok(articlesDto);
        }


        [HttpGet("withBarcodes")]
        public async Task<IActionResult> GetAllArticlesWithBarcodes()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articles = (List<Article>)await ArticleRepository.GetAllArticles(x => x.Barcodes);

            if (articles.Count == 0)
            {
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo.", HttpContext.Response.StatusCode.ToString()));
            }

            var articlesDto = MapArticlesToArticleDtos(articles);

            return Ok(articlesDto);
        }

        // GET: api/article/{id}
        [HttpGet("articleid/{articleId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        public async Task<IActionResult> GetArticleByArticleId(string articleId)
        {
            var article = await ArticleRepository.GetArticleByArticleId<IEntity>(articleId);

            if (article == null)
            {
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo con ID '{articleId}'", HttpContext.Response.StatusCode.ToString()));
            }

            var artcleDto = MapArticleToArticleDto(article);
            return Ok(artcleDto);
        }

        [HttpGet("articleid/{articleId}/WithAllProperties")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        public async Task<IActionResult> GetArticleByArticleIdWithAllCollections(string articleId)
        {
            var article = await ArticleRepository.GetArticleByArticleId<object>(articleId,
                a => a.Barcodes,
                a => a.AssortmentFamily,
                a => a.Ingredient,
                a => a.Iva
                );

            if (article == null)
            {
                return NotFound(new ErrorMessage($"Non è stato trovato alcun articolo con ID '{articleId}'", HttpContext.Response.StatusCode.ToString()));
            }

            var artcleDto = MapArticleToArticleDto(article);
            return Ok(artcleDto);
        }

        

        [HttpGet("barcodeId/{barcodeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticleDto))]
        public async Task<IActionResult> GetArticleByBarcodeId(string barcodeId)
        {
            var barcode = await BarcodeRepository.GetBarcodeByBarcodeIdWithArticle(barcodeId);

            if (barcode == null)
                return NotFound(new ErrorMessage($"Non è stato trovato alcun barcode con id '{barcodeId}'", HttpContext.Response.StatusCode.ToString()));

            if (barcode.Article == null)
                return BadRequest(new ErrorMessage($"Il barcode con id '{barcodeId}' non è colegato a nessun articolo", HttpContext.Response.StatusCode.ToString()));

            return Ok(MapArticleToArticleDto(barcode.Article));
        }

        private ArticleDto MapArticleToArticleDto(Article article)
        {
            if (article == null)
                return null;

            return new ArticleDto()
            {
                ArticleId = article.ArticleId,
                CodStat = article.CodStat,
                DataCreazione = article.DataCreazione,
                Descrizione = article.Descrizione,
                PesoNetto = article.PesoNetto,
                PzCart = article.PzCart,
                Um = article.Um,
                Barcodes = MapBarcodesToBarcodeDtos(article.Barcodes),
                Ingredient = MapIngredientToIngredientDto(article.Ingredient),
                AssortmentFamily = MapAssortmentFamilyToAssortmentFamilyDto(article.AssortmentFamily),
                Iva = MapIvaToIvaDto(article.Iva),
                ArticleStateId = article.ArticleStateId
            };
        }

        private IvaDto MapIvaToIvaDto(Iva iva)
        {
            if (iva == null)
                return null;

            return new IvaDto() 
            {
                Aliquota = iva.Aliquota,
                Descrizione = iva.Descrizione
            };
        }

        private AssortmentFamilyDto MapAssortmentFamilyToAssortmentFamilyDto(AssortmentFamily assortmentFamily)
        {
            if (assortmentFamily == null)
                return null;

            return new AssortmentFamilyDto()
            {
                AssortmentFamilyId = assortmentFamily.AssortmentFamilyId,
                Descrizione = assortmentFamily.Descrizione
            };
        }

        private IngredientDto MapIngredientToIngredientDto(Ingredient ingredient)
        {
            if (ingredient == null)
                return null;

            return new IngredientDto()
            { 
                ArticleId = ingredient.ArticleId,
                Info = ingredient.Info
            };
        }

        private ICollection<ArticleDto> MapArticlesToArticleDtos(ICollection<Article> articles)
        {
            var articleDtos = new List<ArticleDto>();

            ((List<Article>)articles).ForEach(article =>
            {
                articleDtos.Add(MapArticleToArticleDto(article));
            });

            return articleDtos;
        }

        private ICollection<BarcodeDto> MapBarcodesToBarcodeDtos(ICollection<Barcode> barcodes)
        {
            var barcodeDtos = new List<BarcodeDto>();

            ((List<Barcode>)barcodes).ForEach(barcode =>
            {
                barcodeDtos.Add(MapBarcodeToBarcodeDto(barcode));
            });

            return barcodeDtos;
        }

        private BarcodeDto MapBarcodeToBarcodeDto(Barcode barcode)
        {
            if (barcode == null)
                return null;

            return new BarcodeDto()
            {
                BarcodeId = barcode.BarcodeId,
                IdTipoArt = barcode.IdTipoArt
            };
        }
    }
}
