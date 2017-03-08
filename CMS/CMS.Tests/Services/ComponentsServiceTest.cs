using CMS.Core.Models;
using CMS.Core.Services.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Tests.Services
{
    [TestClass]
    class ComponentsServiceTest
    {
        IComponentsLoaderService service = null;

        [TestInitialize]
        public void Init()
        {
            /*var db = new Mock<FakeDbContext>();
            db.Setup(x => x.Set<ComponentModel>()).Returns(new FakeDbSet<ComponentModel>()
            {
                new ComponentModel() { ID = 1, Name = "SiteName",  = "Example title" },
                new ComponentModel() { ID = 2, Name = "Description", DirName = "Example site description" },
                new ComponentModel() { ID = 3, Name = "Tags", DirName = "Tag1 Tag2 Tag3" }
            });*/

            //service = new ComponentsService(db.Object);
        }
    }
}
