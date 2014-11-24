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
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebFormsLab.Model;

    public partial class CustomerDetails : System.Web.UI.Page
    {
        public Customer SelectCustomer([QueryString]int id)
        {
            using (var db = new ProductsContext())
            {
                return db.Customers.Find(id);
            }
        }

        public void UpdateCustomer(int id)
        {
            using (var db = new ProductsContext())
            {
                var customer = db.Customers.Find(id);
                this.TryUpdateModel(customer);

                if (this.ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }

        public void SaveCustomer(Customer customer)
        {
            if (this.ModelState.IsValid)
            {
                using (var db = new ProductsContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    this.Response.Redirect("~/Customers.aspx");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Page.ClientQueryString))
            {
                this.fvDataBinding.ChangeMode(FormViewMode.Insert);
            }
        }
    }
}