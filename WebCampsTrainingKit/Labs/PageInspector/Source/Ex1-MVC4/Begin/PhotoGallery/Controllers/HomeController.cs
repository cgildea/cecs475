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

namespace PhotoGallery.Controllers
{
    using PhotoGallery.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var photoList = new List<Photo>
            {
                new Photo 
                {
                    Title = "Chrysanthemum",
                    FileName = "Chrysanthemum.jpg"
                },
                new Photo 
                {
                    Title = "Koala",
                    FileName = "Koala.jpg"
                },
                new Photo 
                {
                    Title = "Penguins",
                    FileName = "Penguins.jpg"
                },
                new Photo 
                {
                    Title = "Tulips",
                    FileName = "Tulips.jpg"
                },
                new Photo 
                {
                    Title = "Desert",
                    FileName = "Desert.jpg"
                },
                new Photo 
                {
                    Title = "Lighthouse",
                    FileName = "Lighthouse.jpg"
                },
                new Photo 
                {
                    Title = "Jellyfish",
                    FileName = "Jellyfish.jpg"
                }
            };

            return this.View(photoList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
