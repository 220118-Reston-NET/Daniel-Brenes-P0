using Xunit;
using BL;
using StoreModel;
using StoreDL;
using Moq;
using System.Collections.Generic;

namespace StoreTest
{
public class ProductTest
{
    [Fact]
    public void Should_Get_All_Product()
    {
        string productName = "Nike Air Max 3000";
        int productId = 1;
        Product product = new Product()
        {
            ProductId = productId,
            Name = productName
        };
        List<Product> expectedProducts = new List<Product>();
        expectedProducts.Add(product);
        

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetAllProducts()).Returns(expectedProducts);

        IStoreBL customerBL = new StoreBL(mockRepo.Object);

        List<Product> actualProducts = customerBL.GetAllProducts();

        Assert.Same(expectedProducts, actualProducts); 
        Assert.Equal(productName, actualProducts[0].Name); 
        Assert.Equal(productId, actualProducts[0].ProductId); 
    }
    [Fact]
    public void ProductCorrectTypes()
    {
       Product prod = new Product();
        prod.ProductId = 5;

        List<Product> expectedProducts= new List<Product>();
        expectedProducts.Add(prod);

        Mock<IRepo> mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetAllProducts()).Returns(expectedProducts);

        IStoreBL orderBL = new StoreBL(mockRepo.Object);

        List<Product> actualProducts = orderBL.GetAllProducts();

        Assert.Same(expectedProducts, actualProducts); 
        Assert.IsType<int>(actualProducts[0].ProductId);
        Assert.IsType<double>(actualProducts[0].Price);
        Assert.IsType<string>(actualProducts[0].Name);
        Assert.IsType<string>(actualProducts[0].Desc);
    }
    
    [Fact]
        public void ProductShouldSetValidData()
        {
            //Arrange
            Product prod = new Product();
            string validProd = "Jersey";

            //Act
            prod.Name = validProd;
        
            //Assert
            Assert.NotNull(prod.Name);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validProd, prod.Name);//checks if the property does indeed hold the same value as what we set it as
        }
}
}