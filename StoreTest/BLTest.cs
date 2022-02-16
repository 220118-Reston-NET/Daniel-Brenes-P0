using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class BLTest
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
}
}