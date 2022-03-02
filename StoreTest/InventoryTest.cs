using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class InventoryTest
{
    [Fact]
    public void Should_Get_All_Inventory()
    {
        int storeFront = 7;
        Inventory inv = new Inventory()
        {
            StoreFrontId = storeFront
        };

        List<Inventory> expectedInventory = new List<Inventory>();
        expectedInventory.Add(inv);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetInventoryByStoreFront(storeFront)).Returns(expectedInventory);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<Inventory> actualInventory = orderBL.GetInventoryByStoreFront(storeFront);

        Assert.Same(expectedInventory, actualInventory); 
        Assert.Equal(expectedInventory[0].StoreFrontId, actualInventory[0].StoreFrontId); 
    }

    [Fact]
    public void InventoryShouldSetValidData()
    {
        //Arrange
        Inventory inv = new Inventory();
        int productId = 11;
        int storeFrontId = 7; 

        //Act
        inv.StoreFrontId = storeFrontId;
        inv.ProductId = productId;
        
        //Assert
        Assert.IsType<int>(inv.ProductId);
        Assert.IsType<int>(inv.StoreFrontId);
        Assert.Equal(productId, inv.ProductId); 
        Assert.Equal(storeFrontId, inv.StoreFrontId); 
    }
    [Fact]
    public void InventoryCorrectTypes()
    {
        Inventory inv = new Inventory();
        inv.StoreFrontId = 5;

        List<Inventory> expectedInventory = new List<Inventory>();
        expectedInventory.Add(inv);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetInventoryByStoreFront(inv.StoreFrontId)).Returns(expectedInventory);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<Inventory> actualInventory = orderBL.GetInventoryByStoreFront(inv.StoreFrontId);

        Assert.Same(expectedInventory, actualInventory); 
        Assert.IsType<int>(actualInventory[0].ProductId);
        Assert.IsType<string>(actualInventory[0].ProductName);
        Assert.IsType<int>(actualInventory[0].Quantity);
        Assert.IsType<int>(actualInventory[0].StoreFrontId);
    }
}
}