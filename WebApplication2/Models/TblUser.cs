using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblArticles = new HashSet<TblArticle>();
        }

        public string UserId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime? CreateTimed { get; set; }
        public string? Address { get; set; }
        public string RoleId { get; set; } = null!;
        public string PaymentId { get; set; } = null!;

        public virtual TblPayment Payment { get; set; } = null!;
        public virtual TblRole Role { get; set; } = null!;
        public virtual ICollection<TblArticle> TblArticles { get; set; }
    }
}
