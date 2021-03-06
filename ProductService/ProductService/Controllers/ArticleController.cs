﻿using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ArticleDto>))]
        public async Task<ActionResult<ICollection<ArticleDto>>> GetArticlesByDescription(string description)
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
        public async Task<ActionResult<ArticleDto>> GetArticleByArticleId(string articleId)
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
        public async Task<IActionResult> GetArticleByArticleIdWithAllProperties(string articleId)
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

        [HttpPost("create")]
        [ProducesResponseType(201, Type = typeof(ArticleDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ArticleDto>> CreateArticle([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest(ModelState);
            }

            var isPresent = await ArticleRepository.ArticleExixts(article.ArticleId);

            if (isPresent)
            {
                ModelState.AddModelError("",$"Impossibile creare l'articolo. Esiste già un articolo con id '{article.ArticleId}'");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                string error="";
                foreach (var modelState in ModelState.Values)
                {
                    error =  string.Concat(modelState.Errors,"|");
                }
                return BadRequest(error);
            }

            var isCreated = await ArticleRepository.CreateArticle(article);

            if (isCreated)
            {
                Article createdArticle = await ArticleRepository.GetArticleByArticleId<IEntity>(article.ArticleId);
                return Ok(MapArticleToArticleDto(createdArticle));
            }
            else
            {
                ModelState.AddModelError("", $"Ci sono stati problemi a creare l'articolo con id '{article.ArticleId}'");
                return StatusCode(500,ModelState);
            }

        }

        [HttpPut("update")]
        [ProducesResponseType(201, Type = typeof(InfoMessage))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ArticleDto>> UpdateArticoli([FromBody] Article article )
        {
            var isPresent = await ArticleRepository.ArticleExixts(article.ArticleId);

            if (!isPresent)
            {
                ModelState.AddModelError("", $"Articolo {article.ArticleId} NON presente in anagrafica! Impossibile utilizzare il metodo PUT!");
                return StatusCode(422, ModelState);
            }


            //Verifichiamo che i dati siano corretti
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //verifichiamo che i dati siano stati regolarmente inseriti nel database
            if (! await ArticleRepository.UpdateArticle(article))
            {
                ModelState.AddModelError("", $"Ci sono stati problemi nella modifica dell'Articolo {article.ArticleId}.");
                return StatusCode(500, ModelState);
            }

            return Ok(new InfoMessage(DateTime.Today, $"Modifica articolo {article.ArticleId} eseguita con successo!"));

        }

        [HttpDelete("delete/{articleId}")]
        [ProducesResponseType(201, Type = typeof(InfoMessage))]
        [ProducesResponseType(400, Type = typeof(ErrorMessage))]
        [ProducesResponseType(422, Type = typeof(ErrorMessage))]
        [ProducesResponseType(500, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> DeleteArticleByArticleIdAsync(string articleId)
        {
            if (string.IsNullOrWhiteSpace(articleId))
            {
                return BadRequest(new ErrorMessage($"E' necessario inserire il codice dell'articolo da eliminare!",
                    HttpContext.Response.StatusCode.ToString()));
            }

            //Contolliamo se l'articolo è presente (Usare il metodo senza Traking)
            var article = await ArticleRepository.GetArticleByArticleId<IEntity>(articleId);

            if (article == null)
            {
                return StatusCode(422, new ErrorMessage($"Articolo {articleId} NON presente in anagrafica! Impossibile Eliminare!",
                    "422"));
            }

            //verifichiamo che i dati siano stati regolarmente eliminati dal database
            if (! await ArticleRepository.DeleteArticleByArticleId(article))
            {
                return StatusCode(500, new ErrorMessage($"Ci sono stati problemi nella eliminazione dell'Articolo {article.ArticleId}.",
                    "500"));
            }

            return Ok(new InfoMessage(DateTime.Today, $"Eliminazione articolo {articleId} eseguita con successo!"));
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
                IvaId = iva.IvaId,
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
