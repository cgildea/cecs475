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

namespace Web11
{
    using System;
    //// using Microsoft.Web.Optimization;

    public class Global : System.Web.HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            // Default behavior
            // Bundles all .js files in folders such as "scripts" if URL pointed to it: http://localhost:54716/scripts/custom/js
            // BundleTable.Bundles.EnableDefaultBundles();

            //// Static bundle.
            //// Access on url http://localhost:54716/StaticBundle
            // Bundle b = new Bundle("~/StaticBundle", typeof(JsMinify));
            // b.AddFile("~/scripts/custom/ECMAScript5.js");
            // b.AddFile("~/scripts/custom/GoToDefinition.js");
            // b.AddFile("~/scripts/bundle/JScript1.js");
            // b.AddFile("~/scripts/bundle/JScript2.js");

            // BundleTable.Bundles.Add(b);

            //// Dynamic bundle
            //// Bundles all .coffee files in folders such as "script" when "coffee" is appended to it: http://localhost:54716/scripts/coffee
            // DynamicFolderBundle fb = new DynamicFolderBundle("coffee", typeof(CoffeeMinify), "*.coffee");
            // BundleTable.Bundles.Add(fb);
        }
    }
}
