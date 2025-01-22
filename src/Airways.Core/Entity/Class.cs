using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Class:BaseEntity,IAuditedEntity
    {
        public Tariff TariffName { get; set; }
        public string Description { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public enum Tariff
    {
        Economy = 1000,
        Business = 2000,
        FirstClass = 3000
    }
}
