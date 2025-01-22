using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public  class PricePolicy:BaseEntity,IAuditedEntity
    {
        public decimal DiscountPercentage { get; set; }
        public string Conditions { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
