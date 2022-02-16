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
    [Fact]
    public void Search_Customer_By_Id()
    {
        // int id = 7;
        // Customer customer = new Customer()
        // {
        //     CustomerId = 7
        // };

        // List<Customer> testList = new List<Customer>();

        // testList.Add(customer);

        // Mock<IRepo> mockRepo = new Mock<IRepo>();
        // mockRepo.Setup(repo => repo.SearchCustomerById(id)).Returns(testList);

        // IStoreBL _storeBL = new StoreBL(mockRepo.Object);
        // List<Customer> actualList = _storeBL.SearchCustomerById(id);
  
        // Assert.Same(testList, actualList);
        // Assert.Equal(id, actualList[0].CustomerId); 
    }
}
}