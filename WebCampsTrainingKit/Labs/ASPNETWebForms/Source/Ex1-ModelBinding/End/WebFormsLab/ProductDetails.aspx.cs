// ----------------------------------------------------------------------------------
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
    using System.Web.ModelBinding;
    using WebFormsLab.Model;

    public partial class ProductDetails : System.Web.UI.Page
    {
        private ProductsContext db = new ProductsContext();

        public Product SelectProduct([QueryString]int? productId)
        {
            return this.db.Products.Find(productId);
        }

        public void UpdateProduct(int productID)
        {
            var product = this.db.Products.Find(productID);

            this.TryUpdateModel(product);

            if (this.ModelState.IsValid)
            {
                this.db.SaveChanges();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}