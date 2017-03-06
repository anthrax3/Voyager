﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Core.Models
{
    public class ComponentInstances
    {
        public int ID { get; set; }
        public int PositionID { get; set; }
        public virtual PositionModel Position { get; set; }
        public int ComponentActionID { get; set; }
        public virtual ComponentActions ComponentAction { get; set; }
    }
}