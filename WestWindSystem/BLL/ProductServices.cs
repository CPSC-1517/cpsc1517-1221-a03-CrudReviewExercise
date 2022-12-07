﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;   // for WestWindContext
using WestWindSystem.Entities;  // for Product
using Microsoft.EntityFrameworkCore;    // for LINQ extension methods

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        // Step 1: Define a readonly data field for the custom DbContext class
        // and use constructor injection to set the value of the data field
        private readonly WestWindContext _dbContext;
        internal ProductServices(WestWindContext context)
        {
            _dbContext = context;
        }

        // Step 2: Define methods for entity
        public List<Product> Product_List()
        {
            var query = _dbContext
                .Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.Discontinued == false)
                .OrderBy(p => p.ProductName);
            return query.ToList();
        }

        public int Product_AddProduct(Product newProduct)
        {
            // TODO: Write code to save newProduct to database

            return 0;
        }

        public int UpdateProduct(Product existingProduct)
        {
            _dbContext.Products.Attach(existingProduct).State = EntityState.Modified;
            int rowsUpdated = _dbContext.SaveChanges();
            return rowsUpdated;
        }
    }
}
