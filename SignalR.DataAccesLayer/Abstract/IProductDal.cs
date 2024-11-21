﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();

        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        
        decimal ProductPriceAvg();
        // ortalama fiyat bulma 

        string ProductNameByMaxPrice(); 
        string ProductNameByMinPrice();
        decimal ProductAvgPriceByHamburger();
        List<Product> GetLast9Products();
        decimal ProductPriceBySteakBurger();

	}
}
