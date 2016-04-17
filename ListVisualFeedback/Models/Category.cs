using System.Collections.Generic;

namespace ListVisualFeedback.Models
{
    public class Category
    {
        public string Name { get; set; }

        public List<string> Subcategories { get; set; }
    }
}
