using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIService.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {

        public EntityMapper()
        {
            Mapper.CreateMap<Models.Product, Product>();
            Mapper.CreateMap<Product, Models.Product>();

        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }

    }
}