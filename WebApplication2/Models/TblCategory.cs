using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblArticles = new HashSet<TblArticle>();
        }

        public string CategoryId { get; set; } = null!;
        public string? CategoryName { get; set; }

        public virtual ICollection<TblArticle> TblArticles { get; set; }
    }
}
