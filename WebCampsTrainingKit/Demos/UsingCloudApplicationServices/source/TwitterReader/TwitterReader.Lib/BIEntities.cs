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

using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweeterReader.Web.Entities
{
    public class TopicEntity : TableEntity
    {
        public TopicEntity(string date, string topic)
        {
            this.PartitionKey = date;
            this.RowKey = topic;
            this.Mentions = 1;
            this.Topic = topic;
        }
        public TopicEntity() { }
        public string Topic { get; set; }
        public int Mentions { get; set; }
    }
    public class TopicModel:IComparable
    {
        public TopicModel(string topic, int mentions)
        {
            Topic = topic;
            Mentions = mentions;
        }
        public string Topic { get; set; }
        public int Mentions { get; set; }

        public int CompareTo(object obj)
        {
            if (obj != null && obj is TopicModel)
                return -this.Mentions.CompareTo(((TopicModel)obj).Mentions);
            else
                throw new ArgumentException("Expected: TopicModel");
        }
    }
}