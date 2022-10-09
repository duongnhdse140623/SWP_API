using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblArticle
    {
        public string ArticleId { get; set; } = null!;
        public string? ArticleTitile { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? Description { get; set; }
        public string? AuthorName { get; set; }
        public string? Status { get; set; }
        public float? Price { get; set; }
        public string? UserId { get; set; }
        public string CategoryId { get; set; } = null!;
        public string? Image { get; set; }

        public virtual TblCategory Category { get; set; } = null!;
        public virtual TblUser? User { get; set; }
    }
}
