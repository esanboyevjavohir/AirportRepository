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
using Airways.Core.Entity;
using Moq;
using System.Linq.Expressions;

namespace TestProject2
{
    public class UpdateTestService
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

        public UpdateTestService()
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
        public async Task UpdateAirline_ShouldReturnModel()
        {
            Guid id = Guid.NewGuid();

            UpdateAirlineModel airlineModel = new UpdateAirlineModel()
            {
                Name = "Test",
                Country = "Uzbekistan",
                Code = Guid.NewGuid()
            };

            UpdateAirlineResponceModel airlineResponceModel = new UpdateAirlineResponceModel()
            {
                Id = id
            };

            _airlineServiceMock.Setup(service => service.UpdateAsync(id, airlineModel))
                .ReturnsAsync(airlineResponceModel);

            var service = _airlineServiceMock.Object;

            var result = await service.UpdateAsync(id, airlineModel);
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Class_Update()
        {
            Guid id = Guid.NewGuid();

            var updateModel = new UpdateClassModel()
            {
                className = ClassType.Economy,
                description = "Test",
            };

            var responseModel = new UpdateClassResponceModel { Id = id };

            _classServiceMock.Setup(c => c.UpdateAsync(id, updateModel, 
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _classServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Aircraft_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateAicraftModel()
            {
                Name = "Test",
                Description = "Test",
                Model = "test",
                SeatCapacity = 50,
                Airline_id = Guid.NewGuid()
            };

            var responseModel = new UpdateAicraftResponceModel() { Id = id };

            _aircraftServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _aircraftServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Order_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateOrderModel()
            {
                TotalPrice = 100,
                User_id = Guid.NewGuid(),
                Ticked_id = Guid.NewGuid()
            };

            var responseModel = new UpdateOrderResponceModel() { Id = id };

            _orderServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _orderServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task PricePolicy_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdatePricePolicyModel()
            {
                DiscountPercentage = 100,
                Conditions = "test"
            };

            var responseModel = new UpdatePricePolicyResponceModel() { Id = id };

            _pricePolicyServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _pricePolicyServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Review_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateReviewModel()
            {
                Rating = 5,
                Comment = "test",
                User_id = Guid.NewGuid(),
                Reys_id = Guid.NewGuid()
            };

            var responseModel = new UpdateReviewResponceModel() { Id = id };

            _reviewServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reviewServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Payment_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdatePaymentModel()
            {
                Amount = 100,
                payStatus = Airways.Application.Models.Payment.PayStatus.Paid,
                paymentType = Airways.Application.Models.Payment.CardType.Uzcard,
                User_id = Guid.NewGuid(),
                Order_id = Guid.NewGuid()
            };

            var responseModel = new UpdatePaymentResponceModel() { Id = id };

            _paymentServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _paymentServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Reys_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateReysModel()
            {
                TicketCount = 50
            };

            var responseModel = new UpdateReysResponceModel() { Id = id };

            _reysServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _reysServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Ticket_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateTicketModel()
            {
                price = 50
            };

            var responseModel = new UpdateTicketResponceModel() { Id = id };

            _ticketServiceMock.Setup(a => a.UpdateAsync(id, updateModel,
                It.IsAny<CancellationToken>())).ReturnsAsync(responseModel);

            var service = _ticketServiceMock.Object;
            var result = await service.UpdateAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task User_Update()
        {
            Guid id = Guid.NewGuid();
            var updateModel = new UpdateUserDTO()
            {
                Name = "Test"
            };

            var responseModel = new User() { Id = id };

            _userServiceMock.Setup(a => a.UpdateUserAsync(id, updateModel))
            .ReturnsAsync(responseModel);

            var service = _userServiceMock.Object;
            var result = await service.UpdateUserAsync(id, updateModel);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }
    }
}
