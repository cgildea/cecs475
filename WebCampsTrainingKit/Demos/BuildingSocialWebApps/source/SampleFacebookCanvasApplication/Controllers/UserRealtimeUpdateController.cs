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

using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Facebook.Models;
using Microsoft.AspNet.Mvc.Facebook.Realtime;

// To learn more about Facebook Realtime Updates, go to https://developers.facebook.com/docs/reference/api/realtime/

namespace SampleFacebookCanvasApplication.Controllers
{
    public class UserRealtimeUpdateController : FacebookRealtimeUpdateController
    {
        private readonly static string UserVerifyToken = ConfigurationManager.AppSettings["Facebook:VerifyToken:User"];

        public override string VerifyToken
        {
            get
            {
                return UserVerifyToken;
            }
        }

        public override Task HandleUpdateAsync(ChangeNotification notification)
        {
            if (notification.Object == "user")
            {
                foreach (var entry in notification.Entry)
                {
                    // Your logic to handle the update here
                }
            }

            throw new NotImplementedException();
        }
    }
}
