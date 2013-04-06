using System.Linq;
using EventPlanning.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventPlanning.Tests.Repositories
{
    [TestClass]
    public class SessionRepositoryTests
    {
        private SessionRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new SessionRepository();
        }

        [TestMethod]
        public void CanGetSessions()
        {
            Assert.IsTrue(_repository.GetAll().Any());
        }
    }
}
