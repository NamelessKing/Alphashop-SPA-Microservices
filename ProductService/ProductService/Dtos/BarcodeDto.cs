﻿using ProductService.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Dtos
{
    public class BarcodeDto : IDto
    {
        public string BarcodeId { get; set; }
        public string IdTipoArt { get; set; }

    }
}
