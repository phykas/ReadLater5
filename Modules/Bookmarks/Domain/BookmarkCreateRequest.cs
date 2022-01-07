using System;
using System.ComponentModel.DataAnnotations;

namespace ReadLater.Bookmarks.Domain
{
    public class BookmarkCreateRequest
    {

        [StringLength(maximumLength: 500)]
        public string Url { get; set; }

        public string ShortDescription { get; set; }

        public string Category { get; set; }

        public DateTime CreateDate { get; set; }
    }

}
