using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class LineItemTest
{
    [Fact]
    public void Should_Get_All_LineItem()
    {
        int myOrder = 3;
        LineItem lineItem = new LineItem()
        {
            OrderId = myOrder
        };

        List<LineItem> expectedLineItems = new List<LineItem>();
        expectedLineItems.Add(lineItem);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetLineItemByOrderId(myOrder)).Returns(expectedLineItems);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<LineItem> actualLineItems = orderBL.GetLineItemByOrderId(myOrder);

        Assert.Same(expectedLineItems, actualLineItems); 
        Assert.Equal(expectedLineItems[0].OrderId, actualLineItems[0].OrderId); 
    }

    [Fact]
    public void LineItemshouldSetValidData()
    {
        //Arrange
        LineItem lineitem = new LineItem();
        int validOrder = 333;

        //Act
        lineitem.OrderId = validOrder;
        
        //Assert
        Assert.IsType<int>(lineitem.OrderId);//checks that the property is not null meaning we did set data in this property
        Assert.Equal(validOrder, lineitem.OrderId);//checks if the property does indeed hold the same value as what we set it as    
    }
    [Fact]
    public void LineItemCorrectTypes()
    {
        LineItem lineItem = new LineItem();
        lineItem.OrderId = 5;

        List<LineItem> expectedLineItems = new List<LineItem>();
        expectedLineItems.Add(lineItem);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetLineItemByOrderId(lineItem.OrderId)).Returns(expectedLineItems);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<LineItem> actualLineItems = orderBL.GetLineItemByOrderId(lineItem.OrderId);

        Assert.Same(expectedLineItems, actualLineItems); 
        Assert.IsType<int>(actualLineItems[0].ProductId);
        Assert.IsType<string>(actualLineItems[0].ProductName);
        Assert.IsType<int>(actualLineItems[0].Quantity);
        Assert.IsType<int>(actualLineItems[0].OrderId);
        Assert.IsType<double>(actualLineItems[0].subTotal);
    }
}
}