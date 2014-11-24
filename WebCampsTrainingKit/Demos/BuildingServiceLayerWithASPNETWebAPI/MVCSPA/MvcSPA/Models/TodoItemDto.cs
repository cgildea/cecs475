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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcSPA.Models
{
    public class TodoItemDto
    {
        /// <summary>
        /// Data transfer object for <see cref="TodoItem"/>
        /// </summary>    
        public TodoItemDto() { }

        public TodoItemDto(TodoItem item)
        {
            TodoItemId = item.TodoItemId;
            Title = item.Title;
            IsDone = item.IsDone;
            TodoListId = item.TodoListId;
        }

        public int TodoItemId { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public int TodoListId { get; set; }

        public TodoItem ToEntity()
        {
            return new TodoItem
            {
                TodoItemId = TodoItemId,
                Title = Title,
                IsDone = IsDone,
                TodoListId = TodoListId
            };
        }
    }
}
