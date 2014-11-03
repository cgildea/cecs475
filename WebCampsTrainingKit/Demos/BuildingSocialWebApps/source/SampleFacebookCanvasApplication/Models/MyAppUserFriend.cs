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

using Microsoft.AspNet.Mvc.Facebook;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// https://developers.facebook.com/docs/reference/api/user/

namespace SampleFacebookCanvasApplication.Models
{
    public class MyAppUserFriend
    {
        public string Name { get; set; }

        public FacebookConnection<FacebookPicture> Picture { get; set; }
    }
}
