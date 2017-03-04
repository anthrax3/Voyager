using CMS.Core.DAL;
using CMS.Core.DAL.Models;
using CMS.Core.Services.ConfigService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CMS.Tests.Services
{
    [TestClass]
    public class ConfigServiceTest
    {
        ConfigService service = null;

        [TestInitialize]
        public void Init()
        {
            var db = new Mock<FakeDbContext>();
            db.Setup(x => x.Get<ConfigModel>()).Returns(new FakeDbSet<ConfigModel>()
            {
                new ConfigModel() { ID = 1, Key = "SiteName", Value="Example title" },
                new ConfigModel() { ID = 2, Key = "Description", Value="Example site description" },
                new ConfigModel() { ID = 3, Key = "Tags", Value="Tag1 Tag2 Tag3" }
            });

            service = new ConfigService(db.Object);
        }

        [TestMethod]
        public void TestIfExistingElementExist()
        {
            var result = service.Exist("Tags");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIfNotExistingElementExist()
        {
            var result = service.Exist("DatabaseName");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveExistingElementTest()
        {
            service.RemoveKey("Description");
            Assert.IsFalse(service.Exist("Description"));
        }

        [TestMethod]
        public void RemoveNotExistingElementTest()
        {
            var result = service.RemoveKey("DatabaseName");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddNotExistingElementTest()
        {
            var result = service.AddKey("NewKey", "NewValue");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddExistingElementTest()
        {
            var result = service.AddKey("Description", "NewValue");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetValueOfExistingElementTest()
        {
            var result = service.SetValue("Description", "NewValue");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetValueOfNotExistingElementTest()
        {
            var result = service.SetValue("BadKey", "NewValue");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetValueOfExistingElementTest()
        {
            var result = service.GetValue("Description");
            Assert.AreEqual(result, "Example site description");
        }

        [TestMethod]
        public void GetValueOfNotExistingElementTest()
        {
            var result = service.GetValue("BadKey");
            Assert.IsNull(result);
        }
    }
}
