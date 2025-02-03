using Airways.Application.Models.Aicraft;
using Airways.Application.Models.Airline;
using Airways.Application.Services;
using Moq;

namespace TestProject2
{
    public class GetByIdTestService
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

        public GetByIdTestService()
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
        public async Task Airline_GetById()
        {
            Guid id = Guid.NewGuid();

            var responseModel = new AirlineResponceModel() { Id = id, Name = "test", Country = "Uzb" };

            _airlineServiceMock.Setup(a => a.GetByIdAsync(id)).ReturnsAsync(responseModel);

            var service = _airlineServiceMock.Object;
            var result = await service.GetByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(responseModel.Id, result.Id);
        }

        [Fact]
        public async Task Aircraft_GetById()
        {
            Guid id = Guid.NewGuid();

            var responseModel = new AicraftResponceModel() { Id = id };

            _aircraftServiceMock.Setup(a => a.GetByIdAsync(id)).ReturnsAsync(responseModel);

            var service = _aircraftServiceMock.Object;
            var result = await service.GetByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
    }
}
