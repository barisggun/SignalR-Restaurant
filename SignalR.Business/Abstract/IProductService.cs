﻿using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductPriceByHamburger();
    }
}
