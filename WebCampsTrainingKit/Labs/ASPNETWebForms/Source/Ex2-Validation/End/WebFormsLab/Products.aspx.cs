﻿// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace WebFormsLab
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web.ModelBinding;
    using WebFormsLab.Model;

    public partial class Products : System.Web.UI.Page
    {
        private ProductsContext db = new ProductsContext();

        public IQueryable<Category> GetCategories([Control]int? minProductsCount)
        {
            var query = this.db.Categories
              .Include(c => c.Products);

            if (minProductsCount.HasValue)
            {
                query = query.Where(c => c.Products.Count >= minProductsCount);
            }

            return query;
        }

        public IEnumerable<Product> GetProducts([Control("categoriesGrid")]int? categoryId)
        {
            return this.db.Products.Where(p => p.CategoryId == categoryId);
        }

        public void UpdateCategory(int categoryId)
        {
            var category = this.db.Categories.Find(categoryId);

            this.TryUpdateModel(category);

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    var message = string.Format("A category with the name {0} already exists.", category.CategoryName);
                    this.ModelState.AddModelError("CategoryName", message);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}