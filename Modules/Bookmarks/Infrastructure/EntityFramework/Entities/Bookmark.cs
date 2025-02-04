﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ReadLater.Bookmarks.EntityFramework.Entities
{
    public class Bookmark
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [StringLength(maximumLength: 500)]
        public string Url { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreateDate { get; set; }

        public int ClickCount { get; set; }
    }
}
