using NUnit.Framework;
using SharpArch.Core;
using XAIL.Core;

namespace Tests.XAIL.Core
{
    [TestFixture]
    public class NewsTests
    {
        [Test]
        public void CanCreateNews()
        {
            var title = "new 1";
            var body = "This is bbc news blah...";
            var news = new News(title) { Body = body };

            Assert.That(news.Title, Is.EqualTo(title));
            Assert.That(news.Body, Is.EqualTo(body));
            Assert.That(news.CreatedAt, Is.Not.Null);
        }

        [Test]
        [ExpectedException(typeof(PreconditionException))]
        public void CannotCreateNewsWithoutTitle()
        {
            new News(" ");
        }

        [Test]
        public void CanCompareNews()
        {
            var title = "title 1";
            var news = new News(title);
            Assert.That(news, Is.EqualTo(new News(title)));
        }
    }
}
