using CMS.Core.Models;
using CMS.Core.Services.Templates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CMS.Tests.Services
{
    [TestClass]
    public class TemplatesServiceTest
    {
        TemplatesService service = null;

        [TestInitialize]
        public void Init()
        {
            var db = new Mock<FakeDbContext>();
            db.Setup(x => x.Set<TemplateModel>()).Returns(new FakeDbSet<TemplateModel>()
            {
                new TemplateModel() { ID = 1, Name = "T1", Active = false },
                new TemplateModel() { ID = 2, Name = "T2", Active = true },
                new TemplateModel() { ID = 3, Name = "T3", Active = false }
            });

            service = new TemplatesService(db.Object);
        }

        [TestMethod]
        public void GetExistingActiveTemplate()
        {
            var result = service.GetActiveTemplate();
            Assert.IsTrue(result != null && result.Name == "T2");
        }

        [TestMethod]
        public void SetExistngTemplateAsActive()
        {
            var result = service.SetTemplateAsActive("T1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetNotExistngTemplateAsActive()
        {
            var result = service.SetTemplateAsActive("T4");
            Assert.IsFalse(result);
        }
    }
}
