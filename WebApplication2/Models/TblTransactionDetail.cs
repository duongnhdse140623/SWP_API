using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblTransactionDetail
    {
        public TblTransactionDetail()
        {
            TblTransactions = new HashSet<TblTransaction>();
        }

        public string TransDetailId { get; set; } = null!;
        public string? TransDetailName { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? TransactionId { get; set; }
        public string? ArticleId { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual ICollection<TblTransaction> TblTransactions { get; set; }
    }
}
