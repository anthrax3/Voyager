﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Web.Areas.Administrator.ViewModels
{
    public class ComponentSiteDataViewModel
    {
        public String Controller { get; set; }
        public String Action { get; set; }
        public List<String> Parameters { get; set; }
    }
}