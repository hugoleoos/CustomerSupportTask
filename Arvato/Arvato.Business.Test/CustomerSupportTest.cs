using Arvato.Domain.Adapters;
using Arvato.Domain.Exceptions;
using Arvato.Domain.Models;
using Arvato.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Arvato.Business.Test
{
    public class CustomerSupportTest
    {
        private readonly ICustomerSupportService customerSupportService;
        private readonly Mock<ILogger<CustomerSupportService>> loggerMock;
        private readonly Mock<ICustomerSupportDBAdapter> customerSuportDbMock;        

        public CustomerSupportTest()
        {
            loggerMock = new Mock<ILogger<CustomerSupportService>>();
            customerSuportDbMock = new Mock<ICustomerSupportDBAdapter>();

            customerSupportService = new CustomerSupportService(
                loggerMock.Object, 
                customerSuportDbMock.Object);
        }

        [Fact]
        public async Task CreateCustomerSupport_Success()
        {
            //Arrange
            var customerSupportMock = GetCustomerSupport();

            customerSuportDbMock
                .Setup(m => m.CreateCustomerSupportAsync(It.IsAny<CustomerSupport>()))
                .Callback<CustomerSupport>(
                    (customersupport) =>
                    {
                        Assert.Equal(customerSupportMock.Email,
                            customersupport.Email);
                        Assert.Equal(customerSupportMock.Phone,
                            customersupport.Phone);
                    })
                .ReturnsAsync(1)
                .Verifiable();

            //Act
            var customersId = await customerSupportService.CreateCustomerSupportAsync(
                customerSupportMock);

            //Assert
            Assert.Equal(1, customersId);

            customerSuportDbMock
                .Verify(m => m.CreateCustomerSupportAsync(It.IsAny<CustomerSupport>()), Times.Once);
        }

        [Fact]
        public async Task CreateCustomerSupport_ObjectNull_Error()
        {
            //Act
            await Assert.ThrowsAsync<ArgumentNullException>(async () => 
                await customerSupportService.CreateCustomerSupportAsync(null));
        }

        [Fact]
        public async Task CreateCustomerSupport_RequiredFields_Error()
        {
            //Arrange
            var customerSupportMock = new CustomerSupport()
            {
                Email = "",
                FirstName = "Hugo",
                LastName = "Oliveira",
                Phone = "",
                Number = 236546,
                Inquiry = null,
                DescriptionSupport = string.Empty,
                Aggreement = false
            };

            //Act
            var errors = await Assert.ThrowsAsync<CreateSupportCoreException>(async () =>
                await customerSupportService.CreateCustomerSupportAsync(customerSupportMock));

            //Assert
            Assert.Contains($"The field {nameof(CustomerSupport.Email)} is riquered", errors.Message);
            Assert.Contains($"The field {nameof(CustomerSupport.Phone)} is riquered", errors.Message);
            Assert.Contains($"The field {nameof(CustomerSupport.Inquiry)} is riquered", errors.Message);
            Assert.Contains($"The field {nameof(CustomerSupport.DescriptionSupport)} is riquered", errors.Message);
            Assert.Contains($"The field {nameof(CustomerSupport.Aggreement)} is riquered", errors.Message);
        }

        [Fact]
        public async Task GetCustomerSupport_Success()
        {
            //Arrange           
            customerSuportDbMock
                .Setup(m => m.GetCustomerSupportAsync(It.IsAny<int>()))
                .Callback<int>(
                    (customerId) =>
                    {
                        Assert.Equal(1, customerId);
                    })
                .ReturnsAsync(GetCustomerSupport())
                .Verifiable();

            //Act
            var customerData = await customerSupportService.GetCustomerSupportAsync(1);

            //Assert
            Assert.NotNull(customerData);
            Assert.True(customerData.Email == "hugotest@test.com");

            customerSuportDbMock
                .Verify(m => m.GetCustomerSupportAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task CreateCustomerSupport_CustomerNotFound_Error()
        {
            //Act
            var errors = await Assert.ThrowsAsync<CreateSupportCoreException>(async () =>
                await customerSupportService.GetCustomerSupportAsync(1));

            //Assert
            Assert.Contains("Customer not found", errors.Message);
        }

        private static CustomerSupport GetCustomerSupport()
        {
            return new CustomerSupport()
            {
                Email = "hugotest@test.com",
                FirstName = "Hugo",
                LastName = "Oliveira",
                Phone = "+553198720-2924",
                Number = 236546,
                Inquiry = Domain.Models.Enums.EInquiry.DiscussCustomerChallenge,
                DescriptionSupport = "challenge with a new solution delivered....",
                Aggreement = true
            };
        }
    }
}