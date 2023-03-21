using HelsiTest.Core.Entities;
using HelsiTest.Core.Repositories;
using HelsiTest.Core.Services.Implementations;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test
{
    public class ListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckAccessRights()
        {
            var mockRepo = new Mock<IListRepository>();
            var mockLogg = new Mock<ILogger<ListService>>();
            mockRepo.Setup(a => a.CheckPermisstionAsync(1, 1)).Returns(Task.FromResult(true));
            mockRepo.Setup(a => a.CheckPermisstionAsync(1, 2)).Returns(Task.FromResult(false));
            mockRepo.Setup(a => a.GetListAsync(1, 1)).Returns(Task.FromResult(new ListEntity { Id = 1, OwnerId = 1, Name = "Test" }));

            var listService = new ListService(mockLogg.Object, mockRepo.Object);

            var possResult = listService.GetListAsync(1, 1);
            possResult.Wait();

            Assert.IsTrue(possResult.Result.Id == 1);
        }
        //TODO: Add Mock for DBContext, Add tests for Repositories
    }
}