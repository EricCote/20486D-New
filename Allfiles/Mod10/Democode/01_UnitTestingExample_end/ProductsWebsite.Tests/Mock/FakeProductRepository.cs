﻿using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExample.Models;
using UnitTestingExample.Repositories;

namespace ProductsWebsite.Tests.Mock
{
    internal class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product{ Id = 1, Name = "Product1's name", BasePrice = 1.1F, Description = "A description for product 1."},
                new Product{ Id = 2, Name = "Product2's name", BasePrice = 2.2F, Description = "A description for product 2."},
                new Product{ Id = 3, Name = "Product3's name", BasePrice = 3.3F, Description = "A description for product 3."}
            };
        }
    }
}