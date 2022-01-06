using System.ComponentModel.DataAnnotations;

namespace ReadLater.Bookmarks.Domain
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}
