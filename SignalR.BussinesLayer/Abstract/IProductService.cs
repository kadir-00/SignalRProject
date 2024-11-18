﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinesLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();

        public int TProductCount();

		int TProductCountByCategoryNameHamburger();
		int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TProductAvgPriceByHamburger();
		List<Product> TGetLast9Products();


	}
}
