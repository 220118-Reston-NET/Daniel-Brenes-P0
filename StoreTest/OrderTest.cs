using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class OrderTest
{
    [Fact]
    public void Should_Get_All_Order()
    {
        int storeId = 3;
        Order order = new Order()
        {
            StoreFrontId = storeId
        };

        List<Order> expectedOrders = new List<Order>();
        expectedOrders.Add(order);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetAllOrders()).Returns(expectedOrders);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<Order> actualOrders = orderBL.GetAllOrders();

        Assert.Same(expectedOrders, actualOrders); 
        Assert.Equal(storeId, actualOrders[0].StoreFrontId); 
    }
    [Fact]
    public void OrderCorrectTypes()
    {
        Order order = new Order();
        order.OrderId = 5;

        List<Order> expectedOrders = new List<Order>();
        expectedOrders.Add(order);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetAllOrders()).Returns(expectedOrders);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<Order> actualOrders = orderBL.GetAllOrders();

        Assert.Same(expectedOrders, actualOrders); 
        Assert.IsType<int>(actualOrders[0].OrderId);
        Assert.IsType<double>(actualOrders[0].Total);
        Assert.IsType<int>(actualOrders[0].CustomerId);
        Assert.IsType<int>(actualOrders[0].StoreFrontId);
    }

    [Fact]
    public void OrderShouldSetValidData()
    {
        //Arrange
        Order order = new Order();
        int validOrder = 1122;

        //Act
        order.OrderId = validOrder;
        
        //Assert
        Assert.IsType<int>(order.OrderId);//checks that the property is not null meaning we did set data in this property
        Assert.Equal(validOrder, order.OrderId);//checks if the property does indeed hold the same value as what we set it as    
    }

}
}