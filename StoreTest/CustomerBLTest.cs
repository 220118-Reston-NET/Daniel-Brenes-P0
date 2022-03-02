using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
    public class CustomerBLTest
    {
        [Fact]
        public void Should_Get_All_Customer()
        {
            string customerName = "Daniel";
            int customerId = 1;
            Customer customer = new Customer()
            {
                Name = customerName,
                CustomerId = customerId
            };
            List<Customer> expectedListOfCustomer = new List<Customer>();
            expectedListOfCustomer.Add(customer);

            Mock<IRepo> mockRepo = new Mock<IRepo>();
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IStoreBL customerBL = new StoreBL(mockRepo.Object);

            List<Customer> actualCustomerList = customerBL.GetAllCustomer();

            Assert.Same(expectedListOfCustomer, actualCustomerList);
            Assert.Equal(customerName, actualCustomerList[0].Name);
            Assert.Equal(customerId, actualCustomerList[0].CustomerId);
        }
        [Fact]
        public void CustomerCorrectTypes()
        {
            string customerName = "Daniel";
            int customerId = 1;
            Customer customer = new Customer()
            {
                Name = customerName,
                CustomerId = customerId
            };
            List<Customer> expectedListOfCustomer = new List<Customer>();
            expectedListOfCustomer.Add(customer);

            Mock<IRepo> mockRepo = new Mock<IRepo>();
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IStoreBL customerBL = new StoreBL(mockRepo.Object);

            List<Customer> actualCustomerList = customerBL.GetAllCustomer();

            Assert.Same(expectedListOfCustomer, actualCustomerList);
            Assert.IsType<int>(actualCustomerList[0].CustomerId);
            Assert.IsType<string>(actualCustomerList[0].Name);
            Assert.IsType<string>(actualCustomerList[0].Address);
            Assert.IsType<string>(actualCustomerList[0].Email);
            Assert.IsType<string>(actualCustomerList[0].PhoneNumber);
            Assert.IsType<double>(actualCustomerList[0].Wallet);
        }
        [Fact]
        public void ShouldAddCustomer()
        {
            string customerName = "Test Test";
            string customerAddress = "123 Test Avenue";
            string customerEmail = "test@rocketmail.com";
            string customerPhoneNumber = "8000000123";
            string customerPin = "1234";
            Customer customer = new Customer()
            {
                Name = customerName,
                Email = customerEmail,
                Address = customerAddress,
                PhoneNumber = customerPhoneNumber,
                Pin = customerPin
            };

            List<Customer> expectedListOfCustomers = new List<Customer>();
            Mock<IRepo> mockRepo = new Mock<IRepo>();
            mockRepo.Setup(repo => repo.AddCustomer(customer)).Returns(customer);
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomers);

            IStoreBL storeBL = new StoreBL(mockRepo.Object);
            Customer customer1 = storeBL.AddCustomer(customer);

            Assert.Same(customer, customer1);
            Assert.Equal(customer.Name, customer1.Name);
            Assert.Equal(customer.Email, customer1.Email);
            Assert.Equal(customer.PhoneNumber, customer1.PhoneNumber);
            Assert.Equal(customer.Address, customer1.Address);
            Assert.Equal(customer.Pin, customer1.Pin);
        }
        [Fact]
        public void CustomerShouldSetValidData()
        {
            //Arrange
            Customer customer = new Customer();
            string validCustomer = "New Customer";

            //Act
            customer.Name = validCustomer;

            //Assert
            Assert.NotNull(customer.Name);
            Assert.Equal(validCustomer, customer.Name); 
        }
        [Fact]
        public void CustomerShouldSetValidEmail()
        {
            //Arrange
            Customer customer = new Customer();
            string validEmail = "help@revature.net";

            //Act
            customer.Email = validEmail;

            //Assert
            Assert.NotNull(customer.Email);
            Assert.Equal(validEmail, customer.Email); 
        }
    }
}