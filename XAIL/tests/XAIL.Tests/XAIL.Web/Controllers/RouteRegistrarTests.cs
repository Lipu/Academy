namespace Tests.XAIL.Controllers
{
    using System.Web.Routing;

    using MvcContrib.TestHelper;

    using NUnit.Framework;

    using global::XAIL.Web.Controllers;

    [TestFixture]
    public class RouteRegistrarTests
    {
        #region Public Methods

        [Test]
        public void CanVerifyRouteMaps()
        {
            "~/".Route().ShouldMapTo<HomeController>(x => x.Index());
        }

        [SetUp]
        public void SetUp()
        {
            RouteTable.Routes.Clear();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        #endregion
    }
}