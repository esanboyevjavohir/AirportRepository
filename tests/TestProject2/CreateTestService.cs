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
using Airways.Core.Entity;
using Airways.DataAccess;
using Moq;

namespace TestProject2
{
    public class CreateTestService
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

        public CreateTestService()
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
        public async Task Airline_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateAirlineModel()
            {
                Name = "Test"
            };

            var responseModel = new CreateAirlineResponceModel() { Id = id };

            _airlineServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _airlineServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Aircraft_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateAircraftModel()
            {
                Name = "Test"
            };

            var responseModel = new CreateAicraftResponceModel() { Id = id };

            _aircraftServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _aircraftServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Class_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateCLassModel()
            {
                className = ClassType.Economy
            };

            var responseModel = new CreateClassResponceModel() { Id = id };

            _classServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _classServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Order_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateOrderModel()
            {
                TotalPrice = 100,
            };

            var responseModel = new CreateOrderResponceModel() { Id = id };

            _orderServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _orderServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Payment_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreatePaymentModel()
            {
                Amount = 100,
            };

            var responseModel = new CreatePaymentResponceModel() { Id = id };

            _paymentServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _paymentServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task PricePolicy_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreatePricePolicyModel()
            {
                DiscountPercentage = 100
            };

            var responseModel = new CreatePricePolicyResponceModel() { Id = id };

            _pricePolicyServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _pricePolicyServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Review_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateReviewModel()
            {
                Rating = 5
            };

            var responseModel = new CreateReviewResponceModel() { Id = id };

            _reviewServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _reviewServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Reys_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateReysModel()
            {
                TicketCount = 50
            };

            var responseModel = new CreateReysResponceModel() { Id = id };

            _reysServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _reysServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Ticket_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new CreateTicketsModel()
            {
                price = 100,
            };

            var responseModel = new CreateTicketResponceModel() { Id = id };

            _ticketServiceMock.Setup(a => a.CreateAsync(createModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseModel);

            var service = _ticketServiceMock.Object;
            var result = await service.CreateAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task User_Create()
        {
            Guid id = Guid.NewGuid();
            var createModel = new UserForCreationDTO() { Name = "test" };

            var responseModel = new User() { Id = id };

            _userServiceMock.Setup(a => a.AddUserAsync(createModel))
                .ReturnsAsync(responseModel);

            var service = _userServiceMock.Object;
            var result = await service.AddUserAsync(createModel);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }
    }
}
