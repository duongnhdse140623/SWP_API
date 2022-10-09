using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblPayment
    {
        public TblPayment()
        {
            TblTransactions = new HashSet<TblTransaction>();
            TblUsers = new HashSet<TblUser>();
        }

        public string PaymentId { get; set; } = null!;
        public string? Method { get; set; }

        public virtual ICollection<TblTransaction> TblTransactions { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
