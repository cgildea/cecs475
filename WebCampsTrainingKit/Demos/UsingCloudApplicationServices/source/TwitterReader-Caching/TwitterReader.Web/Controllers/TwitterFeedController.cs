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

using Microsoft.ApplicationServer.Caching;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetReader.Web.Repositories;

namespace TweetReader.Web.Controllers
{
    public class TwitterFeedController : Controller
    {
        public ActionResult Index(string name)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Tweets entries = getTweets(name);
            
            timer.Stop();
            ViewBag.LoadTime = timer.Elapsed.TotalMilliseconds;

            return View(entries);
        }
        
        Tweets getTweets(string name)
        {
            DataCache cache = new DataCache();
            Tweets entries = cache.Get(name) as Tweets;
            if (entries == null)
            {
                entries = TwitterFeed.GetTweets(name);
                cache.Add(name, entries);
            }
            return entries;
        }
    }
}
