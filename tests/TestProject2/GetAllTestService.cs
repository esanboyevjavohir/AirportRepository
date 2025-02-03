using Airways.Application.DTO;
using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Airline;
using Airways.Application.Models.Classs;
using Airways.Application.Models.Order;
using Airways.Application.Models.Payment;
using Airways.Application.Models.PricePolycy;
using Airways.Application.Models.Review;
using Airways.Application.Models.Reys;
using Airways.Application.Models.Ticket;
using Airways.Application.Services;
using Moq;

namespace TestProject2
{
    public class GetAllTestService
    {
        private readonly Mock<IAirlineService> _airlineServiceMock;
        private readonly Mock<IClassService> _classServiceMock;
        private readonly Mock<IAircraftService> _aircraftServiceMock;
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly Mock<IPricePolicyService> _pricePolicyServiceMock;
        private readonly Mock<IReviewservice> _reviewServiceMock;
        private readonly Mock<IReysService> _reysServiceMock;
        private readonly Mock<ITicketService> _ticketServiceMock;
        private readonly Mock<IUserService> _userServiceMock;

        public GetAllTestService()
        {
            _airlineServiceMock = new Mock<IAirlineService>();
            _classServiceMock = new Mock<IClassService>();
            _aircraftServiceMock = new Mock<IAircraftService>();
            _orderServiceMock = new Mock<IOrderService>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _pricePolicyServiceMock = new Mock<IPricePolicyService>();
            _reviewServiceMock = new Mock<IReviewservice>();
            _reysServiceMock = new Mock<IReysService>();
            _ticketServiceMock = new Mock<ITicketService>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Airline_GetAll()
        {
            var airlines = new List<AirlineResponceModel>()
            {
                new AirlineResponceModel() { Id = Guid.NewGuid(), Name = "Airline 1" },
                new AirlineResponceModel() { Id = Guid.NewGuid(), Name = "Airline 2" }
            };

            _airlineServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(airlines);

            var service = _airlineServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(airlines.Count, result.Count);
        }

        [Fact]
        public async Task Class_GetAll()
        {
            var classes = new List<ClassResponceModel>()
            {
                new ClassResponceModel(){ Id = Guid.NewGuid(), className = ClassType.Economy },
                new ClassResponceModel(){ Id = Guid.NewGuid(), className = ClassType.Business }
            };

            _classServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(classes);

            var service = _classServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(classes.Count, result.Count);
        }

        [Fact]
        public async Task Aircraft_GetAll()
        {
            var aircrafts = new List<AicraftResponceModel>()
            {
                new AicraftResponceModel(){Id = Guid.NewGuid(), Name = "Aircraft 1"},
                new AicraftResponceModel(){Id = Guid.NewGuid(), Name = "Aircraft 2"}
            };

            _aircraftServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(aircrafts);

            var service = _aircraftServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(aircrafts.Count, result.Count);
        }

        [Fact]
        public async Task Order_GetAll()
        {
            var orders = new List<OrderResponceModel>()
            {
                new OrderResponceModel(){Id = Guid.NewGuid(), TotalPrice = 100 },
                new OrderResponceModel(){Id = Guid.NewGuid(), TotalPrice = 150 }
            };

            _orderServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(orders);

            var service = _orderServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(orders.Count, result.Count());
        }

        [Fact]
        public async Task Payment_GetAll()
        {
            var payments = new List<PaymentResponceModel>()
            {
                new PaymentResponceModel(){ Id = Guid.NewGuid(), Amount = 100 },
                new PaymentResponceModel(){ Id = Guid.NewGuid(), Amount = 200 }
            };

            _paymentServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(payments);

            var service = _paymentServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(payments.Count, result.Count);
        }

        [Fact]
        public async Task PricePolicy_GetAll()
        {
            var pricePolicy = new List<PricePolicyResponceModel>()
            {
                new PricePolicyResponceModel(){ Id = Guid.NewGuid(), DiscountPercentage = 10 },
                new PricePolicyResponceModel(){ Id = Guid.NewGuid(), DiscountPercentage = 12 }
            };

            _pricePolicyServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(pricePolicy);

            var service = _pricePolicyServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(pricePolicy.Count, result.Count);
        }

        [Fact]
        public async Task Review_GetAll()
        {
            var review = new List<ReviewResponceModel>()
            {
                new ReviewResponceModel(){ Id = Guid.NewGuid(), Rating = 5 },
                new ReviewResponceModel(){ Id = Guid.NewGuid(), Rating = 4 }
            };

            _reviewServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(review);

            var service = _reviewServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(review.Count, result.Count);
        }

        [Fact]
        public async Task Reys_GetAll()
        {
            var reys = new List<ReysResponceModel>()
            {
                new ReysResponceModel(){ Id = Guid.NewGuid(), TicketCount = 100 },
                new ReysResponceModel(){ Id = Guid.NewGuid(), TicketCount = 110 }
            };

            _reysServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(reys);

            var service = _reysServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(reys.Count, result.Count());
        }

        [Fact]
        public async Task Ticket_GetAll()
        {
            var tickets = new List<TicketResponceModel>()
            {
                new TicketResponceModel(){ Id = Guid.NewGuid(), price = 100 },
                new TicketResponceModel(){ Id = Guid.NewGuid(), price = 200 }
            };

            _ticketServiceMock.Setup(a => a.GetAllAsync()).ReturnsAsync(tickets);

            var service = _ticketServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(tickets.Count, result.Count);
        }

        [Fact]
        public async Task Users_GetAll()
        {
            var users = new List<UserDTO>()
            {
                new UserDTO(){ Id = Guid.NewGuid(), Name = "test", Email = "test1", Address = "test2"},
                new UserDTO(){ Id = Guid.NewGuid(), Name = "test3", Email = "test4", Address = "test5"},
            };

            _userServiceMock.Setup(u => u.GetAllAsync()).ReturnsAsync(users);

            var service = _userServiceMock.Object;
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count);
        }
    }
}
