using Microsoft.EntityFrameworkCore;
using ProductService.Data.RepositoryContracts;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Data.Repositories
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private DataContext DbContext { get; }

        public BarcodeRepository(DataContext dataContext)
        {
            DbContext = dataContext;
        }
        public async Task<Barcode> GetBarcodeByBarcodeId(string barcodeId)
        {
            return await DbContext.Barcodes.Include(x => x.Article).FirstOrDefaultAsync(b => b.BarcodeId == barcodeId);
            //return await DbContext.Barcodes.
        }
    }
}
