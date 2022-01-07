using System;
using System.ComponentModel.DataAnnotations;

namespace ReadLater.Bookmarks.Domain
{
    public class BookmarkDto
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        [StringLength(maximumLength: 500)]
        public string Url { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public DateTime CreateDate { get; set; }

        public int ClickCount { get; set; }
    }
}
