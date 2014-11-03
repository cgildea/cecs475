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

namespace MvcMusicStore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MvcMusicStore.Models;
    using MvcMusicStore.Services;

    public class StoreService : IStoreService
    {
        private MusicStoreEntities storeDB = new MusicStoreEntities();

        public IList<string> GetGenreNames()
        {
            var genres = from genre in this.storeDB.Genres
                         select genre.Name;

            return genres.ToList();
        }

        public IList<Genre> GetGenres(int max)
        {           
            return max > 0 ? this.storeDB.Genres.Take(max).ToList() : this.storeDB.Genres.ToList();
        }

        public Genre GetGenreByName(string name)
        {
            var genre = this.storeDB.Genres.Include("Albums").Single(g => g.Name == name);

            return genre;
        }

        public Album GetAlbum(int id)
        {
            var album = this.storeDB.Albums.Single(a => a.AlbumId == id);

            return album;
        }
    }
}