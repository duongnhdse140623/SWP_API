using System;
using System.Collections.Generic;

namespace SWP_API.Models
{
    public partial class TblTransaction
    {
        public string TransactionId { get; set; } = null!;
        public string? TransactionName { get; set; }
        public string PaymentId { get; set; } = null!;
        public string TransDetailId { get; set; } = null!;

        public virtual TblPayment Payment { get; set; } = null!;
        public virtual TblTransactionDetail TransDetail { get; set; } = null!;
    }
}
