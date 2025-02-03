using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Ticket : BaseEntity, IAuditedEntity
    {
        public decimal MaxCharge { get; set; }
        public decimal AdditionalCharge { get; set; }
        public DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        public Status Status { get; set; } = Status.Available;
        public Guid Reys_id { get; set; }
        public Reys Reys { get; set; }
        public Guid User_id { get; set; }
        public User User { get; set; }
        public Guid Class_id { get; set; }
        public Class Class { get; set; }
        public Guid Payment_id { get; set; }
        public Payment Payment { get; set; }
        public DateTime? ReservationExpiresOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public enum Status
    {
        Available,
        Sold
    }
}
