using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Reys:BaseEntity,IAuditedEntity
    {
        public Tariff Tariff { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public  Airline? Airline { get; set; }
        public  Guid Airline_id { get; set; }
        public  Aircraft? Aircraft { get; set; }
        public  Guid Aircraft_id { get; set; }
        public List<User> Users { get; set; }
        public List<Review> Review=new List<Review>();
        public List<Ticket> Tickets = new List<Ticket>();
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
