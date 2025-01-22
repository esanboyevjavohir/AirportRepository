using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Order:BaseEntity,IAuditedEntity
    {
        public decimal TotalPrice { get; set; }
        public User User { get; set; }
        public Guid User_id { get; set; }
        public  Ticket Ticket { get; set; }
        public Guid Ticket_id { get; set; }
        public  List<Payment> Payment = new List<Payment>();
        public string?  CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
