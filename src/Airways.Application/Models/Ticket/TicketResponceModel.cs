using System.ComponentModel.DataAnnotations;

namespace Airways.Application.Models.Ticket
{
    public class TicketResponceModel : BaseResponceModel
    {
        public double price { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal AdditionalCharge { get; set; }
        DateTime OrderTime { get; set; }
        public int SeatNumber { get; set; }
        Status status { get; set; }
    }
}
