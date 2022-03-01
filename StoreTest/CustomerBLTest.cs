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
    // [Fact]
    // public void Search_Customer_By_Name()
    // {
    //     string customerName = "Dan B";
    //     Customer customer = new Customer()
    //     {
    //         Name = customerName
    //     };

    //     List<Customer> testList = new List<Customer>();

    //     testList.Add(customer);

    //     Mock<IRepo> mockRepo = new Mock<IRepo>();
    //     mockRepo.Setup(repo => repo.SearchCustomer(customerName)).Returns(testList);

    //     IStoreBL _storeBL = new StoreBL(mockRepo.Object);
    //     List<Customer> actualList = _storeBL.SearchCustomerByName(customerName);
  
    //     Assert.Same(testList, actualList);
    //     Assert.Equal(customerName, actualList[0].Name); 
    // }
}
}