using ContosoRecipiesApi.Controllers;
using ContosoRecipiesApi.DAL;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContoseRecipes.Tests
{
    public class RecipesControllerTests
    {
        private IUnitOfWork _unitOfWork;
        private RecipesController _controller;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _controller = new RecipesController(_unitOfWork);
        }

        [Test]
        public async Task GetRecipes_ReturnsTheCorrectRecipes()
        {
            // Arrange
            var expectedRecipes = A.CollectionOfDummy<Recipe>(5).AsEnumerable();
            A.CallTo(() => _unitOfWork.RecipeRepository.Get(null, null, "Directions,Ingredients"))
                .Returns(Task.FromResult(expectedRecipes));

            // Act
            var actionResult = await _controller.GetRecipes(5);

            // Assert
            var result = actionResult.Result as OkObjectResult;
            var responseRecipes = result.Value as IEnumerable<Recipe>;
            Assert.IsNotNull(responseRecipes);
            Assert.IsTrue(expectedRecipes.Count() == responseRecipes.Count());
        }
    }
}