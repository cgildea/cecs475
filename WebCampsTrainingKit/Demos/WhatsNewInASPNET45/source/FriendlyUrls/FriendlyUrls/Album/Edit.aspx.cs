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

using Microsoft.AspNet.FriendlyUrls;
using WebFormsMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FriendlyUrls
{
    public partial class Edit : System.Web.UI.Page
    {
        private MusicStoreEntities _db = new MusicStoreEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Album EditAlbum_GetItem([FriendlyUrlSegments] int? id)
        {
            return _db.Albums.Find(id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void EditAlbum_UpdateItem(int id)
        {
            Album item = null;
            item = _db.Albums.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                _db.SaveChanges();
            }
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _db.Genres.AsEnumerable();
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _db.Artists.AsEnumerable();
        }
    }
}