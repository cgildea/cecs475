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

using System;
using System.Web;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.AspNet.Membership.OpenAuth;

namespace PhotoGallery.Account
{
    public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? string.Empty; }
            private set { this.ViewState["ProviderName"] = value; }
        }

        protected string ProviderDisplayName
        {
            get { return (string)this.ViewState["ProviderDisplayName"] ?? string.Empty; }
            private set { this.ViewState["ProviderDisplayName"] = value; }
        }

        protected string ProviderUserId
        {
            get { return (string)this.ViewState["ProviderUserId"] ?? string.Empty; }
            private set { this.ViewState["ProviderUserId"] = value; }
        }

        protected string ProviderUserName
        {
            get { return (string)this.ViewState["ProviderUserName"] ?? string.Empty; }
            private set { this.ViewState["ProviderUserName"] = value; }
        }

        protected void Page_Load()
        {
            if (!this.IsPostBack)
            {
                this.ProcessProviderResult();
            }
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            this.CreateAndLoginUser();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            this.RedirectToReturnUrl();
        }

        private void ProcessProviderResult()
        {
            // Process the result from an auth provider in the request
            this.ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (string.IsNullOrEmpty(this.ProviderName))
            {
                Response.Redirect(FormsAuthentication.LoginUrl);
            }

            // Build the redirect url for OpenAuth verification
            var redirectUrl = "~/Account/RegisterExternalLogin.aspx";
            var returnUrl = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                redirectUrl += "?ReturnUrl=" + HttpUtility.UrlEncode(returnUrl);
            }

            // Verify the OpenAuth payload
            var authResult = OpenAuth.VerifyAuthentication(redirectUrl);
            this.ProviderDisplayName = OpenAuth.GetProviderDisplayName(this.ProviderName);
            if (!authResult.IsSuccessful)
            {
                this.Title = "External login failed";
                this.userNameForm.Visible = false;

                ModelState.AddModelError("Provider", string.Format("External login {0} failed.", this.ProviderDisplayName));

                // To view this error, enable page tracing in web.config (<system.web><trace enabled="true"/></system.web>) and visit ~/Trace.axd
                Trace.Warn("OpenAuth", string.Format("There was an error verifying authentication with {0})", this.ProviderDisplayName), authResult.Error);
                return;
            }

            // User has logged in with provider successfully
            // Check if user is already registered locally
            if (OpenAuth.Login(authResult.Provider, authResult.ProviderUserId, createPersistentCookie: false))
            {
                this.RedirectToReturnUrl();
            }

            // Store the provider details in ViewState
            this.ProviderName = authResult.Provider;
            this.ProviderUserId = authResult.ProviderUserId;
            this.ProviderUserName = authResult.UserName;

            // Strip the query string from action
            Form.Action = this.ResolveUrl(redirectUrl);

            if (User.Identity.IsAuthenticated)
            {
                // User is already authenticated, add the external login and redirect to return url
                OpenAuth.AddAccountToExistingUser(this.ProviderName, this.ProviderUserId, this.ProviderUserName, User.Identity.Name);
                this.RedirectToReturnUrl();
            }
            else
            {
                // User is new, ask for their desired membership name
                this.userName.Text = authResult.UserName;
            }
        }

        private void CreateAndLoginUser()
        {
            if (!this.IsValid)
            {
                return;
            }

            var createResult = OpenAuth.CreateUser(this.ProviderName, this.ProviderUserId, this.ProviderUserName, this.userName.Text);
            if (!createResult.IsSuccessful)
            {
                ModelState.AddModelError("UserName", createResult.ErrorMessage);
            }
            else
            {
                // User created & associated OK
                if (OpenAuth.Login(this.ProviderName, this.ProviderUserId, createPersistentCookie: false))
                {
                    this.RedirectToReturnUrl();
                }
            }
        }

        private void RedirectToReturnUrl()
        {
            var returnUrl = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl) && OpenAuth.IsLocalUrl(returnUrl))
            {
                Response.Redirect(returnUrl);
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}