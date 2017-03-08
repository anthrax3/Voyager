using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.App_Start
{
    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public void SetLocations(List<String> locations)
        {
            ViewLocationFormats = locations.ToArray();
            PartialViewLocationFormats = locations.ToArray();
        }
    }
}