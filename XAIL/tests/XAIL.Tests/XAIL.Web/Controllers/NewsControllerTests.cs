using System.Collections.Generic;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Rhino.Mocks;
using SharpArch.Core.PersistenceSupport;
using XAIL.Core;
using XAIL.Web.Controllers;

namespace Tests.XAIL.Web.Controllers
{
    [TestFixture]
    public class NewsControllerTests
    {
        [Test]
        public void CanListAllNews()
        {
            var controller = new NewsController(CreateMockNewsRepository());

            var result = controller.Index(1)
                .AssertViewRendered()
                .ForView("Index");

            Assert.That(result.ViewData, Is.Not.Null);
            Assert.That(result.ViewData.Model as List<News>, Is.Not.Null);
            Assert.That((result.ViewData.Model as List<News>).Count, Is.EqualTo(2));
        }

        public IRepository<News> CreateMockNewsRepository()
        {
            var mocks = new MockRepository();
            var mockedRepository = mocks.StrictMock<IRepository<News>>();
            Expect.Call(mockedRepository.GetAll())
                .IgnoreArguments()
                .Return(createNews());

            mocks.Replay(mockedRepository);

            return mockedRepository;
        }

        private IList<News> createNews()
        {
            return new List<News>
                       {
                           new News("news 1"),
                           new News("news 2"),
                           new News("news 3"),
                           new News("news 4"),
                       };
        }
    }
}
