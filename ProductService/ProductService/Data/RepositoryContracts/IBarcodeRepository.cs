using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.RepositoryContracts
{
    public interface IBarcodeRepository
    {
        Task<Barcode> GetBarcodeByBarcodeId(string barcodeId);
        Task<Barcode> GetBarcodeByBarcodeIdWithArticle(string barcodeId);

    }
}
