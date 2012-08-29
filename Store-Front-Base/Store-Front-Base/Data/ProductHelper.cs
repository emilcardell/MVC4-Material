using System;
using System.Collections.Generic;
using Raven.Client;
using StructureMap;

namespace Store_Front_Base.Data
{
    public class ProductHelper
    {
        public static void CreateABunchOfProducts()
        {
            var session = ObjectFactory.GetInstance<IDocumentSession>();
            for (int i = 0; i < 100; i++)
            {
                var product = new Product();
                product.Id = "Product/" + i;
                product.Name = "Product #" + i;
                product.Price = new Random().NextDouble() * 1000.0;
                product.UrlToSmallImage = "http://lorempixel.com/300/200/nature/" + i  +"/";
                product.UrlToSmallImage = "http://lorempixel.com/900/600/nature/" + i + "/";
                product.Tags = GetRandomTags();
                session.Store(product);
            }
            session.SaveChanges();
            session.Dispose();
        }

        private static IEnumerable<string> GetRandomTags()
        {
            var listOfTags = new List<List<string>>();
            listOfTags.Add(new List<string>() { "Tag 1", "Tag 2", "Tag 3" });
            listOfTags.Add(new List<string>() { "Tag 1", "Tag 2" });
            listOfTags.Add(new List<string>() { "Tag 2", "Tag 3" });
            listOfTags.Add(new List<string>() { "Tag 1", "Tag 3" });
            listOfTags.Add(new List<string>() { "Tag 1" });
            listOfTags.Add(new List<string>() { "Tag 2" }); 
            listOfTags.Add(new List<string>() { "Tag 3" });

            return listOfTags[new Random().Next(0, listOfTags.Count - 1)];

        }
    }
}