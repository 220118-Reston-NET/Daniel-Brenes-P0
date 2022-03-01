using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class StoreFrontTest
{
    [Fact]
    public void Should_Get_All_StoreFront()
    {
        string storeName = "Jamba Juice";
        int storeId = 3;
        StoreFront storeFront = new StoreFront()
        {
            StoreID = storeId,
            Name = storeName
        };

        List<StoreFront> expectedStoreFronts = new List<StoreFront>();
        expectedStoreFronts.Add(storeFront);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetAllStoreFront()).Returns(expectedStoreFronts);

        IStoreBL customerBL = new StoreBL(mockRepo.Object);

        List<StoreFront> actualStores = customerBL.GetAllStoreFront();

        Assert.Same(expectedStoreFronts, actualStores); 
        Assert.Equal(storeName, actualStores[0].Name); 
        Assert.Equal(storeId, actualStores[0].StoreID); 
    }

    [Fact]
    public void StoreFrontShouldSetValidData()
    {
        //Arrange
        StoreFront store = new StoreFront();
        string validStore = "Target";

        //Act
        store.Name = validStore;
        
        //Assert
        Assert.NotNull(store.Name);//checks that the property is not null meaning we did set data in this property
        Assert.Equal(validStore, store.Name);//checks if the property does indeed hold the same value as what we set it as    
    }
}
}