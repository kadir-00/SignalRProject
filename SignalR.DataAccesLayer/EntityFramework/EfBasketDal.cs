﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccesLayer.Abstract;
using SignalR.DataAccesLayer.Concrete;
using SignalR.DataAccesLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccesLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketByMenuTableNumber(int id)
        {// MasaId'sine gore listeleme yapmam  gerek ve musteri kalkinca verilerin de temizlenmesi gerek 
            using var context=new SignalRContext();
            var values = context.Baskets.Where(x=>x.MenuTableId==id).Include(y=>y.Product).ToList();
            return values;
        }
    }
}
