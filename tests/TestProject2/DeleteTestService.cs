using Airways.Application.Services;
using Moq;

namespace TestProject2
{
    public class DeleteTestService
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

        public DeleteTestService()
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
        public async Task DeleteClass_ShouldReturnTrue()
        {
            Guid id = Guid.Parse("0194b28b-dafe-7f87-af25-f92861da22db");

            _classServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _classServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAirline_ShouldReturnTrue()
        {
            // Arrange
            Guid id = Guid.Parse("0194b289-7ec8-71fd-8763-626b74eb4e48");

            _airlineServiceMock
                .Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _airlineServiceMock.Object;

            // Act
            var result = await service.DeleteAsync(id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAircraft_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _aircraftServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _aircraftServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteOrder_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _orderServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _orderServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeletePayment_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _paymentServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _paymentServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeletePricePolicy_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _pricePolicyServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _pricePolicyServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteReview_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _reviewServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _reviewServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteReys_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _reysServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _reysServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTicket_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _ticketServiceMock.Setup(service => service.DeleteAsync(id))
                .ReturnsAsync(true);

            var service = _ticketServiceMock.Object;

            var result = await service.DeleteAsync(id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_ShouldReturnTrue()
        {
            Guid id = Guid.NewGuid();

            _userServiceMock.Setup(service => service.DeleteUserAsync(id))
                .ReturnsAsync(true);

            var service = _userServiceMock.Object;

            var result = await service.DeleteUserAsync(id);

            Assert.True(result);
        }
    }
}